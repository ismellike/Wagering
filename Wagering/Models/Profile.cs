﻿using System.Collections.Generic;

namespace Wagering.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string DisplayName { get; set; }
        public bool IsVerified { get; set; }
        public string PublicKey { get; set; }
        public string Platform { get; set; }
        public string Input { get; set; }
        //Collection of ratings depending on game
        public ICollection<Rating> Ratings { get; set; }
        public IList<Notification> Notifications { get; set; }
    }
}
