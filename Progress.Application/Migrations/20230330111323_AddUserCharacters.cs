using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddUserCharacters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "CharacterStatuses",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UserCharacterId",
                table: "CharacterStatuses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserCharacters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCharacters", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CharacterStatuses",
                keyColumn: "Id",
                keyValue: new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                columns: new[] { "CreatedAt", "UserCharacterId" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 3, 30, 11, 13, 23, 254, DateTimeKind.Unspecified).AddTicks(910), new TimeSpan(0, 0, 0, 0, 0)), new Guid("0da44e54-90ea-4ad0-a409-ea0cb1d38c4a") });

            migrationBuilder.InsertData(
                table: "UserCharacters",
                column: "Id",
                value: new Guid("0da44e54-90ea-4ad0-a409-ea0cb1d38c4a"));

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStatuses_UserCharacterId",
                table: "CharacterStatuses",
                column: "UserCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStatuses_UserCharacters_UserCharacterId",
                table: "CharacterStatuses",
                column: "UserCharacterId",
                principalTable: "UserCharacters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStatuses_UserCharacters_UserCharacterId",
                table: "CharacterStatuses");

            migrationBuilder.DropTable(
                name: "UserCharacters");

            migrationBuilder.DropIndex(
                name: "IX_CharacterStatuses_UserCharacterId",
                table: "CharacterStatuses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CharacterStatuses");

            migrationBuilder.DropColumn(
                name: "UserCharacterId",
                table: "CharacterStatuses");
        }
    }
}
