using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Wagering.Models;

namespace Wagering
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Wager> Wagers { get; set; }
        public DbSet<WagerChallenge> Challenges { get; set; }
        public DbSet<WagerResult> Results { get; set; }
        public DbSet<WagerHostBid> Bids { get; set; }
        public DbSet<Game> Games { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}
