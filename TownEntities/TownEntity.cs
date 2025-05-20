using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using static Ultima45Monogame.Game1;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    [Serializable]
    public class TownEntity
    {
        public Maps TownMap { get; set; } = Maps.U4MapNone;
        public string EntityType { get; set; } = "NPC";
        public int EntityID { get; set; } = 0;
        public int X { get; set; }
        public int Y { get; set; }
        public int TileValue { get; set; }
        public bool IsVisible { get; set; } = true;
        public int Movement { get; set; } = 0;
        public int Schedule { get; set; } = 0;
        public int DialogIndex { get; set; } = 0;

        public TownEntity(Maps townMap, string entityType, int entityid, int y, int x, int tileValue, bool visible, int movement, int schedule, int dialogindex)
        {
            EntityType = entityType;
            TownMap = townMap;
            EntityID = entityid;
            X = x;
            Y = y;
            TileValue = tileValue;
            IsVisible = visible;
            Movement = movement;
            Schedule = schedule;
            DialogIndex = dialogindex;
        }

        // Parameterless constructor for serialization
        public TownEntity() { }
    }
}
