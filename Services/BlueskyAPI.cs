using X.Bluesky;
using X.Bluesky.Models; // Post, Imageクラスのために追加

namespace CrossPoster.Services
{
    /// <summary>
    /// Bluesky APIとの通信を担当するサービスクラス。
    /// </summary>
    internal class BlueskyService
    {
        /// <summary>
        /// 指定されたテキストと画像をBlueskyに投稿します。
        /// </summary>
        /// <param name="account">BlueskyのアカウントID (例: user.bsky.social)。</param>
        /// <param name="password">アプリパスワード。</param>
        /// <param name="sendText">投稿するテキスト。</param>
        /// <param name="imagePath">添付する画像のパス。</param>
        public async Task PostAsync(string account, string password, string sendText, string? imagePath)
        {
            try
            {
                IBlueskyClient blueskyClient = new BlueskyClient(account, password);

                X.Bluesky.Models.Image[]? imagesToEmbed = null;

                // 画像パスが指定されていれば、投稿オブジェクトを作成する前に画像の準備を済ませる
                if (!string.IsNullOrEmpty(imagePath))
                {
                    byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);
                    imagesToEmbed = new[]
                    {
                        // 'Image'の競合を避けるため、X.Bluesky.Models.Image とフルネームで指定
                        new X.Bluesky.Models.Image
                        {
                            Content = imageBytes,
                            MimeType = "image/jpeg", // MIMEタイプを指定
                            Alt = "" // 代替テキスト
                        }
                    };
                }

                // 送信する投稿内容をPostオブジェクトとして構築
                // オブジェクト初期化子の中で Images プロパティを設定する
                var post = new Post
                {
                    Text = sendText,
                    Images = imagesToEmbed
                };

                // 作成したPostオブジェクトを送信
                await blueskyClient.Post(post);
            }
            catch (Exception ex)
            {
                // 投稿失敗時に、より詳細なエラーメッセージを含む例外をスローする
                throw new Exception($"Failed to post to Bluesky: {ex.Message}", ex);
            }
        }
    }
}