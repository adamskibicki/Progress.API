using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddSkillVariableStatSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SkillVariableStats",
                columns: new[] { "SkillVariableId", "StatId", "Id" },
                values: new object[,]
                {
                    { new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"), new Guid("047e7614-496d-4519-a784-6dec5e753571"), new Guid("04183509-32e3-609c-a851-cf9d1e454b01") },
                    { new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"), new Guid("047e7614-496d-4519-a784-6dec5e753571"), new Guid("b319ea2f-9114-7df6-9f79-5b2710c64f97") },
                    { new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"), new Guid("170c68c3-2261-4063-9460-360144fb9597"), new Guid("fe083405-3dd9-fb39-b3df-b8074e11b0bb") },
                    { new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"), new Guid("170c68c3-2261-4063-9460-360144fb9597"), new Guid("2653c99d-8cdf-55b5-be26-0b8b91df042d") },
                    { new Guid("eacd6d98-b4d1-e88a-aa2f-f21710f90fab"), new Guid("170c68c3-2261-4063-9460-360144fb9597"), new Guid("6dfd3998-4945-5305-b856-7dd4f008b727") },
                    { new Guid("55c9daff-9df8-e8db-bd29-5ac70617eaaf"), new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df"), new Guid("98abd6b8-61a5-40a8-821a-207fb04bbb68") },
                    { new Guid("f4008345-108e-5fb5-b697-b4d1bd02712e"), new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df"), new Guid("c9d82084-ab60-5935-b280-c88e5ceed4a1") },
                    { new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"), new Guid("20cce93e-f883-4860-be2f-4cdbd0c6e3be"), new Guid("393dc4f1-4e4c-c6a8-97e0-abd942d77a07") },
                    { new Guid("eacd6d98-b4d1-e88a-aa2f-f21710f90fab"), new Guid("6c7beb1c-10bd-4e10-a019-82fb9c24115a"), new Guid("9a25cdce-1f62-74f3-8864-57465647ec79") },
                    { new Guid("bccc1c4b-c86b-eb97-871c-a027383caa5c"), new Guid("ab85915d-e66f-4460-96af-e90f171ccab5"), new Guid("5618fb37-dc76-73ab-af4e-cb36a4ab0740") },
                    { new Guid("6708123a-3f38-f102-9f3d-07aef4f3760e"), new Guid("c6474033-2e4c-4805-95f3-4fe22e9de88a"), new Guid("f805ffdd-3dc6-fc5f-8f4d-7270fbca6df1") },
                    { new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"), new Guid("de4b423f-4718-4e26-9d75-14f4a1581b37"), new Guid("073f3258-a4fe-45b6-8fa4-ae706cfb4ee5") },
                    { new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"), new Guid("de4b423f-4718-4e26-9d75-14f4a1581b37"), new Guid("c709eef2-c332-cfa3-9e8f-51b0738591a7") },
                    { new Guid("4a946992-0a7d-7e6f-b87b-4e877bd63cc6"), new Guid("ec4aaeb2-2caa-43f0-8c44-3c8374d0cb5d"), new Guid("a757170d-e3cf-f018-8ef0-9bd22e076fc3") },
                    { new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"), new Guid("ec4aaeb2-2caa-43f0-8c44-3c8374d0cb5d"), new Guid("d3cad15f-3531-d853-ac13-22e7a0dd4f58") },
                    { new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"), new Guid("ec4aaeb2-2caa-43f0-8c44-3c8374d0cb5d"), new Guid("124fda9f-701c-726a-820a-8d369832d72f") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"), new Guid("047e7614-496d-4519-a784-6dec5e753571") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"), new Guid("047e7614-496d-4519-a784-6dec5e753571") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"), new Guid("170c68c3-2261-4063-9460-360144fb9597") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"), new Guid("170c68c3-2261-4063-9460-360144fb9597") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("eacd6d98-b4d1-e88a-aa2f-f21710f90fab"), new Guid("170c68c3-2261-4063-9460-360144fb9597") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("55c9daff-9df8-e8db-bd29-5ac70617eaaf"), new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("f4008345-108e-5fb5-b697-b4d1bd02712e"), new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"), new Guid("20cce93e-f883-4860-be2f-4cdbd0c6e3be") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("eacd6d98-b4d1-e88a-aa2f-f21710f90fab"), new Guid("6c7beb1c-10bd-4e10-a019-82fb9c24115a") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("bccc1c4b-c86b-eb97-871c-a027383caa5c"), new Guid("ab85915d-e66f-4460-96af-e90f171ccab5") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("6708123a-3f38-f102-9f3d-07aef4f3760e"), new Guid("c6474033-2e4c-4805-95f3-4fe22e9de88a") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"), new Guid("de4b423f-4718-4e26-9d75-14f4a1581b37") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"), new Guid("de4b423f-4718-4e26-9d75-14f4a1581b37") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("4a946992-0a7d-7e6f-b87b-4e877bd63cc6"), new Guid("ec4aaeb2-2caa-43f0-8c44-3c8374d0cb5d") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"), new Guid("ec4aaeb2-2caa-43f0-8c44-3c8374d0cb5d") });

            migrationBuilder.DeleteData(
                table: "SkillVariableStats",
                keyColumns: new[] { "SkillVariableId", "StatId" },
                keyValues: new object[] { new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"), new Guid("ec4aaeb2-2caa-43f0-8c44-3c8374d0cb5d") });
        }
    }
}
