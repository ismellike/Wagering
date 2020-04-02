using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public class WagerChallengeBid
    {
        public int Id { get; set; }

        public int ChallengeId { get; set; }
        public WagerChallenge Challenge { get; set; }
        public string UserDisplayName { get; set; }
        public Profile User { get; set; }

        [Required]
        public byte Percentage { get; set; }
        public bool? Approved { get; set; }
        public bool IsOwner { get; set; }

        public override string ToString()
        {
            return User.DisplayName;
        }
    }
}
