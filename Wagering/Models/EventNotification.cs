namespace Wagering.Models
{
    public class EventNotification : Notification
    {
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public int WagerId { get; set; }
        public Wager Wager { get; set; }
    }
}
