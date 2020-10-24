using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V2
{
    public class TokenInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("permissions")]
        public string[] Permissions { get; set; }
    }
}
