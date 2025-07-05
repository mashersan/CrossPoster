using System.Text;
using Tweetinvi;
using Tweetinvi.Models;
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
        /// 指定されたテキストをTwitterに投稿します。
        /// </summary>
        /// <param name="sendText">投稿するテキスト。</param>
        public async Task PostAsync(string sendText)
        {
            var tweetParams = new TweetV2PostRequest { Text = sendText };

            var jsonBody = _twitterClient.Json.Serialize(tweetParams);
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
    }
}