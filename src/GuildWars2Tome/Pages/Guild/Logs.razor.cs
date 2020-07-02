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
    public partial class Logs
    {
        [Inject]
        protected IGuildWars2ApiClient GuildWarsClient { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }

        private IList<LogEntry> logs = new List<LogEntry>();

        protected override async Task OnInitializedAsync()
        {
            var token = await JS.GetApiKey();
            if (!string.IsNullOrWhiteSpace(token?.Key ?? null))
            {
                this.GuildWarsClient.Key = token.Key;
                var guildId = await JS.GetGuildId();
                var logs = await this.GuildWarsClient.V2.GetGuildLogAsync(guildId);
                var itemIds = logs.Where(x => x.ItemId.HasValue && x.ItemId.Value > 0).Select(x => x.ItemId.Value).Distinct().AsParallel();
                var upgradeIds = logs.Where(x => x.UpgradeId.HasValue && x.UpgradeId.Value > 0).Select(x => x.UpgradeId.Value).Distinct().AsParallel();
                var items = await this.GuildWarsClient.V2.GetItemsAsync(itemIds);
                var upgrades = await this.GuildWarsClient.V2.GetGuildUpgradesAsync(upgradeIds);
                var orderedList = logs.Where(x => x.LogType != "influence").OrderByDescending(x => x.Datestamp);
                foreach (var log in orderedList)
                {
                    var item = log.ItemId.HasValue && log.ItemId.Value > 0
                        ? items.SingleOrDefault(x => x.Id == log.ItemId.Value)
                        : null;
                    var upgrade = log.UpgradeId.HasValue && log.UpgradeId.Value > 0
                        ? upgrades.SingleOrDefault(x => x.Id == log.UpgradeId.Value)
                        : null;
                    var logEntry = new LogEntry(log, item, upgrade);
                    this.logs.Add(logEntry);
                }
            }
        }
    }
}
