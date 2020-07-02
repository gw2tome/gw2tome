using JK.GuildWars2Api.V1;
using JK.GuildWars2Api.V2;
using System.Net.Http;

namespace JK.GuildWars2Api
{
    public class GuildWars2ApiClient : IGuildWars2ApiClient
    {
        public GuildWars2ApiClient(HttpClient httpClient)
            : this(new Version1ApiClient(httpClient), new Version2ApiClient(httpClient))
        {
        }

        public GuildWars2ApiClient(IVersion1ApiClient version1Client, IVersion2ApiClient version2Client)
        {
            this.V1 = version1Client;
            this.V2 = version2Client;
        }

        public string Key
        {
            get => KeyStore.Instance.Key;
            set => KeyStore.Instance.Key = value;
        }

        public IVersion1ApiClient V1 { get; private set; }

        public IVersion2ApiClient V2 { get; private set; }
    }
}
