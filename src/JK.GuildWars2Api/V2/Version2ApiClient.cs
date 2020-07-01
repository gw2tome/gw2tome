using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JK.GuildWars2Api.V2
{
    public class Version2ApiClient : ApiClientBase, IVersion2ApiClient
    {
        public Version2ApiClient(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public Task<Account> GetAccountAsync()
        {
            this.EnsureAuthorization();
            return this.Http.GetFromJsonAsync<Account>($"v2/account?access_token={this.Key}");
        }

        #region API Calls - Guilds

        public Task<GuildLog[]> GetGuildLogAsync(string guildId)
        {
            this.EnsureAuthorization();
            return this.Http.GetFromJsonAsync<GuildLog[]>($"v2/guild/{guildId}/log?access_token={this.Key}");
        }

        public Task<GuildMember[]> GetGuildMembersAsync(string guildId)
        {
            this.EnsureAuthorization();
            return this.Http.GetFromJsonAsync<GuildMember[]>($"v2/guild/{guildId}/members?access_token={this.Key}");
        }

        public Task<GuildPermission[]> GetGuildPermissionsAsync(IEnumerable<string> ids)
        {
            var list = this.JoinItems(ids);
            return this.Http.GetFromJsonAsync<GuildPermission[]>($"v2/guild/permissions?ids={list}");
        }

        public Task<GuildRank[]> GetGuildRanksAsync(string guildId)
        {
            this.EnsureAuthorization();
            return this.Http.GetFromJsonAsync<GuildRank[]>($"v2/guild/{guildId}/ranks?access_token={this.Key}");
        }

        public Task<GuildStash[]> GetGuildStashAsync(string guildId)
        {
            this.EnsureAuthorization();
            return this.Http.GetFromJsonAsync<GuildStash[]>($"v2/guild/{guildId}/stash?access_token={this.Key}");
        }

        public Task<GuildTreasury[]> GetGuildTreasuryAsync(string guildId)
        {
            this.EnsureAuthorization();
            return this.Http.GetFromJsonAsync<GuildTreasury[]>($"v2/guild/{guildId}/treasury?access_token={this.Key}");
        }

        public Task<GuildUpgrade[]> GetGuildUpgradesAsync(IEnumerable<int> idList)
        {
            var list = this.JoinItems(idList);
            return this.Http.GetFromJsonAsync<GuildUpgrade[]>($"v2/guild/upgrades?ids={list}");
        }

        #endregion

        public Task<Item[]> GetItemsAsync(IEnumerable<int> idList)
        {
            var list = this.JoinItems(idList);
            return this.Http.GetFromJsonAsync<Item[]>($"v2/items?ids={list}");
        }
    }
}
