using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(maxLength: 12, nullable: true),
                    IsVerified = table.Column<bool>(nullable: false),
                    PublicKey = table.Column<string>(nullable: true),
                    Platform = table.Column<string>(nullable: true),
                    Input = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(nullable: false),
                    GameName = table.Column<string>(nullable: true),
                    Result = table.Column<bool>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(24,18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Games_GameName",
                        column: x => x.GameName,
                        principalTable: "Games",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wagers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    MinimumWager = table.Column<decimal>(type: "decimal(18,7)", nullable: true),
                    MaximumWager = table.Column<decimal>(type: "decimal(18,7)", nullable: true),
                    IsClosed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wagers_Games_GameName",
                        column: x => x.GameName,
                        principalTable: "Games",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(nullable: true),
                    UserDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Value = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    GamesPlayed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Games_GameName",
                        column: x => x.GameName,
                        principalTable: "Games",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Profiles_UserId",
                        column: x => x.UserId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WagerId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,7)", nullable: false),
                    IsAccepted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_Wagers_WagerId",
                        column: x => x.WagerId,
                        principalTable: "Wagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WagerBids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WagerId = table.Column<int>(nullable: false),
                    UserDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Percentage = table.Column<byte>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    WagerResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WagerBids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WagerBids_Profiles_UserId",
                        column: x => x.UserId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WagerBids_Wagers_WagerId",
                        column: x => x.WagerId,
                        principalTable: "Wagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WagerBids_Results_WagerResultId",
                        column: x => x.WagerResultId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WagerChallengeBid",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeId = table.Column<int>(nullable: false),
                    UserDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Percentage = table.Column<byte>(nullable: false),
                    Approved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WagerChallengeBid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WagerChallengeBid_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WagerChallengeBid_Profiles_UserId",
                        column: x => x.UserId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0AAAAAAAAAAAAAAAAAAAAAAAAA", 0, "0397789b-9897-4430-a9be-1ce19e2e0d09", "user0@gmail.com", false, false, null, null, null, null, null, false, "4397789b-9897-4430-a9be-1ce19e2e0d00", false, "user0@gmail.com" },
                    { "1AAAAAAAAAAAAAAAAAAAAAAAAA", 0, "1397789b-9897-4430-a9be-1ce19e2e0d09", "user1@gmail.com", false, false, null, null, null, null, null, false, "4397789b-9897-4430-a9be-1ce19e2e0d01", false, "user1@gmail.com" },
                    { "2AAAAAAAAAAAAAAAAAAAAAAAAA", 0, "2397789b-9897-4430-a9be-1ce19e2e0d09", "user2@gmail.com", false, false, null, null, null, null, null, false, "4397789b-9897-4430-a9be-1ce19e2e0d02", false, "user2@gmail.com" },
                    { "3AAAAAAAAAAAAAAAAAAAAAAAAA", 0, "3397789b-9897-4430-a9be-1ce19e2e0d09", "user3@gmail.com", false, false, null, null, null, null, null, false, "4397789b-9897-4430-a9be-1ce19e2e0d03", false, "user3@gmail.com" },
                    { "4AAAAAAAAAAAAAAAAAAAAAAAAA", 0, "4397789b-9897-4430-a9be-1ce19e2e0d09", "user4@gmail.com", false, false, null, null, null, null, null, false, "4397789b-9897-4430-a9be-1ce19e2e0d04", false, "user4@gmail.com" },
                    { "5AAAAAAAAAAAAAAAAAAAAAAAAA", 0, "5397789b-9897-4430-a9be-1ce19e2e0d09", "user5@gmail.com", false, false, null, null, null, null, null, false, "4397789b-9897-4430-a9be-1ce19e2e0d05", false, "user5@gmail.com" },
                    { "6AAAAAAAAAAAAAAAAAAAAAAAAA", 0, "6397789b-9897-4430-a9be-1ce19e2e0d09", "user6@gmail.com", false, false, null, null, null, null, null, false, "4397789b-9897-4430-a9be-1ce19e2e0d06", false, "user6@gmail.com" },
                    { "7AAAAAAAAAAAAAAAAAAAAAAAAA", 0, "7397789b-9897-4430-a9be-1ce19e2e0d09", "user7@gmail.com", false, false, null, null, null, null, null, false, "4397789b-9897-4430-a9be-1ce19e2e0d07", false, "user7@gmail.com" },
                    { "8AAAAAAAAAAAAAAAAAAAAAAAAA", 0, "8397789b-9897-4430-a9be-1ce19e2e0d09", "user8@gmail.com", false, false, null, null, null, null, null, false, "4397789b-9897-4430-a9be-1ce19e2e0d08", false, "user8@gmail.com" },
                    { "9AAAAAAAAAAAAAAAAAAAAAAAAA", 0, "9397789b-9897-4430-a9be-1ce19e2e0d09", "user9@gmail.com", false, false, null, null, null, null, null, false, "4397789b-9897-4430-a9be-1ce19e2e0d09", false, "user9@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Name", "Url" },
                values: new object[] { "Fortnite", "fortnite" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "DisplayName", "Input", "IsVerified", "Platform", "PublicKey", "UserId" },
                values: new object[,]
                {
                    { -1, "user0", null, false, null, "0FF8A9FU328JF8A9SJF8923", "0AAAAAAAAAAAAAAAAAAAAAAAAA" },
                    { -2, "user1", null, false, null, "1FF8A9FU328JF8A9SJF8923", "1AAAAAAAAAAAAAAAAAAAAAAAAA" },
                    { -3, "user2", null, false, null, "2FF8A9FU328JF8A9SJF8923", "2AAAAAAAAAAAAAAAAAAAAAAAAA" },
                    { -4, "user3", null, false, null, "3FF8A9FU328JF8A9SJF8923", "3AAAAAAAAAAAAAAAAAAAAAAAAA" },
                    { -5, "user4", null, false, null, "4FF8A9FU328JF8A9SJF8923", "4AAAAAAAAAAAAAAAAAAAAAAAAA" },
                    { -6, "user5", null, false, null, "5FF8A9FU328JF8A9SJF8923", "5AAAAAAAAAAAAAAAAAAAAAAAAA" },
                    { -7, "user6", null, false, null, "6FF8A9FU328JF8A9SJF8923", "6AAAAAAAAAAAAAAAAAAAAAAAAA" },
                    { -8, "user7", null, false, null, "7FF8A9FU328JF8A9SJF8923", "7AAAAAAAAAAAAAAAAAAAAAAAAA" },
                    { -9, "user8", null, false, null, "8FF8A9FU328JF8A9SJF8923", "8AAAAAAAAAAAAAAAAAAAAAAAAA" },
                    { -10, "user9", null, false, null, "9FF8A9FU328JF8A9SJF8923", "9AAAAAAAAAAAAAAAAAAAAAAAAA" }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "GameName", "GamesPlayed", "UserDisplayName", "UserId", "Value" },
                values: new object[,]
                {
                    { -10, "Fortnite", 0, "user9", null, 1000m },
                    { -9, "Fortnite", 0, "user8", null, 1000m },
                    { -8, "Fortnite", 0, "user7", null, 1000m },
                    { -7, "Fortnite", 0, "user6", null, 1000m },
                    { -6, "Fortnite", 0, "user5", null, 1000m },
                    { -4, "Fortnite", 0, "user3", null, 1000m },
                    { -3, "Fortnite", 0, "user2", null, 1000m },
                    { -2, "Fortnite", 0, "user1", null, 1000m },
                    { -1, "Fortnite", 0, "user0", null, 1000m },
                    { -5, "Fortnite", 0, "user4", null, 1000m }
                });

            migrationBuilder.InsertData(
                table: "Wagers",
                columns: new[] { "Id", "Date", "Description", "GameName", "IsClosed", "MaximumWager", "MinimumWager" },
                values: new object[,]
                {
                    { -36, new DateTime(2020, 1, 1, 10, 20, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -36", "Fortnite", false, null, null },
                    { -27, new DateTime(2020, 1, 1, 8, 6, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -27", "Fortnite", false, null, null },
                    { -28, new DateTime(2020, 1, 1, 9, 12, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -28", "Fortnite", false, null, null },
                    { -29, new DateTime(2020, 1, 1, 9, 13, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -29", "Fortnite", false, null, null },
                    { -30, new DateTime(2020, 1, 1, 9, 14, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -30", "Fortnite", false, null, null },
                    { -31, new DateTime(2020, 1, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -31", "Fortnite", false, null, null },
                    { -32, new DateTime(2020, 1, 1, 9, 26, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -32", "Fortnite", false, null, null },
                    { -33, new DateTime(2020, 1, 1, 9, 27, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -33", "Fortnite", false, null, null },
                    { -34, new DateTime(2020, 1, 1, 9, 48, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -34", "Fortnite", false, null, null },
                    { -35, new DateTime(2020, 1, 1, 9, 49, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -35", "Fortnite", false, null, null },
                    { -37, new DateTime(2020, 1, 1, 10, 21, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -37", "Fortnite", false, null, null },
                    { -47, new DateTime(2020, 1, 1, 14, 16, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -47", "Fortnite", false, null, null },
                    { -39, new DateTime(2020, 1, 1, 11, 3, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -39", "Fortnite", false, null, null },
                    { -40, new DateTime(2020, 1, 1, 11, 54, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -40", "Fortnite", false, null, null },
                    { -41, new DateTime(2020, 1, 1, 11, 55, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -41", "Fortnite", false, null, null },
                    { -42, new DateTime(2020, 1, 1, 12, 56, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -42", "Fortnite", false, null, null },
                    { -43, new DateTime(2020, 1, 1, 12, 57, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -43", "Fortnite", false, null, null },
                    { -44, new DateTime(2020, 1, 1, 14, 8, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -44", "Fortnite", false, null, null },
                    { -45, new DateTime(2020, 1, 1, 14, 9, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -45", "Fortnite", false, null, null },
                    { -46, new DateTime(2020, 1, 1, 14, 15, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -46", "Fortnite", false, null, null },
                    { -26, new DateTime(2020, 1, 1, 8, 5, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -26", "Fortnite", false, null, null },
                    { -48, new DateTime(2020, 1, 1, 14, 32, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -48", "Fortnite", false, null, null },
                    { -38, new DateTime(2020, 1, 1, 11, 2, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -38", "Fortnite", false, null, null },
                    { -25, new DateTime(2020, 1, 1, 7, 9, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -25", "Fortnite", false, null, null },
                    { -15, new DateTime(2020, 1, 1, 4, 54, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -15", "Fortnite", false, null, null },
                    { -23, new DateTime(2020, 1, 1, 6, 22, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -23", "Fortnite", false, null, null },
                    { -1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -1", "Fortnite", false, null, null },
                    { -2, new DateTime(2020, 1, 1, 0, 11, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -2", "Fortnite", false, null, null },
                    { -3, new DateTime(2020, 1, 1, 0, 12, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -3", "Fortnite", false, null, null },
                    { -4, new DateTime(2020, 1, 1, 0, 33, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -4", "Fortnite", false, null, null },
                    { -5, new DateTime(2020, 1, 1, 0, 34, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -5", "Fortnite", false, null, null },
                    { -6, new DateTime(2020, 1, 1, 1, 5, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -6", "Fortnite", false, null, null },
                    { -7, new DateTime(2020, 1, 1, 1, 6, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -7", "Fortnite", false, null, null },
                    { -8, new DateTime(2020, 1, 1, 1, 47, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -8", "Fortnite", false, null, null },
                    { -9, new DateTime(2020, 1, 1, 1, 48, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -9", "Fortnite", false, null, null },
                    { -10, new DateTime(2020, 1, 1, 2, 39, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -10", "Fortnite", false, null, null },
                    { -24, new DateTime(2020, 1, 1, 7, 8, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -24", "Fortnite", false, null, null },
                    { -11, new DateTime(2020, 1, 1, 2, 40, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -11", "Fortnite", false, null, null },
                    { -13, new DateTime(2020, 1, 1, 3, 42, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -13", "Fortnite", false, null, null },
                    { -14, new DateTime(2020, 1, 1, 4, 53, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -14", "Fortnite", false, null, null },
                    { -49, new DateTime(2020, 1, 1, 14, 33, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -49", "Fortnite", false, null, null },
                    { -16, new DateTime(2020, 1, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -16", "Fortnite", false, null, null },
                    { -17, new DateTime(2020, 1, 1, 5, 1, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -17", "Fortnite", false, null, null },
                    { -18, new DateTime(2020, 1, 1, 5, 17, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -18", "Fortnite", false, null, null },
                    { -19, new DateTime(2020, 1, 1, 5, 18, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -19", "Fortnite", false, null, null },
                    { -20, new DateTime(2020, 1, 1, 5, 44, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -20", "Fortnite", false, null, null },
                    { -21, new DateTime(2020, 1, 1, 5, 45, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -21", "Fortnite", false, null, null },
                    { -22, new DateTime(2020, 1, 1, 6, 21, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -22", "Fortnite", false, null, null },
                    { -12, new DateTime(2020, 1, 1, 3, 41, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -12", "Fortnite", false, null, null },
                    { -50, new DateTime(2020, 1, 1, 14, 59, 0, 0, DateTimeKind.Unspecified), "This is a description for wager -50", "Fortnite", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Challenges",
                columns: new[] { "Id", "Amount", "Date", "IsAccepted", "WagerId" },
                values: new object[,]
                {
                    { -86, 26000.0000052m, new DateTime(2020, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), false, -26 },
                    { -64, 20000.0000040m, new DateTime(2020, 1, 1, 5, 34, 0, 0, DateTimeKind.Unspecified), false, -20 },
                    { -65, 20000.0000040m, new DateTime(2020, 1, 1, 5, 39, 0, 0, DateTimeKind.Unspecified), false, -20 },
                    { -135, 40000.0000080m, new DateTime(2020, 1, 1, 11, 49, 0, 0, DateTimeKind.Unspecified), false, -40 },
                    { -134, 40000.0000080m, new DateTime(2020, 1, 1, 11, 44, 0, 0, DateTimeKind.Unspecified), false, -40 },
                    { -133, 40000.0000080m, new DateTime(2020, 1, 1, 11, 39, 0, 0, DateTimeKind.Unspecified), false, -40 },
                    { -132, 40000.0000080m, new DateTime(2020, 1, 1, 11, 34, 0, 0, DateTimeKind.Unspecified), false, -40 },
                    { -131, 40000.0000080m, new DateTime(2020, 1, 1, 11, 29, 0, 0, DateTimeKind.Unspecified), false, -40 },
                    { -130, 40000.0000080m, new DateTime(2020, 1, 1, 11, 24, 0, 0, DateTimeKind.Unspecified), false, -40 },
                    { -66, 22000.0000044m, new DateTime(2020, 1, 1, 5, 46, 0, 0, DateTimeKind.Unspecified), false, -22 },
                    { -67, 22000.0000044m, new DateTime(2020, 1, 1, 5, 51, 0, 0, DateTimeKind.Unspecified), false, -22 },
                    { -68, 22000.0000044m, new DateTime(2020, 1, 1, 5, 56, 0, 0, DateTimeKind.Unspecified), false, -22 },
                    { -69, 22000.0000044m, new DateTime(2020, 1, 1, 6, 1, 0, 0, DateTimeKind.Unspecified), false, -22 },
                    { -70, 22000.0000044m, new DateTime(2020, 1, 1, 6, 6, 0, 0, DateTimeKind.Unspecified), false, -22 },
                    { -71, 22000.0000044m, new DateTime(2020, 1, 1, 6, 11, 0, 0, DateTimeKind.Unspecified), false, -22 },
                    { -72, 22000.0000044m, new DateTime(2020, 1, 1, 6, 16, 0, 0, DateTimeKind.Unspecified), false, -22 },
                    { -129, 40000.0000080m, new DateTime(2020, 1, 1, 11, 19, 0, 0, DateTimeKind.Unspecified), false, -40 },
                    { -128, 40000.0000080m, new DateTime(2020, 1, 1, 11, 14, 0, 0, DateTimeKind.Unspecified), false, -40 },
                    { -127, 40000.0000080m, new DateTime(2020, 1, 1, 11, 9, 0, 0, DateTimeKind.Unspecified), false, -40 },
                    { -126, 40000.0000080m, new DateTime(2020, 1, 1, 11, 4, 0, 0, DateTimeKind.Unspecified), false, -40 },
                    { -73, 24000.0000048m, new DateTime(2020, 1, 1, 6, 23, 0, 0, DateTimeKind.Unspecified), false, -24 },
                    { -74, 24000.0000048m, new DateTime(2020, 1, 1, 6, 28, 0, 0, DateTimeKind.Unspecified), false, -24 },
                    { -63, 20000.0000040m, new DateTime(2020, 1, 1, 5, 29, 0, 0, DateTimeKind.Unspecified), false, -20 },
                    { -75, 24000.0000048m, new DateTime(2020, 1, 1, 6, 33, 0, 0, DateTimeKind.Unspecified), false, -24 },
                    { -62, 20000.0000040m, new DateTime(2020, 1, 1, 5, 24, 0, 0, DateTimeKind.Unspecified), false, -20 },
                    { -60, 18000.0000036m, new DateTime(2020, 1, 1, 5, 12, 0, 0, DateTimeKind.Unspecified), false, -18 },
                    { -48, 14000.0000028m, new DateTime(2020, 1, 1, 4, 8, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -49, 14000.0000028m, new DateTime(2020, 1, 1, 4, 13, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -50, 14000.0000028m, new DateTime(2020, 1, 1, 4, 18, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -51, 14000.0000028m, new DateTime(2020, 1, 1, 4, 23, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -52, 14000.0000028m, new DateTime(2020, 1, 1, 4, 28, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -53, 14000.0000028m, new DateTime(2020, 1, 1, 4, 33, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -54, 14000.0000028m, new DateTime(2020, 1, 1, 4, 38, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -55, 14000.0000028m, new DateTime(2020, 1, 1, 4, 43, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -56, 14000.0000028m, new DateTime(2020, 1, 1, 4, 48, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -145, 42000.0000084m, new DateTime(2020, 1, 1, 12, 41, 0, 0, DateTimeKind.Unspecified), false, -42 },
                    { -144, 42000.0000084m, new DateTime(2020, 1, 1, 12, 36, 0, 0, DateTimeKind.Unspecified), false, -42 },
                    { -143, 42000.0000084m, new DateTime(2020, 1, 1, 12, 31, 0, 0, DateTimeKind.Unspecified), false, -42 },
                    { -57, 16000.0000032m, new DateTime(2020, 1, 1, 4, 55, 0, 0, DateTimeKind.Unspecified), false, -16 },
                    { -142, 42000.0000084m, new DateTime(2020, 1, 1, 12, 26, 0, 0, DateTimeKind.Unspecified), false, -42 },
                    { -141, 42000.0000084m, new DateTime(2020, 1, 1, 12, 21, 0, 0, DateTimeKind.Unspecified), false, -42 },
                    { -139, 42000.0000084m, new DateTime(2020, 1, 1, 12, 11, 0, 0, DateTimeKind.Unspecified), false, -42 },
                    { -138, 42000.0000084m, new DateTime(2020, 1, 1, 12, 6, 0, 0, DateTimeKind.Unspecified), false, -42 },
                    { -137, 42000.0000084m, new DateTime(2020, 1, 1, 12, 1, 0, 0, DateTimeKind.Unspecified), false, -42 },
                    { -136, 42000.0000084m, new DateTime(2020, 1, 1, 11, 56, 0, 0, DateTimeKind.Unspecified), false, -42 },
                    { -58, 18000.0000036m, new DateTime(2020, 1, 1, 5, 2, 0, 0, DateTimeKind.Unspecified), false, -18 },
                    { -59, 18000.0000036m, new DateTime(2020, 1, 1, 5, 7, 0, 0, DateTimeKind.Unspecified), false, -18 },
                    { -61, 20000.0000040m, new DateTime(2020, 1, 1, 5, 19, 0, 0, DateTimeKind.Unspecified), false, -20 },
                    { -47, 14000.0000028m, new DateTime(2020, 1, 1, 4, 3, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -76, 24000.0000048m, new DateTime(2020, 1, 1, 6, 38, 0, 0, DateTimeKind.Unspecified), false, -24 },
                    { -78, 24000.0000048m, new DateTime(2020, 1, 1, 6, 48, 0, 0, DateTimeKind.Unspecified), false, -24 },
                    { -95, 28000.0000056m, new DateTime(2020, 1, 1, 8, 17, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -96, 28000.0000056m, new DateTime(2020, 1, 1, 8, 22, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -97, 28000.0000056m, new DateTime(2020, 1, 1, 8, 27, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -98, 28000.0000056m, new DateTime(2020, 1, 1, 8, 32, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -99, 28000.0000056m, new DateTime(2020, 1, 1, 8, 37, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -100, 28000.0000056m, new DateTime(2020, 1, 1, 8, 42, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -101, 28000.0000056m, new DateTime(2020, 1, 1, 8, 47, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -102, 28000.0000056m, new DateTime(2020, 1, 1, 8, 52, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -103, 28000.0000056m, new DateTime(2020, 1, 1, 8, 57, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -104, 28000.0000056m, new DateTime(2020, 1, 1, 9, 2, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -105, 28000.0000056m, new DateTime(2020, 1, 1, 9, 7, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -115, 36000.0000072m, new DateTime(2020, 1, 1, 10, 5, 0, 0, DateTimeKind.Unspecified), false, -36 },
                    { -114, 36000.0000072m, new DateTime(2020, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), false, -36 },
                    { -113, 36000.0000072m, new DateTime(2020, 1, 1, 9, 55, 0, 0, DateTimeKind.Unspecified), false, -36 },
                    { -112, 36000.0000072m, new DateTime(2020, 1, 1, 9, 50, 0, 0, DateTimeKind.Unspecified), false, -36 },
                    { -106, 32000.0000064m, new DateTime(2020, 1, 1, 9, 16, 0, 0, DateTimeKind.Unspecified), false, -32 },
                    { -107, 32000.0000064m, new DateTime(2020, 1, 1, 9, 21, 0, 0, DateTimeKind.Unspecified), false, -32 },
                    { -111, 34000.0000068m, new DateTime(2020, 1, 1, 9, 43, 0, 0, DateTimeKind.Unspecified), false, -34 },
                    { -110, 34000.0000068m, new DateTime(2020, 1, 1, 9, 38, 0, 0, DateTimeKind.Unspecified), false, -34 },
                    { -109, 34000.0000068m, new DateTime(2020, 1, 1, 9, 33, 0, 0, DateTimeKind.Unspecified), false, -34 },
                    { -108, 34000.0000068m, new DateTime(2020, 1, 1, 9, 28, 0, 0, DateTimeKind.Unspecified), false, -34 },
                    { -94, 28000.0000056m, new DateTime(2020, 1, 1, 8, 12, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -77, 24000.0000048m, new DateTime(2020, 1, 1, 6, 43, 0, 0, DateTimeKind.Unspecified), false, -24 },
                    { -93, 28000.0000056m, new DateTime(2020, 1, 1, 8, 7, 0, 0, DateTimeKind.Unspecified), false, -28 },
                    { -117, 36000.0000072m, new DateTime(2020, 1, 1, 10, 15, 0, 0, DateTimeKind.Unspecified), false, -36 },
                    { -79, 24000.0000048m, new DateTime(2020, 1, 1, 6, 53, 0, 0, DateTimeKind.Unspecified), false, -24 },
                    { -80, 24000.0000048m, new DateTime(2020, 1, 1, 6, 58, 0, 0, DateTimeKind.Unspecified), false, -24 },
                    { -81, 24000.0000048m, new DateTime(2020, 1, 1, 7, 3, 0, 0, DateTimeKind.Unspecified), false, -24 },
                    { -125, 38000.0000076m, new DateTime(2020, 1, 1, 10, 57, 0, 0, DateTimeKind.Unspecified), false, -38 },
                    { -82, 26000.0000052m, new DateTime(2020, 1, 1, 7, 10, 0, 0, DateTimeKind.Unspecified), false, -26 },
                    { -83, 26000.0000052m, new DateTime(2020, 1, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), false, -26 },
                    { -84, 26000.0000052m, new DateTime(2020, 1, 1, 7, 20, 0, 0, DateTimeKind.Unspecified), false, -26 },
                    { -85, 26000.0000052m, new DateTime(2020, 1, 1, 7, 25, 0, 0, DateTimeKind.Unspecified), false, -26 },
                    { -124, 38000.0000076m, new DateTime(2020, 1, 1, 10, 52, 0, 0, DateTimeKind.Unspecified), false, -38 },
                    { -87, 26000.0000052m, new DateTime(2020, 1, 1, 7, 35, 0, 0, DateTimeKind.Unspecified), false, -26 },
                    { -88, 26000.0000052m, new DateTime(2020, 1, 1, 7, 40, 0, 0, DateTimeKind.Unspecified), false, -26 },
                    { -89, 26000.0000052m, new DateTime(2020, 1, 1, 7, 45, 0, 0, DateTimeKind.Unspecified), false, -26 },
                    { -90, 26000.0000052m, new DateTime(2020, 1, 1, 7, 50, 0, 0, DateTimeKind.Unspecified), false, -26 },
                    { -91, 26000.0000052m, new DateTime(2020, 1, 1, 7, 55, 0, 0, DateTimeKind.Unspecified), false, -26 },
                    { -92, 26000.0000052m, new DateTime(2020, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), false, -26 },
                    { -123, 38000.0000076m, new DateTime(2020, 1, 1, 10, 47, 0, 0, DateTimeKind.Unspecified), false, -38 },
                    { -122, 38000.0000076m, new DateTime(2020, 1, 1, 10, 42, 0, 0, DateTimeKind.Unspecified), false, -38 },
                    { -121, 38000.0000076m, new DateTime(2020, 1, 1, 10, 37, 0, 0, DateTimeKind.Unspecified), false, -38 },
                    { -120, 38000.0000076m, new DateTime(2020, 1, 1, 10, 32, 0, 0, DateTimeKind.Unspecified), false, -38 },
                    { -119, 38000.0000076m, new DateTime(2020, 1, 1, 10, 27, 0, 0, DateTimeKind.Unspecified), false, -38 },
                    { -118, 38000.0000076m, new DateTime(2020, 1, 1, 10, 22, 0, 0, DateTimeKind.Unspecified), false, -38 },
                    { -116, 36000.0000072m, new DateTime(2020, 1, 1, 10, 10, 0, 0, DateTimeKind.Unspecified), false, -36 },
                    { -46, 14000.0000028m, new DateTime(2020, 1, 1, 3, 58, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -140, 42000.0000084m, new DateTime(2020, 1, 1, 12, 16, 0, 0, DateTimeKind.Unspecified), false, -42 },
                    { -44, 14000.0000028m, new DateTime(2020, 1, 1, 3, 48, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -15, 8000.0000016m, new DateTime(2020, 1, 1, 1, 17, 0, 0, DateTimeKind.Unspecified), false, -8 },
                    { -16, 8000.0000016m, new DateTime(2020, 1, 1, 1, 22, 0, 0, DateTimeKind.Unspecified), false, -8 },
                    { -17, 8000.0000016m, new DateTime(2020, 1, 1, 1, 27, 0, 0, DateTimeKind.Unspecified), false, -8 },
                    { -18, 8000.0000016m, new DateTime(2020, 1, 1, 1, 32, 0, 0, DateTimeKind.Unspecified), false, -8 },
                    { -45, 14000.0000028m, new DateTime(2020, 1, 1, 3, 53, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -20, 8000.0000016m, new DateTime(2020, 1, 1, 1, 42, 0, 0, DateTimeKind.Unspecified), false, -8 },
                    { -162, 46000.0000092m, new DateTime(2020, 1, 1, 14, 10, 0, 0, DateTimeKind.Unspecified), false, -46 },
                    { -21, 10000.0000020m, new DateTime(2020, 1, 1, 1, 49, 0, 0, DateTimeKind.Unspecified), false, -10 },
                    { -14, 8000.0000016m, new DateTime(2020, 1, 1, 1, 12, 0, 0, DateTimeKind.Unspecified), false, -8 },
                    { -22, 10000.0000020m, new DateTime(2020, 1, 1, 1, 54, 0, 0, DateTimeKind.Unspecified), false, -10 },
                    { -24, 10000.0000020m, new DateTime(2020, 1, 1, 2, 4, 0, 0, DateTimeKind.Unspecified), false, -10 },
                    { -25, 10000.0000020m, new DateTime(2020, 1, 1, 2, 9, 0, 0, DateTimeKind.Unspecified), false, -10 },
                    { -26, 10000.0000020m, new DateTime(2020, 1, 1, 2, 14, 0, 0, DateTimeKind.Unspecified), false, -10 },
                    { -27, 10000.0000020m, new DateTime(2020, 1, 1, 2, 19, 0, 0, DateTimeKind.Unspecified), false, -10 },
                    { -28, 10000.0000020m, new DateTime(2020, 1, 1, 2, 24, 0, 0, DateTimeKind.Unspecified), false, -10 },
                    { -29, 10000.0000020m, new DateTime(2020, 1, 1, 2, 29, 0, 0, DateTimeKind.Unspecified), false, -10 },
                    { -30, 10000.0000020m, new DateTime(2020, 1, 1, 2, 34, 0, 0, DateTimeKind.Unspecified), false, -10 },
                    { -161, 44000.0000088m, new DateTime(2020, 1, 1, 14, 3, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -23, 10000.0000020m, new DateTime(2020, 1, 1, 1, 59, 0, 0, DateTimeKind.Unspecified), false, -10 },
                    { -160, 44000.0000088m, new DateTime(2020, 1, 1, 13, 58, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -13, 8000.0000016m, new DateTime(2020, 1, 1, 1, 7, 0, 0, DateTimeKind.Unspecified), false, -8 },
                    { -11, 6000.0000012m, new DateTime(2020, 1, 1, 0, 55, 0, 0, DateTimeKind.Unspecified), false, -6 },
                    { -170, 50000.0000100m, new DateTime(2020, 1, 1, 14, 54, 0, 0, DateTimeKind.Unspecified), false, -50 },
                    { -1, 2000.0000004m, new DateTime(2020, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified), false, -2 },
                    { -2, 2000.0000004m, new DateTime(2020, 1, 1, 0, 6, 0, 0, DateTimeKind.Unspecified), false, -2 },
                    { -169, 50000.0000100m, new DateTime(2020, 1, 1, 14, 49, 0, 0, DateTimeKind.Unspecified), false, -50 },
                    { -168, 50000.0000100m, new DateTime(2020, 1, 1, 14, 44, 0, 0, DateTimeKind.Unspecified), false, -50 },
                    { -167, 50000.0000100m, new DateTime(2020, 1, 1, 14, 39, 0, 0, DateTimeKind.Unspecified), false, -50 },
                    { -166, 50000.0000100m, new DateTime(2020, 1, 1, 14, 34, 0, 0, DateTimeKind.Unspecified), false, -50 },
                    { -3, 4000.0000008m, new DateTime(2020, 1, 1, 0, 13, 0, 0, DateTimeKind.Unspecified), false, -4 },
                    { -12, 6000.0000012m, new DateTime(2020, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), false, -6 },
                    { -4, 4000.0000008m, new DateTime(2020, 1, 1, 0, 18, 0, 0, DateTimeKind.Unspecified), false, -4 },
                    { -6, 4000.0000008m, new DateTime(2020, 1, 1, 0, 28, 0, 0, DateTimeKind.Unspecified), false, -4 },
                    { -165, 48000.0000096m, new DateTime(2020, 1, 1, 14, 27, 0, 0, DateTimeKind.Unspecified), false, -48 },
                    { -164, 48000.0000096m, new DateTime(2020, 1, 1, 14, 22, 0, 0, DateTimeKind.Unspecified), false, -48 },
                    { -163, 48000.0000096m, new DateTime(2020, 1, 1, 14, 17, 0, 0, DateTimeKind.Unspecified), false, -48 },
                    { -7, 6000.0000012m, new DateTime(2020, 1, 1, 0, 35, 0, 0, DateTimeKind.Unspecified), false, -6 },
                    { -8, 6000.0000012m, new DateTime(2020, 1, 1, 0, 40, 0, 0, DateTimeKind.Unspecified), false, -6 },
                    { -9, 6000.0000012m, new DateTime(2020, 1, 1, 0, 45, 0, 0, DateTimeKind.Unspecified), false, -6 },
                    { -10, 6000.0000012m, new DateTime(2020, 1, 1, 0, 50, 0, 0, DateTimeKind.Unspecified), false, -6 },
                    { -5, 4000.0000008m, new DateTime(2020, 1, 1, 0, 23, 0, 0, DateTimeKind.Unspecified), false, -4 },
                    { -159, 44000.0000088m, new DateTime(2020, 1, 1, 13, 53, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -19, 8000.0000016m, new DateTime(2020, 1, 1, 1, 37, 0, 0, DateTimeKind.Unspecified), false, -8 },
                    { -151, 44000.0000088m, new DateTime(2020, 1, 1, 13, 13, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -35, 12000.0000024m, new DateTime(2020, 1, 1, 3, 1, 0, 0, DateTimeKind.Unspecified), false, -12 },
                    { -36, 12000.0000024m, new DateTime(2020, 1, 1, 3, 6, 0, 0, DateTimeKind.Unspecified), false, -12 },
                    { -152, 44000.0000088m, new DateTime(2020, 1, 1, 13, 18, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -42, 12000.0000024m, new DateTime(2020, 1, 1, 3, 36, 0, 0, DateTimeKind.Unspecified), false, -12 },
                    { -150, 44000.0000088m, new DateTime(2020, 1, 1, 13, 8, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -149, 44000.0000088m, new DateTime(2020, 1, 1, 13, 3, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -37, 12000.0000024m, new DateTime(2020, 1, 1, 3, 11, 0, 0, DateTimeKind.Unspecified), false, -12 },
                    { -154, 44000.0000088m, new DateTime(2020, 1, 1, 13, 28, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -155, 44000.0000088m, new DateTime(2020, 1, 1, 13, 33, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -148, 44000.0000088m, new DateTime(2020, 1, 1, 12, 58, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -34, 12000.0000024m, new DateTime(2020, 1, 1, 2, 56, 0, 0, DateTimeKind.Unspecified), false, -12 },
                    { -158, 44000.0000088m, new DateTime(2020, 1, 1, 13, 48, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -153, 44000.0000088m, new DateTime(2020, 1, 1, 13, 23, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -39, 12000.0000024m, new DateTime(2020, 1, 1, 3, 21, 0, 0, DateTimeKind.Unspecified), false, -12 },
                    { -43, 14000.0000028m, new DateTime(2020, 1, 1, 3, 43, 0, 0, DateTimeKind.Unspecified), false, -14 },
                    { -157, 44000.0000088m, new DateTime(2020, 1, 1, 13, 43, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -146, 42000.0000084m, new DateTime(2020, 1, 1, 12, 46, 0, 0, DateTimeKind.Unspecified), false, -42 },
                    { -147, 42000.0000084m, new DateTime(2020, 1, 1, 12, 51, 0, 0, DateTimeKind.Unspecified), false, -42 },
                    { -41, 12000.0000024m, new DateTime(2020, 1, 1, 3, 31, 0, 0, DateTimeKind.Unspecified), false, -12 },
                    { -156, 44000.0000088m, new DateTime(2020, 1, 1, 13, 38, 0, 0, DateTimeKind.Unspecified), false, -44 },
                    { -31, 12000.0000024m, new DateTime(2020, 1, 1, 2, 41, 0, 0, DateTimeKind.Unspecified), false, -12 },
                    { -32, 12000.0000024m, new DateTime(2020, 1, 1, 2, 46, 0, 0, DateTimeKind.Unspecified), false, -12 },
                    { -33, 12000.0000024m, new DateTime(2020, 1, 1, 2, 51, 0, 0, DateTimeKind.Unspecified), false, -12 },
                    { -40, 12000.0000024m, new DateTime(2020, 1, 1, 3, 26, 0, 0, DateTimeKind.Unspecified), false, -12 },
                    { -38, 12000.0000024m, new DateTime(2020, 1, 1, 3, 16, 0, 0, DateTimeKind.Unspecified), false, -12 }
                });

            migrationBuilder.InsertData(
                table: "WagerBids",
                columns: new[] { "Id", "Approved", "Percentage", "UserDisplayName", "UserId", "WagerId", "WagerResultId" },
                values: new object[,]
                {
                    { -143, true, (byte)33, "user1", null, -37, null },
                    { -188, true, (byte)16, "user6", null, -47, null },
                    { -187, true, (byte)16, "user5", null, -47, null },
                    { -186, true, (byte)16, "user4", null, -47, null },
                    { -141, true, (byte)50, "user1", null, -36, null },
                    { -142, true, (byte)50, "user2", null, -36, null },
                    { -155, true, (byte)16, "user1", null, -40, null },
                    { -190, true, (byte)14, "user2", null, -48, null },
                    { -168, true, (byte)100, "user1", null, -42, null },
                    { -133, true, (byte)14, "user1", null, -34, null },
                    { -134, true, (byte)14, "user2", null, -34, null },
                    { -169, true, (byte)50, "user1", null, -43, null },
                    { -170, true, (byte)50, "user2", null, -43, null },
                    { -135, true, (byte)14, "user3", null, -34, null },
                    { -136, true, (byte)14, "user4", null, -34, null },
                    { -137, true, (byte)14, "user5", null, -34, null },
                    { -138, true, (byte)14, "user6", null, -34, null },
                    { -139, true, (byte)14, "user7", null, -34, null },
                    { -140, true, (byte)100, "user1", null, -35, null },
                    { -196, true, (byte)100, "user1", null, -49, null },
                    { -195, true, (byte)14, "user7", null, -48, null },
                    { -194, true, (byte)14, "user6", null, -48, null },
                    { -193, true, (byte)14, "user5", null, -48, null },
                    { -192, true, (byte)14, "user4", null, -48, null },
                    { -191, true, (byte)14, "user3", null, -48, null },
                    { -189, true, (byte)14, "user1", null, -48, null },
                    { -144, true, (byte)33, "user2", null, -37, null },
                    { -185, true, (byte)16, "user3", null, -47, null },
                    { -132, true, (byte)16, "user6", null, -33, null },
                    { -177, true, (byte)25, "user4", null, -45, null },
                    { -176, true, (byte)25, "user3", null, -45, null },
                    { -175, true, (byte)25, "user2", null, -45, null },
                    { -174, true, (byte)25, "user1", null, -45, null },
                    { -154, true, (byte)20, "user5", null, -39, null },
                    { -162, true, (byte)14, "user2", null, -41, null },
                    { -161, true, (byte)14, "user1", null, -41, null },
                    { -160, true, (byte)16, "user6", null, -40, null },
                    { -159, true, (byte)16, "user5", null, -40, null },
                    { -158, true, (byte)16, "user4", null, -40, null },
                    { -157, true, (byte)16, "user3", null, -40, null },
                    { -173, true, (byte)33, "user3", null, -44, null },
                    { -172, true, (byte)33, "user2", null, -44, null },
                    { -171, true, (byte)33, "user1", null, -44, null },
                    { -156, true, (byte)16, "user2", null, -40, null },
                    { -163, true, (byte)14, "user3", null, -41, null },
                    { -164, true, (byte)14, "user4", null, -41, null },
                    { -165, true, (byte)14, "user5", null, -41, null },
                    { -166, true, (byte)14, "user6", null, -41, null },
                    { -184, true, (byte)16, "user2", null, -47, null },
                    { -183, true, (byte)16, "user1", null, -47, null },
                    { -182, true, (byte)20, "user5", null, -46, null },
                    { -181, true, (byte)20, "user4", null, -46, null },
                    { -180, true, (byte)20, "user3", null, -46, null },
                    { -179, true, (byte)20, "user2", null, -46, null },
                    { -178, true, (byte)20, "user1", null, -46, null },
                    { -145, true, (byte)33, "user3", null, -37, null },
                    { -146, true, (byte)25, "user1", null, -38, null },
                    { -148, true, (byte)25, "user3", null, -38, null },
                    { -149, true, (byte)25, "user4", null, -38, null },
                    { -150, true, (byte)20, "user1", null, -39, null },
                    { -151, true, (byte)20, "user2", null, -39, null },
                    { -152, true, (byte)20, "user3", null, -39, null },
                    { -153, true, (byte)20, "user4", null, -39, null },
                    { -167, true, (byte)14, "user7", null, -41, null },
                    { -147, true, (byte)25, "user2", null, -38, null },
                    { -131, true, (byte)16, "user5", null, -33, null },
                    { -1, true, (byte)50, "user1", null, -1, null },
                    { -129, true, (byte)16, "user3", null, -33, null },
                    { -35, true, (byte)25, "user2", null, -10, null },
                    { -36, true, (byte)25, "user3", null, -10, null },
                    { -37, true, (byte)25, "user4", null, -10, null },
                    { -38, true, (byte)20, "user1", null, -11, null },
                    { -39, true, (byte)20, "user2", null, -11, null },
                    { -40, true, (byte)20, "user3", null, -11, null },
                    { -41, true, (byte)20, "user4", null, -11, null },
                    { -42, true, (byte)20, "user5", null, -11, null },
                    { -43, true, (byte)16, "user1", null, -12, null },
                    { -44, true, (byte)16, "user2", null, -12, null },
                    { -45, true, (byte)16, "user3", null, -12, null },
                    { -46, true, (byte)16, "user4", null, -12, null },
                    { -47, true, (byte)16, "user5", null, -12, null },
                    { -48, true, (byte)16, "user6", null, -12, null },
                    { -49, true, (byte)14, "user1", null, -13, null },
                    { -50, true, (byte)14, "user2", null, -13, null },
                    { -51, true, (byte)14, "user3", null, -13, null },
                    { -52, true, (byte)14, "user4", null, -13, null },
                    { -53, true, (byte)14, "user5", null, -13, null },
                    { -54, true, (byte)14, "user6", null, -13, null },
                    { -55, true, (byte)14, "user7", null, -13, null },
                    { -56, true, (byte)100, "user1", null, -14, null },
                    { -57, true, (byte)50, "user1", null, -15, null },
                    { -58, true, (byte)50, "user2", null, -15, null },
                    { -59, true, (byte)33, "user1", null, -16, null },
                    { -60, true, (byte)33, "user2", null, -16, null },
                    { -61, true, (byte)33, "user3", null, -16, null },
                    { -62, true, (byte)25, "user1", null, -17, null },
                    { -63, true, (byte)25, "user2", null, -17, null },
                    { -34, true, (byte)25, "user1", null, -10, null },
                    { -64, true, (byte)25, "user3", null, -17, null },
                    { -33, true, (byte)33, "user3", null, -9, null },
                    { -31, true, (byte)33, "user1", null, -9, null },
                    { -2, true, (byte)50, "user2", null, -1, null },
                    { -3, true, (byte)33, "user1", null, -2, null },
                    { -4, true, (byte)33, "user2", null, -2, null },
                    { -5, true, (byte)33, "user3", null, -2, null },
                    { -6, true, (byte)25, "user1", null, -3, null },
                    { -7, true, (byte)25, "user2", null, -3, null },
                    { -8, true, (byte)25, "user3", null, -3, null },
                    { -9, true, (byte)25, "user4", null, -3, null },
                    { -10, true, (byte)20, "user1", null, -4, null },
                    { -11, true, (byte)20, "user2", null, -4, null },
                    { -12, true, (byte)20, "user3", null, -4, null },
                    { -13, true, (byte)20, "user4", null, -4, null },
                    { -14, true, (byte)20, "user5", null, -4, null },
                    { -15, true, (byte)16, "user1", null, -5, null },
                    { -16, true, (byte)16, "user2", null, -5, null },
                    { -17, true, (byte)16, "user3", null, -5, null },
                    { -18, true, (byte)16, "user4", null, -5, null },
                    { -19, true, (byte)16, "user5", null, -5, null },
                    { -20, true, (byte)16, "user6", null, -5, null },
                    { -21, true, (byte)14, "user1", null, -6, null },
                    { -22, true, (byte)14, "user2", null, -6, null },
                    { -23, true, (byte)14, "user3", null, -6, null },
                    { -24, true, (byte)14, "user4", null, -6, null },
                    { -25, true, (byte)14, "user5", null, -6, null },
                    { -26, true, (byte)14, "user6", null, -6, null },
                    { -27, true, (byte)14, "user7", null, -6, null },
                    { -28, true, (byte)100, "user1", null, -7, null },
                    { -29, true, (byte)50, "user1", null, -8, null },
                    { -30, true, (byte)50, "user2", null, -8, null },
                    { -32, true, (byte)33, "user2", null, -9, null },
                    { -130, true, (byte)16, "user4", null, -33, null },
                    { -65, true, (byte)25, "user4", null, -17, null },
                    { -67, true, (byte)20, "user2", null, -18, null },
                    { -100, true, (byte)16, "user2", null, -26, null },
                    { -101, true, (byte)16, "user3", null, -26, null },
                    { -102, true, (byte)16, "user4", null, -26, null },
                    { -103, true, (byte)16, "user5", null, -26, null },
                    { -104, true, (byte)16, "user6", null, -26, null },
                    { -105, true, (byte)14, "user1", null, -27, null },
                    { -106, true, (byte)14, "user2", null, -27, null },
                    { -107, true, (byte)14, "user3", null, -27, null },
                    { -108, true, (byte)14, "user4", null, -27, null },
                    { -109, true, (byte)14, "user5", null, -27, null },
                    { -110, true, (byte)14, "user6", null, -27, null },
                    { -111, true, (byte)14, "user7", null, -27, null },
                    { -112, true, (byte)100, "user1", null, -28, null },
                    { -113, true, (byte)50, "user1", null, -29, null },
                    { -114, true, (byte)50, "user2", null, -29, null },
                    { -115, true, (byte)33, "user1", null, -30, null },
                    { -116, true, (byte)33, "user2", null, -30, null },
                    { -117, true, (byte)33, "user3", null, -30, null },
                    { -118, true, (byte)25, "user1", null, -31, null },
                    { -119, true, (byte)25, "user2", null, -31, null },
                    { -120, true, (byte)25, "user3", null, -31, null },
                    { -121, true, (byte)25, "user4", null, -31, null },
                    { -122, true, (byte)20, "user1", null, -32, null },
                    { -123, true, (byte)20, "user2", null, -32, null },
                    { -124, true, (byte)20, "user3", null, -32, null },
                    { -125, true, (byte)20, "user4", null, -32, null },
                    { -126, true, (byte)20, "user5", null, -32, null },
                    { -127, true, (byte)16, "user1", null, -33, null },
                    { -128, true, (byte)16, "user2", null, -33, null },
                    { -99, true, (byte)16, "user1", null, -26, null },
                    { -66, true, (byte)20, "user1", null, -18, null },
                    { -197, true, (byte)50, "user1", null, -50, null },
                    { -97, true, (byte)20, "user4", null, -25, null },
                    { -68, true, (byte)20, "user3", null, -18, null },
                    { -69, true, (byte)20, "user4", null, -18, null },
                    { -70, true, (byte)20, "user5", null, -18, null },
                    { -71, true, (byte)16, "user1", null, -19, null },
                    { -72, true, (byte)16, "user2", null, -19, null },
                    { -73, true, (byte)16, "user3", null, -19, null },
                    { -74, true, (byte)16, "user4", null, -19, null },
                    { -75, true, (byte)16, "user5", null, -19, null },
                    { -76, true, (byte)16, "user6", null, -19, null },
                    { -77, true, (byte)14, "user1", null, -20, null },
                    { -78, true, (byte)14, "user2", null, -20, null }
                });

            migrationBuilder.InsertData(
                table: "WagerBids",
                columns: new[] { "Id", "Approved", "Percentage", "UserDisplayName", "UserId", "WagerId", "WagerResultId" },
                values: new object[,]
                {
                    { -79, true, (byte)14, "user3", null, -20, null },
                    { -80, true, (byte)14, "user4", null, -20, null },
                    { -81, true, (byte)14, "user5", null, -20, null },
                    { -82, true, (byte)14, "user6", null, -20, null },
                    { -83, true, (byte)14, "user7", null, -20, null },
                    { -84, true, (byte)100, "user1", null, -21, null },
                    { -85, true, (byte)50, "user1", null, -22, null },
                    { -86, true, (byte)50, "user2", null, -22, null },
                    { -87, true, (byte)33, "user1", null, -23, null },
                    { -88, true, (byte)33, "user2", null, -23, null },
                    { -89, true, (byte)33, "user3", null, -23, null },
                    { -90, true, (byte)25, "user1", null, -24, null },
                    { -91, true, (byte)25, "user2", null, -24, null },
                    { -92, true, (byte)25, "user3", null, -24, null },
                    { -93, true, (byte)25, "user4", null, -24, null },
                    { -94, true, (byte)20, "user1", null, -25, null },
                    { -95, true, (byte)20, "user2", null, -25, null },
                    { -96, true, (byte)20, "user3", null, -25, null },
                    { -98, true, (byte)20, "user5", null, -25, null },
                    { -198, true, (byte)50, "user2", null, -50, null }
                });

            migrationBuilder.InsertData(
                table: "WagerChallengeBid",
                columns: new[] { "Id", "Approved", "ChallengeId", "Percentage", "UserDisplayName", "UserId" },
                values: new object[,]
                {
                    { -1, true, -1, (byte)33, "user1", null },
                    { -413, true, -109, (byte)14, "user4", null },
                    { -414, true, -109, (byte)14, "user5", null },
                    { -415, true, -109, (byte)14, "user6", null },
                    { -416, true, -109, (byte)14, "user7", null },
                    { -417, true, -110, (byte)14, "user1", null },
                    { -418, true, -110, (byte)14, "user2", null },
                    { -419, true, -110, (byte)14, "user3", null },
                    { -420, true, -110, (byte)14, "user4", null },
                    { -421, true, -110, (byte)14, "user5", null },
                    { -422, true, -110, (byte)14, "user6", null },
                    { -423, true, -110, (byte)14, "user7", null },
                    { -424, true, -111, (byte)14, "user1", null },
                    { -425, true, -111, (byte)14, "user2", null },
                    { -426, true, -111, (byte)14, "user3", null },
                    { -427, true, -111, (byte)14, "user4", null },
                    { -412, true, -109, (byte)14, "user3", null },
                    { -411, true, -109, (byte)14, "user2", null },
                    { -410, true, -109, (byte)14, "user1", null },
                    { -409, true, -108, (byte)14, "user7", null },
                    { -393, true, -106, (byte)20, "user1", null },
                    { -394, true, -106, (byte)20, "user2", null },
                    { -395, true, -106, (byte)20, "user3", null },
                    { -396, true, -106, (byte)20, "user4", null },
                    { -397, true, -106, (byte)20, "user5", null },
                    { -398, true, -107, (byte)20, "user1", null },
                    { -399, true, -107, (byte)20, "user2", null },
                    { -428, true, -111, (byte)14, "user5", null },
                    { -400, true, -107, (byte)20, "user3", null },
                    { -402, true, -107, (byte)20, "user5", null },
                    { -403, true, -108, (byte)14, "user1", null },
                    { -404, true, -108, (byte)14, "user2", null },
                    { -405, true, -108, (byte)14, "user3", null },
                    { -406, true, -108, (byte)14, "user4", null },
                    { -407, true, -108, (byte)14, "user5", null },
                    { -408, true, -108, (byte)14, "user6", null },
                    { -401, true, -107, (byte)20, "user4", null },
                    { -392, true, -105, (byte)100, "user1", null },
                    { -429, true, -111, (byte)14, "user6", null },
                    { -431, true, -112, (byte)50, "user1", null },
                    { -452, true, -120, (byte)25, "user2", null },
                    { -453, true, -120, (byte)25, "user3", null },
                    { -454, true, -120, (byte)25, "user4", null },
                    { -455, true, -121, (byte)25, "user1", null },
                    { -456, true, -121, (byte)25, "user2", null },
                    { -457, true, -121, (byte)25, "user3", null },
                    { -458, true, -121, (byte)25, "user4", null },
                    { -459, true, -122, (byte)25, "user1", null },
                    { -460, true, -122, (byte)25, "user2", null },
                    { -461, true, -122, (byte)25, "user3", null },
                    { -462, true, -122, (byte)25, "user4", null },
                    { -463, true, -123, (byte)25, "user1", null },
                    { -464, true, -123, (byte)25, "user2", null },
                    { -465, true, -123, (byte)25, "user3", null },
                    { -466, true, -123, (byte)25, "user4", null },
                    { -451, true, -120, (byte)25, "user1", null },
                    { -450, true, -119, (byte)25, "user4", null },
                    { -449, true, -119, (byte)25, "user3", null },
                    { -448, true, -119, (byte)25, "user2", null },
                    { -432, true, -112, (byte)50, "user2", null },
                    { -433, true, -113, (byte)50, "user1", null },
                    { -434, true, -113, (byte)50, "user2", null },
                    { -435, true, -114, (byte)50, "user1", null },
                    { -436, true, -114, (byte)50, "user2", null },
                    { -437, true, -115, (byte)50, "user1", null },
                    { -438, true, -115, (byte)50, "user2", null },
                    { -430, true, -111, (byte)14, "user7", null },
                    { -439, true, -116, (byte)50, "user1", null },
                    { -441, true, -117, (byte)50, "user1", null },
                    { -442, true, -117, (byte)50, "user2", null },
                    { -443, true, -118, (byte)25, "user1", null },
                    { -444, true, -118, (byte)25, "user2", null },
                    { -445, true, -118, (byte)25, "user3", null },
                    { -446, true, -118, (byte)25, "user4", null },
                    { -447, true, -119, (byte)25, "user1", null },
                    { -440, true, -116, (byte)50, "user2", null },
                    { -467, true, -124, (byte)25, "user1", null },
                    { -391, true, -104, (byte)100, "user1", null },
                    { -389, true, -102, (byte)100, "user1", null },
                    { -335, true, -85, (byte)16, "user4", null },
                    { -336, true, -85, (byte)16, "user5", null },
                    { -337, true, -85, (byte)16, "user6", null },
                    { -338, true, -86, (byte)16, "user1", null },
                    { -339, true, -86, (byte)16, "user2", null },
                    { -340, true, -86, (byte)16, "user3", null },
                    { -341, true, -86, (byte)16, "user4", null },
                    { -342, true, -86, (byte)16, "user5", null },
                    { -343, true, -86, (byte)16, "user6", null },
                    { -344, true, -87, (byte)16, "user1", null },
                    { -345, true, -87, (byte)16, "user2", null },
                    { -346, true, -87, (byte)16, "user3", null },
                    { -347, true, -87, (byte)16, "user4", null },
                    { -348, true, -87, (byte)16, "user5", null },
                    { -349, true, -87, (byte)16, "user6", null },
                    { -334, true, -85, (byte)16, "user3", null },
                    { -333, true, -85, (byte)16, "user2", null },
                    { -332, true, -85, (byte)16, "user1", null },
                    { -331, true, -84, (byte)16, "user6", null },
                    { -315, true, -82, (byte)16, "user2", null },
                    { -316, true, -82, (byte)16, "user3", null },
                    { -317, true, -82, (byte)16, "user4", null },
                    { -318, true, -82, (byte)16, "user5", null },
                    { -319, true, -82, (byte)16, "user6", null },
                    { -320, true, -83, (byte)16, "user1", null },
                    { -321, true, -83, (byte)16, "user2", null },
                    { -350, true, -88, (byte)16, "user1", null },
                    { -322, true, -83, (byte)16, "user3", null },
                    { -324, true, -83, (byte)16, "user5", null },
                    { -325, true, -83, (byte)16, "user6", null },
                    { -326, true, -84, (byte)16, "user1", null },
                    { -327, true, -84, (byte)16, "user2", null },
                    { -328, true, -84, (byte)16, "user3", null },
                    { -329, true, -84, (byte)16, "user4", null },
                    { -330, true, -84, (byte)16, "user5", null },
                    { -323, true, -83, (byte)16, "user4", null },
                    { -390, true, -103, (byte)100, "user1", null },
                    { -351, true, -88, (byte)16, "user2", null },
                    { -353, true, -88, (byte)16, "user4", null },
                    { -374, true, -92, (byte)16, "user1", null },
                    { -375, true, -92, (byte)16, "user2", null },
                    { -376, true, -92, (byte)16, "user3", null },
                    { -377, true, -92, (byte)16, "user4", null },
                    { -378, true, -92, (byte)16, "user5", null },
                    { -379, true, -92, (byte)16, "user6", null },
                    { -380, true, -93, (byte)100, "user1", null },
                    { -381, true, -94, (byte)100, "user1", null },
                    { -382, true, -95, (byte)100, "user1", null },
                    { -383, true, -96, (byte)100, "user1", null },
                    { -384, true, -97, (byte)100, "user1", null },
                    { -385, true, -98, (byte)100, "user1", null },
                    { -386, true, -99, (byte)100, "user1", null },
                    { -387, true, -100, (byte)100, "user1", null },
                    { -388, true, -101, (byte)100, "user1", null },
                    { -373, true, -91, (byte)16, "user6", null },
                    { -372, true, -91, (byte)16, "user5", null },
                    { -371, true, -91, (byte)16, "user4", null },
                    { -370, true, -91, (byte)16, "user3", null },
                    { -354, true, -88, (byte)16, "user5", null },
                    { -355, true, -88, (byte)16, "user6", null },
                    { -356, true, -89, (byte)16, "user1", null },
                    { -357, true, -89, (byte)16, "user2", null },
                    { -358, true, -89, (byte)16, "user3", null },
                    { -359, true, -89, (byte)16, "user4", null },
                    { -360, true, -89, (byte)16, "user5", null },
                    { -352, true, -88, (byte)16, "user3", null },
                    { -361, true, -89, (byte)16, "user6", null },
                    { -363, true, -90, (byte)16, "user2", null },
                    { -364, true, -90, (byte)16, "user3", null },
                    { -365, true, -90, (byte)16, "user4", null },
                    { -366, true, -90, (byte)16, "user5", null },
                    { -367, true, -90, (byte)16, "user6", null },
                    { -368, true, -91, (byte)16, "user1", null },
                    { -369, true, -91, (byte)16, "user2", null },
                    { -362, true, -90, (byte)16, "user1", null },
                    { -314, true, -82, (byte)16, "user1", null },
                    { -468, true, -124, (byte)25, "user2", null },
                    { -470, true, -124, (byte)25, "user4", null },
                    { -569, true, -155, (byte)33, "user2", null },
                    { -570, true, -155, (byte)33, "user3", null },
                    { -571, true, -156, (byte)33, "user1", null },
                    { -572, true, -156, (byte)33, "user2", null },
                    { -573, true, -156, (byte)33, "user3", null },
                    { -574, true, -157, (byte)33, "user1", null },
                    { -575, true, -157, (byte)33, "user2", null },
                    { -576, true, -157, (byte)33, "user3", null },
                    { -577, true, -158, (byte)33, "user1", null },
                    { -578, true, -158, (byte)33, "user2", null },
                    { -579, true, -158, (byte)33, "user3", null },
                    { -580, true, -159, (byte)33, "user1", null },
                    { -581, true, -159, (byte)33, "user2", null },
                    { -582, true, -159, (byte)33, "user3", null },
                    { -583, true, -160, (byte)33, "user1", null },
                    { -568, true, -155, (byte)33, "user1", null },
                    { -567, true, -154, (byte)33, "user3", null },
                    { -566, true, -154, (byte)33, "user2", null },
                    { -565, true, -154, (byte)33, "user1", null },
                    { -549, true, -148, (byte)33, "user3", null },
                    { -550, true, -149, (byte)33, "user1", null },
                    { -551, true, -149, (byte)33, "user2", null },
                    { -552, true, -149, (byte)33, "user3", null },
                    { -553, true, -150, (byte)33, "user1", null },
                    { -554, true, -150, (byte)33, "user2", null },
                    { -555, true, -150, (byte)33, "user3", null },
                    { -584, true, -160, (byte)33, "user2", null },
                    { -556, true, -151, (byte)33, "user1", null },
                    { -558, true, -151, (byte)33, "user3", null },
                    { -559, true, -152, (byte)33, "user1", null },
                    { -560, true, -152, (byte)33, "user2", null },
                    { -561, true, -152, (byte)33, "user3", null },
                    { -562, true, -153, (byte)33, "user1", null },
                    { -563, true, -153, (byte)33, "user2", null },
                    { -564, true, -153, (byte)33, "user3", null },
                    { -557, true, -151, (byte)33, "user2", null },
                    { -548, true, -148, (byte)33, "user2", null },
                    { -585, true, -160, (byte)33, "user3", null },
                    { -587, true, -161, (byte)33, "user2", null },
                    { -608, true, -165, (byte)14, "user1", null },
                    { -609, true, -165, (byte)14, "user2", null },
                    { -610, true, -165, (byte)14, "user3", null },
                    { -611, true, -165, (byte)14, "user4", null },
                    { -612, true, -165, (byte)14, "user5", null },
                    { -613, true, -165, (byte)14, "user6", null },
                    { -614, true, -165, (byte)14, "user7", null },
                    { -615, true, -166, (byte)50, "user1", null },
                    { -616, true, -166, (byte)50, "user2", null },
                    { -617, true, -167, (byte)50, "user1", null },
                    { -618, true, -167, (byte)50, "user2", null },
                    { -619, true, -168, (byte)50, "user1", null },
                    { -620, true, -168, (byte)50, "user2", null },
                    { -621, true, -169, (byte)50, "user1", null },
                    { -622, true, -169, (byte)50, "user2", null },
                    { -607, true, -164, (byte)14, "user7", null },
                    { -606, true, -164, (byte)14, "user6", null },
                    { -605, true, -164, (byte)14, "user5", null },
                    { -604, true, -164, (byte)14, "user4", null },
                    { -588, true, -161, (byte)33, "user3", null },
                    { -589, true, -162, (byte)20, "user1", null },
                    { -590, true, -162, (byte)20, "user2", null },
                    { -591, true, -162, (byte)20, "user3", null },
                    { -592, true, -162, (byte)20, "user4", null },
                    { -593, true, -162, (byte)20, "user5", null },
                    { -594, true, -163, (byte)14, "user1", null },
                    { -586, true, -161, (byte)33, "user1", null },
                    { -595, true, -163, (byte)14, "user2", null },
                    { -597, true, -163, (byte)14, "user4", null },
                    { -598, true, -163, (byte)14, "user5", null },
                    { -599, true, -163, (byte)14, "user6", null },
                    { -600, true, -163, (byte)14, "user7", null },
                    { -601, true, -164, (byte)14, "user1", null },
                    { -602, true, -164, (byte)14, "user2", null },
                    { -603, true, -164, (byte)14, "user3", null },
                    { -596, true, -163, (byte)14, "user3", null },
                    { -469, true, -124, (byte)25, "user3", null },
                    { -547, true, -148, (byte)33, "user1", null },
                    { -545, true, -146, (byte)100, "user1", null },
                    { -491, true, -128, (byte)16, "user5", null },
                    { -492, true, -128, (byte)16, "user6", null },
                    { -493, true, -129, (byte)16, "user1", null },
                    { -494, true, -129, (byte)16, "user2", null },
                    { -495, true, -129, (byte)16, "user3", null },
                    { -496, true, -129, (byte)16, "user4", null },
                    { -497, true, -129, (byte)16, "user5", null },
                    { -498, true, -129, (byte)16, "user6", null },
                    { -499, true, -130, (byte)16, "user1", null },
                    { -500, true, -130, (byte)16, "user2", null },
                    { -501, true, -130, (byte)16, "user3", null },
                    { -502, true, -130, (byte)16, "user4", null },
                    { -503, true, -130, (byte)16, "user5", null },
                    { -504, true, -130, (byte)16, "user6", null },
                    { -505, true, -131, (byte)16, "user1", null },
                    { -490, true, -128, (byte)16, "user4", null },
                    { -489, true, -128, (byte)16, "user3", null },
                    { -488, true, -128, (byte)16, "user2", null },
                    { -487, true, -128, (byte)16, "user1", null },
                    { -471, true, -125, (byte)25, "user1", null },
                    { -472, true, -125, (byte)25, "user2", null },
                    { -473, true, -125, (byte)25, "user3", null },
                    { -474, true, -125, (byte)25, "user4", null },
                    { -475, true, -126, (byte)16, "user1", null },
                    { -476, true, -126, (byte)16, "user2", null },
                    { -477, true, -126, (byte)16, "user3", null },
                    { -506, true, -131, (byte)16, "user2", null },
                    { -478, true, -126, (byte)16, "user4", null },
                    { -480, true, -126, (byte)16, "user6", null },
                    { -481, true, -127, (byte)16, "user1", null },
                    { -482, true, -127, (byte)16, "user2", null },
                    { -483, true, -127, (byte)16, "user3", null },
                    { -484, true, -127, (byte)16, "user4", null },
                    { -485, true, -127, (byte)16, "user5", null },
                    { -486, true, -127, (byte)16, "user6", null },
                    { -479, true, -126, (byte)16, "user5", null },
                    { -546, true, -147, (byte)100, "user1", null },
                    { -507, true, -131, (byte)16, "user3", null },
                    { -509, true, -131, (byte)16, "user5", null },
                    { -530, true, -135, (byte)16, "user2", null },
                    { -531, true, -135, (byte)16, "user3", null },
                    { -532, true, -135, (byte)16, "user4", null },
                    { -533, true, -135, (byte)16, "user5", null },
                    { -534, true, -135, (byte)16, "user6", null },
                    { -535, true, -136, (byte)100, "user1", null },
                    { -536, true, -137, (byte)100, "user1", null },
                    { -537, true, -138, (byte)100, "user1", null },
                    { -538, true, -139, (byte)100, "user1", null },
                    { -539, true, -140, (byte)100, "user1", null },
                    { -540, true, -141, (byte)100, "user1", null },
                    { -541, true, -142, (byte)100, "user1", null },
                    { -542, true, -143, (byte)100, "user1", null },
                    { -543, true, -144, (byte)100, "user1", null },
                    { -544, true, -145, (byte)100, "user1", null },
                    { -529, true, -135, (byte)16, "user1", null },
                    { -528, true, -134, (byte)16, "user6", null },
                    { -527, true, -134, (byte)16, "user5", null },
                    { -526, true, -134, (byte)16, "user4", null },
                    { -510, true, -131, (byte)16, "user6", null },
                    { -511, true, -132, (byte)16, "user1", null },
                    { -512, true, -132, (byte)16, "user2", null },
                    { -513, true, -132, (byte)16, "user3", null },
                    { -514, true, -132, (byte)16, "user4", null },
                    { -515, true, -132, (byte)16, "user5", null },
                    { -516, true, -132, (byte)16, "user6", null },
                    { -508, true, -131, (byte)16, "user4", null },
                    { -517, true, -133, (byte)16, "user1", null },
                    { -519, true, -133, (byte)16, "user3", null },
                    { -520, true, -133, (byte)16, "user4", null },
                    { -521, true, -133, (byte)16, "user5", null },
                    { -522, true, -133, (byte)16, "user6", null },
                    { -523, true, -134, (byte)16, "user1", null },
                    { -524, true, -134, (byte)16, "user2", null },
                    { -525, true, -134, (byte)16, "user3", null },
                    { -518, true, -133, (byte)16, "user2", null },
                    { -313, true, -81, (byte)25, "user4", null },
                    { -312, true, -81, (byte)25, "user3", null },
                    { -311, true, -81, (byte)25, "user2", null },
                    { -100, true, -24, (byte)25, "user4", null },
                    { -101, true, -25, (byte)25, "user1", null },
                    { -102, true, -25, (byte)25, "user2", null },
                    { -103, true, -25, (byte)25, "user3", null },
                    { -104, true, -25, (byte)25, "user4", null },
                    { -105, true, -26, (byte)25, "user1", null },
                    { -106, true, -26, (byte)25, "user2", null },
                    { -107, true, -26, (byte)25, "user3", null },
                    { -108, true, -26, (byte)25, "user4", null },
                    { -109, true, -27, (byte)25, "user1", null },
                    { -110, true, -27, (byte)25, "user2", null },
                    { -111, true, -27, (byte)25, "user3", null },
                    { -112, true, -27, (byte)25, "user4", null },
                    { -113, true, -28, (byte)25, "user1", null },
                    { -114, true, -28, (byte)25, "user2", null },
                    { -99, true, -24, (byte)25, "user3", null },
                    { -98, true, -24, (byte)25, "user2", null },
                    { -97, true, -24, (byte)25, "user1", null },
                    { -96, true, -23, (byte)25, "user4", null },
                    { -80, true, -18, (byte)50, "user2", null },
                    { -81, true, -19, (byte)50, "user1", null },
                    { -82, true, -19, (byte)50, "user2", null },
                    { -83, true, -20, (byte)50, "user1", null },
                    { -84, true, -20, (byte)50, "user2", null },
                    { -85, true, -21, (byte)25, "user1", null },
                    { -86, true, -21, (byte)25, "user2", null },
                    { -115, true, -28, (byte)25, "user3", null },
                    { -87, true, -21, (byte)25, "user3", null },
                    { -89, true, -22, (byte)25, "user1", null },
                    { -90, true, -22, (byte)25, "user2", null },
                    { -91, true, -22, (byte)25, "user3", null },
                    { -92, true, -22, (byte)25, "user4", null },
                    { -93, true, -23, (byte)25, "user1", null },
                    { -94, true, -23, (byte)25, "user2", null },
                    { -95, true, -23, (byte)25, "user3", null },
                    { -88, true, -21, (byte)25, "user4", null }
                });

            migrationBuilder.InsertData(
                table: "WagerChallengeBid",
                columns: new[] { "Id", "Approved", "ChallengeId", "Percentage", "UserDisplayName", "UserId" },
                values: new object[,]
                {
                    { -79, true, -18, (byte)50, "user1", null },
                    { -116, true, -28, (byte)25, "user4", null },
                    { -118, true, -29, (byte)25, "user2", null },
                    { -139, true, -33, (byte)16, "user3", null },
                    { -140, true, -33, (byte)16, "user4", null },
                    { -141, true, -33, (byte)16, "user5", null },
                    { -142, true, -33, (byte)16, "user6", null },
                    { -143, true, -34, (byte)16, "user1", null },
                    { -144, true, -34, (byte)16, "user2", null },
                    { -145, true, -34, (byte)16, "user3", null },
                    { -146, true, -34, (byte)16, "user4", null },
                    { -147, true, -34, (byte)16, "user5", null },
                    { -148, true, -34, (byte)16, "user6", null },
                    { -149, true, -35, (byte)16, "user1", null },
                    { -150, true, -35, (byte)16, "user2", null },
                    { -151, true, -35, (byte)16, "user3", null },
                    { -152, true, -35, (byte)16, "user4", null },
                    { -153, true, -35, (byte)16, "user5", null },
                    { -138, true, -33, (byte)16, "user2", null },
                    { -137, true, -33, (byte)16, "user1", null },
                    { -136, true, -32, (byte)16, "user6", null },
                    { -135, true, -32, (byte)16, "user5", null },
                    { -119, true, -29, (byte)25, "user3", null },
                    { -120, true, -29, (byte)25, "user4", null },
                    { -121, true, -30, (byte)25, "user1", null },
                    { -122, true, -30, (byte)25, "user2", null },
                    { -123, true, -30, (byte)25, "user3", null },
                    { -124, true, -30, (byte)25, "user4", null },
                    { -125, true, -31, (byte)16, "user1", null },
                    { -117, true, -29, (byte)25, "user1", null },
                    { -126, true, -31, (byte)16, "user2", null },
                    { -128, true, -31, (byte)16, "user4", null },
                    { -129, true, -31, (byte)16, "user5", null },
                    { -130, true, -31, (byte)16, "user6", null },
                    { -131, true, -32, (byte)16, "user1", null },
                    { -132, true, -32, (byte)16, "user2", null },
                    { -133, true, -32, (byte)16, "user3", null },
                    { -134, true, -32, (byte)16, "user4", null },
                    { -127, true, -31, (byte)16, "user3", null },
                    { -154, true, -35, (byte)16, "user6", null },
                    { -78, true, -17, (byte)50, "user2", null },
                    { -76, true, -16, (byte)50, "user2", null },
                    { -22, true, -6, (byte)20, "user1", null },
                    { -23, true, -6, (byte)20, "user2", null },
                    { -24, true, -6, (byte)20, "user3", null },
                    { -25, true, -6, (byte)20, "user4", null },
                    { -26, true, -6, (byte)20, "user5", null },
                    { -27, true, -7, (byte)14, "user1", null },
                    { -28, true, -7, (byte)14, "user2", null },
                    { -29, true, -7, (byte)14, "user3", null },
                    { -30, true, -7, (byte)14, "user4", null },
                    { -31, true, -7, (byte)14, "user5", null },
                    { -32, true, -7, (byte)14, "user6", null },
                    { -33, true, -7, (byte)14, "user7", null },
                    { -34, true, -8, (byte)14, "user1", null },
                    { -35, true, -8, (byte)14, "user2", null },
                    { -36, true, -8, (byte)14, "user3", null },
                    { -21, true, -5, (byte)20, "user5", null },
                    { -20, true, -5, (byte)20, "user4", null },
                    { -19, true, -5, (byte)20, "user3", null },
                    { -18, true, -5, (byte)20, "user2", null },
                    { -2, true, -1, (byte)33, "user2", null },
                    { -3, true, -1, (byte)33, "user3", null },
                    { -4, true, -2, (byte)33, "user1", null },
                    { -5, true, -2, (byte)33, "user2", null },
                    { -6, true, -2, (byte)33, "user3", null },
                    { -7, true, -3, (byte)20, "user1", null },
                    { -8, true, -3, (byte)20, "user2", null },
                    { -37, true, -8, (byte)14, "user4", null },
                    { -9, true, -3, (byte)20, "user3", null },
                    { -11, true, -3, (byte)20, "user5", null },
                    { -12, true, -4, (byte)20, "user1", null },
                    { -13, true, -4, (byte)20, "user2", null },
                    { -14, true, -4, (byte)20, "user3", null },
                    { -15, true, -4, (byte)20, "user4", null },
                    { -16, true, -4, (byte)20, "user5", null },
                    { -17, true, -5, (byte)20, "user1", null },
                    { -10, true, -3, (byte)20, "user4", null },
                    { -77, true, -17, (byte)50, "user1", null },
                    { -38, true, -8, (byte)14, "user5", null },
                    { -40, true, -8, (byte)14, "user7", null },
                    { -61, true, -11, (byte)14, "user7", null },
                    { -62, true, -12, (byte)14, "user1", null },
                    { -63, true, -12, (byte)14, "user2", null },
                    { -64, true, -12, (byte)14, "user3", null },
                    { -65, true, -12, (byte)14, "user4", null },
                    { -66, true, -12, (byte)14, "user5", null },
                    { -67, true, -12, (byte)14, "user6", null },
                    { -68, true, -12, (byte)14, "user7", null },
                    { -69, true, -13, (byte)50, "user1", null },
                    { -70, true, -13, (byte)50, "user2", null },
                    { -71, true, -14, (byte)50, "user1", null },
                    { -72, true, -14, (byte)50, "user2", null },
                    { -73, true, -15, (byte)50, "user1", null },
                    { -74, true, -15, (byte)50, "user2", null },
                    { -75, true, -16, (byte)50, "user1", null },
                    { -60, true, -11, (byte)14, "user6", null },
                    { -59, true, -11, (byte)14, "user5", null },
                    { -58, true, -11, (byte)14, "user4", null },
                    { -57, true, -11, (byte)14, "user3", null },
                    { -41, true, -9, (byte)14, "user1", null },
                    { -42, true, -9, (byte)14, "user2", null },
                    { -43, true, -9, (byte)14, "user3", null },
                    { -44, true, -9, (byte)14, "user4", null },
                    { -45, true, -9, (byte)14, "user5", null },
                    { -46, true, -9, (byte)14, "user6", null },
                    { -47, true, -9, (byte)14, "user7", null },
                    { -39, true, -8, (byte)14, "user6", null },
                    { -48, true, -10, (byte)14, "user1", null },
                    { -50, true, -10, (byte)14, "user3", null },
                    { -51, true, -10, (byte)14, "user4", null },
                    { -52, true, -10, (byte)14, "user5", null },
                    { -53, true, -10, (byte)14, "user6", null },
                    { -54, true, -10, (byte)14, "user7", null },
                    { -55, true, -11, (byte)14, "user1", null },
                    { -56, true, -11, (byte)14, "user2", null },
                    { -49, true, -10, (byte)14, "user2", null },
                    { -155, true, -36, (byte)16, "user1", null },
                    { -156, true, -36, (byte)16, "user2", null },
                    { -157, true, -36, (byte)16, "user3", null },
                    { -257, true, -65, (byte)14, "user1", null },
                    { -258, true, -65, (byte)14, "user2", null },
                    { -259, true, -65, (byte)14, "user3", null },
                    { -260, true, -65, (byte)14, "user4", null },
                    { -261, true, -65, (byte)14, "user5", null },
                    { -262, true, -65, (byte)14, "user6", null },
                    { -263, true, -65, (byte)14, "user7", null },
                    { -264, true, -66, (byte)50, "user1", null },
                    { -265, true, -66, (byte)50, "user2", null },
                    { -266, true, -67, (byte)50, "user1", null },
                    { -267, true, -67, (byte)50, "user2", null },
                    { -268, true, -68, (byte)50, "user1", null },
                    { -269, true, -68, (byte)50, "user2", null },
                    { -270, true, -69, (byte)50, "user1", null },
                    { -271, true, -69, (byte)50, "user2", null },
                    { -256, true, -64, (byte)14, "user7", null },
                    { -255, true, -64, (byte)14, "user6", null },
                    { -254, true, -64, (byte)14, "user5", null },
                    { -253, true, -64, (byte)14, "user4", null },
                    { -237, true, -62, (byte)14, "user2", null },
                    { -238, true, -62, (byte)14, "user3", null },
                    { -239, true, -62, (byte)14, "user4", null },
                    { -240, true, -62, (byte)14, "user5", null },
                    { -241, true, -62, (byte)14, "user6", null },
                    { -242, true, -62, (byte)14, "user7", null },
                    { -243, true, -63, (byte)14, "user1", null },
                    { -272, true, -70, (byte)50, "user1", null },
                    { -244, true, -63, (byte)14, "user2", null },
                    { -246, true, -63, (byte)14, "user4", null },
                    { -247, true, -63, (byte)14, "user5", null },
                    { -248, true, -63, (byte)14, "user6", null },
                    { -249, true, -63, (byte)14, "user7", null },
                    { -250, true, -64, (byte)14, "user1", null },
                    { -251, true, -64, (byte)14, "user2", null },
                    { -252, true, -64, (byte)14, "user3", null },
                    { -245, true, -63, (byte)14, "user3", null },
                    { -236, true, -62, (byte)14, "user1", null },
                    { -273, true, -70, (byte)50, "user2", null },
                    { -275, true, -71, (byte)50, "user2", null },
                    { -296, true, -77, (byte)25, "user3", null },
                    { -297, true, -77, (byte)25, "user4", null },
                    { -298, true, -78, (byte)25, "user1", null },
                    { -299, true, -78, (byte)25, "user2", null },
                    { -300, true, -78, (byte)25, "user3", null },
                    { -301, true, -78, (byte)25, "user4", null },
                    { -302, true, -79, (byte)25, "user1", null },
                    { -303, true, -79, (byte)25, "user2", null },
                    { -304, true, -79, (byte)25, "user3", null },
                    { -305, true, -79, (byte)25, "user4", null },
                    { -306, true, -80, (byte)25, "user1", null },
                    { -307, true, -80, (byte)25, "user2", null },
                    { -308, true, -80, (byte)25, "user3", null },
                    { -309, true, -80, (byte)25, "user4", null },
                    { -310, true, -81, (byte)25, "user1", null },
                    { -295, true, -77, (byte)25, "user2", null },
                    { -294, true, -77, (byte)25, "user1", null },
                    { -293, true, -76, (byte)25, "user4", null },
                    { -292, true, -76, (byte)25, "user3", null },
                    { -276, true, -72, (byte)50, "user1", null },
                    { -277, true, -72, (byte)50, "user2", null },
                    { -278, true, -73, (byte)25, "user1", null },
                    { -279, true, -73, (byte)25, "user2", null },
                    { -280, true, -73, (byte)25, "user3", null },
                    { -281, true, -73, (byte)25, "user4", null },
                    { -282, true, -74, (byte)25, "user1", null },
                    { -274, true, -71, (byte)50, "user1", null },
                    { -283, true, -74, (byte)25, "user2", null },
                    { -285, true, -74, (byte)25, "user4", null },
                    { -286, true, -75, (byte)25, "user1", null },
                    { -287, true, -75, (byte)25, "user2", null },
                    { -288, true, -75, (byte)25, "user3", null },
                    { -289, true, -75, (byte)25, "user4", null },
                    { -290, true, -76, (byte)25, "user1", null },
                    { -291, true, -76, (byte)25, "user2", null },
                    { -284, true, -74, (byte)25, "user3", null },
                    { -235, true, -61, (byte)14, "user7", null },
                    { -234, true, -61, (byte)14, "user6", null },
                    { -233, true, -61, (byte)14, "user5", null },
                    { -178, true, -39, (byte)16, "user6", null },
                    { -179, true, -40, (byte)16, "user1", null },
                    { -180, true, -40, (byte)16, "user2", null },
                    { -181, true, -40, (byte)16, "user3", null },
                    { -182, true, -40, (byte)16, "user4", null },
                    { -183, true, -40, (byte)16, "user5", null },
                    { -184, true, -40, (byte)16, "user6", null },
                    { -185, true, -41, (byte)16, "user1", null },
                    { -186, true, -41, (byte)16, "user2", null },
                    { -187, true, -41, (byte)16, "user3", null },
                    { -188, true, -41, (byte)16, "user4", null },
                    { -189, true, -41, (byte)16, "user5", null },
                    { -190, true, -41, (byte)16, "user6", null },
                    { -191, true, -42, (byte)16, "user1", null },
                    { -192, true, -42, (byte)16, "user2", null },
                    { -177, true, -39, (byte)16, "user5", null },
                    { -176, true, -39, (byte)16, "user4", null },
                    { -175, true, -39, (byte)16, "user3", null },
                    { -174, true, -39, (byte)16, "user2", null },
                    { -158, true, -36, (byte)16, "user4", null },
                    { -159, true, -36, (byte)16, "user5", null },
                    { -160, true, -36, (byte)16, "user6", null },
                    { -161, true, -37, (byte)16, "user1", null },
                    { -162, true, -37, (byte)16, "user2", null },
                    { -163, true, -37, (byte)16, "user3", null },
                    { -164, true, -37, (byte)16, "user4", null },
                    { -193, true, -42, (byte)16, "user3", null },
                    { -165, true, -37, (byte)16, "user5", null },
                    { -167, true, -38, (byte)16, "user1", null },
                    { -168, true, -38, (byte)16, "user2", null },
                    { -169, true, -38, (byte)16, "user3", null },
                    { -170, true, -38, (byte)16, "user4", null },
                    { -171, true, -38, (byte)16, "user5", null },
                    { -172, true, -38, (byte)16, "user6", null },
                    { -173, true, -39, (byte)16, "user1", null },
                    { -166, true, -37, (byte)16, "user6", null },
                    { -194, true, -42, (byte)16, "user4", null },
                    { -195, true, -42, (byte)16, "user5", null },
                    { -196, true, -42, (byte)16, "user6", null },
                    { -217, true, -58, (byte)20, "user4", null },
                    { -218, true, -58, (byte)20, "user5", null },
                    { -219, true, -59, (byte)20, "user1", null },
                    { -220, true, -59, (byte)20, "user2", null },
                    { -221, true, -59, (byte)20, "user3", null },
                    { -222, true, -59, (byte)20, "user4", null },
                    { -223, true, -59, (byte)20, "user5", null },
                    { -216, true, -58, (byte)20, "user3", null },
                    { -224, true, -60, (byte)20, "user1", null },
                    { -226, true, -60, (byte)20, "user3", null },
                    { -227, true, -60, (byte)20, "user4", null },
                    { -228, true, -60, (byte)20, "user5", null },
                    { -229, true, -61, (byte)14, "user1", null },
                    { -230, true, -61, (byte)14, "user2", null },
                    { -231, true, -61, (byte)14, "user3", null },
                    { -232, true, -61, (byte)14, "user4", null },
                    { -225, true, -60, (byte)20, "user2", null },
                    { -623, true, -170, (byte)50, "user1", null },
                    { -215, true, -58, (byte)20, "user2", null },
                    { -213, true, -57, (byte)33, "user3", null },
                    { -197, true, -43, (byte)100, "user1", null },
                    { -198, true, -44, (byte)100, "user1", null },
                    { -199, true, -45, (byte)100, "user1", null },
                    { -200, true, -46, (byte)100, "user1", null },
                    { -201, true, -47, (byte)100, "user1", null },
                    { -202, true, -48, (byte)100, "user1", null },
                    { -203, true, -49, (byte)100, "user1", null },
                    { -214, true, -58, (byte)20, "user1", null },
                    { -204, true, -50, (byte)100, "user1", null },
                    { -206, true, -52, (byte)100, "user1", null },
                    { -207, true, -53, (byte)100, "user1", null },
                    { -208, true, -54, (byte)100, "user1", null },
                    { -209, true, -55, (byte)100, "user1", null },
                    { -210, true, -56, (byte)100, "user1", null },
                    { -211, true, -57, (byte)33, "user1", null },
                    { -212, true, -57, (byte)33, "user2", null },
                    { -205, true, -51, (byte)100, "user1", null },
                    { -624, true, -170, (byte)50, "user2", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_WagerId",
                table: "Challenges",
                column: "WagerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_DisplayName",
                table: "Profiles",
                column: "DisplayName",
                unique: true,
                filter: "[DisplayName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_GameName",
                table: "Rating",
                column: "GameName");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_GameName",
                table: "Results",
                column: "GameName");

            migrationBuilder.CreateIndex(
                name: "IX_WagerBids_UserId",
                table: "WagerBids",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WagerBids_WagerId",
                table: "WagerBids",
                column: "WagerId");

            migrationBuilder.CreateIndex(
                name: "IX_WagerBids_WagerResultId",
                table: "WagerBids",
                column: "WagerResultId");

            migrationBuilder.CreateIndex(
                name: "IX_WagerChallengeBid_ChallengeId",
                table: "WagerChallengeBid",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_WagerChallengeBid_UserId",
                table: "WagerChallengeBid",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wagers_GameName",
                table: "Wagers",
                column: "GameName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "WagerBids");

            migrationBuilder.DropTable(
                name: "WagerChallengeBid");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Wagers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
