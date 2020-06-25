using System.ComponentModel.DataAnnotations;

namespace GuildWars2Tome.Models
{
    public class SettingsFormModel
    {
        [Required]
        public string ApiKey { get; set; }
    }
}
