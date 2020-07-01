using System.Threading.Tasks;

namespace JK.GuildWars2Api.V1
{
    public interface IVersion1ApiClient
    {
        Task<Guild> GetGuildAsync(string guildId);
    }
}
