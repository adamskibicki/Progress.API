using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddSkillsTierDescriptionsSkillVariables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SkillVariableId",
                table: "Stats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Enhanced = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CharacterClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_CharacterClasses_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategorySkill",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySkill", x => new { x.CategoriesId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_CategorySkill_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillVariables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseValue = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryCalculationType = table.Column<int>(type: "int", nullable: false),
                    BaseVariableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VariableCalculationType = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillVariables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillVariables_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TierDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TierDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TierDescriptions_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CharacterStatuses",
                keyColumn: "Id",
                keyValue: new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 4, 12, 27, 42, 453, DateTimeKind.Unspecified).AddTicks(4056), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: new Guid("047e7614-496d-4519-a784-6dec5e753571"),
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

            migrationBuilder.CreateIndex(
                name: "IX_Stats_SkillVariableId",
                table: "Stats",
                column: "SkillVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySkill_SkillsId",
                table: "CategorySkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CharacterClassId",
                table: "Skills",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillVariables_SkillId",
                table: "SkillVariables",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_TierDescriptions_SkillId",
                table: "TierDescriptions",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_SkillVariables_SkillVariableId",
                table: "Stats",
                column: "SkillVariableId",
                principalTable: "SkillVariables",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_SkillVariables_SkillVariableId",
                table: "Stats");

            migrationBuilder.DropTable(
                name: "CategorySkill");

            migrationBuilder.DropTable(
                name: "SkillVariables");

            migrationBuilder.DropTable(
                name: "TierDescriptions");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Stats_SkillVariableId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "SkillVariableId",
                table: "Stats");

            migrationBuilder.UpdateData(
                table: "CharacterStatuses",
                keyColumn: "Id",
                keyValue: new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 3, 30, 11, 13, 23, 254, DateTimeKind.Unspecified).AddTicks(910), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
