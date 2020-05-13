using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Wagering.Models
{
    public abstract class Group : Approvable
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game? Game { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }

        public abstract string GroupName { get; }

        public abstract IEnumerable<string> HostIds();
        public abstract IEnumerable<string> ClientIds();
        public abstract IEnumerable<string> AllIds();
    }
}