using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Wagering.Models;
using System.Collections.Generic;
using System;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            List<Profile> profiles = new List<Profile>();
            List<ApplicationUser> users = new List<ApplicationUser>();
            List<Wager> wagers = new List<Wager>();
            List<WagerHostBid> hostBids = new List<WagerHostBid>();
            List<WagerChallengeBid> challengeBids = new List<WagerChallengeBid>();
            List<WagerChallenge> challenges = new List<WagerChallenge>();
            DateTime date = new DateTime(2020, 01, 01);
            int hostBidId = -1;
            int challengeBidId = -1;
            int challengeId = -1;
            Game games = new Game { Id = -1, Name = "Fortnite" };


            for (int i = 0; i < 10; i++)
            {
                var username = $"user{i}";
                profiles.Add(new Profile
                {
                    DisplayName = username,
                    IsVerified = false,
                    PublicKey = $"{i}FF8A9FU328JF8A9SJF8923"
                });
                users.Add(new ApplicationUser
                {
                    UserName = $"user{i}@gmail.com",
                    Email = $"user{i}@gmail.com",
                    Id = $"{i}AAAAAAAAAAAAAAAAAAAAAAAAA",
                    ProfileDisplayName = username,
                    ConcurrencyStamp = $"{i}397789b-9897-4430-a9be-1ce19e2e0d09",
                    SecurityStamp = $"4397789b-9897-4430-a9be-1ce19e2e0d0{i}"
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
                        UserDisplayName = users[x].ProfileDisplayName
                    });
                    if (x % 2 == 0)
                        for (int y = 0; y < i % 20; y++)
                        {
                            challenges.Add(new WagerChallenge
                            {
                                Id = challengeId,
                                WagerId = id,
                                Date = date,
                                Amount = i * 1000.0000002m
                            });
                            for (int z = 0; z < x; z++)
                                challengeBids.Add(new WagerChallengeBid
                                {
                                    Id = challengeBidId--,
                                    ChallengeId = challengeId,
                                    Approved = true,
                                    Percentage = (byte)(100 / (i % 7 + 1)),
                                    UserDisplayName = users[x].ProfileDisplayName
                                });
                            challengeId--;
                            date = date.AddMinutes(5);
                        }
                }
                wagers.Add(new Wager
                {
                    Id = id,
                    Date = date,
                    IsClosed = false,
                    GameId = games.Id,
                    Description = "This is a description for wager " + id
                });
                date = date.AddMinutes(1);
            }

            builder.Entity<WagerChallenge>().HasData(challenges);
            builder.Entity<Profile>().HasData(profiles);
            builder.Entity<Game>().HasData(games);
            builder.Entity<ApplicationUser>().HasData(users);
            builder.Entity<Wager>().HasData(wagers);
            builder.Entity<WagerHostBid>().HasData(hostBids);
            builder.Entity<WagerChallengeBid>().HasData(challengeBids);
            base.OnModelCreating(builder);
        }
    }
}
