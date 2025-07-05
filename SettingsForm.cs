using CrossPoster.Models;
using CrossPoster.Services;
using System;
using System.Windows.Forms;

namespace CrossPoster
{
    /// <summary>
    /// アプリケーションの設定を行うフォーム。
    /// </summary>
    public partial class SettingsForm : Form
    {
        #region Fields

        private readonly SettingsManager _settingsManager = new SettingsManager();

        /// <summary>
        /// アプリケーションの設定を保持するオブジェクト。
        /// null! (null forgiving operator) を使用し、コンストラクタ内で必ず初期化されることをコンパイラに伝えています。
        /// </summary>
        private AppSettings _settings = null!;

        #endregion

        #region Form Lifecycle

        public SettingsForm()
        {
            InitializeComponent();
            SetupPlaceholders();
            LoadSettings();
        }

        #endregion

        #region UI Event Handlers

        /// <summary>
        /// 保存ボタンがクリックされたときの処理。
        /// </summary>
        private void saveButton_Click(object sender, EventArgs e)
        {
            // UIのテキストボックスから設定オブジェクトに値を反映
            _settings.Twitter.ConsumerKey = settingTwitterConsumerKey.Text;
            _settings.Twitter.ConsumerKeySecret = settingTwitterConsumerKeySecret.Text;
            _settings.Twitter.AccessToken = settingTwitterAccessToken.Text;
            _settings.Twitter.AccessTokenSecret = settingTwitterAccessTokenSecret.Text;

            _settings.Bluesky.Account = settingBlueskyAccount.Text;
            _settings.Bluesky.Password = settingBlueskyAppPassword.Text;

            _settings.Misskey.BaseUrl = settingMisskeyBaseUrl.Text;
            _settings.Misskey.AccessToken = settingMisskeyAccessToken.Text;

            // マネージャークラス経由で設定をファイルに保存
            _settingsManager.Save(_settings);

            MessageBox.Show("設定を保存しました。", "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        /// <summary>
        /// キャンセルボタンがクリックされたときの処理。
        /// </summary>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// フォームロード時に、各テキストボックスにプレースホルダー（入力例）を設定します。
        /// </summary>
        private void SetupPlaceholders()
        {
            settingBlueskyAccount.PlaceholderText = "例: account.bsky.social";
            settingBlueskyAppPassword.PlaceholderText = "xxxx-xxxx-xxxx-xxxx";
            settingMisskeyBaseUrl.PlaceholderText = "例: https://misskey.io/api";
        }

        /// <summary>
        /// 設定ファイルを読み込み、その内容を各テキストボックスに表示します。
        /// </summary>
        private void LoadSettings()
        {
            _settings = _settingsManager.Load();

            // Twitter
            settingTwitterConsumerKey.Text = _settings.Twitter.ConsumerKey;
            settingTwitterConsumerKeySecret.Text = _settings.Twitter.ConsumerKeySecret;
            settingTwitterAccessToken.Text = _settings.Twitter.AccessToken;
            settingTwitterAccessTokenSecret.Text = _settings.Twitter.AccessTokenSecret;

            // Bluesky
            settingBlueskyAccount.Text = _settings.Bluesky.Account;
            settingBlueskyAppPassword.Text = _settings.Bluesky.Password;

            // Misskey
            settingMisskeyBaseUrl.Text = _settings.Misskey.BaseUrl;
            settingMisskeyAccessToken.Text = _settings.Misskey.AccessToken;
        }

        #endregion
    }
}