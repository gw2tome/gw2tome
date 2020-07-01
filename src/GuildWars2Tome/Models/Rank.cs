using GuildWars2Tome.Models.GuidWarsApi;
using System.Collections.Generic;

namespace GuildWars2Tome.Models
{
    public class Rank
    {
        public Rank(GuildRank guildRank)
        {
            this.Permissions = new List<RankPermission>();
            this.Icon = guildRank.Icon;
            this.Id = guildRank.Id;
        }

        public string Id { get; set; }
        public string Icon { get; set; }

        public List<RankPermission> Permissions { get; set; }
    }
}
