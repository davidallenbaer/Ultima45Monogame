using System;
using System.Collections.Generic;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    [Serializable]
    public class FantasySpell
    {
        public enum SpellType
        {
            Combat,
            NonCombat,
            Both
        }

        public enum SpellTargetChoice
        {
            None,
            ChooseDirection,
            ChoosePlayer,
            ChooseMoonGate
        }

        FantasySpell() 
        { 
        }

        // Unique identifier for the spell
        public int ID { get; set; }

        // Spell name
        public string Name { get; set; }

        // Spell level (e.g., 0 for cantrips, 1-9 for leveled spells)
        public int Level { get; set; }

        // Spell school (e.g., Evocation, Conjuration, etc.)
        public string School { get; set; }

        // Casting time (e.g., "1 action", "1 bonus action", "1 minute")
        public string CastingTime { get; set; }

        // Range of the spell (e.g., "30 feet", "Touch")
        public string Range { get; set; }

        // Components required (e.g., "V, S, M")
        public string[] Components { get; set; } = Array.Empty<string>();

        // Duration of the spell (e.g., "Concentration, up to 1 minute")
        public string Duration { get; set; }

        // Description of the spell's effects
        public string Description { get; set; }

        // Cost in gold pieces
        public int Cost { get; set; }

        // Type of spell: Combat, NonCombat, or Both
        public SpellType Type { get; set; } = SpellType.Both;

        // Target choice for the spell
        public SpellTargetChoice TargetChoice { get; set; } = SpellTargetChoice.None;

        // Constructor
        public FantasySpell(int id, string name, int level, string school, string castingTime, string range, string[] components, string duration, string description, int cost, SpellType type = SpellType.Both, SpellTargetChoice targetchoice = SpellTargetChoice.None)
        {
            ID = id;
            Name = name;
            Level = level;
            School = school;
            CastingTime = castingTime;
            Range = range;
            Components = components;
            Duration = duration;
            Description = description;
            Cost = cost;
            Type = type;
            TargetChoice = targetchoice;
        }

        // Override ToString for easy display
        public override string ToString()
        {
            return $"{Name} (Level {Level}, {School}) - {CastingTime}, {Range}, {Duration}";
        }
    }
}
