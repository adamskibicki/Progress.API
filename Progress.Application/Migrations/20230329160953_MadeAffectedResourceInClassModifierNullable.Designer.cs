﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Progress.Application.Persistence;

#nullable disable

namespace Progress.Application.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230329160953_MadeAffectedResourceInClassModifierNullable")]
    partial class MadeAffectedResourceInClassModifierNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Progress.Application.Persistence.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("572ba72e-87df-45bf-9496-a2b9d8962c7d"),
                            DisplayColor = "#000000",
                            Name = "Arcane Magic"
                        },
                        new
                        {
                            Id = new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"),
                            DisplayColor = "#000000",
                            Name = "Body Enhancement"
                        },
                        new
                        {
                            Id = new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"),
                            DisplayColor = "#000000",
                            Name = "Healing Magic"
                        },
                        new
                        {
                            Id = new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"),
                            DisplayColor = "#000000",
                            Name = "Cosmic Magic"
                        },
                        new
                        {
                            Id = new Guid("cdb7b315-0277-451c-9ff0-ea5f1fce8c25"),
                            DisplayColor = "#000000",
                            Name = "Aura"
                        },
                        new
                        {
                            Id = new Guid("f8362bfc-6004-43df-827f-17f21203c6f3"),
                            DisplayColor = "#000000",
                            Name = "Teleportation Magic"
                        },
                        new
                        {
                            Id = new Guid("65728378-090f-4c29-9e87-b282f489d028"),
                            DisplayColor = "#000000",
                            Name = "Perception Aura"
                        },
                        new
                        {
                            Id = new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"),
                            DisplayColor = "#000000",
                            Name = "Ashen Magic"
                        },
                        new
                        {
                            Id = new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"),
                            DisplayColor = "#000000",
                            Name = "Fire Magic"
                        },
                        new
                        {
                            Id = new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"),
                            DisplayColor = "#000000",
                            Name = "Space Magic"
                        },
                        new
                        {
                            Id = new Guid("f8f302ab-7ed7-47a9-85c1-2d570478a99a"),
                            DisplayColor = "#000000",
                            Name = "Flesh Magic"
                        },
                        new
                        {
                            Id = new Guid("4538069f-9680-4b26-84a4-e608d1c86606"),
                            DisplayColor = "#000000",
                            Name = "Mind Magic"
                        },
                        new
                        {
                            Id = new Guid("12696ef5-a857-466f-a618-43ee092816ee"),
                            DisplayColor = "#000000",
                            Name = "Ice Magic"
                        },
                        new
                        {
                            Id = new Guid("94cb02e4-43dc-4021-95ac-d9d5bc6512d6"),
                            DisplayColor = "#000000",
                            Name = "Lava Magic"
                        },
                        new
                        {
                            Id = new Guid("11751928-c2d3-4939-9692-05f578af3d00"),
                            DisplayColor = "#000000",
                            Name = "Earth Magic"
                        });
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.CharacterClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CharacterStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterStatusId");

                    b.ToTable("CharacterClasses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            Level = 1004,
                            Name = "The Cosmic Immortal"
                        },
                        new
                        {
                            Id = new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            Level = 1001,
                            Name = "The Pyroclastic Storm"
                        },
                        new
                        {
                            Id = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            Level = 1002,
                            Name = "The Sunforged Realmwalker"
                        });
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.CharacterStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UnspentStatpoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CharacterStatuses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            UnspentStatpoints = 25
                        });
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.ClassModifier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AffectedResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryCalculationType")
                        .HasColumnType("int");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PercentagePointsOfCategoryIncrease")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AffectedResourceId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClassId");

                    b.ToTable("ClassModifiers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2218f3c7-591f-40eb-9f48-38b4f958440d"),
                            AffectedResourceId = new Guid("97f54c26-273e-47fc-b00f-7c5ad5b6cfae"),
                            CategoryCalculationType = 4,
                            ClassId = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            Description = "Your mana capacity is multiplied by five",
                            PercentagePointsOfCategoryIncrease = 500
                        },
                        new
                        {
                            Id = new Guid("20ac1928-5cff-4504-a926-e253c38891d8"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"),
                            ClassId = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            Description = "Body enhancement magic is improved by 500%",
                            PercentagePointsOfCategoryIncrease = 500
                        },
                        new
                        {
                            Id = new Guid("c2ef6ecc-a8ba-4d0c-a9fd-f0d3dfcf11cf"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"),
                            ClassId = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            Description = "All healing magic skills are improved by 500%",
                            PercentagePointsOfCategoryIncrease = 500
                        },
                        new
                        {
                            Id = new Guid("c37f99aa-4fe2-4ea0-9cbe-63a646a26d1a"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("842269cc-6ac4-4c91-8e86-66787ed92c8c"),
                            ClassId = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            Description = "All cosmic magic skills are improved by 250%",
                            PercentagePointsOfCategoryIncrease = 250
                        },
                        new
                        {
                            Id = new Guid("26d1fd63-e8ce-47ff-9587-b43948baf4d5"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            Description = "Natural health regeneration is increased by 1% per minute",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("a9f8276e-272e-443d-a161-549e43525cce"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            Description = "Natural mana regeneration is increased by 1% per minute",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("6d66a14d-e883-4704-bc2d-8acbfbefecad"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            Description = "Food, water and sleep needed to sustain yourself are no longer required",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("d9c0563a-a568-4809-b798-bdf387475b38"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            Description = "You do not age",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("4a356fc3-234a-4e1e-9091-210132ff23d1"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            Description = "You can absorb and use 25% of the ambient mana around you",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("e58a8112-38b5-4970-b38d-53866b4c8543"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            Description = "All mana regeneration increases by 1% to a maximum of 100% for every second you are not hit by an enemy attack",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("5274cf3c-f1cb-4fc8-8175-8f202d7d47c3"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            Description = "Excess generated mana instead charges a second mana pool equaling your total health [0/125400]. Mana from this pool can be transferred into your main mana pool at will",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("1d2154a7-a236-4afa-b9cc-5f913c5a6468"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("c2782453-16ab-4d52-923d-97c6a2b40029"),
                            Description = "You may infuse any barrier, wall, or magical armor with cosmic energy",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("988af334-4b7e-4c7e-ae51-c5f3362ae0ef"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"),
                            ClassId = new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"),
                            Description = "Body enhancement magic is improved by 500%",
                            PercentagePointsOfCategoryIncrease = 500
                        },
                        new
                        {
                            Id = new Guid("ea583586-3ebb-4680-9092-250882d6c90f"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("b1cbe616-e004-4b34-97eb-3d11d2f5f059"),
                            ClassId = new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"),
                            Description = "All Ashen magic skills are improved by 500%",
                            PercentagePointsOfCategoryIncrease = 500
                        },
                        new
                        {
                            Id = new Guid("a37dff49-7a62-4355-b6d4-7dccc452a247"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"),
                            ClassId = new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"),
                            Description = "All Fire magic skills are improved by 250%",
                            PercentagePointsOfCategoryIncrease = 250
                        },
                        new
                        {
                            Id = new Guid("9d0ab750-a179-4107-8349-e17d2d4dc88e"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"),
                            Description = "All fighting styles using hand to hand combat are more refined",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("268eb8e9-5be0-4d4d-b29d-0ce1f6bcacca"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"),
                            Description = "Your will is ash and heat",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("1382a487-16d5-4356-b1a2-a391cbaa7f53"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"),
                            Description = "You cannot be stunned by enemy attacks",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("6db597af-34bb-4660-ac70-e7d9bb482088"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"),
                            Description = "Your bones and muscles have vastly increased density",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("29185439-b3d7-4648-847d-7709cb46faa1"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("453c74bc-e480-44c2-82ea-13e3e49f821b"),
                            Description = "Your heat generation is increased by 1000%",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("a070e26f-c73c-487f-9fdd-d73286650e22"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("e5451fe8-a092-45bf-9bbd-728fb10ed6ff"),
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Space Magic is improved by 500%",
                            PercentagePointsOfCategoryIncrease = 500
                        },
                        new
                        {
                            Id = new Guid("09e97cee-34b2-4aea-9b47-b7160339de10"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Resilience is increased by 500%",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("fe07af4f-38e6-4e99-9f9d-3bd29692bded"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("b28d8f6f-6ea3-4640-a3d3-acf857dbc00b"),
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Body Enhancement Magic is improved by 300%",
                            PercentagePointsOfCategoryIncrease = 300
                        },
                        new
                        {
                            Id = new Guid("53b6d5e7-cd28-45a4-a7c8-72cc361b8e9b"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("29543eb0-73d9-4fd5-8abc-1ebd3c92d9e3"),
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Fire Magic is improved by 200%",
                            PercentagePointsOfCategoryIncrease = 200
                        },
                        new
                        {
                            Id = new Guid("8bb31795-7294-42f3-9347-1e8b31596065"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("f8f302ab-7ed7-47a9-85c1-2d570478a99a"),
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Flesh Magic is improved by 100%",
                            PercentagePointsOfCategoryIncrease = 100
                        },
                        new
                        {
                            Id = new Guid("a24ac0ce-4fc0-4f2c-ae22-dbed4a108808"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("a9a1f9c4-f80b-4a14-a9e4-82751f95c972"),
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Healing Magic is improved by 100%",
                            PercentagePointsOfCategoryIncrease = 100
                        },
                        new
                        {
                            Id = new Guid("2af0ee40-2ea0-4b2c-abc6-22a15b37fb19"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("4538069f-9680-4b26-84a4-e608d1c86606"),
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Mind Magic is improved by 100%",
                            PercentagePointsOfCategoryIncrease = 100
                        },
                        new
                        {
                            Id = new Guid("d2168950-990e-42d5-9b43-8b556aeb4741"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("12696ef5-a857-466f-a618-43ee092816ee"),
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Ice Magic is improved by 100%",
                            PercentagePointsOfCategoryIncrease = 100
                        },
                        new
                        {
                            Id = new Guid("2cc5563c-4e6f-4785-9d7a-f334fc6600aa"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("94cb02e4-43dc-4021-95ac-d9d5bc6512d6"),
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Lava Magic is improved by 100%",
                            PercentagePointsOfCategoryIncrease = 100
                        },
                        new
                        {
                            Id = new Guid("6c72a67a-beff-4d01-a746-3350677d2832"),
                            CategoryCalculationType = 0,
                            CategoryId = new Guid("11751928-c2d3-4939-9692-05f578af3d00"),
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Earth Magic is improved by 100%",
                            PercentagePointsOfCategoryIncrease = 100
                        },
                        new
                        {
                            Id = new Guid("a0ee0c09-5d9f-4577-9d16-c597fb97d36d"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Your Soul has been strengthened by the Primordial Flame",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("cb4fb181-c7a8-4007-afdf-e68bcf328c9b"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Your skin grows more resilient",
                            PercentagePointsOfCategoryIncrease = 0
                        },
                        new
                        {
                            Id = new Guid("9c725771-e1b1-4a34-a2bf-db707b546077"),
                            CategoryCalculationType = 0,
                            ClassId = new Guid("6689fb11-732c-4fda-af01-abde9895dc16"),
                            Description = "Greatly increases the heat you can store within your body and soul",
                            PercentagePointsOfCategoryIncrease = 0
                        });
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BaseStatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CharacterStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResourcePointsPerBaseStatPoint")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BaseStatId");

                    b.HasIndex("CharacterStatusId");

                    b.ToTable("Resources");

                    b.HasData(
                        new
                        {
                            Id = new Guid("70eaef56-21c1-494d-a0ba-312478c19428"),
                            BaseStatId = new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            DisplayName = "Health",
                            ResourcePointsPerBaseStatPoint = 10
                        },
                        new
                        {
                            Id = new Guid("f8a10c54-df2b-4658-9e37-ff772a55aea3"),
                            BaseStatId = new Guid("ab85915d-e66f-4460-96af-e90f171ccab5"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            DisplayName = "Stamina",
                            ResourcePointsPerBaseStatPoint = 10
                        },
                        new
                        {
                            Id = new Guid("97f54c26-273e-47fc-b00f-7c5ad5b6cfae"),
                            BaseStatId = new Guid("c6474033-2e4c-4805-95f3-4fe22e9de88a"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            DisplayName = "Mana",
                            ResourcePointsPerBaseStatPoint = 10
                        },
                        new
                        {
                            Id = new Guid("741e7652-0c8e-4cb8-8ac4-b298637ae6c2"),
                            BaseStatId = new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            DisplayName = "Mana (Essence)",
                            ResourcePointsPerBaseStatPoint = 10
                        });
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.Stat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CharacterStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterStatusId");

                    b.ToTable("Stats");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1bf1d8dd-7cc3-486d-bb26-0bde4ee439df"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            Name = "Vitality",
                            Value = 3800
                        },
                        new
                        {
                            Id = new Guid("ab85915d-e66f-4460-96af-e90f171ccab5"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            Name = "Endurance",
                            Value = 600
                        },
                        new
                        {
                            Id = new Guid("de4b423f-4718-4e26-9d75-14f4a1581b37"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            Name = "Strength",
                            Value = 860
                        },
                        new
                        {
                            Id = new Guid("20cce93e-f883-4860-be2f-4cdbd0c6e3be"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            Name = "Dexterity",
                            Value = 610
                        },
                        new
                        {
                            Id = new Guid("047e7614-496d-4519-a784-6dec5e753571"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            Name = "Intelligence",
                            Value = 3770
                        },
                        new
                        {
                            Id = new Guid("c6474033-2e4c-4805-95f3-4fe22e9de88a"),
                            CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                            Name = "Wisdom",
                            Value = 4000
                        });
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.CharacterClass", b =>
                {
                    b.HasOne("Progress.Application.Persistence.Entities.CharacterStatus", "CharacterStatus")
                        .WithMany("CharacterClasses")
                        .HasForeignKey("CharacterStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacterStatus");
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.CharacterStatus", b =>
                {
                    b.OwnsOne("Progress.Application.Persistence.Entities.BasicInformation", "BasicInformation", b1 =>
                        {
                            b1.Property<Guid>("CharacterStatusId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Title")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CharacterStatusId");

                            b1.ToTable("CharacterStatuses");

                            b1.WithOwner()
                                .HasForeignKey("CharacterStatusId");

                            b1.HasData(
                                new
                                {
                                    CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                                    Name = "Ilea Spears",
                                    Title = "Dragonslayer"
                                });
                        });

                    b.OwnsOne("Progress.Application.Persistence.Entities.UnspentSkillpoints", "UnspentSkillpoints", b1 =>
                        {
                            b1.Property<Guid>("CharacterStatusId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CoreSkillpoints")
                                .HasColumnType("int");

                            b1.Property<int>("FourthTierGeneralSkillpoints")
                                .HasColumnType("int");

                            b1.Property<int>("FourthTierSkillpoints")
                                .HasColumnType("int");

                            b1.Property<int>("ThirdTierGeneralSkillpoints")
                                .HasColumnType("int");

                            b1.HasKey("CharacterStatusId");

                            b1.ToTable("CharacterStatuses");

                            b1.WithOwner()
                                .HasForeignKey("CharacterStatusId");

                            b1.HasData(
                                new
                                {
                                    CharacterStatusId = new Guid("afa42078-a071-4bea-978e-f439c713848c"),
                                    CoreSkillpoints = 10,
                                    FourthTierGeneralSkillpoints = 1,
                                    FourthTierSkillpoints = 1,
                                    ThirdTierGeneralSkillpoints = 3
                                });
                        });

                    b.Navigation("BasicInformation");

                    b.Navigation("UnspentSkillpoints");
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.ClassModifier", b =>
                {
                    b.HasOne("Progress.Application.Persistence.Entities.Resource", "AffectedResource")
                        .WithMany("AffectingClassModifiers")
                        .HasForeignKey("AffectedResourceId");

                    b.HasOne("Progress.Application.Persistence.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Progress.Application.Persistence.Entities.CharacterClass", "Class")
                        .WithMany("ClassModifiers")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AffectedResource");

                    b.Navigation("Category");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.Resource", b =>
                {
                    b.HasOne("Progress.Application.Persistence.Entities.Stat", "BaseStat")
                        .WithMany()
                        .HasForeignKey("BaseStatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Progress.Application.Persistence.Entities.CharacterStatus", null)
                        .WithMany("Resources")
                        .HasForeignKey("CharacterStatusId");

                    b.Navigation("BaseStat");
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.Stat", b =>
                {
                    b.HasOne("Progress.Application.Persistence.Entities.CharacterStatus", null)
                        .WithMany("Stats")
                        .HasForeignKey("CharacterStatusId");
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.CharacterClass", b =>
                {
                    b.Navigation("ClassModifiers");
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.CharacterStatus", b =>
                {
                    b.Navigation("CharacterClasses");

                    b.Navigation("Resources");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("Progress.Application.Persistence.Entities.Resource", b =>
                {
                    b.Navigation("AffectingClassModifiers");
                });
#pragma warning restore 612, 618
        }
    }
}
