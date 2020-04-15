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

        [NotMapped]
        public string TimeAgo
        {
            get { return Date.ToTime(); }
        }

        public bool IsApproved()
        {
            if (Status == 1)
                return true;

            foreach (WagerHostBid bid in Hosts)
                if (bid.Approved == false)
                    return false;
            if (Hosts.Count == 0)
                return false;
            return true;
        }

        public override string GroupName()
        {
            return $"wager_{Id}";
        }
    }
}
