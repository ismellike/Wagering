using System;

namespace Wagering.Models
{
    public class PersonalNotification
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string Link { get; set; }
    }
}