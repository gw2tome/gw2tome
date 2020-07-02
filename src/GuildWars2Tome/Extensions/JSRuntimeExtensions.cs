using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace GuildWars2Tome.Extensions
{
    public static class JSRuntimeExtensions
    {
        public async static Task<T> LocalStorageGet<T>(this IJSRuntime js, string key)
        {
            return await js.InvokeAsync<T>("gw2tome.localStorageGet", key);
        }

        public async static Task LocalStorageSet<T>(this IJSRuntime js, string key, T value)
        {
            await js.InvokeVoidAsync("gw2tome.localStorageSet", key, value);
        }
    }
}
