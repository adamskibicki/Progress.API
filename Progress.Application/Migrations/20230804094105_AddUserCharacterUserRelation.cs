using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddUserCharacterUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserCharacters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"), 0, "70ec409e-c520-475e-aa89-231640772a21", "test.test@test", false, false, null, null, "TEST", "AQAAAAEAACcQAAAAEMlxPlvWPhY0DOHtBATV2Hs8IBgYjxYUdNvpg7ILAoVnRDV+EKIUavJ6648huBlu2Q==", null, false, null, false, "test" });

            migrationBuilder.UpdateData(
                table: "UserCharacters",
                keyColumn: "Id",
                keyValue: new Guid("0da44e54-90ea-4ad0-a409-ea0cb1d38c4a"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.CreateIndex(
                name: "IX_UserCharacters_UserId",
                table: "UserCharacters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacters_AspNetUsers_UserId",
                table: "UserCharacters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacters_AspNetUsers_UserId",
                table: "UserCharacters");

            migrationBuilder.DropIndex(
                name: "IX_UserCharacters_UserId",
                table: "UserCharacters");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserCharacters");
        }
    }
}
