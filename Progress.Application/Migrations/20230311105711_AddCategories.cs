using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayColor", "Name" },
                values: new object[,]
                {
                    { new Guid("11751928-c2d3-4939-9692-05f578af3d00"), "#000000", "Earth Magic" },
                    { new Guid("12696ef5-a857-466f-a618-43ee092816ee"), "#000000", "Ice Magic" },
                    { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), "#000000", "Fire Magic" },
                    { new Guid("4538069f-9680-4b26-84a4-e608d1c86606"), "#000000", "Mind Magic" },
                    { new Guid("572ba72e-87df-45bf-9496-a2b9d8962c7d"), "#000000", "Arcane Magic" },
                    { new Guid("65728378-090f-4c29-9e87-b282f489d028"), "#000000", "Perception Aura" },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), "#000000", "Cosmic Magic" },
                    { new Guid("94cb02e4-43dc-4021-95ac-d9d5bc6512d6"), "#000000", "Lava Magic" },
                    { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), "#000000", "Healing Magic" },
                    { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), "#000000", "Ashen Magic" },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), "#000000", "Body Enhancement" },
                    { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), "#000000", "Aura" },
                    { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), "#000000", "Space Magic" },
                    { new Guid("f8362bfc-6004-43df-827f-17f21203c6f3"), "#000000", "Teleportation Magic" },
                    { new Guid("f8f302ab-7ed7-47a9-85c1-2d570478a99a"), "#000000", "Flesh Magic" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
