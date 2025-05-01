using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    [Serializable]
    public class FantasyPlayer
    {
        // Player stats
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public int HP { get; set; } = 100;
        public int MaxHP { get; set; } = 100;
        public int MP { get; set; } = 50;
        public int MaxMP { get; set; } = 50;
        public int Strength { get; set; } = 10;
        public int Dexterity { get; set; } = 10;
        public int Constitution { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Wisdom { get; set; } = 10;
        public int Charisma { get; set; } = 10;
        public int XP { get; set; } = 0;
        public int AC { get; set; } = 0;
        public int Initiative { get; set; } = 0;
        public int Speed { get; set; } = 5;

        public int Age { get; set; } = 20; // in years
        public int Height { get; set; } = 72; // in inches 
        public int Weight { get; set; } = 125; // in pounds
        public int Eyes { get; set; }
        public int Skin { get; set; }
        public int Hair { get; set; }
        public int GP { get; set; } = 0;
        public int Rations { get; set; } = 0;

        public bool Enabled { get; set; } = false;

        // List of weapons
        [XmlArray("Weapons")]
        [XmlArrayItem("Weapon")]
        public List<FantasyWeapon> Weapons { get; set; }

        // List of spells
        [XmlArray("Spells")]
        [XmlArrayItem("Spell")]
        public List<FantasySpell> Spells { get; set; }

        // List of classes
        [XmlArray("Classes")]
        [XmlArrayItem("Class")]
        public List<FantasyClass> Classes { get; set; }

        // List of equipment
        [XmlArray("Equipment")]
        [XmlArrayItem("EquipmentItem")]
        public List<FantasyEquipment> Equipment { get; set; }

        // List of skills
        [XmlArray("Skills")]
        [XmlArrayItem("Skill")]
        public List<FantasySkill> Skills { get; set; }

        // List of feats
        [XmlArray("Feats")]
        [XmlArrayItem("Feat")]
        public List<FantasyFeat> Feats { get; set; }

        // List of armor
        [XmlArray("Armors")]
        [XmlArrayItem("Armor")]
        public List<FantasyArmor> Armor { get; set; }

        // Constructor
        public FantasyPlayer()
        {
            Weapons = new List<FantasyWeapon>();
            Armor = new List<FantasyArmor>();
            Classes = new List<FantasyClass>();
            Skills = new List<FantasySkill>();
            Feats = new List<FantasyFeat>();
            Spells = new List<FantasySpell>();
            Equipment = new List<FantasyEquipment>();

        }

    }
}
