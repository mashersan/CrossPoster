using X.Bluesky;

namespace CrossPoster.Services
{
    /// <summary>
    /// Bluesky APIとの通信を担当するサービスクラス。
    /// </summary>
    internal class BlueskyService
    {
        /// <summary>
        /// 指定されたテキストをBlueskyに投稿します。
        /// </summary>
        /// <param name="account">BlueskyのアカウントID (例: user.bsky.social)。</param>
        /// <param name="password">アプリパスワード。</param>
        /// <param name="sendText">投稿するテキスト。</param>
        public async Task PostAsync(string account, string password, string sendText)
        {
            try
            {
                IBlueskyClient blueskyClient = new BlueskyClient(account, password);
                await blueskyClient.Post(sendText);
            }
            catch (Exception ex)
            {
                // 投稿失敗時に、より詳細なエラーメッセージを含む例外をスローする
                throw new Exception($"Failed to post to Bluesky: {ex.Message}", ex);
            }
        }
    }
}