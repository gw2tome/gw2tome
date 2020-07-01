using System.Text.Json.Serialization;

namespace GuildWars2Tome.Models.GuidWarsApi
{
    public class GuildInventory
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
