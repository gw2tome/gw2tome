using System;
using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V2
{
    public class GuildMember
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rank")]
        public string Rank { get; set; }

        [JsonPropertyName("joined")]
        public DateTimeOffset? Joined { get; set; }
    }
}
