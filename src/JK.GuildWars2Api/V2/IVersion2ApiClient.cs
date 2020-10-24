using System.Collections.Generic;
using System.Threading.Tasks;

namespace JK.GuildWars2Api.V2
{
    public interface IVersion2ApiClient : IAuthenticated
    {
        Task<Account> GetAccountAsync();

        #region API Calls - Guilds

        Task<GuildLog[]> GetGuildLogAsync(string guildId);
        Task<GuildMember[]> GetGuildMembersAsync(string guildId);
        Task<GuildPermission[]> GetGuildPermissionsAsync(IEnumerable<string> ids);
        Task<GuildRank[]> GetGuildRanksAsync(string guildId);
        Task<GuildStash[]> GetGuildStashAsync(string guildId);
        Task<GuildTreasury[]> GetGuildTreasuryAsync(string guildId);
        Task<GuildUpgrade[]> GetGuildUpgradesAsync(IEnumerable<int> idList);

        #endregion

        Task<Item[]> GetItemsAsync(IEnumerable<int> idList);
        Task<TokenInfo> GetTokenInfo();
    }
}
