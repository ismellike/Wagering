using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public class Game
    {
        [Key]
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
