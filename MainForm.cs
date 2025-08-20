using CrossPoster.Models;
using CrossPoster.Services;
using System.Security.Policy;
using Tweetinvi;

namespace CrossPoster
{
    /// <summary>
    /// メインの投稿フォーム。UIの操作と各SNSへの投稿指示を担当します。
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        /// <summary>
        /// 設定ファイルの読み書きを管理するマネージャー。
        /// </summary>
        private readonly SettingsManager _settingsManager = new SettingsManager();

        /// <summary>
        /// アプリケーションの設定を保持するオブジェクト。
        /// null! (null forgiving operator) を使用し、コンストラクタ内で必ず初期化されることをコンパイラに伝えています。
        /// </summary>
        private AppSettings _settings = null!;

        /// <summary>
        /// 添付するメディアファイルのパス。
        /// </summary>
        private string? _mediaPath = null;

        // 各SNSの画像ファイルサイズ上限 (バイト単位)
        private const long TWITTER_IMAGE_SIZE_LIMIT = 5 * 1024 * 1024; // 5MB
        private const long BLUESKY_IMAGE_SIZE_LIMIT = 1 * 1024 * 1024; // 1MB
        private const long MISSKEY_IMAGE_SIZE_LIMIT = 10 * 1024 * 1024; // 10MB (サーバーにより異なる)

        // メディアが各SNSの要件を満たしているかの状態を保持
        private bool _isMediaValidForTwitter = true;
        private bool _isMediaValidForBluesky = true;
        private bool _isMediaValidForMisskey = true;

        #endregion

        #region Form Lifecycle

