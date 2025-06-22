using System.Collections.Generic;
using Ultima45Monogame;

namespace Ultima45Monogame
{
    public static class FantasyArmorFactory
    {
        public static List<FantasyArmor> GetAllFantasyArmor()
        {
            return new List<FantasyArmor>
            {
                // No Armor
                new FantasyArmor(0,"None", "Light", 10, 99, true, 6f, false, false, 0),

                // Light Armor
                new FantasyArmor(1,"Cloth", "Light", 10, 99, true, 7f, false, false, 0),
                new FantasyArmor(2,"Padded Armor", "Light", 11, 99, true, 8f, false, false, 0),
                new FantasyArmor(3,"Leather Armor", "Light", 11, 99, false, 10f, false, false, 0),
                new FantasyArmor(4,"Studded Leather Armor", "Light", 12, 99, false, 13f, false, false, 0),

                // Medium Armor
                new FantasyArmor(5,"Hide Armor", "Medium", 12, 2, false, 12f, false, false, 0),
                new FantasyArmor(6,"Chain Shirt", "Medium", 13, 2, false, 20f, false, false, 0),
                new FantasyArmor(7,"Scale Mail", "Medium", 14, 2, true, 45f, false, false, 0),
                new FantasyArmor(8,"Breastplate", "Medium", 14, 2, false, 20f, false, false, 0),
                new FantasyArmor(9,"Half Plate", "Medium", 15, 2, true, 40f, false, false, 0),

                // Heavy Armor
                new FantasyArmor(10,"Ring Mail", "Heavy", 14, 0, true, 40f, false, false, 0),
                new FantasyArmor(11,"Chain Mail", "Heavy", 16, 0, true, 55f, false, false, 0),
                new FantasyArmor(12,"Splint", "Heavy", 17, 0, true, 60f, false, false, 0),
                new FantasyArmor(13, "Plate", "Heavy", 18, 0, true, 65f, false, false, 0),

                // Shield
                new FantasyArmor(14, "Shield", "Shield", 2, 0, false, 6f, false, false, 0),
            };
        }

        internal static FantasyArmor GetFantasyArmor(int armorID)
        {
            foreach (var armor in GetAllFantasyArmor())
            {
                if (armor.ID == armorID)
                    return armor;
            }
            return null;
        }

    }
}