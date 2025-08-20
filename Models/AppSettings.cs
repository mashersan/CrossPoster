namespace CrossPoster.Models
{
    /// <summary>
    /// Twitterの認証情報を保持します。
    /// </summary>
    public class TwitterSettings
    {
        public string ConsumerKey { get; set; } = string.Empty;
        public string ConsumerKeySecret { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string AccessTokenSecret { get; set; } = string.Empty;

        /// <summary>
        /// 全ての認証情報が設定済みかを示す便利なプロパティ。
        /// </summary>
        public bool IsConfigured => !string.IsNullOrEmpty(ConsumerKey) && !string.IsNullOrEmpty(ConsumerKeySecret) && !string.IsNullOrEmpty(AccessToken) && !string.IsNullOrEmpty(AccessTokenSecret);
    }

    /// <summary>
    /// Blueskyの認証情報を保持します。
    /// </summary>
    public class BlueskySettings
    {
        public string Account { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 全ての認証情報が設定済みかを示す便利なプロパティ。
        /// </summary>
        public bool IsConfigured => !string.IsNullOrEmpty(Account) && !string.IsNullOrEmpty(Password);
    }

    /// <summary>
    /// Misskeyの認証情報を保持します。
    /// </summary>
    public class MisskeySettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// 全ての認証情報が設定済みかを示す便利なプロパティ。
        /// </summary>
        public bool IsConfigured => !string.IsNullOrEmpty(BaseUrl) && !string.IsNullOrEmpty(AccessToken);
    }

    /// <summary>
    /// アプリケーションの一般的な設定を保持します。
    /// </summary>
    public class GeneralSettings
    {
        public bool LastUsedTwitter { get; set; } = false;
        public bool LastUsedBluesky { get; set; } = false;
        public bool LastUsedMisskey { get; set; } = false;
    }


    /// <summary>
    /// アプリケーション全体の設情報を集約するクラス。
    /// </summary>
    public class AppSettings
    {
        public TwitterSettings Twitter { get; set; } = new TwitterSettings();
        public BlueskySettings Bluesky { get; set; } = new BlueskySettings();
        public MisskeySettings Misskey { get; set; } = new MisskeySettings();
        public GeneralSettings General { get; set; } = new GeneralSettings();
    }
}