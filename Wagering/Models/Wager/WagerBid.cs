using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public class WagerBid : Bid
    {
        [Required]
        public byte ReceivablePt { get; set; }
        [Required]
        public byte PayablePt { get; set; }
        public bool IsOwner { get; set; }
    }
}