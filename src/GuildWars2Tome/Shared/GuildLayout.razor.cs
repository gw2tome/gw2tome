using GuildWars2Tome.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace GuildWars2Tome.Shared
{
    public partial class GuildLayout
    {
        private bool hasApiKey = false;
        private bool hasGuildSelected = false;

        [Inject]
        protected IJSRuntime JS { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var apiToken = await this.JS.GetApiKey();
            this.hasApiKey = !string.IsNullOrWhiteSpace(apiToken?.Key ?? null);
           
            var guildId = await this.JS.GetGuildId();
            this.hasGuildSelected = !string.IsNullOrWhiteSpace(guildId);
        }
    }
}
