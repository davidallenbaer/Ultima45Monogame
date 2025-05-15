using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame.Combat
{
    public class CombatEntity
    {
        public int ID { get; set; } // Unique identifier for the entity
        public FantasyMonster Monster { get; set; }
        public FantasyPlayer Player { get; set; }
        public CombatEntityType EntityType { get; set; } // e.g., "Monster", "Party"
        public int X { get; set; } // X-coordinate in combat map
        public int Y { get; set; } // Y-coordinate in combat map
        public int Initiative { get; set; } = 0; // Initiative value for combat order
        public int InitialXPosition { get; set; } 
        public int InitialYPosition { get; set; } 

        public bool IsVisible { get; set; } = true; // Visibility status of the entity

        public CombatEntity(CombatEntityType entityType, int y, int x, bool visible, int initiative)
        {
            EntityType = entityType;
            X = x;
            Y = y;
            IsVisible = visible;
            Initiative = 0;
        }

        // Parameterless constructor for serialization
        public CombatEntity() { }

    }
}
