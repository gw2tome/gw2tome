using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V1
{
    public class Guild
    {
        [JsonPropertyName("guild_id")]
        public string Id { get; set; }

        [JsonPropertyName("guild_name")]
        public string Name { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("emblem")]
        public GuildEmblem Emblem { get; set; }

        public string FullName => $"{this.Name} [{this.Tag}]";
    }
}
