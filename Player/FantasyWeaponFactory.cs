using MonoGame.Extended;
using MonoGame.Extended.ECS;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    public static class FantasyWeaponFactory
    {
        public static List<FantasyWeapon> GetAllWeapons()
        {
            var weapons = new List<FantasyWeapon>();

            // Example weapon entry
            weapons.Add(new FantasyWeapon(
                id: 0,
                name: "None",
                type: FantasyWeapon.WeaponType.Melee,
                dmgDice: "1d4",
                dmgType: FantasyWeapon.DamageType.Bludgeoning,
                rangeNormal: 1,
                rangeMax: 1,
                weight: 0.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 1,
                name: "Flaming Oil",
                type: FantasyWeapon.WeaponType.Ranged,
                dmgDice: "8d8",
                dmgType: FantasyWeapon.DamageType.Fire,
                rangeNormal: 0,
                rangeMax: 0,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 2,
                name: "Dagger",
                type: FantasyWeapon.WeaponType.Ranged,
                dmgDice: "4d6",
                dmgType: FantasyWeapon.DamageType.Piercing,
                rangeNormal: 0,
                rangeMax: 0,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 3,
                name: "Sling",
                type: FantasyWeapon.WeaponType.Ranged,
                dmgDice: "4d8",
                dmgType: FantasyWeapon.DamageType.Piercing,
                rangeNormal: 0,
                rangeMax: 0,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 4,
                name: "Bow",
                type: FantasyWeapon.WeaponType.Ranged,
                dmgDice: "4d10",
                dmgType: FantasyWeapon.DamageType.Piercing,
                rangeNormal: 0,
                rangeMax: 0,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 5,
                name: "Crossbow",
                type: FantasyWeapon.WeaponType.Ranged,
                dmgDice: "7d8",
                dmgType: FantasyWeapon.DamageType.Piercing,
                rangeNormal: 0,
                rangeMax: 0,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 6,
                name: "Magic Bow",
                type: FantasyWeapon.WeaponType.Ranged,
                dmgDice: "8d10",
                dmgType: FantasyWeapon.DamageType.Piercing,
                rangeNormal: 0,
                rangeMax: 0,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 7,
                name: "Magic Axe",
                type: FantasyWeapon.WeaponType.Ranged,
                dmgDice: "8d12",
                dmgType: FantasyWeapon.DamageType.Piercing,
                rangeNormal: 0,
                rangeMax: 0,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 8,
                name: "Magic Axe",
                type: FantasyWeapon.WeaponType.Ranged,
                dmgDice: "8d12",
                dmgType: FantasyWeapon.DamageType.Piercing,
                rangeNormal: 0,
                rangeMax: 0,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 9,
                name: "Magic Wand",
                type: FantasyWeapon.WeaponType.Ranged,
                dmgDice: "8d20",
                dmgType: FantasyWeapon.DamageType.Piercing,
                rangeNormal: 0,
                rangeMax: 0,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            #region Melee Weapons

            weapons.Add(new FantasyWeapon(
                id: 11,
                name: "Staff",
                type: FantasyWeapon.WeaponType.Melee,
                dmgDice: "2d8",
                dmgType: FantasyWeapon.DamageType.Bludgeoning,
                rangeNormal: 1,
                rangeMax: 1,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 12,
                name: "Mace",
                type: FantasyWeapon.WeaponType.Melee,
                dmgDice: "5d8",
                dmgType: FantasyWeapon.DamageType.Bludgeoning,
                rangeNormal: 1,
                rangeMax: 1,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 13,
                name: "Axe",
                type: FantasyWeapon.WeaponType.Melee,
                dmgDice: "6d8",
                dmgType: FantasyWeapon.DamageType.Slashing,
                rangeNormal: 1,
                rangeMax: 1,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 14,
                name: "Sword",
                type: FantasyWeapon.WeaponType.Melee,
                dmgDice: "8d8",
                dmgType: FantasyWeapon.DamageType.Slashing,
                rangeNormal: 1,
                rangeMax: 1,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 15,
                name: "Halberd",
                type: FantasyWeapon.WeaponType.Melee,
                dmgDice: "12d8",
                dmgType: FantasyWeapon.DamageType.Slashing,
                rangeNormal: 1,
                rangeMax: 1,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 16,
                name: "Magic Sword",
                type: FantasyWeapon.WeaponType.Melee,
                dmgDice: "16d8",
                dmgType: FantasyWeapon.DamageType.Slashing,
                rangeNormal: 1,
                rangeMax: 1,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 17,
                name: "Mystic Sword",
                type: FantasyWeapon.WeaponType.Melee,
                dmgDice: "32d8",
                dmgType: FantasyWeapon.DamageType.Slashing,
                rangeNormal: 1,
                rangeMax: 1,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            #endregion

            return weapons;
        }

        internal static FantasyWeapon GetFantasyWeapon(int weaponID)
        {
            foreach (var weapon in GetAllWeapons())
            {
                if (weapon.ID == weaponID)
                    return weapon;
            }
            return null;
        }

        internal static FantasyWeapon GetFantasyWeapon(string weaponName)
        {
            foreach (var weapon in GetAllWeapons())
            {
                if (weapon.Name == weaponName)
                    return weapon;
            }
            return null;
        }

        internal static List<FantasyWeapon> GetFantasyWeaponsByTownMerchant(Maps map, int townEntityIndex)
        {
            List<FantasyWeapon> merchantWeapons = new List<FantasyWeapon>();

            if (map == Maps.U4MapNone)
            {
                return null;
            }
            else if (map == Maps.U4MapBritain && townEntityIndex == 1001)
            {
                //Britain Merchant Weapons
                merchantWeapons.Add(GetFantasyWeapon("Staff"));
                merchantWeapons.Add(GetFantasyWeapon("Dagger"));
                merchantWeapons.Add(GetFantasyWeapon("Sling"));
                merchantWeapons.Add(GetFantasyWeapon("Sword"));
            }

            return merchantWeapons;
        }

    }
}
