using GuildWars2Tome.Extensions;
using GuildWars2Tome.Models;
using JK.GuildWars2Api;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2Tome.Pages
{
    public partial class Settings
    {
        private SettingsFormModel formModel = new SettingsFormModel();
        private IEnumerable<ListItem<string>> guilds = new List<ListItem<string>>();
        private bool loading = true;

        [Inject]
        protected IGuildWars2ApiClient GuildWarsClient { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.loading = true;
            var apiKey = await this.JS.LocalStorageGet<string>(StorageKeys.SettingsApiKey);
            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                this.GuildWarsClient.Key = apiKey;
                var account = await this.GuildWarsClient.V2.GetAccountAsync();
                var guildList = new List<ListItem<string>>();
                var guildIdList = account.GuildLeader.Where(x => !string.IsNullOrWhiteSpace(x));
                foreach (var guildId in guildIdList)
                {
                    var guild = await this.GuildWarsClient.V1.GetGuildAsync(guildId);
                    guildList.Add(new ListItem<string> { Value = guild.Id, Text = guild.FullName });
                }
                guilds = guildList.OrderBy(x => x.Text);
            }

            this.formModel.ApiKey = apiKey;
            this.formModel.GuildId = await this.JS.LocalStorageGet<string>(StorageKeys.SettingsGuildId);
            this.loading = false;
        }

        private async Task HandleValidSaveSubmit()
        {
            await this.JS.LocalStorageSet(StorageKeys.SettingsApiKey, formModel.ApiKey);
            var guildId = string.IsNullOrEmpty(formModel.GuildId) ? null : formModel.GuildId;
            await this.JS.LocalStorageSet(StorageKeys.SettingsGuildId, guildId);
        }
    }
}
