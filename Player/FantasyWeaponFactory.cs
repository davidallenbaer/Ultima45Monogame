using System;
using System.Collections.Generic;

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
                name: "Sword",
                type: FantasyWeapon.WeaponType.Melee,
                dmgDice: "1d8",
                dmgType: FantasyWeapon.DamageType.Slashing,
                rangeNormal: 0,
                rangeMax: 0,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 2,
                name: "Sling",
                type: FantasyWeapon.WeaponType.Ranged,
                dmgDice: "1d6",
                dmgType: FantasyWeapon.DamageType.Bludgeoning,
                rangeNormal: 10,
                rangeMax: 10,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 3,
                name: "Mace",
                type: FantasyWeapon.WeaponType.Melee,
                dmgDice: "1d8",
                dmgType: FantasyWeapon.DamageType.Bludgeoning,
                rangeNormal: 1,
                rangeMax: 1,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 4,
                name: "Dagger",
                type: FantasyWeapon.WeaponType.Melee,
                dmgDice: "1d4",
                dmgType: FantasyWeapon.DamageType.Slashing,
                rangeNormal: 1,
                rangeMax: 1,
                weight: 3.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            // Add more weapons here...

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
    }
}
