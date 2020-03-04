using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Migrations
{
    public partial class BidRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Profiles_UserDisplayName",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Wagers_WagerId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Results_WagerResultId",
                table: "Bids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bids",
                table: "Bids");

            migrationBuilder.RenameTable(
                name: "Bids",
                newName: "WagerBids");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_WagerResultId",
                table: "WagerBids",
                newName: "IX_WagerBids_WagerResultId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_WagerId",
                table: "WagerBids",
                newName: "IX_WagerBids_WagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_UserDisplayName",
                table: "WagerBids",
                newName: "IX_WagerBids_UserDisplayName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WagerBids",
                table: "WagerBids",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WagerBids_Profiles_UserDisplayName",
                table: "WagerBids",
                column: "UserDisplayName",
                principalTable: "Profiles",
                principalColumn: "DisplayName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerBids_Wagers_WagerId",
                table: "WagerBids",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WagerBids_Profiles_UserDisplayName",
                table: "WagerBids");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerBids_Wagers_WagerId",
                table: "WagerBids");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerBids_Results_WagerResultId",
                table: "WagerBids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WagerBids",
                table: "WagerBids");

            migrationBuilder.RenameTable(
                name: "WagerBids",
                newName: "Bids");

            migrationBuilder.RenameIndex(
                name: "IX_WagerBids_WagerResultId",
                table: "Bids",
                newName: "IX_Bids_WagerResultId");

            migrationBuilder.RenameIndex(
                name: "IX_WagerBids_WagerId",
                table: "Bids",
                newName: "IX_Bids_WagerId");

            migrationBuilder.RenameIndex(
                name: "IX_WagerBids_UserDisplayName",
                table: "Bids",
                newName: "IX_Bids_UserDisplayName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bids",
                table: "Bids",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Profiles_UserDisplayName",
                table: "Bids",
                column: "UserDisplayName",
                principalTable: "Profiles",
                principalColumn: "DisplayName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Wagers_WagerId",
                table: "Bids",
                column: "WagerId",
                principalTable: "Wagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Results_WagerResultId",
                table: "Bids",
                column: "WagerResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
