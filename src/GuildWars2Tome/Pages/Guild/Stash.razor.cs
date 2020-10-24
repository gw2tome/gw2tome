using GuildWars2Tome.Extensions;
using GuildWars2Tome.Models;
using JK.GuildWars2Api;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2Tome.Pages.Guild
{
    public partial class Stash
    {
        [Inject]
        protected IGuildWars2ApiClient GuildWarsClient { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }

        private IList<Models.Stash> stashes = new List<Models.Stash>();

        protected override async Task OnInitializedAsync()
        {
            var token = await JS.GetApiKey();
            if (!string.IsNullOrWhiteSpace(token?.Key ?? null))
            {
                this.GuildWarsClient.Key = token.Key;
                var guildId = await JS.GetGuildId();
                var stashes = await this.GuildWarsClient.V2.GetGuildStashAsync(guildId);
                var upgradeIds = stashes.Where(x => x.UpgradeId > 0).Select(x => x.UpgradeId).Distinct().AsParallel();
                var upgrades = await this.GuildWarsClient.V2.GetGuildUpgradesAsync(upgradeIds);

                foreach (var stashApi in stashes)
                {
                    var upgrade = upgrades.SingleOrDefault(x => x.Id == stashApi.UpgradeId);
                    var stash = new Models.Stash(stashApi, upgrade);

                    var itemIds = stashApi.Inventory.Where(x => x != null).Select(x => x.Id).Distinct().AsParallel();
                    var items = await this.GuildWarsClient.V2.GetItemsAsync(itemIds);

                    foreach (var inventoryItem in stashApi.Inventory)
                    {
                        var item = inventoryItem is null ? null : items.SingleOrDefault(x => x.Id == inventoryItem.Id);
                        var stashItem = new StashItem(inventoryItem, item);
                        stash.Items.Add(stashItem);
                    }

                    this.stashes.Add(stash);
                }
            }
        }
    }
}
