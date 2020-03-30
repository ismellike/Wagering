using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Migrations
{
    public partial class IsOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "WagerChallengeBid",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "WagerBids",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "WagerChallengeBid");

            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "WagerBids");
        }
    }
}
