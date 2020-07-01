using System.Text.Json.Serialization;

namespace GuildWars2Tome.Models.GuidWarsApi
{
    public class GuildUpgradeCost
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("item_id")]
        public int ItemId { get; set; }
    }
}
