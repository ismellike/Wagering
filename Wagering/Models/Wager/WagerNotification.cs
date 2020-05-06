namespace Wagering.Models
{
  public class WagerNotification
  {
    public int Id { get; set; }
    public int WagerId { get; set; }
    public Wager Wager { get; set; }
    public int NotificationId { get; set; }
    public GroupNotification Notification { get; set; }
  }
}
