using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Migrations
{
    public partial class Private : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Wagers");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Wagers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Wagers");

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Wagers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
