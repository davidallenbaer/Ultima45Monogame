using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Ultima45Monogame;
using static Ultima45Monogame.Game1;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame.Combat
{
    public class MonsterPositionManager
    {
        public List<CombatMonsterStartingLocation> MonsterPositions { get; set; } = new List<CombatMonsterStartingLocation>();

        public void AddMonsterPosition(Maps map, int monsterposition, int y, int x)
        {
            MonsterPositions.Add(new CombatMonsterStartingLocation(map, monsterposition, y, x));
        }

        public void RemoveMonsterPosition(int monsterposition)
        {
            MonsterPositions.RemoveAll(e => e.MonsterPosition == monsterposition);
        }

        public CombatMonsterStartingLocation? GetMonsterPosition(int monsterposition)
        {
            return MonsterPositions.FirstOrDefault(e => e.MonsterPosition == monsterposition);
        }

        public void LoadFromFile(Maps map, string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);

                int positionIndex = 0; // Tracks the monster position index
                foreach (var line in lines)
                {
                    var parts = line.Split(',');

                    if (parts.Length == 2 &&
                        int.TryParse(parts[0], out int x) &&
                        int.TryParse(parts[1], out int y))
                    {
                        AddMonsterPosition(map, positionIndex++, y, x);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading monster positions: {ex.Message}");
            }
        }
    }
}