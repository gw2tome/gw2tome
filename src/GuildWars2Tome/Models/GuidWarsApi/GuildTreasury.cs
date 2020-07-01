using System.Text.Json.Serialization;

namespace GuildWars2Tome.Models.GuidWarsApi
{
    public class GuildTreasury
    {
        [JsonPropertyName("item_id")]
        public int ItemId { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("needed_by")]
        public GuildTreasuryNeededBy[] NeededBy { get; set; }
    }
}
