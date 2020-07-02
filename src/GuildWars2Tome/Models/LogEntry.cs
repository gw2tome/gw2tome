using JK.GuildWars2Api.V2;
using System;

namespace GuildWars2Tome.Models
{
    public class LogEntry
    {
        public LogEntry()
        { 
        }

        public LogEntry(GuildLog log, Item item, GuildUpgrade upgrade)
        {
            this.Datestamp = log.Datestamp;
            this.ImageSource = this.GetImageSource(log, item, upgrade);
            this.ImageTitle = item is null ? string.Empty : item.Name;

            switch (log.LogType)
            {
                case "influence":
                    this.LogType = "Influence";
                    break;
                case "invite_declined":
                    this.LogType = "Invite Declined";
                    this.Message = log.User == log.DeclinedBy
                        ? $"{log.User} declined a guild invite"
                        : $"{log.DeclinedBy} cancelled the guild invitation of {log.User}";
                    break;
                case "invited":
                    this.LogType = "Invited";
                    this.Message = $"{log.InvitedBy} invited {log.User} to the guild";
                    break;
                case "joined":
                    this.LogType = "Joined";
                    this.Message = $"{log.User} joined the guild";
                    break;
                case "kick":
                    this.LogType = "Kick";
                    this.Message = log.User == log.KickedBy
                        ? $"{log.User} left the guild"
                        : $"{log.KickedBy} removed {log.User} from the guild";
                    break;
                case "motd":
                    this.LogType = "Message of the Day";
                    this.Message = $"{log.User} changed the MOTD to: \n{log.Motd}";
                    break;
                case "rank_change":
                    this.LogType = "Rank Change";
                    this.Message = $"{log.ChangedBy} changed the rank of {log.User} from {log.OldRank} to {log.NewRank}";
                    break;
                case "stash":
                    this.LogType = "Stash";
                    this.Message = this.GetStashFormat(log, item);
                    break;
                case "treasury":
                    this.LogType = "Treasury";
                    this.Message = $"{log.User} donated {log.Count} {item.Name}";
                    break;
                case "upgrade":
                    this.LogType = "Upgrade";
                    this.Message = log.Action == "queued"
                        ? $"{log.User} queued {upgrade.Name}"
                        : string.Empty;
                    break;
                default:
                    this.LogType = log.LogType;
                    break;
            }
        }

        public DateTime Datestamp { get; set; }
        public string ImageSource { get; set; }
        public string ImageTitle { get; set; }
        public string LogType { get; set; }
        public string Message { get; set; }

        private string GetImageSource(GuildLog log, Item item, GuildUpgrade upgrade)
        {
            if (log.ItemId.HasValue && item != null)
            {
                return item.Icon;
            }

            if (log.UpgradeId.HasValue && upgrade != null)
            {
                return upgrade.Icon;
            }

            return string.Empty;
        }

        private string GetStashFormat(GuildLog log, Item item)
        {
            if (string.IsNullOrWhiteSpace(log.Operation))
            {
                return $"{log.User} repositioned {log.Count} {item.Name} within the stash";
            }

            if (log.Operation == "deposit")
            {
                return log.Coins.HasValue && log.Coins > 0
                    ? $"{log.User} deposited {log.Count} coins"
                    : $"{log.User} deposited {log.Count} {item.Name}";
            }

            if (log.Operation == "withdraw")
            {
                return log.Coins.HasValue && log.Coins > 0
                    ? $"{log.User} withdrew {log.Count} coins"
                    : $"{log.User} withdrew {log.Count} {item.Name}";
            }

            return string.Empty;
        }
    }
}
