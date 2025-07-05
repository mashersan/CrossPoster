using IniParser;
using IniParser.Model;
using CrossPoster.Models;

namespace CrossPoster.Services
{
    /// <summary>
    /// settings.iniファイルの読み込みと書き込みを管理するクラス。
    /// </summary>
    public class SettingsManager
    {
        private readonly string _filePath = "./settings.ini";
        private readonly FileIniDataParser _parser = new FileIniDataParser();

        /// <summary>
        /// settings.iniファイルを読み込み、AppSettingsオブジェクトとして返します。
        /// ファイルが存在しない場合は、空の設定で新しいファイルを作成します。
        /// </summary>
        /// <returns>読み込まれた設定情報。</returns>
        public AppSettings Load()
        {
            if (!File.Exists(_filePath))
            {
                // アプリ初回起動時などに、空のiniファイルを作成する
                Save(new AppSettings());
            }

            IniData data = _parser.ReadFile(_filePath);
            var settings = new AppSettings
            {
                Twitter = new TwitterSettings
                {
                    ConsumerKey = data["TWITTER"]["ConsumerKey"],
                    ConsumerKeySecret = data["TWITTER"]["ConsumerKeySecret"],
                    AccessToken = data["TWITTER"]["AccessToken"],
                    AccessTokenSecret = data["TWITTER"]["AccessTokenSecret"]
                },
                Bluesky = new BlueskySettings
                {
                    Account = data["BLUESKY"]["Account"],
                    Password = data["BLUESKY"]["Password"]
                },
                Misskey = new MisskeySettings
                {
                    BaseUrl = data["MISSKEY"]["BaseUrl"],
                    AccessToken = data["MISSKEY"]["AccessToken"]
                }
            };
            return settings;
        }

        /// <summary>
        /// AppSettingsオブジェクトの内容をsettings.iniファイルに書き込みます。
        /// </summary>
        /// <param name="settings">保存する設定情報。</param>
        public void Save(AppSettings settings)
        {
            var data = new IniData();
            data["TWITTER"]["ConsumerKey"] = settings.Twitter.ConsumerKey ?? "";
            data["TWITTER"]["ConsumerKeySecret"] = settings.Twitter.ConsumerKeySecret ?? "";
            data["TWITTER"]["AccessToken"] = settings.Twitter.AccessToken ?? "";
            data["TWITTER"]["AccessTokenSecret"] = settings.Twitter.AccessTokenSecret ?? "";

            data["BLUESKY"]["Account"] = settings.Bluesky.Account ?? "";
            data["BLUESKY"]["Password"] = settings.Bluesky.Password ?? "";

            data["MISSKEY"]["BaseUrl"] = settings.Misskey.BaseUrl ?? "";
            data["MISSKEY"]["AccessToken"] = settings.Misskey.AccessToken ?? "";

            _parser.WriteFile(_filePath, data);
        }
    }
}