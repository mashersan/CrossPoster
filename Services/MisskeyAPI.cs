using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CrossPoster.Services
{
    /// <summary>
    /// Misskey APIとの通信を担当するサービスクラス。
    /// </summary>
    internal class MisskeyService
    {
        // HttpClientはアプリケーション全体で使いまわすのがベストプラクティス
        private static readonly HttpClient _misskeyClient = new HttpClient();

        /// <summary>
        /// 指定されたテキストと画像をMisskeyに投稿します。
        /// </summary>
        /// <param name="baseUrl">MisskeyインスタンスのAPIベースURL。</param>
        /// <param name="accessToken">アクセストークン。</param>
        /// <param name="sendText">投稿するテキスト。</param>
        /// <param name="imagePath">添付する画像のパス。</param>
        public async Task PostAsync(string baseUrl, string accessToken, string sendText, string? imagePath)
        {
            string? fileId = null;
            if (!string.IsNullOrEmpty(imagePath))
            {
                // 画像をアップロードし、fileIdを取得
                fileId = await UploadFileAsync(baseUrl, accessToken, imagePath);
            }
            // 取得したfileIdを使ってノートを作成
            await CreateNoteAsync(baseUrl, accessToken, sendText, fileId);
        }

        /// <summary>
        /// Misskeyにファイルをアップロードする内部メソッド。
        /// </summary>
        private async Task<string?> UploadFileAsync(string baseUrl, string accessToken, string imagePath)
        {
            using var multipartContent = new MultipartFormDataContent();

            // i (アクセストークン) を追加
            multipartContent.Add(new StringContent(accessToken), "i");

            // 画像ファイルを追加
            byte[] fileBytes = await File.ReadAllBytesAsync(imagePath);
            var fileContent = new ByteArrayContent(fileBytes);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            multipartContent.Add(fileContent, "file", Path.GetFileName(imagePath));

            var response = await _misskeyClient.PostAsync($"{baseUrl}/drive/files/create", multipartContent);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var parsedJson = JObject.Parse(jsonResponse);
                // アップロードされたファイルのIDを返す
                return parsedJson["id"]?.ToString();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to upload file to Misskey. Status: {response.StatusCode}, Content: {errorContent}");
            }
        }

        /// <summary>
        /// Misskeyのノートを作成する内部メソッド。
        /// </summary>
        private async Task CreateNoteAsync(string baseUrl, string accessToken, string sendText, string? fileId)
        {
            // JSONで送信するために改行文字をエスケープ
            string escapedText = sendText.Replace("\r\n", "\\n").Replace("\r", "\\n").Replace("\n", "\\n");

            // 送信するデータを匿名オブジェクトとして定義
            var payload = new
            {
                i = accessToken,
                text = escapedText,
                fileIds = string.IsNullOrEmpty(fileId) ? null : new[] { fileId }
            };

            // NullValueHandling.Ignore を指定して、fileIdsがnullの場合にJSONに含まれないようにする
            var jsonIn = JsonConvert.SerializeObject(payload, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var content = new StringContent(jsonIn, Encoding.UTF8, "application/json");

            var response = await _misskeyClient.PostAsync($"{baseUrl}/notes/create", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to post to Misskey. Status: {response.StatusCode}, Content: {errorContent}");
            }
        }
    }
}