using Newtonsoft.Json;

namespace CrossPoster.Models
{
    /// <summary>
    /// Webから取得するバージョン情報を格納するクラス。
    /// </summary>
    public class VersionInfo
    {
        [JsonProperty("latestVersion")]
        public string LatestVersion { get; set; } = string.Empty;

        [JsonProperty("releaseNotes")]
        public string ReleaseNotes { get; set; } = string.Empty;

        [JsonProperty("githubUrl")]
        public string GithubUrl { get; set; } = string.Empty;

        [JsonProperty("websiteUrl")]
        public string WebsiteUrl { get; set; } = string.Empty;
    }
}