using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Wagering.Models
{
    public class Profile
    {
        /// <summary>
        /// Id should be the same as ApplicationUser.Id
        /// </summary>
        /// <value>Id</value>
        public string Id { get; set; }
        [RegularExpression(Constants.NameRegex)]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        public string DisplayName { get; set; }
        public string NormalizedDisplayName { get; set; }
        public bool IsVerified { get; set; }
        public string PublicKey { get; set; }
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public IList<PersonalNotification> Notifications { get; set; } = new List<PersonalNotification>();
        public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        public ICollection<Connection> Connections { get; set; } = new List<Connection>();
    }
}