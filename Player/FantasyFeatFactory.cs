using System.Collections.Generic;

namespace Ultima45Monogame
{
    public static class FantasyFeatFactory
    {
        public static List<FantasyFeat> GetAllFantasyFeat()
        {
            return new List<FantasyFeat>
            {
                new FantasyFeat(1,"Alert", "Always on the lookout for danger, you gain +5 to initiative and can't be surprised while conscious.", "", false),
                new FantasyFeat(2,"Athlete", "Improve physical performance: climb faster, stand from prone with 5 ft movement, and increase Strength or Dexterity by 1.", "Strength or Dexterity 13+", false),
                new FantasyFeat(3,"Actor", "Gain advantage on Deception and Performance when pretending to be someone else, and mimic voices/sounds.", "Charisma 13+", false),
                new FantasyFeat(4,"Charger", "Dash and make a melee attack as a bonus action. Deal extra damage or shove the target.", "", true),
                new FantasyFeat(5,"Crossbow Expert", "Ignore loading property, no disadvantage at melee range, and fire a bonus attack with a hand crossbow.", "", true),
                new FantasyFeat(6,"Defensive Duelist", "Use your reaction to increase your AC against a melee attack.", "Dexterity 13+", true),
                new FantasyFeat(7,"Dual Wielder", "Wield two weapons even if they aren't light, gain +1 AC while dual wielding, draw two weapons at once.", "", false),
                new FantasyFeat(8,"Dungeon Delver", "Advantage on Perception for traps, resist trap damage, and travel cautiously at normal speed.", "", false),
                new FantasyFeat(9,"Durable", "Increase Constitution by 1 and regain more HP when using Hit Dice to heal.", "Constitution 13+", false),
                new FantasyFeat(10,"Elemental Adept", "Ignore resistance to a chosen element and treat 1s as 2s for damage of that type.", "Ability to cast at least one spell", false),
                new FantasyFeat(11,"Grappler", "Gain advantage on attack rolls against creatures you're grappling and can restrain both of you.", "Strength 13+", true),
                new FantasyFeat(12,"Great Weapon Master", "After a crit or kill, make a bonus melee attack. Take -5 to hit for +10 damage.", "", true),
                new FantasyFeat(13,"Healer", "Stabilize a creature to 1 HP with a healer's kit, and restore HP with a use of the kit.", "", true),
                new FantasyFeat(14,"Inspiring Leader", "Give a speech to grant temporary HP to nearby allies.", "Charisma 13+", true),
                new FantasyFeat(15,"Keen Mind", "Always know which way is north, the time, and recall anything seen or heard in the past month.", "Intelligence 13+", false),
                new FantasyFeat(16,"Lucky", "Gain 3 luck points to reroll attack rolls, ability checks, or saving throws.", "", true),
                new FantasyFeat(17,"Mage Slayer", "Attack spellcasters when they cast, impose disadvantage on their saves, and prevent concentration.", "", true),
                new FantasyFeat(18,"Magic Initiate", "Learn two cantrips and one 1st-level spell from a spellcasting class.", "", false),
                new FantasyFeat(19,"Mobile", "Speed increases by 10 ft. Don't provoke opportunity attacks when dashing. Ignore difficult terrain after attacking.", "", false),
                new FantasyFeat(20,"Mounted Combatant", "Gain advantage on attacks against creatures smaller than your mount, and protect your mount.", "", false),
                new FantasyFeat(21,"Observant", "Increase Intelligence or Wisdom by 1. Lip-read and gain +5 to passive Perception and Investigation.", "", false),
                new FantasyFeat(22,"Polearm Master", "Opportunity attacks when enemies enter your reach. Bonus attack with the butt end of your polearm.", "", true),
                new FantasyFeat(23,"Resilient", "Increase one ability score and gain proficiency in its saving throws.", "", false),
                new FantasyFeat(24,"Ritual Caster", "Learn ritual spells to cast without using spell slots.", "Intelligence or Wisdom 13+", false),
                new FantasyFeat(25,"Savage Attacker", "Once per turn, reroll a weapon’s damage and choose the better result.", "", true),
                new FantasyFeat(26,"Sentinel", "Stop enemies with opportunity attacks, prevent disengage, and react to attacks on others.", "", true),
                new FantasyFeat(27,"Sharpshooter", "Ignore long range penalties and cover, and take -5 to hit for +10 damage with ranged weapons.", "", true),
                new FantasyFeat(28,"Shield Master", "Add shield bonus to Dex saves, shove with a bonus action, and halve effect damage on a successful Dex save.", "", true),
                new FantasyFeat(29,"Skilled", "Gain proficiency in three skills or tools of your choice.", "", false),
                new FantasyFeat(30,"Skulker", "Remain hidden in dim light, don't reveal location when missing a ranged attack, and ignore dim light penalties.", "Dexterity 13+", false),
                new FantasyFeat(31,"Spell Sniper", "Double the range of spells, ignore cover, and learn a new ranged cantrip.", "Ability to cast a spell", false),
                new FantasyFeat(32,"Tavern Brawler", "Proficient with improvised weapons and unarmed strikes. Grapple as a bonus action.", "Strength or Constitution 13+", true),
                new FantasyFeat(33,"Tough", "Increase hit points by 2 per level.", "", false),
                new FantasyFeat(34,"War Caster", "Advantage on concentration checks, perform somatic components while holding weapons, cast spells as opportunity attacks.", "Ability to cast at least one spell", true),
                new FantasyFeat(35,"Weapon Master", "Gain proficiency with four weapons and increase Strength or Dexterity by 1.", "", false)
            };
        }
    }
}
