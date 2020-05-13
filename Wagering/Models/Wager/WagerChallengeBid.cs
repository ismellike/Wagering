#nullable disable

namespace Wagering.Models
{
    public class WagerChallengeBid : WagerBid
    {
        public int ChallengeId { get; set; }
        public WagerChallenge Challenge { get; set; }
    }
}
