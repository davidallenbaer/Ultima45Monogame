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
                // Light Armor
                new FantasyArmor(1,"Padded Armor", "Light", 11, 99, true, 8f, false),
                new FantasyArmor(2,"Leather Armor", "Light", 11, 99, false, 10f, false),
                new FantasyArmor(3,"Studded Leather Armor", "Light", 12, 99, false, 13f, false),

                // Medium Armor
                new FantasyArmor(4,"Hide Armor", "Medium", 12, 2, false, 12f, false),
                new FantasyArmor(5,"Chain Shirt", "Medium", 13, 2, false, 20f, false),
                new FantasyArmor(6,"Scale Mail", "Medium", 14, 2, true, 45f, false),
                new FantasyArmor(7,"Breastplate", "Medium", 14, 2, false, 20f, false),
                new FantasyArmor(8,"Half Plate", "Medium", 15, 2, true, 40f, false),

                // Heavy Armor
                new FantasyArmor(9,"Ring Mail", "Heavy", 14, 0, true, 40f, false),
                new FantasyArmor(10,"Chain Mail", "Heavy", 16, 0, true, 55f, false),
                new FantasyArmor(11,"Splint", "Heavy", 17, 0, true, 60f, false),
                new FantasyArmor(12, "Plate", "Heavy", 18, 0, true, 65f, false),

                // Shield
                new FantasyArmor(13, "Shield", "Shield", 2, 0, false, 6f, false),
            };
        }
    }
}