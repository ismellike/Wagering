using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wagering.Models
{
    public class Profile
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public string DisplayName { get; set; } = string.Empty;
        [Required]
        public string NormalizedDisplayName { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        public string? PublicKey { get; set; }
        public string? Platform { get; set; }
        public string? Input { get; set; }
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public IList<PersonalNotification> Notifications { get; set; } = new List<PersonalNotification>();
        public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        public ICollection<Connection> Connections { get; set; } = new List<Connection>();
    }
}