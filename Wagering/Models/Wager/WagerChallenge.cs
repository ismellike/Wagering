﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace Wagering.Models
{
    public class WagerChallenge : Approvable
    {
        public int Id { get; set; }

        public int WagerId { get; set; }
        public Wager Wager { get; set; }

        public ICollection<WagerChallengeBid> Challengers { get; set; } = new List<WagerChallengeBid>();

        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,7)")]
        public decimal Amount { get; set; }
        public bool IsAccepted { get; set; }

        public override bool IsApproved()
        {
            if (Status == 1)
                return true;

            foreach (WagerChallengeBid bid in Challengers)
                if (bid.Approved == null || bid.Approved == false)
                    return false;
            if (Challengers.Count == 0)
                return false;
            return true;
        }
    }
}
