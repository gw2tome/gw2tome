using GuildWars2Tome.Extensions;
using GuildWars2Tome.Models;
using JK.GuildWars2Api;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace GuildWars2Tome.Pages
{
    public partial class Settings
    {
        private SettingsApiKeyFormModel formModel = new SettingsApiKeyFormModel();
        private bool loading = true;
        private ApiToken token = null;

        [Inject]
        protected IGuildWars2ApiClient GuildWarsClient { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.loading = true;
            var apiToken = await this.JS.GetApiKey();
            if (!string.IsNullOrWhiteSpace(apiToken?.Key ?? null))
            {
                this.token = apiToken;
                this.formModel.ApiKey = apiToken.Key;
            }

            this.loading = false;
        }

        private async Task HandleValidSaveSubmit()
        {
            this.GuildWarsClient.Key = formModel.ApiKey;
            var tokenInfo = await this.GuildWarsClient.V2.GetTokenInfo();
            this.token = new ApiToken(formModel.ApiKey, tokenInfo);
            await this.JS.SetApiKey(this.token);
        }
    }
}
