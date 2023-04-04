using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Progress.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddSkillsToSeededClass : Migration
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
                value: new DateTimeOffset(new DateTime(2023, 4, 4, 14, 13, 15, 976, DateTimeKind.Unspecified).AddTicks(3422), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CharacterClassId", "Enhanced", "Level", "Name", "Tier", "Type" },
                values: new object[,]
                {
                    { new Guid("2c8b0955-013f-5453-b0e8-843725a1587e"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Embodiment of the Arcane", 3, 0 },
                    { new Guid("3302cea7-668b-4275-81df-e22dd8ad36f3"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Cosmic Deconstruction", 3, 0 },
                    { new Guid("44523004-a916-44bd-8593-14649a52bb4d"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), false, 30, "Eternal Huntress", 3, 1 },
                    { new Guid("573f7b5f-c131-4786-8eb4-b9014aa88224"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 1, "True Reconstruction", 4, 0 },
                    { new Guid("7c893d4b-246d-c304-9198-49a886554a85"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Catalyst Core", 3, 1 },
                    { new Guid("8340dbd8-311f-7131-97cb-a4d38bfaaeca"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Timeless Perception", 3, 1 },
                    { new Guid("9e6f3616-a2b1-7643-b9f3-713c472f9dee"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Limitless Domain", 3, 0 },
                    { new Guid("a9050e0d-59c4-eded-868e-1db3ef6d8219"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Cycle of Creation", 3, 1 },
                    { new Guid("c225634f-97c8-c659-97f2-629c12199f07"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), false, 30, "Eternal Brawling", 3, 1 },
                    { new Guid("e8b05991-c7f1-faf9-91e1-d525370c912c"), new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"), true, 30, "Teleportation", 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "CategorySkill",
                columns: new[] { "CategoriesId", "SkillsId" },
                values: new object[,]
                {
                    { new Guid("572ba72e-87df-45bf-9496-a2b9d8962c7d"), new Guid("c225634f-97c8-c659-97f2-629c12199f07") },
                    { new Guid("65728378-090f-4c29-9e87-b282f489d028"), new Guid("9e6f3616-a2b1-7643-b9f3-713c472f9dee") },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("2c8b0955-013f-5453-b0e8-843725a1587e") },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("3302cea7-668b-4275-81df-e22dd8ad36f3") },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("573f7b5f-c131-4786-8eb4-b9014aa88224") },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("7c893d4b-246d-c304-9198-49a886554a85") },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("8340dbd8-311f-7131-97cb-a4d38bfaaeca") },
                    { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("9e6f3616-a2b1-7643-b9f3-713c472f9dee") },
                    { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("3302cea7-668b-4275-81df-e22dd8ad36f3") },
                    { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("573f7b5f-c131-4786-8eb4-b9014aa88224") },
                    { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("7c893d4b-246d-c304-9198-49a886554a85") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("2c8b0955-013f-5453-b0e8-843725a1587e") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("44523004-a916-44bd-8593-14649a52bb4d") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("7c893d4b-246d-c304-9198-49a886554a85") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("8340dbd8-311f-7131-97cb-a4d38bfaaeca") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("a9050e0d-59c4-eded-868e-1db3ef6d8219") },
                    { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("c225634f-97c8-c659-97f2-629c12199f07") },
                    { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), new Guid("2c8b0955-013f-5453-b0e8-843725a1587e") },
                    { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), new Guid("9e6f3616-a2b1-7643-b9f3-713c472f9dee") },
                    { new Guid("f8362bfc-6004-43df-827f-17f21203c6f3"), new Guid("e8b05991-c7f1-faf9-91e1-d525370c912c") }
                });

            migrationBuilder.InsertData(
                table: "SkillVariables",
                columns: new[] { "Id", "BaseValue", "BaseVariableName", "CategoryCalculationType", "Name", "SkillId", "Unit", "VariableCalculationType" },
                values: new object[,]
                {
                    { new Guid("bc45890e-5397-5d1a-9666-afde67a9c7ea"), 25, "stats_increase", 1, "wisdom_increase", new Guid("2c8b0955-013f-5453-b0e8-843725a1587e"), "%", 3 },
                    { new Guid("d1fb8625-1c43-d417-b348-9188627e0039"), 100, null, 1, "stats_increase", new Guid("2c8b0955-013f-5453-b0e8-843725a1587e"), "%", 1 }
                });

            migrationBuilder.InsertData(
                table: "TierDescriptions",
                columns: new[] { "Id", "Description", "SkillId", "Tier" },
                values: new object[,]
                {
                    { new Guid("0af7d155-74d7-f64c-811d-78967b0a6586"), "Vastly increases your perception and reflexes.", new Guid("8340dbd8-311f-7131-97cb-a4d38bfaaeca"), 0 },
                    { new Guid("13c6338f-9536-d44b-9fe5-513a4e7c278c"), "Eternal Brawling consists of more than offense alone. A true brawler knows when to stand and let an enemy strike. You gain knowledge about sustained injuries and damage from incoming attacks as they happen.", new Guid("c225634f-97c8-c659-97f2-629c12199f07"), 2 },
                    { new Guid("1bd0238a-1404-5ec0-a614-7ecd1cd9aee5"), "Your element manipulation skills are improved by a static 100% when used within your dominion. Improves any of your mana absorption or drain abilities within your domain.", new Guid("9e6f3616-a2b1-7643-b9f3-713c472f9dee"), 2 },
                    { new Guid("21dd3291-fe0f-5da8-86a7-3e6b5f64ea93"), "Through Azarinth magic, you may mark an enemy or ally with the Eternal Mark. Allies may use the mark to send a short message to the Arcane Eternal once per day. The Arcane Eternal can send a short message to each non forcefully applied mark once per day. Each level in the third tier adds two additional marks that can be used. Marks forcefully applied have a limited duration.", new Guid("44523004-a916-44bd-8593-14649a52bb4d"), 2 },
                    { new Guid("241a8992-f096-5b79-89f4-78faee6171e5"), "Huntress turned Eternal. Your eyes are unmatched and so is your nose. Perceive the smallest irregularities in your surroundings as well as the ambient mana to find clues about your target’s whereabouts. Perceive the trails of dangerous prey.", new Guid("44523004-a916-44bd-8593-14649a52bb4d"), 0 },
                    { new Guid("418575d1-af0a-fbdf-8342-05a04eff4669"), "Send a healing pulse of cosmic power into yourself or creatures within your domain. This skill can be channeled. In addition to health, True Reconstruction restores mana and heals damage to your soul.", new Guid("573f7b5f-c131-4786-8eb4-b9014aa88224"), 0 },
                    { new Guid("4936c8dd-2a26-6e34-85b3-361bec90a47b"), "Your body glows with the power of the cosmos, increasing your resilience, speed, Intelligence, and Strength by <stats_increase>.", new Guid("2c8b0955-013f-5453-b0e8-843725a1587e"), 0 },
                    { new Guid("4ddda253-7eb1-5660-a823-819834356edb"), "You may choose to use Cosmic Deconstruction as a non intrusive attack, instead sending out a broad wave of deconstructing energy from you at the center. The same motion requirements as in the first tier apply. If used as a wave, the range of Cosmic Deconstruction is equal to the range of your domain and is more effective against magical constructs.", new Guid("3302cea7-668b-4275-81df-e22dd8ad36f3"), 2 },
                    { new Guid("5e631c2d-3bf0-f06b-94e9-d700ae12aa70"), "Your body was changed by magic. All pain is reduced greatly. Your body is 75% [1387.5%] more durable. You heal even fatal injuries without help of healing magic. Your natural Health and Mana regeneration is improved by 150% [2775%].", new Guid("7c893d4b-246d-c304-9198-49a886554a85"), 0 },
                    { new Guid("6b34230d-8f62-ea19-a653-74387cb50011"), "Getting used to fighting in close quarters, your reaction time is increased to accommodate your increasing speed and control. Your bones are steeped with mana, increasing both their weight and resilience two fold.", new Guid("c225634f-97c8-c659-97f2-629c12199f07"), 1 },
                    { new Guid("790c0229-a574-c24f-9889-b7c5a5fb6635"), "You may have both the original and reversed aspects activated at the same time. When an enemy partially or fully resists either Cosmic Deconstruction or True Reconstruction, you absorb the dissipating mana.", new Guid("a9050e0d-59c4-eded-868e-1db3ef6d8219"), 1 },
                    { new Guid("988e506d-2e2b-70d1-a511-a7619e378ae1"), "Arcane dominion opens your senses to the arcane. A paramount skill both on and off the battlefield. Elements and spells you control within your dominion have increased harmony. You drain the remaining mana from creatures you kill inside of your domain.", new Guid("9e6f3616-a2b1-7643-b9f3-713c472f9dee"), 1 },
                    { new Guid("a25a83ba-9204-6a25-92d8-9911e43de6fa"), "Your resilience and speed is doubled during the spike in perception. Increases usage to five times per hour. The effect duration is increased to three seconds and can be activated at will. You gain the ability to gauge enemy mana usage and may learn how strongly a direct hit of a spell will impact you. Increased ability to gauge incoming damage depending on your familiarity with the respective magic type.", new Guid("8340dbd8-311f-7131-97cb-a4d38bfaaeca"), 2 },
                    { new Guid("a4e646d4-ddd0-5cbb-afa3-e6e378ddca1a"), "Your sight, hearing and sense of smell is also affected by Embodiment of the Arcane.", new Guid("2c8b0955-013f-5453-b0e8-843725a1587e"), 1 },
                    { new Guid("aa1bf3e6-8d3d-d9c3-85de-994083b25ed6"), "The amount of mana used per pulse can be regulated with a maximum of 5000 mana per pulse. You may charge each pulse with 5000 mana per second to a maximum of 25000 mana. Once cosmic power resides within a target, you can rip it out with a reversed motion to cause additional damage. Cosmic power within a target stacks, depending on their defensive measures and structure.", new Guid("3302cea7-668b-4275-81df-e22dd8ad36f3"), 1 },
                    { new Guid("be1dafb2-60dd-f37c-8cea-89e6cfb1a489"), "You have learned of Cosmic Deconstruction and True Reconstruction. Now you will learn of their Reversal.\r\nUpon activation, Cosmic Deconstruction will send a part of the struck enemy’s health and mana into yourself. No mana will be released on impact, rendering Cosmic Deconstruction’s offensive potential to zero.\r\nUpon activation, True Reconstruction will send a destructive force of channeled mana into yourself, a creature or magical construct within your domain, the healing aspects are reduced to zero.", new Guid("a9050e0d-59c4-eded-868e-1db3ef6d8219"), 0 },
                    { new Guid("c0136e61-f935-e3b0-b8d7-0d5f2aab376a"), "The time between transfers is reduced greatly. No ground contact needed between transfers. Teleportation gains 3 charges, each with a separate cooldown. For 2 seconds after Teleportation is used, you may return to the original position in the fabric where the spell was initially activated.", new Guid("e8b05991-c7f1-faf9-91e1-d525370c912c"), 1 },
                    { new Guid("c0bcf18e-d71b-771d-87f4-c011c0bac18d"), "Timeless Perception spikes for two seconds, should you be about to receive a blow that would take 50% or more of your health, or should your mind be incapacitated with an incoming blow. This can happen only once per hour.", new Guid("8340dbd8-311f-7131-97cb-a4d38bfaaeca"), 1 },
                    { new Guid("c2e9b624-7d81-4052-b8ae-47196a55f8b7"), "Immediately appear anywhere in your domain or anywhere you can see with reliable clarity.", new Guid("e8b05991-c7f1-faf9-91e1-d525370c912c"), 0 },
                    { new Guid("c43f0039-1859-f115-89bd-11cce7b380f6"), "You are one with the Arcane. The skill’s upkeep has been removed. A static <wisdom_increase> of the base effect is applied to Wisdom. Does not affect the mana regeneration properties of the Wisdom stat.", new Guid("2c8b0955-013f-5453-b0e8-843725a1587e"), 2 },
                    { new Guid("d33a7d6c-37b9-6bab-a900-c5d931fcf99a"), "Send a pulse of deconstructing cosmic power into an object, spell, or creature within your domain with every motion using your arms, fists, fingers, legs, feet, or head. Your Intelligence stat enhances the damage potential.", new Guid("3302cea7-668b-4275-81df-e22dd8ad36f3"), 0 },
                    { new Guid("ddbd2bce-3b0a-54ed-9529-2f298941cfcd"), "You have adapted the fighting style of the Azarinth school to something you now call your own. Damage inflicted with your own body and related skills is 110% [990%] higher. Your arms, fists, fingers, legs, and head deal a slight amount of arcane damage with each strike.", new Guid("c225634f-97c8-c659-97f2-629c12199f07"), 0 },
                    { new Guid("decc6a24-5bfd-4526-a9a8-34d5656c6450"), "The magic of the cosmos settles inside your body. Your resistance to magical, physical, and soul damage is increased by a static 35% [647.5%]. Your bones and muscles are five times as dense.", new Guid("7c893d4b-246d-c304-9198-49a886554a85"), 1 },
                    { new Guid("df9b38f1-387c-fd76-b8f9-fbb8fe7551a2"), "You have healed yourself thousands of times. Have regrown lost limbs, have reformed lost organs. You have healed and protected your mind, all in pursuit of greater power. Healing to shield you. Healing to allow an exchange of blows, with those you would not otherwise be able to fight. A core ability for the Azarinth Healer, a terrifying tool for the Cosmic Immortal. You have grasped the true nature of Reconstruction. Not the healing spell of a savior, but a necessity for the battle healer you have become. Through the fourth tier, you have enhanced this ability to the pinnacle. Once active, cosmic energies will surge within your body. Not to heal wounds you have sustained, but to keep you fighting whatever enemy you face. To overwhelm the foes no other could dare stand against.\r\nIf you reach 0 points of health, all remaining mana is used to activate True Reconstruction, containing your essence in a set of powerful cosmic barriers protecting your remains from harm and restoring your life. This effect may activate once every 24 hours.\r\nFollowing benefits and changes will apply during use of the fourth tier:\r\n- All damage sustained is dealt to your mana instead of your health\r\n- The first stage of True Reconstruction will generate additional mana and health\r\n- All mana generation and absorption is doubled\r\n- Your body is pushed to the limits of cosmic power, enhancing all of your abilities\r\n- Your body sustains heavy damage from this flow of cosmic power. This ability will deactivate when your health drops below a certain point [1% - Set value] and cannot be used again for twice as long as it has been active\r\n- Once the 4th tier deactivates, a set of seven cosmic barriers appear around you to protect from enemy blows. You may control these barriers or allow them to automatically react to enemy attacks\r\n- You cannot use the third tier of True Reconstruction on your own body", new Guid("573f7b5f-c131-4786-8eb4-b9014aa88224"), 3 },
                    { new Guid("e128a92f-5c38-d0a8-8675-1878d757135d"), "You may set ten destinations you touch. You may change each destination once per day. This cooldown is static. You may travel to each destination once every 25 minutes [12.5 minutes]. Cast time is reduced by a static 50% for destinations you have already teleported to.", new Guid("e8b05991-c7f1-faf9-91e1-d525370c912c"), 2 },
                    { new Guid("e454dd96-a075-757f-a4d2-5bc3707e1461"), "Perceive everything in a sphere around you while this skill is activated. The higher the level the further your domain reaches. You may drain mana from creatures and spells within your domain.", new Guid("9e6f3616-a2b1-7643-b9f3-713c472f9dee"), 0 },
                    { new Guid("ed178ddc-382e-54c1-85ee-c78c31d936d6"), "You gain a sense for the distress in the people around you. Amplify this by sacrificing mana. You gain a sense for the arcane, feeling even minor spells around you. As you practice to differentiate these spells, you will learn of their intent.", new Guid("44523004-a916-44bd-8593-14649a52bb4d"), 1 },
                    { new Guid("ef19f675-4468-f513-976d-ee4e447e3dd0"), "Healing, power, resilience and speed. All requires balance. Your respective Deconstruction and Reconstruction spells have their potency increased by a static 25% of your median stat value. [488.75%]. You may channel health in addition to mana into the respective offensive uses of Archon Strike and Sentinel Reconstruction. Health cost to activate effects is reduced by a static 20%.", new Guid("a9050e0d-59c4-eded-868e-1db3ef6d8219"), 2 },
                    { new Guid("fbf2babb-dab1-dcce-b97d-83c2de127e78"), "Your control is increased greatly, you can now focus your healing on specific parts of the body. As long as mana and health remains, your True Reconstruction will restore your body. Lose your head and see for yourself! Health loss and critical blows are recalculated due to the nature of your healing. You may restore magical constructs and enchantments with True Reconstruction.", new Guid("573f7b5f-c131-4786-8eb4-b9014aa88224"), 1 },
                    { new Guid("fde2e4d4-4b21-d2f1-b7cc-b9d8a31f39c7"), "Your body was battered and forged by magic. You absorb mana from enemy spells in your domain. Efficiency is determined by enemy mana used and your resistance to the type of magic. Mana cost for all skills reduced by a static 35%. Your body can absorb ambient mana. Amount dependent on availability and harmony.", new Guid("7c893d4b-246d-c304-9198-49a886554a85"), 2 },
                    { new Guid("fe06af7a-5aa0-6269-a1c9-c08ea3d528e4"), "You have healed your body time and time again, knowing every cell and where it belongs. Sacrifice a large amount of mana to rush your healing to unprecedented speeds. Lack of knowledge about your body may result in heavy damage. Effect can be used on any creature or magical construct. Limited to 10’000 mana per use.", new Guid("573f7b5f-c131-4786-8eb4-b9014aa88224"), 2 }
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
                keyValues: new object[] { new Guid("572ba72e-87df-45bf-9496-a2b9d8962c7d"), new Guid("c225634f-97c8-c659-97f2-629c12199f07") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("65728378-090f-4c29-9e87-b282f489d028"), new Guid("9e6f3616-a2b1-7643-b9f3-713c472f9dee") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("2c8b0955-013f-5453-b0e8-843725a1587e") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("3302cea7-668b-4275-81df-e22dd8ad36f3") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("573f7b5f-c131-4786-8eb4-b9014aa88224") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("7c893d4b-246d-c304-9198-49a886554a85") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("8340dbd8-311f-7131-97cb-a4d38bfaaeca") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"), new Guid("9e6f3616-a2b1-7643-b9f3-713c472f9dee") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("3302cea7-668b-4275-81df-e22dd8ad36f3") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("573f7b5f-c131-4786-8eb4-b9014aa88224") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"), new Guid("7c893d4b-246d-c304-9198-49a886554a85") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("2c8b0955-013f-5453-b0e8-843725a1587e") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("44523004-a916-44bd-8593-14649a52bb4d") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("7c893d4b-246d-c304-9198-49a886554a85") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("8340dbd8-311f-7131-97cb-a4d38bfaaeca") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("a9050e0d-59c4-eded-868e-1db3ef6d8219") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"), new Guid("c225634f-97c8-c659-97f2-629c12199f07") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), new Guid("2c8b0955-013f-5453-b0e8-843725a1587e") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"), new Guid("9e6f3616-a2b1-7643-b9f3-713c472f9dee") });

            migrationBuilder.DeleteData(
                table: "CategorySkill",
                keyColumns: new[] { "CategoriesId", "SkillsId" },
                keyValues: new object[] { new Guid("f8362bfc-6004-43df-827f-17f21203c6f3"), new Guid("e8b05991-c7f1-faf9-91e1-d525370c912c") });

            migrationBuilder.DeleteData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("bc45890e-5397-5d1a-9666-afde67a9c7ea"));

            migrationBuilder.DeleteData(
                table: "SkillVariables",
                keyColumn: "Id",
                keyValue: new Guid("d1fb8625-1c43-d417-b348-9188627e0039"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("0af7d155-74d7-f64c-811d-78967b0a6586"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("13c6338f-9536-d44b-9fe5-513a4e7c278c"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("1bd0238a-1404-5ec0-a614-7ecd1cd9aee5"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("21dd3291-fe0f-5da8-86a7-3e6b5f64ea93"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("241a8992-f096-5b79-89f4-78faee6171e5"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("418575d1-af0a-fbdf-8342-05a04eff4669"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("4936c8dd-2a26-6e34-85b3-361bec90a47b"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("4ddda253-7eb1-5660-a823-819834356edb"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("5e631c2d-3bf0-f06b-94e9-d700ae12aa70"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("6b34230d-8f62-ea19-a653-74387cb50011"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("790c0229-a574-c24f-9889-b7c5a5fb6635"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("988e506d-2e2b-70d1-a511-a7619e378ae1"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("a25a83ba-9204-6a25-92d8-9911e43de6fa"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("a4e646d4-ddd0-5cbb-afa3-e6e378ddca1a"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("aa1bf3e6-8d3d-d9c3-85de-994083b25ed6"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("be1dafb2-60dd-f37c-8cea-89e6cfb1a489"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("c0136e61-f935-e3b0-b8d7-0d5f2aab376a"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("c0bcf18e-d71b-771d-87f4-c011c0bac18d"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("c2e9b624-7d81-4052-b8ae-47196a55f8b7"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("c43f0039-1859-f115-89bd-11cce7b380f6"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("d33a7d6c-37b9-6bab-a900-c5d931fcf99a"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("ddbd2bce-3b0a-54ed-9529-2f298941cfcd"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("decc6a24-5bfd-4526-a9a8-34d5656c6450"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("df9b38f1-387c-fd76-b8f9-fbb8fe7551a2"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("e128a92f-5c38-d0a8-8675-1878d757135d"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("e454dd96-a075-757f-a4d2-5bc3707e1461"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("ed178ddc-382e-54c1-85ee-c78c31d936d6"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("ef19f675-4468-f513-976d-ee4e447e3dd0"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("fbf2babb-dab1-dcce-b97d-83c2de127e78"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("fde2e4d4-4b21-d2f1-b7cc-b9d8a31f39c7"));

            migrationBuilder.DeleteData(
                table: "TierDescriptions",
                keyColumn: "Id",
                keyValue: new Guid("fe06af7a-5aa0-6269-a1c9-c08ea3d528e4"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2c8b0955-013f-5453-b0e8-843725a1587e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("3302cea7-668b-4275-81df-e22dd8ad36f3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("44523004-a916-44bd-8593-14649a52bb4d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("573f7b5f-c131-4786-8eb4-b9014aa88224"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("7c893d4b-246d-c304-9198-49a886554a85"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("8340dbd8-311f-7131-97cb-a4d38bfaaeca"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9e6f3616-a2b1-7643-b9f3-713c472f9dee"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a9050e0d-59c4-eded-868e-1db3ef6d8219"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c225634f-97c8-c659-97f2-629c12199f07"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e8b05991-c7f1-faf9-91e1-d525370c912c"));

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
