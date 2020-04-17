using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public class WagerHostBid : Bid
    {
        public int WagerId { get; set; }
        public Wager Wager { get; set; }
        [Required]
        public byte Percentage { get; set; }
        public bool IsOwner { get; set; }

        public override string ToString()
        {
            return ProfileDisplayName;
        }
    }
}
