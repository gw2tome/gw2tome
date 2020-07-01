using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V2
{
    public class GuildRank
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("permissions")]
        public string[] Permissions { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}
