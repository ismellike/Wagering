using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Wagering.Models;

namespace Wagering
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        IOptions<OperationalStoreOptions> Options { get; set; }
        public DbSet<Wager> Wagers { get; set; }
        public DbSet<WagerChallenge> Challenges { get; set; }
        public DbSet<WagerHostBid> WagerBids { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<EventNotification> EventNotifications { get; set; }
        public DbSet<PersonalNotification> PersonalNotifications { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

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
            //need to fix many to many relationships creating a joining table
            base.OnModelCreating(builder);
        }
    }
}
