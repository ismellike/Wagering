using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Models.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileDisplayName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    DisplayName = table.Column<string>(maxLength: 20, nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    PublicKey = table.Column<string>(nullable: true),
                    Platform = table.Column<string>(nullable: true),
                    Input = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.DisplayName);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(nullable: false),
                    Result = table.Column<bool>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(24,18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wagers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(nullable: false),
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
                        name: "FK_Wagers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(nullable: false),
                    UserDisplayName = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    GamesPlayed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Profiles_UserDisplayName",
                        column: x => x.UserDisplayName,
                        principalTable: "Profiles",
                        principalColumn: "DisplayName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WagerId = table.Column<int>(nullable: false),
                    UserDisplayName = table.Column<string>(nullable: true),
                    Percentage = table.Column<byte>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    WagerResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Profiles_UserDisplayName",
                        column: x => x.UserDisplayName,
                        principalTable: "Profiles",
                        principalColumn: "DisplayName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bids_Wagers_WagerId",
                        column: x => x.WagerId,
                        principalTable: "Wagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Results_WagerResultId",
                        column: x => x.WagerResultId,
                        principalTable: "Results",
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
                    Amount = table.Column<decimal>(type: "decimal(18,7)", nullable: false)
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
                name: "WagerChallengeBid",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeId = table.Column<int>(nullable: false),
                    UserDisplayName = table.Column<string>(nullable: true),
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
                        name: "FK_WagerChallengeBid_Profiles_UserDisplayName",
                        column: x => x.UserDisplayName,
                        principalTable: "Profiles",
                        principalColumn: "DisplayName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileDisplayName",
                table: "AspNetUsers",
                column: "ProfileDisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_UserDisplayName",
                table: "Bids",
                column: "UserDisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_WagerId",
                table: "Bids",
                column: "WagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_WagerResultId",
                table: "Bids",
                column: "WagerResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_WagerId",
                table: "Challenges",
                column: "WagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_GameId",
                table: "Rating",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserDisplayName",
                table: "Rating",
                column: "UserDisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_Results_GameId",
                table: "Results",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_WagerChallengeBid_ChallengeId",
                table: "WagerChallengeBid",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_WagerChallengeBid_UserDisplayName",
                table: "WagerChallengeBid",
                column: "UserDisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_Wagers_GameId",
                table: "Wagers",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileDisplayName",
                table: "AspNetUsers",
                column: "ProfileDisplayName",
                principalTable: "Profiles",
                principalColumn: "DisplayName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileDisplayName",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "WagerChallengeBid");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Wagers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileDisplayName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileDisplayName",
                table: "AspNetUsers");
        }
    }
}
