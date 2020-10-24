using JK.GuildWars2Api.V2;
using System.Collections.Generic;

namespace GuildWars2Tome.Models
{
    public class ApiToken
    {
        public ApiToken()
        {
        }

        public ApiToken(string key, TokenInfo tokenInfo)
        {
            this.Key = key;
            this.Name = tokenInfo.Name;
            this.Permissions = tokenInfo.Permissions;
        }

        public string Key { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Permissions { get; set; }
    }
}
