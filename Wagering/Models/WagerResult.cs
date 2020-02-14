using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wagering.Models
{
    public class WagerResult
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public ICollection<WagerHostBid> Members { get; set; }

        //true if host wins, false if challenger wins, null if undecided
        public bool? Result { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "decimal(24,18)")]
        public decimal Amount { get; set; }
    }
}
