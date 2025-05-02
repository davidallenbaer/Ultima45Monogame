using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.IO;
using Ultima45Monogame.Combat;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame;

public class Game1 : Game
{
    #region Declarations

    public enum GameStates
    {
        LoadingIntro,
        Menu,
        Playing,
        Paused,
        GameOver
    }

    private int selectedMenuIndex = 0;
    private string[] pauseMenuOptions = { "Resume", "Exit to Main Menu", "Exit to Windows" };

    private OverworldEntityManager overworldEntityManager = new OverworldEntityManager();
    private MonsterPositionManager monsterPositionManager = new MonsterPositionManager();
    private PartyPositionManager partyPositionManager = new PartyPositionManager();

    private KeyboardState oldKeyboardState;
    private KeyboardState newKeyboardState;
    private GamePadState gamePad1State;
    private GameStates _currentState;
    private Vehicle _currentVehicle = Vehicle.None;
    private MoveDirection _currentHeading = MoveDirection.None;

    private bool bDetectCollision = true;
    private int iTeleportTownIndex = 1;
    private int iSpawnVehicleIndex = 1;
    private int iCombatMapIndex = 1;
    private bool bGamePaused = false;
    private FantasyPlayer player1 = new FantasyPlayer();

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    int scaleFactor = 2;
    bool bIsMouseVisible = true;
    private int defaultScreenSizeWidth = 1024;
    private int defaultScreenSizeHeight = 768;

    private const int overworldGridSize = 256;
    private const int mainDisplayGridSize = 11;
    private const int mainDisplayCenter = 5;
    private const int mainDisplayOneNorthOfCenter = 4;
    private const int mainDisplayOneSouthOfCenter = 6;
    private const int mainDisplayOneEastOfCenter = 6;
    private const int mainDisplayOneWestOfCenter = 4;

    private const int townGridSize = 32;
    private const int combatGridSize = 11;

    int[,] mapUltima4Overworld = new int[overworldGridSize, overworldGridSize];
    int[,] mapMainDisplay = new int[mainDisplayGridSize, mainDisplayGridSize];
    int[,] mapUltima4Britain = new int[townGridSize, townGridSize];
    int[,] mapUltima4BuccaneersDen = new int[townGridSize, townGridSize];
    int[,] mapUltima4Cove = new int[townGridSize, townGridSize];
    int[,] mapUltima4EmpathAbbey = new int[townGridSize, townGridSize];
    int[,] mapUltima4Jhelom = new int[townGridSize, townGridSize];
    int[,] mapUltima4LordBritishCastle1 = new int[townGridSize, townGridSize];
    int[,] mapUltima4LordBritishCastle2 = new int[townGridSize, townGridSize];
    int[,] mapUltima4Lycaeum = new int[townGridSize, townGridSize];
    int[,] mapUltima4Magincia = new int[townGridSize, townGridSize];
    int[,] mapUltima4Moonglow = new int[townGridSize, townGridSize];
    int[,] mapUltima4Paws = new int[townGridSize, townGridSize];
    int[,] mapUltima4SerpentIsle = new int[townGridSize, townGridSize];
    int[,] mapUltima4SkaraBrae = new int[townGridSize, townGridSize];
    int[,] mapUltima4Trinsic = new int[townGridSize, townGridSize];
    int[,] mapUltima4Vesper = new int[townGridSize, townGridSize];
    int[,] mapUltima4Yew = new int[townGridSize, townGridSize];
    int[,] mapUltima4Minoc = new int[townGridSize, townGridSize];

    int[,] mapUltima4CombatBRICK = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatBRIDGE = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatBRUSH = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatCAMP = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatDNG0 = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatDNG1 = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatDNG2 = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatDNG3 = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatDNG4 = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatDNG5 = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatDNG6 = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatDUNGEON = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatFOREST = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatGRASS = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatHILL = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatINN = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatMARSH = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatSHIPSEA = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatSHIPSHIP = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatSHIPSHOR = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatSHORE = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatSHORSHIP = new int[combatGridSize, combatGridSize];
    int[,] mapUltima4CombatSHRINE = new int[combatGridSize, combatGridSize];
    private Maps currentMap; // Variable to hold the current map
    private Songs currentSong; // Variable to hold the current song

    private int pcOverworldLocationX = 86; //Start at Lord British's Castle
    private int pcOverworldLocationY = 109; //Start at Lord British's Castle
    private int pcTownMapLocationX = 0;
    private int pcTownMapLocationY = 0;

    public Texture2D spriteDeepWater;
    public Texture2D spriteMediumWater;
    public Texture2D spriteShallowWater;
    public Texture2D spriteSwamp;
    public Texture2D spriteGrasslands;
    public Texture2D spriteScrubland;
    public Texture2D spriteForest;
    public Texture2D spriteHills;
    public Texture2D spriteMountains;
    public Texture2D spriteDungeonEntrance;
    public Texture2D spriteTown;
    public Texture2D spriteCastle;
    public Texture2D spriteVillage;
    public Texture2D spriteLordBritishCastleWest;
    public Texture2D spriteLordBritishCastleEntrance;
    public Texture2D spriteLordBritishCastleEast;
    public Texture2D spriteShipWest;
    public Texture2D spriteShipNorth;
    public Texture2D spriteShipEast;
    public Texture2D spriteShipSouth;
    public Texture2D spriteHorseWest;
    public Texture2D spriteHorseEast;
    public Texture2D spriteTileFloor;
    public Texture2D spriteBridge;
    public Texture2D spriteBalloon;
    public Texture2D spriteBridgeNorth;
    public Texture2D spriteBridgeSouth;
    public Texture2D spriteLadderUp;
    public Texture2D spriteLadderDown;
    public Texture2D spriteRuins;
    public Texture2D spriteShrine;
    public Texture2D spriteAvatar;
    public Texture2D spriteMage1;
    public Texture2D spriteMage2;
    public Texture2D spriteBard1;
    public Texture2D spriteBard2;
    public Texture2D spriteFighter1;
    public Texture2D spriteFighter2;
    public Texture2D spriteDuid1;
    public Texture2D spriteDruid2;
    public Texture2D spriteTinker1;
    public Texture2D spriteTinker2;
    public Texture2D spritePaladin1;
    public Texture2D spritePaladin2;
    public Texture2D spriteRanger1;
    public Texture2D spriteRanger2;
    public Texture2D spriteShepherd1;
    public Texture2D spriteShepherd2;
    public Texture2D spriteColumn;
    public Texture2D spriteWhiteSW;
    public Texture2D spriteWhiteSE;
    public Texture2D spriteWhiteNW;
    public Texture2D spriteNE;
    public Texture2D spriteMast;
    public Texture2D spriteShipsWheel;
    public Texture2D spriteRocks;
    public Texture2D spriteLyinDown;
    public Texture2D spriteStoneWall;
    public Texture2D spriteLockedDoor;
    public Texture2D spriteUnlockedDoor;
    public Texture2D spriteChest;
    public Texture2D spriteAnkh;
    public Texture2D spriteBrickFloor;
    public Texture2D spriteWoodenPlanks;
    public Texture2D spriteMoongate1;
    public Texture2D spriteMoongate2;
    public Texture2D spriteMoongate3;
    public Texture2D spriteMoongate4;
    public Texture2D spritePoisonField;
    public Texture2D spriteEnergyField;
    public Texture2D spriteFireField;
    public Texture2D spriteSleepField;
    public Texture2D spriteSolidBarrier;
    public Texture2D spriteHiddenPassage;
    public Texture2D spriteAltar;
    public Texture2D spriteSpit;
    public Texture2D spriteLavaFlow;
    public Texture2D spriteMissile;
    public Texture2D spriteMagicSphere;
    public Texture2D spriteAttackFlash;
    public Texture2D spriteGuard1;
    public Texture2D spriteGuard2;
    public Texture2D spriteCitizen1;
    public Texture2D spriteCitizen2;
    public Texture2D spriteSingingBard1;
    public Texture2D spriteSingingBard2;
    public Texture2D spriteJester1;
    public Texture2D spriteJester2;
    public Texture2D spriteBeggar1;
    public Texture2D spriteBeggar2;
    public Texture2D spriteChild1;
    public Texture2D spriteChild2;
    public Texture2D spriteBull1;
    public Texture2D spriteBull2;
    public Texture2D spriteLordBritish1;
    public Texture2D spriteLordBritish2;
    public Texture2D spriteA;
    public Texture2D spriteB;
    public Texture2D spriteC;
    public Texture2D spriteD;
    public Texture2D spriteE;
    public Texture2D spriteF;
    public Texture2D spriteG;
    public Texture2D spriteH;
    public Texture2D spriteI;
    public Texture2D spriteJ;
    public Texture2D spriteK;
    public Texture2D spriteL;
    public Texture2D spriteM;
    public Texture2D spriteN;
    public Texture2D spriteO;
    public Texture2D spriteP;
    public Texture2D spriteQ;
    public Texture2D spriteR;
    public Texture2D spriteS;
    public Texture2D spriteT;
    public Texture2D spriteU;
    public Texture2D spriteV;
    public Texture2D spriteW;
    public Texture2D spriteX;
    public Texture2D spriteY;
    public Texture2D spriteZ;
    public Texture2D spriteSpace;
    public Texture2D spriteRight;
    public Texture2D spriteLeft;
    public Texture2D spriteWindow;
    public Texture2D spriteBlank;
    public Texture2D spriteBrickWall;
    public Texture2D spritePirateShipWest;
    public Texture2D spritePirateShipNorth;
    public Texture2D spritePirateShipEast;
    public Texture2D spritePirateShipSouth;
    public Texture2D spriteNixie1;
    public Texture2D spriteNixie2;
    public Texture2D spriteGiantSquid1;
    public Texture2D spriteGiantSquid2;
    public Texture2D spriteSeaSerpent1;
    public Texture2D spriteSeaSerpent2;
    public Texture2D spriteSeahorse1;
    public Texture2D spriteSeahorse2;
    public Texture2D spriteWhirlpool1;
    public Texture2D spriteWhirlpool2;
    public Texture2D spriteStorm1;
    public Texture2D spriteStorm2;
    public Texture2D spriteRat1;
    public Texture2D spriteRat2;
    public Texture2D spriteRat3;
    public Texture2D spriteRat4;
    public Texture2D spriteBat1;
    public Texture2D spriteBat2;
    public Texture2D spriteBat3;
    public Texture2D spriteBat4;
    public Texture2D spriteGiantSpider1;
    public Texture2D spriteGiantSpider2;
    public Texture2D spriteGiantSpider3;
    public Texture2D spriteGiantSpider4;
    public Texture2D spriteGhost1;
    public Texture2D spriteGhost2;
    public Texture2D spriteGhost3;
    public Texture2D spriteGhost4;
    public Texture2D spriteSlime1;
    public Texture2D spriteSlime2;
    public Texture2D spriteSlime3;
    public Texture2D spriteSlime4;
    public Texture2D spriteTroll1;
    public Texture2D spriteTroll2;
    public Texture2D spriteTroll3;
    public Texture2D spriteTroll4;
    public Texture2D spriteGremlin1;
    public Texture2D spriteGremlin2;
    public Texture2D spriteGremlin3;
    public Texture2D spriteGremlin4;
    public Texture2D spriteMimic1;
    public Texture2D spriteMimic2;
    public Texture2D spriteMimic3;
    public Texture2D spriteMimic4;
    public Texture2D spriteReaper1;
    public Texture2D spriteReaper2;
    public Texture2D spriteReaper3;
    public Texture2D spriteReaper4;
    public Texture2D spriteInsectSwarm1;
    public Texture2D spriteInsectSwarm2;
    public Texture2D spriteInsectSwarm3;
    public Texture2D spriteInsectSwarm4;
    public Texture2D spriteGazer1;
    public Texture2D spriteGazer2;
    public Texture2D spriteGazer3;
    public Texture2D spriteGazer4;
    public Texture2D spritePhantom1;
    public Texture2D spritePhantom2;
    public Texture2D spritePhantom3;
    public Texture2D spritePhantom4;
    public Texture2D spriteOrc1;
    public Texture2D spriteOrc2;
    public Texture2D spriteOrc3;
    public Texture2D spriteOrc4;
    public Texture2D spriteSkeleton1;
    public Texture2D spriteSkeleton2;
    public Texture2D spriteSkeleton3;
    public Texture2D spriteSkeleton4;
    public Texture2D spriteRogue1;
    public Texture2D spriteRogue2;
    public Texture2D spriteRogue3;
    public Texture2D spriteRogue4;
    public Texture2D spritePython1;
    public Texture2D spritePython2;
    public Texture2D spritePython3;
    public Texture2D spritePython4;
    public Texture2D spriteEttin1;
    public Texture2D spriteEttin2;
    public Texture2D spriteEttin3;
    public Texture2D spriteEttin4;
    public Texture2D spriteHeadless1;
    public Texture2D spriteHeadless2;
    public Texture2D spriteHeadless3;
    public Texture2D spriteHeadless4;
    public Texture2D spriteCyclops1;
    public Texture2D spriteCyclops2;
    public Texture2D spriteCyclops3;
    public Texture2D spriteCyclops4;
    public Texture2D spriteWisp1;
    public Texture2D spriteWisp2;
    public Texture2D spriteWisp3;
    public Texture2D spriteWisp4;
    public Texture2D spriteEvilMage1;
    public Texture2D spriteEvilMage2;
    public Texture2D spriteEvilMage3;
    public Texture2D spriteEvilMage4;
    public Texture2D spriteLich1;
    public Texture2D spriteLich2;
    public Texture2D spriteLich3;
    public Texture2D spriteLich4;
    public Texture2D spriteLavaLizard1;
    public Texture2D spriteLavaLizard2;
    public Texture2D spriteLavaLizard3;
    public Texture2D spriteLavaLizard4;
    public Texture2D spriteZorn1;
    public Texture2D spriteZorn2;
    public Texture2D spriteZorn3;
    public Texture2D spriteZorn4;
    public Texture2D spriteDaemon1;
    public Texture2D spriteDaemon2;
    public Texture2D spriteDaemon3;
    public Texture2D spriteDaemon4;
    public Texture2D spriteHydra1;
    public Texture2D spriteHydra2;
    public Texture2D spriteHydra3;
    public Texture2D spriteHydra4;
    public Texture2D spriteDragon1;
    public Texture2D spriteDragon2;
    public Texture2D spriteDragon3;
    public Texture2D spriteDragon4;
    public Texture2D spriteBalron1;
    public Texture2D spriteBalron2;
    public Texture2D spriteBalron3;
    public Texture2D spriteBalron4;

    public Texture2D _ultima4Background;

    private Song _songUltima4Wanderer;
    private Song _songUltima4Towne;
    private Song _songUltima4Shrines;
    private Song _songUltima4Shopping;
    private Song _songUltima4RuleBritannia;
    private Song _songUltima4LordBritishCastle;
    private Song _songUltima4FanfareOfLordBritish;
    private Song _songUltima4Dungeons;
    private Song _songUltima4Combat;
    private double inputTimer;
    private double inputDelay;
    private SoundEffect _soundEffect_Walk;
    private SoundEffect _soundEffect_BadCommand;
    

