using System;

namespace Ultima45Monogame
{
    [Serializable]
    public class FantasyEquipment
    {
        FantasyEquipment() 
        {
        }

        // Unique identifier for the equipment
        public int ID { get; set; }

        // Item name (e.g., "Bag of Holding", "Rope", "Rations")
        public string Name { get; set; }

        // Item description
        public string Description { get; set; }

        // Item weight in pounds
        public float Weight { get; set; }

        // Quantity of the item
        public int Quantity { get; set; }

        // Whether the item is magical
        public bool IsMagical { get; set; }

        // Constructor
        public FantasyEquipment(int id, string name, string description, float weight, int quantity, bool isMagical)
        {
            ID = id;
            Name = name;
            Description = description;
            Weight = weight;
            Quantity = quantity;
            IsMagical = isMagical;
        }

        // Override ToString for easy display
        public override string ToString()
        {
            return $"{Name} (x{Quantity}) - {Description} [Weight: {Weight} lbs, Magical: {IsMagical}]";
        }
    }
}
