using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultima45Monogame
{
    [Serializable]
    public class FantasyWeapon
    {
        public FantasyWeapon() 
        {
        }

        public enum WeaponType
        {
            Melee,
            Ranged,
            Thrown
        }

        public enum DamageType
        {
            Slashing,
            Piercing,
            Bludgeoning,
            Fire,
            Cold,
            Lightning,
            Acid,
            Poison,
            Psychic,
            Radiant,
            Necrotic,
            Thunder,
            Force
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public WeaponType Type { get; set; }
        public string DmgDice { get; set; } // e.g., "1d8", "2d6"
        public DamageType DmgType { get; set; }
        public int RangeNormal { get; set; } // in feet
        public int RangeMax { get; set; } // in feet
        public float Weight { get; set; } // in pounds
        public bool IsMagical { get; set; }
        public bool IsEquipped { get; set; } = false; // Indicates if the weapon is currently equipped
        public int Cost { get; set; } = 0; // Cost in gold pieces

        public FantasyWeapon(int id, string name, WeaponType type, string dmgDice, DamageType dmgType, int rangeNormal, int rangeMax, float weight, bool isMagical, bool isEquiped, int cost)
        {
            ID = id;
            Name = name;
            Type = type;
            DmgDice = dmgDice;
            DmgType = dmgType;
            RangeNormal = rangeNormal;
            RangeMax = rangeMax;
            Weight = weight;
            IsMagical = isMagical;
            IsEquipped = isEquiped;
            Cost = cost;
        }
    }
}
