using GuildWars2Tome.Extensions;
using GuildWars2Tome.Models;
using JK.GuildWars2Api;
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
        protected IGuildWars2ApiClient GuildWarsClient { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }

        private IList<TreasuryItem> treasuryItems = new List<TreasuryItem>();

        protected override async Task OnInitializedAsync()
        {
            var token = await JS.GetApiKey();
            if (!string.IsNullOrWhiteSpace(token?.Key ?? null))
            {
                this.GuildWarsClient.Key = token.Key;
                var guildId = await JS.GetGuildId();
                var treasuries = await this.GuildWarsClient.V2.GetGuildTreasuryAsync(guildId);
                var itemIds = treasuries.Where(x => x.ItemId > 0).Select(x => x.ItemId).Distinct().AsParallel();
                var items = await this.GuildWarsClient.V2.GetItemsAsync(itemIds);
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
