using System;
using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public class PersonalNotification
    {
        public int Id { get; set; }
        public string ProfileId { get; set; } = string.Empty;
        public Profile? Profile { get; set; }
        [Required]
        public string Message { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public byte DataModel { get; set; }
        public string? Data { get; set; }
    }
}