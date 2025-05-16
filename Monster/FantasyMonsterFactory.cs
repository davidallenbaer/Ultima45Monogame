using System;
using System.Collections.Generic;
using System.Linq;
using Ultima45Monogame;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    public static class FantasyMonsterFactory
    {
        public static List<FantasyMonster> GetRandomMonsters(TileType terrain, int MaxNumEnemies)
        {
            // Cap the maximum number of enemies to 16
            int maxEnemies = Math.Min(MaxNumEnemies, 16);

            // Filter monsters by terrain
            var eligibleMonsters = GetAllFantasyMonsters()
                .Where(m => m.TerrainTiles != null && m.TerrainTiles.Contains(terrain))
                .ToList();

            // Shuffle and take up to maxEnemies
            var random = new Random();
            var randomMonsters = new List<FantasyMonster>();

            if (eligibleMonsters.Count == 0)
                return randomMonsters;

            for (int i = 0; i < maxEnemies; i++)
            {
                // Pick a random monster from the eligible list (allowing duplicates)
                int index = random.Next(eligibleMonsters.Count);
                randomMonsters.Add(eligibleMonsters[index]);
            }

            return randomMonsters;
        }

        public static List<FantasyMonster> GetAllFantasyMonsters()
        {
            return new List<FantasyMonster>
            {
                new FantasyMonster(
                    id: 1,
                    name: "PirateShip",
                    type: "PirateShip",
                    size: "Large",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 50,
                    hitDice: "5d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.PirateShipEast, TileType.PirateShipNorth, TileType.PirateShipSouth, TileType.PirateShipWest },
                    terrainTiles: new List<TileType> { TileType.DeepWater, TileType.MediumWater }
                ),
                new FantasyMonster(
                    id: 2,
                    name: "Nixie",
                    type: "Nixie",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Nixie1, TileType.Nixie2 },
                    terrainTiles: new List<TileType> { TileType.DeepWater, TileType.MediumWater, TileType.ShallowWater }
                ),
                new FantasyMonster(
                    id: 3,
                    name: "GiantSquid",
                    type: "GiantSquid",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.GiantSquid1, TileType.GiantSquid2 },
                    terrainTiles: new List<TileType> { TileType.DeepWater, TileType.MediumWater }
                ),
                new FantasyMonster(
                    id: 4,
                    name: "SeaSerpent",
                    type: "SeaSerpent",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.SeaSerpent1, TileType.SeaSerpent2 },
                    terrainTiles: new List<TileType> { TileType.DeepWater, TileType.MediumWater }
                ),
                new FantasyMonster(
                    id: 5,
                    name: "Seahorse",
                    type: "Seahorse",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Seahorse1, TileType.Seahorse2 },
                    terrainTiles: new List<TileType> { TileType.DeepWater, TileType.MediumWater }
                ),
                new FantasyMonster(
                    id: 6,
                    name: "Whirlpool",
                    type: "Whirlpool",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Whirlpool1, TileType.Whirlpool2 },
                    terrainTiles: new List<TileType> { TileType.DeepWater, TileType.MediumWater }
                ),
                new FantasyMonster(
                    id: 7,
                    name: "Storm",
                    type: "Storm",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Storm1, TileType.Storm2 },
                    terrainTiles: new List<TileType> { TileType.DeepWater, TileType.MediumWater }
                ),
                new FantasyMonster(
                    id: 8,
                    name: "Rat",
                    type: "Rat",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Rat1, TileType.Rat2, TileType.Rat3, TileType.Rat4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Grasslands,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Scrubland,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 9,
                    name: "Bat",
                    type: "Bat",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Bat1, TileType.Bat2, TileType.Bat3, TileType.Bat4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Grasslands,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Scrubland,TileType.Swamp,TileType.DungeonEntrance }

                ),
                new FantasyMonster(
                    id: 10,
                    name: "GiantSpider",
                    type: "GiantSpider",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.GiantSpider1, TileType.GiantSpider2, TileType.GiantSpider3, TileType.GiantSpider4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 11,
                    name: "Ghost",
                    type: "Ghost",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Ghost1, TileType.Ghost2, TileType.Ghost3, TileType.Ghost4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 12,
                    name: "Slime",
                    type: "Slime",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Slime1, TileType.Slime2, TileType.Slime3, TileType.Slime4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 13,
                    name: "Troll",
                    type: "Troll",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Troll1, TileType.Troll2, TileType.Troll3, TileType.Troll4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance, TileType.Bridge, TileType.BridgeNorth, TileType.BridgeSouth }
                ),
                new FantasyMonster(
                    id: 14,
                    name: "Gremlin",
                    type: "Gremlin",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Gremlin1, TileType.Gremlin2, TileType.Gremlin3, TileType.Gremlin4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance, TileType.Bridge, TileType.BridgeNorth, TileType.BridgeSouth }
                ),
                new FantasyMonster(
                    id: 15,
                    name: "Mimic",
                    type: "Mimic",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Mimic1, TileType.Mimic2, TileType.Mimic3, TileType.Mimic4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 16,
                    name: "Reaper",
                    type: "Reaper",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Reaper1, TileType.Reaper2, TileType.Reaper3, TileType.Reaper4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 17,
                    name: "InsectSwarm",
                    type: "InsectSwarm",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.InsectSwarm1, TileType.InsectSwarm2, TileType.InsectSwarm3, TileType.InsectSwarm4 },
                    terrainTiles: new List<TileType> { TileType.Forest, TileType.Hills, TileType.Mountains, TileType.Swamp }
                ),
                new FantasyMonster(
                    id: 18,
                    name: "Gazer",
                    type: "Gazer",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Gazer1, TileType.Gazer2, TileType.Gazer3, TileType.Gazer4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 19,
                    name: "Phantom",
                    type: "Phantom",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Phantom1, TileType.Phantom2, TileType.Phantom3, TileType.Phantom4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 20,
                    name: "Orc",
                    type: "Orc",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Orc1, TileType.Orc2, TileType.Orc3, TileType.Orc4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 21,
                    name: "Skeleton",
                    type: "Skeleton",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Skeleton1, TileType.Skeleton2, TileType.Skeleton3, TileType.Skeleton4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 22,
                    name: "Rogue",
                    type: "Rogue",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Rogue1, TileType.Rogue2, TileType.Rogue3, TileType.Rogue4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }

                ),
                new FantasyMonster(
                    id: 23,
                    name: "Python",
                    type: "Python",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Python1, TileType.Python2, TileType.Python3, TileType.Python4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 24,
                    name: "Ettin",
                    type: "Ettin",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Ettin1, TileType.Ettin2, TileType.Ettin3, TileType.Ettin4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 25,
                    name: "Headless",
                    type: "Headless",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Headless1, TileType.Headless2, TileType.Headless3, TileType.Headless4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 26,
                    name: "Cyclops",
                    type: "Cyclops",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Cyclops1, TileType.Cyclops2, TileType.Cyclops3, TileType.Cyclops4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 27,
                    name: "Wisp",
                    type: "Wisp",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Wisp1, TileType.Wisp2, TileType.Wisp3, TileType.Wisp4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 28,
                    name: "EvilMage",
                    type: "EvilMage",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.EvilMage1, TileType.EvilMage2, TileType.EvilMage3, TileType.EvilMage4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 29,
                    name: "EvilMage",
                    type: "EvilMage",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.EvilMage1, TileType.EvilMage2, TileType.EvilMage3, TileType.EvilMage4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 30,
                    name: "Lich1",
                    type: "Lich1",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Lich1, TileType.Lich2, TileType.Lich3, TileType.Lich4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 31,
                    name: "EvilMage",
                    type: "EvilMage",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.EvilMage1, TileType.EvilMage2, TileType.EvilMage3, TileType.EvilMage4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 32,
                    name: "LavaLizard",
                    type: "LavaLizard",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.LavaLizard1, TileType.LavaLizard2, TileType.LavaLizard3, TileType.LavaLizard4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 33,
                    name: "Zorn",
                    type: "Zorn",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Zorn1, TileType.Zorn2, TileType.Zorn3, TileType.Zorn4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 34,
                    name: "Daemon",
                    type: "Daemon",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Daemon1, TileType.Daemon2, TileType.Daemon3, TileType.Daemon4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance, TileType.Shrine }
                ),
                new FantasyMonster(
                    id: 35,
                    name: "Hydra",
                    type: "Hydra",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Hydra1, TileType.Hydra2, TileType.Hydra3, TileType.Hydra4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 36,
                    name: "Dragon",
                    type: "Dragon",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Dragon1, TileType.Dragon2, TileType.Dragon3, TileType.Dragon4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance }
                ),
                new FantasyMonster(
                    id: 37,
                    name: "Balron",
                    type: "Balron",
                    size: "Medium",
                    alignment: "None",
                    armorClass: 15,
                    hitPoints: 10,
                    hitDice: "1d10",
                    challengeRating: 1,
                    monsterTiles: new List<TileType> { TileType.Balron1, TileType.Balron2, TileType.Balron3, TileType.Balron4 },
                    terrainTiles: new List<TileType> { TileType.Forest,TileType.Hills,TileType.Mountains,
                        TileType.Ruins,TileType.Swamp,TileType.DungeonEntrance, TileType.Shrine }
                ),
            };
        }
    }
}