using System.Collections.Generic;
using Ultima45Monogame;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    public static class FantasyMonsterFactory
    {
        public static List<FantasyMonster> GetAllFantasyMonsters()
        {
            return new List<FantasyMonster>
            {
                new FantasyMonster(
                    id: 1,
                    name: "Goblin",
                    type: "Humanoid (goblinoid)",
                    size: "Small",
                    alignment: "Neutral Evil",
                    armorClass: 15,
                    hitPoints: 7,
                    hitDice: "2d6",
                    challengeRating: 1,
                    monsterTile: TileType.Blank
                ),
                new FantasyMonster(
                    id: 2,
                    name: "Orc",
                    type: "Humanoid (orc)",
                    size: "Medium",
                    alignment: "Chaotic Evil",
                    armorClass: 13,
                    hitPoints: 15,
                    hitDice: "2d8+6",
                    challengeRating: 1,
                    monsterTile: TileType.Blank
                ),
                new FantasyMonster(
                    id: 3,
                    name: "Ogre",
                    type: "Giant",
                    size: "Large",
                    alignment: "Chaotic Evil",
                    armorClass: 11,
                    hitPoints: 59,
                    hitDice: "7d10+21",
                    challengeRating: 2,
                    monsterTile: TileType.Blank
                ),
                new FantasyMonster(
                    id: 4,
        name: "Adult Red Dragon",
                    type: "Dragon",
                    size: "Huge",
                    alignment: "Chaotic Evil",
                    armorClass: 19,
                    hitPoints: 256,
                    hitDice: "19d12+133",
                    challengeRating: 17,
                    monsterTile: TileType.Blank
                ),
                new FantasyMonster(
                    id: 5,
                    name: "Skeleton",
                    type: "Undead",
                    size: "Medium",
                    alignment: "Lawful Evil",
                    armorClass: 13,
                    hitPoints: 13,
                    hitDice: "2d8+4",
                    challengeRating: 0,
                    monsterTile: TileType.Blank
                )
            };
        }
    }
}