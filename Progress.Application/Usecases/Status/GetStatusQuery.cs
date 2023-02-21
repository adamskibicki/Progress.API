using MediatR;
using Progress.Application.Usecases.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Application.Usecases.Status
{
    public class GetStatusQuery : IRequest<StatusDto>
    {
        public Guid StatusId { get; set; }
    }

    public class GetStatusQueryHandler : IRequestHandler<GetStatusQuery, StatusDto>
    {
        public Task<StatusDto> Handle(GetStatusQuery request, CancellationToken cancellationToken)
        {
            var result = new StatusDto()
            {
                GeneralInformation = new GeneralInformationDto()
                {
                    BasicInfo = new BasicInformationDto()
                    {
                        Name = "Ilea Spears",
                        Title = "Dragonslayer"
                    },
                    ResourcesStatus = new ResourcesStatusDto()
                    {
                        MaxHealth = 1500000,
                        MaxMana = 2000000,
                        MaxStamina = 60000
                    },
                    Skillpoints = new UnspentSkillpointsDto()
                    {
                        CoreSkillpoints = 10,
                        FourthTierGeneralSkillpoints = 1,
                        FourthTierSkillpoints = 1,
                        ThirdTierGeneralSkillpoints = 3
                    },
                    Stats = new StatsDto()
                    {
                        UnspentStatpoints = 25,
                        Stats = new StatDto[]
                        {
                            new StatDto()
                            {
                                Name = "Vitality",
                                Value = 3300
                            },
                            new StatDto()
                            {
                                Name = "Endurance",
                                Value = 600
                            },
                            new StatDto()
                            {
                                Name = "Strength",
                                Value = 600
                            },
                            new StatDto()
                            {
                                Name = "Dexterity",
                                Value = 600
                            },
                            new StatDto()
                            {
                                Name = "Intelligence",
                                Value = 3300
                            },
                            new StatDto()
                            {
                                Name = "Wisdom",
                                Value = 3600
                            }
                        }
                    }
                },
                Classes = new ClassDto[]
                {
                    new ClassDto()
                    {
                        Name = "The Cosmic Immortal",
                        Level = 1004,
                        Skills = new SkillDto[]
                        {
                            new SkillDto()
                            {
                                Name = "Cosmic Deconstruction",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "Send a pulse of deconstructing cosmic power into an object, spell, or creature within your domain with every motion using your arms, fists, fingers, legs, feet, or head. Your Intelligence stat enhances the damage potential.",
                                    "The amount of mana used per pulse can be regulated with a maximum of 5000 mana per pulse. You may charge each pulse with 5000 mana per second to a maximum of 25000 mana. Once cosmic power resides within a target, you can rip it out with a reversed motion to cause additional damage. Cosmic power within a target stacks, depending on their defensive measures and structure.",
                                    "You may choose to use Cosmic Deconstruction as a non intrusive attack, instead sending out a broad wave of deconstructing energy from you at the center. The same motion requirements as in the first tier apply. If used as a wave, the range of Cosmic Deconstruction is equal to the range of your domain and is more effective against magical constructs."
                                },
                                Categories = new string[]
                                {
                                    "Healing Magic",
                                    "Cosmic Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "True Reconstruction",
                                Level = 1,
                                Tier = 4,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "Send a healing pulse of cosmic power into yourself or creatures within your domain. This skill can be channeled. In addition to health, True Reconstruction restores mana and heals damage to your soul.",
                                    "Your control is increased greatly, you can now focus your healing on specific parts of the body. As long as mana and health remains, your True Reconstruction will restore your body. Lose your head and see for yourself! Health loss and critical blows are recalculated due to the nature of your healing. You may restore magical constructs and enchantments with True Reconstruction.",
                                    "You have healed your body time and time again, knowing every cell and where it belongs. Sacrifice a large amount of mana to rush your healing to unprecedented speeds. Lack of knowledge about your body may result in heavy damage. Effect can be used on any creature or magical construct. Limited to 10’000 mana per use.",
                                    "You have healed yourself thousands of times. Have regrown lost limbs, have reformed lost organs. You have healed and protected your mind, all in pursuit of greater power. Healing to shield you. Healing to allow an exchange of blows, with those you would not otherwise be able to fight. A core ability for the Azarinth Healer, a terrifying tool for the Cosmic Immortal. You have grasped the true nature of Reconstruction. Not the healing spell of a savior, but a necessity for the battle healer you have become. Through the fourth tier, you have enhanced this ability to the pinnacle. Once active, cosmic energies will surge within your body. Not to heal wounds you have sustained, but to keep you fighting whatever enemy you face. To overwhelm the foes no other could dare stand against.\r\nIf you reach 0 points of health, all remaining mana is used to activate True Reconstruction, containing your essence in a set of powerful cosmic barriers protecting your remains from harm and restoring your life. This effect may activate once every 24 hours.\r\nFollowing benefits and changes will apply during use of the fourth tier:\r\n- All damage sustained is dealt to your mana instead of your health\r\n- The first stage of True Reconstruction will generate additional mana and health\r\n- All mana generation and absorption is doubled\r\n- Your body is pushed to the limits of cosmic power, enhancing all of your abilities\r\n- Your body sustains heavy damage from this flow of cosmic power. This ability will deactivate when your health drops below a certain point [1% - Set value] and cannot be used again for twice as long as it has been active\r\n- Once the 4th tier deactivates, a set of seven cosmic barriers appear around you to protect from enemy blows. You may control these barriers or allow them to automatically react to enemy attacks\r\n- You cannot use the third tier of True Reconstruction on your own body"
                                },
                                Categories = new string[]
                                {
                                    "Healing Magic",
                                    "Cosmic Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Embodiment of the Arcane",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "Your body glows with the power of the cosmos, increasing your resilience, speed, Intelligence, and Strength by 100% [1250%].",
                                    "Your sight, hearing and sense of smell is also affected by Embodiment of the Arcane.",
                                    "You are one with the Arcane. The skill’s upkeep has been removed. A static 25% of the base effect is applied to Wisdom. Does not affect the mana regeneration properties of the Wisdom stat."
                                },
                                Categories = new string[]
                                {
                                    "Aura",
                                    "Body Enhancement",
                                    "Cosmic Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Teleportation",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "Immediately appear anywhere in your domain or anywhere you can see with reliable clarity.",
                                    "The time between transfers is reduced greatly. No ground contact needed between transfers. Teleportation gains 3 charges, each with a separate cooldown. For 2 seconds after Teleportation is used, you may return to the original position in the fabric where the spell was initially activated.",
                                    "You may set ten destinations you touch. You may change each destination once per day. This cooldown is static. You may travel to each destination once every 25 minutes [12.5 minutes]. Cast time is reduced by a static 50% for destinations you have already teleported to."
                                },
                                Categories = new string[]
                                {
                                    "Teleportation Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Limitless Domain",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "Perceive everything in a sphere around you while this skill is activated. The higher the level the further your domain reaches. You may drain mana from creatures and spells within your domain.",
                                    "Arcane dominion opens your senses to the arcane. A paramount skill both on and off the battlefield. Elements and spells you control within your dominion have increased harmony. You drain the remaining mana from creatures you kill inside of your domain.",
                                    "Your element manipulation skills are improved by a static 100% when used within your dominion. Improves any of your mana absorption or drain abilities within your domain."
                                },
                                Categories = new string[]
                                {
                                    "Aura",
                                    "Perception Aura",
                                    "Cosmic Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Catalyst Core",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Passive,
                                TierDescriptions = new string[]
                                {
                                    "Your body was changed by magic. All pain is reduced greatly. Your body is 75% [1387.5%] more durable. You heal even fatal injuries without help of healing magic. Your natural Health and Mana regeneration is improved by 150% [2775%].",
                                    "The magic of the cosmos settles inside your body. Your resistance to magical, physical, and soul damage is increased by a static 35% [647.5%]. Your bones and muscles are five times as dense.",
                                    "Your body was battered and forged by magic. You absorb mana from enemy spells in your domain. Efficiency is determined by enemy mana used and your resistance to the type of magic. Mana cost for all skills reduced by a static 35%. Your body can absorb ambient mana. Amount dependent on availability and harmony."
                                },
                                Categories = new string[]
                                {
                                    "Healing",
                                    "Body Enhancement",
                                    "Cosmic Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Timeless Perception",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Passive,
                                TierDescriptions = new string[]
                                {
                                    "Vastly increases your perception and reflexes.",
                                    "Timeless Perception spikes for two seconds, should you be about to receive a blow that would take 50% or more of your health, or should your mind be incapacitated with an incoming blow. This can happen only once per hour.",
                                    "Your resilience and speed is doubled during the spike in perception. Increases usage to five times per hour. The effect duration is increased to three seconds and can be activated at will. You gain the ability to gauge enemy mana usage and may learn how strongly a direct hit of a spell will impact you. Increased ability to gauge incoming damage depending on your familiarity with the respective magic type."
                                },
                                Categories = new string[]
                                {
                                    "Body Enhancement",
                                    "Cosmic Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Cycle of Creation",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Passive,
                                TierDescriptions = new string[]
                                {
                                    "You have learned of Cosmic Deconstruction and True Reconstruction. Now you will learn of their Reversal.\r\nUpon activation, Cosmic Deconstruction will send a part of the struck enemy’s health and mana into yourself. No mana will be released on impact, rendering Cosmic Deconstruction’s offensive potential to zero.\r\nUpon activation, True Reconstruction will send a destructive force of channeled mana into yourself, a creature or magical construct within your domain, the healing aspects are reduced to zero.",
                                    "You may have both the original and reversed aspects activated at the same time. When an enemy partially or fully resists either Cosmic Deconstruction or True Reconstruction, you absorb the dissipating mana.",
                                    "Healing, power, resilience and speed. All requires balance. Your respective Deconstruction and Reconstruction spells have their potency increased by a static 25% of your median stat value. [488.75%]. You may channel health in addition to mana into the respective offensive uses of Archon Strike and Sentinel Reconstruction. Health cost to activate effects is reduced by a static 20%."
                                },
                                Categories = new string[]
                                {
                                    "Body Enhancement",
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Eternal Huntress",
                                Level = 30,
                                Tier = 3,
                                Enhanced = false,
                                Type = SkillType.Passive,
                                TierDescriptions = new string[]
                                {
                                    "Huntress turned Eternal. Your eyes are unmatched and so is your nose. Perceive the smallest irregularities in your surroundings as well as the ambient mana to find clues about your target’s whereabouts. Perceive the trails of dangerous prey.",
                                    "You gain a sense for the distress in the people around you. Amplify this by sacrificing mana. You gain a sense for the arcane, feeling even minor spells around you. As you practice to differentiate these spells, you will learn of their intent.",
                                    "Through Azarinth magic, you may mark an enemy or ally with the Eternal Mark. Allies may use the mark to send a short message to the Arcane Eternal once per day. The Arcane Eternal can send a short message to each non forcefully applied mark once per day. Each level in the third tier adds two additional marks that can be used. Marks forcefully applied have a limited duration."
                                },
                                Categories = new string[]
                                {
                                    "Body Enhancement"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Eternal Brawling",
                                Level = 30,
                                Tier = 3,
                                Enhanced = false,
                                Type = SkillType.Passive,
                                TierDescriptions = new string[]
                                {
                                    "You have adapted the fighting style of the Azarinth school to something you now call your own. Damage inflicted with your own body and related skills is 110% [990%] higher. Your arms, fists, fingers, legs, and head deal a slight amount of arcane damage with each strike.",
                                    "Getting used to fighting in close quarters, your reaction time is increased to accommodate your increasing speed and control. Your bones are steeped with mana, increasing both their weight and resilience two fold.",
                                    "Eternal Brawling consists of more than offense alone. A true brawler knows when to stand and let an enemy strike. You gain knowledge about sustained injuries and damage from incoming attacks as they happen."
                                },
                                Categories = new string[]
                                {
                                    "Body Enhancement",
                                    "Arcane Magic"
                                }
                            },
                        }
                    },
                    new ClassDto()
                    {
                        Name = "The Pyroclastic Storm",
                        Level = 1001,
                        Skills = new SkillDto[]
                        {
                            new SkillDto()
                            {
                                Name = "Ash Scale Armor",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "An armor of ash and hardened volcanic glass scales protects and fuses partially with your body, forming at your will. The Armor increases your resistance to heat and fire, as well as your overall resilience by 200% [3200%].",
                                    "The strength of your Resistance skills and your wings also benefit from Ash Scale Armor. The Armor is a part of your body. It benefits from natural regeneration. You can feel through your armor and you can heal it. Your Ash Scale Armor repairs minor damage on its own. If you armor is penetrated to the lowest layer, an explosion of heated smoke and volcanic glass is released at your enemy if you do not suppress the effect.",
                                    "Increases the defensive capabilities of all ash you control. Increase the ash used to form your armor by up to a static 500%. The additional ash used requires conscious manipulation. You may use Ash Scale Armor to defend willing allies. Amount of required ash dependent on size of the target. You may increase the ash used by another static 500%, reducing your total speed by a static 15% for each 100% of additional increase."
                                },
                                Categories = new string[]
                                {
                                    "Body Enhancement",
                                    "Ashen magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Draconic Core",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "Heat glows within you, raising your resilience, speed, Strength, Intelligence and Dexterity by 100% [1850%]. Your learn how to generate and store vast amounts of heat within your Draconic Core or your magical constructs.",
                                    "The longer you fight with Draconic Core active, the deeper it roots. Each second of fighting adds 1% more power to the skill with a maximum of a static [250%]. Once no longer engaged in battle, 1% of additionally generated power is lost per second.",
                                    "Familiarity with the skill removes its upkeep. You can choose to increase your weight by 1% [18.5%] for each passing second to a maximum of a static [1500%], increasing your natural health regeneration, heat generation, and resilience by the same factor."
                                },
                                Categories = new string[]
                                {
                                    "Aura",
                                    "Body Enhancement",
                                    "Ashen Magic",
                                    "Fire Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Pyroclastic Flow",
                                Level = 1,
                                Tier = 4,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "Create ash, smoke, and volcanic glass in a certain radius around you.",
                                    "You may vastly increase the density and heat of your ash, smoke, and volcanic glass.",
                                    "You have proven your dedication. The Pyroclastic Flow moves to aid and destroy at your whims. The amount of ash, smoke, and volcanic glass you can create is vastly increased.",
                                    "You are the Pyroclastic Storm. The Fourth Tier allows for true harmony."
                                },
                                Categories = new string[]
                                {
                                    "Ashen Magic",
                                    "Fire Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Volcanic Source",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "Vastly increase the heat in your body and release it in a blast or continuous heat around you.",
                                    "The fires run deep. The heat you may reach is only limited by your very life. Your resistance to heat held within your body is tripled.",
                                    "Focus on release to change the blast into a cone of destruction sent out of either arm. You may store heat within any ash, smoke, or volcanic glass that you control. Creations not connected to you release their stored heat upon a strong impact in a blast around it or when you will it. You learn to send out any stored heat as waves through your Pyroclastic Flow."
                                },
                                Categories = new string[]
                                {
                                    "Body Enhancement",
                                    "Ashen Magic",
                                    "Fire Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Scorching Intrusion",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "Burn the inside of whatever your body or your magical constructs touch with a surge of heat or release the attack in a violent burst.",
                                    "The heat burns on. Targets hit will have fire burning through or on them. Continuous use of Scorching Intrusion will increase the stored energy up to a breaking point where all is released in a violent explosion of fire and heat. Breaking point is dependent on enemy resilience and heat resistance.",
                                    "Scorching Intrusion damages mana intrusion capabilities of defensive enchantments, natural- as well as manufactured armor. Once a target is affected by Scorching Intrusion and in contact with your body or your magical constructs, you may increase the stored heat for up to a static 1000 mana per second to faster reach the breaking point."
                                },
                                Categories = new string[]
                                {
                                    "Ashen magic",
                                    "Fire Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Mastery of Ash",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Passive,
                                TierDescriptions = new string[]
                                {
                                    "You are one with Ash and Heat, your creations blotting out the very suns.",
                                    "Your understanding grows, allowing you to create greater change in ash, smoke, and volcanic glass. Imbue mana and complex commands into your creations. Ash and volcanic glass you imbue retains its form until the mana is used up. Imbued creations retain a static 10% of your ambient and enemy spell mana absorption.",
                                    "The elements themselves become an extension of your body, an extension of your will, for as long as they stay in physical contact with you. Ash and volcanic glass not connected benefits from passive abilities enhancing your body. You may imbue commands into ash and ember you have imbued with mana. Once per hour, you may create up to 25 copies of your form made of ash and volcanic glass, all instantly imbued with the same or separate complex commands. Each copy receives one random Class skill from any of your Classes. Should a spell require health or stamina to function, you may choose to imbue these resources as well. Copies lose access to this skill after initially imbued resources are used up."
                                },
                                Categories = new string[]
                                {
                                    "Ashen magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Draconic Ash Wings",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Passive,
                                TierDescriptions = new string[]
                                {
                                    "Your understanding of the Pyroclastic Flow allows you to create scaled wings from ash and volcanic glass. Bring terror from above and deliver your wrath, your wings carrying you no matter how dense, how heavy, or how injured you are.",
                                    "Your wings become more dense and tangible, able to help you defend and attack. When active, your wings become a part of your body.",
                                    "Shape and form your wings to your liking, now directly affected by your control. An added tail shall make you one with the skies above, not a mere human imitating flight but one who revels in it. You may charge your wings with mana and stamina to dramatically increase your flight velocity at the cost of heavily reduced control. Your resilience is increased greatly during a charged flight. If wings are active, this charge may be applied to created magical constructs for a vast increase in the velocity of projectiles. Resilience bonuses do not apply to such constructs."
                                },
                                Categories = new string[]
                                {
                                    "Body Enhancement",
                                    "Ashen Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Embodiment of Heat",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Passive,
                                TierDescriptions = new string[]
                                {
                                    "Increases your reflexes and speed by 75% [1387.5%]. Your ability to avoid damage to your vitals when dodging increases. A static 25% of this bonus is applied to Vitality.",
                                    "Your muscles grow more dense. For each Resistance skill your body becomes tougher. First tier Resistances equal a static 5% increase, second tier equal a static 10% increase, third tier equal a static 15% increase [625%]. Additionally affects your stamina.",
                                    "You can choose to allow magic damage to bypass your related resistance skills. If this effect is active, any absorption abilities related to such magic damage is increased. Effect is canceled automatically upon reaching 50% of your health. Each Resistance skill in the second tier or higher increases your heat generation and the potential density of your created ash and volcanic glass by a static 5% [225%]. Each Resistance skill in the third tier increases the speed of your created projectiles by 10% [260%]."
                                },
                                Categories = new string[]
                                {
                                    "Body Enhancement",
                                    "Ashen magic",
                                    "Fire Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Vision of Ash",
                                Level = 30,
                                Tier = 3,
                                Enhanced = false,
                                Type = SkillType.Passive,
                                TierDescriptions = new string[]
                                {
                                    "Increases your perception by 65% [780%] when fighting.",
                                    "Opportunity calls, you notice possible critical weak points on enemies with more ease. You can choose to see through ash and embers.",
                                    "Your eyes are vastly improved. Great distances and a lack of light won’t pose a problem to you anymore. You can control ash and embers that you can see."
                                },
                                Categories = new string[]
                                {
                                    "Body Enhancement",
                                    "Ashen magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Embered Form",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "You are one with the fighting style of Ash. Damage inflicted is 85% [850%] higher.",
                                    "Adds density to your bones, muscles and skin to increase strength, speed and damage. Base body weight is doubled. The abuse your body takes from your own strikes and their feedback is reduced.",
                                    "Reduces stamina consumption by a static 35%. Mana intrusion attacks formed or charged within your arms, hands, fingers, legs, feet, or your head can instead be converted into a purely physical damage increase to the executed attack. Be aware that this increase will be heavily demanding for your body."
                                },
                                Categories = new string[]
                                {
                                    "Body Enhancement"
                                }
                            },

                        }
                    },
                    new ClassDto()
                    {
                        Name = "The Sunforged Realmwalker",
                        Level = 1002,
                        Skills = new SkillDto[]
                        {
                            new SkillDto()
                            {
                                Name = "The Primordial Flame",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "Bring upon your enemies, the power of the suns themselves, burning away your health in the exchange for devastating light, heat, and energy. Your flames are limitless and form at your will. All of your spells and your body are infused with the Primordial Flame, dealing lingering damage to all within the fabric. You are immune to stunning, fear, and shout abilities. Your resilience is increased by 100% [2350%]",
                                    "The bright flame settles within your core. The Primordial Flame now affects enemy health, mana, and stamina regeneration. This effect is higher for areas directly touched by the Primordial Flame.",
                                    "You may infuse your magical constructs with the Primordial Flame. For each level in the third tier, the skill’s upkeep is reduced by a static 50 [1500] points of health per second and you may sacrifice an additional static 500 [15000] points of health per second to enhance the skill’s effects. The Primordial Flames return a static 10% of all health, stamina, and mana burned away so long as the spell is active."
                                },
                                Categories = new string[]
                                {
                                    "Aura",
                                    "Body Enhancement",
                                    "Space Magic",
                                    "Fire Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Framework Disruption",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "Shift space to your will, making frameworks or parts of frameworks appear somewhere else. Yes. That means you can teleport someone’s head off of their shoulders. Should you do it? Probably not.",
                                    "You may change the orientation of the objects you displace. Should you be unable to affect a framework with the initial spell usage, you may channel up to a static 1000 mana per second into it to cause the desired effect.",
                                    "You may choose two flat areas and connect them through space. At the time of marking an area, it has to be within the range of Framework Disruption. Ten sets of connections can be upheld at a time with exponential costs."
                                },
                                Categories = new string[]
                                {
                                    "Space Magic",
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Sunbound Creation",
                                Level = 1,
                                Tier = 4,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "Expending a large amount of mana and health, you can temporarily summon a new reality around your form, burning with the Primordial Flame and shielded by the fabric itself. Absorb a part of all magic that tries to affect your creation, depending on your understanding and resistance. All regeneration and healing is doubled in this state. Your movements are impaired as your very form is rejected by the true fabric that surrounds you.",
                                    "Resilience bonuses from skills are doubled when entering your Sunbound Creation. During the shift, you cannot be moved by anything but your will. Your weight increases a hundred fold while this spell is active. You may incorporate nearby allies into your creation, protecting them for an additional cost of mana and health.",
                                    "The Primordial Flame wills itself into existence, your control and its power increasing dramatically while Sunbound Creation is active. Increases the power of all space manipulation while the spell is active. Greatly reduces the activation time of Sunbound Creation. The longer this spell remains active, the more powerful its effects become.",
                                    "You have delved into the secrets of creation. Inside of your reality, you are not part of the Fabric, but you have learned to navigate through the mesh, and you have learned how to affect the true fabric with all that you can form. While Sunbound Creation is active, you gain the following benefits:\r\n- Your space manipulation of frameworks outside of your creation is vastly improved.\r\n- Your vision is no longer distorted, but clear, if you will it so.\r\n- The Primordial Flame burns at your will, vastly improved and burning with the very heat of the stars\r\n- You may use every spell within your Sunbound Creation. Limitations exist in regards to movement and teleportation of yourself.\r\n- You learn to move at a slow pace through the fabric, pushing your creation through known reality."
                                },
                                Categories = new string[]
                                {
                                    "Space Magic",
                                    "Fire Magic",
                                    "Healing Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Cosmic Shape",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Active,
                                TierDescriptions = new string[]
                                {
                                    "The Primordial Flame flows through your veins, increasing your resilience by 75% [1762.5%]. Increases your physical damage resistance by 15% [352.5%]. Increases your magic damage resistance by 15% [352.5%]. You won’t be fazed anymore by heavy damage or powerful sources of light and sound. Your natural regeneration can heal any injury.",
                                    "Your body has withstood incredible damage, endured the hardships of battle. The fires flowing through you have hardened your bones and muscles. Your health is increased by 35% [822.5%].",
                                    "Your ability to adapt to your enemy grows. Continued battle against the same foe or species of monster increases damage reduction against their attacks by 2.5% [58.75%] per minute to a maximum of a static 50%. This effect will remain even after a battle has ended. The Cosmic Shape is released should you reach low health [0.1% - set value]. Your mana [100% - set value] will be used to create both spatial shields and the Primordial Flame to prevent death. This effect can only occur once every three hours."
                                },
                                Categories = new string[]
                                {
                                    "Body enhancement",
                                    "Space Magic",
                                    "Fire Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Fabric Alteration",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Passive,
                                TierDescriptions = new string[]
                                {
                                    "You have learned to see and manipulate the ever present spatial fabric. You gain the ability to move anything within the fabric with a mere gesture. Greatly improves the power of your manipulation and reduces its cost.",
                                    "Further understanding of the spatial fabric allows you to manipulate its forces with greater ease and higher intensity. You learn to perceive even the tiniest ripples in space. In the case of active fissures, you find yourself able to peer into the other side. You gain the ability to anchor a spatial pocket to your very essence. Storage increases with the skill’s level. You gain the ability to glimpse through the fabric at any anchors you have set within.",
                                    "You have peered through the fabric of space itself and have learned to unravel its intricate structure. You gain the ability to perceive and differentiate magical frameworks and how to manipulate them within your space without failure. Charge simple manipulation attempts with up to 500 [10000] points of mana. You learn how to damage existing frameworks. Results may vary. Your experience with the fabric allows you to imbue your eyes with mana, to perceive and manipulate old tears in the mesh where cracks had formed or beings have traveled through the realms."
                                },
                                Categories = new string[]
                                {
                                    "Body Enhancement",
                                    "Space Magic"
                                }
                            },
                            new SkillDto()
                            {
                                Name = "Reality Warp",
                                Level = 30,
                                Tier = 3,
                                Enhanced = true,
                                Type = SkillType.Passive,
                                TierDescriptions = new string[]
                                {
                                    "Space wields easier for you, allowing you to unravel its mysteries. Teleportation abilities can be used again three times as fast and you can travel ten times as far. You notice fissures between realms at a distance of 50 [200] kilometers. This distance can vary depending on the size and extent of the fissure.",
                                    "Prevent enemy teleportation spells within a sphere around you at a radius of 50 meters. You cannot teleport while this skill is active.",
                                    "Your understanding of space magic grows. You learn to latch on to ongoing teleportation spells with your own teleportation abilities. Long range and channeled teleportation spells have their range doubled and their cooldown as well as cost reduced by half."
                                },
                                Categories = new string[]
                                {
                                    "Space magic"
                                }
                            },
                        }
                    }
                }
            };

            return Task.FromResult(result);
        }
    }
}