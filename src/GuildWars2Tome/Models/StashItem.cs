using JK.GuildWars2Api.V2;

namespace GuildWars2Tome.Models
{
    public class StashItem
    {
        public StashItem(GuildInventory inventoryItem, Item item)
        {
            this.Count = item is null ? 0 : inventoryItem.Count;
            this.Icon = item is null ? string.Empty : item.Icon;
            this.Name = item is null ? string.Empty : item.Name;
        }

        public int Count { get; private set; }
        public string Icon { get; private set; }
        public string Name { get; private set; }
    }
}
