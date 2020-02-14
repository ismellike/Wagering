using Microsoft.AspNetCore.Identity;

namespace Wagering.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ProfileDisplayName { get; set; }
        public Profile Profile { get; set; }
    }
}
