namespace Wagering.Models
{
    public class WagerHostBid : WagerBid
    {
        public int WagerId { get; set; }
        public Wager Wager { get; set; }
    }
}
