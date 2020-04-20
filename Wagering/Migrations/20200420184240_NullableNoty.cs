using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Migrations
{
    public partial class NullableNoty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventNotifications_Tournaments_TournamentId",
                table: "EventNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_EventNotifications_Wagers_WagerId",
                table: "EventNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerBids_Results_WagerResultId",
                table: "WagerBids");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropIndex(
                name: "IX_WagerBids_WagerResultId",
                table: "WagerBids");

            migrationBuilder.DropColumn(
                name: "WagerResultId",
                table: "WagerBids");

            migrationBuilder.AlterColumn<int>(
                name: "WagerId",
                table: "EventNotifications",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "EventNotifications",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EventNotifications_Tournaments_TournamentId",
                table: "EventNotifications",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventNotifications_Wagers_WagerId",
                table: "EventNotifications",
                column: "WagerId",
                principalTable: "Wagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventNotifications_Tournaments_TournamentId",
                table: "EventNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_EventNotifications_Wagers_WagerId",
                table: "EventNotifications");

            migrationBuilder.AddColumn<int>(
                name: "WagerResultId",
                table: "WagerBids",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WagerId",
                table: "EventNotifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "EventNotifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(24,18)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Result = table.Column<bool>(type: "bit", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_WagerBids_WagerResultId",
                table: "WagerBids",
                column: "WagerResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_GameName",
                table: "Results",
                column: "GameName");

            migrationBuilder.AddForeignKey(
                name: "FK_EventNotifications_Tournaments_TournamentId",
                table: "EventNotifications",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventNotifications_Wagers_WagerId",
                table: "EventNotifications",
                column: "WagerId",
                principalTable: "Wagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerBids_Results_WagerResultId",
                table: "WagerBids",
                column: "WagerResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
