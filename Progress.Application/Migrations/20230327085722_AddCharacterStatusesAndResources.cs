using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterStatusesAndResources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasicInformationName = table.Column<string>(name: "BasicInformation_Name", type: "nvarchar(max)", nullable: true),
                    BasicInformationTitle = table.Column<string>(name: "BasicInformation_Title", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalculationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseStatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourcePointsPerBaseStatPoint = table.Column<int>(type: "int", nullable: false),
                    CharacterStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_CharacterStatuses_CharacterStatusId",
                        column: x => x.CharacterStatusId,
                        principalTable: "CharacterStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"),
                column: "Name",
                value: "Fire Magic");

            migrationBuilder.InsertData(
                table: "CharacterStatuses",
                columns: new[] { "Id", "BasicInformation_Name", "BasicInformation_Title" },
                values: new object[] { new Guid("afa42078-a071-4bea-978e-f439c713848c"), "Ilea Spears", "Dragonslayer" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "BaseStatName", "CalculationName", "CharacterStatusId", "DisplayName", "ResourcePointsPerBaseStatPoint" },
                values: new object[,]
                {
                    { new Guid("70eaef56-21c1-494d-a0ba-312478c19428"), "Vitality", "Health", new Guid("afa42078-a071-4bea-978e-f439c713848c"), "Health", 10 },
                    { new Guid("741e7652-0c8e-4cb8-8ac4-b298637ae6c2"), "Vitality", "Health", new Guid("afa42078-a071-4bea-978e-f439c713848c"), "Mana (Essence)", 10 },
                    { new Guid("97f54c26-273e-47fc-b00f-7c5ad5b6cfae"), "Wisdom", "Mana", new Guid("afa42078-a071-4bea-978e-f439c713848c"), "Mana", 10 },
                    { new Guid("f8a10c54-df2b-4658-9e37-ff772a55aea3"), "Endurance", "Stamina", new Guid("afa42078-a071-4bea-978e-f439c713848c"), "Stamina", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_CharacterStatusId",
                table: "Resources",
                column: "CharacterStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "CharacterStatuses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"),
                column: "Name",
                value: "FireMagic");
        }
    }
}
