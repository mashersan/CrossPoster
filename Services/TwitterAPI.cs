using System.Text;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using Newtonsoft.Json;
using System.Net.Http;

namespace CrossPoster.Services
{
    /// <summary>
    /// Twitter APIとの通信を担当するサービスクラス。
    /// </summary>
    internal class TwitterService
    {
        private readonly ITwitterClient _twitterClient;

        public TwitterService(ITwitterClient client)
        {
            _twitterClient = client;
        }

        /// <summary>
        /// 指定されたテキストと画像をTwitterに投稿します。
        /// </summary>
        /// <param name="sendText">投稿するテキスト。</param>
        /// <param name="imagePath">添付する画像のパス。</param>
        public async Task PostAsync(string sendText, string? imagePath)
        {
            string? mediaId = null;
            if (!string.IsNullOrEmpty(imagePath))
            {
                // 画像ファイルをバイト配列に読み込み
                byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);
                // Tweetinviのv1 APIを使ってメディアをアップロード
                var uploadedImage = await _twitterClient.Upload.UploadTweetImageAsync(imageBytes);
                mediaId = uploadedImage.Id.ToString();
            }

            // v2 API用のリクエストボディを作成
            var tweetParams = new TweetV2PostRequest
            {
                Text = sendText,
                Media = string.IsNullOrEmpty(mediaId) ? null : new Media { MediaIds = new[] { mediaId } }
            };

            // NullValueHandling.Ignore を指定して、mediaがnullの場合にJSONに含まれないようにする
            var jsonBody = JsonConvert.SerializeObject(tweetParams, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var result = await _twitterClient.Execute.AdvanceRequestAsync(
                (request) =>
                {
                    request.Query.Url = "https://api.twitter.com/2/tweets";
                    // `HttpMethod`が複数のライブラリに存在するため、`Tweetinvi.Models`のものだと明示する
                    request.Query.HttpMethod = Tweetinvi.Models.HttpMethod.POST;
                    request.Query.HttpContent = content;
                }
            );

            // APIからの応答が成功でなかった場合に例外をスローする
            if (!result.Response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to post to Twitter. Status: {result.Response.StatusCode}, Content: {result.Content}");
            }
        }
    }

    /// <summary>
    /// Twitter API v2へPOSTリクエストを送信するためのデータ構造。
    /// </summary>
    public class TweetV2PostRequest
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("media")]
        public Media? Media { get; set; }
    }

    public class Media
    {
        [JsonProperty("media_ids")]
        public string[] MediaIds { get; set; } = [];
    }
}