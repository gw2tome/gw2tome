using JK.GuildWars2Api.V1;
using JK.GuildWars2Api.V2;

namespace JK.GuildWars2Api
{
    public interface IGuildWars2ApiClient
    {
        IVersion1ApiClient V1 { get; }
        IVersion2ApiClient V2 { get; }
        string Key { get; set; }
    }
}
