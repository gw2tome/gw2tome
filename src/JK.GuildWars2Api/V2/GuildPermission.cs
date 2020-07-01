using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V2
{
    public class GuildPermission
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
