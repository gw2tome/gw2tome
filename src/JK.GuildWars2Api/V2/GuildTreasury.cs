using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V2
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
