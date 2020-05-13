using System.Collections.Generic;
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
        public string DisplayName { get; set; }
        public string NormalizedDisplayName { get; set; }
        public bool IsVerified { get; set; }
        public string PublicKey { get; set; }
        public string Platform { get; set; }
        public string Input { get; set; }
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public IList<PersonalNotification> Notifications { get; set; } = new List<PersonalNotification>();
        public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        public ICollection<Connection> Connections { get; set; } = new List<Connection>();
    }
}