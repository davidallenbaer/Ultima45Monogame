﻿using System;
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
        public int pcDungeonLevel { get; set; } = 0;

        public Vehicle CurrentVehicle { get; set; } = Vehicle.None;
        public MoveDirection CurrentHeading { get; set; } = MoveDirection.None;
        public int GP { get; set; } = 0;
        public int Food { get; set; } = 0;
        public int GameMoves { get; set; } = 0;
        public int Honesty { get; set; } = 0;
        public int Compassion { get; set; } = 0;
        public int Valor { get; set; } = 0;
        public int Justice { get; set; } = 0;
        public int Sacrifice { get; set; } = 0;
        public int Honor { get; set; } = 0;
        public int Spirituality { get; set; } = 0;
        public int Humility { get; set; } = 0;
        public int Torches { get; set; } = 0;
        public int Gems { get; set; } = 0;
        public int Keys { get; set; } = 0;
        public int Sextants { get; set; } = 0;
        public int Skull { get; set; } = 0;
        public int Candle { get; set; } = 0;
        public int Book { get; set; } = 0;
        public int Bell { get; set; } = 0;
        public int KeyPartC { get; set; } = 0;
        public int KeyPartL { get; set; } = 0;
        public int KeyPartT { get; set; } = 0;
        public int Horn { get; set; } = 0;
        public int Wheel { get; set; } = 0;
        public bool SkullDestroyed { get; set; } = false;
        public bool CandleUsedAtAbyssEntrance { get; set; } = false;
        public bool BookUsedAtAbyssEntrance { get; set; } = false;
        public bool BellUsedAtAbyssEntrance { get; set; } = false;

        public int StoneBlue { get; set; } = 0; //Associated with Honesty
        public int StoneYellow { get; set; } = 0; //Associated with Compassion
        public int StoneRed { get; set; } = 0; //Associated with Valor
        public int StoneGreen { get; set; } = 0; //Associated with Justice
        public int StoneOrange { get; set; } = 0; //Associated with Sacrifice
        public int StonePurple { get; set; } = 0; //Associated with Honor
        public int StoneWhite { get; set; } = 0; //Associated with Spirituality
        public int StoneBlack { get; set; } = 0; //Associated with Humility

        public int RuneHonesty { get; set; } = 0;
        public int RuneCompassion { get; set; } = 0;
        public int RuneValor { get; set; } = 0;
        public int RuneJustice { get; set; } = 0;
        public int RuneSacrifice { get; set; } = 0;
        public int RuneHonor { get; set; } = 0;
        public int RuneSpirituality { get; set; } = 0;
        public int RuneHumility { get; set; } = 0;

        public int CurrentPhaseLeftMoon { get; set; } = 0;
        public int CurrentPhaseRightMoon { get; set; } = 0;
        public int HullIntegrityCurrentShip { get; set; } = 0;
        public bool IntroducedToLordBritish { get; set; } = false;
        public DateTime? TimeOfLastSuccessfulHoleUpAndCamp { get; set; } = null;
        public DateTime? TimeOfLastMandrakeFind { get; set; } = null;
        public DateTime? TimeOfLastNightshadeFind { get; set; } = null;
        public DateTime? TimeOfLastSuccessfulShrineMeditation { get; set; } = null;
        public DateTime? TimeOfLastVirtueRelatedConversation { get; set; } = null;
    }
}
