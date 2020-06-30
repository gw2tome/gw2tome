using GuildWars2Tome.Extensions;
using GuildWars2Tome.Models;
using GuildWars2Tome.Models.GuidWarsApi;
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
        protected GuildWarsApiClient GuildWarsClient { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }

        private IList<Models.Stash> stashes = new List<Models.Stash>();

        protected override async Task OnInitializedAsync()
        {
            var key = await JS.LocalStorageGet<string>(StorageKeys.SettingsApiKey);
            if (!string.IsNullOrWhiteSpace(key))
            {
                this.GuildWarsClient.Key = key;
                var guildId = await JS.LocalStorageGet<string>(StorageKeys.SettingsGuildId);
                var stashes = await this.GuildWarsClient.GetGuildStashAsync(guildId);
                var upgradeIds = stashes.Where(x => x.UpgradeId > 0).Select(x => x.UpgradeId).Distinct().AsParallel();
                var upgrades = await this.GuildWarsClient.GetGuildUpgradesAsync(upgradeIds);

                foreach (var stashApi in stashes)
                {
                    var upgrade = upgrades.SingleOrDefault(x => x.Id == stashApi.UpgradeId);
                    var stash = new Models.Stash(stashApi, upgrade);

                    var itemIds = stashApi.Inventory.Where(x => x != null).Select(x => x.Id).Distinct().AsParallel();
                    var items = await this.GuildWarsClient.GetItemsAsync(itemIds);

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
