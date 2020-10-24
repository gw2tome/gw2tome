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
    public partial class Ranks
    {
        private IEnumerable<Rank> ranks = new List<Rank>();

        [Inject]
        protected IGuildWars2ApiClient GuildWarsClient { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var token = await JS.GetApiKey();
            if (!string.IsNullOrWhiteSpace(token?.Key ?? null))
            {
                this.GuildWarsClient.Key = token.Key;
                var guildId = await JS.GetGuildId();
                var guildRanks = await this.GuildWarsClient.V2.GetGuildRanksAsync(guildId);
                var permissionIds = guildRanks.SelectMany(x => x.Permissions).Distinct().AsParallel();
                var permissions = await this.GuildWarsClient.V2.GetGuildPermissionsAsync(permissionIds);
                var unorderedRanks = new ConcurrentBag<Rank>();
                Parallel.ForEach(guildRanks, guildRank =>
                {
                    var rank = new Rank(guildRank);
                    foreach (var guildPermissionId in guildRank.Permissions)
                    {
                        var guildPermission = permissions.SingleOrDefault(x => x.Id == guildPermissionId);
                        var rankPermission = new RankPermission(guildPermission);
                        rank.Permissions.Add(rankPermission);
                    }
                    unorderedRanks.Add(rank);
                });

                this.ranks = unorderedRanks.OrderBy(x => x.Id);
            }
        }
    }
}
