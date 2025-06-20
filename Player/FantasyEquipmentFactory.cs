using System.Collections.Generic;

namespace Ultima45Monogame
{
    public static class FantasyEquipmentFactory
    {
        public static List<FantasyEquipment> GetStandardEquipment()
        {
            return new List<FantasyEquipment>
            {
                // Adventuring Gear (Non-magical)
                new FantasyEquipment(1,"Backpack", "A sturdy leather pack to carry your gear.", 5f, 1, false, 0),
                new FantasyEquipment(2,"Bedroll", "A simple bedroll for sleeping outdoors.", 5f, 1, false, 0),
                new FantasyEquipment(3,"Rope (50 feet)", "50 feet of hempen rope.", 10f, 1, false, 0),
                new FantasyEquipment(4,"Rations (1 day)", "Preserved food and water for one day.", 2f, 1, false, 0),
                new FantasyEquipment(5,"Torch", "A wooden torch that burns for 1 hour.", 1f, 5, false, 0),
                new FantasyEquipment(6,"Waterskin", "A leather pouch for holding water.", 5f, 1, false, 0),
                new FantasyEquipment(7,"Tinderbox", "Used to light a fire.", 1f, 1, false, 0),
                new FantasyEquipment(8,"Lantern (Hooded)", "Provides bright light in a 30-foot radius.", 2f, 1, false, 0),
                new FantasyEquipment(9,"Flask of Oil", "Can be used to fuel lanterns or as a weapon.", 1f, 1, false, 0),
                new FantasyEquipment(10,"Grappling Hook", "A hook tied to a rope for climbing.", 4f, 1, false, 0),
                new FantasyEquipment(11,"Crowbar", "A metal bar used for prying open doors or crates.", 5f, 1, false, 0),
                new FantasyEquipment(12,"Hammer", "A small metal tool used with nails or spikes.", 3f, 1, false, 0),
                new FantasyEquipment(13,"Pitons (x10)", "Metal spikes used for climbing or securing ropes.", 2.5f, 10, false, 0),
                new FantasyEquipment(14,"Whetstone", "Used to keep blades sharp.", 1f, 1, false, 0),
                new FantasyEquipment(15,"Healer's Kit", "Contains bandages and salves; can stabilize a dying creature.", 3f, 1, false, 0),
                new FantasyEquipment(16,"Spellbook", "A book containing prepared spells.", 3f, 1, false, 0),

                // Magical Items (Iconic Examples)
                new FantasyEquipment(17,"Bag of Holding", "A magical bag that holds far more than its size implies.", 15f, 1, true, 0),
                new FantasyEquipment(18,"Immovable Rod", "A magical rod that can be fixed in space.", 10f, 1, true, 0),
                new FantasyEquipment(19,"Driftglobe", "A small globe of light that can float and follow you.", 1f, 1, true, 0),
                new FantasyEquipment(20,"Sending Stones", "A pair of magical stones used for communication over long distances.", 1f, 2, true, 0),
            };
        }
    }
}
