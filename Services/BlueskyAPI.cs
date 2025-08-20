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
                Post post; // 送信するPostオブジェクトを宣言

                // 画像パスの有無でPostオブジェクトの生成を分ける
                if (!string.IsNullOrEmpty(imagePath))
                {
                    // --- 画像がある場合 ---
                    byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);
                    var imagesToEmbed = new[]
                    {
                        new X.Bluesky.Models.Image
                        {
                            Content = imageBytes,
                            MimeType = "image/jpeg",
                            Alt = ""
                        }
                    };

                    // Imagesプロパティを含めてオブジェクトを生成
                    post = new Post
                    {
                        Text = sendText,
                        Images = imagesToEmbed // ここで non-null な値が設定される
                    };
                }
                else
                {
                    // --- 画像がない場合 ---
                    // Imagesプロパティを設定せずにオブジェクトを生成
                    post = new Post
                    {
                        Text = sendText
                    };
                }

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