using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public class Profile
    {
        [Key]
        [StringLength(20, MinimumLength = 4)]
        public string DisplayName { get; set; }

        public bool IsVerified { get; set; }
        public string PublicKey { get; set; }
        public string Platform { get; set; }
        public string Input { get; set; }
        //Collection of ratings depending on game
        public ICollection<Rating> Ratings { get; set; }
    }
}
