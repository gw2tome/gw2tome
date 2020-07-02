using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V2
{
    public class Item
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }

        [JsonPropertyName("vendor_value")]
        public int VendorValue { get; set; }

        [JsonPropertyName("game_types")]
        public string[] GameTypes { get; set; }

        [JsonPropertyName("flags")]
        public string[] Flags { get; set; }

        [JsonPropertyName("restrictions")]
        public string[] Restrictions { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("chat_link")]
        public string ChatLink { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("details")]
        public ItemDetail Details { get; set; }
    }
}
