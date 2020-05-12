namespace Wagering.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public string ProfileUserId { get; set; } = string.Empty;
        public Profile? Profile { get; set; }
        public bool? Approved { get; set; }
    }
}
