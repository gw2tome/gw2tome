using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V2
{
    public class GuildTreasuryNeededBy
    {
        [JsonPropertyName("upgrade_id")]
        public int UpgradeId { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
