using Microsoft.AspNetCore.Identity;

namespace Wagering.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
