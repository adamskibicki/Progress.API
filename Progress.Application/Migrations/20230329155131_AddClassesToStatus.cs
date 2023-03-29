using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddClassesToStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CharacterStatusId",
                table: "CharacterClasses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"),
                column: "CharacterStatusId",
                value: new Guid("afa42078-a071-4bea-978e-f439c713848c"));

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                column: "CharacterStatusId",
                value: new Guid("afa42078-a071-4bea-978e-f439c713848c"));

            migrationBuilder.UpdateData(
                table: "CharacterClasses",
                keyColumn: "Id",
                keyValue: new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                column: "CharacterStatusId",
                value: new Guid("afa42078-a071-4bea-978e-f439c713848c"));

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClasses_CharacterStatusId",
                table: "CharacterClasses",
                column: "CharacterStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterClasses_CharacterStatuses_CharacterStatusId",
                table: "CharacterClasses",
                column: "CharacterStatusId",
                principalTable: "CharacterStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClasses_CharacterStatuses_CharacterStatusId",
                table: "CharacterClasses");

            migrationBuilder.DropIndex(
                name: "IX_CharacterClasses_CharacterStatusId",
                table: "CharacterClasses");

            migrationBuilder.DropColumn(
                name: "CharacterStatusId",
                table: "CharacterClasses");
        }
    }
}
