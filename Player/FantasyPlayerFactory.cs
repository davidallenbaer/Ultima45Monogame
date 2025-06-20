﻿using System.Collections.Generic;
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
            
            var weaponLongsword = FantasyWeaponFactory.GetFantasyWeapon(1);

            var armorNone = FantasyArmorFactory.GetFantasyArmor(0);

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
                    Enabled = true,
                    PlayerTile = TileType.Avatar,
                    Weapons = new List<FantasyWeapon> { weaponNone, weaponLongsword },
                    Armor = new List<FantasyArmor> { armorNone }
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
                    Enabled = true,
                    PlayerTile = TileType.Bard1,
                    Weapons = new List<FantasyWeapon> { weaponNone },
                    Armor = new List<FantasyArmor> { armorNone }
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
                    Enabled = true,
                    PlayerTile = TileType.Ranger1,
                    Weapons = new List<FantasyWeapon> { weaponNone },
                    Armor = new List<FantasyArmor> { armorNone }
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
                    Enabled = true,
                    PlayerTile = TileType.Paladin1,
                    Weapons = new List<FantasyWeapon> { weaponNone },
                    Armor = new List<FantasyArmor> { armorNone }
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
                    Enabled = true,
                    PlayerTile = TileType.Druid1,
                    Weapons = new List<FantasyWeapon> { weaponNone },
                    Armor = new List<FantasyArmor> { armorNone }
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
                    Enabled = true,
                    PlayerTile = TileType.Tinker1,
                    Weapons = new List<FantasyWeapon> { weaponNone },
                    Armor = new List<FantasyArmor> { armorNone }
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
                    Enabled = true,
                    PlayerTile = TileType.Mage1,
                    Weapons = new List<FantasyWeapon> { weaponNone },
                    Armor = new List<FantasyArmor> { armorNone }
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
                    Enabled = true,
                    PlayerTile = TileType.Fighter1,
                    Weapons = new List<FantasyWeapon> { weaponNone },
                    Armor = new List<FantasyArmor> { armorNone }
                }
            };

            // Ensure each player has a NONE weapon, and it is equipped by default
            foreach (var player in fantasyPlayers)
            {
                if (player.Weapons == null)
                    player.Weapons = new List<FantasyWeapon>();

                var noneWeapon = player.Weapons.Find(w => w.ID == 0);
                if (noneWeapon == null)
                {
                    noneWeapon = FantasyWeaponFactory.GetFantasyWeapon(0);
                    noneWeapon.IsEquipped = true;
                    player.Weapons.Insert(0, noneWeapon);
                }
                else
                {
                    // Set NONE to equipped, and all others to not equipped
                    foreach (var weapon in player.Weapons)
                        weapon.IsEquipped = (weapon.ID == 0);
                }
            }

            // Ensure each player has a NONE armor, and it is equipped by default
            foreach (var player in fantasyPlayers)
            {
                if (player.Armor == null)
                    player.Armor = new List<FantasyArmor>();

                var noneArmor = player.Armor.Find(w => w.ID == 0);
                if (noneArmor == null)
                {
                    noneArmor = FantasyArmorFactory.GetFantasyArmor(0);
                    noneArmor.IsEquipped = true;
                    player.Armor.Insert(0, noneArmor);
                }
                else
                {
                    // Set NONE to equipped, and all others to not equipped
                    foreach (var armor in player.Armor)
                        armor.IsEquipped = (armor.ID == 0);
                }
            }

            return fantasyPlayers;
        }
    }
}