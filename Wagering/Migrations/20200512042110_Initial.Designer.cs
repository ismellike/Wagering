﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wagering;

namespace Wagering.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200512042110_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wagering.Models.Connection", b =>
                {
                    b.Property<string>("ConnectionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Connected")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConnectionID");

                    b.HasIndex("ProfileId");

                    b.ToTable("Connection");
                });

            modelBuilder.Entity("Wagering.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique();

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fortnite",
                            NormalizedName = "fortnite"
                        });
                });

            modelBuilder.Entity("Wagering.Models.PersonalNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("DataModel")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Wagering.Models.Profile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Input")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("NormalizedDisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Platform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("DisplayName");

                    b.HasIndex("NormalizedDisplayName")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Wagering.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("ProfileId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("ProfileId1");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("Wagering.Models.Rule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("Wagering.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Entry")
                        .HasColumnType("decimal(18,7)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Wagering.Models.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProfileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int?>("WagerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WagerId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("Wagering.Models.Wager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChallengeCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<decimal?>("MaximumWager")
                        .HasColumnType("decimal(18,7)");

                    b.Property<decimal?>("MinimumWager")
                        .HasColumnType("decimal(18,7)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Wagers");
                });

            modelBuilder.Entity("Wagering.Models.WagerChallenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,7)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<int>("WagerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WagerId");

                    b.ToTable("WagerChallenges");
                });

            modelBuilder.Entity("Wagering.Models.WagerChallengeBid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Approved")
                        .HasColumnType("bit");

                    b.Property<int>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<byte>("PayablePt")
                        .HasColumnType("tinyint");

                    b.Property<string>("ProfileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte>("ReceivablePt")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("ProfileId");

                    b.ToTable("WagerChallengeBids");
                });

            modelBuilder.Entity("Wagering.Models.WagerHostBid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Approved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<byte>("PayablePt")
                        .HasColumnType("tinyint");

                    b.Property<string>("ProfileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte>("ReceivablePt")
                        .HasColumnType("tinyint");

                    b.Property<int>("WagerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("WagerId");

                    b.ToTable("WagerHostBids");
                });

            modelBuilder.Entity("Wagering.Models.WagerRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RuleId")
                        .HasColumnType("int");

                    b.Property<int>("WagerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RuleId");

                    b.HasIndex("WagerId");

                    b.ToTable("WagerRules");
                });

            modelBuilder.Entity("Wagering.Models.Connection", b =>
                {
                    b.HasOne("Wagering.Models.Profile", "Profile")
                        .WithMany("Connections")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wagering.Models.PersonalNotification", b =>
                {
                    b.HasOne("Wagering.Models.Profile", "Profile")
                        .WithMany("Notifications")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wagering.Models.Rating", b =>
                {
                    b.HasOne("Wagering.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wagering.Models.Profile", "Profile")
                        .WithMany("Ratings")
                        .HasForeignKey("ProfileId1");
                });

            modelBuilder.Entity("Wagering.Models.Tournament", b =>
                {
                    b.HasOne("Wagering.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wagering.Models.UserGroup", b =>
                {
                    b.HasOne("Wagering.Models.Profile", "Profile")
                        .WithMany("UserGroups")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wagering.Models.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentId");

                    b.HasOne("Wagering.Models.Wager", "Wager")
                        .WithMany()
                        .HasForeignKey("WagerId");
                });

            modelBuilder.Entity("Wagering.Models.Wager", b =>
                {
                    b.HasOne("Wagering.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wagering.Models.WagerChallenge", b =>
                {
                    b.HasOne("Wagering.Models.Wager", "Wager")
                        .WithMany("Challenges")
                        .HasForeignKey("WagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wagering.Models.WagerChallengeBid", b =>
                {
                    b.HasOne("Wagering.Models.WagerChallenge", "Challenge")
                        .WithMany("Challengers")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wagering.Models.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wagering.Models.WagerHostBid", b =>
                {
                    b.HasOne("Wagering.Models.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wagering.Models.Wager", "Wager")
                        .WithMany("Hosts")
                        .HasForeignKey("WagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wagering.Models.WagerRule", b =>
                {
                    b.HasOne("Wagering.Models.Rule", "Rule")
                        .WithMany()
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wagering.Models.Wager", "Wager")
                        .WithMany("Rules")
                        .HasForeignKey("WagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}