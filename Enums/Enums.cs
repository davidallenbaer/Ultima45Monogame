using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultima45Monogame
{
    public static class RPGEnums
    {
        #region Enums

        public enum TownEntityMerchantType
        {
            None = 0,
            WeaponMerchant = 1,
            ArmorMerchant = 2,
            EquipmentMerchant = 3,
            ReagentsMerchant = 4,
            FoodMerchant = 5,
            HealingMerchant = 6,
            GoldDonationMerchant = 7,
            InnMerchant = 8,
        }

        public enum CastSpellMode
        {
            Combat,
            NonCombat
        }

        public enum OpenStatus
        {
            None = 0,
            Open = 1,
            Closed = 2,
        }

        public enum LockedStatus
        {
            None = 0,
            Locked = 1,
            Unlocked = 2,
        }

        public enum PlayerStatus
        {
            None = 0,
            Good = 1,
            Poisoned = 2,
            Sleeping = 3,
            Dead = 4
        }

        public enum CombatState
        {
            None = 0,
            CombatInitialize = 1,
            PlaceEnemies = 2,
            PlacePlayers = 3,
            PlayerTurn = 4,
            EnemyTurn = 5,
            CombatVictory = 6,
            CombatDefeat = 7
        }

        public enum CombatEntityType
        {
            None = 0,
            Player = 1,
            Monster = 2,
        }

        public enum MoveDirection
        {
            None = 0,
            North = 1,
            South = 2,
            East = 3,
            West = 4
        }

        public enum RPGRace
        {
            None = 0,
            Dwarf = 1,
            Elf = 2,
            Halfling = 3,
            Human = 4,
            Dragonborn = 5,
            Gnome = 6,
            HalfElf = 7,
            HalfOrc = 8,
            Tiefling = 9,
        }

        public enum RPGClass
        {
            None = 0,
            Barbarian = 1,
            Bard = 2,
            Cleric = 3,
            Druid = 4,
            Fighter = 5,
            Monk = 6,
            Paladin = 7,
            Ranger = 8,
            Rogue = 9,
            Sorcerer = 10,
            Warlock = 11,
            Wizard = 12,
        }

        public enum RPGAbilities
        {
            None = 0,
            Strength = 1,
            Dexterity = 2,
            Constitution = 3,
            Intelligence = 4,
            Wisdom = 5,
            Charisma = 6,
        }

        public enum RPGAlignment
        {
            None = 0,
            Lawful_Good = 1,
            Neutral_Good = 2,
            Chaotic_Good = 3,
            Lawful_Neutral = 4,
            True_Neutral = 5,
            Chaotic_Neutral = 6,
            Lawful_Evil = 7,
            Neutral_Evil = 8,
            Chaotic_Evil = 9,
        };

        public enum RPGDieType
        {
            None = 0,
            D4 = 4,
            D6 = 6,
            D8 = 8,
            D10 = 10,
            D12 = 12,
            D20 = 20,
            D100 = 100,
        }

        public enum RPGHitDieType
        {
            None = 0,
            D4 = 4,
            D6 = 6,
            D8 = 8,
            D10 = 10,
            D12 = 12,
        }

        public enum Songs
        {
            U4SongNone = 0,
            U4SongWanderer = 1,
            U4SongTowne = 2,
            U4SongShrines = 3,
            U4SongShopping = 4,
            U4SongRuleBritannia = 5,
            U4SongLordBritishCastle = 6,
            U4SongFanfareOfLordBritish = 7,
            U4SongDungeons = 8,
            U4SongCombat = 9
        }

        public enum Maps
        {
            U4MapNone = 0,
            U4MapOverworld = 1,
            U4MapBritain = 2,
            U4MapBuccaneersDen = 3,
            U4MapCove = 4,
            U4MapEmpathAbbey = 5,
            U4MapJhelom = 6,
            U4MapLordBritishCastle1 = 7,
            U4MapLordBritishCastle2 = 8,
            U4MapLycaeum = 9,
            U4MapMagincia = 10,
            U4MapMinoc = 11,
            U4MapMoonglow = 12,
            U4MapPaws = 13,
            U4MapSerpentIsle = 14,
            U4MapSkaraBrae = 15,
            U4MapTrinsic = 16,
            U4MapVesper = 17,
            U4MapYew = 18,
            U4CombatMapBRICK = 19,
            U4CombatMapBRIDGE = 20,
            U4CombatMapBRUSH = 21,
            U4CombatMapCAMP = 22,
            U4CombatMapDNG0 = 23,
            U4CombatMapDNG1 = 24,
            U4CombatMapDNG2 = 25,
            U4CombatMapDNG3 = 26,
            U4CombatMapDNG4 = 27,
            U4CombatMapDNG5 = 28,
            U4CombatMapDNG6 = 29,
            U4CombatMapDUNGEON = 30,
            U4CombatMapFOREST = 31,
            U4CombatMapGRASS = 32,
            U4CombatMapHILL = 33,
            U4CombatMapINN = 34,
            U4CombatMapMARSH = 35,
            U4CombatMapSHIPSEA = 36,
            U4CombatMapSHIPSHIP = 37,
            U4CombatMapSHIPSHOR = 38,
            U4CombatMapSHORE = 39,
            U4CombatMapSHORSHIP = 40,
            U4CombatMapSHRINE = 41
        }

        public enum TileType
        {
            DeepWater = 1,
            MediumWater = 2,
            ShallowWater = 3,
            Swamp = 4,
            Grasslands = 5,
            Scrubland = 6,
            Forest = 7,
            Hills = 8,
            Mountains = 9,
            DungeonEntrance = 10,
            Town = 11,
            Castle = 12,
            Village = 13,
            LordBritishCastleWest = 14,
            LordBritishCastleEntrance = 15,
            LordBritishCastleEast = 16,
            ShipWest = 17,
            ShipNorth = 18,
            ShipEast = 19,
            ShipSouth = 20,
            HorseWest = 21,
            HorseEast = 22,
            TileFloor = 23,
            Bridge = 24,
            Balloon = 25,
            BridgeNorth = 26,
            BridgeSouth = 27,
            LadderUp = 28,
            LadderDown = 29,
            Ruins = 30,
            Shrine = 31,
            Avatar = 32,
            Mage1 = 33,
            Mage2 = 34,
            Bard1 = 35,
            Bard2 = 36,
            Fighter1 = 37,
            Fighter2 = 38,
            Druid1 = 39,
            Druid2 = 40,
            Tinker1 = 41,
            Tinker2 = 42,
            Paladin1 = 43,
            Paladin2 = 44,
            Ranger1 = 45,
            Ranger2 = 46,
            Shepherd1 = 47,
            Shepherd2 = 48,
            Column = 49,
            WhiteSW = 50,
            WhiteSE = 51,
            WhiteNW = 52,
            NE = 53,
            Mast = 54,
            ShipsWheel = 55,
            Rocks = 56,
            LyinDown = 57,
            StoneWall = 58,
            LockedDoor = 59,
            UnlockedDoor = 60,
            Chest = 61,
            Ankh = 62,
            BrickFloor = 63,
            WoodenPlanks = 64,
            Moongate1 = 65,
            Moongate2 = 66,
            Moongate3 = 67,
            Moongate4 = 68,
            PoisonField = 69,
            EnergyField = 70,
            FireField = 71,
            SleepField = 72,
            SolidBarrier = 73,
            HiddenPassage = 74,
            Altar = 75,
            Spit = 76,
            LavaFlow = 77,
            Missile = 78,
            MagicSphere = 79,
            AttackFlash = 80,
            Guard1 = 81,
            Guard2 = 82,
            Citizen1 = 83,
            Citizen2 = 84,
            SingingBard1 = 85,
            SingingBard2 = 86,
            Jester1 = 87,
            Jester2 = 88,
            Beggar1 = 89,
            Beggar2 = 90,
            Child1 = 91,
            Child2 = 92,
            Bull1 = 93,
            Bull2 = 94,
            LordBritish1 = 95,
            LordBritish2 = 96,
            A = 97,
            B = 98,
            C = 99,
            D = 100,
            E = 101,
            F = 102,
            G = 103,
            H = 104,
            I = 105,
            J = 106,
            K = 107,
            L = 108,
            M = 109,
            N = 110,
            O = 111,
            P = 112,
            Q = 113,
            R = 114,
            S = 115,
            T = 116,
            U = 117,
            V = 118,
            W = 119,
            X = 120,
            Y = 121,
            Z = 122,
            Space = 123,
            Right = 124,
            Left = 125,
            Window = 126,
            Blank = 127,
            BrickWall = 128,
            PirateShipWest = 129,
            PirateShipNorth = 130,
            PirateShipEast = 131,
            PirateShipSouth = 132,
            Nixie1 = 133,
            Nixie2 = 134,
            GiantSquid1 = 135,
            GiantSquid2 = 136,
            SeaSerpent1 = 137,
            SeaSerpent2 = 138,
            Seahorse1 = 139,
            Seahorse2 = 140,
            Whirlpool1 = 141,
            Whirlpool2 = 142,
            Storm1 = 143,
            Storm2 = 144,
            Rat1 = 145,
            Rat2 = 146,
            Rat3 = 147,
            Rat4 = 148,
            Bat1 = 149,
            Bat2 = 150,
            Bat3 = 151,
            Bat4 = 152,
            GiantSpider1 = 153,
            GiantSpider2 = 154,
            GiantSpider3 = 155,
            GiantSpider4 = 156,
            Ghost1 = 157,
            Ghost2 = 158,
            Ghost3 = 159,
            Ghost4 = 160,
            Slime1 = 161,
            Slime2 = 162,
            Slime3 = 163,
            Slime4 = 164,
            Troll1 = 165,
            Troll2 = 166,
            Troll3 = 167,
            Troll4 = 168,
            Gremlin1 = 169,
            Gremlin2 = 170,
            Gremlin3 = 171,
            Gremlin4 = 172,
            Mimic1 = 173,
            Mimic2 = 174,
            Mimic3 = 175,
            Mimic4 = 176,
            Reaper1 = 177,
            Reaper2 = 178,
            Reaper3 = 179,
            Reaper4 = 180,
            InsectSwarm1 = 181,
            InsectSwarm2 = 182,
            InsectSwarm3 = 183,
            InsectSwarm4 = 184,
            Gazer1 = 185,
            Gazer2 = 186,
            Gazer3 = 187,
            Gazer4 = 188,
            Phantom1 = 189,
            Phantom2 = 190,
            Phantom3 = 191,
            Phantom4 = 192,
            Orc1 = 193,
            Orc2 = 194,
            Orc3 = 195,
            Orc4 = 196,
            Skeleton1 = 197,
            Skeleton2 = 198,
            Skeleton3 = 199,
            Skeleton4 = 200,
            Rogue1 = 201,
            Rogue2 = 202,
            Rogue3 = 203,
            Rogue4 = 204,
            Python1 = 205,
            Python2 = 206,
            Python3 = 207,
            Python4 = 208,
            Ettin1 = 209,
            Ettin2 = 210,
            Ettin3 = 211,
            Ettin4 = 212,
            Headless1 = 213,
            Headless2 = 214,
            Headless3 = 215,
            Headless4 = 216,
            Cyclops1 = 217,
            Cyclops2 = 218,
            Cyclops3 = 219,
            Cyclops4 = 220,
            Wisp1 = 221,
            Wisp2 = 222,
            Wisp3 = 223,
            Wisp4 = 224,
            EvilMage1 = 225,
            EvilMage2 = 226,
            EvilMage3 = 227,
            EvilMage4 = 228,
            Lich1 = 229,
            Lich2 = 230,
            Lich3 = 231,
            Lich4 = 232,
            LavaLizard1 = 233,
            LavaLizard2 = 234,
            LavaLizard3 = 235,
            LavaLizard4 = 236,
            Zorn1 = 237,
            Zorn2 = 238,
            Zorn3 = 239,
            Zorn4 = 240,
            Daemon1 = 241,
            Daemon2 = 242,
            Daemon3 = 243,
            Daemon4 = 244,
            Hydra1 = 245,
            Hydra2 = 246,
            Hydra3 = 247,
            Hydra4 = 248,
            Dragon1 = 249,
            Dragon2 = 250,
            Dragon3 = 251,
            Dragon4 = 252,
            Balron1 = 253,
            Balron2 = 254,
            Balron3 = 255,
            Balron4 = 256
        }

        public enum Vehicle
        {
            None = 0,
            Ship = 1,
            Horse = 2,
            Balloon = 3
        }

        public enum OverworldMonsterAppearanceType
        {
            None = 0,
            NES = 1, //No visible Monsters on Overworld - Attacks are random
            PC = 2, //Visible Monsters on Overworld
        }

        public enum CombatModeBattleType
        {
            None = 0,
            TurnBased_Ultima = 1, //Turn based combat similar to Ultima 1-5
            TurnBased_FinalFantasy = 2, //Turn based combat similar to Final Fantasy 1-6
            TurnBased_Wizardry = 3, //Turn based combat similar to Bard's Tale and Wizardry
        }

        public enum CombatMode
        {
            None = 0,
            Manual = 1,
            Auto = 2,
        }

        #endregion

    }
}
