using System.Text;
using Newtonsoft.Json;

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
        /// 指定されたテキストをMisskeyに投稿します。
        /// </summary>
        /// <param name="baseUrl">MisskeyインスタンスのAPIベースURL。</param>
        /// <param name="accessToken">アクセストークン。</param>
        /// <param name="sendText">投稿するテキスト。</param>
        public async Task PostAsync(string baseUrl, string accessToken, string sendText)
        {
            // 画像投稿は未実装のため、fileIdは常にnull
            string? fileId = null;
            await CreateNoteAsync(baseUrl, accessToken, sendText, fileId);
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