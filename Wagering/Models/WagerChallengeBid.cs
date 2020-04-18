using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public class WagerChallengeBid : Bid
    {
        public int ChallengeId { get; set; }
        public WagerChallenge Challenge { get; set; }

        [Required]
        public byte Percentage { get; set; }
        public bool IsOwner { get; set; }
    }
}
