using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Wagering.Models
{
    public class Rule
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Message { get; set; }
    }
}
