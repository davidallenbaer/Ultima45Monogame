using System.Collections.Generic;

namespace Ultima45Monogame
{
    public static class FantasySkillFactory
    {
        public static List<FantasySkill> GetAllFantasySkill()
        {
            return new List<FantasySkill>
            {
                new FantasySkill(1,"Acrobatics", "Dexterity", false, 0, "Covers balancing, flipping, tumbling, and escaping from restraints."),
                new FantasySkill(2,"Animal Handling", "Wisdom", false, 0, "Calm or control animals, intuit their intentions, or train them."),
                new FantasySkill(3,"Arcana", "Intelligence", false, 0, "Knowledge of magic, magical traditions, and spell lore."),
                new FantasySkill(4,"Athletics", "Strength", false, 0, "Covers climbing, jumping, swimming, and grappling."),
                new FantasySkill(5,"Deception", "Charisma", false, 0, "Lying, misleading others, and disguising intentions."),
                new FantasySkill(6,"History", "Intelligence", false, 0, "Knowledge of past events, ancient civilizations, and lore."),
                new FantasySkill(7,"Insight", "Wisdom", false, 0, "Detecting lies, reading body language, and understanding motives."),
                new FantasySkill(8,"Intimidation", "Charisma", false, 0, "Threatening others through words, actions, or presence."),
                new FantasySkill(9,"Investigation", "Intelligence", false, 0, "Examining clues, solving puzzles, and finding hidden things."),
                new FantasySkill(10,"Medicine", "Wisdom", false, 0, "Stabilizing wounds, diagnosing ailments, or treating the sick."),
                new FantasySkill(11,"Nature", "Intelligence", false, 0, "Knowledge of plants, animals, weather, and terrain."),
                new FantasySkill(12,"Perception", "Wisdom", false, 0, "Spotting, hearing, or otherwise detecting presence of things."),
                new FantasySkill(13,"Performance", "Charisma", false, 0, "Singing, dancing, storytelling, and other entertainments."),
                new FantasySkill(14,"Persuasion", "Charisma", false, 0, "Influencing others through tact, kindness, or charm."),
                new FantasySkill(15,"Religion", "Intelligence", false, 0, "Knowledge of deities, religious rites, and religious lore."),
                new FantasySkill(16,"Sleight of Hand", "Dexterity", false, 0, "Palm objects, plant items on others, or pick pockets."),
                new FantasySkill(17,"Stealth", "Dexterity", false, 0, "Sneaking, hiding, and remaining undetected."),
                new FantasySkill(18,"Survival", "Wisdom", false, 0, "Tracking creatures, finding food, avoiding hazards.")
            };
        }
    }
}
