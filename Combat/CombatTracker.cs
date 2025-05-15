using System.Collections.Generic;
using System.Linq;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame.Combat
{
    public class CombatTracker
    {
        public List<CombatEntity> CombatEntities { get; set; }

        public void AddCombatEntity(CombatEntity combatEntity)
        {
            CombatEntities.Add(combatEntity);
        }

        public void RemoveCombatEntityAt(int y, int x)
        {
            CombatEntities.RemoveAll(e => e.X == x && e.Y == y);
        }

        public void RemoveCombatEntityByEntityType(CombatEntityType entityType)
        {
            CombatEntities.RemoveAll(e => e.EntityType == entityType);
        }

        public CombatEntity? GetCombatEntityAt(int y, int x)
        {
            return CombatEntities.FirstOrDefault(e => e.X == x && e.Y == y);
        }

        public int[,] CombatGrid { get; set; }
        public Maps CombatMapType { get; set; }
        public int CombatRound { get; set; } = 0;

        public CombatTracker(
            int[,] combatGrid,
            Maps combatMapType)
        {
            CombatGrid = combatGrid;
            CombatMapType = combatMapType;
        }

        public CombatTracker()
        {
            CombatEntities = new List<CombatEntity>();
        }
    }
}