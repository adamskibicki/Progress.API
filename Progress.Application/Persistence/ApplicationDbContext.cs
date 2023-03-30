using Microsoft.EntityFrameworkCore;
using Progress.Application.Persistence.Entities;
using Progress.Application.Usecases.Status;

namespace Progress.Application.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<CharacterStatus> CharacterStatuses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Stat> Stats { get; set; }

        public DbSet<ClassModifier> ClassModifiers { get; set; }

        public DbSet<CharacterClass> CharacterClasses { get; set; }

        public DbSet<UserCharacter> UserCharacters { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string userCharacterId = "0da44e54-90ea-4ad0-a409-ea0cb1d38c4a";

            string characterStatusId = "afa42078-a071-4bea-978e-f439c713848c";

            string vitalityStatId = "1bf1d8dd-7cc3-486d-bb26-0bde4ee439df";
            string enduranceStatId = "ab85915d-e66f-4460-96af-e90f171ccab5";
            string wisdomStatId = "c6474033-2e4c-4805-95f3-4fe22e9de88a";

            string firstClassId = "c2782453-16ab-4d52-923d-97c6a2b40029";
            string secondClassId = "453c74bc-e480-44c2-82ea-13e3e49f821b";
            string thirdClassId = "6689fb11-732c-4fda-af01-abde9895dc16";

            string manaResourceId = "97f54c26-273e-47fc-b00f-7c5ad5b6cfae";

            modelBuilder.Entity<CharacterClass>().HasData(new CharacterClass
            {
                Id = new Guid(firstClassId),
                CharacterStatusId = new Guid(characterStatusId),
                Name = "The Cosmic Immortal",
                Level = 1004,
            },
            new CharacterClass
            {
                Id = new Guid(secondClassId),
                CharacterStatusId = new Guid(characterStatusId),
                Name = "The Pyroclastic Storm",
                Level = 1001,
            },
            new CharacterClass
            {
                Id = new Guid(thirdClassId),
                CharacterStatusId = new Guid(characterStatusId),
                Name = "The Sunforged Realmwalker",
                Level = 1002,
            });

            modelBuilder.Entity<UserCharacter>().HasData(new UserCharacter()
            {
                Id = new Guid(userCharacterId)
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

            #region categories

            var bodyEnhancementCategory = new Category
            {
                Id = new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"),
                DisplayColor = "#000000",
                Name = "Body Enhancement"
            };
            var healingMagicCategory = new Category
            {
                Id = new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"),
                DisplayColor = "#000000",
                Name = "Healing Magic"
            };
            var cosmicMagicCategory = new Category
            {
                Id = new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"),
                DisplayColor = "#000000",
                Name = "Cosmic Magic"
            };
            var ashenMagicCategory = new Category
            {
                Id = new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"),
                DisplayColor = "#000000",
                Name = "Ashen Magic"
            };
            var fireMagicCategory = new Category
            {
                Id = new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"),
                DisplayColor = "#000000",
                Name = "Fire Magic"
            };
            var spaceMagicCategory = new Category
            {
                Id = new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"),
                DisplayColor = "#000000",
                Name = "Space Magic"
            };
            var mindMagicCategory = new Category
            {
                Id = new Guid("4538069f-9680-4b26-84a4-e608d1c86606"),
                DisplayColor = "#000000",
                Name = "Mind Magic"
            };
            var fleshMagicCategory = new Category
            {
                Id = new Guid("f8f302ab-7ed7-47a9-85c1-2d570478a99a"),
                DisplayColor = "#000000",
                Name = "Flesh Magic"
            };
            var iceMagicCategory = new Category
            {
                Id = new Guid("12696ef5-a857-466f-a618-43ee092816ee"),
                DisplayColor = "#000000",
                Name = "Ice Magic"
            };
            var lavaMagicCategory = new Category
            {
                Id = new Guid("94cb02e4-43dc-4021-95ac-d9d5bc6512d6"),
                DisplayColor = "#000000",
                Name = "Lava Magic"
            };
            var earthMagicCategory = new Category
            {
                Id = new Guid("11751928-c2d3-4939-9692-05f578af3d00"),
                DisplayColor = "#000000",
                Name = "Earth Magic"
            };

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = new Guid("572ba72e-87df-45bf-9496-a2b9d8962c7d"),
                    DisplayColor = "#000000",
                    Name = "Arcane Magic"
                },
                bodyEnhancementCategory,
                healingMagicCategory,
                cosmicMagicCategory,
                new Category
                {
                    Id = new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"),
                    DisplayColor = "#000000",
                    Name = "Aura"
                },
                new Category
                {
                    Id = new Guid("f8362bfc-6004-43df-827f-17f21203c6f3"),
                    DisplayColor = "#000000",
                    Name = "Teleportation Magic"
                },
                new Category
                {
                    Id = new Guid("65728378-090f-4c29-9e87-b282f489d028"),
                    DisplayColor = "#000000",
                    Name = "Perception Aura"
                },
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

            #region class modifiers
            var class1Modifiers = new[]
            {
                new ClassModifier()
                {
                    Id = new Guid("20ac1928-5cff-4504-a926-e253c38891d8"),
                    ClassId = new Guid(firstClassId),
                    Description = "Body enhancement magic is improved by 500%",
                    CategoryId = bodyEnhancementCategory.Id,
                    PercentagePointsOfCategoryIncrease = 500
                },
                new ClassModifier()
                {
                    Id = new Guid("c2ef6ecc-a8ba-4d0c-a9fd-f0d3dfcf11cf"),
                    ClassId = new Guid(firstClassId),
                    Description = "All healing magic skills are improved by 500%",
                    CategoryId = healingMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 500
                },
                new ClassModifier()
                {
                    Id = new Guid("c37f99aa-4fe2-4ea0-9cbe-63a646a26d1a"),
                    ClassId = new Guid(firstClassId),
                    Description = "All cosmic magic skills are improved by 250%",
                    CategoryId = cosmicMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 250
                },
                new ClassModifier()
                {
                    Id = new Guid("26d1fd63-e8ce-47ff-9587-b43948baf4d5"),
                    ClassId = new Guid(firstClassId),
                    Description = "Natural health regeneration is increased by 1% per minute",
                    PercentagePointsOfCategoryIncrease = 0
                },
                new ClassModifier()
                {
                    Id = new Guid("a9f8276e-272e-443d-a161-549e43525cce"),
                    ClassId = new Guid(firstClassId),
                    Description = "Natural mana regeneration is increased by 1% per minute",
                },
                new ClassModifier()
                {
                    Id = new Guid("6d66a14d-e883-4704-bc2d-8acbfbefecad"),
                    ClassId = new Guid(firstClassId),
                    Description = "Food, water and sleep needed to sustain yourself are no longer required",
                },
                new ClassModifier()
                {
                    Id = new Guid("d9c0563a-a568-4809-b798-bdf387475b38"),
                    ClassId = new Guid(firstClassId),
                    Description = "You do not age",
                },
                new ClassModifier()
                {
                    Id = new Guid("4a356fc3-234a-4e1e-9091-210132ff23d1"),
                    ClassId = new Guid(firstClassId),
                    Description = "You can absorb and use 25% of the ambient mana around you",
                },
                new ClassModifier()
                {
                    Id = new Guid("e58a8112-38b5-4970-b38d-53866b4c8543"),
                    ClassId = new Guid(firstClassId),
                    Description = "All mana regeneration increases by 1% to a maximum of 100% for every second you are not hit by an enemy attack",
                },
                new ClassModifier()
                {
                    Id = new Guid("5274cf3c-f1cb-4fc8-8175-8f202d7d47c3"),
                    ClassId = new Guid(firstClassId),
                    Description = "Excess generated mana instead charges a second mana pool equaling your total health [0/125400]. Mana from this pool can be transferred into your main mana pool at will",
                },
                new ClassModifier()
                {
                    Id = new Guid("1d2154a7-a236-4afa-b9cc-5f913c5a6468"),
                    ClassId = new Guid(firstClassId),
                    Description = "You may infuse any barrier, wall, or magical armor with cosmic energy",
                }
            };

            var additionalClass1Modifier = new
            {
                Id = new Guid("2218f3c7-591f-40eb-9f48-38b4f958440d"),
                ClassId = new Guid(firstClassId),
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
                    ClassId = new Guid(secondClassId),
                    Description = "Body enhancement magic is improved by 500%",
                    CategoryId = bodyEnhancementCategory.Id,
                    PercentagePointsOfCategoryIncrease = 500
                },
                new ClassModifier()
                {
                    Id = new Guid("ea583586-3ebb-4680-9092-250882d6c90f"),
                    ClassId = new Guid(secondClassId),
                    Description = "All Ashen magic skills are improved by 500%",
                    CategoryId = ashenMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 500
                },
                new ClassModifier()
                {
                    Id = new Guid("a37dff49-7a62-4355-b6d4-7dccc452a247"),
                    ClassId = new Guid(secondClassId),
                    Description = "All Fire magic skills are improved by 250%",
                    CategoryId = fireMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 250
                },
                new ClassModifier()
                {
                    Id = new Guid("9d0ab750-a179-4107-8349-e17d2d4dc88e"),
                    ClassId = new Guid(secondClassId),
                    Description = "All fighting styles using hand to hand combat are more refined",
                },
                new ClassModifier()
                {
                    Id = new Guid("268eb8e9-5be0-4d4d-b29d-0ce1f6bcacca"),
                    ClassId = new Guid(secondClassId),
                    Description = "Your will is ash and heat",
                },
                new ClassModifier()
                {
                    Id = new Guid("1382a487-16d5-4356-b1a2-a391cbaa7f53"),
                    ClassId = new Guid(secondClassId),
                    Description = "You cannot be stunned by enemy attacks",
                },
                new ClassModifier()
                {
                    Id = new Guid("6db597af-34bb-4660-ac70-e7d9bb482088"),
                    ClassId = new Guid(secondClassId),
                    Description = "Your bones and muscles have vastly increased density",
                },
                new ClassModifier()
                {
                    Id = new Guid("29185439-b3d7-4648-847d-7709cb46faa1"),
                    ClassId = new Guid(secondClassId),
                    Description = "Your heat generation is increased by 1000%",
                }
            };

            var class3Modifiers = new[]
            {
                new ClassModifier()
                {
                    Id = new Guid("a070e26f-c73c-487f-9fdd-d73286650e22"),
                    ClassId = new Guid(thirdClassId),
                    Description = "Space Magic is improved by 500%",
                    CategoryId = spaceMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 500
                },
                new ClassModifier()
                {
                    Id = new Guid("09e97cee-34b2-4aea-9b47-b7160339de10"),
                    ClassId = new Guid(thirdClassId),
                    Description = "Resilience is increased by 500%",
                },
                new ClassModifier()
                {
                    Id = new Guid("fe07af4f-38e6-4e99-9f9d-3bd29692bded"),
                    ClassId = new Guid(thirdClassId),
                    Description = "Body Enhancement Magic is improved by 300%",
                    CategoryId = bodyEnhancementCategory.Id,
                    PercentagePointsOfCategoryIncrease = 300
                },
                new ClassModifier()
                {
                    Id = new Guid("53b6d5e7-cd28-45a4-a7c8-72cc361b8e9b"),
                    ClassId = new Guid(thirdClassId),
                    Description = "Fire Magic is improved by 200%",
                    CategoryId = fireMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 200
                },
                new ClassModifier()
                {
                    Id = new Guid("8bb31795-7294-42f3-9347-1e8b31596065"),
                    ClassId = new Guid(thirdClassId),
                    Description = "Flesh Magic is improved by 100%",
                    CategoryId = fleshMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 100
                },
                new ClassModifier()
                {
                    Id = new Guid("a24ac0ce-4fc0-4f2c-ae22-dbed4a108808"),
                    ClassId = new Guid(thirdClassId),
                    Description = "Healing Magic is improved by 100%",
                    CategoryId = healingMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 100
                },
                new ClassModifier()
                {
                    Id = new Guid("2af0ee40-2ea0-4b2c-abc6-22a15b37fb19"),
                    ClassId = new Guid(thirdClassId),
                    Description = "Mind Magic is improved by 100%",
                    CategoryId = mindMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 100
                },
                new ClassModifier()
                {
                    Id = new Guid("d2168950-990e-42d5-9b43-8b556aeb4741"),
                    ClassId = new Guid(thirdClassId),
                    Description = "Ice Magic is improved by 100%",
                    CategoryId = iceMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 100
                },
                new ClassModifier()
                {
                    Id = new Guid("2cc5563c-4e6f-4785-9d7a-f334fc6600aa"),
                    ClassId = new Guid(thirdClassId),
                    Description = "Lava Magic is improved by 100%",
                    CategoryId = lavaMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 100
                },
                new ClassModifier()
                {
                    Id = new Guid("6c72a67a-beff-4d01-a746-3350677d2832"),
                    ClassId = new Guid(thirdClassId),
                    Description = "Earth Magic is improved by 100%",
                    CategoryId = earthMagicCategory.Id,
                    PercentagePointsOfCategoryIncrease = 100
                },
                new ClassModifier()
                {
                    Id = new Guid("a0ee0c09-5d9f-4577-9d16-c597fb97d36d"),
                    ClassId = new Guid(thirdClassId),
                    Description = "Your Soul has been strengthened by the Primordial Flame",
                },
                new ClassModifier()
                {
                    Id = new Guid("cb4fb181-c7a8-4007-afdf-e68bcf328c9b"),
                    ClassId = new Guid(thirdClassId),
                    Description = "Your skin grows more resilient",
                },
                new ClassModifier()
                {
                    Id = new Guid("9c725771-e1b1-4a34-a2bf-db707b546077"),
                    ClassId = new Guid(thirdClassId),
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
                    CreatedAt = DateTimeOffset.UtcNow,
                });

            modelBuilder.Entity<Resource>().HasData(resources);

            #region stats
            modelBuilder.Entity<Stat>().HasData(
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(vitalityStatId),
                    Name = "Vitality",
                    Value = 3800
                },
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(enduranceStatId),
                    Name = "Endurance",
                    Value = 600
                },
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid("de4b423f-4718-4e26-9d75-14f4a1581b37"),
                    Name = "Strength",
                    Value = 860
                },
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid("20cce93e-f883-4860-be2f-4cdbd0c6e3be"),
                    Name = "Dexterity",
                    Value = 610
                },
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid("047e7614-496d-4519-a784-6dec5e753571"),
                    Name = "Intelligence",
                    Value = 3770
                },
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid(wisdomStatId),
                    Name = "Wisdom",
                    Value = 4000
                }
            );
            #endregion
        }
    }
}
