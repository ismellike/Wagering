using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Migrations
{
    public partial class ProfileRestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileDisplayName",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Profiles_UserDisplayName",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerBids_Profiles_UserDisplayName",
                table: "WagerBids");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerChallengeBid_Profiles_UserDisplayName",
                table: "WagerChallengeBid");

            migrationBuilder.DropIndex(
                name: "IX_WagerChallengeBid_UserDisplayName",
                table: "WagerChallengeBid");

            migrationBuilder.DropIndex(
                name: "IX_WagerBids_UserDisplayName",
                table: "WagerBids");

            migrationBuilder.DropIndex(
                name: "IX_Rating_UserDisplayName",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileDisplayName",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "DisplayName",
                keyValue: "user0");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "DisplayName",
                keyValue: "user1");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "DisplayName",
                keyValue: "user2");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "DisplayName",
                keyValue: "user3");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "DisplayName",
                keyValue: "user4");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "DisplayName",
                keyValue: "user5");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "DisplayName",
                keyValue: "user6");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "DisplayName",
                keyValue: "user7");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "DisplayName",
                keyValue: "user8");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "DisplayName",
                keyValue: "user9");

            migrationBuilder.DropColumn(
                name: "ProfileDisplayName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserDisplayName",
                table: "WagerChallengeBid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WagerChallengeBid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserDisplayName",
                table: "WagerBids",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WagerBids",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserDisplayName",
                table: "Rating",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Rating",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Profiles",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Profiles",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "DisplayName", "Input", "IsVerified", "Platform", "PublicKey", "UserId" },
                values: new object[,]
                {
                    { -1, "user0", null, false, null, "0FF8A9FU328JF8A9SJF8923", null },
                    { -2, "user1", null, false, null, "1FF8A9FU328JF8A9SJF8923", null },
                    { -3, "user2", null, false, null, "2FF8A9FU328JF8A9SJF8923", null },
                    { -4, "user3", null, false, null, "3FF8A9FU328JF8A9SJF8923", null },
                    { -5, "user4", null, false, null, "4FF8A9FU328JF8A9SJF8923", null },
                    { -6, "user5", null, false, null, "5FF8A9FU328JF8A9SJF8923", null },
                    { -7, "user6", null, false, null, "6FF8A9FU328JF8A9SJF8923", null },
                    { -8, "user7", null, false, null, "7FF8A9FU328JF8A9SJF8923", null },
                    { -9, "user8", null, false, null, "8FF8A9FU328JF8A9SJF8923", null },
                    { -10, "user9", null, false, null, "9FF8A9FU328JF8A9SJF8923", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileId",
                value: -1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileId",
                value: -2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileId",
                value: -3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileId",
                value: -4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileId",
                value: -5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileId",
                value: -6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileId",
                value: -7);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileId",
                value: -8);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileId",
                value: -9);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileId",
                value: -10);

            migrationBuilder.CreateIndex(
                name: "IX_WagerChallengeBid_UserId",
                table: "WagerChallengeBid",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WagerBids_UserId",
                table: "WagerBids",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_DisplayName",
                table: "Profiles",
                column: "DisplayName",
                unique: true,
                filter: "[DisplayName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Profiles_UserId",
                table: "Rating",
                column: "UserId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerBids_Profiles_UserId",
                table: "WagerBids",
                column: "UserId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerChallengeBid_Profiles_UserId",
                table: "WagerChallengeBid",
                column: "UserId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Profiles_UserId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerBids_Profiles_UserId",
                table: "WagerBids");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerChallengeBid_Profiles_UserId",
                table: "WagerChallengeBid");

            migrationBuilder.DropIndex(
                name: "IX_WagerChallengeBid_UserId",
                table: "WagerChallengeBid");

            migrationBuilder.DropIndex(
                name: "IX_WagerBids_UserId",
                table: "WagerBids");

            migrationBuilder.DropIndex(
                name: "IX_Rating_UserId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_DisplayName",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WagerChallengeBid");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WagerBids");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserDisplayName",
                table: "WagerChallengeBid",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserDisplayName",
                table: "WagerBids",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserDisplayName",
                table: "Rating",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Profiles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileDisplayName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "DisplayName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileDisplayName",
                value: "user0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileDisplayName",
                value: "user8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9AAAAAAAAAAAAAAAAAAAAAAAAA",
                column: "ProfileDisplayName",
                value: "user9");

            migrationBuilder.CreateIndex(
                name: "IX_WagerChallengeBid_UserDisplayName",
                table: "WagerChallengeBid",
                column: "UserDisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_WagerBids_UserDisplayName",
                table: "WagerBids",
                column: "UserDisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserDisplayName",
                table: "Rating",
                column: "UserDisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileDisplayName",
                table: "AspNetUsers",
                column: "ProfileDisplayName");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileDisplayName",
                table: "AspNetUsers",
                column: "ProfileDisplayName",
                principalTable: "Profiles",
                principalColumn: "DisplayName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Profiles_UserDisplayName",
                table: "Rating",
                column: "UserDisplayName",
                principalTable: "Profiles",
                principalColumn: "DisplayName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerBids_Profiles_UserDisplayName",
                table: "WagerBids",
                column: "UserDisplayName",
                principalTable: "Profiles",
                principalColumn: "DisplayName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerChallengeBid_Profiles_UserDisplayName",
                table: "WagerChallengeBid",
                column: "UserDisplayName",
                principalTable: "Profiles",
                principalColumn: "DisplayName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
