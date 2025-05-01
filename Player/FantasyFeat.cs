using System;

namespace Ultima45Monogame
{
    [Serializable]
    public class FantasyFeat
    {
        public FantasyFeat() 
        {
        }

        // Unique identifier for the feat
        public int ID { get; set; }

        // Feat name (e.g., "Sharpshooter", "Great Weapon Master")
        public string Name { get; set; }

        // Feat description
        public string Description { get; set; }

        // Any prerequisites for the feat (e.g., "Dexterity 13+", "Proficiency with martial weapons")
        public string Prerequisites { get; set; }

        // Whether the feat is active or passive
        public bool IsActive { get; set; }

        // Constructor
        public FantasyFeat(int id, string name, string description, string prerequisites, bool isActive)
        {
            ID = id;
            Description = description;
            Prerequisites = prerequisites;
            IsActive = isActive;
        }

        // Override ToString for easy display
        public override string ToString()
        {
            return $"{Name} - {Description} (Prerequisites: {Prerequisites}, Active: {IsActive})";
        }
    }
}
