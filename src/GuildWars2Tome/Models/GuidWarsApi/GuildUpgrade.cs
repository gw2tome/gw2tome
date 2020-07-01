using System.Text.Json.Serialization;

namespace GuildWars2Tome.Models.GuidWarsApi
{
    public class GuildUpgrade
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("build_time")]
        public int BuildTime { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("type")]
        public string UpgradeType { get; set; }

        [JsonPropertyName("required_level")]
        public int RequiredLevel { get; set; }

        [JsonPropertyName("experience")]
        public int Experience { get; set; }

        [JsonPropertyName("prerequisites")]
        public int[] Prerequisites { get; set; }

        [JsonPropertyName("bag_max_items")]
        public int BagMaxItems { get; set; }

        [JsonPropertyName("bag_max_coins")]
        public int BagMaxCoins { get; set; }

        [JsonPropertyName("costs")]
        public GuildUpgradeCost[] Costs { get; set; }
    }
}
