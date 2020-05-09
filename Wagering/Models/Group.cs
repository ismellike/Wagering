using System;
using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public abstract class Group : Approvable
    {
        public int Id { get; set; }
        public string GameUrl { get; set; }
        public Game Game { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }

        public abstract string GroupName { get; }
        public abstract string GroupLink { get; }
    }
}