        /// <summary>
        /// MainFormのコンストラクタ。
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            // フォームのLoadイベントハンドラを登録
            this.Load += new System.EventHandler(this.MainForm_Load);
        }

        /// <summary>
        /// フォームが読み込まれたときの処理。
        /// </summary>
        private async void MainForm_Load(object? sender, EventArgs e) // ★修正点: sender を object? に変更
        {
            LoadSettingsAndApply();

            // アップデートチェックを実行
            var updateChecker = new UpdateChecker();
            await updateChecker.CheckForUpdateAsync();
        }

        /// <summary>
        /// 設定を読み込み、UIに適用します。
        /// </summary>
        private void LoadSettingsAndApply()
        {
            _settings = _settingsManager.Load();
            UpdateCheckBoxesState();

            // 保存された前回のチェック状態を復元
            checkBoxX.Checked = _settings.General.LastUsedTwitter;
            checkBoxBluesky.Checked = _settings.General.LastUsedBluesky;
            checkBoxMisskey.Checked = _settings.General.LastUsedMisskey;
        }

        #endregion

        #region UI Event Handlers

        /// <summary>
        /// 送信ボタンがクリックされたときの処理。
        /// </summary>
        private async void postButton_Click(object sender, EventArgs e)
        {
            // --- 投稿前バリデーション ---
            var validationErrors = new List<string>();

            // メディアファイルのサイズチェック
            if (!string.IsNullOrEmpty(_mediaPath))
            {
                if (checkBoxX.Checked && !_isMediaValidForTwitter)
                    validationErrors.Add("X (Twitter): 画像サイズが5MBを超えています。");
                if (checkBoxBluesky.Checked && !_isMediaValidForBluesky)
                    validationErrors.Add("Bluesky: 画像サイズが1MBを超えています。");
                if (checkBoxMisskey.Checked && !_isMediaValidForMisskey)
                    validationErrors.Add("Misskey: 画像サイズが10MBを超えています。");
            }

            // 文字数チェック
            string textToPost = postTextBox.Text;
            if (checkBoxX.Checked && textToPost.Length > 140)
                validationErrors.Add("X (Twitter): 140文字を超えています。");
            if (checkBoxBluesky.Checked && textToPost.Length > 300)
                validationErrors.Add("Bluesky: 300文字を超えています。");
            if (checkBoxMisskey.Checked && textToPost.Length > 3000)
                validationErrors.Add("Misskey: 3000文字を超えています。");

            // 投稿先未選択チェック
            if (!checkBoxX.Checked && !checkBoxBluesky.Checked && !checkBoxMisskey.Checked)
            {
                MessageBox.Show("投稿先のSNSを選択してください。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // バリデーションエラーがあればメッセージを表示して処理を中断
            if (validationErrors.Any())
            {
                MessageBox.Show("以下の問題により投稿できませんでした：\n\n" + string.Join("\n", validationErrors),
                                "投稿エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // --- バリデーションここまで ---


            // 連続クリックを防ぐためにボタンを無効化
            postButton.Enabled = false;

            // 投稿タスクを作成
            var postTasks = new List<Tuple<string, Task>>();
            if (checkBoxX.Checked)
                postTasks.Add(new Tuple<string, Task>("Twitter", PostToTwitterAsync(textToPost, _mediaPath)));
            if (checkBoxBluesky.Checked)
                postTasks.Add(new Tuple<string, Task>("Bluesky", PostToBlueskyAsync(textToPost, _mediaPath)));
            if (checkBoxMisskey.Checked)
                postTasks.Add(new Tuple<string, Task>("Misskey", PostToMisskeyAsync(textToPost, _mediaPath)));

            // 作成した投稿タスクをすべて非同期で実行
            var results = new List<string>();
            bool hasSuccess = false; // 少なくとも1つの投稿が成功したか
            foreach (var taskInfo in postTasks)
            {
                try
                {
                    await taskInfo.Item2;
                    results.Add($"{taskInfo.Item1}: 投稿に成功しました。");
                    hasSuccess = true;
                }
                catch (Exception ex)
                {
                    results.Add($"{taskInfo.Item1}: 投稿に失敗しました。\n  エラー: {ex.Message}");
                }
            }

            // 少なくとも1つの投稿が成功した場合、チェックボックスの状態を保存
            if (hasSuccess)
            {
                _settings.General.LastUsedTwitter = checkBoxX.Checked;
                _settings.General.LastUsedBluesky = checkBoxBluesky.Checked;
                _settings.General.LastUsedMisskey = checkBoxMisskey.Checked;
                _settingsManager.Save(_settings);
            }

            // すべての投稿結果をまとめて表示
            MessageBox.Show(string.Join("\n\n", results), "投稿結果", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ボタンを再度有効化
            postButton.Enabled = true;

            // 投稿後、テキストボックスと添付画像をクリアするか確認
            var clearResult = MessageBox.Show("入力内容をクリアしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (clearResult == DialogResult.Yes)
            {
                postTextBox.Text = string.Empty;
                ClearMedia();
            }
        }

        /// <summary>
        /// 投稿テキストボックスの文字数が変更されるたびに文字数カウンターを更新する処理。
        /// </summary>
        private void postTextBox_TextChanged(object sender, EventArgs e)
        {
            int length = postTextBox.Text.Length;

            // Twitterカウンターの更新
            twitterCharCountLabel.Text = $"{length} / 140";
            twitterCharCountLabel.ForeColor = length > 140 ? Color.Red : SystemColors.ControlText;

            // Blueskyカウンターの更新
            blueskyCharCountLabel.Text = $"{length} / 300";
            blueskyCharCountLabel.ForeColor = length > 300 ? Color.Red : SystemColors.ControlText;

            // Misskeyカウンターの更新
            misskeyCharCountLabel.Text = $"{length} / 3000";
            misskeyCharCountLabel.ForeColor = length > 3000 ? Color.Red : SystemColors.ControlText;
        }

        /// <summary>
        /// メニューの「設定」がクリックされたときの処理。
        /// </summary>
        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // usingステートメントで、フォームが閉じられたときにリソースが自動的に解放されるようにする
            using (var form2 = new SettingsForm()) // Form2をSettingsFormに変更
            {
                form2.ShowDialog();
            }
            // 設定画面が閉じられた後、変更をUIに反映するために設定を再読み込み
            LoadSettingsAndApply();
        }

        /// <summary>
        /// メニューの「終了」がクリックされたときの処理。
        /// </summary>
        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 「メディア選択」ボタンがクリックされたときの処理。
        /// </summary>
        private void selectMediaButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "画像ファイル(*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _mediaPath = ofd.FileName;
                    pictureBox.ImageLocation = _mediaPath;
                    ValidateMedia(_mediaPath);
                }
            }
        }

        /// <summary>
        /// 「クリア」ボタンがクリックされたときの処理。
        /// </summary>
        private void clearMediaButton_Click(object sender, EventArgs e)
        {
            ClearMedia();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 添付されたメディアのファイルサイズを検証し、UIに結果を表示します。
        /// </summary>
        /// <param name="filePath">検証するファイルのパス。</param>
        private void ValidateMedia(string? filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                // ファイルパスがなければ全検証をリセット
                _isMediaValidForTwitter = true;
                _isMediaValidForBluesky = true;
                _isMediaValidForMisskey = true;
                twitterMediaStatusLabel.Text = "";
                blueskyMediaStatusLabel.Text = "";
                misskeyMediaStatusLabel.Text = "";
                return;
            }

            try
            {
                var fileInfo = new FileInfo(filePath);
                long fileSize = fileInfo.Length;

                // Twitterのサイズチェック
                _isMediaValidForTwitter = fileSize <= TWITTER_IMAGE_SIZE_LIMIT;
                twitterMediaStatusLabel.Text = _isMediaValidForTwitter ? "" : "サイズ超過";

                // Blueskyのサイズチェック
                _isMediaValidForBluesky = fileSize <= BLUESKY_IMAGE_SIZE_LIMIT;
                blueskyMediaStatusLabel.Text = _isMediaValidForBluesky ? "" : "サイズ超過";

                // Misskeyのサイズチェック
                _isMediaValidForMisskey = fileSize <= MISSKEY_IMAGE_SIZE_LIMIT;
                misskeyMediaStatusLabel.Text = _isMediaValidForMisskey ? "" : "サイズ超過";
            }
            catch (Exception ex)
            {
                // ファイル情報の取得に失敗した場合
                MessageBox.Show($"ファイル情報の取得に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearMedia();
            }
        }

        /// <summary>
        /// 添付メディアをクリアします。
        /// </summary>
        private void ClearMedia()
        {
            _mediaPath = null;
            pictureBox.Image = null;
            // メディアをクリアしたら検証ステータスもリセット
            ValidateMedia(null);
        }


        /// <summary>
        /// 設定に基づいて、各SNSのチェックボックスの有効/無効を切り替えます。
        /// </summary>
        private void UpdateCheckBoxesState()
        {
            checkBoxX.Enabled = _settings.Twitter.IsConfigured;
            checkBoxBluesky.Enabled = _settings.Bluesky.IsConfigured;
            checkBoxMisskey.Enabled = _settings.Misskey.IsConfigured;

            // 設定が無効な場合はチェックも外す
            if (!checkBoxX.Enabled) checkBoxX.Checked = false;
            if (!checkBoxBluesky.Enabled) checkBoxBluesky.Checked = false;
            if (!checkBoxMisskey.Enabled) checkBoxMisskey.Checked = false;
        }

        /// <summary>
        /// Twitterへの投稿処理を呼び出すヘルパーメソッド。
        /// </summary>
        /// <param name="text">投稿するテキスト。</param>
        /// <param name="imagePath">添付する画像のパス。</param>
        private Task PostToTwitterAsync(string text, string? imagePath)
        {
            var twitterClient = new TwitterClient(_settings.Twitter.ConsumerKey, _settings.Twitter.ConsumerKeySecret, _settings.Twitter.AccessToken, _settings.Twitter.AccessTokenSecret);
            var twitterService = new TwitterService(twitterClient);
            return twitterService.PostAsync(text, imagePath);
        }

        /// <summary>
        /// Blueskyへの投稿処理を呼び出すヘルパーメソッド。
        /// </summary>
        /// <param name="text">投稿するテキスト。</param>
        /// <param name="imagePath">添付する画像のパス。</param>
        private Task PostToBlueskyAsync(string text, string? imagePath)
        {
            var blueskyService = new BlueskyService();
            return blueskyService.PostAsync(_settings.Bluesky.Account, _settings.Bluesky.Password, text, imagePath);
        }

        /// <summary>
        /// Misskeyへの投稿処理を呼び出すヘルパーメソッド。
        /// </summary>
        /// <param name="text">投稿するテキスト。</param>
        /// <param name="imagePath">添付する画像のパス。</param>
        private Task PostToMisskeyAsync(string text, string? imagePath)
        {
            var misskeyService = new MisskeyService();
            return misskeyService.PostAsync(_settings.Misskey.BaseUrl, _settings.Misskey.AccessToken, text, imagePath);
        }

        #endregion
    }
}