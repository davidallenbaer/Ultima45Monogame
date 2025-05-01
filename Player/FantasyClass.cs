using System;
using System.Collections.Generic;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    [Serializable]
    public class FantasyClass
    {
        public FantasyClass()
        {
        }

        // Unique identifier for the class
        public int ID { get; set; }

        // Class name (e.g., Fighter, Wizard, Cleric)
        public string Name { get; set; }

        // Hit die type (e.g., d6, d8, d10)
        public string HitDie { get; set; }

        // Primary ability for the class (e.g., Strength, Intelligence)
        public string PrimaryAbility { get; set; }

        // Saving throw proficiencies (e.g., Strength, Constitution)
        public List<string> SavingThrows { get; set; }

        // Description of the class
        public string Description { get; set; }

        // Constructor
        public FantasyClass(int id, string name, string hitDie, string primaryAbility, List<string> savingThrows, string description)
        {
            ID = id;
            Name = name;
            HitDie = hitDie;
            PrimaryAbility = primaryAbility;
            SavingThrows = savingThrows;
            Description = description;
        }

        // Override ToString for easy display
        public override string ToString()
        {
            return $"{Name} (Hit Die: {HitDie}, Primary Ability: {PrimaryAbility})";
        }
    }
}
