using System.ComponentModel.DataAnnotations.Schema;

namespace Wagering.Models {
    public class Tournament : Group {
        [Column(TypeName = "decimal(18,7)")]
        public decimal Entry { get; set; }

        public override bool IsApproved() {
            throw new System.NotImplementedException();
        }

        public override string GroupName { get { return $"tournament_{Id}"; } }
        public override string GroupLink { get { return $"/control/tournaments/{Id}"; } }
    }
}