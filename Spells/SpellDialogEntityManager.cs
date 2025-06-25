using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Ultima45Monogame.Player;

namespace Ultima45Monogame.Spells
{
    public class SpellDialogEntityManager
    {
        private readonly Ultima4SaveGameVariables _saveGame;
        private readonly List<FantasyPlayer> _players;
        private readonly List<Spell> _spells;

        public SpellDialogTree DialogTree { get; private set; }

        public SpellDialogEntityManager(Ultima4SaveGameVariables saveGame, List<FantasyPlayer> players)
        {
            _saveGame = saveGame;
            _players = players;
            _spells = LoadSpells("Spells/spells.json");
            DialogTree = BuildDialogTree();
        }

        private List<Spell> LoadSpells(string path)
        {
            var json = File.ReadAllText(path);
            var doc = JsonDocument.Parse(json);
            var spells = new List<Spell>();
            foreach (var element in doc.RootElement.GetProperty("spells").EnumerateArray())
            {
                spells.Add(new Spell
                {
                    SpellId = element.GetProperty("spellid").GetString(),
                    SpellName = element.GetProperty("spellname").GetString(),
                    Description = element.GetProperty("description").GetString(),
                    RequiredReagents = element.GetProperty("requiredreagents").EnumerateArray().Select(x => x.GetString()).ToList(),
                    SpellTargetChoice = element.GetProperty("spelltargetchoice").EnumerateArray().Select(x => x.GetString()).ToList()
                });
            }
            return spells;
        }

        private SpellDialogTree BuildDialogTree()
        {
            // Step 1: List enabled players who can cast spells
            var enabledPlayers = _players.Where(p => p.IsEnabled && p.CanCastSpells).ToList();
            var root = new SpellDialogNode("Choose a spellcaster:", enabledPlayers.Select(p =>
                new SpellDialogOption(p.Name, () => BuildSpellListNode(p))
            ).ToList());

            return new SpellDialogTree(root);
        }

        private SpellDialogNode BuildSpellListNode(FantasyPlayer caster)
        {
            // Step 2: List spells the player can cast (has reagents)
            var availableSpells = _spells.Where(spell => HasReagents(caster, spell.RequiredReagents)).ToList();
            var spellOptions = availableSpells.Select(spell =>
                new SpellDialogOption($"{spell.SpellName} - {spell.Description}", () => BuildTargetChoiceNode(caster, spell))
            ).ToList();

            if (!spellOptions.Any())
                spellOptions.Add(new SpellDialogOption("(No available spells)", null));

            return new SpellDialogNode("Choose a spell:", spellOptions);
        }

        private SpellDialogNode BuildTargetChoiceNode(FantasyPlayer caster, Spell spell)
        {
            // Step 3: Handle spelltargetchoice
            if (spell.SpellTargetChoice.Contains("ChooseDirection"))
            {
                var directions = new[] { "North", "South", "East", "West" };
                var dirOptions = directions.Select(dir =>
                    new SpellDialogOption(dir, () => { CastSpell(caster, spell, dir); return null; })
                ).ToList();
                return new SpellDialogNode("Choose a direction:", dirOptions);
            }
            else if (spell.SpellTargetChoice.Contains("ChoosePlayer"))
            {
                var enabledPlayers = _players.Where(p => p.IsEnabled).ToList();
                var playerOptions = enabledPlayers.Select(p =>
                    new SpellDialogOption(p.Name, () => { CastSpell(caster, spell, p); return null; })
                ).ToList();
                return new SpellDialogNode("Choose a player:", playerOptions);
            }
            else // "All", "Immediate", or "None"
            {
                return new SpellDialogNode($"Cast {spell.SpellName}?", new List<SpellDialogOption>
                {
                    new SpellDialogOption("Cast", () => { CastSpell(caster, spell, null); return null; })
                });
            }
        }

        private bool HasReagents(FantasyPlayer caster, List<string> requiredReagents)
        {
            // Check _saveGame for each reagent
            foreach (var reagent in requiredReagents)
            {
                if (!_saveGame.HasReagent(reagent))
                    return false;
            }
            return true;
        }

        private void CastSpell(FantasyPlayer caster, Spell spell, object target)
        {
            // Implement your spell-casting logic here
            // Example: SpellSystem.Cast(caster, spell, target);
        }

        // Helper class for spell data
        private class Spell
        {
            public string SpellId { get; set; }
            public string SpellName { get; set; }
            public string Description { get; set; }
            public List<string> RequiredReagents { get; set; }
            public List<string> SpellTargetChoice { get; set; }
        }
    }
}