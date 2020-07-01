using GuildWars2Tome.Models.GuidWarsApi;

namespace GuildWars2Tome.Models
{
    public class RankPermission
    {
        public RankPermission(GuildPermission guildPermission)
        {
            this.Name = guildPermission.Name;
            this.Description = guildPermission.Description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
