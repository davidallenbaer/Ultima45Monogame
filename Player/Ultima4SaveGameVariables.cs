using System;
using static Ultima45Monogame.Game1;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    /// <summary>
    /// This class is used to store the variables for the Ultima 4 save game.
    /// Need to save the position of the player in the overworld, underworld, town map, and dungeon map
    /// so that we can load the game and put the player back in the same place regardless of the map.
    /// </summary>
    [Serializable]
    public class Ultima4SaveGameVariables
    {
        public Maps CurrentMap { get; set; }
        public int pcOverworldLocationX { get; set; } = 0;
        public int pcOverworldLocationY { get; set; } = 0;
        public int pcTownMapLocationX { get; set; } = 0;
        public int pcTownMapLocationY { get; set; } = 0;
        public int pcDungeonMapLocationX { get; set; } = 0;
        public int pcDungeonMapLocationY { get; set; } = 0;
        public Vehicle CurrentVehicle { get; set; } = Vehicle.None;
        public MoveDirection CurrentHeading { get; set; } = MoveDirection.None;
    }
}
