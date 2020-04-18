using System;

namespace Wagering.Models
{
    public abstract class Notification
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
