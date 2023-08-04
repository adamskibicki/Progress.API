using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddNormalizedEmailToSeededTestUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "a5b88d84-07d0-4eb5-a84d-01ab99839a01", "TEST.TEST@TEST", "AQAAAAEAACcQAAAAECxrNs50etyeQ62Dy5nXqhmiJT90uq1i4pOh7UDoC8lDvndsMOU1c55eJh2gU+mEfw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0f9bb970-3723-ce3a-878f-0ba2c2a81d09"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "70ec409e-c520-475e-aa89-231640772a21", null, "AQAAAAEAACcQAAAAEMlxPlvWPhY0DOHtBATV2Hs8IBgYjxYUdNvpg7ILAoVnRDV+EKIUavJ6648huBlu2Q==" });
        }
    }
}
