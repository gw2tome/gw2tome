using GuildWars2Tome.Models.GuidWarsApi;
using System;

namespace GuildWars2Tome.Models
{
    public class Member
    {
        public Member(GuildMember guildMember)
        {
            this.Name = guildMember.Name;
            this.Rank = guildMember.Rank;
            this.Joined = guildMember.Joined;
        }

        public string Name { get; set; }

        public string Rank { get; set; }

        public DateTimeOffset? Joined { get; set; }

        public string JoinedDisplay => !this.Joined.HasValue ? "Unknown" : this.Joined.Value.ToLocalTime().ToString();
    }
}
