using JK.GuildWars2Api.V2;
using System.Collections.Generic;

namespace GuildWars2Tome.Models
{
    public class Stash
    {      
        public Stash(GuildStash stash, GuildUpgrade upgrade)
        {
            this.Items = new List<StashItem>();
            this.Coins = stash.Coins;
            this.Icon = upgrade.Icon;
            this.Name = upgrade.Name;
            this.Note = stash.Note;
        }

        public List<StashItem> Items { get; set; }
        public int Coins { get; private set; }
        public string Icon { get; private set; }
        public string Name { get; private set; }
        public string Note { get; private set; }
    }
}
