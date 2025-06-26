using System;
using System.Collections.Generic;

namespace Ultima45Monogame
{
    public static class FantasySpellFactory
    {
        public static List<FantasySpell> GetAllSpells()
        {
            var spells = new List<FantasySpell>();

            // Example spell entry
            spells.Add(new FantasySpell(
                id: 1,
                name: "Awaken",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Ginseng", "Garlic"],
                duration: "Instantaneous",
                description: "Wakes a sleeping party member.",
                cost: 0,
                type: FantasySpell.SpellType.Both,
                targetchoice: FantasySpell.SpellTargetChoice.ChoosePlayer
            ));

            spells.Add(new FantasySpell(
                id: 2,
                name: "Blink",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Sulfurous Ash", "Blood Moss"],
                duration: "Instantaneous",
                description: "Teleports the party a short distance on the map.",
                cost: 0,
                type: FantasySpell.SpellType.NonCombat,
                targetchoice: FantasySpell.SpellTargetChoice.ChooseDirection
            ));

            spells.Add(new FantasySpell(
                id: 3,
                name: "Cure",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Ginseng", "Garlic"],
                duration: "Instantaneous",
                description: "Cures poison for one character.",
                cost: 0,
                type: FantasySpell.SpellType.Both,
                targetchoice: FantasySpell.SpellTargetChoice.ChoosePlayer
            ));

            spells.Add(new FantasySpell(
                id: 4,
                name: "Dispel",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Garlic", "Sulfurous Ash"],
                duration: "Instantaneous",
                description: "Dispels enemy summoned creatures, dispel field.",
                cost: 0,
                type: FantasySpell.SpellType.Both,
                targetchoice: FantasySpell.SpellTargetChoice.ChooseDirection
            ));

            spells.Add(new FantasySpell(
                id: 5,
                name: "Energy",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Sulfurous Ash", "Spider Silk"],
                duration: "Instantaneous",
                description: "Creates an energy field barrier.",
                cost: 0,
                type: FantasySpell.SpellType.Both,
                targetchoice: FantasySpell.SpellTargetChoice.ChooseDirection
            ));

            spells.Add(new FantasySpell(
                id: 6,
                name: "Fireball",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Sulfurous Ash", "Black Pearl"],
                duration: "Instantaneous",
                description: "Attacks one enemy with fire.",
                cost: 0,
                type: FantasySpell.SpellType.Combat,
                targetchoice: FantasySpell.SpellTargetChoice.ChooseDirection
            ));

            spells.Add(new FantasySpell(
                id: 7,
                name: "Gate Travel",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Mandrake Root", "Black Pearl"],
                duration: "Instantaneous",
                description: "Teleports the party to a moongate location.",
                cost: 0,
                type: FantasySpell.SpellType.NonCombat,
                targetchoice: FantasySpell.SpellTargetChoice.ChooseMoonGate
            ));

            spells.Add(new FantasySpell(
                id: 8,
                name: "Heal",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Ginseng"],
                duration: "Instantaneous",
                description: "Restores some HP to one character.",
                cost: 0,
                type: FantasySpell.SpellType.Both,
                targetchoice: FantasySpell.SpellTargetChoice.ChoosePlayer
            ));

            spells.Add(new FantasySpell(
                id: 9,
                name: "Iceball",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Sulfurous Ash", "Black Pearl"],
                duration: "Instantaneous",
                description: "Attacks one enemy with ice.",
                cost: 0,
                type: FantasySpell.SpellType.Combat,
                targetchoice: FantasySpell.SpellTargetChoice.ChooseDirection
            ));

            spells.Add(new FantasySpell(
                id: 10,
                name: "Jinx",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Nightshade"],
                duration: "Instantaneous",
                description: "Confuses enemies.",
                cost: 0,
                type: FantasySpell.SpellType.Combat,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            spells.Add(new FantasySpell(
                id: 11,
                name: "Kill",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Nightshade", "Mandrake Root"],
                duration: "Instantaneous",
                description: "Attempts to instantly kill an enemy.",
                cost: 0,
                type: FantasySpell.SpellType.Combat,
                targetchoice: FantasySpell.SpellTargetChoice.ChooseDirection
            ));

            spells.Add(new FantasySpell(
                id: 12,
                name: "Light",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Sulfurous Ash"],
                duration: "Instantaneous",
                description: "Stuns all enemies with a flash, and lights up dark areas.",
                cost: 0,
                type: FantasySpell.SpellType.Both,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            spells.Add(new FantasySpell(
                id: 13,
                name: "Magic Missile",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Sulfurous Ash", "Black Pearl"],
                duration: "Instantaneous",
                description: "Stuns all enemies with a flash, and lights up dark areas.",
                cost: 0,
                type: FantasySpell.SpellType.Combat,
                targetchoice: FantasySpell.SpellTargetChoice.ChooseDirection
            ));

            spells.Add(new FantasySpell(
                id: 14,
                name: "Negate",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Garlic", "Sulfurous Ash"],
                duration: "Instantaneous",
                description: "Cancels enemy spell effects",
                cost: 0,
                type: FantasySpell.SpellType.Combat,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            spells.Add(new FantasySpell(
                id: 15,
                name: "Open",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Sulfurous Ash"],
                duration: "Instantaneous",
                description: "Unlocks chests.",
                cost: 0,
                type: FantasySpell.SpellType.NonCombat,
                targetchoice: FantasySpell.SpellTargetChoice.ChooseDirection
            ));

            spells.Add(new FantasySpell(
                id: 16,
                name: "Protect",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Garlic", "Spider Silk"],
                duration: "Instantaneous",
                description: "Increases party’s defense temporarily.",
                cost: 0,
                type: FantasySpell.SpellType.Combat,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            spells.Add(new FantasySpell(
                id: 17,
                name: "Haste",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Blood Moss", "Spider Silk"],
                duration: "Instantaneous",
                description: "Speeds up party in combat.",
                cost: 0,
                type: FantasySpell.SpellType.Combat,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            spells.Add(new FantasySpell(
                id: 18,
                name: "Resurrection",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Ginseng", "Garlic", "Mandrake Root"],
                duration: "Instantaneous",
                description: "Revives a dead character.",
                cost: 0,
                type: FantasySpell.SpellType.Both,
                targetchoice: FantasySpell.SpellTargetChoice.ChoosePlayer
            ));

            spells.Add(new FantasySpell(
                id: 19,
                name: "Sleep",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Ginseng", "Spider Silk"],
                duration: "Instantaneous",
                description: "Attempts to put enemies to sleep.",
                cost: 0,
                type: FantasySpell.SpellType.Combat,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            spells.Add(new FantasySpell(
                id: 20,
                name: "Tremor",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Sulfurous Ash", "Blood Moss", "Mandrake Root"],
                duration: "Instantaneous",
                description: "Damages all enemies with an earthquake.",
                cost: 0,
                type: FantasySpell.SpellType.Combat,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            spells.Add(new FantasySpell(
                id: 21,
                name: "Turn Undead",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Garlic", "Sulfurous Ash"],
                duration: "Instantaneous",
                description: "Damages all undead creatures.",
                cost: 0,
                type: FantasySpell.SpellType.Combat,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            spells.Add(new FantasySpell(
                id: 22,
                name: "View",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Nightshade", "Blood Moss"],
                duration: "Instantaneous",
                description: "Displays a bird’s-eye view of the overworld.",
                cost: 0,
                type: FantasySpell.SpellType.NonCombat,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            spells.Add(new FantasySpell(
                id: 23,
                name: "Wind",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Blood Moss"],
                duration: "Instantaneous",
                description: "Damages all enemies with Whirlwind.",
                cost: 0,
                type: FantasySpell.SpellType.Combat,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            spells.Add(new FantasySpell(
                id: 24,
                name: "Exit",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Mandrake Root", "Blood Moss"],
                duration: "Instantaneous",
                description: "Exits dungeons, shrines, or combat.",
                cost: 0,
                type: FantasySpell.SpellType.Both,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            spells.Add(new FantasySpell(
                id: 25,
                name: "Up Level",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Blood Moss", "Mandrake Root"],
                duration: "Instantaneous",
                description: "Elevates party one level in dungeon.",
                cost: 0,
                type: FantasySpell.SpellType.NonCombat,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            spells.Add(new FantasySpell(
                id: 26,
                name: "Down Level",
                level: 1,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: ["Nightshade", "Mandrake Root"],
                duration: "Instantaneous",
                description: "Lowers party one level in dungeon.",
                cost: 0,
                type: FantasySpell.SpellType.NonCombat,
                targetchoice: FantasySpell.SpellTargetChoice.None
            ));

            // Add more spells here...

            return spells;
        }
    }
}
