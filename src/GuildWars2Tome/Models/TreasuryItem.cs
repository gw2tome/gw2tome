using GuildWars2Tome.Models.GuidWarsApi;
using System.Linq;

namespace GuildWars2Tome.Models
{
    public class TreasuryItem
    {
        public TreasuryItem(GuildTreasury treasury, Item item)
        {
            this.Count = treasury.Count;
            this.Icon = item.Icon;
            this.ItemId = item.Id;
            this.Name = item.Name;
            this.Needed = (treasury.NeededBy is null && !treasury.NeededBy.Any())
                ? 0
                : treasury.NeededBy.Sum(x => x.Count);
            this.PercentComplete = this.Needed == 0
                ? 100
                : (int)((this.Count / (double)this.Needed) * 100);
        }

        public int Count { get; private set; }
        public string Icon { get; private set; }
        public int ItemId { get; private set; }
        public string Name { get; private set; }
        public int Needed { get; private set; }
        public int PercentComplete { get; private set; }
    }
}
