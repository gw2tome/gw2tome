using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V2
{
    public class GuildInventory
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
