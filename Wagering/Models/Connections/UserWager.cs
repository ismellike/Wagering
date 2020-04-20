namespace Wagering.Models
{
    public class UserWager
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int WagerId { get; set; }
        public Wager Wager { get; set; }
    }
}
