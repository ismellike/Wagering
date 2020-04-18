namespace Wagering.Models
{
    public class PersonalNotification : Notification
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsRead { get; set; }
        public string Link { get; set; }
    }
}
