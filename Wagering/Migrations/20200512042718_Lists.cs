using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Migrations
{
    public partial class Lists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connection_Profiles_ProfileId",
                table: "Connection");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Games_GameId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Profiles_ProfileId1",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Connection",
                table: "Connection");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "Connection",
                newName: "Connections");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_ProfileId1",
                table: "Ratings",
                newName: "IX_Ratings_ProfileId1");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_GameId",
                table: "Ratings",
                newName: "IX_Ratings_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Connection_ProfileId",
                table: "Connections",
                newName: "IX_Connections_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Connections",
                table: "Connections",
                column: "ConnectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Profiles_ProfileId",
                table: "Connections",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Games_GameId",
                table: "Ratings",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Profiles_ProfileId1",
                table: "Ratings",
                column: "ProfileId1",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Profiles_ProfileId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Games_GameId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Profiles_ProfileId1",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Connections",
                table: "Connections");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameTable(
                name: "Connections",
                newName: "Connection");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_ProfileId1",
                table: "Rating",
                newName: "IX_Rating_ProfileId1");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_GameId",
                table: "Rating",
                newName: "IX_Rating_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Connections_ProfileId",
                table: "Connection",
                newName: "IX_Connection_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Connection",
                table: "Connection",
                column: "ConnectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Connection_Profiles_ProfileId",
                table: "Connection",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Games_GameId",
                table: "Rating",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Profiles_ProfileId1",
                table: "Rating",
                column: "ProfileId1",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
