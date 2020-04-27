using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Migrations
{
    public partial class Percents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "WagerChallengeBid");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "WagerBids");

            migrationBuilder.AddColumn<byte>(
                name: "PayablePt",
                table: "WagerChallengeBid",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ReceivablePt",
                table: "WagerChallengeBid",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "PayablePt",
                table: "WagerBids",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ReceivablePt",
                table: "WagerBids",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayablePt",
                table: "WagerChallengeBid");

            migrationBuilder.DropColumn(
                name: "ReceivablePt",
                table: "WagerChallengeBid");

            migrationBuilder.DropColumn(
                name: "PayablePt",
                table: "WagerBids");

            migrationBuilder.DropColumn(
                name: "ReceivablePt",
                table: "WagerBids");

            migrationBuilder.AddColumn<byte>(
                name: "Percentage",
                table: "WagerChallengeBid",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Percentage",
                table: "WagerBids",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
