using GuildWars2Tome.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace GuildWars2Tome.Extensions
{
    public static class JSRuntimeExtensions
    {
        public static ValueTask<T> LocalStorageGet<T>(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<T>("gw2tome.localStorageGet", key);
        }

        public async static Task LocalStorageSet<T>(this IJSRuntime js, string key, T value)
        {
            await js.InvokeVoidAsync("gw2tome.localStorageSet", key, value);
        }

        public static ValueTask<ApiToken> GetApiKey(this IJSRuntime js)
        {
            return js.LocalStorageGet<ApiToken>(StorageKeys.SettingsApiKey);
        }

        public static ValueTask<string> GetGuildId(this IJSRuntime js)
        {
            return js.LocalStorageGet<string>(StorageKeys.SettingsGuildId);
        }

        public async static Task SetApiKey(this IJSRuntime js, ApiToken apiToken)
        {
            await js.LocalStorageSet(StorageKeys.SettingsApiKey, apiToken);
        }

        public async static Task SetGuildId(this IJSRuntime js, string guildId)
        {
            await js.LocalStorageSet(StorageKeys.SettingsGuildId, guildId);
        }
    }
}
