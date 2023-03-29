using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class ChangedResourceToUseRelationsInsteadOfNamesAndAddCharacterClassWithModifiers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseStatName",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "CalculationName",
                table: "Resources");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseStatId",
                table: "Resources",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassModifiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PercentagePointsOfCategoryIncrease = table.Column<int>(type: "int", nullable: false),
                    CategoryCalculationType = table.Column<int>(type: "int", nullable: false),
                    AffectedResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassModifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassModifiers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClassModifiers_CharacterClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassModifiers_Resources_AffectedResourceId",
                        column: x => x.AffectedResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CharacterClasses",
                columns: new[] { "Id", "Level", "Name" },
                values: new object[,]
                {
                    { new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), 1001, "The Pyroclastic Storm" },
                    { new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), 1002, "The Sunforged Realmwalker" },
                    { new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), 1004, "The Cosmic Immortal" }
                });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("70eaef56-21c1-494d-a0ba-312478c19428"),
                column: "BaseStatId",
                value: new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df"));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("741e7652-0c8e-4cb8-8ac4-b298637ae6c2"),
                column: "BaseStatId",
                value: new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df"));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("97f54c26-273e-47fc-b00f-7c5ad5b6cfae"),
                column: "BaseStatId",
                value: new Guid("c6474033-2e4c-4805-95f3-4fe22e9de88a"));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("f8a10c54-df2b-4658-9e37-ff772a55aea3"),
                column: "BaseStatId",
                value: new Guid("ab85915d-e66f-4460-96af-e90f171ccab5"));

            migrationBuilder.InsertData(
                table: "ClassModifiers",
                columns: new[] { "Id", "AffectedResourceId", "CategoryCalculationType", "CategoryId", "ClassId", "Description", "PercentagePointsOfCategoryIncrease" },
                values: new object[,]
                {
                    { new Guid("09e97cee-34b2-4aea-9b47-b7160339de10"), null, 0, null, new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Resilience is increased by 500%", 0 },
                    { new Guid("1382a487-16d5-4356-b1a2-a391cbaa7f53"), null, 0, null, new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), "You cannot be stunned by enemy attacks", 0 },
                    { new Guid("1d2154a7-a236-4afa-b9cc-5f913c5a6468"), null, 0, null, new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), "You may infuse any barrier, wall, or magical armor with cosmic energy", 0 },
                    { new Guid("20ac1928-5cff-4504-a926-e253c38891d8"), null, 0, new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), "Body enhancement magic is improved by 500%", 500 },
                    { new Guid("2218f3c7-591f-40eb-9f48-38b4f958440d"), new Guid("97f54c26-273e-47fc-b00f-7c5ad5b6cfae"), 4, null, new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), "Your mana capacity is multiplied by five", 500 },
                    { new Guid("268eb8e9-5be0-4d4d-b29d-0ce1f6bcacca"), null, 0, null, new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), "Your will is ash and heat", 0 },
                    { new Guid("26d1fd63-e8ce-47ff-9587-b43948baf4d5"), null, 0, null, new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), "Natural health regeneration is increased by 1% per minute", 0 },
                    { new Guid("29185439-b3d7-4648-847d-7709cb46faa1"), null, 0, null, new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), "Your heat generation is increased by 1000%", 0 },
                    { new Guid("2af0ee40-2ea0-4b2c-abc6-22a15b37fb19"), null, 0, new Guid("4538069f-9680-4b26-84a4-e608d1c86606"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Mind Magic is improved by 100%", 100 },
                    { new Guid("2cc5563c-4e6f-4785-9d7a-f334fc6600aa"), null, 0, new Guid("94cb02e4-43dc-4021-95ac-d9d5bc6512d6"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Lava Magic is improved by 100%", 100 },
                    { new Guid("4a356fc3-234a-4e1e-9091-210132ff23d1"), null, 0, null, new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), "You can absorb and use 25% of the ambient mana around you", 0 },
                    { new Guid("5274cf3c-f1cb-4fc8-8175-8f202d7d47c3"), null, 0, null, new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), "Excess generated mana instead charges a second mana pool equaling your total health [0/125400]. Mana from this pool can be transferred into your main mana pool at will", 0 },
                    { new Guid("53b6d5e7-cd28-45a4-a7c8-72cc361b8e9b"), null, 0, new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Fire Magic is improved by 200%", 200 },
                    { new Guid("6c72a67a-beff-4d01-a746-3350677d2832"), null, 0, new Guid("11751928-c2d3-4939-9692-05f578af3d00"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Earth Magic is improved by 100%", 100 },
                    { new Guid("6d66a14d-e883-4704-bc2d-8acbfbefecad"), null, 0, null, new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), "Food, water and sleep needed to sustain yourself are no longer required", 0 },
                    { new Guid("6db597af-34bb-4660-ac70-e7d9bb482088"), null, 0, null, new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), "Your bones and muscles have vastly increased density", 0 },
                    { new Guid("8bb31795-7294-42f3-9347-1e8b31596065"), null, 0, new Guid("f8f302ab-7ed7-47a9-85c1-2d570478a99a"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Flesh Magic is improved by 100%", 100 },
                    { new Guid("988af334-4b7e-4c7e-ae51-c5f3362ae0ef"), null, 0, new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), "Body enhancement magic is improved by 500%", 500 },
                    { new Guid("9c725771-e1b1-4a34-a2bf-db707b546077"), null, 0, null, new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Greatly increases the heat you can store within your body and soul", 0 },
                    { new Guid("9d0ab750-a179-4107-8349-e17d2d4dc88e"), null, 0, null, new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), "All fighting styles using hand to hand combat are more refined", 0 },
                    { new Guid("a070e26f-c73c-487f-9fdd-d73286650e22"), null, 0, new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Space Magic is improved by 500%", 500 },
                    { new Guid("a0ee0c09-5d9f-4577-9d16-c597fb97d36d"), null, 0, null, new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Your Soul has been strengthened by the Primordial Flame", 0 },
                    { new Guid("a24ac0ce-4fc0-4f2c-ae22-dbed4a108808"), null, 0, new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Healing Magic is improved by 100%", 100 },
                    { new Guid("a37dff49-7a62-4355-b6d4-7dccc452a247"), null, 0, new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), "All Fire magic skills are improved by 250%", 250 },
                    { new Guid("a9f8276e-272e-443d-a161-549e43525cce"), null, 0, null, new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), "Natural mana regeneration is increased by 1% per minute", 0 },
                    { new Guid("c2ef6ecc-a8ba-4d0c-a9fd-f0d3dfcf11cf"), null, 0, new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), "All healing magic skills are improved by 500%", 500 },
                    { new Guid("c37f99aa-4fe2-4ea0-9cbe-63a646a26d1a"), null, 0, new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), "All cosmic magic skills are improved by 250%", 250 },
                    { new Guid("cb4fb181-c7a8-4007-afdf-e68bcf328c9b"), null, 0, null, new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Your skin grows more resilient", 0 },
                    { new Guid("d2168950-990e-42d5-9b43-8b556aeb4741"), null, 0, new Guid("12696ef5-a857-466f-a618-43ee092816ee"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Ice Magic is improved by 100%", 100 },
                    { new Guid("d9c0563a-a568-4809-b798-bdf387475b38"), null, 0, null, new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), "You do not age", 0 },
                    { new Guid("e58a8112-38b5-4970-b38d-53866b4c8543"), null, 0, null, new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), "All mana regeneration increases by 1% to a maximum of 100% for every second you are not hit by an enemy attack", 0 },
                    { new Guid("ea583586-3ebb-4680-9092-250882d6c90f"), null, 0, new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), "All Ashen magic skills are improved by 500%", 500 },
                    { new Guid("fe07af4f-38e6-4e99-9f9d-3bd29692bded"), null, 0, new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), "Body Enhancement Magic is improved by 300%", 300 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_BaseStatId",
                table: "Resources",
                column: "BaseStatId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassModifiers_AffectedResourceId",
                table: "ClassModifiers",
                column: "AffectedResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassModifiers_CategoryId",
                table: "ClassModifiers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassModifiers_ClassId",
                table: "ClassModifiers",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Stats_BaseStatId",
                table: "Resources",
                column: "BaseStatId",
                principalTable: "Stats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Stats_BaseStatId",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "ClassModifiers");

            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropIndex(
                name: "IX_Resources_BaseStatId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "BaseStatId",
                table: "Resources");

            migrationBuilder.AddColumn<string>(
                name: "BaseStatName",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalculationName",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("70eaef56-21c1-494d-a0ba-312478c19428"),
                columns: new[] { "BaseStatName", "CalculationName" },
                values: new object[] { "Vitality", "Health" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("741e7652-0c8e-4cb8-8ac4-b298637ae6c2"),
                columns: new[] { "BaseStatName", "CalculationName" },
                values: new object[] { "Vitality", "Health" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("97f54c26-273e-47fc-b00f-7c5ad5b6cfae"),
                columns: new[] { "BaseStatName", "CalculationName" },
                values: new object[] { "Wisdom", "Mana" });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("f8a10c54-df2b-4658-9e37-ff772a55aea3"),
                columns: new[] { "BaseStatName", "CalculationName" },
                values: new object[] { "Endurance", "Stamina" });
        }
    }
}
