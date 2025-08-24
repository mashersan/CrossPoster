using CrossPoster.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;

namespace CrossPoster.Services
{
    /// <summary>
    /// アプリケーションのアップデートを確認するクラス。
    /// </summary>
    public class UpdateChecker
    {
        private const string VersionCheckUrl = "https://raw.githubusercontent.com/mashersan/CrossPoster/refs/heads/master/version.json";
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// 新しいバージョンが利用可能か確認し、ダイアログで通知します。
        /// </summary>
        public async Task CheckForUpdateAsync()
        {
            try
            {
                // 現在のアプリケーションのバージョンを取得
                var currentVersion = new Version(Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0");

                // Webから最新のバージョン情報を取得
                var response = await _httpClient.GetStringAsync(VersionCheckUrl);
                var versionInfo = JsonConvert.DeserializeObject<VersionInfo>(response);

                if (versionInfo == null || string.IsNullOrEmpty(versionInfo.LatestVersion))
                {
                    return; // バージョン情報が取得できなければ何もしない
                }

                var latestVersion = new Version(versionInfo.LatestVersion);

                // 現在のバージョンより新しいバージョンがリリースされているか比較
                if (latestVersion > currentVersion)
                {
                    ShowUpdateNotification(versionInfo);
                }
            }
            catch (Exception ex)
            {
                // バージョンチェック中にエラーが発生しても、アプリの動作を妨げないように握りつぶす
                Debug.WriteLine($"Update check failed: {ex.Message}");
            }
        }

        /// <summary>
        /// アップデート通知のダイアログを表示します。
        /// </summary>
        private void ShowUpdateNotification(VersionInfo versionInfo)
        {
            var message = $"新しいバージョン {versionInfo.LatestVersion} が利用可能です。\n\n";
            message += $"リリースノート:\n{versionInfo.ReleaseNotes}\n\n";
            message += "ダウンロードページを開きますか？";

            var result = MessageBox.Show(message, "アップデートのお知らせ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // ユーザーの既定のブラウザでGitHubのURLを開く
                    Process.Start(new ProcessStartInfo(versionInfo.GithubUrl) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"URLを開けませんでした: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}