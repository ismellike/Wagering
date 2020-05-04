using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
  public class Game
  {
    public string Name { get; set; }
    [Key]
    public string Url { get; set; }
  }
}
