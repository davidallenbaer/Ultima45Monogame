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
                rangeNormal: 0,
                rangeMax: 0,
                weight: 0.0f,
                isMagical: false,
                isEquiped: false,
                cost: 0
            ));

            weapons.Add(new FantasyWeapon(
                id: 1,
                name: "Longsword",
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
