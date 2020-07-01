using System.Text.Json.Serialization;

namespace GuildWars2Tome.Models.GuidWarsApi
{
    public class GuildTreasuryNeededBy
    {
        [JsonPropertyName("upgrade_id")]
        public int UpgradeId { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
