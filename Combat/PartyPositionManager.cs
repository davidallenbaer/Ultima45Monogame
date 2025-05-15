using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Ultima45Monogame;
using static Ultima45Monogame.Game1;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame.Combat
{
    public class PartyPositionManager
    {
        public List<CombatPartyStartingLocation> PartyPositions { get; set; } = new List<CombatPartyStartingLocation>();

        public void AddPartyPosition(Maps map, int partyposition, int y, int x)
        {
            PartyPositions.Add(new CombatPartyStartingLocation(map, partyposition, y, x));
        }

        public void RemovePartyPosition(Maps map, int partyposition)
        {
            PartyPositions.RemoveAll(e => e.CombatMap == map && e.PartyPosition == partyposition);
        }

        public CombatPartyStartingLocation? GetPartyPosition(Maps map, int partyposition)
        {
            return PartyPositions.FirstOrDefault(e => e.CombatMap == map && e.PartyPosition == partyposition);
        }

        public void LoadFromFile(Maps map, string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);

                int positionIndex = 0; // Tracks the party position index
                foreach (var line in lines)
                {
                    var parts = line.Split(',');

                    if (parts.Length == 2 &&
                        int.TryParse(parts[0], out int x) &&
                        int.TryParse(parts[1], out int y))
                    {
                        AddPartyPosition(map, positionIndex++, y, x);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading party positions: {ex.Message}");
            }
        }
    }
}