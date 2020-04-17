using Microsoft.EntityFrameworkCore.Migrations;

namespace Wagering.Migrations
{
    public partial class ProfileDisplayName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "UserDisplayName",
                table: "WagerChallengeBid");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WagerChallengeBid");

            migrationBuilder.DropColumn(
                name: "UserDisplayName",
                table: "WagerBids");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WagerBids");

            migrationBuilder.DropColumn(
                name: "UserDisplayName",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rating");

            migrationBuilder.AddColumn<string>(
                name: "ProfileDisplayName",
                table: "WagerChallengeBid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "WagerChallengeBid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileDisplayName",
                table: "WagerBids",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "WagerBids",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileDisplayName",
                table: "Rating",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Rating",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -10,
                column: "ProfileDisplayName",
                value: "user9");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -9,
                column: "ProfileDisplayName",
                value: "user8");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -8,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -7,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -6,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -5,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -4,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -3,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -2,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -1,
                column: "ProfileDisplayName",
                value: "user0");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -198,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -197,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -196,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -195,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -194,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -193,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -192,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -191,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -190,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -189,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -188,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -187,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -186,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -185,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -184,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -183,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -182,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -181,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -180,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -179,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -178,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -177,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -176,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -175,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -174,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -173,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -172,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -171,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -170,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -169,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -168,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -167,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -166,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -165,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -164,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -163,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -162,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -161,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -160,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -159,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -158,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -157,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -156,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -155,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -154,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -153,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -152,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -151,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -150,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -149,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -148,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -147,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -146,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -145,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -144,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -143,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -142,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -141,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -140,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -139,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -138,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -137,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -136,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -135,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -134,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -133,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -132,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -131,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -130,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -129,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -128,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -127,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -126,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -125,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -124,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -123,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -122,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -121,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -120,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -119,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -118,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -117,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -116,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -115,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -114,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -113,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -112,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -111,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -110,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -109,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -108,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -107,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -106,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -105,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -104,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -103,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -102,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -101,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -100,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -99,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -98,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -97,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -96,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -95,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -94,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -93,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -92,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -91,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -90,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -89,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -88,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -87,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -86,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -85,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -84,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -83,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -82,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -81,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -80,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -79,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -78,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -77,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -76,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -75,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -74,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -73,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -72,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -71,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -70,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -69,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -68,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -67,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -66,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -65,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -64,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -63,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -62,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -61,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -60,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -59,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -58,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -57,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -56,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -55,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -54,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -53,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -52,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -51,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -50,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -49,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -48,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -47,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -46,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -45,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -44,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -43,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -42,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -41,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -40,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -39,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -38,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -37,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -36,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -35,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -34,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -33,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -32,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -31,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -30,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -29,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -28,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -27,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -26,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -25,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -24,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -23,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -22,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -21,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -20,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -19,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -18,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -17,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -16,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -15,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -14,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -13,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -12,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -11,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -10,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -9,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -8,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -7,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -6,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -5,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -4,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -3,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -2,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -1,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -624,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -623,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -622,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -621,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -620,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -619,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -618,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -617,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -616,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -615,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -614,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -613,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -612,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -611,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -610,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -609,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -608,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -607,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -606,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -605,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -604,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -603,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -602,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -601,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -600,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -599,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -598,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -597,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -596,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -595,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -594,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -593,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -592,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -591,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -590,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -589,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -588,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -587,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -586,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -585,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -584,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -583,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -582,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -581,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -580,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -579,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -578,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -577,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -576,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -575,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -574,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -573,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -572,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -571,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -570,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -569,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -568,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -567,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -566,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -565,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -564,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -563,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -562,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -561,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -560,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -559,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -558,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -557,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -556,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -555,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -554,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -553,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -552,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -551,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -550,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -549,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -548,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -547,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -546,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -545,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -544,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -543,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -542,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -541,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -540,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -539,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -538,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -537,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -536,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -535,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -534,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -533,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -532,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -531,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -530,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -529,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -528,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -527,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -526,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -525,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -524,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -523,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -522,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -521,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -520,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -519,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -518,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -517,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -516,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -515,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -514,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -513,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -512,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -511,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -510,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -509,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -508,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -507,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -506,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -505,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -504,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -503,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -502,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -501,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -500,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -499,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -498,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -497,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -496,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -495,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -494,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -493,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -492,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -491,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -490,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -489,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -488,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -487,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -486,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -485,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -484,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -483,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -482,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -481,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -480,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -479,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -478,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -477,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -476,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -475,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -474,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -473,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -472,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -471,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -470,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -469,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -468,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -467,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -466,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -465,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -464,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -463,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -462,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -461,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -460,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -459,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -458,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -457,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -456,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -455,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -454,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -453,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -452,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -451,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -450,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -449,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -448,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -447,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -446,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -445,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -444,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -443,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -442,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -441,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -440,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -439,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -438,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -437,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -436,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -435,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -434,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -433,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -432,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -431,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -430,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -429,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -428,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -427,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -426,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -425,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -424,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -423,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -422,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -421,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -420,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -419,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -418,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -417,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -416,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -415,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -414,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -413,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -412,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -411,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -410,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -409,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -408,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -407,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -406,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -405,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -404,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -403,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -402,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -401,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -400,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -399,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -398,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -397,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -396,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -395,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -394,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -393,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -392,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -391,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -390,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -389,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -388,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -387,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -386,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -385,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -384,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -383,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -382,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -381,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -380,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -379,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -378,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -377,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -376,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -375,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -374,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -373,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -372,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -371,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -370,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -369,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -368,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -367,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -366,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -365,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -364,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -363,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -362,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -361,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -360,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -359,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -358,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -357,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -356,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -355,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -354,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -353,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -352,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -351,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -350,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -349,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -348,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -347,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -346,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -345,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -344,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -343,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -342,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -341,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -340,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -339,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -338,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -337,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -336,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -335,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -334,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -333,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -332,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -331,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -330,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -329,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -328,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -327,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -326,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -325,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -324,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -323,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -322,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -321,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -320,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -319,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -318,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -317,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -316,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -315,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -314,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -313,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -312,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -311,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -310,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -309,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -308,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -307,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -306,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -305,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -304,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -303,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -302,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -301,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -300,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -299,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -298,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -297,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -296,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -295,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -294,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -293,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -292,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -291,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -290,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -289,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -288,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -287,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -286,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -285,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -284,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -283,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -282,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -281,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -280,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -279,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -278,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -277,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -276,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -275,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -274,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -273,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -272,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -271,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -270,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -269,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -268,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -267,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -266,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -265,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -264,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -263,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -262,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -261,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -260,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -259,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -258,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -257,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -256,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -255,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -254,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -253,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -252,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -251,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -250,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -249,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -248,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -247,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -246,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -245,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -244,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -243,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -242,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -241,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -240,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -239,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -238,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -237,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -236,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -235,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -234,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -233,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -232,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -231,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -230,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -229,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -228,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -227,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -226,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -225,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -224,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -223,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -222,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -221,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -220,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -219,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -218,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -217,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -216,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -215,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -214,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -213,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -212,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -211,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -210,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -209,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -208,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -207,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -206,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -205,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -204,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -203,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -202,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -201,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -200,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -199,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -198,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -197,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -196,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -195,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -194,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -193,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -192,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -191,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -190,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -189,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -188,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -187,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -186,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -185,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -184,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -183,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -182,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -181,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -180,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -179,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -178,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -177,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -176,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -175,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -174,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -173,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -172,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -171,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -170,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -169,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -168,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -167,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -166,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -165,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -164,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -163,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -162,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -161,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -160,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -159,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -158,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -157,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -156,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -155,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -154,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -153,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -152,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -151,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -150,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -149,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -148,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -147,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -146,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -145,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -144,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -143,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -142,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -141,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -140,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -139,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -138,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -137,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -136,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -135,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -134,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -133,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -132,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -131,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -130,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -129,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -128,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -127,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -126,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -125,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -124,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -123,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -122,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -121,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -120,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -119,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -118,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -117,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -116,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -115,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -114,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -113,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -112,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -111,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -110,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -109,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -108,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -107,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -106,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -105,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -104,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -103,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -102,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -101,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -100,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -99,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -98,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -97,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -96,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -95,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -94,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -93,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -92,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -91,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -90,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -89,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -88,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -87,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -86,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -85,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -84,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -83,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -82,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -81,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -80,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -79,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -78,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -77,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -76,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -75,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -74,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -73,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -72,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -71,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -70,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -69,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -68,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -67,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -66,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -65,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -64,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -63,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -62,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -61,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -60,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -59,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -58,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -57,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -56,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -55,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -54,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -53,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -52,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -51,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -50,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -49,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -48,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -47,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -46,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -45,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -44,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -43,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -42,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -41,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -40,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -39,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -38,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -37,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -36,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -35,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -34,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -33,
                column: "ProfileDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -32,
                column: "ProfileDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -31,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -30,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -29,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -28,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -27,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -26,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -25,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -24,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -23,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -22,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -21,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -20,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -19,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -18,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -17,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -16,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -15,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -14,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -13,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -12,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -11,
                column: "ProfileDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -10,
                column: "ProfileDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -9,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -8,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -7,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -6,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -5,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -4,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -3,
                column: "ProfileDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -2,
                column: "ProfileDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -1,
                column: "ProfileDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -50,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -49,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -48,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -47,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -46,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -45,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -44,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -43,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -42,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -41,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -40,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -39,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -38,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -37,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -36,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -35,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -34,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -33,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -32,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -31,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -30,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -29,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -28,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -27,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -26,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -25,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -24,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -23,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -22,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -21,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -20,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -19,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -18,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -17,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -16,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -15,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -14,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -13,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -12,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -11,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -10,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -9,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -8,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -7,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -6,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -5,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -4,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -3,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -2,
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -1,
                column: "Status",
                value: (byte)1);

            migrationBuilder.CreateIndex(
                name: "IX_WagerChallengeBid_ProfileId",
                table: "WagerChallengeBid",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_WagerBids_ProfileId",
                table: "WagerBids",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ProfileId",
                table: "Rating",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Profiles_ProfileId",
                table: "Rating",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerBids_Profiles_ProfileId",
                table: "WagerBids",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WagerChallengeBid_Profiles_ProfileId",
                table: "WagerChallengeBid",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Profiles_ProfileId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerBids_Profiles_ProfileId",
                table: "WagerBids");

            migrationBuilder.DropForeignKey(
                name: "FK_WagerChallengeBid_Profiles_ProfileId",
                table: "WagerChallengeBid");

            migrationBuilder.DropIndex(
                name: "IX_WagerChallengeBid_ProfileId",
                table: "WagerChallengeBid");

            migrationBuilder.DropIndex(
                name: "IX_WagerBids_ProfileId",
                table: "WagerBids");

            migrationBuilder.DropIndex(
                name: "IX_Rating_ProfileId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "ProfileDisplayName",
                table: "WagerChallengeBid");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "WagerChallengeBid");

            migrationBuilder.DropColumn(
                name: "ProfileDisplayName",
                table: "WagerBids");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "WagerBids");

            migrationBuilder.DropColumn(
                name: "ProfileDisplayName",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Rating");

            migrationBuilder.AddColumn<string>(
                name: "UserDisplayName",
                table: "WagerChallengeBid",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WagerChallengeBid",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserDisplayName",
                table: "WagerBids",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WagerBids",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserDisplayName",
                table: "Rating",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Rating",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -10,
                column: "UserDisplayName",
                value: "user9");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -9,
                column: "UserDisplayName",
                value: "user8");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -8,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -7,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -6,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -5,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -4,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -3,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -2,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: -1,
                column: "UserDisplayName",
                value: "user0");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -198,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -197,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -196,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -195,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -194,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -193,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -192,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -191,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -190,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -189,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -188,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -187,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -186,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -185,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -184,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -183,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -182,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -181,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -180,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -179,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -178,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -177,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -176,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -175,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -174,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -173,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -172,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -171,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -170,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -169,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -168,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -167,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -166,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -165,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -164,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -163,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -162,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -161,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -160,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -159,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -158,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -157,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -156,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -155,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -154,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -153,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -152,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -151,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -150,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -149,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -148,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -147,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -146,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -145,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -144,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -143,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -142,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -141,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -140,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -139,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -138,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -137,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -136,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -135,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -134,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -133,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -132,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -131,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -130,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -129,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -128,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -127,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -126,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -125,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -124,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -123,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -122,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -121,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -120,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -119,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -118,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -117,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -116,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -115,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -114,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -113,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -112,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -111,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -110,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -109,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -108,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -107,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -106,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -105,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -104,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -103,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -102,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -101,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -100,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -99,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -98,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -97,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -96,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -95,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -94,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -93,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -92,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -91,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -90,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -89,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -88,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -87,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -86,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -85,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -84,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -83,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -82,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -81,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -80,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -79,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -78,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -77,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -76,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -75,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -74,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -73,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -72,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -71,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -70,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -69,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -68,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -67,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -66,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -65,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -64,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -63,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -62,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -61,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -60,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -59,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -58,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -57,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -56,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -55,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -54,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -53,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -52,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -51,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -50,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -49,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -48,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -47,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -46,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -45,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -44,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -43,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -42,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -41,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -40,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -39,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -38,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -37,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -36,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -35,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -34,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -33,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -32,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -31,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -30,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -29,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -28,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -27,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -26,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -25,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -24,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -23,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -22,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -21,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -20,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -19,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -18,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -17,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -16,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -15,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -14,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -13,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -12,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -11,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -10,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -9,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -8,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -7,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -6,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -5,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -4,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -3,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -2,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerBids",
                keyColumn: "Id",
                keyValue: -1,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -624,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -623,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -622,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -621,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -620,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -619,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -618,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -617,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -616,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -615,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -614,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -613,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -612,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -611,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -610,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -609,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -608,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -607,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -606,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -605,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -604,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -603,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -602,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -601,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -600,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -599,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -598,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -597,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -596,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -595,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -594,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -593,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -592,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -591,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -590,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -589,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -588,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -587,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -586,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -585,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -584,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -583,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -582,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -581,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -580,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -579,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -578,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -577,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -576,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -575,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -574,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -573,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -572,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -571,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -570,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -569,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -568,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -567,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -566,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -565,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -564,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -563,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -562,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -561,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -560,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -559,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -558,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -557,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -556,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -555,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -554,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -553,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -552,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -551,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -550,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -549,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -548,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -547,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -546,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -545,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -544,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -543,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -542,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -541,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -540,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -539,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -538,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -537,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -536,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -535,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -534,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -533,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -532,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -531,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -530,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -529,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -528,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -527,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -526,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -525,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -524,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -523,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -522,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -521,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -520,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -519,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -518,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -517,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -516,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -515,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -514,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -513,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -512,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -511,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -510,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -509,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -508,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -507,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -506,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -505,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -504,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -503,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -502,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -501,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -500,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -499,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -498,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -497,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -496,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -495,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -494,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -493,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -492,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -491,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -490,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -489,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -488,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -487,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -486,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -485,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -484,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -483,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -482,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -481,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -480,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -479,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -478,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -477,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -476,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -475,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -474,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -473,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -472,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -471,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -470,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -469,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -468,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -467,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -466,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -465,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -464,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -463,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -462,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -461,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -460,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -459,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -458,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -457,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -456,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -455,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -454,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -453,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -452,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -451,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -450,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -449,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -448,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -447,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -446,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -445,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -444,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -443,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -442,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -441,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -440,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -439,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -438,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -437,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -436,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -435,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -434,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -433,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -432,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -431,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -430,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -429,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -428,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -427,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -426,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -425,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -424,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -423,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -422,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -421,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -420,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -419,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -418,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -417,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -416,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -415,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -414,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -413,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -412,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -411,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -410,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -409,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -408,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -407,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -406,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -405,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -404,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -403,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -402,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -401,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -400,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -399,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -398,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -397,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -396,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -395,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -394,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -393,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -392,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -391,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -390,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -389,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -388,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -387,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -386,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -385,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -384,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -383,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -382,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -381,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -380,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -379,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -378,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -377,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -376,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -375,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -374,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -373,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -372,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -371,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -370,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -369,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -368,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -367,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -366,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -365,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -364,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -363,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -362,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -361,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -360,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -359,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -358,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -357,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -356,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -355,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -354,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -353,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -352,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -351,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -350,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -349,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -348,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -347,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -346,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -345,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -344,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -343,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -342,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -341,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -340,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -339,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -338,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -337,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -336,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -335,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -334,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -333,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -332,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -331,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -330,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -329,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -328,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -327,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -326,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -325,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -324,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -323,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -322,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -321,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -320,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -319,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -318,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -317,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -316,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -315,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -314,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -313,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -312,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -311,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -310,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -309,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -308,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -307,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -306,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -305,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -304,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -303,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -302,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -301,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -300,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -299,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -298,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -297,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -296,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -295,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -294,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -293,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -292,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -291,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -290,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -289,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -288,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -287,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -286,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -285,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -284,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -283,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -282,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -281,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -280,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -279,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -278,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -277,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -276,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -275,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -274,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -273,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -272,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -271,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -270,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -269,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -268,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -267,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -266,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -265,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -264,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -263,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -262,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -261,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -260,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -259,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -258,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -257,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -256,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -255,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -254,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -253,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -252,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -251,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -250,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -249,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -248,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -247,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -246,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -245,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -244,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -243,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -242,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -241,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -240,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -239,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -238,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -237,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -236,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -235,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -234,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -233,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -232,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -231,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -230,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -229,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -228,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -227,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -226,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -225,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -224,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -223,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -222,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -221,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -220,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -219,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -218,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -217,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -216,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -215,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -214,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -213,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -212,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -211,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -210,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -209,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -208,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -207,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -206,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -205,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -204,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -203,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -202,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -201,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -200,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -199,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -198,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -197,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -196,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -195,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -194,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -193,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -192,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -191,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -190,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -189,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -188,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -187,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -186,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -185,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -184,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -183,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -182,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -181,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -180,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -179,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -178,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -177,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -176,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -175,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -174,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -173,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -172,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -171,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -170,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -169,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -168,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -167,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -166,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -165,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -164,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -163,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -162,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -161,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -160,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -159,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -158,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -157,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -156,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -155,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -154,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -153,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -152,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -151,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -150,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -149,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -148,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -147,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -146,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -145,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -144,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -143,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -142,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -141,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -140,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -139,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -138,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -137,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -136,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -135,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -134,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -133,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -132,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -131,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -130,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -129,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -128,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -127,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -126,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -125,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -124,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -123,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -122,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -121,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -120,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -119,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -118,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -117,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -116,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -115,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -114,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -113,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -112,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -111,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -110,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -109,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -108,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -107,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -106,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -105,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -104,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -103,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -102,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -101,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -100,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -99,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -98,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -97,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -96,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -95,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -94,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -93,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -92,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -91,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -90,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -89,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -88,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -87,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -86,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -85,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -84,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -83,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -82,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -81,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -80,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -79,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -78,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -77,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -76,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -75,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -74,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -73,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -72,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -71,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -70,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -69,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -68,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -67,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -66,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -65,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -64,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -63,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -62,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -61,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -60,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -59,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -58,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -57,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -56,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -55,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -54,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -53,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -52,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -51,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -50,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -49,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -48,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -47,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -46,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -45,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -44,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -43,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -42,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -41,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -40,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -39,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -38,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -37,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -36,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -35,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -34,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -33,
                column: "UserDisplayName",
                value: "user7");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -32,
                column: "UserDisplayName",
                value: "user6");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -31,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -30,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -29,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -28,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -27,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -26,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -25,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -24,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -23,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -22,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -21,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -20,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -19,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -18,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -17,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -16,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -15,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -14,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -13,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -12,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -11,
                column: "UserDisplayName",
                value: "user5");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -10,
                column: "UserDisplayName",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -9,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -8,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -7,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -6,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -5,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -4,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -3,
                column: "UserDisplayName",
                value: "user3");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -2,
                column: "UserDisplayName",
                value: "user2");

            migrationBuilder.UpdateData(
                table: "WagerChallengeBid",
                keyColumn: "Id",
                keyValue: -1,
                column: "UserDisplayName",
                value: "user1");

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -50,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -49,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -48,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -47,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -46,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -45,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -44,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -43,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -42,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -41,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -40,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -39,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -38,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -37,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -36,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -35,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -34,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -33,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -32,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -31,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -30,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -29,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -28,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -27,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -26,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -25,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -24,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -23,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -22,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -21,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -20,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -19,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -18,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -17,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -16,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -15,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -14,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -13,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -12,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -11,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -10,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -9,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -8,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -7,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -6,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -5,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -4,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -3,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -2,
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Wagers",
                keyColumn: "Id",
                keyValue: -1,
                column: "Status",
                value: (byte)0);

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
    }
}
