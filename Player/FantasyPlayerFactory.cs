using System.Collections.Generic;
using Ultima45Monogame;
using static Ultima45Monogame.FantasyWeapon;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    public static class FantasyPlayerFactory
    {
        public static List<FantasyPlayer> GetAllFantasyPlayers()
        {
            List<FantasyPlayer> fantasyPlayers = new List<FantasyPlayer>();

            var weaponNone = FantasyWeaponFactory.GetFantasyWeapon(0);            
            var weaponSword = FantasyWeaponFactory.GetFantasyWeapon(1);
            weaponSword.IsEquipped = true;
            var weaponSling = FantasyWeaponFactory.GetFantasyWeapon(2);
            weaponSling.IsEquipped = true;
            var weaponMace = FantasyWeaponFactory.GetFantasyWeapon(3);
            weaponMace.IsEquipped = true;
            var weaponDagger = FantasyWeaponFactory.GetFantasyWeapon(4);
            weaponDagger.IsEquipped = true;

            var armorNone = FantasyArmorFactory.GetFantasyArmor(0);            
            var armorCloth = FantasyArmorFactory.GetFantasyArmor(1);
            armorCloth.IsEquipped = true;
            var armorLeather = FantasyArmorFactory.GetFantasyArmor(3);
            armorLeather.IsEquipped = true;
            var armorChainmail = FantasyArmorFactory.GetFantasyArmor(11);
            armorChainmail.IsEquipped = true;

            // Ensure each player has a NONE weapon and a NONE armor

            fantasyPlayers = new List<FantasyPlayer>
            {
                new FantasyPlayer
                {
                    Name = "Avatar",
                    Level = 1,
                    HP = 20,
                    MP = 5,
                    Strength = 15,
                    Dexterity = 20,
                    Constitution = 12,
                    Intelligence = 15,
                    Wisdom = 10,
                    Charisma = 10,
                    XP = 0,
                    AC = 15,
                    Initiative = 2,
                    Speed = 30,
                    Age = 25,
                    Height = 70,
                    Weight = 170,
                    GP = 100,
                    Rations = 10,
                    Visible = true,
                    PartyPosition = 1,
                    IsEnabled = true,
                    PlayerTile = TileType.Avatar,
                    Weapons = new List<FantasyWeapon> { weaponNone, weaponSling },
                    Armor = new List<FantasyArmor> { armorNone, armorCloth },
                    CanCastSpells = true
                },
                new FantasyPlayer
                {
                    Name = "Iolo",
                    Level = 1,
                    HP = 16,
                    MP = 3,
                    Strength = 15,
                    Dexterity = 20,
                    Constitution = 12,
                    Intelligence = 15,
                    Wisdom = 10,
                    Charisma = 8,
                    XP = 0,
                    AC = 13,
                    Initiative = 3,
                    Speed = 30,
                    Age = 38,
                    Height = 68,
                    Weight = 150,
                    GP = 50,
                    Rations = 8,
                    Visible = true,
                    PartyPosition = 2,
                    IsEnabled = true,
                    PlayerTile = TileType.Bard1,
                    Weapons = new List<FantasyWeapon> { weaponNone, weaponSling },
                    Armor = new List<FantasyArmor> { armorNone, armorCloth },
                    CanCastSpells = true
                },
                new FantasyPlayer
                {
                    Name = "Shamino",
                    Level = 1,
                    HP = 16,
                    MP = 3,
                    Strength = 15,
                    Dexterity = 20,
                    Constitution = 12,
                    Intelligence = 15,
                    Wisdom = 10,
                    Charisma = 8,
                    XP = 0,
                    AC = 13,
                    Initiative = 3,
                    Speed = 30,
                    Age = 38,
                    Height = 68,
                    Weight = 150,
                    GP = 50,
                    Rations = 8,
                    Visible = true,
                    PartyPosition = 3,
                    IsEnabled = true,
                    PlayerTile = TileType.Ranger1,
                    Weapons = new List<FantasyWeapon> { weaponNone, weaponMace },
                    Armor = new List<FantasyArmor> { armorNone, armorCloth },
                    CanCastSpells = true
                },
                new FantasyPlayer
                {
                    Name = "Dupre",
                    Level = 1,
                    HP = 16,
                    MP = 3,
                    Strength = 20,
                    Dexterity = 15,
                    Constitution = 12,
                    Intelligence = 15,
                    Wisdom = 10,
                    Charisma = 8,
                    XP = 0,
                    AC = 13,
                    Initiative = 3,
                    Speed = 30,
                    Age = 38,
                    Height = 68,
                    Weight = 150,
                    GP = 50,
                    Rations = 8,
                    Visible = true,
                    PartyPosition = 4,
                    IsEnabled = true,
                    PlayerTile = TileType.Paladin1,
                    Weapons = new List<FantasyWeapon> { weaponNone, weaponSword },
                    Armor = new List<FantasyArmor> { armorNone, armorChainmail },
                    CanCastSpells = true
                },
                new FantasyPlayer
                {
                    Name = "Jaana",
                    Level = 1,
                    HP = 16,
                    MP = 3,
                    Strength = 15,
                    Dexterity = 15,
                    Constitution = 12,
                    Intelligence = 20,
                    Wisdom = 10,
                    Charisma = 8,
                    XP = 0,
                    AC = 13,
                    Initiative = 3,
                    Speed = 30,
                    Age = 38,
                    Height = 68,
                    Weight = 150,
                    GP = 50,
                    Rations = 8,
                    Visible = true,
                    PartyPosition = 5,
                    IsEnabled = true,
                    PlayerTile = TileType.Druid1,
                    Weapons = new List<FantasyWeapon> { weaponNone, weaponMace },
                    Armor = new List<FantasyArmor> { armorNone, armorCloth },
                    CanCastSpells = true
                },
                new FantasyPlayer
                {
                    Name = "Julia",
                    Level = 1,
                    HP = 16,
                    MP = 3,
                    Strength = 20,
                    Dexterity = 15,
                    Constitution = 12,
                    Intelligence = 15,
                    Wisdom = 10,
                    Charisma = 8,
                    XP = 0,
                    AC = 13,
                    Initiative = 3,
                    Speed = 30,
                    Age = 38,
                    Height = 68,
                    Weight = 150,
                    GP = 50,
                    Rations = 8,
                    Visible = true,
                    PartyPosition = 6,
                    IsEnabled = true,
                    PlayerTile = TileType.Tinker1,
                    Weapons = new List<FantasyWeapon> { weaponNone, weaponSword },
                    Armor = new List<FantasyArmor> { armorNone, armorLeather },
                    CanCastSpells = true
                },
                new FantasyPlayer
                {
                    Name = "Mariah",
                    Level = 1,
                    HP = 16,
                    MP = 3,
                    Strength = 10,
                    Dexterity = 10,
                    Constitution = 12,
                    Intelligence = 25,
                    Wisdom = 10,
                    Charisma = 8,
                    XP = 0,
                    AC = 13,
                    Initiative = 3,
                    Speed = 30,
                    Age = 38,
                    Height = 68,
                    Weight = 150,
                    GP = 50,
                    Rations = 8,
                    Visible = true,
                    PartyPosition = 7,
                    IsEnabled = true,
                    PlayerTile = TileType.Mage1,
                    Weapons = new List<FantasyWeapon> { weaponNone, weaponDagger },
                    Armor = new List<FantasyArmor> { armorNone, armorCloth },
                    CanCastSpells = true
                },
                new FantasyPlayer
                {
                    Name = "Geoffrey",
                    Level = 1,
                    HP = 16,
                    MP = 3,
                    Strength = 25,
                    Dexterity = 15,
                    Constitution = 12,
                    Intelligence = 10,
                    Wisdom = 10,
                    Charisma = 8,
                    XP = 0,
                    AC = 13,
                    Initiative = 3,
                    Speed = 30,
                    Age = 38,
                    Height = 68,
                    Weight = 150,
                    GP = 50,
                    Rations = 8,
                    Visible = true,
                    PartyPosition = 8,
                    IsEnabled = true,
                    PlayerTile = TileType.Fighter1,
                    Weapons = new List<FantasyWeapon> { weaponNone, weaponSword },
                    Armor = new List<FantasyArmor> { armorNone, armorChainmail },
                    CanCastSpells = false
                }
            };
 
            return fantasyPlayers;
        }
    }
}