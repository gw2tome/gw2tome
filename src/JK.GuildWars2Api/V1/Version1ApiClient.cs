using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JK.GuildWars2Api.V1
{
    public class Version1ApiClient : ApiClientBase, IVersion1ApiClient
    {
        public Version1ApiClient(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public Task<Guild> GetGuildAsync(string guildId)
        {
            return this.Http.GetFromJsonAsync<Guild>($"v1/guild_details.json?guild_id={guildId}");
        }
    }
}
