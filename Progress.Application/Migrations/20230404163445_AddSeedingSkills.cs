using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_CharacterClasses_CharacterClassId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillVariables_Skills_SkillId",
                table: "SkillVariables");

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillId",
                table: "SkillVariables",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CharacterClassId",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CharacterStatuses",
                keyColumn: "Id",
                keyValue: new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 4, 16, 34, 45, 327, DateTimeKind.Unspecified).AddTicks(7121), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CharacterClassId", "Enhanced", "Level", "Name", "Tier", "Type" },
                values: new object[,]
                {
                    { new Guid("04183509-32e3-609c-a851-cf9d1e454b01"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Embodiment of the Arcane", 3, 0 },
                    { new Guid("073f3258-a4fe-45b6-8fa4-ae706cfb4ee5"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Teleportation", 3, 0 },
                    { new Guid("124fda9f-701c-726a-820a-8d369832d72f"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Catalyst Core", 3, 1 },
                    { new Guid("1b8af906-2278-f55c-b9d2-1d3bac80f41a"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), true, 30, "Volcanic Source", 3, 0 },
                    { new Guid("2653c99d-8cdf-55b5-be26-0b8b91df042d"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Timeless Perception", 3, 1 },
                    { new Guid("393dc4f1-4e4c-c6a8-97e0-abd942d77a07"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), false, 30, "Eternal Brawling", 3, 1 },
                    { new Guid("47510d1e-864d-515c-928e-449533a609ac"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), true, 1, "Pyroclastic Flow", 4, 0 },
                    { new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), true, 30, "The Primordial Flame", 3, 0 },
                    { new Guid("5c44ca2c-4a2b-fe06-9ba5-5b514e509a59"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), true, 30, "Ash Scale Armor", 3, 0 },
                    { new Guid("6867a632-b599-5d58-9898-1542221b7bce"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), true, 30, "Draconic Core", 3, 0 },
                    { new Guid("6a0b5b10-678d-f128-a606-f05f175e174f"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), true, 1, "Sunbound Creation", 4, 0 },
                    { new Guid("6bef7f20-7c71-d402-994e-0d6080b02029"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), true, 30, "Cosmic Shape", 3, 0 },
                    { new Guid("84dd85c6-8c89-c23f-b392-eeab48d0a42d"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), true, 30, "Scorching Intrusion", 3, 0 },
                    { new Guid("8f4de75d-29e4-7ee9-8668-714edd543167"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), true, 30, "Reality Warp", 3, 1 },
                    { new Guid("932d79fd-8896-497a-b012-8271b421e66b"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), true, 30, "Mastery of Ash", 3, 1 },
                    { new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), true, 30, "Embodiment of Heat", 3, 1 },
                    { new Guid("9a9ba5ac-05c7-e681-a4dc-118abd9b17ae"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), true, 30, "Draconic Ash Wings", 3, 1 },
                    { new Guid("ae94e0c9-1fa7-f167-b836-ddeaea261b5c"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), true, 30, "Fabric Alteration", 3, 1 },
                    { new Guid("b094f1b0-5b8a-fd1a-b8cb-7062837f1f70"), new Guid("6689fb11-732c-4fda-af01-abde9895dc16"), true, 30, "Framework Disruption", 3, 0 },
                    { new Guid("b319ea2f-9114-7df6-9f79-5b2710c64f97"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Cycle of Creation", 3, 1 },
                    { new Guid("c44ce21f-7e2e-d03d-aefe-ea2a495d9918"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), true, 30, "Embered Form", 3, 0 },
                    { new Guid("c709eef2-c332-cfa3-9e8f-51b0738591a7"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), false, 30, "Eternal Huntress", 3, 1 },
                    { new Guid("d3cad15f-3531-d853-ac13-22e7a0dd4f58"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Cosmic Deconstruction", 3, 0 },
                    { new Guid("f805ffdd-3dc6-fc5f-8f4d-7270fbca6df1"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Limitless Domain", 3, 0 },
                    { new Guid("f9b1c17e-d87a-dc9c-a22d-5fdbad8358a5"), new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"), false, 30, "Vision of Ash", 3, 1 },
                    { new Guid("fe083405-3dd9-fb39-b3df-b8074e11b0bb"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 1, "True Reconstruction", 4, 0 }
                });

            migrationBuilder.InsertData(
                table: "CategorySkill",
                columns: new[] { "CategoriesId", "SkillsId" },
                values: new object[,]
                {
                    { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("1b8af906-2278-f55c-b9d2-1d3bac80f41a") },
                    { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("47510d1e-864d-515c-928e-449533a609ac") },
                    { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1") },
                    { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("6867a632-b599-5d58-9898-1542221b7bce") },
                    { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("6a0b5b10-678d-f128-a606-f05f175e174f") },
                    { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("6bef7f20-7c71-d402-994e-0d6080b02029") },
                    { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("84dd85c6-8c89-c23f-b392-eeab48d0a42d") },
                    { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b") },
                    { new Guid("572ba72e-87df-45bf-9496-a2b9d8962c7d"), new Guid("393dc4f1-4e4c-c6a8-97e0-abd942d77a07") },
                    { new Guid("65728378-090f-4c29-9e87-b282f489d028"), new Guid("f805ffdd-3dc6-fc5f-8f4d-7270fbca6df1") },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("04183509-32e3-609c-a851-cf9d1e454b01") },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("124fda9f-701c-726a-820a-8d369832d72f") },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("2653c99d-8cdf-55b5-be26-0b8b91df042d") },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("d3cad15f-3531-d853-ac13-22e7a0dd4f58") },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("f805ffdd-3dc6-fc5f-8f4d-7270fbca6df1") },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("fe083405-3dd9-fb39-b3df-b8074e11b0bb") },
                    { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("124fda9f-701c-726a-820a-8d369832d72f") },
                    { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("6a0b5b10-678d-f128-a606-f05f175e174f") },
                    { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("d3cad15f-3531-d853-ac13-22e7a0dd4f58") },
                    { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("fe083405-3dd9-fb39-b3df-b8074e11b0bb") },
                    { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("1b8af906-2278-f55c-b9d2-1d3bac80f41a") },
                    { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("47510d1e-864d-515c-928e-449533a609ac") },
                    { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("5c44ca2c-4a2b-fe06-9ba5-5b514e509a59") },
                    { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("6867a632-b599-5d58-9898-1542221b7bce") },
                    { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("84dd85c6-8c89-c23f-b392-eeab48d0a42d") },
                    { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("932d79fd-8896-497a-b012-8271b421e66b") },
                    { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b") },
                    { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("9a9ba5ac-05c7-e681-a4dc-118abd9b17ae") },
                    { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("f9b1c17e-d87a-dc9c-a22d-5fdbad8358a5") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("04183509-32e3-609c-a851-cf9d1e454b01") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("124fda9f-701c-726a-820a-8d369832d72f") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("1b8af906-2278-f55c-b9d2-1d3bac80f41a") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("2653c99d-8cdf-55b5-be26-0b8b91df042d") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("393dc4f1-4e4c-c6a8-97e0-abd942d77a07") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("5c44ca2c-4a2b-fe06-9ba5-5b514e509a59") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("6867a632-b599-5d58-9898-1542221b7bce") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("6bef7f20-7c71-d402-994e-0d6080b02029") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("9a9ba5ac-05c7-e681-a4dc-118abd9b17ae") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("ae94e0c9-1fa7-f167-b836-ddeaea261b5c") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("b319ea2f-9114-7df6-9f79-5b2710c64f97") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("c44ce21f-7e2e-d03d-aefe-ea2a495d9918") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("c709eef2-c332-cfa3-9e8f-51b0738591a7") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("f9b1c17e-d87a-dc9c-a22d-5fdbad8358a5") },
                    { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), new Guid("04183509-32e3-609c-a851-cf9d1e454b01") },
                    { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1") },
                    { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), new Guid("6867a632-b599-5d58-9898-1542221b7bce") },
                    { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), new Guid("f805ffdd-3dc6-fc5f-8f4d-7270fbca6df1") },
                    { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1") },
                    { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("6a0b5b10-678d-f128-a606-f05f175e174f") },
                    { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("6bef7f20-7c71-d402-994e-0d6080b02029") },
                    { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("8f4de75d-29e4-7ee9-8668-714edd543167") },
                    { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("ae94e0c9-1fa7-f167-b836-ddeaea261b5c") },
                    { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("b094f1b0-5b8a-fd1a-b8cb-7062837f1f70") },
                    { new Guid("f8362bfc-6004-43df-827f-17f21203c6f3"), new Guid("073f3258-a4fe-45b6-8fa4-ae706cfb4ee5") }
                });

            migrationBuilder.InsertData(
                table: "SkillVariables",
                columns: new[] { "Id", "BaseValue", "BaseVariableName", "CategoryCalculationType", "Name", "SkillId", "Unit", "VariableCalculationType" },
                values: new object[,]
                {
                    { new Guid("4a946992-0a7d-7e6f-b87b-4e877bd63cc6"), 75, null, 1, "resilience_increase", new Guid("6bef7f20-7c71-d402-994e-0d6080b02029"), "%", 1 },
                    { new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"), 100, null, 1, "stats_increase", new Guid("04183509-32e3-609c-a851-cf9d1e454b01"), "%", 1 },
                    { new Guid("55c9daff-9df8-e8db-bd29-5ac70617eaaf"), 35, null, 5, "vitality_increase", new Guid("6bef7f20-7c71-d402-994e-0d6080b02029"), "%", 1 },
                    { new Guid("6708123a-3f38-f102-9f3d-07aef4f3760e"), 25, "stats_increase", 1, "wisdom_increase", new Guid("04183509-32e3-609c-a851-cf9d1e454b01"), "%", 3 },
                    { new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"), 100, null, 1, "stats_increase", new Guid("6867a632-b599-5d58-9898-1542221b7bce"), "%", 1 },
                    { new Guid("bccc1c4b-c86b-eb97-871c-a027383caa5c"), 625, null, 1, "endurance_increase", new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b"), "%", 0 },
                    { new Guid("eacd6d98-b4d1-e88a-aa2f-f21710f90fab"), 75, null, 1, "stats_increase", new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b"), "%", 1 },
                    { new Guid("f4008345-108e-5fb5-b697-b4d1bd02712e"), 25, "stats_increase", 5, "vitality_increase", new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b"), "%", 3 }
                });

            migrationBuilder.InsertData(
                table: "TierDescriptions",
                columns: new[] { "Id", "Description", "SkillId", "Tier" },
                values: new object[,]
                {
                    { new Guid("068bf9bf-6b3f-f5c2-9047-b8249f9215c2"), "You may have both the original and reversed aspects activated at the same time. When an enemy partially or fully resists either Cosmic Deconstruction or True Reconstruction, you absorb the dissipating mana.", new Guid("b319ea2f-9114-7df6-9f79-5b2710c64f97"), 2 },
                    { new Guid("07e7b3ca-74df-7e4e-ab26-aa51aa4e947f"), "Focus on release to change the blast into a cone of destruction sent out of either arm. You may store heat within any ash, smoke, or volcanic glass that you control. Creations not connected to you release their stored heat upon a strong impact in a blast around it or when you will it. You learn to send out any stored heat as waves through your Pyroclastic Flow.", new Guid("1b8af906-2278-f55c-b9d2-1d3bac80f41a"), 3 },
                    { new Guid("096abe96-c853-d910-b1f0-08c87dcee82a"), "You may choose two flat areas and connect them through space. At the time of marking an area, it has to be within the range of Framework Disruption. Ten sets of connections can be upheld at a time with exponential costs.", new Guid("b094f1b0-5b8a-fd1a-b8cb-7062837f1f70"), 3 },
                    { new Guid("09b31c14-9df3-44cf-b0c3-49d7069ed870"), "You have proven your dedication. The Pyroclastic Flow moves to aid and destroy at your whims. The amount of ash, smoke, and volcanic glass you can create is vastly increased.", new Guid("47510d1e-864d-515c-928e-449533a609ac"), 3 },
                    { new Guid("0a1e1b87-3f92-5282-aab3-e4303c1aa457"), "The Primordial Flame wills itself into existence, your control and its power increasing dramatically while Sunbound Creation is active. Increases the power of all space manipulation while the spell is active. Greatly reduces the activation time of Sunbound Creation. The longer this spell remains active, the more powerful its effects become.", new Guid("6a0b5b10-678d-f128-a606-f05f175e174f"), 3 },
                    { new Guid("0ddfa7c4-8d9f-e8ce-a31a-1877acb2b765"), "You have adapted the fighting style of the Azarinth school to something you now call your own. Damage inflicted with your own body and related skills is 110% [990%] higher. Your arms, fists, fingers, legs, and head deal a slight amount of arcane damage with each strike.", new Guid("393dc4f1-4e4c-c6a8-97e0-abd942d77a07"), 1 },
                    { new Guid("18f789f5-c4ca-f6f3-bfee-1d4a3cc6f4a0"), "Your understanding grows, allowing you to create greater change in ash, smoke, and volcanic glass. Imbue mana and complex commands into your creations. Ash and volcanic glass you imbue retains its form until the mana is used up. Imbued creations retain a static 10% of your ambient and enemy spell mana absorption.", new Guid("932d79fd-8896-497a-b012-8271b421e66b"), 2 },
                    { new Guid("192b7f5f-96aa-42ca-a8a5-6e863c0a5582"), "You may vastly increase the density and heat of your ash, smoke, and volcanic glass.", new Guid("47510d1e-864d-515c-928e-449533a609ac"), 2 },
                    { new Guid("19637103-c9a6-729f-9d30-908ef6ba3c0e"), "Burn the inside of whatever your body or your magical constructs touch with a surge of heat or release the attack in a violent burst.", new Guid("84dd85c6-8c89-c23f-b392-eeab48d0a42d"), 1 },
                    { new Guid("1a42c346-1e75-de2d-89fd-c9648feab18a"), "Vastly increase the heat in your body and release it in a blast or continuous heat around you.", new Guid("1b8af906-2278-f55c-b9d2-1d3bac80f41a"), 1 },
                    { new Guid("1bc0cec8-4c80-c4d9-aa45-bcb96aad549a"), "The time between transfers is reduced greatly. No ground contact needed between transfers. Teleportation gains 3 charges, each with a separate cooldown. For 2 seconds after Teleportation is used, you may return to the original position in the fabric where the spell was initially activated.", new Guid("073f3258-a4fe-45b6-8fa4-ae706cfb4ee5"), 2 },
                    { new Guid("1dbb61b1-7e31-de9b-9c3a-c2a3e41078b8"), "Your body was battered and forged by magic. You absorb mana from enemy spells in your domain. Efficiency is determined by enemy mana used and your resistance to the type of magic. Mana cost for all skills reduced by a static 35%. Your body can absorb ambient mana. Amount dependent on availability and harmony.", new Guid("124fda9f-701c-726a-820a-8d369832d72f"), 3 },
                    { new Guid("1f6aca0d-a5b6-dce9-bee6-4d4fcad987f9"), "Opportunity calls, you notice possible critical weak points on enemies with more ease. You can choose to see through ash and embers.", new Guid("f9b1c17e-d87a-dc9c-a22d-5fdbad8358a5"), 2 },
                    { new Guid("219ff2a7-8fe6-427e-9243-c675d3d1d9bf"), "Your wings become more dense and tangible, able to help you defend and attack. When active, your wings become a part of your body.", new Guid("9a9ba5ac-05c7-e681-a4dc-118abd9b17ae"), 2 },
                    { new Guid("240237b3-cef2-ec3b-b24c-2b4c3d599a97"), "Your ability to adapt to your enemy grows. Continued battle against the same foe or species of monster increases damage reduction against their attacks by 2.5% [58.75%] per minute to a maximum of a static 50%. This effect will remain even after a battle has ended. The Cosmic Shape is released should you reach low health [0.1% - set value]. Your mana [100% - set value] will be used to create both spatial shields and the Primordial Flame to prevent death. This effect can only occur once every three hours.", new Guid("6bef7f20-7c71-d402-994e-0d6080b02029"), 3 },
                    { new Guid("2877767d-5a15-fa0e-bfb1-d4be1610f94f"), "Vastly increases your perception and reflexes.", new Guid("2653c99d-8cdf-55b5-be26-0b8b91df042d"), 1 },
                    { new Guid("291407cc-1627-e15d-a762-a7226894a333"), "The bright flame settles within your core. The Primordial Flame now affects enemy health, mana, and stamina regeneration. This effect is higher for areas directly touched by the Primordial Flame.", new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1"), 2 },
                    { new Guid("319ce442-288c-5082-90c9-493f98815b6c"), "Prevent enemy teleportation spells within a sphere around you at a radius of 50 meters. You cannot teleport while this skill is active.", new Guid("8f4de75d-29e4-7ee9-8668-714edd543167"), 2 },
                    { new Guid("335ace47-817c-dbcc-b84f-337ae17ab55a"), "Increases your perception by 65% [780%] when fighting.", new Guid("f9b1c17e-d87a-dc9c-a22d-5fdbad8358a5"), 1 },
                    { new Guid("355c0a74-b530-da78-9c26-752b2e6ac086"), "Adds density to your bones, muscles and skin to increase strength, speed and damage. Base body weight is doubled. The abuse your body takes from your own strikes and their feedback is reduced.", new Guid("c44ce21f-7e2e-d03d-aefe-ea2a495d9918"), 2 },
                    { new Guid("358a78f9-e1e3-f77b-b0ee-36033962e4e7"), "You have learned of Cosmic Deconstruction and True Reconstruction. Now you will learn of their Reversal.\r\nUpon activation, Cosmic Deconstruction will send a part of the struck enemy’s health and mana into yourself. No mana will be released on impact, rendering Cosmic Deconstruction’s offensive potential to zero.\r\nUpon activation, True Reconstruction will send a destructive force of channeled mana into yourself, a creature or magical construct within your domain, the healing aspects are reduced to zero.", new Guid("b319ea2f-9114-7df6-9f79-5b2710c64f97"), 1 },
                    { new Guid("3ae0a554-f727-ee84-9752-5ec4ee1fc939"), "Space wields easier for you, allowing you to unravel its mysteries. Teleportation abilities can be used again three times as fast and you can travel ten times as far. You notice fissures between realms at a distance of 50 [200] kilometers. This distance can vary depending on the size and extent of the fissure.", new Guid("8f4de75d-29e4-7ee9-8668-714edd543167"), 1 },
                    { new Guid("3b3d2df7-6345-c7c9-802e-8a5fb10deacd"), "Perceive everything in a sphere around you while this skill is activated. The higher the level the further your domain reaches. You may drain mana from creatures and spells within your domain.", new Guid("f805ffdd-3dc6-fc5f-8f4d-7270fbca6df1"), 1 },
                    { new Guid("3c55975d-f536-60f6-853c-1966e4ed1bd6"), "You have peered through the fabric of space itself and have learned to unravel its intricate structure. You gain the ability to perceive and differentiate magical frameworks and how to manipulate them within your space without failure. Charge simple manipulation attempts with up to 500 [10000] points of mana. You learn how to damage existing frameworks. Results may vary. Your experience with the fabric allows you to imbue your eyes with mana, to perceive and manipulate old tears in the mesh where cracks had formed or beings have traveled through the realms.", new Guid("ae94e0c9-1fa7-f167-b836-ddeaea261b5c"), 3 },
                    { new Guid("40412425-5047-7117-8c76-fff960024aa6"), "You are one with the fighting style of Ash. Damage inflicted is 85% [850%] higher.", new Guid("c44ce21f-7e2e-d03d-aefe-ea2a495d9918"), 1 },
                    { new Guid("42e9bea0-4759-def3-a848-6f1cb832aa0a"), "The elements themselves become an extension of your body, an extension of your will, for as long as they stay in physical contact with you. Ash and volcanic glass not connected benefits from passive abilities enhancing your body. You may imbue commands into ash and ember you have imbued with mana. Once per hour, you may create up to 25 copies of your form made of ash and volcanic glass, all instantly imbued with the same or separate complex commands. Each copy receives one random Class skill from any of your Classes. Should a spell require health or stamina to function, you may choose to imbue these resources as well. Copies lose access to this skill after initially imbued resources are used up.", new Guid("932d79fd-8896-497a-b012-8271b421e66b"), 3 },
                    { new Guid("449dfd43-9554-4d15-a358-fa46ab927c73"), "You can choose to allow magic damage to bypass your related resistance skills. If this effect is active, any absorption abilities related to such magic damage is increased. Effect is canceled automatically upon reaching 50% of your health. Each Resistance skill in the second tier or higher increases your heat generation and the potential density of your created ash and volcanic glass by a static 5% [225%]. Each Resistance skill in the third tier increases the speed of your created projectiles by 10% [260%].", new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b"), 3 },
                    { new Guid("44e53c0b-5ac1-419f-85dc-c5fd60a47352"), "An armor of ash and hardened volcanic glass scales protects and fuses partially with your body, forming at your will. The Armor increases your resistance to heat and fire, as well as your overall resilience by 200% [3200%].", new Guid("5c44ca2c-4a2b-fe06-9ba5-5b514e509a59"), 1 },
                    { new Guid("46a80a7b-4bcd-e808-9c21-05d0c0c764ee"), "Arcane dominion opens your senses to the arcane. A paramount skill both on and off the battlefield. Elements and spells you control within your dominion have increased harmony. You drain the remaining mana from creatures you kill inside of your domain.", new Guid("f805ffdd-3dc6-fc5f-8f4d-7270fbca6df1"), 2 },
                    { new Guid("4ec031fd-a1b8-cbbc-b818-e9c5a6393da9"), "Your understanding of space magic grows. You learn to latch on to ongoing teleportation spells with your own teleportation abilities. Long range and channeled teleportation spells have their range doubled and their cooldown as well as cost reduced by half.", new Guid("8f4de75d-29e4-7ee9-8668-714edd543167"), 3 },
                    { new Guid("5618fb37-dc76-73ab-af4e-cb36a4ab0740"), "Send a healing pulse of cosmic power into yourself or creatures within your domain. This skill can be channeled. In addition to health, True Reconstruction restores mana and heals damage to your soul.", new Guid("fe083405-3dd9-fb39-b3df-b8074e11b0bb"), 1 },
                    { new Guid("5846ad71-bd86-f40b-9ea9-79eee236660f"), "Your resilience and speed is doubled during the spike in perception. Increases usage to five times per hour. The effect duration is increased to three seconds and can be activated at will. You gain the ability to gauge enemy mana usage and may learn how strongly a direct hit of a spell will impact you. Increased ability to gauge incoming damage depending on your familiarity with the respective magic type.", new Guid("2653c99d-8cdf-55b5-be26-0b8b91df042d"), 3 },
                    { new Guid("5957b8f6-e03c-561a-85f9-1d55be8cab73"), "Timeless Perception spikes for two seconds, should you be about to receive a blow that would take 50% or more of your health, or should your mind be incapacitated with an incoming blow. This can happen only once per hour.", new Guid("2653c99d-8cdf-55b5-be26-0b8b91df042d"), 2 },
                    { new Guid("60d96527-1472-53dc-8d08-1fb70c76f10a"), "Familiarity with the skill removes its upkeep. You can choose to increase your weight by 1% [18.5%] for each passing second to a maximum of a static [1500%], increasing your natural health regeneration, heat generation, and resilience by the same factor.", new Guid("6867a632-b599-5d58-9898-1542221b7bce"), 3 },
                    { new Guid("666c91d8-ed80-c9bf-ae56-7e2479780065"), "Healing, power, resilience and speed. All requires balance. Your respective Deconstruction and Reconstruction spells have their potency increased by a static 25% of your median stat value. [488.75%]. You may channel health in addition to mana into the respective offensive uses of Archon Strike and Sentinel Reconstruction. Health cost to activate effects is reduced by a static 20%.", new Guid("b319ea2f-9114-7df6-9f79-5b2710c64f97"), 3 },
                    { new Guid("6a5db6b6-e21b-4cf2-a261-fb4207a1e2c9"), "Your body has withstood incredible damage, endured the hardships of battle. The fires flowing through you have hardened your bones and muscles. Your health is increased by <vitality_increase> 35% [822.5%].", new Guid("6bef7f20-7c71-d402-994e-0d6080b02029"), 2 },
                    { new Guid("6d67ea18-2888-df52-9403-5ddc2d89404d"), "The heat burns on. Targets hit will have fire burning through or on them. Continuous use of Scorching Intrusion will increase the stored energy up to a breaking point where all is released in a violent explosion of fire and heat. Breaking point is dependent on enemy resilience and heat resistance.", new Guid("84dd85c6-8c89-c23f-b392-eeab48d0a42d"), 2 },
                    { new Guid("6dfd3998-4945-5305-b856-7dd4f008b727"), "The amount of mana used per pulse can be regulated with a maximum of 5000 mana per pulse. You may charge each pulse with 5000 mana per second to a maximum of 25000 mana. Once cosmic power resides within a target, you can rip it out with a reversed motion to cause additional damage. Cosmic power within a target stacks, depending on their defensive measures and structure.", new Guid("d3cad15f-3531-d853-ac13-22e7a0dd4f58"), 2 },
                    { new Guid("70e04ac0-1eda-6658-9eb3-229c2f3ba2c5"), "Your body glows with the power of the cosmos, increasing your resilience, speed, Intelligence, and Strength by <stats_increase>.", new Guid("04183509-32e3-609c-a851-cf9d1e454b01"), 1 },
                    { new Guid("70e84c30-61da-f0be-b19e-9873fdadfa9f"), "Shift space to your will, making frameworks or parts of frameworks appear somewhere else. Yes. That means you can teleport someone’s head off of their shoulders. Should you do it? Probably not.", new Guid("b094f1b0-5b8a-fd1a-b8cb-7062837f1f70"), 1 },
                    { new Guid("70ff3b61-0e86-4267-942e-92173e928c1f"), "You may infuse your magical constructs with the Primordial Flame. For each level in the third tier, the skill’s upkeep is reduced by a static 50 [1500] points of health per second and you may sacrifice an additional static 500 [15000] points of health per second to enhance the skill’s effects. The Primordial Flames return a static 10% of all health, stamina, and mana burned away so long as the spell is active.", new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1"), 3 },
                    { new Guid("7a119d75-aa04-73aa-a860-3fc4853cf813"), "Your muscles grow more dense. For each Resistance skill your body becomes tougher. First tier Resistances equal a static 5% increase, second tier equal a static 10% increase, third tier equal a static 15% increase [<endurance_increase>]. Additionally affects your endurance.", new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b"), 2 },
                    { new Guid("7e89e93f-db6b-59bf-b0f5-0921d45d2f3e"), "You may set ten destinations you touch. You may change each destination once per day. This cooldown is static. You may travel to each destination once every 25 minutes [12.5 minutes]. Cast time is reduced by a static 50% for destinations you have already teleported to.", new Guid("073f3258-a4fe-45b6-8fa4-ae706cfb4ee5"), 3 },
                    { new Guid("7ec886af-0dea-de3f-98b1-daece0ab459a"), "Expending a large amount of mana and health, you can temporarily summon a new reality around your form, burning with the Primordial Flame and shielded by the fabric itself. Absorb a part of all magic that tries to affect your creation, depending on your understanding and resistance. All regeneration and healing is doubled in this state. Your movements are impaired as your very form is rejected by the true fabric that surrounds you.", new Guid("6a0b5b10-678d-f128-a606-f05f175e174f"), 1 },
                    { new Guid("7f94fb54-0f8e-5e26-ac84-08c96a55a021"), "Through Azarinth magic, you may mark an enemy or ally with the Eternal Mark. Allies may use the mark to send a short message to the Arcane Eternal once per day. The Arcane Eternal can send a short message to each non forcefully applied mark once per day. Each level in the third tier adds two additional marks that can be used. Marks forcefully applied have a limited duration.", new Guid("c709eef2-c332-cfa3-9e8f-51b0738591a7"), 3 },
                    { new Guid("83af78b2-e824-f419-8085-ef271ad1d87e"), "You have learned to see and manipulate the ever present spatial fabric. You gain the ability to move anything within the fabric with a mere gesture. Greatly improves the power of your manipulation and reduces its cost.", new Guid("ae94e0c9-1fa7-f167-b836-ddeaea261b5c"), 1 },
                    { new Guid("852f39a5-faaf-f4c1-a242-c9ab4e700844"), "The fires run deep. The heat you may reach is only limited by your very life. Your resistance to heat held within your body is tripled.", new Guid("1b8af906-2278-f55c-b9d2-1d3bac80f41a"), 2 },
                    { new Guid("86403491-f224-c030-baab-20e34557c785"), "Your understanding of the Pyroclastic Flow allows you to create scaled wings from ash and volcanic glass. Bring terror from above and deliver your wrath, your wings carrying you no matter how dense, how heavy, or how injured you are.", new Guid("9a9ba5ac-05c7-e681-a4dc-118abd9b17ae"), 1 },
                    { new Guid("8c29ec68-bf9e-c96b-93c9-51dc4f64d6fe"), "Scorching Intrusion damages mana intrusion capabilities of defensive enchantments, natural- as well as manufactured armor. Once a target is affected by Scorching Intrusion and in contact with your body or your magical constructs, you may increase the stored heat for up to a static 1000 mana per second to faster reach the breaking point.", new Guid("84dd85c6-8c89-c23f-b392-eeab48d0a42d"), 3 },
                    { new Guid("8c7b9a59-3fa8-5e3c-8bcd-65871db28fcb"), "Your eyes are vastly improved. Great distances and a lack of light won’t pose a problem to you anymore. You can control ash and embers that you can see.", new Guid("f9b1c17e-d87a-dc9c-a22d-5fdbad8358a5"), 3 },
                    { new Guid("9445f404-c483-c5ce-bcb5-5e9335942354"), "You gain a sense for the distress in the people around you. Amplify this by sacrificing mana. You gain a sense for the arcane, feeling even minor spells around you. As you practice to differentiate these spells, you will learn of their intent.", new Guid("c709eef2-c332-cfa3-9e8f-51b0738591a7"), 2 },
                    { new Guid("94ec4204-abad-ca4d-a680-3ff07b632e06"), "Your sight, hearing and sense of smell is also affected by Embodiment of the Arcane.", new Guid("04183509-32e3-609c-a851-cf9d1e454b01"), 2 },
                    { new Guid("98abd6b8-61a5-40a8-821a-207fb04bbb68"), "You have healed your body time and time again, knowing every cell and where it belongs. Sacrifice a large amount of mana to rush your healing to unprecedented speeds. Lack of knowledge about your body may result in heavy damage. Effect can be used on any creature or magical construct. Limited to 10’000 mana per use.", new Guid("fe083405-3dd9-fb39-b3df-b8074e11b0bb"), 3 },
                    { new Guid("9a25cdce-1f62-74f3-8864-57465647ec79"), "Send a pulse of deconstructing cosmic power into an object, spell, or creature within your domain with every motion using your arms, fists, fingers, legs, feet, or head. Your Intelligence stat enhances the damage potential.", new Guid("d3cad15f-3531-d853-ac13-22e7a0dd4f58"), 1 },
                    { new Guid("a0aa3129-3a8a-4f68-b903-dd1b11f7ac91"), "You are the Pyroclastic Storm. The Fourth Tier allows for true harmony.", new Guid("47510d1e-864d-515c-928e-449533a609ac"), 4 },
                    { new Guid("a1ca5b32-004a-5052-83c6-201875906f7d"), "Reduces stamina consumption by a static 35%. Mana intrusion attacks formed or charged within your arms, hands, fingers, legs, feet, or your head can instead be converted into a purely physical damage increase to the executed attack. Be aware that this increase will be heavily demanding for your body.", new Guid("c44ce21f-7e2e-d03d-aefe-ea2a495d9918"), 3 },
                    { new Guid("a1cb4b09-fc50-c462-99c5-cca6679d2a2d"), "You may change the orientation of the objects you displace. Should you be unable to affect a framework with the initial spell usage, you may channel up to a static 1000 mana per second into it to cause the desired effect.", new Guid("b094f1b0-5b8a-fd1a-b8cb-7062837f1f70"), 2 },
                    { new Guid("a2461a26-4320-6c5a-88a2-26a09a93909f"), "Resilience bonuses from skills are doubled when entering your Sunbound Creation. During the shift, you cannot be moved by anything but your will. Your weight increases a hundred fold while this spell is active. You may incorporate nearby allies into your creation, protecting them for an additional cost of mana and health.", new Guid("6a0b5b10-678d-f128-a606-f05f175e174f"), 2 },
                    { new Guid("a323d2bc-4654-c379-8147-f003fe10ae88"), "Huntress turned Eternal. Your eyes are unmatched and so is your nose. Perceive the smallest irregularities in your surroundings as well as the ambient mana to find clues about your target’s whereabouts. Perceive the trails of dangerous prey.", new Guid("c709eef2-c332-cfa3-9e8f-51b0738591a7"), 1 },
                    { new Guid("a757170d-e3cf-f018-8ef0-9bd22e076fc3"), "Your control is increased greatly, you can now focus your healing on specific parts of the body. As long as mana and health remains, your True Reconstruction will restore your body. Lose your head and see for yourself! Health loss and critical blows are recalculated due to the nature of your healing. You may restore magical constructs and enchantments with True Reconstruction.", new Guid("fe083405-3dd9-fb39-b3df-b8074e11b0bb"), 2 },
                    { new Guid("a77cbedf-abbb-c665-9d33-e5fc216494f7"), "Immediately appear anywhere in your domain or anywhere you can see with reliable clarity.", new Guid("073f3258-a4fe-45b6-8fa4-ae706cfb4ee5"), 1 },
                    { new Guid("a78cea9c-7278-d3b7-8b10-9b34b2339e5a"), "Your body was changed by magic. All pain is reduced greatly. Your body is 75% [1387.5%] more durable. You heal even fatal injuries without help of healing magic. Your natural Health and Mana regeneration is improved by 150% [2775%].", new Guid("124fda9f-701c-726a-820a-8d369832d72f"), 1 },
                    { new Guid("afa2cafd-4681-d085-82a0-b06f35db739b"), "Increases your reflexes and speed by <stats_increase>. Your ability to avoid damage to your vitals when dodging increases. A static <vitality_increase> of this bonus is applied to Vitality.", new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b"), 1 },
                    { new Guid("c6ef3d6a-4fc8-fecd-aa7d-d7835db33abf"), "Increases the defensive capabilities of all ash you control. Increase the ash used to form your armor by up to a static 500%. The additional ash used requires conscious manipulation. You may use Ash Scale Armor to defend willing allies. Amount of required ash dependent on size of the target. You may increase the ash used by another static 500%, reducing your total speed by a static 15% for each 100% of additional increase.", new Guid("5c44ca2c-4a2b-fe06-9ba5-5b514e509a59"), 3 },
                    { new Guid("c82a74db-2bb9-cdcb-930b-d3416b543a3b"), "The strength of your Resistance skills and your wings also benefit from Ash Scale Armor. The Armor is a part of your body. It benefits from natural regeneration. You can feel through your armor and you can heal it. Your Ash Scale Armor repairs minor damage on its own. If you armor is penetrated to the lowest layer, an explosion of heated smoke and volcanic glass is released at your enemy if you do not suppress the effect.", new Guid("5c44ca2c-4a2b-fe06-9ba5-5b514e509a59"), 2 },
                    { new Guid("c9d82084-ab60-5935-b280-c88e5ceed4a1"), "You may choose to use Cosmic Deconstruction as a non intrusive attack, instead sending out a broad wave of deconstructing energy from you at the center. The same motion requirements as in the first tier apply. If used as a wave, the range of Cosmic Deconstruction is equal to the range of your domain and is more effective against magical constructs.", new Guid("d3cad15f-3531-d853-ac13-22e7a0dd4f58"), 3 },
                    { new Guid("ce6079af-31f5-7fcb-a2a1-1f6d97d6c6de"), "The Primordial Flame flows through your veins, increasing your resilience by <resilience_increase> 75% [1762.5%]. Increases your physical damage resistance by 15% [352.5%]. Increases your magic damage resistance by 15% [352.5%]. You won’t be fazed anymore by heavy damage or powerful sources of light and sound. Your natural regeneration can heal any injury.", new Guid("6bef7f20-7c71-d402-994e-0d6080b02029"), 1 },
                    { new Guid("d3c2e457-f8fc-d224-b270-6580c45b681f"), "You have delved into the secrets of creation. Inside of your reality, you are not part of the Fabric, but you have learned to navigate through the mesh, and you have learned how to affect the true fabric with all that you can form. While Sunbound Creation is active, you gain the following benefits:\r\n- Your space manipulation of frameworks outside of your creation is vastly improved.\r\n- Your vision is no longer distorted, but clear, if you will it so.\r\n- The Primordial Flame burns at your will, vastly improved and burning with the very heat of the stars\r\n- You may use every spell within your Sunbound Creation. Limitations exist in regards to movement and teleportation of yourself.\r\n- You learn to move at a slow pace through the fabric, pushing your creation through known reality.", new Guid("6a0b5b10-678d-f128-a606-f05f175e174f"), 4 },
                    { new Guid("d4e79724-fcce-7efd-801e-29a1b003d195"), "You have healed yourself thousands of times. Have regrown lost limbs, have reformed lost organs. You have healed and protected your mind, all in pursuit of greater power. Healing to shield you. Healing to allow an exchange of blows, with those you would not otherwise be able to fight. A core ability for the Azarinth Healer, a terrifying tool for the Cosmic Immortal. You have grasped the true nature of Reconstruction. Not the healing spell of a savior, but a necessity for the battle healer you have become. Through the fourth tier, you have enhanced this ability to the pinnacle. Once active, cosmic energies will surge within your body. Not to heal wounds you have sustained, but to keep you fighting whatever enemy you face. To overwhelm the foes no other could dare stand against.\r\nIf you reach 0 points of health, all remaining mana is used to activate True Reconstruction, containing your essence in a set of powerful cosmic barriers protecting your remains from harm and restoring your life. This effect may activate once every 24 hours.\r\nFollowing benefits and changes will apply during use of the fourth tier:\r\n- All damage sustained is dealt to your mana instead of your health\r\n- The first stage of True Reconstruction will generate additional mana and health\r\n- All mana generation and absorption is doubled\r\n- Your body is pushed to the limits of cosmic power, enhancing all of your abilities\r\n- Your body sustains heavy damage from this flow of cosmic power. This ability will deactivate when your health drops below a certain point [1% - Set value] and cannot be used again for twice as long as it has been active\r\n- Once the 4th tier deactivates, a set of seven cosmic barriers appear around you to protect from enemy blows. You may control these barriers or allow them to automatically react to enemy attacks\r\n- You cannot use the third tier of True Reconstruction on your own body", new Guid("fe083405-3dd9-fb39-b3df-b8074e11b0bb"), 4 },
                    { new Guid("d7b1e0d9-a646-f409-ae22-8466d75e610f"), "Bring upon your enemies, the power of the suns themselves, burning away your health in the exchange for devastating light, heat, and energy. Your flames are limitless and form at your will. All of your spells and your body are infused with the Primordial Flame, dealing lingering damage to all within the fabric. You are immune to stunning, fear, and shout abilities. Your resilience is increased by 100% [2350%]", new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1"), 1 },
                    { new Guid("dcb61632-6e21-d20f-a5a2-181f9ee9a314"), "Further understanding of the spatial fabric allows you to manipulate its forces with greater ease and higher intensity. You learn to perceive even the tiniest ripples in space. In the case of active fissures, you find yourself able to peer into the other side. You gain the ability to anchor a spatial pocket to your very essence. Storage increases with the skill’s level. You gain the ability to glimpse through the fabric at any anchors you have set within.", new Guid("ae94e0c9-1fa7-f167-b836-ddeaea261b5c"), 2 },
                    { new Guid("de562001-4975-6a51-a8f1-af4edff6dacb"), "Create ash, smoke, and volcanic glass in a certain radius around you.", new Guid("47510d1e-864d-515c-928e-449533a609ac"), 1 },
                    { new Guid("e2b73245-4780-7045-9a0e-93a7fff56fef"), "You are one with Ash and Heat, your creations blotting out the very suns.", new Guid("932d79fd-8896-497a-b012-8271b421e66b"), 1 },
                    { new Guid("ea21b897-c65b-c61a-a643-7695408f6ede"), "Shape and form your wings to your liking, now directly affected by your control. An added tail shall make you one with the skies above, not a mere human imitating flight but one who revels in it. You may charge your wings with mana and stamina to dramatically increase your flight velocity at the cost of heavily reduced control. Your resilience is increased greatly during a charged flight. If wings are active, this charge may be applied to created magical constructs for a vast increase in the velocity of projectiles. Resilience bonuses do not apply to such constructs.", new Guid("9a9ba5ac-05c7-e681-a4dc-118abd9b17ae"), 3 },
                    { new Guid("ea807c7c-8b28-46d9-a0ad-9999943f915f"), "The magic of the cosmos settles inside your body. Your resistance to magical, physical, and soul damage is increased by a static 35% [647.5%]. Your bones and muscles are five times as dense.", new Guid("124fda9f-701c-726a-820a-8d369832d72f"), 2 },
                    { new Guid("f27c3b9d-8089-f349-99b9-1c45cc363599"), "You are one with the Arcane. The skill’s upkeep has been removed. A static <wisdom_increase> of the base effect is applied to Wisdom. Does not affect the mana regeneration properties of the Wisdom stat.", new Guid("04183509-32e3-609c-a851-cf9d1e454b01"), 3 },
                    { new Guid("f7200964-30a7-fccc-bf8b-716d33b733b3"), "The longer you fight with Draconic Core active, the deeper it roots. Each second of fighting adds 1% more power to the skill with a maximum of a static [250%]. Once no longer engaged in battle, 1% of additionally generated power is lost per second.", new Guid("6867a632-b599-5d58-9898-1542221b7bce"), 2 },
                    { new Guid("f828ad21-2234-f155-a4d6-ed5d5bafac59"), "Heat glows within you, raising your resilience, speed, Strength, Intelligence and Dexterity by <stats_increase>. Your learn how to generate and store vast amounts of heat within your Draconic Core or your magical constructs.", new Guid("6867a632-b599-5d58-9898-1542221b7bce"), 1 },
                    { new Guid("fbadbcb6-217c-4d19-bce7-19c422e707d8"), "Eternal Brawling consists of more than offense alone. A true brawler knows when to stand and let an enemy strike. You gain knowledge about sustained injuries and damage from incoming attacks as they happen.", new Guid("393dc4f1-4e4c-c6a8-97e0-abd942d77a07"), 3 },
                    { new Guid("ff7fe17d-1458-f0fd-bbea-75e8dfc91687"), "Getting used to fighting in close quarters, your reaction time is increased to accommodate your increasing speed and control. Your bones are steeped with mana, increasing both their weight and resilience two fold.", new Guid("393dc4f1-4e4c-c6a8-97e0-abd942d77a07"), 2 },
                    { new Guid("ffa9c9c9-0a59-ff9e-864b-41edd49eaa4e"), "Your element manipulation skills are improved by a static 100% when used within your dominion. Improves any of your mana absorption or drain abilities within your domain.", new Guid("f805ffdd-3dc6-fc5f-8f4d-7270fbca6df1"), 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_CharacterClasses_CharacterClassId",
                table: "Skills",
                column: "CharacterClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillVariables_Skills_SkillId",
                table: "SkillVariables",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_CharacterClasses_CharacterClassId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillVariables_Skills_SkillId",
                table: "SkillVariables");

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("1b8af906-2278-f55c-b9d2-1d3bac80f41a") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("47510d1e-864d-515c-928e-449533a609ac") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("6867a632-b599-5d58-9898-1542221b7bce") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("6a0b5b10-678d-f128-a606-f05f175e174f") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("6bef7f20-7c71-d402-994e-0d6080b02029") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("84dd85c6-8c89-c23f-b392-eeab48d0a42d") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"), new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("572ba72e-87df-45bf-9496-a2b9d8962c7d"), new Guid("393dc4f1-4e4c-c6a8-97e0-abd942d77a07") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("65728378-090f-4c29-9e87-b282f489d028"), new Guid("f805ffdd-3dc6-fc5f-8f4d-7270fbca6df1") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("04183509-32e3-609c-a851-cf9d1e454b01") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("124fda9f-701c-726a-820a-8d369832d72f") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("2653c99d-8cdf-55b5-be26-0b8b91df042d") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("d3cad15f-3531-d853-ac13-22e7a0dd4f58") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("f805ffdd-3dc6-fc5f-8f4d-7270fbca6df1") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("fe083405-3dd9-fb39-b3df-b8074e11b0bb") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("124fda9f-701c-726a-820a-8d369832d72f") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("6a0b5b10-678d-f128-a606-f05f175e174f") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("d3cad15f-3531-d853-ac13-22e7a0dd4f58") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("fe083405-3dd9-fb39-b3df-b8074e11b0bb") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("1b8af906-2278-f55c-b9d2-1d3bac80f41a") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("47510d1e-864d-515c-928e-449533a609ac") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("5c44ca2c-4a2b-fe06-9ba5-5b514e509a59") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("6867a632-b599-5d58-9898-1542221b7bce") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("84dd85c6-8c89-c23f-b392-eeab48d0a42d") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("932d79fd-8896-497a-b012-8271b421e66b") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("9a9ba5ac-05c7-e681-a4dc-118abd9b17ae") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"), new Guid("f9b1c17e-d87a-dc9c-a22d-5fdbad8358a5") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("04183509-32e3-609c-a851-cf9d1e454b01") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("124fda9f-701c-726a-820a-8d369832d72f") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("1b8af906-2278-f55c-b9d2-1d3bac80f41a") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("2653c99d-8cdf-55b5-be26-0b8b91df042d") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("393dc4f1-4e4c-c6a8-97e0-abd942d77a07") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("5c44ca2c-4a2b-fe06-9ba5-5b514e509a59") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("6867a632-b599-5d58-9898-1542221b7bce") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("6bef7f20-7c71-d402-994e-0d6080b02029") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("9a9ba5ac-05c7-e681-a4dc-118abd9b17ae") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("ae94e0c9-1fa7-f167-b836-ddeaea261b5c") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("b319ea2f-9114-7df6-9f79-5b2710c64f97") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("c44ce21f-7e2e-d03d-aefe-ea2a495d9918") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("c709eef2-c332-cfa3-9e8f-51b0738591a7") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("f9b1c17e-d87a-dc9c-a22d-5fdbad8358a5") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), new Guid("04183509-32e3-609c-a851-cf9d1e454b01") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), new Guid("6867a632-b599-5d58-9898-1542221b7bce") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), new Guid("f805ffdd-3dc6-fc5f-8f4d-7270fbca6df1") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("6a0b5b10-678d-f128-a606-f05f175e174f") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("6bef7f20-7c71-d402-994e-0d6080b02029") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("8f4de75d-29e4-7ee9-8668-714edd543167") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("ae94e0c9-1fa7-f167-b836-ddeaea261b5c") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"), new Guid("b094f1b0-5b8a-fd1a-b8cb-7062837f1f70") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("f8362bfc-6004-43df-827f-17f21203c6f3"), new Guid("073f3258-a4fe-45b6-8fa4-ae706cfb4ee5") });

            migrationBuilder.DeleteData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("4a946992-0a7d-7e6f-b87b-4e877bd63cc6"));

            migrationBuilder.DeleteData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("4aeb210e-5ec2-661a-b399-65ad06c77db6"));

            migrationBuilder.DeleteData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("55c9daff-9df8-e8db-bd29-5ac70617eaaf"));

            migrationBuilder.DeleteData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("6708123a-3f38-f102-9f3d-07aef4f3760e"));

            migrationBuilder.DeleteData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("76cb43f2-094d-7e93-a698-4a8fef206d60"));

            migrationBuilder.DeleteData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("bccc1c4b-c86b-eb97-871c-a027383caa5c"));

            migrationBuilder.DeleteData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("eacd6d98-b4d1-e88a-aa2f-f21710f90fab"));

            migrationBuilder.DeleteData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("f4008345-108e-5fb5-b697-b4d1bd02712e"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("068bf9bf-6b3f-f5c2-9047-b8249f9215c2"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("07e7b3ca-74df-7e4e-ab26-aa51aa4e947f"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("096abe96-c853-d910-b1f0-08c87dcee82a"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("09b31c14-9df3-44cf-b0c3-49d7069ed870"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("0a1e1b87-3f92-5282-aab3-e4303c1aa457"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("0ddfa7c4-8d9f-e8ce-a31a-1877acb2b765"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("18f789f5-c4ca-f6f3-bfee-1d4a3cc6f4a0"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("192b7f5f-96aa-42ca-a8a5-6e863c0a5582"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("19637103-c9a6-729f-9d30-908ef6ba3c0e"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("1a42c346-1e75-de2d-89fd-c9648feab18a"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("1bc0cec8-4c80-c4d9-aa45-bcb96aad549a"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("1dbb61b1-7e31-de9b-9c3a-c2a3e41078b8"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("1f6aca0d-a5b6-dce9-bee6-4d4fcad987f9"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("219ff2a7-8fe6-427e-9243-c675d3d1d9bf"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("240237b3-cef2-ec3b-b24c-2b4c3d599a97"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("2877767d-5a15-fa0e-bfb1-d4be1610f94f"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("291407cc-1627-e15d-a762-a7226894a333"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("319ce442-288c-5082-90c9-493f98815b6c"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("335ace47-817c-dbcc-b84f-337ae17ab55a"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("355c0a74-b530-da78-9c26-752b2e6ac086"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("358a78f9-e1e3-f77b-b0ee-36033962e4e7"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("3ae0a554-f727-ee84-9752-5ec4ee1fc939"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("3b3d2df7-6345-c7c9-802e-8a5fb10deacd"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("3c55975d-f536-60f6-853c-1966e4ed1bd6"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("40412425-5047-7117-8c76-fff960024aa6"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("42e9bea0-4759-def3-a848-6f1cb832aa0a"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("449dfd43-9554-4d15-a358-fa46ab927c73"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("44e53c0b-5ac1-419f-85dc-c5fd60a47352"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("46a80a7b-4bcd-e808-9c21-05d0c0c764ee"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("4ec031fd-a1b8-cbbc-b818-e9c5a6393da9"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("5618fb37-dc76-73ab-af4e-cb36a4ab0740"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("5846ad71-bd86-f40b-9ea9-79eee236660f"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("5957b8f6-e03c-561a-85f9-1d55be8cab73"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("60d96527-1472-53dc-8d08-1fb70c76f10a"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("666c91d8-ed80-c9bf-ae56-7e2479780065"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("6a5db6b6-e21b-4cf2-a261-fb4207a1e2c9"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("6d67ea18-2888-df52-9403-5ddc2d89404d"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("6dfd3998-4945-5305-b856-7dd4f008b727"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("70e04ac0-1eda-6658-9eb3-229c2f3ba2c5"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("70e84c30-61da-f0be-b19e-9873fdadfa9f"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("70ff3b61-0e86-4267-942e-92173e928c1f"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("7a119d75-aa04-73aa-a860-3fc4853cf813"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("7e89e93f-db6b-59bf-b0f5-0921d45d2f3e"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("7ec886af-0dea-de3f-98b1-daece0ab459a"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("7f94fb54-0f8e-5e26-ac84-08c96a55a021"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("83af78b2-e824-f419-8085-ef271ad1d87e"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("852f39a5-faaf-f4c1-a242-c9ab4e700844"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("86403491-f224-c030-baab-20e34557c785"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("8c29ec68-bf9e-c96b-93c9-51dc4f64d6fe"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("8c7b9a59-3fa8-5e3c-8bcd-65871db28fcb"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("9445f404-c483-c5ce-bcb5-5e9335942354"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("94ec4204-abad-ca4d-a680-3ff07b632e06"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("98abd6b8-61a5-40a8-821a-207fb04bbb68"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("9a25cdce-1f62-74f3-8864-57465647ec79"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("a0aa3129-3a8a-4f68-b903-dd1b11f7ac91"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("a1ca5b32-004a-5052-83c6-201875906f7d"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("a1cb4b09-fc50-c462-99c5-cca6679d2a2d"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("a2461a26-4320-6c5a-88a2-26a09a93909f"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("a323d2bc-4654-c379-8147-f003fe10ae88"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("a757170d-e3cf-f018-8ef0-9bd22e076fc3"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("a77cbedf-abbb-c665-9d33-e5fc216494f7"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("a78cea9c-7278-d3b7-8b10-9b34b2339e5a"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("afa2cafd-4681-d085-82a0-b06f35db739b"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("c6ef3d6a-4fc8-fecd-aa7d-d7835db33abf"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("c82a74db-2bb9-cdcb-930b-d3416b543a3b"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("c9d82084-ab60-5935-b280-c88e5ceed4a1"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("ce6079af-31f5-7fcb-a2a1-1f6d97d6c6de"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("d3c2e457-f8fc-d224-b270-6580c45b681f"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("d4e79724-fcce-7efd-801e-29a1b003d195"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("d7b1e0d9-a646-f409-ae22-8466d75e610f"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("dcb61632-6e21-d20f-a5a2-181f9ee9a314"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("de562001-4975-6a51-a8f1-af4edff6dacb"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("e2b73245-4780-7045-9a0e-93a7fff56fef"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("ea21b897-c65b-c61a-a643-7695408f6ede"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("ea807c7c-8b28-46d9-a0ad-9999943f915f"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("f27c3b9d-8089-f349-99b9-1c45cc363599"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("f7200964-30a7-fccc-bf8b-716d33b733b3"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("f828ad21-2234-f155-a4d6-ed5d5bafac59"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("fbadbcb6-217c-4d19-bce7-19c422e707d8"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("ff7fe17d-1458-f0fd-bbea-75e8dfc91687"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("ffa9c9c9-0a59-ff9e-864b-41edd49eaa4e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("04183509-32e3-609c-a851-cf9d1e454b01"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("073f3258-a4fe-45b6-8fa4-ae706cfb4ee5"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("124fda9f-701c-726a-820a-8d369832d72f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("1b8af906-2278-f55c-b9d2-1d3bac80f41a"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2653c99d-8cdf-55b5-be26-0b8b91df042d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("393dc4f1-4e4c-c6a8-97e0-abd942d77a07"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("47510d1e-864d-515c-928e-449533a609ac"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("51704072-1f1c-c216-981f-19ff7b25cdd1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5c44ca2c-4a2b-fe06-9ba5-5b514e509a59"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("6867a632-b599-5d58-9898-1542221b7bce"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("6a0b5b10-678d-f128-a606-f05f175e174f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("6bef7f20-7c71-d402-994e-0d6080b02029"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("84dd85c6-8c89-c23f-b392-eeab48d0a42d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("8f4de75d-29e4-7ee9-8668-714edd543167"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("932d79fd-8896-497a-b012-8271b421e66b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9685407f-a27c-758d-8e36-58f2b30c4b2b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9a9ba5ac-05c7-e681-a4dc-118abd9b17ae"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("ae94e0c9-1fa7-f167-b836-ddeaea261b5c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b094f1b0-5b8a-fd1a-b8cb-7062837f1f70"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b319ea2f-9114-7df6-9f79-5b2710c64f97"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c44ce21f-7e2e-d03d-aefe-ea2a495d9918"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c709eef2-c332-cfa3-9e8f-51b0738591a7"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("d3cad15f-3531-d853-ac13-22e7a0dd4f58"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("f805ffdd-3dc6-fc5f-8f4d-7270fbca6df1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("f9b1c17e-d87a-dc9c-a22d-5fdbad8358a5"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("fe083405-3dd9-fb39-b3df-b8074e11b0bb"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillId",
                table: "SkillVariables",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CharacterClassId",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "CharacterStatuses",
                keyColumn: "Id",
                keyValue: new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 4, 12, 27, 42, 453, DateTimeKind.Unspecified).AddTicks(4056), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_CharacterClasses_CharacterClassId",
                table: "Skills",
                column: "CharacterClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillVariables_Skills_SkillId",
                table: "SkillVariables",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");
        }
    }
}
