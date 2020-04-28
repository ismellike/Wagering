using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Migrations
{
    public partial class Junctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_Wagers_WagerId",
                table: "Challenges");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerBids_AspNetUsers_UserId",
                table: "WagerBids");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerBids_Wagers_WagerId",
                table: "WagerBids");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerChallengeBid_Challenges_ChallengeId",
                table: "WagerChallengeBid");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerChallengeBid_AspNetUsers_UserId",
                table: "WagerChallengeBid");

            migrationBuilder.DropTable(
                name: "EventNotifications");

            migrationBuilder.DropTable(
                name: "PersonalNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WagerChallengeBid",
                table: "WagerChallengeBid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WagerBids",
                table: "WagerBids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Challenges",
                table: "Challenges");

            migrationBuilder.RenameTable(
                name: "WagerChallengeBid",
                newName: "WagerChallengeBids");

            migrationBuilder.RenameTable(
                name: "WagerBids",
                newName: "WagerHostBids");

            migrationBuilder.RenameTable(
                name: "Challenges",
                newName: "WagerChallenges");

            migrationBuilder.RenameIndex(
                name: "IX_WagerChallengeBid_UserId",
                table: "WagerChallengeBids",
                newName: "IX_WagerChallengeBids_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WagerChallengeBid_ChallengeId",
                table: "WagerChallengeBids",
                newName: "IX_WagerChallengeBids_ChallengeId");

            migrationBuilder.RenameIndex(
                name: "IX_WagerBids_WagerId",
                table: "WagerHostBids",
                newName: "IX_WagerHostBids_WagerId");

            migrationBuilder.RenameIndex(
                name: "IX_WagerBids_UserId",
                table: "WagerHostBids",
                newName: "IX_WagerHostBids_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Challenges_WagerId",
                table: "WagerChallenges",
                newName: "IX_WagerChallenges_WagerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WagerChallengeBids",
                table: "WagerChallengeBids",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WagerHostBids",
                table: "WagerHostBids",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WagerChallenges",
                table: "WagerChallenges",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WagerNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WagerId = table.Column<int>(nullable: false),
                    NotificationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WagerNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WagerNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WagerNotifications_Wagers_WagerId",
                        column: x => x.WagerId,
                        principalTable: "Wagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WagerRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RuleId = table.Column<int>(nullable: false),
                    WagerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WagerRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WagerRules_Rules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "Rules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WagerRules_Wagers_WagerId",
                        column: x => x.WagerId,
                        principalTable: "Wagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WagerNotifications_NotificationId",
                table: "WagerNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_WagerNotifications_WagerId",
                table: "WagerNotifications",
                column: "WagerId");

            migrationBuilder.CreateIndex(
                name: "IX_WagerRules_RuleId",
                table: "WagerRules",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_WagerRules_WagerId",
                table: "WagerRules",
                column: "WagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_WagerChallengeBids_WagerChallenges_ChallengeId",
                table: "WagerChallengeBids",
                column: "ChallengeId",
                principalTable: "WagerChallenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerChallengeBids_AspNetUsers_UserId",
                table: "WagerChallengeBids",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerChallenges_Wagers_WagerId",
                table: "WagerChallenges",
                column: "WagerId",
                principalTable: "Wagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerHostBids_AspNetUsers_UserId",
                table: "WagerHostBids",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerHostBids_Wagers_WagerId",
                table: "WagerHostBids",
                column: "WagerId",
                principalTable: "Wagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WagerChallengeBids_WagerChallenges_ChallengeId",
                table: "WagerChallengeBids");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerChallengeBids_AspNetUsers_UserId",
                table: "WagerChallengeBids");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerChallenges_Wagers_WagerId",
                table: "WagerChallenges");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerHostBids_AspNetUsers_UserId",
                table: "WagerHostBids");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerHostBids_Wagers_WagerId",
                table: "WagerHostBids");

            migrationBuilder.DropTable(
                name: "WagerNotifications");

            migrationBuilder.DropTable(
                name: "WagerRules");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WagerHostBids",
                table: "WagerHostBids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WagerChallenges",
                table: "WagerChallenges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WagerChallengeBids",
                table: "WagerChallengeBids");

            migrationBuilder.RenameTable(
                name: "WagerHostBids",
                newName: "WagerBids");

            migrationBuilder.RenameTable(
                name: "WagerChallenges",
                newName: "Challenges");

            migrationBuilder.RenameTable(
                name: "WagerChallengeBids",
                newName: "WagerChallengeBid");

            migrationBuilder.RenameIndex(
                name: "IX_WagerHostBids_WagerId",
                table: "WagerBids",
                newName: "IX_WagerBids_WagerId");

            migrationBuilder.RenameIndex(
                name: "IX_WagerHostBids_UserId",
                table: "WagerBids",
                newName: "IX_WagerBids_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WagerChallenges_WagerId",
                table: "Challenges",
                newName: "IX_Challenges_WagerId");

            migrationBuilder.RenameIndex(
                name: "IX_WagerChallengeBids_UserId",
                table: "WagerChallengeBid",
                newName: "IX_WagerChallengeBid_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WagerChallengeBids_ChallengeId",
                table: "WagerChallengeBid",
                newName: "IX_WagerChallengeBid_ChallengeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WagerBids",
                table: "WagerBids",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Challenges",
                table: "Challenges",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WagerChallengeBid",
                table: "WagerChallengeBid",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EventNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Message = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    TournamentId = table.Column<int>(type: "int", nullable: true),
                    WagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventNotifications_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventNotifications_Wagers_WagerId",
                        column: x => x.WagerId,
                        principalTable: "Wagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Link = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Message = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalNotifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventNotifications_TournamentId",
                table: "EventNotifications",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_EventNotifications_WagerId",
                table: "EventNotifications",
                column: "WagerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalNotifications_UserId",
                table: "PersonalNotifications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_Wagers_WagerId",
                table: "Challenges",
                column: "WagerId",
                principalTable: "Wagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerBids_AspNetUsers_UserId",
                table: "WagerBids",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerBids_Wagers_WagerId",
                table: "WagerBids",
                column: "WagerId",
                principalTable: "Wagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerChallengeBid_Challenges_ChallengeId",
                table: "WagerChallengeBid",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerChallengeBid_AspNetUsers_UserId",
                table: "WagerChallengeBid",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
