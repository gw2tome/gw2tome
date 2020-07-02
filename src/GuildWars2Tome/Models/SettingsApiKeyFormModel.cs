using System.ComponentModel.DataAnnotations;

namespace GuildWars2Tome.Models
{
    public class SettingsApiKeyFormModel
    {
        [Required]
        public string ApiKey { get; set; }
    }
}
