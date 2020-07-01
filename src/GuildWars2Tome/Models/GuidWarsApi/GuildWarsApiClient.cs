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
            this.client.BaseAddress = new Uri("https://api.guildwars2.com/");
        }

        public string Key { get; set; }

        public Task<Account> GetAccountAsync()
        {
            this.EnsureAuthorization();
            return this.client.GetFromJsonAsync<Account>($"v2/account?access_token={this.Key}");           
        }

        #region API Calls - Guilds

        public Task<Guild> GetGuildAsync(string guildId)
        {
            return this.client.GetFromJsonAsync<Guild>($"v1/guild_details.json?guild_id={guildId}");
        }

        public Task<GuildLog[]> GetGuildLogAsync(string guildId)
        {
            this.EnsureAuthorization();
            return this.client.GetFromJsonAsync<GuildLog[]>($"v2/guild/{guildId}/log?access_token={this.Key}");
        }

        public Task<GuildMember[]> GetGuildMembersAsync(string guildId)
        {
            this.EnsureAuthorization();
            return this.client.GetFromJsonAsync<GuildMember[]>($"v2/guild/{guildId}/members?access_token={this.Key}");
        }

        public Task<GuildStash[]> GetGuildStashAsync(string guildId)
        {
            this.EnsureAuthorization();
            return this.client.GetFromJsonAsync<GuildStash[]>($"v2/guild/{guildId}/stash?access_token={this.Key}");
        }

        public Task<GuildTreasury[]> GetGuildTreasuryAsync(string guildId)
        {
            this.EnsureAuthorization();
            return this.client.GetFromJsonAsync<GuildTreasury[]>($"v2/guild/{guildId}/treasury?access_token={this.Key}");
        }

        public Task<GuildUpgrade[]> GetGuildUpgradesAsync(IEnumerable<int> idList)
        {
            var list = this.JoinItems(idList);
            return this.client.GetFromJsonAsync<GuildUpgrade[]>($"v2/guild/upgrades?ids={list}");
        }

        #endregion

        public Task<Item[]> GetItemsAsync(IEnumerable<int> idList)
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
