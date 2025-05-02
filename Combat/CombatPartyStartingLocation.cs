using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using static Ultima45Monogame.Game1;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame.Combat
{
    public class CombatPartyStartingLocation
    {
        public Maps CombatMap { get; set; }
        public int PartyPosition { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public CombatPartyStartingLocation(Maps map, int position, int y, int x)
        {
            CombatMap = map;
            PartyPosition = position;
            X = x;
            Y = y;
        }

        public CombatPartyStartingLocation()
        {

        }
    }
}