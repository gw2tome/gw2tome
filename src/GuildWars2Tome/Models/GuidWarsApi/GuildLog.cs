using System;
using System.Text.Json.Serialization;

namespace GuildWars2Tome.Models.GuidWarsApi
{
    public class GuildLog
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("type")]
        public string LogType { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("operation")]
        public string Operation { get; set; }

        [JsonPropertyName("item_id")]
        public int? ItemId { get; set; }

        [JsonPropertyName("count")]
        public int? Count { get; set; }

        [JsonPropertyName("coins")]
        public int? Coins { get; set; }

        [JsonPropertyName("motd")]
        public string Motd { get; set; }

        [JsonPropertyName("upgrade_id")]
        public int? UpgradeId { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("kicked_by")]
        public string KickedBy { get; set; }

        [JsonPropertyName("invited_by")]
        public string InvitedBy { get; set; }

        [JsonPropertyName("changed_by")]
        public string ChangedBy { get; set; }

        [JsonPropertyName("old_rank")]
        public string OldRank { get; set; }

        [JsonPropertyName("new_rank")]
        public string NewRank { get; set; }

        [JsonPropertyName("activity")]
        public string Activity { get; set; }

        [JsonPropertyName("total_participants")]
        public int? TotalParticipants { get; set; }

        [JsonPropertyName("participants")]
        public object[] Participants { get; set; }

        [JsonPropertyName("declined_by")]
        public string DeclinedBy { get; set; }

        public DateTime Datestamp
        {
            get { return DateTime.Parse(this.Time); }
        }
    }
}
