using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddUserCategoryUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e7bc669-d4a7-4122-bd65-bb0525a3c61c", "AQAAAAEAACcQAAAAELLMjIiFKuc+3Kj9jkb2LO04/8BLo377wFmfKztG6sRrlJ6Jb+l3ln3gmUwzS+Z4Xg==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11751928-c2d3-4939-9692-05f578af3d00"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("12696ef5-a857-466f-a618-43ee092816ee"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4538069f-9680-4b26-84a4-e608d1c86606"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("572ba72e-87df-45bf-9496-a2b9d8962c7d"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("65728378-090f-4c29-9e87-b282f489d028"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94cb02e4-43dc-4021-95ac-d9d5bc6512d6"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f8362bfc-6004-43df-827f-17f21203c6f3"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f8f302ab-7ed7-47a9-85c1-2d570478a99a"),
                column: "UserId",
                value: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_UserId",
                table: "Categories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_UserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a5b88d84-07d0-4eb5-a84d-01ab99839a01", "AQAAAAEAACcQAAAAECxrNs50etyeQ62Dy5nXqhmiJT90uq1i4pOh7UDoC8lDvndsMOU1c55eJh2gU+mEfw==" });
        }
    }
}
