using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class SimplifyTreeRootToQuestFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Trees_TreeId",
                table: "Quests");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Trees_TreeId1",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Quests_TreeId1",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "TreeId1",
                table: "Quests");

            migrationBuilder.AlterColumn<Guid>(
                name: "TreeId",
                table: "Quests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsRoot",
                table: "Quests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Trees_TreeId",
                table: "Quests",
                column: "TreeId",
                principalTable: "Trees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Trees_TreeId",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "IsRoot",
                table: "Quests");

            migrationBuilder.AlterColumn<Guid>(
                name: "TreeId",
                table: "Quests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TreeId1",
                table: "Quests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quests_TreeId1",
                table: "Quests",
                column: "TreeId1",
                unique: true,
                filter: "[TreeId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Trees_TreeId",
                table: "Quests",
                column: "TreeId",
                principalTable: "Trees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Trees_TreeId1",
                table: "Quests",
                column: "TreeId1",
                principalTable: "Trees",
                principalColumn: "Id");
        }
    }
}
