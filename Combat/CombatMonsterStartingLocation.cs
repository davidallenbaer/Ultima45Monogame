using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using static Ultima45Monogame.Game1;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame.Combat
{
    public class CombatMonsterStartingLocation
    {
        public Maps CombatMap { get; set; }
        public int MonsterPosition { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public CombatMonsterStartingLocation(Maps map, int position, int y, int x)
        {
            CombatMap = map;
            MonsterPosition = position;
            X = x;
            Y = y;
        }

        public CombatMonsterStartingLocation()
        {

        }
    }
}