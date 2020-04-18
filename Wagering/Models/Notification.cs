﻿using System;

namespace Wagering.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public bool IsRead { get; set; }
        //should be local format
        public string Link { get; set; }
    }
}
