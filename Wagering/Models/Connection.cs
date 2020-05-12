using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public class Connection
    {
        public string ProfileId { get; set; } = string.Empty;
        public Profile? Profile { get; set; }
        [Required]
        public string ConnectionID { get; set; } = string.Empty;
        [Required]
        public string UserAgent { get; set; } = string.Empty;
        public bool Connected { get; set; }
    }
}