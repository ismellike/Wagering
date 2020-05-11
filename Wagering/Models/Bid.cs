namespace Wagering.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public bool? Approved { get; set; }
    }
}
