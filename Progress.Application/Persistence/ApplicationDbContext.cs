using Microsoft.EntityFrameworkCore;
using Progress.Application.Persistence.Entities;

namespace Progress.Application.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string characterStatusId = "afa42078-a071-4bea-978e-f439c713848c";

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
                    ThirdTierGeneralSkillpoints = 3
                });

            #region categories
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = new Guid("572ba72e-87df-45bf-9496-a2b9d8962c7d"),
                    DisplayColor = "#000000",
                    Name = "Arcane Magic"
                },
                new Category
                {
                    Id = new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"),
                    DisplayColor = "#000000",
                    Name = "Body Enhancement"
                },
                new Category
                {
                    Id = new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"),
                    DisplayColor = "#000000",
                    Name = "Healing Magic"
                },
                new Category
                {
                    Id = new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"),
                    DisplayColor = "#000000",
                    Name = "Cosmic Magic"
                },
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
                new Category
                {
                    Id = new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"),
                    DisplayColor = "#000000",
                    Name = "Ashen Magic"
                },
                new Category
                {
                    Id = new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"),
                    DisplayColor = "#000000",
                    Name = "Fire Magic"
                },
                new Category
                {
                    Id = new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"),
                    DisplayColor = "#000000",
                    Name = "Space Magic"
                },
                new Category
                {
                    Id = new Guid("f8f302ab-7ed7-47a9-85c1-2d570478a99a"),
                    DisplayColor = "#000000",
                    Name = "Flesh Magic"
                },
                new Category
                {
                    Id = new Guid("4538069f-9680-4b26-84a4-e608d1c86606"),
                    DisplayColor = "#000000",
                    Name = "Mind Magic"
                },
                new Category
                {
                    Id = new Guid("12696ef5-a857-466f-a618-43ee092816ee"),
                    DisplayColor = "#000000",
                    Name = "Ice Magic"
                },
                new Category
                {
                    Id = new Guid("94cb02e4-43dc-4021-95ac-d9d5bc6512d6"),
                    DisplayColor = "#000000",
                    Name = "Lava Magic"
                },
                new Category
                {
                    Id = new Guid("11751928-c2d3-4939-9692-05f578af3d00"),
                    DisplayColor = "#000000",
                    Name = "Earth Magic"
                }
            );
            #endregion


            var resources = new[]
            {
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid("70eaef56-21c1-494d-a0ba-312478c19428"),
                    DisplayName = "Health",
                    CalculationName = "Health",
                    BaseStatName = "Vitality",
                    ResourcePointsPerBaseStatPoint = 10
                },
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid("f8a10c54-df2b-4658-9e37-ff772a55aea3"),
                    DisplayName = "Stamina",
                    CalculationName = "Stamina",
                    BaseStatName = "Endurance",
                    ResourcePointsPerBaseStatPoint = 10
                },
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid("97f54c26-273e-47fc-b00f-7c5ad5b6cfae"),
                    DisplayName = "Mana",
                    CalculationName = "Mana",
                    BaseStatName = "Wisdom",
                    ResourcePointsPerBaseStatPoint = 10
                },
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid("741e7652-0c8e-4cb8-8ac4-b298637ae6c2"),
                    DisplayName = "Mana (Essence)",
                    CalculationName = "Health",
                    BaseStatName = "Vitality",
                    ResourcePointsPerBaseStatPoint = 10
                },
            };

            modelBuilder.Entity<CharacterStatus>().HasData(
                new CharacterStatus()
                {
                    Id = new Guid(characterStatusId),
                    UnspentStatpoints = 25
                });

            modelBuilder.Entity<Resource>().HasData(resources);

            #region stats
            modelBuilder.Entity<Stat>().HasData(
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df"),
                    Name = "Vitality",
                    Value = 3800
                },
                new
                {
                    CharacterStatusId = new Guid(characterStatusId),
                    Id = new Guid("ab85915d-e66f-4460-96af-e90f171ccab5"),
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
                    Id = new Guid("c6474033-2e4c-4805-95f3-4fe22e9de88a"),
                    Name = "Wisdom",
                    Value = 4000
                }
            );
            #endregion
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CharacterStatus> CharacterStatuses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Stat> Stats { get; set; }
    }
}
