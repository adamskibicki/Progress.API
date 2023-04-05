using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationshipBetweenStatAndSkillVariable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_SkillVariables_SkillVariableId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_SkillVariableId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "SkillVariableId",
                table: "Stats");

            migrationBuilder.CreateTable(
                name: "SkillVariableStats",
                columns: table => new
                {
                    StatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillVariableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillVariableStats", x => new { x.StatId, x.SkillVariableId });
                    table.ForeignKey(
                        name: "FK_SkillVariableStats_SkillVariables_SkillVariableId",
                        column: x => x.SkillVariableId,
                        principalTable: "SkillVariables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkillVariableStats_Stats_StatId",
                        column: x => x.StatId,
                        principalTable: "Stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillVariableStats_SkillVariableId",
                table: "SkillVariableStats",
                column: "SkillVariableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillVariableStats");

            migrationBuilder.AddColumn<Guid>(
                name: "SkillVariableId",
                table: "Stats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("047e7614-496d-4519-a784-6dec5e753571"),
                column: "SkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("170c68c3-2261-4063-9460-360144fb9597"),
                column: "SkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df"),
                column: "SkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("20cce93e-f883-4860-be2f-4cdbd0c6e3be"),
                column: "SkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("6c7beb1c-10bd-4e10-a019-82fb9c24115a"),
                column: "SkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("ab85915d-e66f-4460-96af-e90f171ccab5"),
                column: "SkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("c6474033-2e4c-4805-95f3-4fe22e9de88a"),
                column: "SkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("de4b423f-4718-4e26-9d75-14f4a1581b37"),
                column: "SkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("ec4aaeb2-2caa-43f0-8c44-3c8374d0cb5d"),
                column: "SkillVariableId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_SkillVariableId",
                table: "Stats",
                column: "SkillVariableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_SkillVariables_SkillVariableId",
                table: "Stats",
                column: "SkillVariableId",
                principalTable: "SkillVariables",
                principalColumn: "Id");
        }
    }
}
