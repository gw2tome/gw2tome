using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazorStrap;
using GuildWars2Tome.Models.GuidWarsApi;

namespace GuildWars2Tome
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddBootstrapCss();
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient(sp => {
                var client = new HttpClient { BaseAddress = new Uri("https://api.guildwars2.com/") };
                return new GuildWarsApiClient(client);
            });
            await builder.Build().RunAsync();
        }
    }
}
