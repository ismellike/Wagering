using Microsoft.EntityFrameworkCore;
using Wagering.Models;
#nullable disable

namespace Wagering
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
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
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Profile>().HasIndex(x => x.UserId).IsUnique();
            builder.Entity<Profile>().HasIndex(x => x.NormalizedDisplayName).IsUnique();
            builder.Entity<Profile>().HasAlternateKey(x => x.UserId);
            builder.Entity<Game>().HasIndex(x => x.NormalizedName).IsUnique();

            Game[] games = new Game[] { new Game { Id = 1, Name = "Fortnite", NormalizedName = "fortnite" } };
            builder.Entity<Game>().HasData(games);
            base.OnModelCreating(builder);
        }
    }
}