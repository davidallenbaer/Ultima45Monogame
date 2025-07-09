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
        public string EntityName { get; set; }
        public string EntityType { get; set; } = "NPC";
        public int EntityID { get; set; } = 0;
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public int TileValue
        {
            get
            {
                if (EntityType == "Door" && OpenState == OpenStatus.Closed && LockedState == LockedStatus.Locked)
                {
                    return (int)TileType.LockedDoor;
                }
                if (EntityType == "Door" && OpenState == OpenStatus.Closed && LockedState == LockedStatus.Unlocked)
                {
                    return (int)TileType.UnlockedDoor;
                }
                if (EntityType == "Door" && OpenState == OpenStatus.Open && LockedState == LockedStatus.Unlocked)
                {
                    //Default tile below the door
                    return _tileValue;
                }

                return _tileValue;
            }
            set
            {
                _tileValue = value;
            }
        }
        
        public List<FantasyWeapon> MerchantWeapons { get; set; } = new List<FantasyWeapon>();
        public List<FantasyArmor> MerchantArmor { get; set; } = new List<FantasyArmor>();
        public List<FantasyEquipment> MerchantEquipment { get; set; } = new List<FantasyEquipment>();

        public bool IsVisible { get; set; } = true;
        public int Movement { get; set; } = 0;
        public int Schedule { get; set; } = 0;
        public int DialogIndex { get; set; } = 0;

        public bool PreventEnteringTile
        {
            get
            {
                // If the entity is open and unlocked, do not prevent entering the tile
                if (EntityType == "Door" && OpenState == OpenStatus.Open)
                {
                    return false;
                }
                else if (EntityType == "Door" && OpenState == OpenStatus.Closed)
                {
                    return true;
                }
                
                // Otherwise, use the backing field value
                return _preventEnteringTile;
            }
            set
            {
                _preventEnteringTile = value;
            }
        }

        private int _tileValue;
        private bool _preventEnteringTile;
        public OpenStatus OpenState { get; set; } = OpenStatus.None;
        public LockedStatus LockedState { get; set; } = LockedStatus.None;
        public bool IsMerchant { get; set; } = false;

        public TownEntity(Maps townMap, string entityName, string entityType, int entityId, int startY, int startX, int tileValue, bool visible, int movement, int schedule, int dialogindex, bool preventEnteringTile, OpenStatus openStatus = OpenStatus.None, LockedStatus lockedStatus = LockedStatus.None, bool isMerchant = false)
        {
            EntityType = entityType;
            EntityName = entityName;
            TownMap = townMap;
            EntityID = entityId;
            StartX = startX;
            StartY = startY;
            CurrentX = startX;
            CurrentY = startY;
            TileValue = tileValue;
            IsVisible = visible;
            Movement = movement;
            Schedule = schedule;
            DialogIndex = dialogindex;
            PreventEnteringTile = preventEnteringTile;
            OpenState = openStatus;
            LockedState = lockedStatus;
            IsMerchant = isMerchant;
        }

        // Parameterless constructor for serialization
        public TownEntity() { }
    }
}
