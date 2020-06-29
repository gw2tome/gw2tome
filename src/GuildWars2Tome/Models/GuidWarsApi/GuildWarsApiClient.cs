using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GuildWars2Tome.Models.GuidWarsApi
{
    public class GuildWarsApiClient 
    {
        private HttpClient client;

        public GuildWarsApiClient(HttpClient httpClient)
        {
            this.client = httpClient;
        }

        public string Key { get; set; }

        #region API Calls - Guilds

        public Task<GuildLog[]> GetGuildLogAsync(string guildId)
        {
            this.EnsureAuthorization();
            return this.client.GetFromJsonAsync<GuildLog[]>($"v2/guild/{guildId}/log?access_token={this.Key}");
        }

        public Task<GuildStash[]> GetGuildStashAsync(string guildId)
        {
            this.EnsureAuthorization();
            return this.client.GetFromJsonAsync<GuildStash[]>($"v2/guild/{guildId}/stash?access_token={this.Key}");
        }

        public Task<GuildUpgrade[]> GetGuildUpgradeAsync(IEnumerable<int> idList)
        {
            var list = this.JoinItems(idList);
            return this.client.GetFromJsonAsync<GuildUpgrade[]>($"v2/guild/upgrades?ids={list}");
        }

        #endregion

        public Task<Item[]> GetItemAsync(IEnumerable<int> idList)
        {
            var list = this.JoinItems(idList);
            return this.client.GetFromJsonAsync<Item[]>($"v2/items?ids={list}");
        }

        private void EnsureAuthorization()
        {
            if (string.IsNullOrWhiteSpace(this.Key))
            {
                throw new InvalidOperationException("Property Key must be set.");
            }
        }

        private string JoinItems<T>(IEnumerable<T> items)
        {
            return string.Join(",", items.Select(x => x.ToString()).ToArray());
        } 
    }
}
