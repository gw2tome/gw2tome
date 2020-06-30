using GuildWars2Tome.Extensions;
using GuildWars2Tome.Models;
using GuildWars2Tome.Models.GuidWarsApi;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2Tome.Pages.Guild
{
    public partial class Treasury
    {
        [Inject]
        protected GuildWarsApiClient GuildWarsClient { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }

        private IList<TreasuryItem> treasuryItems = new List<TreasuryItem>();

        protected override async Task OnInitializedAsync()
        {
            var key = await JS.LocalStorageGet<string>(StorageKeys.SettingsApiKey);
            if (!string.IsNullOrWhiteSpace(key))
            {
                this.GuildWarsClient.Key = key;
                var guildId = await JS.LocalStorageGet<string>(StorageKeys.SettingsGuildId);
                var treasuries = await this.GuildWarsClient.GetGuildTreasuryAsync(guildId);
                var itemIds = treasuries.Where(x => x.ItemId > 0).Select(x => x.ItemId).Distinct().AsParallel();
                var items = await this.GuildWarsClient.GetItemsAsync(itemIds);
                var bag = new ConcurrentBag<TreasuryItem>();
                Parallel.ForEach(treasuries, treasury =>
                {
                    var item = items.SingleOrDefault(x => x.Id == treasury.ItemId);
                    var treasuryItem = new TreasuryItem(treasury, item);
                    bag.Add(treasuryItem);
                });
                this.treasuryItems = bag.OrderBy(x => x.Name).ToList();
            }
        }
    }
}
