﻿using InputHandlers.State;
using System.Collections.Generic;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    public static class TownEntityFactory
    {
        /// <summary>
        /// Returns a list of all default TownEntities.
        /// </summary>
        public static List<TownEntity> GetAllTownEntities()
        {
            var entities = new List<TownEntity>();

            #region U4MapLordBritishCastle2

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapLordBritishCastle2,
                    entityName: "Lord British",
                    entityType: "NPC",
                    entityId: 1,
                    startY: 7,
                    startX: 19,
                    tileValue: (int)TileType.LordBritish1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                ));

            entities.Add(new TownEntity(
                townMap: Maps.U4MapLordBritishCastle2,
                entityName: "Jester",
                entityType: "NPC",
                entityId: 2,
                startY: 9,
                startX: 17,
                tileValue: (int)TileType.Jester1,
                visible: true,
                movement: 0,
                schedule: 0,
                dialogindex: 1,
                preventEnteringTile: true
            ));

            #endregion

            #region U4MapLordBritishCastle1
            
            entities.Add(new TownEntity(
                townMap: Maps.U4MapLordBritishCastle1,
                entityName: "Seer",
                entityType: "NPC",
                entityId: 3,
                startY: 26,
                startX: 8,
                tileValue: (int)TileType.Mage1,
                visible: true,
                movement: 0,
                schedule: 0,
                dialogindex: 1,
                preventEnteringTile: true
            ));

            #endregion

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Guard",
                    entityType: "NPC",
                    entityId: 4,
                    startY: 13,
                    startX: 1,
                    tileValue: (int)TileType.Guard1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Guard",
                    entityType: "NPC",
                    entityId: 5,
                    startY: 17,
                    startX: 1,
                    tileValue: (int)TileType.Guard1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Guard",
                    entityType: "NPC",
                    entityId: 6,
                    startY: 25,
                    startX: 20,
                    tileValue: (int)TileType.Guard1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Guard",
                    entityType: "NPC",
                    entityId: 7,
                    startY: 22,
                    startX: 20,
                    tileValue: (int)TileType.Guard1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Rune of Compassion",
                    entityType: "NPC",
                    entityId: 8,
                    startY: 1,
                    startX: 25,
                    tileValue: (int)TileType.Blank,
                    visible: false,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: false
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Shepherd1",
                    entityType: "NPC",
                    entityId: 9,
                    startY: 1,
                    startX: 30,
                    tileValue: (int)TileType.Shepherd1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Beggar",
                    entityType: "NPC",
                    entityId: 10,
                    startY: 9,
                    startX: 19,
                    tileValue: (int)TileType.Beggar1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Child",
                    entityType: "NPC",
                    entityId: 11,
                    startY: 27,
                    startX: 28,
                    tileValue: (int)TileType.Child1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Child",
                    entityType: "NPC",
                    entityId: 12,
                    startY: 28,
                    startX: 27,
                    tileValue: (int)TileType.Child1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Child",
                    entityType: "NPC",
                    entityId: 13,
                    startY: 28,
                    startX: 29,
                    tileValue: (int)TileType.Child1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Iolo",
                    entityType: "NPC",
                    entityId: 14,
                    startY: 29,
                    startX: 28,
                    tileValue: (int)TileType.Bard1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Brittania Manor Dude",
                    entityType: "NPC",
                    entityId: 15,
                    startY: 13,
                    startX: 26,
                    tileValue: (int)TileType.Citizen1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Brittania Spirits",
                    entityType: "NPC",
                    entityId: 16,
                    startY: 1,
                    startX: 20,
                    tileValue: (int)TileType.Citizen1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Brittania Food",
                    entityType: "NPC",
                    entityId: 17,
                    startY: 7,
                    startX: 19,
                    tileValue: (int)TileType.Citizen2,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Brittania Healing",
                    entityType: "NPC",
                    entityId: 18,
                    startY: 30,
                    startX: 4,
                    tileValue: (int)TileType.Citizen1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Brittania Druid",
                    entityType: "NPC",
                    entityId: 19,
                    startY: 28,
                    startX: 3,
                    tileValue: (int)TileType.Druid2,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Brittania Weapons",
                    entityType: "NPC",
                    entityId: 20,
                    startY: 2,
                    startX: 5,
                    tileValue: (int)TileType.Fighter1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Brittania Armor",
                    entityType: "NPC",
                    entityId: 21,
                    startY: 8,
                    startX: 6,
                    tileValue: (int)TileType.Fighter1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1,
                    preventEnteringTile: true
                    ));

            return entities;
        }



        /*
            Unlocked Door
            Locked Door
            Gold Chest
            Ladder Up
            Ladder Down
            Magic Field
            Fire Field
            Poison Field
            Rune Field in britain (Not Visible)
         */
    }
}