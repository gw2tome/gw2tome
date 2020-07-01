using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace JK.GuildWars2Api
{
    public abstract class ApiClientBase
    {
        public ApiClientBase(HttpClient httpClient)
        {
            this.Http = httpClient;
            this.Http.BaseAddress = new Uri("https://api.guildwars2.com/");
        }

        public string Key 
        {
            get => KeyStore.Instance.Key;
            set => KeyStore.Instance.Key = value; 
        }

        protected HttpClient Http { get; private set; }

        protected void EnsureAuthorization()
        {
            if (string.IsNullOrWhiteSpace(this.Key))
            {
                throw new NullKeyException();
            }
        }

        protected string JoinItems<T>(IEnumerable<T> items)
        {
            return string.Join(",", items.Select(x => x.ToString()).ToArray());
        }
    }
}
