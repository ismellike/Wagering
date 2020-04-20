﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Migrations
{
    public partial class Approvable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Challenges",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Challenges");
        }
    }
}