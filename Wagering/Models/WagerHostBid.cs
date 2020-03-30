using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public class WagerHostBid
    {
        public int Id { get; set; }

        public int WagerId { get; set; }
        public Wager Wager { get; set; }
        public string UserDisplayName { get; set; }
        public Profile User { get; set; }

        [Required]
        public byte Percentage { get; set; }
        [Required]
        public bool Approved { get; set; }
        public bool IsOwner { get; set; }

        public override string ToString()
        {
            return User.DisplayName;
        }
    }
}
