using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Wagering.Models;

namespace Wagering
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        IOptions<OperationalStoreOptions> Options { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Wager> Wagers { get; set; }
        public DbSet<WagerChallenge> Challenges { get; set; }
        public DbSet<WagerResult> Results { get; set; }
        public DbSet<WagerHostBid> WagerBids { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Notification> Notifications { get; set; }
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

            List<Profile> profiles = new List<Profile>();
            List<ApplicationUser> users = new List<ApplicationUser>();
            List<Wager> wagers = new List<Wager>();
            List<WagerHostBid> hostBids = new List<WagerHostBid>();
            List<WagerChallengeBid> challengeBids = new List<WagerChallengeBid>();
            List<WagerChallenge> challenges = new List<WagerChallenge>();
            List<Rating> ratings = new List<Rating>();
            DateTime date = new DateTime(2020, 01, 01);
            int hostBidId = -1;
            int challengeBidId = -1;
            int challengeId = -1;
            Game games = new Game { Name = "Fortnite", Url = "fortnite" };


            for (int i = 0; i < 10; i++)
            {
                var username = $"user{i}";
                int id = -1 * i - 1;
                string userId = $"{i}AAAAAAAAAAAAAAAAAAAAAAAAA";
                users.Add(new ApplicationUser
                {
                    UserName = $"user{i}@gmail.com",
                    Email = $"user{i}@gmail.com",
                    Id = userId,
                    ConcurrencyStamp = $"{i}397789b-9897-4430-a9be-1ce19e2e0d09",
                    SecurityStamp = $"4397789b-9897-4430-a9be-1ce19e2e0d0{i}"
                });
                profiles.Add(new Profile
                {
                    Id = id,
                    DisplayName = username,
                    IsVerified = false,
                    PublicKey = $"{i}FF8A9FU328JF8A9SJF8923",
                    UserId = userId
                });
                ratings.Add(new Rating
                {
                    GameName = "Fortnite",
                    GamesPlayed = 0,
                    Id = id,
                    ProfileDisplayName = username,
                    Value = Constants.Rating.Initial
                });
            }
            for (int i = 1; i <= 50; i++)
            {
                int id = i * -1;
                for (int x = 1; x <= i % 7 + 1; x++)
                {
                    hostBids.Add(new WagerHostBid
                    {
                        Id = hostBidId--,
                        WagerId = id,
                        Approved = true,
                        Percentage = (byte)(100 / (i % 7 + 1)),
                        ProfileDisplayName = profiles[x].DisplayName
                    });
                }
                if (i % 2 == 0)
                    for (int y = 0; y < i % 15; y++)
                    {
                        challenges.Add(new WagerChallenge
                        {
                            Id = challengeId,
                            WagerId = id,
                            Date = date,
                            Amount = i * 1000.0000002m
                        });
                        for (int x = 1; x <= i % 7 + 1; x++)
                            challengeBids.Add(new WagerChallengeBid
                            {
                                Id = challengeBidId--,
                                ChallengeId = challengeId,
                                Approved = true,
                                Percentage = (byte)(100 / (i % 7 + 1)),
                                ProfileDisplayName = profiles[x].DisplayName
                            });
                        challengeId--;
                        date = date.AddMinutes(5);
                    }
                wagers.Add(new Wager
                {
                    Id = id,
                    Date = date,
                    IsPrivate = false,
                    GameName = "Fortnite",
                    Status = 1,
                    Description = "This is a description for wager " + id
                });
                date = date.AddMinutes(1);
            }

            builder.Entity<WagerChallenge>().HasData(challenges);
            builder.Entity<Profile>().HasData(profiles);
            builder.Entity<Profile>().HasIndex(x => x.DisplayName).IsUnique();
            builder.Entity<Game>().HasData(games);
            builder.Entity<ApplicationUser>().HasData(users);
            builder.Entity<Wager>().HasData(wagers);
            builder.Entity<WagerHostBid>().HasData(hostBids);
            builder.Entity<WagerChallengeBid>().HasData(challengeBids);
            builder.Entity<Rating>().HasData(ratings);
            base.OnModelCreating(builder);
        }
    }
}
