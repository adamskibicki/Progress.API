using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class MadeAffectedResourceInClassModifierNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Stats_BaseStatId",
                table: "Resources");

            migrationBuilder.AlterColumn<Guid>(
                name: "BaseStatId",
                table: "Resources",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Stats_BaseStatId",
                table: "Resources",
                column: "BaseStatId",
                principalTable: "Stats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Stats_BaseStatId",
                table: "Resources");

            migrationBuilder.AlterColumn<Guid>(
                name: "BaseStatId",
                table: "Resources",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Stats_BaseStatId",
                table: "Resources",
                column: "BaseStatId",
                principalTable: "Stats",
                principalColumn: "Id");
        }
    }
}
