using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V2
{
    public class ItemDetail
    {
        [JsonPropertyName("no_sell_or_sort")]
        public bool NoSellOrSort { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }
    }
}
