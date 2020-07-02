using System.ComponentModel.DataAnnotations;

namespace GuildWars2Tome.Models
{
    public class SettingsGuildFormModel
    {
        [Required]
        public string GuildId { get; set; }
    }
}
