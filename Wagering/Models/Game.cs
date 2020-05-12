using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string NormalizedName { get; set; } = string.Empty;
    }
}
