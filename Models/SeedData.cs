using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using dndgenesis.Data;
using System;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace dndgenesis.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new dndgenesisContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<dndgenesisContext>>());

            int IdCounter = 1;

            // insert books
            if (!context.Book.Any())
            {
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Book ON");

                    Book[] books = new Book[]
                    {
                            new Book { BookType = "Core", BookName = "Player's Handhook", PublishDate = "August 18th, 2014" },
                            new Book { BookType = "Core", BookName = "Monster Manual", PublishDate = "September 29th, 2014" },
                            new Book { BookType = "Core", BookName = "Dungeon Master's Guide", PublishDate = "December 8th, 2014" },
                            new Book { BookType = "Supplements", BookName = "Volo's Guide to Monsters", PublishDate = "November 14th, 2016" },
                            new Book { BookType = "Supplements", BookName = "Xanathar's Guide to Everything", PublishDate = "November 20th, 2014" },
                            new Book { BookType = "Supplements", BookName = "Mordenkainen's Tome of Foes", PublishDate = "May 28th, 2018" },
                            new Book { BookType = "Supplements", BookName = "Acquisitions Incorporated", PublishDate = "June 17th, 2019" },
                            new Book { BookType = "Supplements", BookName = "Dungeons & Dragons vs. Rickk and Morty: Basic Rules", PublishDate = "November 18th, 2019" },
                            new Book { BookType = "Supplements", BookName = "Tasha's Cauldron of Everything", PublishDate = "November 16th, 2020" },
                            new Book { BookType = "Supplements", BookName = "Fizban's Treasury of Dragons", PublishDate = "October 25th, 2021" },
                            new Book { BookType = "Supplements", BookName = "Mordenkainen Presents: Monsters of the Multiverse", PublishDate = "January 24th, 2022" },
                            new Book { BookType = "Settings", BookName = "Sword Coast Adventurer's Guide", PublishDate = "November 2nd, 2015" },
                            new Book { BookType = "Settings", BookName = "Guildmasters' Guide to Ravnica", PublishDate = "November 19th, 2018" },
                            new Book { BookType = "Settings", BookName = "Eberron: Rising from the Last War", PublishDate = "November 18th, 2019" },
                            new Book { BookType = "Settings", BookName = "Explorer's Guide to Wildemount", PublishDate = "March 16th, 2020" },
                            new Book { BookType = "Settings", BookName = "Mythic Odysseys of Theros", PublishDate = "June 1st, 2020" },
                            new Book { BookType = "Settings", BookName = "Van Richten's Guide to Ravenloft", PublishDate = "May 17th, 2021" },
                            new Book { BookType = "Settings", BookName = "Strixhaven: A Curriculum of Chaos", PublishDate = "December 6th, 2021" },
                            new Book { BookType = "Extras", BookName = "PlaneShift: Zendikar", PublishDate = "April 26th, 2016" },
                            new Book { BookType = "Extras", BookName = "PlaneShift: Innistrad", PublishDate = "July 11th, 2016" },
                            new Book { BookType = "Extras", BookName = "PlaneShift:Kaladesh", PublishDate = "February 15th, 2017" },
                            new Book { BookType = "Extras", BookName = "PlaneShift: Amonkhet", PublishDate = "July 5th, 2017" },
                            new Book { BookType = "Extras", BookName = "One Grung Above", PublishDate = "October 10th, 2017" },
                            new Book { BookType = "Extras", BookName = "PlaneShift: Ixalan", PublishDate = "January 8th, 2018" },
                            new Book { BookType = "Extras", BookName = "PlaneShift: Dominaria", PublishDate = "July 30th, 2018" },
                            new Book { BookType = "Extras", BookName = "Domains of Delight", PublishDate = "September 20th, 2021" },
                            new Book { BookType = "Extras", BookName = "Minsc and Boo's Journal of Villainy", PublishDate = "October 4th, 2021" },
                            new Book { BookType = "Screens", BookName = "Dungeon Master's Screen", PublishDate = "January 19th, 2015" },
                            new Book { BookType = "Screens", BookName = "Dungeon Master's Screen: Dungeon Kit", PublishDate = "September 20th, 2020" },
                            new Book { BookType = "Screens", BookName = "Dungeon Master's Screen Wilderness Kit", PublishDate = "November 16th, 2020" },
                            new Book { BookType = "Miscellaneous", BookName = "Adventure's League", PublishDate = "August 25, 2016" },
                            new Book { BookType = "Miscellaneous", BookName = "Sage Advice Compendium", PublishDate = "January 30th, 2019" }
                    };
                    foreach (Book x in books)
                    {
                        x.BookId = IdCounter++;
                        context.Book.Add(x);
                    }
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Book OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                    IdCounter = 1;
                }
            }

            // insert dndclasses
            if (!context.DndClass.Any())
            {
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DndClass ON");

                    DndClass[] dndClasses = new DndClass[]
                    {
                            new DndClass { DndClassName = "Artificer", BookId = 9, HitDice = "1d8" },
                            new DndClass { DndClassName = "Barbarian", BookId = 1, HitDice = "1d12"  },
                            new DndClass { DndClassName = "Bard", BookId = 1, HitDice = "1d8"  },
                            new DndClass { DndClassName = "Cleric", BookId = 1, HitDice = "1d8"  },
                            new DndClass { DndClassName = "Druid", BookId = 1, HitDice = "1d8"  },
                            new DndClass { DndClassName = "Fighter", BookId = 1, HitDice = "1d10"  },
                            new DndClass { DndClassName = "Monk", BookId = 1, HitDice = "1d8"  },
                            new DndClass { DndClassName = "Paladin", BookId = 1, HitDice = "1d10"  },
                            new DndClass { DndClassName = "Ranger", BookId = 1, HitDice = "1d10"  },
                            new DndClass { DndClassName = "Rogue", BookId = 1, HitDice = "1d8"  },
                            new DndClass { DndClassName = "Sorcerer", BookId = 1, HitDice = "1d6"  },
                            new DndClass { DndClassName = "Warlock", BookId = 1, HitDice = "1d8"  },
                            new DndClass { DndClassName = "Wizard", BookId = 1, HitDice = "1d6"  }
                    };
                    foreach (DndClass x in dndClasses)
                    {
                        x.DndClassId = IdCounter++;
                        context.DndClass.Add(x);
                    }
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DndClass OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                    IdCounter = 1;
                }
            }

            // insert dndsubclasses
            if (!context.DndSubclass.Any())
            {
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DndSubClass ON");

                    DndSubclass[] dndSubclasses = new DndSubclass[]
                    {
                        // alchemist subclasses
                        new DndSubclass { DndSubclassName = "Alchemist", DndClassId = 1 },
                        new DndSubclass { DndSubclassName = "Armorer", DndClassId = 1 },
                        new DndSubclass { DndSubclassName = "Artillerist", DndClassId = 1 },
                        new DndSubclass { DndSubclassName = "Battle Smith", DndClassId = 1 },
                        // barbarian subclasses
                        new DndSubclass { DndSubclassName = "Path of the Ancestral Guardian", DndClassId = 2 },
                        new DndSubclass { DndSubclassName = "Path of the Battlerager", DndClassId = 2 },
                        new DndSubclass { DndSubclassName = "Path of the Beast", DndClassId = 2 },
                        new DndSubclass { DndSubclassName = "Path of the Berserker", DndClassId = 2 },
                        new DndSubclass { DndSubclassName = "Path of the Storm Herald", DndClassId = 2 },
                        new DndSubclass { DndSubclassName = "Path of the Totem Warrior", DndClassId = 2 },
                        new DndSubclass { DndSubclassName = "Path of Wild Magic", DndClassId = 2 },
                        new DndSubclass { DndSubclassName = "Path of the Zealot", DndClassId = 2 },
                        // barbarian subclasses
                        new DndSubclass { DndSubclassName = "College of Creation", DndClassId = 3 },
                        new DndSubclass { DndSubclassName = "College of Eloquence", DndClassId = 3 },
                        new DndSubclass { DndSubclassName = "College of Glamour", DndClassId = 3 },
                        new DndSubclass { DndSubclassName = "College of Lore", DndClassId = 3 },
                        new DndSubclass { DndSubclassName = "College of Spirits", DndClassId = 3 },
                        new DndSubclass { DndSubclassName = "College of Swords", DndClassId = 3 },
                        new DndSubclass { DndSubclassName = "College of Valor", DndClassId = 3 },
                        new DndSubclass { DndSubclassName = "College of Whispers", DndClassId = 3 },
                        // cleric subclasses
                        new DndSubclass { DndSubclassName = "Arcana Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "Death Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "Forge Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "Grave Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "Knowledge Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "Life Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "Light Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "Nature Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "Order Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "Peace Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "Tempest Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "Trickery Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "Twilight Domain", DndClassId = 4 },
                        new DndSubclass { DndSubclassName = "War Domain", DndClassId = 4 },
                        // druid subclasses
                        new DndSubclass { DndSubclassName = "Circle of Dreams", DndClassId = 5 },
                        new DndSubclass { DndSubclassName = "Circle of the Land", DndClassId = 5 },
                        new DndSubclass { DndSubclassName = "Circle of the Moon", DndClassId = 5 },
                        new DndSubclass { DndSubclassName = "Circle of the Shepherd", DndClassId = 5 },
                        new DndSubclass { DndSubclassName = "Circle of Spores", DndClassId = 5 },
                        new DndSubclass { DndSubclassName = "Circle of Stars", DndClassId = 5 },
                        new DndSubclass { DndSubclassName = "Circle of Wildfire", DndClassId = 5 },
                        // fighter subclasses
                        new DndSubclass { DndSubclassName = "Arcane Archer", DndClassId = 6 },
                        new DndSubclass { DndSubclassName = "Banneret", DndClassId = 6 },
                        new DndSubclass { DndSubclassName = "Battle Master", DndClassId = 6 },
                        new DndSubclass { DndSubclassName = "Cavelier", DndClassId = 6 },
                        new DndSubclass { DndSubclassName = "Champion", DndClassId = 6 },
                        new DndSubclass { DndSubclassName = "Echo Knight", DndClassId = 6 },
                        new DndSubclass { DndSubclassName = "Elddritch Knight", DndClassId = 6 },
                        new DndSubclass { DndSubclassName = "Psi Warrior", DndClassId = 6 },
                        new DndSubclass { DndSubclassName = "Rune Knight", DndClassId = 6 },
                        new DndSubclass { DndSubclassName = "Samuri", DndClassId = 6 },
                        // monk subclasses
                        new DndSubclass { DndSubclassName = "Way of Mercy", DndClassId = 7 },
                        new DndSubclass { DndSubclassName = "Way of Ascendant Dragon", DndClassId = 7 },
                        new DndSubclass { DndSubclassName = "Way of the Astral Self", DndClassId = 7 },
                        new DndSubclass { DndSubclassName = "Way of the Drunken Master", DndClassId = 7 },
                        new DndSubclass { DndSubclassName = "Way of the Four Elements", DndClassId = 7 },
                        new DndSubclass { DndSubclassName = "Way of the Kensei", DndClassId = 7 },
                        new DndSubclass { DndSubclassName = "Way of the Long Death", DndClassId = 7 },
                        new DndSubclass { DndSubclassName = "Way of the Open Hand", DndClassId = 7 },
                        new DndSubclass { DndSubclassName = "Way of Shadow", DndClassId = 7 },
                        new DndSubclass { DndSubclassName = "Way of the Sun Soul", DndClassId = 7 },
                        // paladin subclasses
                        new DndSubclass { DndSubclassName = "Oath of the Ancients", DndClassId = 8 },
                        new DndSubclass { DndSubclassName = "Oath of Conquest", DndClassId = 8 },
                        new DndSubclass { DndSubclassName = "Oath of the Crown", DndClassId = 8 },
                        new DndSubclass { DndSubclassName = "Oath of Devotion", DndClassId = 8 },
                        new DndSubclass { DndSubclassName = "Oath of Glory", DndClassId = 8 },
                        new DndSubclass { DndSubclassName = "Oath of Redemption", DndClassId = 8 },
                        new DndSubclass { DndSubclassName = "Oath of Vengeance", DndClassId = 8 },
                        new DndSubclass { DndSubclassName = "Oath of the Watchers", DndClassId = 8 },
                        new DndSubclass { DndSubclassName = "Oathbreaker", DndClassId = 8 },
                        // ranger subclasses
                        new DndSubclass { DndSubclassName = "Beast Master Conclave", DndClassId = 9 },
                        new DndSubclass { DndSubclassName = "Drakenwarden", DndClassId = 9 },
                        new DndSubclass { DndSubclassName = "Fey Wanderer", DndClassId = 9 },
                        new DndSubclass { DndSubclassName = "Gloom Stalker Conclave", DndClassId = 9 },
                        new DndSubclass { DndSubclassName = "Horizon Walker Conclave", DndClassId = 9 },
                        new DndSubclass { DndSubclassName = "Hunter Conclave", DndClassId = 9 },
                        new DndSubclass { DndSubclassName = "Monaster Slayer Conclave", DndClassId = 9 },
                        new DndSubclass { DndSubclassName = "Swarmkeeper", DndClassId = 9 },
                        // rogue subclasses
                        new DndSubclass { DndSubclassName = "Arcane Trickster", DndClassId = 10 },
                        new DndSubclass { DndSubclassName = "Assassin", DndClassId = 10 },
                        new DndSubclass { DndSubclassName = "Inquisitive", DndClassId = 10 },
                        new DndSubclass { DndSubclassName = "Mastermind", DndClassId = 10 },
                        new DndSubclass { DndSubclassName = "Phantom", DndClassId = 10 },
                        new DndSubclass { DndSubclassName = "Scout", DndClassId = 10 },
                        new DndSubclass { DndSubclassName = "Soulknife", DndClassId = 10 },
                        new DndSubclass { DndSubclassName = "Swashbuckler", DndClassId = 10 },
                        new DndSubclass { DndSubclassName = "Thief", DndClassId = 10 },
                        // sorcerer subclasses
                        new DndSubclass { DndSubclassName = "Aberrant Mind", DndClassId = 11 },
                        new DndSubclass { DndSubclassName = "Clockwork Soul", DndClassId = 11 },
                        new DndSubclass { DndSubclassName = "Draconic Bloodline", DndClassId = 11 },
                        new DndSubclass { DndSubclassName = "Divine Soul", DndClassId = 11 },
                        new DndSubclass { DndSubclassName = "Shadow Magic", DndClassId = 11 },
                        new DndSubclass { DndSubclassName = "Storm Sorcery", DndClassId = 11 },
                        new DndSubclass { DndSubclassName = "Wild Magic", DndClassId = 11 },
                        // warlock subclasses
                        new DndSubclass { DndSubclassName = "Archfey", DndClassId = 12 },
                        new DndSubclass { DndSubclassName = "Celestial", DndClassId = 12 },
                        new DndSubclass { DndSubclassName = "Fathomless", DndClassId = 12 },
                        new DndSubclass { DndSubclassName = "Fiend", DndClassId = 12 },
                        new DndSubclass { DndSubclassName = "The Genie", DndClassId = 12 },
                        new DndSubclass { DndSubclassName = "Great Old One", DndClassId = 12 },
                        new DndSubclass { DndSubclassName = "Hexblade", DndClassId = 12 },
                        new DndSubclass { DndSubclassName = "Undead", DndClassId = 12 },
                        new DndSubclass { DndSubclassName = "Undying", DndClassId = 12 },
                        // wizard subclasses
                        new DndSubclass { DndSubclassName = "School of Abjuration", DndClassId = 13 },
                        new DndSubclass { DndSubclassName = "School of Bladesinging", DndClassId = 13 },
                        new DndSubclass { DndSubclassName = "School of Chronurgy", DndClassId = 13 },
                        new DndSubclass { DndSubclassName = "School of Conjuration", DndClassId = 13 },
                        new DndSubclass { DndSubclassName = "School of Divination", DndClassId = 13 },
                        new DndSubclass { DndSubclassName = "School of Enchantment", DndClassId = 13 },
                        new DndSubclass { DndSubclassName = "School of Evocation", DndClassId = 13 },
                        new DndSubclass { DndSubclassName = "School of Graviturgy", DndClassId = 13 },
                        new DndSubclass { DndSubclassName = "School of Illusion", DndClassId = 13 },
                        new DndSubclass { DndSubclassName = "School of Necromancy", DndClassId = 13 },
                        new DndSubclass { DndSubclassName = "Order of Scribes", DndClassId = 13 },
                        new DndSubclass { DndSubclassName = "School of Transmutation", DndClassId = 13 },
                        new DndSubclass { DndSubclassName = "School of War Magic", DndClassId = 13 }
                    };
                    foreach (DndSubclass x in dndSubclasses)
                    {
                        x.DndSubclassId = IdCounter++;
                        context.DndSubclass.Add(x);
                    }
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DndSubClass OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                    IdCounter = 1;
                }
            }

            // insert schools
            if (!context.SchoolMagic.Any())
            {
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.SchoolMagic ON");

                    SchoolMagic[] schools = new SchoolMagic[]
                    {
                        new SchoolMagic { SchoolMagicName = "Abjuration" },
                        new SchoolMagic { SchoolMagicName = "Conjuration" },
                        new SchoolMagic { SchoolMagicName = "Divination" },
                        new SchoolMagic { SchoolMagicName = "Enchantment" },
                        new SchoolMagic { SchoolMagicName = "Evocation" },
                        new SchoolMagic { SchoolMagicName = "Illusion" },
                        new SchoolMagic { SchoolMagicName = "Necromancy" },
                        new SchoolMagic { SchoolMagicName = "Transmutation" },
                    };
                    foreach (SchoolMagic x in schools)
                    {
                        x.SchoolMagicId = IdCounter++;
                        context.SchoolMagic.Add(x);
                    }
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.SchoolMagic OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                    IdCounter = 1;
                };
            }

            // insert spells (144/514)
            //  Abj. - 53: done
            //  Conj. - 91: done
            //  Divin. - 35
            //  Ench. - 50
            //  Evoc. - 109
            //  Illu. - 33
            //  Necro. - 42
            //  Trans. - 101
            if (!context.Spell.Any())
            {
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Spell ON");

                    Spell[] spells = new Spell[]
                    {
                        // too much data :/ maybe add details at the end
                        //new Spell { SpellName = "Absorb ELements", Level = 1, Ritual = false, CastingTime = "Reaction", Concentration = false, Range = "Self", Components = "S", Duration = "1 round", SchoolMagicId = 1, BookId = 5 },
                        //new Spell { SpellName = "Aid", Level = 2, Ritual = false, CastingTime = "Action", Concentration = false, Range = "30 feet", Components = "V, S, M (a tiny strip of white cloth)", Duration = "8 hours", SchoolMagicId = 1, BookId = 1 },
                        //new Spell { SpellName = "Alarm", Level = 1, Ritual = true, CastingTime = "1 Min", Concentration = false, Range = "30 feet", Components = "V, S, M (a tiny bell and a piece of fine silver wire)", Duration = "8 hours", SchoolMagicId = 1, BookId = 1 },
                        //new Spell { SpellName = "Antilife Shell", Level = 5, Ritual = false, CastingTime = "Action", Concentration = true, Range = "Self (10-foot radius)", Components = "V, S", Duration = "Concentration, up to 1 hour", SchoolMagicId = 1, BookId = 1 },
                        //new Spell { SpellName = "Antimagic Field", Level = 8, Ritual = false, CastingTime = "Action", Concentration = true, Range = "Self (10-foot radius)", Components = "V, S, M (a pinch of powdered iron or iron filings)", Duration = "Concentration, up to 1 hour", SchoolMagicId = 1, BookId = 1 },
                        //new Spell { SpellName = "Arcane Lock", Level = 2, Ritual = false, CastingTime = "Action", Concentration = false, Range = "Touch", Components = "V, S, M (gold dust worth at least 25 gp, which the spell consumed)", Duration = "Until dispelled", SchoolMagicId = 1, BookId = 1 },
                        //new Spell { SpellName = "Armor of Agathys", Level = 1, Ritual = false, CastingTime = "Action", Concentration = false, Range = "Self", Components = "V, S, M (a cup of water)", Duration = "1 hour", SchoolMagicId = 1, BookId = 1 },
                        //new Spell { SpellName = "Aura of Life", Level = 4, Ritual = false, CastingTime = "Action", Concentration = true, Range = "Self (30-foot radius)", Components = "V", Duration = "Concentration, up to 10 minutes", SchoolMagicId = 1, BookId = 1 },
                        //new Spell { SpellName = "Aura of Purity", Level = 4, Ritual = false, CastingTime = "Action", Concentration = true, Range = "Self (30-foot radius)", Components = "V", Duration = "Concentration, up to 10 minutes", SchoolMagicId = 1, BookId = 1 },
                        //new Spell { SpellName = "Banishing Smite", Level = 5, Ritual = false, CastingTime = "Bonus", Concentration = true, Range = "Self", Components = "V", Duration = "Concentration, up to 1 minute", SchoolMagicId = 1, BookId = 1 },
                        //new Spell { SpellName = "Banishment", Level = 4, Ritual = false, CastingTime = "Action", Concentration = true, Range = "60", Components = "V, S, M (an item distasteful to the target)", Duration = "Concentration, up to 1 minute", SchoolMagicId = 1, BookId = 1 },
                        //new Spell { SpellName = "Beacon of Hope", Level = 3, Ritual = false, CastingTime = "Action", Concentration = true, Range = "30", Components = "V, S", Duration = "Concentration, up to 1 minute", SchoolMagicId = 1, BookId = 1 },
                        //new Spell { SpellName = "Blade Ward", Level = 0, SchoolMagicId = 1, BookId = 1 },

                        // Abj. - 53
                        new Spell { SpellName = "Absorb Elements", Level = 1, SchoolMagicId = 1, BookId = 5 },
                        new Spell { SpellName = "Aid", Level = 2, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Alarm", Level = 1, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Antilife Shell", Level = 5, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Antimagic Field", Level = 8, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Arcane Lock", Level = 2, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Armor of Agathys", Level = 1, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Aura of Life", Level = 4, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Aura of Purity", Level = 4, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Banishing Smite", Level = 5, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Banishment", Level = 4, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Beacon of Hope", Level = 3, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Blade Ward", Level = 0, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Ceremony", Level = 1, SchoolMagicId = 1, BookId = 5 },
                        new Spell { SpellName = "Circle of Power", Level = 5, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Counter Spell", Level = 3, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Death Ward", Level = 4, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Dispel Evil and Good", Level = 5, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Dispel Magic", Level = 3, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Druid Grove", Level = 6, SchoolMagicId = 1, BookId = 5 },
                        new Spell { SpellName = "Fizban's Platinum Shield", Level = 6, SchoolMagicId = 1, BookId = 10 },
                        new Spell { SpellName = "Forbiddance", Level = 6, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Freedom of Movement", Level = 4, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Globe of Invulnerability", Level = 6, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Glyph of Warding", Level = 3, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Greater Restoration", Level = 5, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Guards and Wards", Level = 6, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Holy Aura", Level = 8, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Imprisonment", Level = 9, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Intellect Fortress", Level = 3, SchoolMagicId = 1, BookId = 9 },
                        new Spell { SpellName = "Invulnerability", Level = 9, SchoolMagicId = 1, BookId = 5 },
                        new Spell { SpellName = "Lesser Restoration", Level = 2, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Mage Armor", Level = 1, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Magic Circle", Level = 3, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Mind Blank", Level = 8, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Mordenkainen's Private Sanctum", Level = 4, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Nondectection", Level = 3, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Pass without Trace", Level = 2, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Planar Binding", Level = 5, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Primordial Ward", Level = 6, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Prismatic Wall", Level = 9, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Protection from Energy", Level = 3, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Protection from Evil and Good", Level = 1, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Protection from Poison", Level = 2, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Remove Curse", Level = 3, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Resistance", Level = 0, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Sanctuary", Level = 1, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Shield", Level = 1, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Shield of Faith", Level = 1, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Snare", Level = 1, SchoolMagicId = 1, BookId = 5 },
                        new Spell { SpellName = "Stoneskin", Level = 4, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Symbol", Level = 7, SchoolMagicId = 1, BookId = 1 },
                        new Spell { SpellName = "Warding Bond", Level = 2, SchoolMagicId = 1, BookId = 1 },
                        // Conj. - 91
                        new Spell { SpellName = "Acid Splash", Level = 0, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Arcane Gate", Level = 6, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Arms of Hadar", Level = 1, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Blade of Disaster", Level = 9, SchoolMagicId = 2, BookId = 9 },
                        new Spell { SpellName = "Call Lightning", Level = 3, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Cloud of Daggers", Level = 2, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Cloudkill", Level = 5, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Conjure Animals", Level = 3, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Conjure Barrage", Level = 3, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Conjure Celestial", Level = 7, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Conjure Elemental", Level = 5, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Conjure Fey", Level = 6, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Conjure Minor Elementals", Level = 4, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Conjure Volley", Level = 5, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Conjuer Woodland Beings", Level = 4, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Create Bonfire", Level = 0, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Create Food and Water", Level = 3, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Demiplane", Level = 8, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Dimension Door", Level = 4, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Drawmij's Instant Summons", Level = 6, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Dream of the Blue Veil", Level = 7, SchoolMagicId = 2, BookId = 9 },
                        new Spell { SpellName = "Dust Devil", Level = 2, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Ensnaring Strike", Level = 1, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Entangle", Level = 1, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Evard's Black Tentacles", Level = 4, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Far Step", Level = 5, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Find Familiar", Level = 1, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Find Greater Steed", Level = 4, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Find Steed", Level = 2, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Flaming Sphere", Level = 2, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Fog Cloud", Level = 1, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Gate", Level = 9, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Grasping Vine", Level = 4, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Grease", Level = 1, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Guardian of Faith", Level = 4, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Hail of Thorns", Level = 1, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Healing Spirit", Level = 2, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Heroes' Feast", Level = 6, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Hunger of Hadar", Level = 3, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Ice Knife", Level = 1, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Incendiary Cloud", Level = 8, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Infernal Calling", Level = 5, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Infestation", Level = 0, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Insect Plague", Level = 5, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Leomund's Secret Chest", Level = 4, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Mage Hand", Level = 0, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Maze", Level = 8, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Mighty Fortress", Level = 8, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Misty Step", Level = 2, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Mordenkainen's Faithful Hound", Level = 4, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Mordenkainen's Magnificent Mansion", Level = 7, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Planar Ally", Level = 6, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Plane Shift", Level = 7, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Poison Spray", Level = 0, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Produce Flame", Level = 0, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Reality Break", Level = 8, SchoolMagicId = 2, BookId = 15 },
                        new Spell { SpellName = "Scatter", Level = 6, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Sleet Storm", Level = 3, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Spirit Guardians", Level = 3, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Steel Wind Strike", Level = 5, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Stinking Cloud", Level = 3, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Storm of Vengeance", Level = 9, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Summon Aberration", Level = 4, SchoolMagicId = 2, BookId = 9 },
                        new Spell { SpellName = "Summon Beast", Level = 2, SchoolMagicId = 2, BookId = 9 },
                        new Spell { SpellName = "Summon Celestial", Level = 5, SchoolMagicId = 2, BookId = 9 },
                        new Spell { SpellName = "Summon Construct", Level = 4, SchoolMagicId = 2, BookId = 9 },
                        new Spell { SpellName = "Summon Draconic Spirit", Level = 5, SchoolMagicId = 2, BookId = 10 },
                        new Spell { SpellName = "Summon Elemental", Level = 4, SchoolMagicId = 2, BookId = 9 },
                        new Spell { SpellName = "Summon Fey", Level = 3, SchoolMagicId = 2, BookId = 9 },
                        new Spell { SpellName = "Summon Fiend", Level = 6, SchoolMagicId = 2, BookId = 9 },
                        new Spell { SpellName = "Summon Greater Demon", Level = 4, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Summon Lesser Demons", Level = 3, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Summon Shadowspawn", Level = 3, SchoolMagicId = 2, BookId = 9 },
                        new Spell { SpellName = "Sword Burst", Level = 0, SchoolMagicId = 2, BookId = 9 },
                        new Spell { SpellName = "Teleport", Level = 7, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Teleportation Circle", Level = 5, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Temple of Gods", Level = 7, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Tenser's Floating Disk", Level = 1, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Thunder Step", Level = 3, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Tital Wave", Level = 3, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Transport via Plants", Level = 6, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Tree Stride", Level = 5, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Tsunami", Level = 8, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Unseen Servant", Level = 1, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Vortex Warp", Level = 2, SchoolMagicId = 2, BookId = 18 },
                        new Spell { SpellName = "Wall of Thorns", Level = 6, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Watery Sphere", Level = 4, SchoolMagicId = 2, BookId = 5 },
                        new Spell { SpellName = "Web", Level = 2, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Wish", Level = 8, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Word of Recall", Level = 6, SchoolMagicId = 2, BookId = 1 },
                        new Spell { SpellName = "Wristpocket", Level = 2, SchoolMagicId = 2, BookId = 10 },
                        //  Divin. - 35
                        new Spell { SpellName = "", Level = 1, SchoolMagicId = 3, BookId = 1 },
                        //  Ench. - 50
                        new Spell { SpellName = "", Level = 1, SchoolMagicId = 4, BookId = 1 },
                        //  Evoc. - 109
                        new Spell { SpellName = "", Level = 1, SchoolMagicId = 4, BookId = 1 },
                        //  Illu. - 33
                        new Spell { SpellName = "", Level = 1, SchoolMagicId = 5, BookId = 1 },
                        //  Necro. - 42
                        new Spell { SpellName = "", Level = 1, SchoolMagicId = 6, BookId = 1 },
                        //  Trans. - 101
                        new Spell { SpellName = "", Level = 1, SchoolMagicId = 7, BookId = 1 },
                    };
                    foreach (Spell x in spells)
                    {
                        x.SpellId = IdCounter++;
                        context.Spell.Add(x);
                    }
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Spell OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                    IdCounter = 1;
                }
            }

            // insert races
            if (!context.Race.Any())
            {
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Race ON");

                    Race[] races = new Race[]
                    {
                        new Race { RaceName = "Aarakocra" },
                        new Race { RaceName = "Aasimar" },
                        new Race { RaceName = "Bugbear" },
                        new Race { RaceName = "Centaur" },
                        new Race { RaceName = "Changeling" },
                        new Race { RaceName = "Custom Lineage" },
                        new Race { RaceName = "Dhampir" },
                        new Race { RaceName = "Dragonborn" },
                        new Race { RaceName = "Dwarf" },
                        new Race { RaceName = "Elf" },
                        new Race { RaceName = "Fairy" },
                        new Race { RaceName = "Firbolg" },
                        new Race { RaceName = "Gensai" },
                        new Race { RaceName = "Genasi" },
                        new Race { RaceName = "Gith" },
                        new Race { RaceName = "Gnome" },
                        new Race { RaceName = "Goblin" },
                        new Race { RaceName = "Goliath" },
                        new Race { RaceName = "Grung" },
                        new Race { RaceName = "Half-Elf" },
                        new Race { RaceName = "Half-Orc" },
                        new Race { RaceName = "Halfling" },
                        new Race { RaceName = "Harengon" },
                        new Race { RaceName = "Hexblood" },
                        new Race { RaceName = "Hobgoblin" },
                        new Race { RaceName = "Human" },
                        new Race { RaceName = "Kalashtar" },
                        new Race { RaceName = "Kenku" },
                        new Race { RaceName = "Kobold" },
                        new Race { RaceName = "Leonin" },
                        new Race { RaceName = "Lizardfolk" },
                        new Race { RaceName = "Locathah" },
                        new Race { RaceName = "Loxodon" },
                        new Race { RaceName = "Minotaur" },
                        new Race { RaceName = "Orc" },
                        new Race { RaceName = "Owlin" },
                        new Race { RaceName = "Reborn" },
                        new Race { RaceName = "Satyr" },
                        new Race { RaceName = "Shifter" },
                        new Race { RaceName = "Simic Hybrid" },
                        new Race { RaceName = "Tabaxi" },
                        new Race { RaceName = "Tiefling" },
                        new Race { RaceName = "Tortle" },
                        new Race { RaceName = "Triton" },
                        new Race { RaceName = "Vedalken" },
                        new Race { RaceName = "Verdan" },
                        new Race { RaceName = "Warforged" },
                        new Race { RaceName = "Yuan-Ti" }
                    };
                    foreach (Race x in races)
                    {
                        x.RaceId = IdCounter++;
                        context.Race.Add(x);
                    }
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Race OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                    IdCounter = 1;
                };
            }

            // insert subraces
            if (!context.Subrace.Any())
            {
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Subrace ON");

                    Subrace[] subraces = new Subrace[]
                    {
                        new Subrace { SubraceName = "", RaceId = 1, AbilityScores = "", BookId = 1 },
                        new Subrace { SubraceName = "", RaceId = 1, AbilityScores = "", BookId = 1 },
                        new Subrace { SubraceName = "", RaceId = 1, AbilityScores = "", BookId = 1 },
                        new Subrace { SubraceName = "", RaceId = 1, AbilityScores = "", BookId = 1 }
                    };
                    foreach (Subrace x in subraces)
                    {
                        x.SubraceId = IdCounter++;
                        context.Subrace.Add(x);
                    }
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Subrace OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                    IdCounter = 1;
                };
            }
        }
    }
}