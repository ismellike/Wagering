using System;

namespace Wagering.Models
{
  public class PersonalNotification
  {
    public string Message { get; set; }
    public DateTime Date { get; set; }
    public bool IsRead { get; set; }
    public string Link { get; set; }
  }
}
