using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultima45Monogame
{
    [Serializable]
    public class FantasyArmor
    {
        public FantasyArmor() 
        {
        }

        // Unique identifier for the armor
        public int ID { get; set; }
        
        // Armor name (e.g., "Chain Mail", "Leather Armor", "Plate Armor")
        public string Name { get; set; }

        // Armor type (e.g., "Light", "Medium", "Heavy", "Shield")
        public string Type { get; set; }

        // Base Armor Class (AC) provided by the armor
        public int BaseAC { get; set; }

        // Maximum Dexterity modifier allowed (if applicable)
        public int MaxDexBonus { get; set; }

        // Whether the armor imposes disadvantage on stealth checks
        public bool DisadvantageOnStealth { get; set; }

        // Armor weight in pounds
        public float Weight { get; set; }

        // Whether the armor is magical
        public bool IsMagical { get; set; }

        // Indicates if the armor is currently equipped
        public bool IsEquipped { get; set; } = false;

        // Cost in gold pieces
        public int Cost { get; set; } = 0; 

        // Constructor
        public FantasyArmor(int id, string name, string type, int baseAC, int maxDexBonus, bool disadvantageOnStealth, float weight, bool isMagical, bool isEquipped, int cost)
        {
            ID = id;
            Name = name;
            Type = type;
            BaseAC = baseAC;
            MaxDexBonus = maxDexBonus;
            DisadvantageOnStealth = disadvantageOnStealth;
            Weight = weight;
            IsMagical = isMagical;
            IsEquipped = isEquipped;
            Cost = cost;
        }

        // Override ToString for easy display
        public override string ToString()
        {
            return $"{Name} ({Type}) - Base AC: {BaseAC}, Max Dex Bonus: {MaxDexBonus}, Stealth Disadvantage: {DisadvantageOnStealth}, Weight: {Weight} lbs, Magical: {IsMagical}";
        }
    }
}
