using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Wagering.Models;
#nullable disable
namespace Wagering
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        IOptions<OperationalStoreOptions> Options { get; set; }
        #region Wagers
        public DbSet<Wager> Wagers { get; set; }
        public DbSet<WagerChallenge> WagerChallenges { get; set; }
        public DbSet<WagerChallengeBid> WagerChallengeBids { get; set; }
        public DbSet<WagerHostBid> WagerHostBids { get; set; }
        public DbSet<WagerRule> WagerRules { get; set; }
        #endregion
        #region Tournaments
        public DbSet<Tournament> Tournaments { get; set; }
        #endregion
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<PersonalNotification> Notifications { get; set; }

        public ApplicationDbContext(
          DbContextOptions options,
          IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            Options = operationalStoreOptions;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigurePersistedGrantContext(Options.Value);
            Game[] games = new Game[] { new Game { Name = "Fortnite", Url = "fortnite" } };
            builder.Entity<Game>().HasData(games);
            base.OnModelCreating(builder);
        }
    }
}