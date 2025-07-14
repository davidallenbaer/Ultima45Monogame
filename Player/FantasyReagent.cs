using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultima45Monogame.Player
{
    [Serializable]
    public class FantasyReagent
    {
        public FantasyReagent()
        {
        }

        // Unique identifier for the reagent
        public int ID { get; set; }

        // Reagent name
        public string Name { get; set; }

        // Cost in gold pieces
        public int Cost { get; set; } = 0;

        // Description of the reagent
        public string Description { get; set; } = "";

        // Constructor
        public FantasyReagent(int id, string name, string description, int cost)
        {
            ID = id;
            Name = name;
            Description = description;
            Cost = cost;
        }

        // Override ToString for easy display
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
