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

        #endregion

        #region Form Lifecycle

        /// <summary>
        /// MainFormのコンストラクタ。
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            LoadSettingsAndApply();
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
            string textToPost = postTextBox.Text;
            var postTasks = new List<Tuple<string, Task>>();

            // 連続クリックを防ぐためにボタンを無効化
            postButton.Enabled = false;

            // 各SNSのチェックボックスと文字数を確認し、投稿タスクを作成
            if (checkBoxX.Checked)
            {
                if (textToPost.Length > 140)
                {
                    MessageBox.Show("Twitterは140文字以内で入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    postTasks.Add(new Tuple<string, Task>("Twitter", PostToTwitterAsync(textToPost, _mediaPath)));
                }
            }

            if (checkBoxBluesky.Checked)
            {
                if (textToPost.Length > 300)
                {
                    MessageBox.Show("Blueskyは300文字以内で入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    postTasks.Add(new Tuple<string, Task>("Bluesky", PostToBlueskyAsync(textToPost, _mediaPath)));
                }
            }

            if (checkBoxMisskey.Checked)
            {
                if (textToPost.Length > 3000)
                {
                    MessageBox.Show("Misskeyは3000文字以内で入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    postTasks.Add(new Tuple<string, Task>("Misskey", PostToMisskeyAsync(textToPost, _mediaPath)));
                }
            }

            // 投稿先が選択されていない場合はメッセージを表示
            if (!postTasks.Any())
            {
                MessageBox.Show("投稿先のSNSを選択してください。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                postButton.Enabled = true;
                return;
            }

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
        /// 添付メディアをクリアします。
        /// </summary>
        private void ClearMedia()
        {
            _mediaPath = null;
            pictureBox.Image = null;
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