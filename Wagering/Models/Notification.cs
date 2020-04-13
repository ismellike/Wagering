using System;

namespace Wagering.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public DateTime Date { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        //should be local format
        public string Link { get; set; }
    }
}
