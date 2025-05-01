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
                id: 1,
                name: "Longsword",
                type: FantasyWeapon.WeaponType.Melee,
                dmgDice: "1d8",
                dmgType: FantasyWeapon.DamageType.Slashing,
                rangeNormal: 0,
                rangeMax: 0,
                weight: 3.0f,
                isMagical: false
            ));

            // Add more weapons here...

            return weapons;
        }
    }
}
