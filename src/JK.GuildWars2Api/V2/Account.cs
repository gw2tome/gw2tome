using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JK.GuildWars2Api.V2
{
    public class Account
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///  The age of the account in seconds.
        /// </summary>
        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("world")]
        public int WorldId { get; set; }

        [JsonPropertyName("guilds")]
        public IEnumerable<string> GuildIds { get; set; }

        /// <summary>
        /// A list of guilds the account is leader of. Requires the additional guilds scope.
        /// </summary>
        [JsonPropertyName("guild_leader")]
        public IEnumerable<string> GuildLeader { get; set; }

        [JsonPropertyName("created")]
        public DateTimeOffset Created { get; set; }

        [JsonPropertyName("access")]
        public IEnumerable<string> Access { get; set; }

        [JsonPropertyName("commander")]
        public bool Commander { get; set; }
    }
}
