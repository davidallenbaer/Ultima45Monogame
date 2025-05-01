using System.Collections.Generic;

namespace Ultima45Monogame
{
    public static class FantasyClassFactory
    {
        public static List<FantasyClass> GetAllFantasyClass()
        {
            return new List<FantasyClass>
            {
                new FantasyClass(1,"Barbarian", "d12", "Strength", new List<string>{ "Strength", "Constitution" },
                    "A fierce warrior of primitive background who can enter a battle rage."),

                new FantasyClass(2,"Bard", "d8", "Charisma", new List<string>{ "Dexterity", "Charisma" },
                    "An inspiring magician whose power echoes the music of creation."),

                new FantasyClass(3,"Cleric", "d8", "Wisdom", new List<string>{ "Wisdom", "Charisma" },
                    "A priestly champion who wields divine magic in service of a higher power."),

                new FantasyClass(4,"Druid", "d8", "Wisdom", new List<string>{ "Intelligence", "Wisdom" },
                    "A priest of the Old Faith, wielding the powers of nature."),

                new FantasyClass(5,"Fighter", "d10", "Strength or Dexterity", new List<string>{ "Strength", "Constitution" },
                    "A master of martial combat, skilled with a variety of weapons and armor."),

                new FantasyClass(6,"Monk", "d8", "Dexterity & Wisdom", new List<string>{ "Strength", "Dexterity" },
                    "A master of martial arts, harnessing the power of the body in pursuit of physical and spiritual perfection."),

                new FantasyClass(7,"Paladin", "d10", "Strength & Charisma", new List<string>{ "Wisdom", "Charisma" },
                    "A holy warrior bound to a sacred oath."),

                new FantasyClass(8,"Ranger", "d10", "Dexterity & Wisdom", new List<string>{ "Strength", "Dexterity" },
                    "A warrior who combats threats on the edges of civilization."),

                new FantasyClass(9,"Rogue", "d8", "Dexterity", new List<string>{ "Dexterity", "Intelligence" },
                    "A scoundrel who uses stealth and trickery to overcome obstacles and enemies."),

                new FantasyClass(10,"Sorcerer", "d6", "Charisma", new List<string>{ "Constitution", "Charisma" },
                    "A spellcaster who draws on inherent magic from a gift or bloodline."),

                new FantasyClass(11,"Warlock", "d8", "Charisma", new List<string>{ "Wisdom", "Charisma" },
                    "A wielder of magic that is derived from a bargain with an extraplanar entity."),

                new FantasyClass(12,"Wizard", "d6", "Intelligence", new List<string>{ "Intelligence", "Wisdom" },
                    "A scholarly magic-user capable of manipulating the structures of reality.")
            };
        }
    }
}
