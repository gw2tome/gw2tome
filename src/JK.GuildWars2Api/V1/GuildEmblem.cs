using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V1
{
    public class GuildEmblem
    {
        [JsonPropertyName("background_id")]
        public int BackgroundId { get; set; }

        [JsonPropertyName("foreground_id")]
        public int ForegroundId { get; set; }

        [JsonPropertyName("flags")]
        public List<object> Flags { get; set; }

        [JsonPropertyName("background_color_id")]
        public int BackgroundColorId { get; set; }

        [JsonPropertyName("foreground_primary_color_id")]
        public int ForegroundPrimaryColorId { get; set; }

        [JsonPropertyName("foreground_secondary_color_id")]
        public int ForegroundSecondaryColorId { get; set; }
    }
}
