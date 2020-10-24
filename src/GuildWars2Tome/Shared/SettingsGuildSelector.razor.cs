using GuildWars2Tome.Extensions;
using GuildWars2Tome.Models;
using JK.GuildWars2Api;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2Tome.Shared
{
    public partial class SettingsGuildSelector
    {
        private SettingsGuildFormModel formModel = new SettingsGuildFormModel();
        private IEnumerable<ListItem<string>> guilds = new List<ListItem<string>>();
        private bool loading = true;
        private bool hasGuildPermission = false;

        [Inject]
        protected IGuildWars2ApiClient GuildWarsClient { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.loading = true;
            var token = await this.JS.GetApiKey();
            if (!string.IsNullOrWhiteSpace(token?.Key ?? null))
            {
                this.GuildWarsClient.Key = token.Key;
                var account = await this.GuildWarsClient.V2.GetAccountAsync();
                var guildList = new List<ListItem<string>>();
                var guildIdList = account.GuildLeader.Where(x => !string.IsNullOrWhiteSpace(x));

                if (guildIdList.Any())
                {
                    this.hasGuildPermission = true;
                    foreach (var guildId in guildIdList)
                    {
                        var guild = await this.GuildWarsClient.V1.GetGuildAsync(guildId);
                        guildList.Add(new ListItem<string> { Value = guild.Id, Text = guild.FullName });
                    }
                    guilds = guildList.OrderBy(x => x.Text);
                    this.formModel.GuildId = await this.JS.GetGuildId();
                }
            }

            this.loading = false;
        }

        private async Task HandleValidSaveSubmit()
        {
            var guildId = string.IsNullOrEmpty(formModel.GuildId) ? null : formModel.GuildId;
            await this.JS.SetGuildId(guildId);
        }
    }
}
