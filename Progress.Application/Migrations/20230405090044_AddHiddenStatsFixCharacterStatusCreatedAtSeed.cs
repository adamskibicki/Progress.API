using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddHiddenStatsFixCharacterStatusCreatedAtSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_CharacterStatuses_CharacterStatusId",
                table: "Stats");

            migrationBuilder.AlterColumn<Guid>(
                name: "CharacterStatusId",
                table: "Stats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Stats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CharacterStatuses",
                keyColumn: "Id",
                keyValue: new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("047e7614-496d-4519-a784-6dec5e753571"),
                column: "IsHidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df"),
                column: "IsHidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("20cce93e-f883-4860-be2f-4cdbd0c6e3be"),
                column: "IsHidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("ab85915d-e66f-4460-96af-e90f171ccab5"),
                column: "IsHidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("c6474033-2e4c-4805-95f3-4fe22e9de88a"),
                column: "IsHidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("de4b423f-4718-4e26-9d75-14f4a1581b37"),
                column: "IsHidden",
                value: false);

            migrationBuilder.InsertData(
                table: "Stats",
                columns: new[] { "Id", "CharacterStatusId", "IsHidden", "Name", "SkillVariableId", "Value" },
                values: new object[,]
                {
                    { new Guid("170c68c3-2261-4063-9460-360144fb9597"), new Guid("afa42078-a071-4bea-978e-f439c713848c"), true, "Speed", null, 1 },
                    { new Guid("6c7beb1c-10bd-4e10-a019-82fb9c24115a"), new Guid("afa42078-a071-4bea-978e-f439c713848c"), true, "Reflexes", null, 1 },
                    { new Guid("ec4aaeb2-2caa-43f0-8c44-3c8374d0cb5d"), new Guid("afa42078-a071-4bea-978e-f439c713848c"), true, "Resilience", null, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_CharacterStatuses_CharacterStatusId",
                table: "Stats",
                column: "CharacterStatusId",
                principalTable: "CharacterStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_CharacterStatuses_CharacterStatusId",
                table: "Stats");

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("170c68c3-2261-4063-9460-360144fb9597"));

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("6c7beb1c-10bd-4e10-a019-82fb9c24115a"));

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("ec4aaeb2-2caa-43f0-8c44-3c8374d0cb5d"));

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Stats");

            migrationBuilder.AlterColumn<Guid>(
                name: "CharacterStatusId",
                table: "Stats",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "CharacterStatuses",
                keyColumn: "Id",
                keyValue: new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 4, 16, 34, 45, 327, DateTimeKind.Unspecified).AddTicks(7121), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_CharacterStatuses_CharacterStatusId",
                table: "Stats",
                column: "CharacterStatusId",
                principalTable: "CharacterStatuses",
                principalColumn: "Id");
        }
    }
}
