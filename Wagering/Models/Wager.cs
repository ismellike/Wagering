using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wagering.Models
{
    public class Wager
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }

        public ICollection<WagerHostBid> Hosts { get; set; }
        public ICollection<WagerChallenge> Challenges { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18,7)")]
        public decimal? MinimumWager { get; set; }
        [Column(TypeName = "decimal(18,7)")]
        public decimal? MaximumWager { get; set; }
        public bool IsClosed { get; set; }

        [NotMapped]
        public int ChallengeCount { get; set; }

        [NotMapped]
        public string TimeAgo
        {
            get { return Date.ToTime(); }
        }

        public bool IsApproved()
        {
            foreach (WagerHostBid bid in Hosts)
                if (bid.Approved == false)
                    return false;
            if (Hosts.Count == 0)
                return false;
            return true;
        }
    }
}
