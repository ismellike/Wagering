using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wagering.Models
{
    public class Wager : Event
    {
        public ICollection<WagerHostBid> Hosts { get; set; }
        public ICollection<WagerChallenge> Challenges { get; set; }
        [Column(TypeName = "decimal(18,7)")]
        public decimal? MinimumWager { get; set; }
        [Column(TypeName = "decimal(18,7)")]
        public decimal? MaximumWager { get; set; }

        [NotMapped]
        public int ChallengeCount { get; set; }

        public Wager() { }
        public Wager(Wager wager)
        {
            Hosts = wager.Hosts;
            Challenges = wager.Challenges;
            MinimumWager = wager.MinimumWager;
            MaximumWager = wager.MaximumWager;
            Date = wager.Date;
            Description = wager.Description;
            Game = wager.Game;
            GameName = wager.GameName;
            Id = wager.Id;
            IsPrivate = wager.IsPrivate;
            Notifications = wager.Notifications;
        }

        public override bool IsApproved()
        {
            if (Status == 1)
                return true;

            foreach (WagerHostBid bid in Hosts)
                if (bid.Approved == null || bid.Approved == false)
                    return false;
            if (Hosts.Count == 0)
                return false;
            return true;
        }

        public override string GroupName
        {
            get
            {
                return $"wager_{Id}";
            }
        }
    }
}
