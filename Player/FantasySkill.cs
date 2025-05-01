using System;

namespace Ultima45Monogame
{
    [Serializable]
    public class FantasySkill
    {
        FantasySkill() 
        {
        }

        // Unique identifier for the skill
        public int ID { get; set; }

        // Skill name (e.g., "Acrobatics", "Stealth", "Arcana")
        public string Name { get; set; }

        // Related ability (e.g., "Dexterity", "Intelligence")
        public string RelatedAbility { get; set; }

        // Whether the player is proficient in this skill
        public bool IsProficient { get; set; }

        // Skill modifier (calculated based on ability score and proficiency)
        public int Modifier { get; set; }

        // Description of the skill
        public string Description { get; set; }

        // Constructor
        public FantasySkill(int id, string name, string relatedAbility, bool isProficient, int modifier, string description)
        {
            ID = id;
            Name = name;
            RelatedAbility = relatedAbility;
            IsProficient = isProficient;
            Modifier = modifier;
            Description = description;
        }

        // Override ToString for easy display
        public override string ToString()
        {
            return $"{Name} (Related Ability: {RelatedAbility}, Modifier: {Modifier}, Proficient: {IsProficient})";
        }
    }
}
