using System;
using System.Collections.Generic;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    public class FantasyMonster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // e.g., Humanoid, Dragon
        public string Size { get; set; } // e.g., Small, Medium, Huge
        public string Alignment { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public string HitDice { get; set; }
        public int ChallengeRating { get; set; }

        public List<TileType> MonsterTiles { get; set; } = new List<TileType> { TileType.Blank };

        public FantasyMonster(int id, string name, string type, string size, string alignment,
            int armorClass, int hitPoints, string hitDice, int challengeRating, List<TileType> monsterTiles)
        {
            ID = id;
            Name = name;
            Type = type;
            Size = size;
            Alignment = alignment;
            ArmorClass = armorClass;
            HitPoints = hitPoints;
            HitDice = hitDice;
            ChallengeRating = challengeRating;
            MonsterTiles = monsterTiles;
        }

        public override string ToString()
        {
            return $"{Name} (CR {ChallengeRating}) - {Size} {Type}, AC {ArmorClass}, HP {HitPoints}";
        }
    }
}