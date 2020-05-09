using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Wagering.Models
{
  public class ApplicationUser : IdentityUser
  {
    public bool IsVerified { get; set; }
    public string PublicKey { get; set; }
    public string Platform { get; set; }
    public string Input { get; set; }
    public ICollection<Rating> Ratings { get; set; }
    public IList<PersonalNotification> Notifications { get; set; }

    #region overrides
    [JsonIgnore]
    public override string Email { get; set; }
    [JsonIgnore]
    public override string NormalizedEmail { get; set; }
    [JsonIgnore]
    public override bool EmailConfirmed { get; set; }
    [JsonIgnore]
    public override bool TwoFactorEnabled { get; set; }
    [JsonIgnore]
    public override string PhoneNumber { get; set; }
    [JsonIgnore]
    public override bool PhoneNumberConfirmed { get; set; }
    [JsonIgnore]
    public override string PasswordHash { get; set; }
    [JsonIgnore]
    public override string SecurityStamp { get; set; }
    [JsonIgnore]
    public override bool LockoutEnabled { get; set; }
    [JsonIgnore]
    public override string ConcurrencyStamp { get; set; }
    [JsonIgnore]
    public override int AccessFailedCount { get; set; }
    [JsonIgnore]
    public override DateTimeOffset? LockoutEnd { get; set; }
    #endregion
  }
}
