using System;
using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public class Event
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
        public byte Status { get; set; }

        public string GetGroupName()
        {
            return $"{GameName}{Id}";
        }
    }
}
