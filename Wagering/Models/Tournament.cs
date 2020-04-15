using System.ComponentModel.DataAnnotations.Schema;

namespace Wagering.Models
{
    public class Tournament : Event
    {
        [Column(TypeName = "decimal(18,7)")]
        public decimal Entry { get; set; }
    }
}
