using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public abstract class Event : Approvable
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public Game Game { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }

        public abstract string GroupName { get; }
    }
}