    #endregion

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = bIsMouseVisible;
        currentMap = Maps.U4MapOverworld;
        currentSong = Songs.U4SongNone;
        player1.Enabled = true;
    }

    protected override void Initialize()
    {
        _currentState = GameStates.LoadingIntro;

        // Set full screen mode and resolution
        _graphics.IsFullScreen = false;
        //_graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        //_graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _graphics.PreferredBackBufferWidth = defaultScreenSizeWidth;
        _graphics.PreferredBackBufferHeight = defaultScreenSizeHeight;
        _graphics.ApplyChanges();

        Microsoft.Xna.Framework.Media.MediaPlayer.IsRepeating = true;
        Microsoft.Xna.Framework.Media.MediaPlayer.Volume = 0.25f; // Adjust volume (0.0 to 1.0)

        inputDelay = .125;

        overworldEntityManager.AddEntity("Balloon", 242, 233, (int)TileType.Balloon, true);
        overworldEntityManager.AddEntity("Horse", 146, 97, (int)TileType.HorseEast, true, MoveDirection.East);
        overworldEntityManager.AddEntity("Ship", 107, 82, (int)TileType.ShipEast, true, MoveDirection.East);

        base.Initialize();
    }

    #region Load Content

    public void LoadUltima4TileSet()
    {
        spriteDeepWater = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 000 - Deep Water");
        spriteMediumWater = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 001 - Medium Water");
        spriteShallowWater = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 002 - Shallow Water");
        spriteSwamp = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 003 - Swamp");
        spriteGrasslands = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 004 - Grasslands");
        spriteScrubland = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 005 - Scrubland");
        spriteForest = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 006 - Forest");
        spriteHills = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 007 - Hills");
        spriteMountains = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 008 - Mountains");
        spriteDungeonEntrance = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 009 - Dungeon Entrance");
        spriteTown = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 010 - Town");
        spriteCastle = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 011 - Castle");
        spriteVillage = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 012 - Village");
        spriteLordBritishCastleWest = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 013 - Lord British's Castle West");
        spriteLordBritishCastleEntrance = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 014 - Lord British's Castle Entrance");
        spriteLordBritishCastleEast = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 000 Tile 015 - Lord British's Castle East");
        spriteShipWest = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 016 - Ship West");
        spriteShipNorth = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 017 - Ship North");
        spriteShipEast = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 018 - Ship East");
        spriteShipSouth = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 019 - Ship South");
        spriteHorseWest = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 020 - Horse West");
        spriteHorseEast = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 021 - Horse East");
        spriteTileFloor = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 022 - Tile Floor");
        spriteBridge = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 023 - Bridge");
        spriteBalloon = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 024 - Balloon");
        spriteBridgeNorth = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 025 - Bridge North");
        spriteBridgeSouth = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 026 - Bridge South");
        spriteLadderUp = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 027 - Ladder Up");
        spriteLadderDown = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 028 - Ladder Down");
        spriteRuins = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 029 - Ruins");
        spriteShrine = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 030 - Shrine");
        spriteAvatar = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 001 Tile 031 - Avatar");
        spriteMage1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 032 - Mage 1");
        spriteMage2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 033 - Mage 2");
        spriteBard1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 034 - Bard 1");
        spriteBard2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 035 - Bard 2");
        spriteFighter1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 036 - Fighter 1");
        spriteFighter2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 037 - Fighter 2");
        spriteDuid1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 038 - Duid 1");
        spriteDruid2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 039 - Druid 2");
        spriteTinker1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 040 - Tinker 1");
        spriteTinker2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 041 - Tinker 2");
        spritePaladin1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 042 - Paladin 1");
        spritePaladin2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 043 - Paladin 2");
        spriteRanger1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 044 - Ranger 1");
        spriteRanger2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 045 - Ranger 2");
        spriteShepherd1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 046 - Shepherd 1");
        spriteShepherd2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 002 Tile 047 - Shepherd 2");
        spriteColumn = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 048 - Column");
        spriteWhiteSW = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 049 - White SW");
        spriteWhiteSE = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 050 - White SE");
        spriteWhiteNW = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 051 - White NW");
        spriteNE = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 052 - NE");
        spriteMast = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 053 - Mast");
        spriteShipsWheel = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 054 - Ship's Wheel");
        spriteRocks = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 055 - Rocks");
        spriteLyinDown = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 056 - Lyin Down");
        spriteStoneWall = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 057 - Stone Wall");
        spriteLockedDoor = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 058 - Locked Door");
        spriteUnlockedDoor = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 059 - Unlocked Door");
        spriteChest = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 060 - Chest");
        spriteAnkh = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 061 - Ankh");
        spriteBrickFloor = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 062 - Brick Floor");
        spriteWoodenPlanks = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 003 Tile 063 - Wooden Planks");
        spriteMoongate1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 064 - Moongate 1");
        spriteMoongate2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 065 - Moongate 2");
        spriteMoongate3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 066 - Moongate 3");
        spriteMoongate4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 067 - Moongate 4");
        spritePoisonField = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 068 - Poison Field");
        spriteEnergyField = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 069 - Energy Field");
        spriteFireField = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 070 - Fire Field");
        spriteSleepField = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 071 - Sleep Field");
        spriteSolidBarrier = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 072 - Solid Barrier");
        spriteHiddenPassage = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 073 - Hidden Passage");
        spriteAltar = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 074 - Altar");
        spriteSpit = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 075 - Spit");
        spriteLavaFlow = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 076 - Lava Flow");
        spriteMissile = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 077 - Missile");
        spriteMagicSphere = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 078 - Magic Sphere");
        spriteAttackFlash = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 004 Tile 079 - Attack Flash");
        spriteGuard1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 080 - Guard 1");
        spriteGuard2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 081 - Guard 2");
        spriteCitizen1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 082 - Citizen 1");
        spriteCitizen2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 083 - Citizen 2");
        spriteSingingBard1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 084 - Singing Bard 1");
        spriteSingingBard2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 085 - Singing Bard 2");
        spriteJester1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 086 - Jester 1");
        spriteJester2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 087 - Jester 2");
        spriteBeggar1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 088 - Beggar 1");
        spriteBeggar2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 089 - Beggar 2");
        spriteChild1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 090 - Child 1");
        spriteChild2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 091 - Child 2");
        spriteBull1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 092 - Bull 1");
        spriteBull2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 093 - Bull 2");
        spriteLordBritish1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 094 - Lord British 1");
        spriteLordBritish2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Row 005 Tile 095 - Lord British 2");
        spriteA = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 096 - A");
        spriteB = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 097 - B");
        spriteC = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 098 - C");
        spriteD = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 099 - D");
        spriteE = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 100 - E");
        spriteF = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 101 - F");
        spriteG = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 102 - G");
        spriteH = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 103 - H");
        spriteI = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 104 - I");
        spriteJ = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 105 - J");
        spriteK = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 106 - K");
        spriteL = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 107 - L");
        spriteM = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 108 - M");
        spriteN = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 109 - N");
        spriteO = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 110 - O");
        spriteP = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 006 Tile 111 - P");
        spriteQ = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 112 - Q");
        spriteR = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 113 - R");
        spriteS = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 114 - S");
        spriteT = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 115 - T");
        spriteU = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 116 - U");
        spriteV = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 117 - V");
        spriteW = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 118 - W");
        spriteX = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 119 - X");
        spriteY = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 120 - Y");
        spriteZ = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 121 - Z");
        spriteSpace = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 122 - Space");
        spriteRight = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 123 - Right");
        spriteLeft = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 124 - Left");
        spriteWindow = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 125 - Window");
        spriteBlank = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 126 - Blank");
        spriteBrickWall = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 007 Tile 127 - Brick Wall");
        spritePirateShipWest = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 128 - Pirate Ship West");
        spritePirateShipNorth = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 129 - Pirate Ship North");
        spritePirateShipEast = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 130 - Pirate Ship East");
        spritePirateShipSouth = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 131 - Pirate Ship South");
        spriteNixie1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 132 - Nixie 1");
        spriteNixie2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 133 - Nixie 2");
        spriteGiantSquid1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 134 - Giant Squid 1");
        spriteGiantSquid2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 135 - Giant Squid 2");
        spriteSeaSerpent1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 136 - Sea Serpent 1");
        spriteSeaSerpent2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 137 - Sea Serpent 2");
        spriteSeahorse1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 138 - Seahorse 1");
        spriteSeahorse2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 139 - Seahorse 2");
        spriteWhirlpool1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 140 - Whirlpool 1");
        spriteWhirlpool2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 141 - Whirlpool 2");
        spriteStorm1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 142 - Storm 1");
        spriteStorm2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 008 Tile 143 - Storm 2");
        spriteRat1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 144 - Rat 1");
        spriteRat2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 145 - Rat 2");
        spriteRat3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 146 - Rat 3");
        spriteRat4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 147 - Rat 4");
        spriteBat1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 148 - Bat 1");
        spriteBat2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 149 - Bat 2");
        spriteBat3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 150 - Bat 3");
        spriteBat4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 151 - Bat 4");
        spriteGiantSpider1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 152 - Giant Spider 1");
        spriteGiantSpider2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 153 - Giant Spider 2");
        spriteGiantSpider3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 154 - Giant Spider 3");
        spriteGiantSpider4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 155 - Giant Spider 4");
        spriteGhost1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 156 - Ghost 1");
        spriteGhost2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 157 - Ghost 2");
        spriteGhost3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 158 - Ghost 3");
        spriteGhost4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 009 Tile 159 - Ghost 4");
        spriteSlime1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 160 - Slime 1");
        spriteSlime2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 161 - Slime 2");
        spriteSlime3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 162 - Slime 3");
        spriteSlime4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 163 - Slime 4");
        spriteTroll1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 164 - Troll 1");
        spriteTroll2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 165 - Troll 2");
        spriteTroll3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 166 - Troll 3");
        spriteTroll4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 167 - Troll 4");
        spriteGremlin1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 168 - Gremlin 1");
        spriteGremlin2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 169 - Gremlin 2");
        spriteGremlin3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 170 - Gremlin 3");
        spriteGremlin4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 171 - Gremlin 4");
        spriteMimic1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 172 - Mimic 1");
        spriteMimic2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 173 - Mimic 2");
        spriteMimic3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 174 - Mimic 3");
        spriteMimic4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 010 Tile 175 - Mimic 4");
        spriteReaper1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 176 - Reaper 1");
        spriteReaper2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 177 - Reaper 2");
        spriteReaper3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 178 - Reaper 3");
        spriteReaper4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 179 - Reaper 4");
        spriteInsectSwarm1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 180 - Insect Swarm 1");
        spriteInsectSwarm2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 181 - Insect Swarm 2");
        spriteInsectSwarm3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 182 - Insect Swarm 3");
        spriteInsectSwarm4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 183 - Insect Swarm 4");
        spriteGazer1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 184 - Gazer 1");
        spriteGazer2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 185 - Gazer 2");
        spriteGazer3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 186 - Gazer 3");
        spriteGazer4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 187 - Gazer 4");
        spritePhantom1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 188 - Phantom 1");
        spritePhantom2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 189 - Phantom 2");
        spritePhantom3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 190 - Phantom 3");
        spritePhantom4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 011 Tile 191 - Phantom 4");
        spriteOrc1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 192 - Orc 1");
        spriteOrc2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 193 - Orc 2");
        spriteOrc3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 194 - Orc 3");
        spriteOrc4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 195 - Orc 4");
        spriteSkeleton1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 196 - Skeleton 1");
        spriteSkeleton2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 197 - Skeleton 2");
        spriteSkeleton3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 198 - Skeleton 3");
        spriteSkeleton4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 199 - Skeleton 4");
        spriteRogue1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 200 - Rogue 1");
        spriteRogue2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 201 - Rogue 2");
        spriteRogue3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 202 - Rogue 3");
        spriteRogue4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 203 - Rogue 4");
        spritePython1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 204 - Python 1");
        spritePython2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 205 - Python 2");
        spritePython3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 206 - Python 3");
        spritePython4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 012 Tile 207 - Python 4");
        spriteEttin1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 208 - Ettin 1");
        spriteEttin2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 209 - Ettin 2");
        spriteEttin3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 210 - Ettin 3");
        spriteEttin4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 211 - Ettin 4");
        spriteHeadless1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 212 - Headless 1");
        spriteHeadless2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 213 - Headless 2");
        spriteHeadless3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 214 - Headless 3");
        spriteHeadless4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 215 - Headless 4");
        spriteCyclops1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 216 - Cyclops 1");
        spriteCyclops2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 217 - Cyclops 2");
        spriteCyclops3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 218 - Cyclops 3");
        spriteCyclops4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 219 - Cyclops 4");
        spriteWisp1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 220 - Wisp 1");
        spriteWisp2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 221 - Wisp 2");
        spriteWisp3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 222 - Wisp 3");
        spriteWisp4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 013 Tile 223 - Wisp 4");
        spriteEvilMage1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 224 - Evil Mage 1");
        spriteEvilMage2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 225 - Evil Mage 2");
        spriteEvilMage3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 226 - Evil Mage 3");
        spriteEvilMage4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 227 - Evil Mage 4");
        spriteLich1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 228 - Lich 1");
        spriteLich2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 229 - Lich 2");
        spriteLich3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 230 - Lich 3");
        spriteLich4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 231 - Lich 4");
        spriteLavaLizard1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 232 - Lava Lizard 1");
        spriteLavaLizard2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 233 - Lava Lizard 2");
        spriteLavaLizard3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 234 - Lava Lizard 3");
        spriteLavaLizard4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 235 - Lava Lizard 4");
        spriteZorn1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 236 - Zorn 1");
        spriteZorn2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 237 - Zorn 2");
        spriteZorn3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 238 - Zorn 3");
        spriteZorn4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 014 Tile 239 - Zorn 4");
        spriteDaemon1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 240 - Daemon 1");
        spriteDaemon2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 241 - Daemon 2");
        spriteDaemon3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 242 - Daemon 3");
        spriteDaemon4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 243 - Daemon 4");
        spriteHydra1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 244 - Hydra 1");
        spriteHydra2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 245 - Hydra 2");
        spriteHydra3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 246 - Hydra 3");
        spriteHydra4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 247 - Hydra 4");
        spriteDragon1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 248 - Dragon 1");
        spriteDragon2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 249 - Dragon 2");
        spriteDragon3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 250 - Dragon 3");
        spriteDragon4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 251 - Dragon 4");
        spriteBalron1 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 252 - Balron 1");
        spriteBalron2 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 253 - Balron 2");
        spriteBalron3 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 254 - Balron 3");
        spriteBalron4 = Content.Load<Texture2D>("TileSets\\Ultima4\\U4 Tileset Row 015 Tile 255 - Balron 4");
    }

    private void LoadUltima4CombatMaps()
    {
        var loadedMap = LoadMap("Maps\\U4 Combat Map BRICK.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatBRICK = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map BRIDGE.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatBRIDGE = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map BRUSH.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatBRUSH = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map CAMP.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatCAMP = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map DNG0.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatDNG0 = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map DNG1.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatDNG1 = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map DNG2.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatDNG2 = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map DNG3.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatDNG3 = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map DNG4.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatDNG4 = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map DNG5.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatDNG5 = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map DNG6.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatDNG6 = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map DUNGEON.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatDUNGEON = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map FOREST.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatFOREST = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map GRASS.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatGRASS = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map HILL.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatHILL = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map INN.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatINN = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map MARSH.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatMARSH = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map SHIPSEA.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatSHIPSEA = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map SHIPSHIP.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatSHIPSHIP = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map SHIPSHOR.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatSHIPSHOR = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map SHORE.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatSHORE = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map SHORSHIP.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatSHORSHIP = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Combat Map SHRINE.txt", combatGridSize);
        if (loadedMap != null)
        {
            mapUltima4CombatSHRINE = loadedMap;
        }
    }

    private void LoadUltima4Maps()
    {
        var loadedMap = LoadMap("Maps\\U4 Overworld Map.txt", overworldGridSize);
        if (loadedMap != null)
        {
            mapUltima4Overworld = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Britain.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4Britain = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Buccaneers Den.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4BuccaneersDen = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Cove.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4Cove = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Empath Abbey.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4EmpathAbbey = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Jhelom.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4Jhelom = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Lord British Castle 1.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4LordBritishCastle1 = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Lord British Castle 2.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4LordBritishCastle2 = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Lycaeum.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4Lycaeum = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Magincia.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4Magincia = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Minoc.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4Minoc = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Moonglow.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4Moonglow = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Paws.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4Paws = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Serpent Isle.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4SerpentIsle = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Skara Brae.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4SkaraBrae = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Trinsic.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4Trinsic = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Vesper.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4Vesper = loadedMap;
        }

        loadedMap = LoadMap("Maps\\U4 Town Map Yew.txt", townGridSize);
        if (loadedMap != null)
        {
            mapUltima4Yew = loadedMap;
        }
    }

    private void LoadUltima4Textures()
    {
        _ultima4Background = Content.Load<Texture2D>("Backgrounds\\Ultima4\\Ultima4Background");
    }

    private void LoadUltima4Music()
    {
        _songUltima4Wanderer = Content.Load<Song>("Music\\Ultima4\\Ultima4C64Wanderer");
        _songUltima4Towne = Content.Load<Song>("Music\\Ultima4\\Ultima4C64Towne");
        _songUltima4Shrines = Content.Load<Song>("Music\\Ultima4\\Ultima4C64Shrines");
        _songUltima4Shopping = Content.Load<Song>("Music\\Ultima4\\Ultima4C64Shopping");
        _songUltima4RuleBritannia = Content.Load<Song>("Music\\Ultima4\\Ultima4C64RuleBritannia");
        _songUltima4LordBritishCastle = Content.Load<Song>("Music\\Ultima4\\Ultima4C64LordBritishCastle");
        _songUltima4FanfareOfLordBritish = Content.Load<Song>("Music\\Ultima4\\Ultima4C64FanfareOfLordBritish");
        _songUltima4Dungeons = Content.Load<Song>("Music\\Ultima4\\Ultima4C64Dungeons");
        _songUltima4Combat = Content.Load<Song>("Music\\Ultima4\\Ultima4C64Combat");
    }

    private void LoadUltima4SoundEffects()
    {
        _soundEffect_Walk = Content.Load<SoundEffect>("SoundEffects\\Ultima4\\SoundEffect_Walk");
        _soundEffect_BadCommand = Content.Load<SoundEffect>("SoundEffects\\Ultima4\\SoundEffect_BadCommand");
    }

    private int[,]? LoadMap(string sMapFileName, int iMapSize)
    {
        try
        {
            string[] lines = File.ReadAllLines(sMapFileName);

            if (lines.Length != iMapSize)
            {
                Console.WriteLine($"Error: The file does not contain exactly {iMapSize} rows.");
                return null;
            }

            int[,] tempMap = new int[iMapSize, iMapSize];

            for (int row = 0; row < iMapSize; row++)
            {
                string[] values = lines[row].Split(',');

                if (values.Length != iMapSize)
                {
                    Console.WriteLine($"Error: Row {row + 1} does not contain exactly {iMapSize} values.");
                    return null;
                }

                for (int col = 0; col < iMapSize; col++)
                {
                    if (int.TryParse(values[col], out int number))
                    {
                        tempMap[row, col] = number;
                    }
                    else
                    {
                        Console.WriteLine($"Error: Invalid integer at row {row + 1}, column {col + 1}.");
                        return null;
                    }
                }
            }

            Console.WriteLine("File successfully loaded into the grid.");
            return tempMap;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            return null;
        }
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        LoadUltima4TileSet();
        LoadUltima4Music();
        LoadUltima4SoundEffects();
        LoadUltima4Textures();
        LoadUltima4Maps();
        LoadUltima4CombatMaps();
        LoadUltima4CombatMapMonsterLocations();
        LoadUltima4CombatMapPartyLocations();
    }

    private void LoadUltima4CombatMapMonsterLocations()
    {
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapBRICK, "Combat\\Combat Starting Locations for Monsters BRICK.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapBRIDGE, "Combat\\Combat Starting Locations for Monsters BRIDGE.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapBRUSH, "Combat\\Combat Starting Locations for Monsters BRUSH.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapCAMP, "Combat\\Combat Starting Locations for Monsters CAMP.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapDNG0, "Combat\\Combat Starting Locations for Monsters DNG0.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapDNG1, "Combat\\Combat Starting Locations for Monsters DNG1.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapDNG2, "Combat\\Combat Starting Locations for Monsters DNG2.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapDNG3, "Combat\\Combat Starting Locations for Monsters DNG3.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapDNG4, "Combat\\Combat Starting Locations for Monsters DNG4.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapDNG5, "Combat\\Combat Starting Locations for Monsters DNG5.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapDNG6, "Combat\\Combat Starting Locations for Monsters DNG6.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapDUNGEON, "Combat\\Combat Starting Locations for Monsters DUNGEON.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapFOREST, "Combat\\Combat Starting Locations for Monsters FOREST.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapGRASS, "Combat\\Combat Starting Locations for Monsters GRASS.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapHILL, "Combat\\Combat Starting Locations for Monsters HILL.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapINN, "Combat\\Combat Starting Locations for Monsters INN.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapMARSH, "Combat\\Combat Starting Locations for Monsters MARSH.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapSHIPSEA, "Combat\\Combat Starting Locations for Monsters SHIPSEA.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapSHIPSHIP, "Combat\\Combat Starting Locations for Monsters SHIPSHIP.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapSHIPSHOR, "Combat\\Combat Starting Locations for Monsters SHIPSHOR.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapSHORE, "Combat\\Combat Starting Locations for Monsters SHORE.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapSHORSHIP, "Combat\\Combat Starting Locations for Monsters SHORSHIP.txt");
        monsterPositionManager.LoadFromFile(Maps.U4CombatMapSHRINE, "Combat\\Combat Starting Locations for Monsters SHRINE.txt");
    }

    private void LoadUltima4CombatMapPartyLocations()
    {
        partyPositionManager.LoadFromFile(Maps.U4CombatMapBRICK, "Combat\\Combat Starting Locations for Party BRICK.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapBRIDGE, "Combat\\Combat Starting Locations for Party BRIDGE.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapBRUSH, "Combat\\Combat Starting Locations for Party BRUSH.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapCAMP, "Combat\\Combat Starting Locations for Party CAMP.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapDNG0, "Combat\\Combat Starting Locations for Party DNG0.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapDNG1, "Combat\\Combat Starting Locations for Party DNG1.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapDNG2, "Combat\\Combat Starting Locations for Party DNG2.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapDNG3, "Combat\\Combat Starting Locations for Party DNG3.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapDNG4, "Combat\\Combat Starting Locations for Party DNG4.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapDNG5, "Combat\\Combat Starting Locations for Party DNG5.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapDNG6, "Combat\\Combat Starting Locations for Party DNG6.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapDUNGEON, "Combat\\Combat Starting Locations for Party DUNGEON.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapFOREST, "Combat\\Combat Starting Locations for Party FOREST.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapGRASS, "Combat\\Combat Starting Locations for Party GRASS.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapHILL, "Combat\\Combat Starting Locations for Party HILL.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapINN, "Combat\\Combat Starting Locations for Party INN.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapMARSH, "Combat\\Combat Starting Locations for Party MARSH.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapSHIPSEA, "Combat\\Combat Starting Locations for Party SHIPSEA.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapSHIPSHIP, "Combat\\Combat Starting Locations for Party SHIPSHIP.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapSHIPSHOR, "Combat\\Combat Starting Locations for Party SHIPSHOR.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapSHORE, "Combat\\Combat Starting Locations for Party SHORE.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapSHORSHIP, "Combat\\Combat Starting Locations for Party SHORSHIP.txt");
        partyPositionManager.LoadFromFile(Maps.U4CombatMapSHRINE, "Combat\\Combat Starting Locations for Party SHRINE.txt");
    }

    #endregion

    public int GetMainDisplayMapValue(int y, int x)
    {
        return mapMainDisplay[y, x];
    }

    public int GetCurrentMapValue(Maps map, int y, int x, int yy, int xx)
    {
        if (map == Maps.U4MapOverworld)
        {
            OverworldEntity entity = overworldEntityManager.GetEntityAt(y, x);
            if (entity == null)
            {
                //If there is no persisted entity, use the normal map value
                return mapUltima4Overworld[y, x];
            }
            else
            {
                //If there is a persisted entity, use its TileValue
                if (entity.IsVisible)
                {
                    return entity.TileValue;
                }
                else
                {
                    //If the entity is not visible, use the normal map value
                    return mapUltima4Overworld[y, x];
                }
            }
        }
        else if (map == Maps.U4MapBritain)
            return mapUltima4Britain[yy, xx];
        else if (map == Maps.U4MapBuccaneersDen)
            return mapUltima4BuccaneersDen[yy, xx];
        else if (map == Maps.U4MapCove)
            return mapUltima4Cove[yy, xx];
        else if (map == Maps.U4MapEmpathAbbey)
            return mapUltima4EmpathAbbey[yy, xx];
        else if (map == Maps.U4MapJhelom)
            return mapUltima4Jhelom[yy, xx];
        else if (map == Maps.U4MapLordBritishCastle1)
            return mapUltima4LordBritishCastle1[yy, xx];
        else if (map == Maps.U4MapLordBritishCastle2)
            return mapUltima4LordBritishCastle2[yy, xx];
        else if (map == Maps.U4MapLycaeum)
            return mapUltima4Lycaeum[yy, xx];
        else if (map == Maps.U4MapMagincia)
            return mapUltima4Magincia[yy, xx];
        else if (map == Maps.U4MapMinoc)
            return mapUltima4Minoc[yy, xx];
        else if (map == Maps.U4MapMoonglow)
            return mapUltima4Moonglow[yy, xx];
        else if (map == Maps.U4MapPaws)
            return mapUltima4Paws[yy, xx];
        else if (map == Maps.U4MapSerpentIsle)
            return mapUltima4SerpentIsle[yy, xx];
        else if (map == Maps.U4MapSkaraBrae)
            return mapUltima4SkaraBrae[yy, xx];
        else if (map == Maps.U4MapTrinsic)
            return mapUltima4Trinsic[yy, xx];
        else if (map == Maps.U4MapVesper)
            return mapUltima4Vesper[yy, xx];
        else if (map == Maps.U4MapYew)
            return mapUltima4Yew[yy, xx];
        else if (map == Maps.U4CombatMapBRICK)
            return mapUltima4CombatBRICK[yy, xx];
        else if (map == Maps.U4CombatMapBRIDGE)
            return mapUltima4CombatBRIDGE[yy, xx];
        else if (map == Maps.U4CombatMapBRUSH)
            return mapUltima4CombatBRUSH[yy, xx];
        else if (map == Maps.U4CombatMapCAMP)
            return mapUltima4CombatCAMP[yy, xx];
        else if (map == Maps.U4CombatMapDNG0)
            return mapUltima4CombatDNG0[yy, xx];
        else if (map == Maps.U4CombatMapDNG1)
            return mapUltima4CombatDNG1[yy, xx];
        else if (map == Maps.U4CombatMapDNG2)
            return mapUltima4CombatDNG2[yy, xx];
        else if (map == Maps.U4CombatMapDNG3)
            return mapUltima4CombatDNG3[yy, xx];
        else if (map == Maps.U4CombatMapDNG4)
            return mapUltima4CombatDNG4[yy, xx];
        else if (map == Maps.U4CombatMapDNG5)
            return mapUltima4CombatDNG5[yy, xx];
        else if (map == Maps.U4CombatMapDNG6)
            return mapUltima4CombatDNG6[yy, xx];
        else if (map == Maps.U4CombatMapDUNGEON)
            return mapUltima4CombatDUNGEON[yy, xx];
        else if (map == Maps.U4CombatMapFOREST)
            return mapUltima4CombatFOREST[yy, xx];
        else if (map == Maps.U4CombatMapGRASS)
            return mapUltima4CombatGRASS[yy, xx];
        else if (map == Maps.U4CombatMapHILL)
            return mapUltima4CombatHILL[yy, xx];
        else if (map == Maps.U4CombatMapINN)
            return mapUltima4CombatINN[yy, xx];
        else if (map == Maps.U4CombatMapMARSH)
            return mapUltima4CombatMARSH[yy, xx];
        else if (map == Maps.U4CombatMapSHIPSEA)
            return mapUltima4CombatSHIPSEA[yy, xx];
        else if (map == Maps.U4CombatMapSHIPSHIP)
            return mapUltima4CombatSHIPSHIP[yy, xx];
        else if (map == Maps.U4CombatMapSHIPSHOR)
            return mapUltima4CombatSHIPSHOR[yy, xx];
        else if (map == Maps.U4CombatMapSHORE)
            return mapUltima4CombatSHORE[yy, xx];
        else if (map == Maps.U4CombatMapSHORSHIP)
            return mapUltima4CombatSHORSHIP[yy, xx];
        else if (map == Maps.U4CombatMapSHRINE)
            return mapUltima4CombatSHRINE[yy, xx];
        else
                                                                                                                                                                                                { 
            return (int)TileType.Blank;
        }
    }

    private Texture2D GetSpriteForMapValue(int mapValue)
    {
        switch (mapValue)
        {
            case 1: return spriteDeepWater;
            case 2: return spriteMediumWater;
            case 3: return spriteShallowWater;
            case 4: return spriteSwamp;
            case 5: return spriteGrasslands;
            case 6: return spriteScrubland;
            case 7: return spriteForest;
            case 8: return spriteHills;
            case 9: return spriteMountains;
            case 10: return spriteDungeonEntrance;
            case 11: return spriteTown;
            case 12: return spriteCastle;
            case 13: return spriteVillage;
            case 14: return spriteLordBritishCastleWest;
            case 15: return spriteLordBritishCastleEntrance;
            case 16: return spriteLordBritishCastleEast;
            case 17: return spriteShipWest;
            case 18: return spriteShipNorth;
            case 19: return spriteShipEast;
            case 20: return spriteShipSouth;
            case 21: return spriteHorseWest;
            case 22: return spriteHorseEast;
            case 23: return spriteTileFloor;
            case 24: return spriteBridge;
            case 25: return spriteBalloon;
            case 26: return spriteBridgeNorth;
            case 27: return spriteBridgeSouth;
            case 28: return spriteLadderUp;
            case 29: return spriteLadderDown;
            case 30: return spriteRuins;
            case 31: return spriteShrine;
            case 32: return spriteAvatar;
            case 33: return spriteMage1;
            case 34: return spriteMage2;
            case 35: return spriteBard1;
            case 36: return spriteBard2;
            case 37: return spriteFighter1;
            case 38: return spriteFighter2;
            case 39: return spriteDuid1;
            case 40: return spriteDruid2;
            case 41: return spriteTinker1;
            case 42: return spriteTinker2;
            case 43: return spritePaladin1;
            case 44: return spritePaladin2;
            case 45: return spriteRanger1;
            case 46: return spriteRanger2;
            case 47: return spriteShepherd1;
            case 48: return spriteShepherd2;
            case 49: return spriteColumn;
            case 50: return spriteWhiteSW;
            case 51: return spriteWhiteSE;
            case 52: return spriteWhiteNW;
            case 53: return spriteNE;
            case 54: return spriteMast;
            case 55: return spriteShipsWheel;
            case 56: return spriteRocks;
            case 57: return spriteLyinDown;
            case 58: return spriteStoneWall;
            case 59: return spriteLockedDoor;
            case 60: return spriteUnlockedDoor;
            case 61: return spriteChest;
            case 62: return spriteAnkh;
            case 63: return spriteBrickFloor;
            case 64: return spriteWoodenPlanks;
            case 65: return spriteMoongate1;
            case 66: return spriteMoongate2;
            case 67: return spriteMoongate3;
            case 68: return spriteMoongate4;
            case 69: return spritePoisonField;
            case 70: return spriteEnergyField;
            case 71: return spriteFireField;
            case 72: return spriteSleepField;
            case 73: return spriteSolidBarrier;
            case 74: return spriteHiddenPassage;
            case 75: return spriteAltar;
            case 76: return spriteSpit;
            case 77: return spriteLavaFlow;
            case 78: return spriteMissile;
            case 79: return spriteMagicSphere;
            case 80: return spriteAttackFlash;
            case 81: return spriteGuard1;
            case 82: return spriteGuard2;
            case 83: return spriteCitizen1;
            case 84: return spriteCitizen2;
            case 85: return spriteSingingBard1;
            case 86: return spriteSingingBard2;
            case 87: return spriteJester1;
            case 88: return spriteJester2;
            case 89: return spriteBeggar1;
            case 90: return spriteBeggar2;
            case 91: return spriteChild1;
            case 92: return spriteChild2;
            case 93: return spriteBull1;
            case 94: return spriteBull2;
            case 95: return spriteLordBritish1;
            case 96: return spriteLordBritish2;
            case 97: return spriteA;
            case 98: return spriteB;
            case 99: return spriteC;
            case 100: return spriteD;
            case 101: return spriteE;
            case 102: return spriteF;
            case 103: return spriteG;
            case 104: return spriteH;
            case 105: return spriteI;
            case 106: return spriteJ;
            case 107: return spriteK;
            case 108: return spriteL;
            case 109: return spriteM;
            case 110: return spriteN;
            case 111: return spriteO;
            case 112: return spriteP;
            case 113: return spriteQ;
            case 114: return spriteR;
            case 115: return spriteS;
            case 116: return spriteT;
            case 117: return spriteU;
            case 118: return spriteV;
            case 119: return spriteW;
            case 120: return spriteX;
            case 121: return spriteY;
            case 122: return spriteZ;
            case 123: return spriteSpace;
            case 124: return spriteRight;
            case 125: return spriteLeft;
            case 126: return spriteWindow;
            case 127: return spriteBlank;
            case 128: return spriteBrickWall;
            case 129: return spritePirateShipWest;
            case 130: return spritePirateShipNorth;
            case 131: return spritePirateShipEast;
            case 132: return spritePirateShipSouth;
            case 133: return spriteNixie1;
            case 134: return spriteNixie2;
            case 135: return spriteGiantSquid1;
            case 136: return spriteGiantSquid2;
            case 137: return spriteSeaSerpent1;
            case 138: return spriteSeaSerpent2;
            case 139: return spriteSeahorse1;
            case 140: return spriteSeahorse2;
            case 141: return spriteWhirlpool1;
            case 142: return spriteWhirlpool2;
            case 143: return spriteStorm1;
            case 144: return spriteStorm2;
            case 145: return spriteRat1;
            case 146: return spriteRat2;
            case 147: return spriteRat3;
            case 148: return spriteRat4;
            case 149: return spriteBat1;
            case 150: return spriteBat2;
            case 151: return spriteBat3;
            case 152: return spriteBat4;
            case 153: return spriteGiantSpider1;
            case 154: return spriteGiantSpider2;
            case 155: return spriteGiantSpider3;
            case 156: return spriteGiantSpider4;
            case 157: return spriteGhost1;
            case 158: return spriteGhost2;
            case 159: return spriteGhost3;
            case 160: return spriteGhost4;
            case 161: return spriteSlime1;
            case 162: return spriteSlime2;
            case 163: return spriteSlime3;
            case 164: return spriteSlime4;
            case 165: return spriteTroll1;
            case 166: return spriteTroll2;
            case 167: return spriteTroll3;
            case 168: return spriteTroll4;
            case 169: return spriteGremlin1;
            case 170: return spriteGremlin2;
            case 171: return spriteGremlin3;
            case 172: return spriteGremlin4;
            case 173: return spriteMimic1;
            case 174: return spriteMimic2;
            case 175: return spriteMimic3;
            case 176: return spriteMimic4;
            case 177: return spriteReaper1;
            case 178: return spriteReaper2;
            case 179: return spriteReaper3;
            case 180: return spriteReaper4;
            case 181: return spriteInsectSwarm1;
            case 182: return spriteInsectSwarm2;
            case 183: return spriteInsectSwarm3;
            case 184: return spriteInsectSwarm4;
            case 185: return spriteGazer1;
            case 186: return spriteGazer2;
            case 187: return spriteGazer3;
            case 188: return spriteGazer4;
            case 189: return spritePhantom1;
            case 190: return spritePhantom2;
            case 191: return spritePhantom3;
            case 192: return spritePhantom4;
            case 193: return spriteOrc1;
            case 194: return spriteOrc2;
            case 195: return spriteOrc3;
            case 196: return spriteOrc4;
            case 197: return spriteSkeleton1;
            case 198: return spriteSkeleton2;
            case 199: return spriteSkeleton3;
            case 200: return spriteSkeleton4;
            case 201: return spriteRogue1;
            case 202: return spriteRogue2;
            case 203: return spriteRogue3;
            case 204: return spriteRogue4;
            case 205: return spritePython1;
            case 206: return spritePython2;
            case 207: return spritePython3;
            case 208: return spritePython4;
            case 209: return spriteEttin1;
            case 210: return spriteEttin2;
            case 211: return spriteEttin3;
            case 212: return spriteEttin4;
            case 213: return spriteHeadless1;
            case 214: return spriteHeadless2;
            case 215: return spriteHeadless3;
            case 216: return spriteHeadless4;
            case 217: return spriteCyclops1;
            case 218: return spriteCyclops2;
            case 219: return spriteCyclops3;
            case 220: return spriteCyclops4;
            case 221: return spriteWisp1;
            case 222: return spriteWisp2;
            case 223: return spriteWisp3;
            case 224: return spriteWisp4;
            case 225: return spriteEvilMage1;
            case 226: return spriteEvilMage2;
            case 227: return spriteEvilMage3;
            case 228: return spriteEvilMage4;
            case 229: return spriteLich1;
            case 230: return spriteLich2;
            case 231: return spriteLich3;
            case 232: return spriteLich4;
            case 233: return spriteLavaLizard1;
            case 234: return spriteLavaLizard2;
            case 235: return spriteLavaLizard3;
            case 236: return spriteLavaLizard4;
            case 237: return spriteZorn1;
            case 238: return spriteZorn2;
            case 239: return spriteZorn3;
            case 240: return spriteZorn4;
            case 241: return spriteDaemon1;
            case 242: return spriteDaemon2;
            case 243: return spriteDaemon3;
            case 244: return spriteDaemon4;
            case 245: return spriteHydra1;
            case 246: return spriteHydra2;
            case 247: return spriteHydra3;
            case 248: return spriteHydra4;
            case 249: return spriteDragon1;
            case 250: return spriteDragon2;
            case 251: return spriteDragon3;
            case 252: return spriteDragon4;
            case 253: return spriteBalron1;
            case 254: return spriteBalron2;
            case 255: return spriteBalron3;
            case 256: return spriteBalron4;
            default:
                {
                    return spriteBlank;
                }
        }
    }

    bool IsEnterableTerrain(int mapValue)
    {
        if (mapValue == (int)TileType.Balloon ||
            mapValue == (int)TileType.Castle ||
            mapValue == (int)TileType.DungeonEntrance ||
            mapValue == (int)TileType.HiddenPassage ||
            mapValue == (int)TileType.HorseEast ||
            mapValue == (int)TileType.HorseWest ||
            mapValue == (int)TileType.LordBritishCastleEntrance ||
            mapValue == (int)TileType.PirateShipNorth ||
            mapValue == (int)TileType.PirateShipSouth ||
            mapValue == (int)TileType.PirateShipEast ||
            mapValue == (int)TileType.PirateShipWest ||
            mapValue == (int)TileType.Ruins ||
            mapValue == (int)TileType.Shrine ||
            mapValue == (int)TileType.Village ||
            mapValue == (int)TileType.Town ||
            mapValue == (int)TileType.ShipNorth ||
            mapValue == (int)TileType.ShipSouth ||
            mapValue == (int)TileType.ShipEast ||
            mapValue == (int)TileType.ShipWest
            )
        {
            return true;
        }

        return false;
    }

    bool IsPassableTerrain(int mapValue)
    {
        if (!bDetectCollision) return true;

        if (_currentVehicle == Vehicle.Balloon) { return true; }

        if (_currentVehicle == Vehicle.Ship)
        {
            if (mapValue == (int)TileType.DeepWater || mapValue == (int)TileType.MediumWater)
            {
                return true; 
            }
            else
            { 
                return false;
            }
        }

        if (mapValue == (int)TileType.DeepWater ||
            mapValue == (int)TileType.MediumWater ||
            mapValue == (int)TileType.ShallowWater ||
            mapValue == (int)TileType.Mountains ||
            mapValue == (int)TileType.LordBritishCastleEast ||
            mapValue == (int)TileType.LordBritishCastleWest ||
            mapValue == (int)TileType.Mage1 ||
            mapValue == (int)TileType.Mage2 ||
            mapValue == (int)TileType.Bard1 ||
            mapValue == (int)TileType.Bard2 ||
            mapValue == (int)TileType.Fighter1 ||
            mapValue == (int)TileType.Fighter2 ||
            mapValue == (int)TileType.Druid1 ||
            mapValue == (int)TileType.Druid2 ||
            mapValue == (int)TileType.Tinker1 ||
            mapValue == (int)TileType.Tinker2 ||
            mapValue == (int)TileType.Paladin1 ||
            mapValue == (int)TileType.Paladin2 ||
            mapValue == (int)TileType.Ranger1 ||
            mapValue == (int)TileType.Ranger2 ||
            mapValue == (int)TileType.Shepherd1 ||
            mapValue == (int)TileType.Shepherd2 ||
            mapValue == (int)TileType.Column ||
            mapValue == (int)TileType.WhiteSW ||
            mapValue == (int)TileType.WhiteSE ||
            mapValue == (int)TileType.WhiteNW ||
            mapValue == (int)TileType.NE ||
            mapValue == (int)TileType.Mast ||
            mapValue == (int)TileType.ShipsWheel ||
            mapValue == (int)TileType.Rocks ||
            mapValue == (int)TileType.LyinDown ||
            mapValue == (int)TileType.StoneWall ||
            mapValue == (int)TileType.LockedDoor ||
            mapValue == (int)TileType.SolidBarrier ||
            mapValue == (int)TileType.Altar ||
            mapValue == (int)TileType.Spit ||
            mapValue == (int)TileType.Guard1 ||
            mapValue == (int)TileType.Guard2 ||
            mapValue == (int)TileType.Citizen1 ||
            mapValue == (int)TileType.Citizen2 ||
            mapValue == (int)TileType.SingingBard1 ||
            mapValue == (int)TileType.SingingBard2 ||
            mapValue == (int)TileType.Jester1 ||
            mapValue == (int)TileType.Jester2 ||
            mapValue == (int)TileType.Beggar1 ||
            mapValue == (int)TileType.Beggar2 ||
            mapValue == (int)TileType.Child1 ||
            mapValue == (int)TileType.Child2 ||
            mapValue == (int)TileType.Bull1 ||
            mapValue == (int)TileType.Bull2 ||
            mapValue == (int)TileType.LordBritish1 ||
            mapValue == (int)TileType.LordBritish2 ||
            mapValue == (int)TileType.A ||
            mapValue == (int)TileType.B ||
            mapValue == (int)TileType.C ||
            mapValue == (int)TileType.D ||
            mapValue == (int)TileType.E ||
            mapValue == (int)TileType.F ||
            mapValue == (int)TileType.G ||
            mapValue == (int)TileType.H ||
            mapValue == (int)TileType.I ||
            mapValue == (int)TileType.J ||
            mapValue == (int)TileType.K ||
            mapValue == (int)TileType.L ||
            mapValue == (int)TileType.M ||
            mapValue == (int)TileType.N ||
            mapValue == (int)TileType.O ||
            mapValue == (int)TileType.P ||
            mapValue == (int)TileType.Q ||
            mapValue == (int)TileType.R ||
            mapValue == (int)TileType.S ||
            mapValue == (int)TileType.T ||
            mapValue == (int)TileType.U ||
            mapValue == (int)TileType.V ||
            mapValue == (int)TileType.W ||
            mapValue == (int)TileType.X ||
            mapValue == (int)TileType.Y ||
            mapValue == (int)TileType.Z ||
            mapValue == (int)TileType.Space ||
            mapValue == (int)TileType.Right ||
            mapValue == (int)TileType.Left ||
            mapValue == (int)TileType.Window ||
            mapValue == (int)TileType.Blank ||
            mapValue == (int)TileType.BrickWall ||
            mapValue == (int)TileType.Nixie1 ||
            mapValue == (int)TileType.Nixie2 ||
            mapValue == (int)TileType.GiantSquid1 ||
            mapValue == (int)TileType.GiantSquid2 ||
            mapValue == (int)TileType.SeaSerpent1 ||
            mapValue == (int)TileType.SeaSerpent2 ||
            mapValue == (int)TileType.Seahorse1 ||
            mapValue == (int)TileType.Seahorse2 ||
            mapValue == (int)TileType.Whirlpool1 ||
            mapValue == (int)TileType.Whirlpool2 ||
            mapValue == (int)TileType.Storm1 ||
            mapValue == (int)TileType.Storm2 ||
            mapValue == (int)TileType.Rat1 ||
            mapValue == (int)TileType.Rat2 ||
            mapValue == (int)TileType.Rat3 ||
            mapValue == (int)TileType.Rat4 ||
            mapValue == (int)TileType.Bat1 ||
            mapValue == (int)TileType.Bat2 ||
            mapValue == (int)TileType.Bat3 ||
            mapValue == (int)TileType.Bat4 ||
            mapValue == (int)TileType.GiantSpider1 ||
            mapValue == (int)TileType.GiantSpider2 ||
            mapValue == (int)TileType.GiantSpider3 ||
            mapValue == (int)TileType.GiantSpider4 ||
            mapValue == (int)TileType.Ghost1 ||
            mapValue == (int)TileType.Ghost2 ||
            mapValue == (int)TileType.Ghost3 ||
            mapValue == (int)TileType.Ghost4 ||
            mapValue == (int)TileType.Slime1 ||
            mapValue == (int)TileType.Slime2 ||
            mapValue == (int)TileType.Slime3 ||
            mapValue == (int)TileType.Slime4 ||
            mapValue == (int)TileType.Troll1 ||
            mapValue == (int)TileType.Troll2 ||
            mapValue == (int)TileType.Troll3 ||
            mapValue == (int)TileType.Troll4 ||
            mapValue == (int)TileType.Gremlin1 ||
            mapValue == (int)TileType.Gremlin2 ||
            mapValue == (int)TileType.Gremlin3 ||
            mapValue == (int)TileType.Gremlin4 ||
            mapValue == (int)TileType.Mimic1 ||
            mapValue == (int)TileType.Mimic2 ||
            mapValue == (int)TileType.Mimic3 ||
            mapValue == (int)TileType.Mimic4 ||
            mapValue == (int)TileType.Reaper1 ||
            mapValue == (int)TileType.Reaper2 ||
            mapValue == (int)TileType.Reaper3 ||
            mapValue == (int)TileType.Reaper4 ||
            mapValue == (int)TileType.InsectSwarm1 ||
            mapValue == (int)TileType.InsectSwarm2 ||
            mapValue == (int)TileType.InsectSwarm3 ||
            mapValue == (int)TileType.InsectSwarm4 ||
            mapValue == (int)TileType.Gazer1 ||
            mapValue == (int)TileType.Gazer2 ||
            mapValue == (int)TileType.Gazer3 ||
            mapValue == (int)TileType.Gazer4 ||
            mapValue == (int)TileType.Phantom1 ||
            mapValue == (int)TileType.Phantom2 ||
            mapValue == (int)TileType.Phantom3 ||
            mapValue == (int)TileType.Phantom4 ||
            mapValue == (int)TileType.Orc1 ||
            mapValue == (int)TileType.Orc2 ||
            mapValue == (int)TileType.Orc3 ||
            mapValue == (int)TileType.Orc4 ||
            mapValue == (int)TileType.Skeleton1 ||
            mapValue == (int)TileType.Skeleton2 ||
            mapValue == (int)TileType.Skeleton3 ||
            mapValue == (int)TileType.Skeleton4 ||
            mapValue == (int)TileType.Rogue1 ||
            mapValue == (int)TileType.Rogue2 ||
            mapValue == (int)TileType.Rogue3 ||
            mapValue == (int)TileType.Rogue4 ||
            mapValue == (int)TileType.Python1 ||
            mapValue == (int)TileType.Python2 ||
            mapValue == (int)TileType.Python3 ||
            mapValue == (int)TileType.Python4 ||
            mapValue == (int)TileType.Ettin1 ||
            mapValue == (int)TileType.Ettin2 ||
            mapValue == (int)TileType.Ettin3 ||
            mapValue == (int)TileType.Ettin4 ||
            mapValue == (int)TileType.Headless1 ||
            mapValue == (int)TileType.Headless2 ||
            mapValue == (int)TileType.Headless3 ||
            mapValue == (int)TileType.Headless4 ||
            mapValue == (int)TileType.Cyclops1 ||
            mapValue == (int)TileType.Cyclops2 ||
            mapValue == (int)TileType.Cyclops3 ||
            mapValue == (int)TileType.Cyclops4 ||
            mapValue == (int)TileType.Wisp1 ||
            mapValue == (int)TileType.Wisp2 ||
            mapValue == (int)TileType.Wisp3 ||
            mapValue == (int)TileType.Wisp4 ||
            mapValue == (int)TileType.EvilMage1 ||
            mapValue == (int)TileType.EvilMage2 ||
            mapValue == (int)TileType.EvilMage3 ||
            mapValue == (int)TileType.EvilMage4 ||
            mapValue == (int)TileType.Lich1 ||
            mapValue == (int)TileType.Lich2 ||
            mapValue == (int)TileType.Lich3 ||
            mapValue == (int)TileType.Lich4 ||
            mapValue == (int)TileType.LavaLizard1 ||
            mapValue == (int)TileType.LavaLizard2 ||
            mapValue == (int)TileType.LavaLizard3 ||
            mapValue == (int)TileType.LavaLizard4 ||
            mapValue == (int)TileType.Zorn1 ||
            mapValue == (int)TileType.Zorn2 ||
            mapValue == (int)TileType.Zorn3 ||
            mapValue == (int)TileType.Zorn4 ||
            mapValue == (int)TileType.Daemon1 ||
            mapValue == (int)TileType.Daemon2 ||
            mapValue == (int)TileType.Daemon3 ||
            mapValue == (int)TileType.Daemon4 ||
            mapValue == (int)TileType.Hydra1 ||
            mapValue == (int)TileType.Hydra2 ||
            mapValue == (int)TileType.Hydra3 ||
            mapValue == (int)TileType.Hydra4 ||
            mapValue == (int)TileType.Dragon1 ||
            mapValue == (int)TileType.Dragon2 ||
            mapValue == (int)TileType.Dragon3 ||
            mapValue == (int)TileType.Dragon4 ||
            mapValue == (int)TileType.Balron1 ||
            mapValue == (int)TileType.Balron2 ||
            mapValue == (int)TileType.Balron3 ||
            mapValue == (int)TileType.Balron4)
        {
            return false;
        }

        return true;
    }

    public void MovePlayer(Maps map, MoveDirection direction)
    {
        if (map == Maps.U4MapOverworld)
        {
            //Need to wrap around the overworld grid if the pc moves off the edge of the map
            switch (direction)
            {
                case MoveDirection.North:
                    pcOverworldLocationY = (pcOverworldLocationY - 1 + overworldGridSize) % overworldGridSize;
                    break;
                case MoveDirection.South:
                    pcOverworldLocationY = (pcOverworldLocationY + 1) % overworldGridSize;
                    break;
                case MoveDirection.West:
                    pcOverworldLocationX = (pcOverworldLocationX - 1 + overworldGridSize) % overworldGridSize;
                    break;
                case MoveDirection.East:
                    pcOverworldLocationX = (pcOverworldLocationX + 1) % overworldGridSize;
                    break;
            }
        }
        else if (map == Maps.U4MapBritain ||
            map == Maps.U4MapBuccaneersDen || map == Maps.U4MapCove ||
            map == Maps.U4MapEmpathAbbey || map == Maps.U4MapJhelom ||
            map == Maps.U4MapLordBritishCastle1 || map == Maps.U4MapLordBritishCastle2 ||
            map == Maps.U4MapLycaeum || map == Maps.U4MapMagincia ||
            map == Maps.U4MapMinoc || map == Maps.U4MapMoonglow ||
            map == Maps.U4MapPaws || map == Maps.U4MapSerpentIsle ||
            map == Maps.U4MapSkaraBrae || map == Maps.U4MapTrinsic ||
            map == Maps.U4MapVesper || map == Maps.U4MapYew)
        {
            //No need to wrap around the grid if the pc moves off the edge of the map
            switch (direction)
            {
                case MoveDirection.North:
                    if (pcTownMapLocationY > 0)
                    {
                        pcTownMapLocationY--;
                    }
                    break;
                case MoveDirection.South:
                    if (pcTownMapLocationY < townGridSize - 1)
                    {
                        pcTownMapLocationY++;
                    }
                    break;
                case MoveDirection.West:
                    if (pcTownMapLocationX > 0)
                    {
                        pcTownMapLocationX--;
                    }
                    break;
                case MoveDirection.East:
                    if (pcTownMapLocationX < townGridSize - 1)
                    {
                        pcTownMapLocationX++;
                    }
                    break;
            }
        }
        else if (map == Maps.U4CombatMapBRICK || map == Maps.U4CombatMapBRIDGE ||
            map == Maps.U4CombatMapBRUSH || map == Maps.U4CombatMapCAMP ||
            map == Maps.U4CombatMapDNG0 || map == Maps.U4CombatMapDNG1 ||
            map == Maps.U4CombatMapDNG2 || map == Maps.U4CombatMapDNG3 ||
            map == Maps.U4CombatMapDNG4 || map == Maps.U4CombatMapDNG5 ||
            map == Maps.U4CombatMapDNG6 || map == Maps.U4CombatMapDUNGEON ||
            map == Maps.U4CombatMapFOREST || map == Maps.U4CombatMapGRASS ||
            map == Maps.U4CombatMapHILL || map == Maps.U4CombatMapINN ||
            map == Maps.U4CombatMapMARSH || map == Maps.U4CombatMapSHIPSEA ||
            map == Maps.U4CombatMapSHIPSHIP || map == Maps.U4CombatMapSHIPSHOR ||
            map == Maps.U4CombatMapSHORE || map == Maps.U4CombatMapSHORSHIP ||
            map == Maps.U4CombatMapSHRINE)
        {
            ////No need to wrap around the grid if the pc moves off the edge of the map
            //switch (direction)
            //{
            //    case MoveDirection.North:
            //        if (pcTownMapLocationY > 0)
            //        {
            //            pcTownMapLocationY--;
            //        }
            //        break;
            //    case MoveDirection.South:
            //        if (pcTownMapLocationY < townGridSize - 1)
            //        {
            //            pcTownMapLocationY++;
            //        }
            //        break;
            //    case MoveDirection.West:
            //        if (pcTownMapLocationX > 0)
            //        {
            //            pcTownMapLocationX--;
            //        }
            //        break;
            //    case MoveDirection.East:
            //        if (pcTownMapLocationX < townGridSize - 1)
            //        {
            //            pcTownMapLocationX++;
            //        }
            //        break;
            //}
        }

    }

    #region Update Main Display Grid Values

    public void UpdateMainDisplayGridValues(Maps map)
    {
        if (map == Maps.U4MapOverworld)
        {
            UpdateOverworldGrid();
        }
        else if (IsTownMap(map))
        {
            UpdateTownGrid(GetTownMap(map));
        }
        else if (IsCombatMap(map))
        {
            UpdateCombatGrid(GetCombatMapGrid(map));
        }
    }

    private void UpdateOverworldGrid()
    {
        int halfDisplay = mainDisplayGridSize / 2;

        for (int y = 0; y < mainDisplayGridSize; y++)
        {
            for (int x = 0; x < mainDisplayGridSize; x++)
            {
                int worldX = (pcOverworldLocationX - halfDisplay + x + overworldGridSize) % overworldGridSize;
                int worldY = (pcOverworldLocationY - halfDisplay + y + overworldGridSize) % overworldGridSize;

                OverworldEntity entity = overworldEntityManager.GetEntityAt(worldY, worldX);
                if (entity == null || !entity.IsVisible)
                {
                    mapMainDisplay[y, x] = mapUltima4Overworld[worldY, worldX];
                }
                else
                {
                    mapMainDisplay[y, x] = entity.TileValue;
                }
            }
        }
    }

    private void UpdateTownGrid(int[,] townMap)
    {
        for (int y = 0; y < mainDisplayGridSize; y++)
        {
            for (int x = 0; x < mainDisplayGridSize; x++)
            {
                int townX = pcTownMapLocationX - mainDisplayCenter + x;
                int townY = pcTownMapLocationY - mainDisplayCenter + y;

                if (IsWithinBounds(townX, townY, townGridSize))
                {
                    mapMainDisplay[y, x] = townMap[townY, townX];
                }
                else
                {
                    mapMainDisplay[y, x] = (int)TileType.Blank;
                }
            }
        }
    }

    private void UpdateCombatGrid(int[,] combatMap)
    {
        for (int y = 0; y < mainDisplayGridSize; y++)
        {
            for (int x = 0; x < mainDisplayGridSize; x++)
            {
                int combatX = 5 - mainDisplayCenter + x;
                int combatY = 5 - mainDisplayCenter + y;

                if (IsWithinBounds(combatX, combatY, combatGridSize))
                {
                    mapMainDisplay[y, x] = combatMap[combatY, combatX];
                }
                else
                {
                    mapMainDisplay[y, x] = (int)TileType.Blank;
                }
            }
        }
    }

    private bool IsWithinBounds(int x, int y, int gridSize)
    {
        return x >= 0 && x < gridSize && y >= 0 && y < gridSize;
    }

    private bool IsTownMap(Maps map)
    {
        return map >= Maps.U4MapBritain && map <= Maps.U4MapYew;
    }

    private bool IsCombatMap(Maps map)
    {
        return map >= Maps.U4CombatMapBRICK && map <= Maps.U4CombatMapSHRINE;
    }

    private int[,] GetTownMap(Maps map)
    {
        return map switch
        {
            Maps.U4MapBritain => mapUltima4Britain,
            Maps.U4MapBuccaneersDen => mapUltima4BuccaneersDen,
            Maps.U4MapCove => mapUltima4Cove,
            Maps.U4MapEmpathAbbey => mapUltima4EmpathAbbey,
            Maps.U4MapJhelom => mapUltima4Jhelom,
            Maps.U4MapLordBritishCastle1 => mapUltima4LordBritishCastle1,
            Maps.U4MapLordBritishCastle2 => mapUltima4LordBritishCastle2,
            Maps.U4MapLycaeum => mapUltima4Lycaeum,
            Maps.U4MapMagincia => mapUltima4Magincia,
            Maps.U4MapMinoc => mapUltima4Minoc,
            Maps.U4MapMoonglow => mapUltima4Moonglow,
            Maps.U4MapPaws => mapUltima4Paws,
            Maps.U4MapSerpentIsle => mapUltima4SerpentIsle,
            Maps.U4MapSkaraBrae => mapUltima4SkaraBrae,
            Maps.U4MapTrinsic => mapUltima4Trinsic,
            Maps.U4MapVesper => mapUltima4Vesper,
            Maps.U4MapYew => mapUltima4Yew,
            _ => throw new ArgumentException("Invalid town map")
        };
    }

    private int[,] GetCombatMapGrid(Maps map)
    {
        return map switch
        {
            Maps.U4CombatMapBRICK => mapUltima4CombatBRICK,
            Maps.U4CombatMapBRIDGE => mapUltima4CombatBRIDGE,
            Maps.U4CombatMapBRUSH => mapUltima4CombatBRUSH,
            Maps.U4CombatMapCAMP => mapUltima4CombatCAMP,
            Maps.U4CombatMapDNG0 => mapUltima4CombatDNG0,
            Maps.U4CombatMapDNG1 => mapUltima4CombatDNG1,
            Maps.U4CombatMapDNG2 => mapUltima4CombatDNG2,
            Maps.U4CombatMapDNG3 => mapUltima4CombatDNG3,
            Maps.U4CombatMapDNG4 => mapUltima4CombatDNG4,
            Maps.U4CombatMapDNG5 => mapUltima4CombatDNG5,
            Maps.U4CombatMapDNG6 => mapUltima4CombatDNG6,
            Maps.U4CombatMapDUNGEON => mapUltima4CombatDUNGEON,
            Maps.U4CombatMapFOREST => mapUltima4CombatFOREST,
            Maps.U4CombatMapGRASS => mapUltima4CombatGRASS,
            Maps.U4CombatMapHILL => mapUltima4CombatHILL,
            Maps.U4CombatMapINN => mapUltima4CombatINN,
            Maps.U4CombatMapMARSH => mapUltima4CombatMARSH,
            Maps.U4CombatMapSHIPSEA => mapUltima4CombatSHIPSEA,
            Maps.U4CombatMapSHIPSHIP => mapUltima4CombatSHIPSHIP,
            Maps.U4CombatMapSHIPSHOR => mapUltima4CombatSHIPSHOR,
            Maps.U4CombatMapSHORE => mapUltima4CombatSHORE,
            Maps.U4CombatMapSHORSHIP => mapUltima4CombatSHORSHIP,
            Maps.U4CombatMapSHRINE => mapUltima4CombatSHRINE,
            _ => throw new ArgumentException("Invalid combat map")
        };
    }

    #endregion

    public void DrawMainDisplayGrid(SpriteBatch spriteBatch, int startY, int startX, int cellSize, bool bDrawAvatarInCenter = true)
    {
        int rows = mainDisplayGridSize;
        int cols = mainDisplayGridSize;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int x = startX + (col * cellSize * scaleFactor);
                int y = startY + (row * cellSize * scaleFactor);

                int mapValue = GetMainDisplayMapValue(row, col);

                if (bDrawAvatarInCenter)
                {
                    if (row == mainDisplayCenter && col == mainDisplayCenter)
                    {
                        // Always draw the avatar/vehicle in the center of the main display grid
                        // unless it is a combat map

                        if (_currentVehicle == RPGEnums.Vehicle.None)
                        {
                            mapValue = (int)TileType.Avatar;
                        }
                        else if (_currentVehicle == RPGEnums.Vehicle.Balloon)
                        {
                            mapValue = (int)TileType.Balloon;
                        }
                        else if (_currentVehicle == RPGEnums.Vehicle.Horse)
                        {
                            OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Horse");
                            if (entity != null)
                            {
                                mapValue = entity.TileValue;
                            }

                        }
                        else if (_currentVehicle == RPGEnums.Vehicle.Ship)
                        {
                            OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Ship");
                            if (entity != null)
                            {
                                mapValue = entity.TileValue;
                            }
                        }
                    }
                }

                Texture2D sprite = GetSpriteForMapValue(mapValue);

                // Draw the sprite with scaling
                spriteBatch.Draw(sprite, new Rectangle(x, y, cellSize * scaleFactor, cellSize * scaleFactor), Color.White);
            }
        }
    }

    private void TeleportAvatar(int iTownIndex)
    {
        switch (iTownIndex)
        {
            case 1:
                //Maps.U4MapLordBritishCastle1
                pcOverworldLocationY = 107;
                pcOverworldLocationX = 86;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 2:
                //Maps.U4MapBritain
                pcOverworldLocationY = 106;
                pcOverworldLocationX = 82;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 3:
                //Maps.U4MapPaws
                pcOverworldLocationY = 145;
                pcOverworldLocationX = 98;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 4:
                //Maps.U4MapTrinsic
                pcOverworldLocationY = 184;
                pcOverworldLocationX = 106;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 5:
                //Maps.U4MapCove
                pcOverworldLocationY = 90;
                pcOverworldLocationX = 136;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 6:
                //Maps.U4MapEmpathAbbey
                pcOverworldLocationY = 50;
                pcOverworldLocationX = 28;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 7:
                //Maps.U4MapJhelom
                pcOverworldLocationY = 222;
                pcOverworldLocationX = 36;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 8:
                //Maps.U4MapLycaeum
                pcOverworldLocationY = 107;
                pcOverworldLocationX = 218;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 9:
                //Maps.U4MapYew
                pcOverworldLocationY = 43;
                pcOverworldLocationX = 58;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 10:
                //Vesper
                pcOverworldLocationY = 59;
                pcOverworldLocationX = 201;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 11:
                //Minoc
                pcOverworldLocationY = 20;
                pcOverworldLocationX = 159;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 12:
                //Moonglow
                pcOverworldLocationY = 135;
                pcOverworldLocationX = 232;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 13:
                //Magincia
                pcOverworldLocationY = 169;
                pcOverworldLocationX = 187;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 14:
                //BuccaneersDen
                pcOverworldLocationY = 158;
                pcOverworldLocationX = 136;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 15:
                //SerpentIsle
                pcOverworldLocationY = 241;
                pcOverworldLocationX = 146;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 16:
                //SkaraBrae
                pcOverworldLocationY = 128;
                pcOverworldLocationX = 22;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 17:
                //Balloon Location
                pcOverworldLocationY = 242;
                pcOverworldLocationX = 233;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 18:
                //Skull Location
                pcOverworldLocationY = 245;
                pcOverworldLocationX = 197;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 19:
                //Wheel Location
                pcOverworldLocationY = 215;
                pcOverworldLocationX = 96;
                UpdateMainDisplayGridValues(currentMap);
                break;
            case 20:
                //Bell Location
                pcOverworldLocationY = 173;
                pcOverworldLocationX = 45;
                UpdateMainDisplayGridValues(currentMap);
                break;
            default:
                break;
        }
    }

    bool CanEnter(Maps map, int overworldlocationY, int overworldlocationX, int townMapLocationY, int townMapLocationX)
    {
        int mapValue = 0;

        mapValue = GetCurrentMapValue(map, overworldlocationY, overworldlocationX, townMapLocationY, townMapLocationX);

        TileType tileType = (TileType)mapValue;
        string tileTypeName = Enum.GetName(typeof(TileType), tileType);

        return IsEnterableTerrain(mapValue);
    }

    bool CanMoveInDirection(Maps map, MoveDirection direction, int overworldlocationY, int overworldlocationX, int townMapLocationY, int townMapLocationX)
    {
        int mapValue = 0;

        if (map == Maps.U4MapOverworld && direction == MoveDirection.North && overworldlocationY == 107 && overworldlocationX == 86)
        {
            if (!bDetectCollision) return true;

            //If you are on Lord British's castle entrance, you can not move north
            if (_currentVehicle == Vehicle.Balloon) { return true; }

            return false;
        }

        if (map == Maps.U4MapOverworld && direction == MoveDirection.South && overworldlocationY == 106 && overworldlocationX == 86)
        {
            if (!bDetectCollision) return true;

            //If you are north of Lord British's castle entrance, you can not move south
            if (_currentVehicle == Vehicle.Balloon) { return true; }

            return false;
        }

        if (direction == MoveDirection.North)
        {
            mapValue = GetMainDisplayMapValue(mainDisplayOneNorthOfCenter, mainDisplayCenter);
            return IsPassableTerrain(mapValue);
        }
        else if (direction == MoveDirection.South)
        {
            mapValue = GetMainDisplayMapValue(mainDisplayOneSouthOfCenter, mainDisplayCenter);
            return IsPassableTerrain(mapValue);
        }
        else if (direction == MoveDirection.East)
        {
            mapValue = GetMainDisplayMapValue(mainDisplayCenter, mainDisplayOneEastOfCenter);
            return IsPassableTerrain(mapValue);
        }
        else if (direction == MoveDirection.West)
        {
            mapValue = GetMainDisplayMapValue(mainDisplayCenter, mainDisplayOneWestOfCenter);
            return IsPassableTerrain(mapValue);
        }

        return true;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();

        switch (_currentState)
        {
            case GameStates.LoadingIntro:
                DrawLoadingIntro();
                break;

            case GameStates.Menu:
                DrawMenu();
                break;

            case GameStates.Playing:
                DrawPlaying();
                break;

            case GameStates.Paused:
                DrawPaused();
                break;

            case GameStates.GameOver:
                DrawGameOver();
                break;
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void DrawGameOver()
    {

    }

    private void DrawPaused()
    {
        // Draw "Paused" title
        var font = Content.Load<SpriteFont>("Fonts/CabinCondensed-Bold");
        string title = "--Paused--";
        Vector2 titlePosition = new Vector2(400, 200);
        _spriteBatch.DrawString(font, title, titlePosition, Color.White);

        // Draw menu options
        for (int i = 0; i < pauseMenuOptions.Length; i++)
        {
            string option = pauseMenuOptions[i];
            Vector2 position = new Vector2(400, 250 + i * 30);
            Color color = (i == selectedMenuIndex) ? Color.Yellow : Color.White;
            _spriteBatch.DrawString(font, option, position, color);
        }
    }

    private void DrawPlaying()
    {
        bool bDrawAvatarInCenter = true;

        if (currentMap == Maps.U4CombatMapBRICK || currentMap == Maps.U4CombatMapBRIDGE || currentMap == Maps.U4CombatMapBRUSH ||
        currentMap == Maps.U4CombatMapCAMP || currentMap == Maps.U4CombatMapDNG0 || currentMap == Maps.U4CombatMapDNG1 ||
        currentMap == Maps.U4CombatMapDNG2 || currentMap == Maps.U4CombatMapDNG3 || currentMap == Maps.U4CombatMapDNG4 ||
        currentMap == Maps.U4CombatMapDNG5 || currentMap == Maps.U4CombatMapDNG6 || currentMap == Maps.U4CombatMapDUNGEON ||
        currentMap == Maps.U4CombatMapFOREST || currentMap == Maps.U4CombatMapGRASS || currentMap == Maps.U4CombatMapHILL ||
        currentMap == Maps.U4CombatMapINN || currentMap == Maps.U4CombatMapMARSH || currentMap == Maps.U4CombatMapSHIPSEA ||
        currentMap == Maps.U4CombatMapSHIPSHIP || currentMap == Maps.U4CombatMapSHIPSHOR || currentMap == Maps.U4CombatMapSHORE ||
        currentMap == Maps.U4CombatMapSHORSHIP || currentMap == Maps.U4CombatMapSHRINE)
        {
            bDrawAvatarInCenter = false;
        }

        DrawMainDisplayGrid(
            _spriteBatch,
            0,
            0,
            16 * scaleFactor,
            bDrawAvatarInCenter
        );
    }

    private void DrawMenu()
    {

    }

    private void DrawLoadingIntro()
    {

    }

    protected override void Update(GameTime gameTime)
    {
        newKeyboardState = Keyboard.GetState();
        gamePad1State = GamePad.GetState(PlayerIndex.One);

        if (newKeyboardState.IsKeyDown(Keys.Escape))
        {
            _currentState = GameStates.GameOver;
        }

        // Toggle pause state when "P" is pressed
        if (oldKeyboardState.IsKeyUp(Keys.P) && newKeyboardState.IsKeyDown(Keys.P))
        {
            bGamePaused = !bGamePaused;

            if (bGamePaused)
            {

                _currentState = GameStates.Paused;
            }
            else
            {
                _currentState = GameStates.Playing;
            }
        }

        switch (_currentState)
        {
            case GameStates.LoadingIntro:
                UpdateLoadingIntro(gameTime);
                break;

            case GameStates.Menu:
                UpdateMenu(gameTime);
                break;

            case GameStates.Playing:
                UpdatePlaying(gameTime);
                break;

            case GameStates.Paused:
                UpdatePaused(gameTime);
                break;

            case GameStates.GameOver:
                UpdateGameOver(gameTime);
                break;
        }

        base.Update(gameTime);
    }

    private void UpdateGameOver(GameTime gameTime)
    {
        Exit();
    }

    private void UpdatePaused(GameTime gameTime)
    {
        newKeyboardState = Keyboard.GetState();

        PlayBackgroundMusicBasedOnCurrentMap();

        // Navigate menu
        if (oldKeyboardState.IsKeyUp(Keys.Up) && newKeyboardState.IsKeyDown(Keys.Up))
        {
            selectedMenuIndex = (selectedMenuIndex - 1 + pauseMenuOptions.Length) % pauseMenuOptions.Length;
        }
        else if (oldKeyboardState.IsKeyUp(Keys.Down) && newKeyboardState.IsKeyDown(Keys.Down))
        {
            selectedMenuIndex = (selectedMenuIndex + 1) % pauseMenuOptions.Length;
        }

        // Select menu option
        if (oldKeyboardState.IsKeyUp(Keys.Enter) && newKeyboardState.IsKeyDown(Keys.Enter))
        {
            if (pauseMenuOptions[selectedMenuIndex] == "Resume")
            {
                bGamePaused = false;
                _currentState = GameStates.Playing;
            }
            else if (pauseMenuOptions[selectedMenuIndex] == "Exit to Main Menu")
            {
                _currentState = GameStates.Menu;
            }
            else if (pauseMenuOptions[selectedMenuIndex] == "Exit to Windows")
            {
                _currentState = GameStates.GameOver;
            }
        }

        oldKeyboardState = newKeyboardState;
    }

    private void UpdatePlaying(GameTime gameTime)
    {
        // Update the input timer
        inputTimer += gameTime.ElapsedGameTime.TotalSeconds;

        PlayBackgroundMusicBasedOnCurrentMap();

        // Only process input if the required time has passed
        if (inputTimer >= inputDelay)
        {
            //Handle the Keyboard input
            if (newKeyboardState.IsKeyDown(Keys.LeftShift) && newKeyboardState.IsKeyDown(Keys.F12) ||
                newKeyboardState.IsKeyDown(Keys.RightShift) && newKeyboardState.IsKeyDown(Keys.F12)
                )
            {
                SaveGame();
                inputTimer = 0; // Reset the timer
                return;
            }

            if (newKeyboardState.IsKeyDown(Keys.F12))
            {
                LoadGame();
                UpdateMainDisplayGridValues(currentMap);
                PlayBackgroundMusicBasedOnCurrentMap();
                inputTimer = 0; // Reset the timer
                return;
            }

            #region Debug
                //Press the F1 key to turn off collision detection
                if (newKeyboardState.IsKeyDown(Keys.F1))
                {
                    bDetectCollision = !bDetectCollision;
                    inputTimer = 0; // Reset the timer
                    return;
                }

                //Press the F4 to change vehicles
                if (newKeyboardState.IsKeyDown(Keys.F4) && currentMap == Maps.U4MapOverworld)
                {
                    iSpawnVehicleIndex--;

                    if (iSpawnVehicleIndex < 1)
                    {
                        iSpawnVehicleIndex = 4;
                    }

                    switch (iSpawnVehicleIndex)
                    {
                        case 1:
                            _currentVehicle = Vehicle.Ship;
                            break;
                        case 2:
                            _currentVehicle = Vehicle.Horse;
                            break;
                        case 3:
                            _currentVehicle = Vehicle.Balloon;
                            break;
                        case 4:
                            _currentVehicle = Vehicle.None;
                            break;
                    }

                    inputTimer = 0; // Reset the timer
                }

                //Press the F5 to change vehicles
                if (newKeyboardState.IsKeyDown(Keys.F5) && currentMap == Maps.U4MapOverworld)
                {
                    iSpawnVehicleIndex++;

                    if (iSpawnVehicleIndex > 4)
                    {
                        iSpawnVehicleIndex = 1;
                    }

                    switch (iSpawnVehicleIndex)
                    {
                        case 1:
                            _currentVehicle = Vehicle.Ship;
                            break;
                        case 2:
                            _currentVehicle = Vehicle.Horse;
                            break;
                        case 3:
                            _currentVehicle = Vehicle.Balloon;
                            break;
                        case 4:
                            _currentVehicle = Vehicle.None;
                            break;
                    }

                    inputTimer = 0; // Reset the timer
                }

                //Press the F2 to teleport to the prev town
                if (newKeyboardState.IsKeyDown(Keys.F2) && currentMap == Maps.U4MapOverworld)
                {
                    iTeleportTownIndex--;

                    if (iTeleportTownIndex < 1)
                    {
                        iTeleportTownIndex = 20;
                    }

                    TeleportAvatar(iTeleportTownIndex);

                    inputTimer = 0; // Reset the timer
                }

                //Press the F3 to teleport to the next town
                if (newKeyboardState.IsKeyDown(Keys.F3) && currentMap == Maps.U4MapOverworld)
                {
                    iTeleportTownIndex++;

                    if (iTeleportTownIndex > 20)
                    {
                        iTeleportTownIndex = 1;
                    }

                    TeleportAvatar(iTeleportTownIndex);

                    inputTimer = 0; // Reset the timer
                    return;
                }

                //Press the F6 to display the prev combat map
                if (newKeyboardState.IsKeyDown(Keys.F6))
                {
                    iCombatMapIndex--;

                    if (iCombatMapIndex < 1)
                    {
                        iCombatMapIndex = 24;
                    }

                    currentMap = GetCombatMapForDebugging(iCombatMapIndex);
                    UpdateMainDisplayGridValues(currentMap);
                    PlayBackgroundMusicBasedOnCurrentMap();
                    inputTimer = 0; // Reset the timer
                    return;
                }

                //Press the F7 to display the next combat map
                if (newKeyboardState.IsKeyDown(Keys.F7))
                {
                    iCombatMapIndex++;

                    if (iCombatMapIndex > 24)
                    {
                        iCombatMapIndex = 1;
                    }

                    currentMap = GetCombatMapForDebugging(iCombatMapIndex);
                    UpdateMainDisplayGridValues(currentMap);
                    PlayBackgroundMusicBasedOnCurrentMap();
                    inputTimer = 0; // Reset the timer
                    return;
                }
            #endregion

            if (oldKeyboardState.IsKeyUp(Keys.Left) && newKeyboardState.IsKeyDown(Keys.Left))
            {
                _currentHeading = MoveDirection.West;

                if (currentMap != Maps.U4MapOverworld && (pcTownMapLocationX - 1 < 0))
                {
                    //ExitTownToOverworld
                    currentMap = Maps.U4MapOverworld;
                    UpdateMainDisplayGridValues(currentMap);
                    PlayBackgroundMusicBasedOnCurrentMap();
                    inputTimer = 0; // Reset the timer
                    return;
                }

                if (CanMoveInDirection(currentMap, MoveDirection.West, pcOverworldLocationY, pcOverworldLocationX, pcTownMapLocationY, pcTownMapLocationX))
                {
                    MovePlayer(currentMap, MoveDirection.West);

                    if (_currentVehicle == Vehicle.Balloon)
                    {
                        OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Balloon");
                        if (entity != null)
                        {
                            entity.X = pcOverworldLocationX;
                            entity.Y = pcOverworldLocationY;
                        }
                    }
                    else if (_currentVehicle == Vehicle.Horse)
                    {
                        OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Horse");
                        if (entity != null)
                        {
                            entity.X = pcOverworldLocationX;
                            entity.Y = pcOverworldLocationY;
                            entity.TileValue = (int)TileType.HorseWest;
                            entity.EntityFacing = MoveDirection.West;
                        }
                    }
                    else if (_currentVehicle == Vehicle.Ship)
                    {
                        OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Ship");
                        if (entity != null)
                        {
                            entity.X = pcOverworldLocationX;
                            entity.Y = pcOverworldLocationY;
                            entity.TileValue = (int)TileType.ShipWest;
                            entity.EntityFacing = MoveDirection.West;
                        }
                    }

                    if (_currentVehicle != Vehicle.Ship && _currentVehicle != Vehicle.Balloon)
                    {
                        _soundEffect_Walk.Play();
                    }
                }
                else
                {
                    _soundEffect_BadCommand.Play();
                }

                inputTimer = 0; // Reset the timer
            }
            else if (oldKeyboardState.IsKeyUp(Keys.Right) && newKeyboardState.IsKeyDown(Keys.Right))
            {
                _currentHeading = MoveDirection.East;

                if (currentMap != Maps.U4MapOverworld && (pcTownMapLocationX + 1 == townGridSize))
                {
                    //ExitTownToOverworld
                    currentMap = Maps.U4MapOverworld;
                    UpdateMainDisplayGridValues(currentMap);
                    PlayBackgroundMusicBasedOnCurrentMap();
                    inputTimer = 0; // Reset the timer
                    return;
                }

                if (CanMoveInDirection(currentMap, MoveDirection.East, pcOverworldLocationY, pcOverworldLocationX, pcTownMapLocationY, pcTownMapLocationX))
                {
                    MovePlayer(currentMap, MoveDirection.East);

                    if (_currentVehicle == Vehicle.Balloon)
                    {
                        OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Balloon");
                        if (entity != null)
                        {
                            entity.X = pcOverworldLocationX;
                            entity.Y = pcOverworldLocationY;
                        }
                    }
                    else if (_currentVehicle == Vehicle.Horse)
                    {
                        OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Horse");
                        if (entity != null)
                        {
                            entity.X = pcOverworldLocationX;
                            entity.Y = pcOverworldLocationY;
                            entity.TileValue = (int)TileType.HorseEast;
                            entity.EntityFacing = MoveDirection.East;
                        }
                    }
                    else if (_currentVehicle == Vehicle.Ship)
                    {
                        OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Ship");
                        if (entity != null)
                        {
                            entity.X = pcOverworldLocationX;
                            entity.Y = pcOverworldLocationY;
                            entity.TileValue = (int)TileType.ShipEast;
                            entity.EntityFacing = MoveDirection.East;
                        }
                    }

                    if (_currentVehicle != Vehicle.Ship && _currentVehicle != Vehicle.Balloon)
                    {
                        _soundEffect_Walk.Play();
                    }
                }
                else
                {
                    _soundEffect_BadCommand.Play();
                }

                inputTimer = 0; // Reset the timer
            }
            else if (oldKeyboardState.IsKeyUp(Keys.Up) && newKeyboardState.IsKeyDown(Keys.Up))
            {
                _currentHeading = MoveDirection.North;

                if (currentMap != Maps.U4MapOverworld && (pcTownMapLocationY - 1 < 0))
                {
                    //ExitTownToOverworld
                    currentMap = Maps.U4MapOverworld;
                    UpdateMainDisplayGridValues(currentMap);
                    PlayBackgroundMusicBasedOnCurrentMap();
                    inputTimer = 0; // Reset the timer
                    return;
                }

                if (CanMoveInDirection(currentMap, MoveDirection.North, pcOverworldLocationY, pcOverworldLocationX, pcTownMapLocationY, pcTownMapLocationX))
                {
                    MovePlayer(currentMap, MoveDirection.North);

                    if (_currentVehicle == Vehicle.Balloon)
                    {
                        //If we are in the balloon, we need to update the balloon entity position
                        OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Balloon");
                        if (entity != null)
                        {
                            entity.X = pcOverworldLocationX;
                            entity.Y = pcOverworldLocationY;
                        }
                    }
                    else if (_currentVehicle == Vehicle.Horse)
                    {
                        OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Horse");
                        if (entity != null)
                        {
                            entity.X = pcOverworldLocationX;
                            entity.Y = pcOverworldLocationY;
                            entity.TileValue = (int)TileType.HorseEast;
                            entity.EntityFacing = MoveDirection.East;
                        }
                    }
                    else if (_currentVehicle == Vehicle.Ship)
                    {
                        OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Ship");
                        if (entity != null)
                        {
                            entity.X = pcOverworldLocationX;
                            entity.Y = pcOverworldLocationY;
                            entity.TileValue = (int)TileType.ShipNorth;
                            entity.EntityFacing = MoveDirection.North;
                        }
                    }

                    if (_currentVehicle != Vehicle.Ship && _currentVehicle != Vehicle.Balloon)
                    {
                        _soundEffect_Walk.Play();
                    }
                }
                else
                {
                    _soundEffect_BadCommand.Play();
                }

                inputTimer = 0; // Reset the timer
            }
            else if (oldKeyboardState.IsKeyUp(Keys.Down) && newKeyboardState.IsKeyDown(Keys.Down))
            {
                _currentHeading = MoveDirection.South;

                if (currentMap != Maps.U4MapOverworld && (pcTownMapLocationY + 1 == townGridSize))
                {
                    //ExitTownToOverworld
                    currentMap = Maps.U4MapOverworld;
                    UpdateMainDisplayGridValues(currentMap);
                    PlayBackgroundMusicBasedOnCurrentMap();
                    inputTimer = 0; // Reset the timer
                    return;
                }

                if (CanMoveInDirection(currentMap, MoveDirection.South, pcOverworldLocationY, pcOverworldLocationX, pcTownMapLocationY, pcTownMapLocationX))
                {
                    MovePlayer(currentMap, MoveDirection.South);

                    if (_currentVehicle == Vehicle.Balloon)
                    {
                        //If we are in the balloon, we need to update the balloon entity position
                        OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Balloon");
                        if (entity != null)
                        {
                            entity.X = pcOverworldLocationX;
                            entity.Y = pcOverworldLocationY;
                        }
                    }
                    else if (_currentVehicle == Vehicle.Horse)
                    {
                        OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Horse");
                        if (entity != null)
                        {
                            entity.X = pcOverworldLocationX;
                            entity.Y = pcOverworldLocationY;
                            entity.TileValue = (int)TileType.HorseWest;
                            entity.EntityFacing = MoveDirection.West;
                        }
                    }
                    else if (_currentVehicle == Vehicle.Ship)
                    {
                        OverworldEntity entity = overworldEntityManager.GetEntityByEntityType("Ship");
                        if (entity != null)
                        {
                            entity.X = pcOverworldLocationX;
                            entity.Y = pcOverworldLocationY;
                            entity.TileValue = (int)TileType.ShipSouth;
                            entity.EntityFacing = MoveDirection.South;
                        }
                    }

                    if (_currentVehicle != Vehicle.Ship && _currentVehicle != Vehicle.Balloon)
                    {
                        _soundEffect_Walk.Play();
                    }
                }
                else
                {
                    _soundEffect_BadCommand.Play();
                }

                inputTimer = 0; // Reset the timer
            }
            else if (oldKeyboardState.IsKeyUp(Keys.L) && newKeyboardState.IsKeyDown(Keys.L))
            {
                Console.WriteLine($"{pcOverworldLocationY} {pcOverworldLocationX}");
                Console.WriteLine($"{pcTownMapLocationY} {pcTownMapLocationX}");
            }
            else if (oldKeyboardState.IsKeyUp(Keys.K) && newKeyboardState.IsKeyDown(Keys.K))
            {
                if (currentMap == Maps.U4MapLordBritishCastle1 && pcOverworldLocationY == 107 && pcOverworldLocationX == 86 && pcTownMapLocationY == 3 && pcTownMapLocationX == 3)
                {
                    currentMap = Maps.U4MapLordBritishCastle2;
                    pcTownMapLocationY = 3;
                    pcTownMapLocationX = 3;
                    UpdateMainDisplayGridValues(currentMap);
                    PlayBackgroundMusicBasedOnCurrentMap();
                }
            }
            else if (oldKeyboardState.IsKeyUp(Keys.D) && newKeyboardState.IsKeyDown(Keys.D))
            {
                if (currentMap == Maps.U4MapLordBritishCastle2 && pcOverworldLocationY == 107 && pcOverworldLocationX == 86 && pcTownMapLocationY == 3 && pcTownMapLocationX == 3)
                {
                    currentMap = Maps.U4MapLordBritishCastle1;
                    pcTownMapLocationY = 3;
                    pcTownMapLocationX = 3;
                    UpdateMainDisplayGridValues(currentMap);
                    PlayBackgroundMusicBasedOnCurrentMap();
                }
            }
            else if (oldKeyboardState.IsKeyUp(Keys.E) && newKeyboardState.IsKeyDown(Keys.E))
            {
                if (CanEnter(currentMap, pcOverworldLocationY, pcOverworldLocationX, pcTownMapLocationY, pcTownMapLocationX))
                {
                    if (_currentVehicle != Vehicle.None)
                    {
                        //If the player is already in a vehicle, they cannot enter anything
                        _soundEffect_BadCommand.Play();
                        inputTimer = 0; // Reset the timer
                        return;
                    }

                    //Check if current location is the same as a persisted item 
                    OverworldEntity entity = overworldEntityManager.GetEntityAt(pcOverworldLocationY, pcOverworldLocationX);
                    if (entity != null)
                    {
                        //Enter the Balloon
                        if (entity.EntityType == "Balloon")
                        {
                            _currentVehicle = Vehicle.Balloon;
                            inputTimer = 0; // Reset the timer
                            return;
                        }
                        else if (entity.EntityType == "Horse")
                        {
                            _currentVehicle = Vehicle.Horse;
                            inputTimer = 0; // Reset the timer
                            return;
                        }
                        else if (entity.EntityType == "Ship")
                        {
                            _currentVehicle = Vehicle.Ship;
                            inputTimer = 0; // Reset the timer
                            return;
                        }
                    }

                    // Logic to enter a location (like a castle, town, etc.)
                    if (pcOverworldLocationY == 106 && pcOverworldLocationX == 82)
                    {
                        currentMap = Maps.U4MapBritain;
                        pcTownMapLocationY = 15;
                        pcTownMapLocationX = 0;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 107 && pcOverworldLocationX == 86)
                    {
                        currentMap = Maps.U4MapLordBritishCastle1;
                        pcTownMapLocationY = 31;
                        pcTownMapLocationX = 15;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 145 && pcOverworldLocationX == 98)
                    {
                        currentMap = Maps.U4MapPaws;
                        pcTownMapLocationY = 15;
                        pcTownMapLocationX = 0;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 184 && pcOverworldLocationX == 106)
                    {
                        currentMap = Maps.U4MapTrinsic;
                        pcTownMapLocationY = 15;
                        pcTownMapLocationX = 0;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 90 && pcOverworldLocationX == 136)
                    {
                        currentMap = Maps.U4MapCove;
                        pcTownMapLocationY = 15;
                        pcTownMapLocationX = 0;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 50 && pcOverworldLocationX == 28)
                    {
                        currentMap = Maps.U4MapEmpathAbbey;
                        pcTownMapLocationY = 31;
                        pcTownMapLocationX = 15;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 222 && pcOverworldLocationX == 36)
                    {
                        currentMap = Maps.U4MapJhelom;
                        pcTownMapLocationY = 15;
                        pcTownMapLocationX = 0;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 107 && pcOverworldLocationX == 218)
                    {
                        currentMap = Maps.U4MapLycaeum;
                        pcTownMapLocationY = 31;
                        pcTownMapLocationX = 15;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 43 && pcOverworldLocationX == 58)
                    {
                        currentMap = Maps.U4MapYew;
                        pcTownMapLocationY = 15;
                        pcTownMapLocationX = 0;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 59 && pcOverworldLocationX == 201)
                    {
                        currentMap = Maps.U4MapVesper;
                        pcTownMapLocationY = 15;
                        pcTownMapLocationX = 0;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 20 && pcOverworldLocationX == 159)
                    {
                        currentMap = Maps.U4MapMinoc;
                        pcTownMapLocationY = 15;
                        pcTownMapLocationX = 0;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 135 && pcOverworldLocationX == 232)
                    {
                        currentMap = Maps.U4MapMoonglow;
                        pcTownMapLocationY = 15;
                        pcTownMapLocationX = 0;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 169 && pcOverworldLocationX == 187)
                    {
                        currentMap = Maps.U4MapMagincia;
                        pcTownMapLocationY = 15;
                        pcTownMapLocationX = 0;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 158 && pcOverworldLocationX == 136)
                    {
                        currentMap = Maps.U4MapBuccaneersDen;
                        pcTownMapLocationY = 15;
                        pcTownMapLocationX = 0;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 241 && pcOverworldLocationX == 146)
                    {
                        currentMap = Maps.U4MapSerpentIsle;
                        pcTownMapLocationY = 31;
                        pcTownMapLocationX = 15;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                    else if (pcOverworldLocationY == 128 && pcOverworldLocationX == 22)
                    {
                        currentMap = Maps.U4MapSkaraBrae;
                        pcTownMapLocationY = 15;
                        pcTownMapLocationX = 0;
                        UpdateMainDisplayGridValues(currentMap);
                        PlayBackgroundMusicBasedOnCurrentMap();
                    }
                }
                else
                {
                    _soundEffect_BadCommand.Play();
                }

                inputTimer = 0; // Reset the timer
            }

            else if (oldKeyboardState.IsKeyUp(Keys.X) && newKeyboardState.IsKeyDown(Keys.X))
            {
                if (currentMap == Maps.U4MapOverworld)
                {
                    if (_currentVehicle == Vehicle.None)
                    {
                        _soundEffect_BadCommand.Play();
                    }
                    else
                    {
                        _currentVehicle = Vehicle.None;
                    }
                }
            }
            //Handle the GamePad input
            else if (gamePad1State.IsConnected && gamePad1State.DPad.Left == ButtonState.Pressed)
            {
                if (CanMoveInDirection(currentMap, MoveDirection.West, pcOverworldLocationY, pcOverworldLocationX, pcTownMapLocationY, pcTownMapLocationX))
                {
                    MovePlayer(currentMap, MoveDirection.West);
                    if (_currentVehicle != Vehicle.Ship && _currentVehicle != Vehicle.Balloon)
                    {
                        _soundEffect_Walk.Play();
                    }
                }
                else
                {
                    _soundEffect_BadCommand.Play();
                }

                inputTimer = 0; // Reset the timer
            }
            else if (gamePad1State.IsConnected && gamePad1State.DPad.Right == ButtonState.Pressed)
            {
                if (CanMoveInDirection(currentMap, MoveDirection.East, pcOverworldLocationY, pcOverworldLocationX, pcTownMapLocationY, pcTownMapLocationX))
                {
                    MovePlayer(currentMap, MoveDirection.East);
                    if (_currentVehicle != Vehicle.Ship && _currentVehicle != Vehicle.Balloon)
                    {
                        _soundEffect_Walk.Play();
                    }
                }
                else
                {
                    _soundEffect_BadCommand.Play();
                }

                inputTimer = 0; // Reset the timer
            }
            else if (gamePad1State.IsConnected && gamePad1State.DPad.Up == ButtonState.Pressed)
            {
                if (CanMoveInDirection(currentMap, MoveDirection.North, pcOverworldLocationY, pcOverworldLocationX, pcTownMapLocationY, pcTownMapLocationX))
                {
                    MovePlayer(currentMap, MoveDirection.North);
                    if (_currentVehicle != Vehicle.Ship && _currentVehicle != Vehicle.Balloon)
                    {
                        _soundEffect_Walk.Play();
                    }
                }
                else
                {
                    _soundEffect_BadCommand.Play();
                }

                inputTimer = 0; // Reset the timer
            }
            else if (gamePad1State.IsConnected && gamePad1State.DPad.Down == ButtonState.Pressed)
            {
                if (CanMoveInDirection(currentMap, MoveDirection.South, pcOverworldLocationY, pcOverworldLocationX, pcTownMapLocationY, pcTownMapLocationX))
                {
                    MovePlayer(currentMap, MoveDirection.South);
                    if (_currentVehicle != Vehicle.Ship && _currentVehicle != Vehicle.Balloon)
                    {
                        _soundEffect_Walk.Play();
                    }
                }
                else
                {
                    _soundEffect_BadCommand.Play();
                }

                inputTimer = 0; // Reset the timer
            }
        }

        oldKeyboardState = newKeyboardState;  // set the new state as the old state for next time

        UpdateMainDisplayGridValues(currentMap);
    }

    private Maps GetCombatMapForDebugging(int iCombatMapIndex)
    {
        switch (iCombatMapIndex)
        {
            case 1:
                //Include this to make sure the player can always return to the overworld
                //when debugging
                return Maps.U4MapOverworld;
            case 2:
                return Maps.U4CombatMapBRIDGE;
            case 3:
                return Maps.U4CombatMapBRUSH;
            case 4:
                return Maps.U4CombatMapCAMP;
            case 5:
                return Maps.U4CombatMapDNG0;
            case 6:
                return Maps.U4CombatMapDNG1;
            case 7:
                return Maps.U4CombatMapDNG2;
            case 8:
                return Maps.U4CombatMapDNG3;
            case 9:
                return Maps.U4CombatMapDNG4;
            case 10:
                return Maps.U4CombatMapDNG5;
            case 11:
                return Maps.U4CombatMapDNG6;
            case 12:
                return Maps.U4CombatMapDUNGEON;
            case 13:
                return Maps.U4CombatMapFOREST;
            case 14:
                return Maps.U4CombatMapGRASS;
            case 15:
                return Maps.U4CombatMapHILL;
            case 16:
                return Maps.U4CombatMapINN;
            case 17:
                return Maps.U4CombatMapMARSH;
            case 18:
                return Maps.U4CombatMapSHIPSEA;
            case 19:
                return Maps.U4CombatMapSHIPSHIP;
            case 20:
                return Maps.U4CombatMapSHIPSHOR;
            case 21:
                return Maps.U4CombatMapSHORE;
            case 22:
                return Maps.U4CombatMapSHORSHIP;
            case 23:
                return Maps.U4CombatMapSHRINE;
            case 24:
                return Maps.U4CombatMapBRICK;
            default:
                return Maps.U4MapOverworld;
        }
    }

    private void LoadGame()
    {
        string saveGamePath = "SaveSlot1\\Ultima4SaveGameVariables.xml";
        string playerDataPath = "SaveSlot1\\FantasyPlayer01.xml";
        string overworldEntityPath = "SaveSlot1\\OverworldEntities.xml";
        if (File.Exists(saveGamePath) && File.Exists(playerDataPath))
        {
            Ultima4SaveGameVariables gameSaveVariables = new Ultima4SaveGameVariables();
            gameSaveVariables = Utilities.DeserializeSaveGameVariables(saveGamePath);
            currentMap = gameSaveVariables.CurrentMap;
            pcOverworldLocationX = gameSaveVariables.pcOverworldLocationX;
            pcOverworldLocationY = gameSaveVariables.pcOverworldLocationY;
            pcTownMapLocationX = gameSaveVariables.pcTownMapLocationX;
            pcTownMapLocationY = gameSaveVariables.pcTownMapLocationY;
            _currentVehicle = gameSaveVariables.CurrentVehicle;
            _currentHeading = gameSaveVariables.CurrentHeading;

            player1 = Utilities.DeserializeFantasyPlayer(playerDataPath);
            overworldEntityManager = OverworldEntityManager.LoadFromFile(overworldEntityPath);
        }
    }

    private void SaveGame()
    {
        Ultima4SaveGameVariables gameSaveVariables = new Ultima4SaveGameVariables();
        gameSaveVariables.CurrentMap = currentMap;
        gameSaveVariables.pcOverworldLocationX = pcOverworldLocationX;
        gameSaveVariables.pcOverworldLocationY = pcOverworldLocationY;
        gameSaveVariables.pcTownMapLocationX = pcTownMapLocationX;
        gameSaveVariables.pcTownMapLocationY = pcTownMapLocationY;
        gameSaveVariables.CurrentVehicle = _currentVehicle;
        gameSaveVariables.CurrentHeading = _currentHeading;

        Utilities.SerializeSaveGameVariables(gameSaveVariables, "SaveSlot1\\Ultima4SaveGameVariables.xml");

        Utilities.SerializeFantasyPlayer(player1, "SaveSlot1\\FantasyPlayer01.xml");

        Utilities.SerializeOverworldEntities(overworldEntityManager, "SaveSlot1\\OverworldEntities.xml");
    }

    private void PlayBackgroundMusicBasedOnCurrentMap()
    {
        if (currentMap == Maps.U4MapOverworld && currentSong == Songs.U4SongNone)
        {
            if (Microsoft.Xna.Framework.Media.MediaPlayer.State != MediaState.Playing)
            {
                //First time playing the game - Default to _songUltima4Wanderer
                //because we start on the overworld
                Microsoft.Xna.Framework.Media.MediaPlayer.Play(_songUltima4Wanderer);
                currentSong = Songs.U4SongWanderer;
            }
        }
        else if (currentMap == Maps.U4MapOverworld && currentSong != Songs.U4SongWanderer)
        {
            Microsoft.Xna.Framework.Media.MediaPlayer.Play(_songUltima4Wanderer);
            currentSong = Songs.U4SongWanderer;
        }
        else if (currentMap == Maps.U4MapLordBritishCastle1 && currentSong != Songs.U4SongLordBritishCastle)
        {
            Microsoft.Xna.Framework.Media.MediaPlayer.Play(_songUltima4LordBritishCastle);
            currentSong = Songs.U4SongLordBritishCastle;
        }
        else if (currentMap == Maps.U4MapLordBritishCastle2 && currentSong != Songs.U4SongLordBritishCastle)
        {
            Microsoft.Xna.Framework.Media.MediaPlayer.Play(_songUltima4LordBritishCastle);
            currentSong = Songs.U4SongLordBritishCastle;
        }
        else if (
            (currentMap == Maps.U4MapBritain ||
            currentMap == Maps.U4MapBuccaneersDen ||
            currentMap == Maps.U4MapCove ||
            currentMap == Maps.U4MapEmpathAbbey ||
            currentMap == Maps.U4MapJhelom ||
            currentMap == Maps.U4MapLycaeum ||
            currentMap == Maps.U4MapMagincia ||
            currentMap == Maps.U4MapMinoc ||
            currentMap == Maps.U4MapMoonglow ||
            currentMap == Maps.U4MapPaws ||
            currentMap == Maps.U4MapSerpentIsle ||
            currentMap == Maps.U4MapSkaraBrae ||
            currentMap == Maps.U4MapTrinsic ||
            currentMap == Maps.U4MapVesper ||
            currentMap == Maps.U4MapYew) 
            && currentSong != Songs.U4SongTowne)
        {
            Microsoft.Xna.Framework.Media.MediaPlayer.Play(_songUltima4Towne);
            currentSong = Songs.U4SongTowne;
        }
        else if (
            (
        currentMap == Maps.U4CombatMapBRICK ||
        currentMap == Maps.U4CombatMapBRIDGE ||
        currentMap == Maps.U4CombatMapBRUSH ||
        currentMap == Maps.U4CombatMapCAMP ||
        currentMap == Maps.U4CombatMapDNG0 ||
        currentMap == Maps.U4CombatMapDNG1 ||
        currentMap == Maps.U4CombatMapDNG2 ||
        currentMap == Maps.U4CombatMapDNG3 ||
        currentMap == Maps.U4CombatMapDNG4 ||
        currentMap == Maps.U4CombatMapDNG5 ||
        currentMap == Maps.U4CombatMapDNG6 ||
        currentMap == Maps.U4CombatMapDUNGEON ||
        currentMap == Maps.U4CombatMapFOREST ||
        currentMap == Maps.U4CombatMapGRASS ||
        currentMap == Maps.U4CombatMapHILL ||
        currentMap == Maps.U4CombatMapINN ||
        currentMap == Maps.U4CombatMapMARSH ||
        currentMap == Maps.U4CombatMapSHIPSEA ||
        currentMap == Maps.U4CombatMapSHIPSHIP ||
        currentMap == Maps.U4CombatMapSHIPSHOR ||
        currentMap == Maps.U4CombatMapSHORE ||
        currentMap == Maps.U4CombatMapSHORSHIP ||
        currentMap == Maps.U4CombatMapSHRINE)
            && currentSong != Songs.U4SongCombat)
        {
            Microsoft.Xna.Framework.Media.MediaPlayer.Play(_songUltima4Combat);
            currentSong = Songs.U4SongCombat;
        }

        if (bGamePaused && Microsoft.Xna.Framework.Media.MediaPlayer.State == MediaState.Playing)
        {
            currentSong = Songs.U4SongNone;
            Microsoft.Xna.Framework.Media.MediaPlayer.Stop();
        }
    }

    private void UpdateMenu(GameTime gameTime)
    {
        //Not Implemented Yet... just move on to the Playing
        _currentState = GameStates.Playing;
    }

    private void UpdateLoadingIntro(GameTime gameTime)
    {
        //Not Implemented Yet... just move on to the Menu
        _currentState = GameStates.Menu;
    }

}