using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Migrations
{
    public partial class UserUsrename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserUserName",
                table: "WagerChallengeBid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserUserName",
                table: "WagerBids",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserUserName",
                table: "WagerChallengeBid");

            migrationBuilder.DropColumn(
                name: "UserUserName",
                table: "WagerBids");
        }
    }
}
