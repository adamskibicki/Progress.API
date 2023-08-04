using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Progress.Application.Persistence.Entities;
using Progress.Application.Usecases.Status.Get;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Progress.Application.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User, ApplicationRole, Guid>
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<CharacterStatus> CharacterStatuses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Stat> Stats { get; set; }

        public DbSet<ClassModifier> ClassModifiers { get; set; }

        public DbSet<CharacterClass> CharacterClasses { get; set; }

        public DbSet<UserCharacter> UserCharacters { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<SkillVariable> SkillVariables { get; set; }

        public DbSet<TierDescription> TierDescriptions { get; set; }

        public DbSet<SkillVariableStat> SkillVariableStats { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SkillVariableStat>()
                .HasKey(svs => new { svs.StatId, svs.SkillVariableId });
            modelBuilder.Entity<SkillVariableStat>()
                .HasOne(svs => svs.Stat)
                .WithMany(s => s.AffectingSkillVariables)
                .HasForeignKey(svs => svs.StatId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SkillVariableStat>()
                .HasOne(svs => svs.SkillVariable)
                .WithMany(sv => sv.AffectedStats)
                .HasForeignKey(svs => svs.SkillVariableId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            var guidGenerator = new SeededGuidGenerator(1501381288);
            var skillVariableGuidGenerator = new SeededGuidGenerator(1501381288);
            var userGuidGenerator = new SeededGuidGenerator(1467393458);

            var testUserId = userGuidGenerator.GetNext();

            string userCharacterId = "0da44e54-90ea-4ad0-a409-ea0cb1d38c4a";

            string characterStatusId = "afa42078-a071-4bea-978e-f439c713848c";

            string healingClassId = "c2782453-16ab-4d52-923d-97c6a2b40029";
            string ashenClassId = "453c74bc-e480-44c2-82ea-13e3e49f821b";
            string spaceClassId = "6689fb11-732c-4fda-af01-abde9895dc16";

            string manaResourceId = "97f54c26-273e-47fc-b00f-7c5ad5b6cfae";

            string vitalityStatId = "1bf1d8dd-7cc3-486d-bb26-0bde4ee439df";
            string enduranceStatId = "ab85915d-e66f-4460-96af-e90f171ccab5";
            string wisdomStatId = "c6474033-2e4c-4805-95f3-4fe22e9de88a";
            string strengthStatId = "de4b423f-4718-4e26-9d75-14f4a1581b37";
            string dexterityStatId = "20cce93e-f883-4860-be2f-4cdbd0c6e3be";
            string intelligenceStatId = "047e7614-496d-4519-a784-6dec5e753571";
            string resilienceStatId = "ec4aaeb2-2caa-43f0-8c44-3c8374d0cb5d";
            string speedStatId = "170c68c3-2261-4063-9460-360144fb9597";
            string reflexesStatId = "6c7beb1c-10bd-4e10-a019-82fb9c24115a";


            PasswordHasher<User> ph = new PasswordHasher<User>();

            var user = new User()
            {
                Id = testUserId,
                Email = "test.test@test",
                NormalizedEmail = "TEST.TEST@TEST",
                UserName = "test",
                EmailConfirmed = false,
                NormalizedUserName = "TEST"
            };
            user.PasswordHash = ph.HashPassword(user, "test12345");

            modelBuilder.Entity<User>()
                .HasData(new List<User>()
                {
                    user
                });
            
            
            #region classes and statuses

            modelBuilder.Entity<CharacterClass>().HasData(new CharacterClass
                {
                    Id = new Guid(healingClassId),
                    CharacterStatusId = new Guid(characterStatusId),
                    Name = "The Cosmic Immortal",
                    Level = 1004,
                },
                new CharacterClass
                {
                    Id = new Guid(ashenClassId),
                    CharacterStatusId = new Guid(characterStatusId),
                    Name = "The Pyroclastic Storm",
                    Level = 1001,
                },
                new CharacterClass
                {
                    Id = new Guid(spaceClassId),
                    CharacterStatusId = new Guid(characterStatusId),
                    Name = "The Sunforged Realmwalker",
                    Level = 1002,
                });

            modelBuilder.Entity<UserCharacter>().HasData(new UserCharacter()
            {
                Id = new Guid(userCharacterId),
                UserId = testUserId
            });

            modelBuilder.Entity<CharacterStatus>().OwnsOne(cs => cs.BasicInformation)
                .HasData(new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Name = "Ilea Spears",
                    Title = "Dragonslayer"
                });

            modelBuilder.Entity<CharacterStatus>().OwnsOne(cs => cs.UnspentSkillpoints)
                .HasData(new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    CoreSkillpoints = 10,
                    FourthTierGeneralSkillpoints = 1,
                    FourthTierSkillpoints = 1,
                    ThirdTierGeneralSkillpoints = 3,
                });

            #endregion

            #region categories

            var bodyEnhancementCategory = new Category
            {
                Id = new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"),
                DisplayColor = "#000000",
                Name = "Body Enhancement",
                UserId = testUserId
            };
            var healingMagicCategory = new Category
            {
                Id = new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"),
                DisplayColor = "#000000",
                Name = "Healing Magic",
                UserId = testUserId
            };
            var cosmicMagicCategory = new Category
            {
                Id = new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"),
                DisplayColor = "#000000",
                Name = "Cosmic Magic",
                UserId = testUserId
            };
            var ashenMagicCategory = new Category
            {
                Id = new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"),
                DisplayColor = "#000000",
                Name = "Ashen Magic",
                UserId = testUserId
            };
            var fireMagicCategory = new Category
            {
                Id = new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"),
                DisplayColor = "#000000",
                Name = "Fire Magic",
                UserId = testUserId
            };
            var spaceMagicCategory = new Category
            {
                Id = new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"),
                DisplayColor = "#000000",
                Name = "Space Magic",
                UserId = testUserId
            };
            var mindMagicCategory = new Category
            {
                Id = new Guid("4538069f-9680-4b26-84a4-e608d1c86606"),
                DisplayColor = "#000000",
                Name = "Mind Magic",
                UserId = testUserId
            };
            var fleshMagicCategory = new Category
            {
                Id = new Guid("f8f302ab-7ed7-47a9-85c1-2d570478a99a"),
                DisplayColor = "#000000",
                Name = "Flesh Magic",
                UserId = testUserId
            };
            var iceMagicCategory = new Category
            {
                Id = new Guid("12696ef5-a857-466f-a618-43ee092816ee"),
                DisplayColor = "#000000",
                Name = "Ice Magic",
                UserId = testUserId
            };
            var lavaMagicCategory = new Category
            {
                Id = new Guid("94cb02e4-43dc-4021-95ac-d9d5bc6512d6"),
                DisplayColor = "#000000",
                Name = "Lava Magic",
                UserId = testUserId
            };
            var earthMagicCategory = new Category
            {
                Id = new Guid("11751928-c2d3-4939-9692-05f578af3d00"),
                DisplayColor = "#000000",
                Name = "Earth Magic",
                UserId = testUserId
            };
            var auraCategory = new Category
            {
                Id = new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"),
                DisplayColor = "#000000",
                Name = "Aura",
                UserId = testUserId
            };
            var arcaneMagicCategory = new Category
            {
                Id = new Guid("572ba72e-87df-45bf-9496-a2b9d8962c7d"),
                DisplayColor = "#000000",
                Name = "Arcane Magic",
                UserId = testUserId
            };
            var teleportationMagicCategory = new Category
            {
                Id = new Guid("f8362bfc-6004-43df-827f-17f21203c6f3"),
                DisplayColor = "#000000",
                Name = "Teleportation Magic",
                UserId = testUserId
            };
            var perceptionAuraCategory = new Category
            {
                Id = new Guid("65728378-090f-4c29-9e87-b282f489d028"),
                DisplayColor = "#000000",
                Name = "Perception Aura",
                UserId = testUserId
            };

            modelBuilder.Entity<Category>().HasData(
                arcaneMagicCategory,
                bodyEnhancementCategory,
                healingMagicCategory,
                cosmicMagicCategory,
                auraCategory,
                teleportationMagicCategory,
                perceptionAuraCategory,
                ashenMagicCategory,
                fireMagicCategory,
                spaceMagicCategory,
                fleshMagicCategory,
                mindMagicCategory,
                iceMagicCategory,
                lavaMagicCategory,
                earthMagicCategory
            );

            #endregion

            #region resources

            var resources = new[]
            {
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid("70eaef56-21c1-494d-a0ba-312478c19428"),
                    DisplayName = "Health",
                    ResourcePointsPerBaseStatPoint = 10,
                    BaseStatId = new Guid(vitalityStatId)
                },
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid("f8a10c54-df2b-4658-9e37-ff772a55aea3"),
                    DisplayName = "Stamina",
                    ResourcePointsPerBaseStatPoint = 10,
                    BaseStatId = new Guid(enduranceStatId)
                },
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(manaResourceId),
                    DisplayName = "Mana",
                    ResourcePointsPerBaseStatPoint = 10,
                    BaseStatId = new Guid(wisdomStatId)
                },
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid("741e7652-0c8e-4cb8-8ac4-b298637ae6c2"),
                    DisplayName = "Mana (Essence)",
                    ResourcePointsPerBaseStatPoint = 10,
                    BaseStatId = new Guid(vitalityStatId)
                },
            };

            #endregion

            #region class modifiers

            var class1Modifiers = new[]
            {
                new ClassModifier()
                {
                    Id = new Guid("20ac1928-5cff-4504-a926-e253c38891d8"),
                    ClassId = new Guid(healingClassId),
                    Description = "Body enhancement magic is improved by 500%",
                    CategoryId = bodyEnhancementCategory.Id,
                    PercentagePointsOfCategoryIncrease = 500
                },
                new ClassModifier()
                {
                    Id = new Guid("c2ef6ecc-a8ba-4d0c-a9fd-f0d3dfcf11cf"),
                    ClassId = new Guid(healingClassId),
                    Description = "All healing magic skills are improved by 500%",
                    CategoryId = healingMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 500
                },
                new ClassModifier()
                {
                    Id = new Guid("c37f99aa-4fe2-4ea0-9cbe-63a646a26d1a"),
                    ClassId = new Guid(healingClassId),
                    Description = "All cosmic magic skills are improved by 250%",
                    CategoryId = cosmicMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 250
                },
                new ClassModifier()
                {
                    Id = new Guid("26d1fd63-e8ce-47ff-9587-b43948baf4d5"),
                    ClassId = new Guid(healingClassId),
                    Description = "Natural health regeneration is increased by 1% per minute",
                    PercentagePointsOfCategoryIncrease = 0
                },
                new ClassModifier()
                {
                    Id = new Guid("a9f8276e-272e-443d-a161-549e43525cce"),
                    ClassId = new Guid(healingClassId),
                    Description = "Natural mana regeneration is increased by 1% per minute",
                },
                new ClassModifier()
                {
                    Id = new Guid("6d66a14d-e883-4704-bc2d-8acbfbefecad"),
                    ClassId = new Guid(healingClassId),
                    Description = "Food, water and sleep needed to sustain yourself are no longer required",
                },
                new ClassModifier()
                {
                    Id = new Guid("d9c0563a-a568-4809-b798-bdf387475b38"),
                    ClassId = new Guid(healingClassId),
                    Description = "You do not age",
                },
                new ClassModifier()
                {
                    Id = new Guid("4a356fc3-234a-4e1e-9091-210132ff23d1"),
                    ClassId = new Guid(healingClassId),
                    Description = "You can absorb and use 25% of the ambient mana around you",
                },
                new ClassModifier()
                {
                    Id = new Guid("e58a8112-38b5-4970-b38d-53866b4c8543"),
                    ClassId = new Guid(healingClassId),
                    Description =
                        "All mana regeneration increases by 1% to a maximum of 100% for every second you are not hit by an enemy attack",
                },
                new ClassModifier()
                {
                    Id = new Guid("5274cf3c-f1cb-4fc8-8175-8f202d7d47c3"),
                    ClassId = new Guid(healingClassId),
                    Description =
                        "Excess generated mana instead charges a second mana pool equaling your total health [0/125400]. Mana from this pool can be transferred into your main mana pool at will",
                },
                new ClassModifier()
                {
                    Id = new Guid("1d2154a7-a236-4afa-b9cc-5f913c5a6468"),
                    ClassId = new Guid(healingClassId),
                    Description = "You may infuse any barrier, wall, or magical armor with cosmic energy",
                }
            };

            var additionalClass1Modifier = new
            {
                Id = new Guid("2218f3c7-591f-40eb-9f48-38b4f958440d"),
                ClassId = new Guid(healingClassId),
                Description = "Your mana capacity is multiplied by five",
                PercentagePointsOfCategoryIncrease = 500,
                CategoryCalculationType = CategoryCalculationType.Multiplicative,
                AffectedResourceId = new Guid(manaResourceId)
            };

            var class2Modifiers = new[]
            {
                new ClassModifier()
                {
                    Id = new Guid("988af334-4b7e-4c7e-ae51-c5f3362ae0ef"),
                    ClassId = new Guid(ashenClassId),
                    Description = "Body enhancement magic is improved by 500%",
                    CategoryId = bodyEnhancementCategory.Id,
                    PercentagePointsOfCategoryIncrease = 500
                },
                new ClassModifier()
                {
                    Id = new Guid("ea583586-3ebb-4680-9092-250882d6c90f"),
                    ClassId = new Guid(ashenClassId),
                    Description = "All Ashen magic skills are improved by 500%",
                    CategoryId = ashenMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 500
                },
                new ClassModifier()
                {
                    Id = new Guid("a37dff49-7a62-4355-b6d4-7dccc452a247"),
                    ClassId = new Guid(ashenClassId),
                    Description = "All Fire magic skills are improved by 250%",
                    CategoryId = fireMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 250
                },
                new ClassModifier()
                {
                    Id = new Guid("9d0ab750-a179-4107-8349-e17d2d4dc88e"),
                    ClassId = new Guid(ashenClassId),
                    Description = "All fighting styles using hand to hand combat are more refined",
                },
                new ClassModifier()
                {
                    Id = new Guid("268eb8e9-5be0-4d4d-b29d-0ce1f6bcacca"),
                    ClassId = new Guid(ashenClassId),
                    Description = "Your will is ash and heat",
                },
                new ClassModifier()
                {
                    Id = new Guid("1382a487-16d5-4356-b1a2-a391cbaa7f53"),
                    ClassId = new Guid(ashenClassId),
                    Description = "You cannot be stunned by enemy attacks",
                },
                new ClassModifier()
                {
                    Id = new Guid("6db597af-34bb-4660-ac70-e7d9bb482088"),
                    ClassId = new Guid(ashenClassId),
                    Description = "Your bones and muscles have vastly increased density",
                },
                new ClassModifier()
                {
                    Id = new Guid("29185439-b3d7-4648-847d-7709cb46faa1"),
                    ClassId = new Guid(ashenClassId),
                    Description = "Your heat generation is increased by 1000%",
                }
            };

            var class3Modifiers = new[]
            {
                new ClassModifier()
                {
                    Id = new Guid("a070e26f-c73c-487f-9fdd-d73286650e22"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Space Magic is improved by 500%",
                    CategoryId = spaceMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 500
                },
                new ClassModifier()
                {
                    Id = new Guid("09e97cee-34b2-4aea-9b47-b7160339de10"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Resilience is increased by 500%",
                },
                new ClassModifier()
                {
                    Id = new Guid("fe07af4f-38e6-4e99-9f9d-3bd29692bded"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Body Enhancement Magic is improved by 300%",
                    CategoryId = bodyEnhancementCategory.Id,
                    PercentagePointsOfCategoryIncrease = 300
                },
                new ClassModifier()
                {
                    Id = new Guid("53b6d5e7-cd28-45a4-a7c8-72cc361b8e9b"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Fire Magic is improved by 200%",
                    CategoryId = fireMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 200
                },
                new ClassModifier()
                {
                    Id = new Guid("8bb31795-7294-42f3-9347-1e8b31596065"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Flesh Magic is improved by 100%",
                    CategoryId = fleshMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 100
                },
                new ClassModifier()
                {
                    Id = new Guid("a24ac0ce-4fc0-4f2c-ae22-dbed4a108808"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Healing Magic is improved by 100%",
                    CategoryId = healingMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 100
                },
                new ClassModifier()
                {
                    Id = new Guid("2af0ee40-2ea0-4b2c-abc6-22a15b37fb19"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Mind Magic is improved by 100%",
                    CategoryId = mindMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 100
                },
                new ClassModifier()
                {
                    Id = new Guid("d2168950-990e-42d5-9b43-8b556aeb4741"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Ice Magic is improved by 100%",
                    CategoryId = iceMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 100
                },
                new ClassModifier()
                {
                    Id = new Guid("2cc5563c-4e6f-4785-9d7a-f334fc6600aa"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Lava Magic is improved by 100%",
                    CategoryId = lavaMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 100
                },
                new ClassModifier()
                {
                    Id = new Guid("6c72a67a-beff-4d01-a746-3350677d2832"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Earth Magic is improved by 100%",
                    CategoryId = earthMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 100
                },
                new ClassModifier()
                {
                    Id = new Guid("a0ee0c09-5d9f-4577-9d16-c597fb97d36d"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Your Soul has been strengthened by the Primordial Flame",
                },
                new ClassModifier()
                {
                    Id = new Guid("cb4fb181-c7a8-4007-afdf-e68bcf328c9b"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Your skin grows more resilient",
                },
                new ClassModifier()
                {
                    Id = new Guid("9c725771-e1b1-4a34-a2bf-db707b546077"),
                    ClassId = new Guid(spaceClassId),
                    Description = "Greatly increases the heat you can store within your body and soul",
                },
            };

            modelBuilder.Entity<ClassModifier>().HasData(additionalClass1Modifier);
            modelBuilder.Entity<ClassModifier>().HasData(class1Modifiers);
            modelBuilder.Entity<ClassModifier>().HasData(class2Modifiers);
            modelBuilder.Entity<ClassModifier>().HasData(class3Modifiers);

            #endregion

            modelBuilder.Entity<CharacterStatus>().HasData(
                new CharacterStatus()
                {
                    Id = new Guid(characterStatusId),
                    UnspentStatpoints = 25,
                    UserCharacterId = new Guid(userCharacterId),
                    CreatedAt = new DateTimeOffset(
                        new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(0),
                        new TimeSpan(0, 0, 0, 0, 0)),
                });

            modelBuilder.Entity<Resource>().HasData(resources);

            #region stats

            modelBuilder.Entity<Stat>().HasData(
                new Stat
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(vitalityStatId),
                    Name = "Vitality",
                    Value = 3800
                },
                new Stat
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(enduranceStatId),
                    Name = "Endurance",
                    Value = 600
                },
                new Stat
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(strengthStatId),
                    Name = "Strength",
                    Value = 860
                },
                new Stat
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(dexterityStatId),
                    Name = "Dexterity",
                    Value = 610
                },
                new Stat
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(intelligenceStatId),
                    Name = "Intelligence",
                    Value = 3770
                },
                new Stat
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(wisdomStatId),
                    Name = "Wisdom",
                    Value = 4000
                },
                new Stat
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(resilienceStatId),
                    Name = "Resilience",
                    Value = 1,
                    IsHidden = true
                },
                new Stat
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(speedStatId),
                    Name = "Speed",
                    Value = 1,
                    IsHidden = true
                },
                new Stat
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(reflexesStatId),
                    Name = "Reflexes",
                    Value = 1,
                    IsHidden = true
                }
            );

            #endregion

            #region skills

            #region healing class skills

            var skillGuids = Enumerable.Range(1, 10).Select(x => guidGenerator.GetNext()).ToArray();

            var skills = new Skill[]
            {
                new Skill()
                {
                    Id = skillGuids[0],
                    CharacterClassId = new Guid(healingClassId),
                    Name = "Cosmic Deconstruction",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[1],
                    CharacterClassId = new Guid(healingClassId),
                    Name = "True Reconstruction",
                    Level = 1,
                    Tier = 4,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[2],
                    CharacterClassId = new Guid(healingClassId),
                    Name = "Embodiment of the Arcane",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[3],
                    CharacterClassId = new Guid(healingClassId),
                    Name = "Teleportation",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[4],
                    CharacterClassId = new Guid(healingClassId),
                    Name = "Limitless Domain",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[5],
                    CharacterClassId = new Guid(healingClassId),
                    Name = "Catalyst Core",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Passive,
                },
                new Skill()
                {
                    Id = skillGuids[6],
                    CharacterClassId = new Guid(healingClassId),
                    Name = "Timeless Perception",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Passive,
                },
                new Skill()
                {
                    Id = skillGuids[7],
                    CharacterClassId = new Guid(healingClassId),
                    Name = "Cycle of Creation",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Passive,
                },
                new Skill()
                {
                    Id = skillGuids[8],
                    CharacterClassId = new Guid(healingClassId),
                    Name = "Eternal Huntress",
                    Level = 30,
                    Tier = 3,
                    Enhanced = false,
                    Type = SkillType.Passive,
                },
                new Skill()
                {
                    Id = skillGuids[9],
                    CharacterClassId = new Guid(healingClassId),
                    Name = "Eternal Brawling",
                    Level = 30,
                    Tier = 3,
                    Enhanced = false,
                    Type = SkillType.Passive,
                }
            };

            modelBuilder.Entity<Skill>().HasData(skills);

            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Send a pulse of deconstructing cosmic power into an object, spell, or creature within your domain with every motion using your arms, fists, fingers, legs, feet, or head. Your Intelligence stat enhances the damage potential.",
                    "The amount of mana used per pulse can be regulated with a maximum of 5000 mana per pulse. You may charge each pulse with 5000 mana per second to a maximum of 25000 mana. Once cosmic power resides within a target, you can rip it out with a reversed motion to cause additional damage. Cosmic power within a target stacks, depending on their defensive measures and structure.",
                    "You may choose to use Cosmic Deconstruction as a non intrusive attack, instead sending out a broad wave of deconstructing energy from you at the center. The same motion requirements as in the first tier apply. If used as a wave, the range of Cosmic Deconstruction is equal to the range of your domain and is more effective against magical constructs."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[0].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = healingMagicCategory.Id, SkillsId = skills[0].Id },
                        new { CategoriesId = cosmicMagicCategory.Id, SkillsId = skills[0].Id }
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Send a healing pulse of cosmic power into yourself or creatures within your domain. This skill can be channeled. In addition to health, True Reconstruction restores mana and heals damage to your soul.",
                    "Your control is increased greatly, you can now focus your healing on specific parts of the body. As long as mana and health remains, your True Reconstruction will restore your body. Lose your head and see for yourself! Health loss and critical blows are recalculated due to the nature of your healing. You may restore magical constructs and enchantments with True Reconstruction.",
                    "You have healed your body time and time again, knowing every cell and where it belongs. Sacrifice a large amount of mana to rush your healing to unprecedented speeds. Lack of knowledge about your body may result in heavy damage. Effect can be used on any creature or magical construct. Limited to 10’000 mana per use.",
                    "You have healed yourself thousands of times. Have regrown lost limbs, have reformed lost organs. You have healed and protected your mind, all in pursuit of greater power. Healing to shield you. Healing to allow an exchange of blows, with those you would not otherwise be able to fight. A core ability for the Azarinth Healer, a terrifying tool for the Cosmic Immortal. You have grasped the true nature of Reconstruction. Not the healing spell of a savior, but a necessity for the battle healer you have become. Through the fourth tier, you have enhanced this ability to the pinnacle. Once active, cosmic energies will surge within your body. Not to heal wounds you have sustained, but to keep you fighting whatever enemy you face. To overwhelm the foes no other could dare stand against.\r\nIf you reach 0 points of health, all remaining mana is used to activate True Reconstruction, containing your essence in a set of powerful cosmic barriers protecting your remains from harm and restoring your life. This effect may activate once every 24 hours.\r\nFollowing benefits and changes will apply during use of the fourth tier:\r\n- All damage sustained is dealt to your mana instead of your health\r\n- The first stage of True Reconstruction will generate additional mana and health\r\n- All mana generation and absorption is doubled\r\n- Your body is pushed to the limits of cosmic power, enhancing all of your abilities\r\n- Your body sustains heavy damage from this flow of cosmic power. This ability will deactivate when your health drops below a certain point [1% - Set value] and cannot be used again for twice as long as it has been active\r\n- Once the 4th tier deactivates, a set of seven cosmic barriers appear around you to protect from enemy blows. You may control these barriers or allow them to automatically react to enemy attacks\r\n- You cannot use the third tier of True Reconstruction on your own body"
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[1].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = healingMagicCategory.Id, SkillsId = skills[1].Id },
                        new { CategoriesId = cosmicMagicCategory.Id, SkillsId = skills[1].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Your body glows with the power of the cosmos, increasing your resilience, speed, Intelligence, and Strength by <stats_increase>.",
                    "Your sight, hearing and sense of smell is also affected by Embodiment of the Arcane.",
                    "You are one with the Arcane. The skill’s upkeep has been removed. A static <wisdom_increase> of the base effect is applied to Wisdom. Does not affect the mana regeneration properties of the Wisdom stat."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[2].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = auraCategory.Id, SkillsId = skills[2].Id },
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[2].Id },
                        new { CategoriesId = cosmicMagicCategory.Id, SkillsId = skills[2].Id },
                    }));

            var statsIncreaseSkillVariableId = guidGenerator.GetNext();

            var skillVariables = new SkillVariable[]
            {
                new SkillVariable()
                {
                    Id = statsIncreaseSkillVariableId,
                    SkillId = skills[2].Id,
                    Name = "stats_increase",
                    BaseValue = 100,
                    Unit = "%",
                    CategoryCalculationType = CategoryCalculationType.Additive,
                    VariableCalculationType = VariableCalculationType.Additive,
                },
                new SkillVariable()
                {
                    Id = guidGenerator.GetNext(),
                    SkillId = skills[2].Id,
                    Name = "wisdom_increase",
                    BaseValue = 25,
                    Unit = "%",
                    BaseSkillVariableId = statsIncreaseSkillVariableId,
                    CategoryCalculationType = CategoryCalculationType.Additive,
                    VariableCalculationType = VariableCalculationType.StaticAdditiveOtherVariableBased,
                }
            };

            modelBuilder.Entity<SkillVariable>().HasData(skillVariables);

            modelBuilder.Entity<SkillVariableStat>().HasData(new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[0].Id,
                    StatId = new Guid(resilienceStatId)
                },
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[0].Id,
                    StatId = new Guid(speedStatId)
                },
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[0].Id,
                    StatId = new Guid(intelligenceStatId)
                },
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[0].Id,
                    StatId = new Guid(strengthStatId)
                },
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[1].Id,
                    StatId = new Guid(wisdomStatId)
                });


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Immediately appear anywhere in your domain or anywhere you can see with reliable clarity.",
                    "The time between transfers is reduced greatly. No ground contact needed between transfers. Teleportation gains 3 charges, each with a separate cooldown. For 2 seconds after Teleportation is used, you may return to the original position in the fabric where the spell was initially activated.",
                    "You may set ten destinations you touch. You may change each destination once per day. This cooldown is static. You may travel to each destination once every 25 minutes [12.5 minutes]. Cast time is reduced by a static 50% for destinations you have already teleported to."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[3].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = teleportationMagicCategory.Id, SkillsId = skills[3].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Perceive everything in a sphere around you while this skill is activated. The higher the level the further your domain reaches. You may drain mana from creatures and spells within your domain.",
                    "Arcane dominion opens your senses to the arcane. A paramount skill both on and off the battlefield. Elements and spells you control within your dominion have increased harmony. You drain the remaining mana from creatures you kill inside of your domain.",
                    "Your element manipulation skills are improved by a static 100% when used within your dominion. Improves any of your mana absorption or drain abilities within your domain."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[4].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = auraCategory.Id, SkillsId = skills[4].Id },
                        new { CategoriesId = perceptionAuraCategory.Id, SkillsId = skills[4].Id },
                        new { CategoriesId = cosmicMagicCategory.Id, SkillsId = skills[4].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Your body was changed by magic. All pain is reduced greatly. Your body is 75% [1387.5%] more durable. You heal even fatal injuries without help of healing magic. Your natural Health and Mana regeneration is improved by 150% [2775%].",
                    "The magic of the cosmos settles inside your body. Your resistance to magical, physical, and soul damage is increased by a static 35% [647.5%]. Your bones and muscles are five times as dense.",
                    "Your body was battered and forged by magic. You absorb mana from enemy spells in your domain. Efficiency is determined by enemy mana used and your resistance to the type of magic. Mana cost for all skills reduced by a static 35%. Your body can absorb ambient mana. Amount dependent on availability and harmony."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[5].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = healingMagicCategory.Id, SkillsId = skills[5].Id },
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[5].Id },
                        new { CategoriesId = cosmicMagicCategory.Id, SkillsId = skills[5].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Vastly increases your perception and reflexes.",
                    "Timeless Perception spikes for two seconds, should you be about to receive a blow that would take 50% or more of your health, or should your mind be incapacitated with an incoming blow. This can happen only once per hour.",
                    "Your resilience and speed is doubled during the spike in perception. Increases usage to five times per hour. The effect duration is increased to three seconds and can be activated at will. You gain the ability to gauge enemy mana usage and may learn how strongly a direct hit of a spell will impact you. Increased ability to gauge incoming damage depending on your familiarity with the respective magic type."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[6].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[6].Id },
                        new { CategoriesId = cosmicMagicCategory.Id, SkillsId = skills[6].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "You have learned of Cosmic Deconstruction and True Reconstruction. Now you will learn of their Reversal.\r\nUpon activation, Cosmic Deconstruction will send a part of the struck enemy’s health and mana into yourself. No mana will be released on impact, rendering Cosmic Deconstruction’s offensive potential to zero.\r\nUpon activation, True Reconstruction will send a destructive force of channeled mana into yourself, a creature or magical construct within your domain, the healing aspects are reduced to zero.",
                    "You may have both the original and reversed aspects activated at the same time. When an enemy partially or fully resists either Cosmic Deconstruction or True Reconstruction, you absorb the dissipating mana.",
                    "Healing, power, resilience and speed. All requires balance. Your respective Deconstruction and Reconstruction spells have their potency increased by a static 25% of your median stat value. [488.75%]. You may channel health in addition to mana into the respective offensive uses of Archon Strike and Sentinel Reconstruction. Health cost to activate effects is reduced by a static 20%."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[7].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[7].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Huntress turned Eternal. Your eyes are unmatched and so is your nose. Perceive the smallest irregularities in your surroundings as well as the ambient mana to find clues about your target’s whereabouts. Perceive the trails of dangerous prey.",
                    "You gain a sense for the distress in the people around you. Amplify this by sacrificing mana. You gain a sense for the arcane, feeling even minor spells around you. As you practice to differentiate these spells, you will learn of their intent.",
                    "Through Azarinth magic, you may mark an enemy or ally with the Eternal Mark. Allies may use the mark to send a short message to the Arcane Eternal once per day. The Arcane Eternal can send a short message to each non forcefully applied mark once per day. Each level in the third tier adds two additional marks that can be used. Marks forcefully applied have a limited duration."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[8].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[8].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "You have adapted the fighting style of the Azarinth school to something you now call your own. Damage inflicted with your own body and related skills is 110% [990%] higher. Your arms, fists, fingers, legs, and head deal a slight amount of arcane damage with each strike.",
                    "Getting used to fighting in close quarters, your reaction time is increased to accommodate your increasing speed and control. Your bones are steeped with mana, increasing both their weight and resilience two fold.",
                    "Eternal Brawling consists of more than offense alone. A true brawler knows when to stand and let an enemy strike. You gain knowledge about sustained injuries and damage from incoming attacks as they happen."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[9].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[9].Id },
                        new { CategoriesId = arcaneMagicCategory.Id, SkillsId = skills[9].Id },
                    }));

            #endregion

            #region ashen class skills

            skillGuids = Enumerable.Range(1, 10).Select(x => guidGenerator.GetNext()).ToArray();

            skills = new Skill[]
            {
                new Skill()
                {
                    Id = skillGuids[0],
                    CharacterClassId = new Guid(ashenClassId),
                    Name = "Ash Scale Armor",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[1],
                    CharacterClassId = new Guid(ashenClassId),
                    Name = "Draconic Core",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[2],
                    CharacterClassId = new Guid(ashenClassId),
                    Name = "Pyroclastic Flow",
                    Level = 1,
                    Tier = 4,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[3],
                    CharacterClassId = new Guid(ashenClassId),
                    Name = "Volcanic Source",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[4],
                    CharacterClassId = new Guid(ashenClassId),
                    Name = "Scorching Intrusion",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[5],
                    CharacterClassId = new Guid(ashenClassId),
                    Name = "Mastery of Ash",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Passive,
                },
                new Skill()
                {
                    Id = skillGuids[6],
                    CharacterClassId = new Guid(ashenClassId),
                    Name = "Draconic Ash Wings",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Passive,
                },
                new Skill()
                {
                    Id = skillGuids[7],
                    CharacterClassId = new Guid(ashenClassId),
                    Name = "Embodiment of Heat",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Passive,
                },
                new Skill()
                {
                    Id = skillGuids[8],
                    CharacterClassId = new Guid(ashenClassId),
                    Name = "Vision of Ash",
                    Level = 30,
                    Tier = 3,
                    Enhanced = false,
                    Type = SkillType.Passive,
                },
                new Skill()
                {
                    Id = skillGuids[9],
                    CharacterClassId = new Guid(ashenClassId),
                    Name = "Embered Form",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
            };

            modelBuilder.Entity<Skill>().HasData(skills);

            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "An armor of ash and hardened volcanic glass scales protects and fuses partially with your body, forming at your will. The Armor increases your resistance to heat and fire, as well as your overall resilience by 200% [3200%].",
                    "The strength of your Resistance skills and your wings also benefit from Ash Scale Armor. The Armor is a part of your body. It benefits from natural regeneration. You can feel through your armor and you can heal it. Your Ash Scale Armor repairs minor damage on its own. If you armor is penetrated to the lowest layer, an explosion of heated smoke and volcanic glass is released at your enemy if you do not suppress the effect.",
                    "Increases the defensive capabilities of all ash you control. Increase the ash used to form your armor by up to a static 500%. The additional ash used requires conscious manipulation. You may use Ash Scale Armor to defend willing allies. Amount of required ash dependent on size of the target. You may increase the ash used by another static 500%, reducing your total speed by a static 15% for each 100% of additional increase."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[0].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[0].Id },
                        new { CategoriesId = ashenMagicCategory.Id, SkillsId = skills[0].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Heat glows within you, raising your resilience, speed, Strength, Intelligence and Dexterity by <stats_increase>. Your learn how to generate and store vast amounts of heat within your Draconic Core or your magical constructs.",
                    "The longer you fight with Draconic Core active, the deeper it roots. Each second of fighting adds 1% more power to the skill with a maximum of a static [250%]. Once no longer engaged in battle, 1% of additionally generated power is lost per second.",
                    "Familiarity with the skill removes its upkeep. You can choose to increase your weight by 1% [18.5%] for each passing second to a maximum of a static [1500%], increasing your natural health regeneration, heat generation, and resilience by the same factor."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[1].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = auraCategory.Id, SkillsId = skills[1].Id },
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[1].Id },
                        new { CategoriesId = ashenMagicCategory.Id, SkillsId = skills[1].Id },
                        new { CategoriesId = fireMagicCategory.Id, SkillsId = skills[1].Id },
                    }));

            skillVariables = new SkillVariable[]
            {
                new SkillVariable()
                {
                    Id = guidGenerator.GetNext(),
                    SkillId = skills[1].Id,
                    Name = "stats_increase",
                    BaseValue = 100,
                    Unit = "%",
                    CategoryCalculationType = CategoryCalculationType.Additive,
                    VariableCalculationType = VariableCalculationType.Additive,
                }
            };

            modelBuilder.Entity<SkillVariable>().HasData(skillVariables);

            modelBuilder.Entity<SkillVariableStat>().HasData(new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[0].Id,
                    StatId = new Guid(resilienceStatId)
                },
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[0].Id,
                    StatId = new Guid(speedStatId)
                },
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[0].Id,
                    StatId = new Guid(intelligenceStatId)
                },
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[0].Id,
                    StatId = new Guid(strengthStatId)
                },
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[0].Id,
                    StatId = new Guid(dexterityStatId)
                });


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Create ash, smoke, and volcanic glass in a certain radius around you.",
                    "You may vastly increase the density and heat of your ash, smoke, and volcanic glass.",
                    "You have proven your dedication. The Pyroclastic Flow moves to aid and destroy at your whims. The amount of ash, smoke, and volcanic glass you can create is vastly increased.",
                    "You are the Pyroclastic Storm. The Fourth Tier allows for true harmony."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[2].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = ashenMagicCategory.Id, SkillsId = skills[2].Id },
                        new { CategoriesId = fireMagicCategory.Id, SkillsId = skills[2].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Vastly increase the heat in your body and release it in a blast or continuous heat around you.",
                    "The fires run deep. The heat you may reach is only limited by your very life. Your resistance to heat held within your body is tripled.",
                    "Focus on release to change the blast into a cone of destruction sent out of either arm. You may store heat within any ash, smoke, or volcanic glass that you control. Creations not connected to you release their stored heat upon a strong impact in a blast around it or when you will it. You learn to send out any stored heat as waves through your Pyroclastic Flow."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[3].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[3].Id },
                        new { CategoriesId = ashenMagicCategory.Id, SkillsId = skills[3].Id },
                        new { CategoriesId = fireMagicCategory.Id, SkillsId = skills[3].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Burn the inside of whatever your body or your magical constructs touch with a surge of heat or release the attack in a violent burst.",
                    "The heat burns on. Targets hit will have fire burning through or on them. Continuous use of Scorching Intrusion will increase the stored energy up to a breaking point where all is released in a violent explosion of fire and heat. Breaking point is dependent on enemy resilience and heat resistance.",
                    "Scorching Intrusion damages mana intrusion capabilities of defensive enchantments, natural- as well as manufactured armor. Once a target is affected by Scorching Intrusion and in contact with your body or your magical constructs, you may increase the stored heat for up to a static 1000 mana per second to faster reach the breaking point."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[4].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = ashenMagicCategory.Id, SkillsId = skills[4].Id },
                        new { CategoriesId = fireMagicCategory.Id, SkillsId = skills[4].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "You are one with Ash and Heat, your creations blotting out the very suns.",
                    "Your understanding grows, allowing you to create greater change in ash, smoke, and volcanic glass. Imbue mana and complex commands into your creations. Ash and volcanic glass you imbue retains its form until the mana is used up. Imbued creations retain a static 10% of your ambient and enemy spell mana absorption.",
                    "The elements themselves become an extension of your body, an extension of your will, for as long as they stay in physical contact with you. Ash and volcanic glass not connected benefits from passive abilities enhancing your body. You may imbue commands into ash and ember you have imbued with mana. Once per hour, you may create up to 25 copies of your form made of ash and volcanic glass, all instantly imbued with the same or separate complex commands. Each copy receives one random Class skill from any of your Classes. Should a spell require health or stamina to function, you may choose to imbue these resources as well. Copies lose access to this skill after initially imbued resources are used up."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[5].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = ashenMagicCategory.Id, SkillsId = skills[5].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Your understanding of the Pyroclastic Flow allows you to create scaled wings from ash and volcanic glass. Bring terror from above and deliver your wrath, your wings carrying you no matter how dense, how heavy, or how injured you are.",
                    "Your wings become more dense and tangible, able to help you defend and attack. When active, your wings become a part of your body.",
                    "Shape and form your wings to your liking, now directly affected by your control. An added tail shall make you one with the skies above, not a mere human imitating flight but one who revels in it. You may charge your wings with mana and stamina to dramatically increase your flight velocity at the cost of heavily reduced control. Your resilience is increased greatly during a charged flight. If wings are active, this charge may be applied to created magical constructs for a vast increase in the velocity of projectiles. Resilience bonuses do not apply to such constructs."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[6].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[6].Id },
                        new { CategoriesId = ashenMagicCategory.Id, SkillsId = skills[6].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Increases your reflexes and speed by <stats_increase>. Your ability to avoid damage to your vitals when dodging increases. A static <vitality_increase> of this bonus is applied to Vitality.",
                    "Your muscles grow more dense. For each Resistance skill your body becomes tougher. First tier Resistances equal a static 5% increase, second tier equal a static 10% increase, third tier equal a static 15% increase [<endurance_increase>]. Additionally affects your endurance.",
                    "You can choose to allow magic damage to bypass your related resistance skills. If this effect is active, any absorption abilities related to such magic damage is increased. Effect is canceled automatically upon reaching 50% of your health. Each Resistance skill in the second tier or higher increases your heat generation and the potential density of your created ash and volcanic glass by a static 5% [225%]. Each Resistance skill in the third tier increases the speed of your created projectiles by 10% [260%]."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[7].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[7].Id },
                        new { CategoriesId = ashenMagicCategory.Id, SkillsId = skills[7].Id },
                        new { CategoriesId = fireMagicCategory.Id, SkillsId = skills[7].Id },
                    }));

            statsIncreaseSkillVariableId = guidGenerator.GetNext();

            skillVariables = new SkillVariable[]
            {
                new SkillVariable()
                {
                    Id = statsIncreaseSkillVariableId,
                    SkillId = skills[7].Id,
                    Name = "stats_increase",
                    BaseValue = 75,
                    Unit = "%",
                    CategoryCalculationType = CategoryCalculationType.Additive,
                    VariableCalculationType = VariableCalculationType.Additive,
                },
                new SkillVariable()
                {
                    Id = guidGenerator.GetNext(),
                    SkillId = skills[7].Id,
                    Name = "vitality_increase",
                    BaseValue = 25,
                    Unit = "%",
                    BaseSkillVariableId = statsIncreaseSkillVariableId,
                    CategoryCalculationType = CategoryCalculationType.MultiplicativeWithBaseAdded,
                    VariableCalculationType = VariableCalculationType.StaticAdditiveOtherVariableBased,
                },
                new SkillVariable()
                {
                    Id = guidGenerator.GetNext(),
                    SkillId = skills[7].Id,
                    Name = "endurance_increase",
                    BaseValue = 625,
                    Unit = "%",
                    CategoryCalculationType = CategoryCalculationType.Additive,
                    VariableCalculationType = VariableCalculationType.None,
                }
            };

            modelBuilder.Entity<SkillVariable>().HasData(skillVariables);

            modelBuilder.Entity<SkillVariableStat>().HasData(new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[0].Id,
                    StatId = new Guid(reflexesStatId)
                },
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[0].Id,
                    StatId = new Guid(speedStatId)
                },
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[1].Id,
                    StatId = new Guid(vitalityStatId)
                },
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[2].Id,
                    StatId = new Guid(enduranceStatId)
                });


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Increases your perception by 65% [780%] when fighting.",
                    "Opportunity calls, you notice possible critical weak points on enemies with more ease. You can choose to see through ash and embers.",
                    "Your eyes are vastly improved. Great distances and a lack of light won’t pose a problem to you anymore. You can control ash and embers that you can see."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[8].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[8].Id },
                        new { CategoriesId = ashenMagicCategory.Id, SkillsId = skills[8].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "You are one with the fighting style of Ash. Damage inflicted is 85% [850%] higher.",
                    "Adds density to your bones, muscles and skin to increase strength, speed and damage. Base body weight is doubled. The abuse your body takes from your own strikes and their feedback is reduced.",
                    "Reduces stamina consumption by a static 35%. Mana intrusion attacks formed or charged within your arms, hands, fingers, legs, feet, or your head can instead be converted into a purely physical damage increase to the executed attack. Be aware that this increase will be heavily demanding for your body."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[9].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[9].Id },
                    }));

            #endregion

            #region space class skills

            skillGuids = Enumerable.Range(1, 6).Select(x => guidGenerator.GetNext()).ToArray();

            skills = new Skill[]
            {
                new Skill()
                {
                    Id = skillGuids[0],
                    CharacterClassId = new Guid(spaceClassId),
                    Name = "The Primordial Flame",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[1],
                    CharacterClassId = new Guid(spaceClassId),
                    Name = "Framework Disruption",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[2],
                    CharacterClassId = new Guid(spaceClassId),
                    Name = "Sunbound Creation",
                    Level = 1,
                    Tier = 4,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[3],
                    CharacterClassId = new Guid(spaceClassId),
                    Name = "Cosmic Shape",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Active,
                },
                new Skill()
                {
                    Id = skillGuids[4],
                    CharacterClassId = new Guid(spaceClassId),
                    Name = "Fabric Alteration",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Passive,
                },
                new Skill()
                {
                    Id = skillGuids[5],
                    CharacterClassId = new Guid(spaceClassId),
                    Name = "Reality Warp",
                    Level = 30,
                    Tier = 3,
                    Enhanced = true,
                    Type = SkillType.Passive,
                },
            };

            modelBuilder.Entity<Skill>().HasData(skills);

            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Bring upon your enemies, the power of the suns themselves, burning away your health in the exchange for devastating light, heat, and energy. Your flames are limitless and form at your will. All of your spells and your body are infused with the Primordial Flame, dealing lingering damage to all within the fabric. You are immune to stunning, fear, and shout abilities. Your resilience is increased by 100% [2350%]",
                    "The bright flame settles within your core. The Primordial Flame now affects enemy health, mana, and stamina regeneration. This effect is higher for areas directly touched by the Primordial Flame.",
                    "You may infuse your magical constructs with the Primordial Flame. For each level in the third tier, the skill’s upkeep is reduced by a static 50 [1500] points of health per second and you may sacrifice an additional static 500 [15000] points of health per second to enhance the skill’s effects. The Primordial Flames return a static 10% of all health, stamina, and mana burned away so long as the spell is active."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[0].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = auraCategory.Id, SkillsId = skills[0].Id },
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[0].Id },
                        new { CategoriesId = spaceMagicCategory.Id, SkillsId = skills[0].Id },
                        new { CategoriesId = fireMagicCategory.Id, SkillsId = skills[0].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Shift space to your will, making frameworks or parts of frameworks appear somewhere else. Yes. That means you can teleport someone’s head off of their shoulders. Should you do it? Probably not.",
                    "You may change the orientation of the objects you displace. Should you be unable to affect a framework with the initial spell usage, you may channel up to a static 1000 mana per second into it to cause the desired effect.",
                    "You may choose two flat areas and connect them through space. At the time of marking an area, it has to be within the range of Framework Disruption. Ten sets of connections can be upheld at a time with exponential costs."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[1].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = spaceMagicCategory.Id, SkillsId = skills[1].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Expending a large amount of mana and health, you can temporarily summon a new reality around your form, burning with the Primordial Flame and shielded by the fabric itself. Absorb a part of all magic that tries to affect your creation, depending on your understanding and resistance. All regeneration and healing is doubled in this state. Your movements are impaired as your very form is rejected by the true fabric that surrounds you.",
                    "Resilience bonuses from skills are doubled when entering your Sunbound Creation. During the shift, you cannot be moved by anything but your will. Your weight increases a hundred fold while this spell is active. You may incorporate nearby allies into your creation, protecting them for an additional cost of mana and health.",
                    "The Primordial Flame wills itself into existence, your control and its power increasing dramatically while Sunbound Creation is active. Increases the power of all space manipulation while the spell is active. Greatly reduces the activation time of Sunbound Creation. The longer this spell remains active, the more powerful its effects become.",
                    "You have delved into the secrets of creation. Inside of your reality, you are not part of the Fabric, but you have learned to navigate through the mesh, and you have learned how to affect the true fabric with all that you can form. While Sunbound Creation is active, you gain the following benefits:\r\n- Your space manipulation of frameworks outside of your creation is vastly improved.\r\n- Your vision is no longer distorted, but clear, if you will it so.\r\n- The Primordial Flame burns at your will, vastly improved and burning with the very heat of the stars\r\n- You may use every spell within your Sunbound Creation. Limitations exist in regards to movement and teleportation of yourself.\r\n- You learn to move at a slow pace through the fabric, pushing your creation through known reality."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[2].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = spaceMagicCategory.Id, SkillsId = skills[2].Id },
                        new { CategoriesId = fireMagicCategory.Id, SkillsId = skills[2].Id },
                        new { CategoriesId = healingMagicCategory.Id, SkillsId = skills[2].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "The Primordial Flame flows through your veins, increasing your resilience by <resilience_increase> 75% [1762.5%]. Increases your physical damage resistance by 15% [352.5%]. Increases your magic damage resistance by 15% [352.5%]. You won’t be fazed anymore by heavy damage or powerful sources of light and sound. Your natural regeneration can heal any injury.",
                    "Your body has withstood incredible damage, endured the hardships of battle. The fires flowing through you have hardened your bones and muscles. Your health is increased by <vitality_increase> 35% [822.5%].",
                    "Your ability to adapt to your enemy grows. Continued battle against the same foe or species of monster increases damage reduction against their attacks by 2.5% [58.75%] per minute to a maximum of a static 50%. This effect will remain even after a battle has ended. The Cosmic Shape is released should you reach low health [0.1% - set value]. Your mana [100% - set value] will be used to create both spatial shields and the Primordial Flame to prevent death. This effect can only occur once every three hours."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[3].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[3].Id },
                        new { CategoriesId = spaceMagicCategory.Id, SkillsId = skills[3].Id },
                        new { CategoriesId = fireMagicCategory.Id, SkillsId = skills[3].Id },
                    }));

            skillVariables = new SkillVariable[]
            {
                new SkillVariable()
                {
                    Id = guidGenerator.GetNext(),
                    SkillId = skills[3].Id,
                    BaseValue = 75,
                    CategoryCalculationType = CategoryCalculationType.Additive,
                    VariableCalculationType = VariableCalculationType.Additive,
                    Name = "resilience_increase",
                    Unit = "%",
                },
                new SkillVariable()
                {
                    Id = guidGenerator.GetNext(),
                    SkillId = skills[3].Id,
                    BaseValue = 35,
                    CategoryCalculationType = CategoryCalculationType.MultiplicativeWithBaseAdded,
                    VariableCalculationType = VariableCalculationType.Additive,
                    Name = "vitality_increase",
                    Unit = "%",
                }
            };

            modelBuilder.Entity<SkillVariable>().HasData(skillVariables);

            modelBuilder.Entity<SkillVariableStat>().HasData(
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[0].Id,
                    StatId = new Guid(resilienceStatId)
                },
                new SkillVariableStat
                {
                    Id = skillVariableGuidGenerator.GetNext(),
                    SkillVariableId = skillVariables[1].Id,
                    StatId = new Guid(vitalityStatId)
                });


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "You have learned to see and manipulate the ever present spatial fabric. You gain the ability to move anything within the fabric with a mere gesture. Greatly improves the power of your manipulation and reduces its cost.",
                    "Further understanding of the spatial fabric allows you to manipulate its forces with greater ease and higher intensity. You learn to perceive even the tiniest ripples in space. In the case of active fissures, you find yourself able to peer into the other side. You gain the ability to anchor a spatial pocket to your very essence. Storage increases with the skill’s level. You gain the ability to glimpse through the fabric at any anchors you have set within.",
                    "You have peered through the fabric of space itself and have learned to unravel its intricate structure. You gain the ability to perceive and differentiate magical frameworks and how to manipulate them within your space without failure. Charge simple manipulation attempts with up to 500 [10000] points of mana. You learn how to damage existing frameworks. Results may vary. Your experience with the fabric allows you to imbue your eyes with mana, to perceive and manipulate old tears in the mesh where cracks had formed or beings have traveled through the realms."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[4].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = bodyEnhancementCategory.Id, SkillsId = skills[4].Id },
                        new { CategoriesId = spaceMagicCategory.Id, SkillsId = skills[4].Id },
                    }));


            AddTierDescriptionsToSkill(modelBuilder,
                new string[]
                {
                    "Space wields easier for you, allowing you to unravel its mysteries. Teleportation abilities can be used again three times as fast and you can travel ten times as far. You notice fissures between realms at a distance of 50 [200] kilometers. This distance can vary depending on the size and extent of the fissure.",
                    "Prevent enemy teleportation spells within a sphere around you at a radius of 50 meters. You cannot teleport while this skill is active.",
                    "Your understanding of space magic grows. You learn to latch on to ongoing teleportation spells with your own teleportation abilities. Long range and channeled teleportation spells have their range doubled and their cooldown as well as cost reduced by half."
                },
                new Guid[]
                {
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                    guidGenerator.GetNext(),
                },
                skills[5].Id);

            modelBuilder.Entity<Skill>().HasMany(s => s.Categories).WithMany(c => c.Skills)
                .UsingEntity(j => j
                    .ToTable("CategorySkill")
                    .HasData(new[]
                    {
                        new { CategoriesId = spaceMagicCategory.Id, SkillsId = skills[5].Id },
                    }));

            #endregion

            #endregion
        }

        private void AddTierDescriptionsToSkill(ModelBuilder modelBuilder, string[] tierDescriptions,
            Guid[] tierDescriptionIds, Guid skillId)
        {
            for (int i = 0; i < tierDescriptions.Length; i++)
            {
                modelBuilder.Entity<TierDescription>().HasData(
                    new TierDescription()
                    {
                        Id = tierDescriptionIds[i],
                        Description = tierDescriptions[i],
                        Tier = i + 1,
                        SkillId = skillId
                    });
            }
        }
    }
}