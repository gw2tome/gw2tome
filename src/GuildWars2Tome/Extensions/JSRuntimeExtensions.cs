using GuildWars2Tome.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace GuildWars2Tome.Extensions
{
    public static class JSRuntimeExtensions
    {
        public async static Task<T> LocalStorageGet<T>(this IJSRuntime js, string key)
        {
            if (key == StorageKeys.SettingsGuildId) return (T)(object)"63BD2725-4626-4831-ADC8-4B722C62BBE7";

            return await js.InvokeAsync<T>("gw2tome.localStorageGet", key);
        }

        public async static Task LocalStorageSet<T>(this IJSRuntime js, string key, T value)
        {
            if (key == StorageKeys.SettingsGuildId) return;
            await js.InvokeVoidAsync("gw2tome.localStorageSet", key, value);
        }
    }
}
