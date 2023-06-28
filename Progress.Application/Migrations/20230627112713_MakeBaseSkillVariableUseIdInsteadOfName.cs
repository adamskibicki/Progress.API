using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class MakeBaseSkillVariableUseIdInsteadOfName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseVariableName",
                table: "SkillVariables");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseSkillVariableId",
                table: "SkillVariables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("4a946992-0a7d-7e6f-b87b-4e877bd63cc6"),
                column: "BaseSkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"),
                column: "BaseSkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("55c9daff-9df8-e8db-bd29-5ac70617eaaf"),
                column: "BaseSkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("6708123a-3f38-f102-9f3d-07aef4f3760e"),
                column: "BaseSkillVariableId",
                value: new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"));

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"),
                column: "BaseSkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("bccc1c4b-c86b-eb97-871c-a027383caa5c"),
                column: "BaseSkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("eacd6d98-b4d1-e88a-aa2f-f21710f90fab"),
                column: "BaseSkillVariableId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("f4008345-108e-5fb5-b697-b4d1bd02712e"),
                column: "BaseSkillVariableId",
                value: new Guid("eacd6d98-b4d1-e88a-aa2f-f21710f90fab"));

            migrationBuilder.CreateIndex(
                name: "IX_SkillVariables_BaseSkillVariableId",
                table: "SkillVariables",
                column: "BaseSkillVariableId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillVariables_SkillVariables_BaseSkillVariableId",
                table: "SkillVariables",
                column: "BaseSkillVariableId",
                principalTable: "SkillVariables",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillVariables_SkillVariables_BaseSkillVariableId",
                table: "SkillVariables");

            migrationBuilder.DropIndex(
                name: "IX_SkillVariables_BaseSkillVariableId",
                table: "SkillVariables");

            migrationBuilder.DropColumn(
                name: "BaseSkillVariableId",
                table: "SkillVariables");

            migrationBuilder.AddColumn<string>(
                name: "BaseVariableName",
                table: "SkillVariables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("4a946992-0a7d-7e6f-b87b-4e877bd63cc6"),
                column: "BaseVariableName",
                value: null);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"),
                column: "BaseVariableName",
                value: null);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("55c9daff-9df8-e8db-bd29-5ac70617eaaf"),
                column: "BaseVariableName",
                value: null);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("6708123a-3f38-f102-9f3d-07aef4f3760e"),
                column: "BaseVariableName",
                value: "stats_increase");

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"),
                column: "BaseVariableName",
                value: null);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("bccc1c4b-c86b-eb97-871c-a027383caa5c"),
                column: "BaseVariableName",
                value: null);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("eacd6d98-b4d1-e88a-aa2f-f21710f90fab"),
                column: "BaseVariableName",
                value: null);

            migrationBuilder.UpdateData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("f4008345-108e-5fb5-b697-b4d1bd02712e"),
                column: "BaseVariableName",
                value: "stats_increase");
        }
    }
}
