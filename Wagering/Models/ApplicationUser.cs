﻿using Microsoft.AspNetCore.Identity;

namespace Wagering.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Profile Profile { get; set; }
    }
}
