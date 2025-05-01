using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using static Ultima45Monogame.Game1;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    [Serializable]
    public class OverworldEntity
    {
        public string EntityType { get; set; } // e.g., "Monster", "GoldChest", "Balloon", "Horse", "Ship"
        public int X { get; set; } // X-coordinate in mapUltima4Overworld
        public int Y { get; set; } // Y-coordinate in mapUltima4Overworld
        public int TileValue { get; set; }

        public bool IsVisible { get; set; } = true; // Visibility status of the entity
        public MoveDirection EntityFacing { get; set; } = MoveDirection.None;

        public OverworldEntity(string entityType, int x, int y, int tileValue, bool visible, MoveDirection entityfacing = MoveDirection.None)
        {
            EntityType = entityType;
            X = x;
            Y = y;
            TileValue = tileValue;
            IsVisible = visible;
            EntityFacing = entityfacing;
        }

        // Parameterless constructor for serialization
        public OverworldEntity() { }
    }
}
