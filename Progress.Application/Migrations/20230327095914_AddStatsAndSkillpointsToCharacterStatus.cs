using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddStatsAndSkillpointsToCharacterStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnspentSkillpoints_CoreSkillpoints",
                table: "CharacterStatuses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnspentSkillpoints_FourthTierGeneralSkillpoints",
                table: "CharacterStatuses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnspentSkillpoints_FourthTierSkillpoints",
                table: "CharacterStatuses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnspentSkillpoints_ThirdTierGeneralSkillpoints",
                table: "CharacterStatuses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnspentStatpoints",
                table: "CharacterStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CharacterStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_CharacterStatuses_CharacterStatusId",
                        column: x => x.CharacterStatusId,
                        principalTable: "CharacterStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "CharacterStatuses",
                keyColumn: "Id",
                keyValue: new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                columns: new[] { "UnspentStatpoints", "UnspentSkillpoints_CoreSkillpoints", "UnspentSkillpoints_FourthTierGeneralSkillpoints", "UnspentSkillpoints_FourthTierSkillpoints", "UnspentSkillpoints_ThirdTierGeneralSkillpoints" },
                values: new object[] { 25, 10, 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "Stats",
                columns: new[] { "Id", "CharacterStatusId", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("047e7614-496d-4519-a784-6dec5e753571"), new Guid("afa42078-a071-4bea-978e-f439c713848c"), "Intelligence", 3770 },
                    { new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df"), new Guid("afa42078-a071-4bea-978e-f439c713848c"), "Vitality", 3800 },
                    { new Guid("20cce93e-f883-4860-be2f-4cdbd0c6e3be"), new Guid("afa42078-a071-4bea-978e-f439c713848c"), "Dexterity", 610 },
                    { new Guid("ab85915d-e66f-4460-96af-e90f171ccab5"), new Guid("afa42078-a071-4bea-978e-f439c713848c"), "Endurance", 600 },
                    { new Guid("c6474033-2e4c-4805-95f3-4fe22e9de88a"), new Guid("afa42078-a071-4bea-978e-f439c713848c"), "Wisdom", 4000 },
                    { new Guid("de4b423f-4718-4e26-9d75-14f4a1581b37"), new Guid("afa42078-a071-4bea-978e-f439c713848c"), "Strength", 860 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stats_CharacterStatusId",
                table: "Stats",
                column: "CharacterStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropColumn(
                name: "UnspentSkillpoints_CoreSkillpoints",
                table: "CharacterStatuses");

            migrationBuilder.DropColumn(
                name: "UnspentSkillpoints_FourthTierGeneralSkillpoints",
                table: "CharacterStatuses");

            migrationBuilder.DropColumn(
                name: "UnspentSkillpoints_FourthTierSkillpoints",
                table: "CharacterStatuses");

            migrationBuilder.DropColumn(
                name: "UnspentSkillpoints_ThirdTierGeneralSkillpoints",
                table: "CharacterStatuses");

            migrationBuilder.DropColumn(
                name: "UnspentStatpoints",
                table: "CharacterStatuses");
        }
    }
}
