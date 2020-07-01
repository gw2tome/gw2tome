using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V2
{
    public class GuildStash
    {
        [JsonPropertyName("upgrade_id")]
        public int UpgradeId { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("coins")]
        public int Coins { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }

        [JsonPropertyName("inventory")]
        public GuildInventory[] Inventory { get; set; }
    }
}
