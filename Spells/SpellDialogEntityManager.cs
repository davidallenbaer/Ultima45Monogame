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

        public SpellDialogTree SpellDialogTree { get; private set; }

        public SpellDialogEntityManager()
        { 
        }

        public SpellDialogEntityManager(Ultima4SaveGameVariables saveGame, List<FantasyPlayer> players)
        {
            _saveGame = saveGame;
            _players = players;
            SpellDialogTree = BuildDialogTree();
        }

        private SpellDialogTree BuildDialogTree()
        {
            // Step 1: List enabled players who can cast spells
            var enabledPlayers = _players.Where(p => p.IsEnabled && p.CanCastSpells).ToList();
            
            var root = new SpellDialogNode("==Cast Spell==", "Choose a spellcaster:", enabledPlayers.Select(p =>
            new SpellDialogOption(p.Name, () => BuildSpellListNode(p))
            ).ToList());

            return new SpellDialogTree(root);
        }

        private SpellDialogNode BuildSpellListNode(FantasyPlayer caster)
        {
            // Step 2: List spells the player can cast (has reagents)
            var availableSpells = caster.Spells.Where(spell => HasReagents(caster, spell.Components)).ToList();
            var spellOptions = availableSpells.Select(spell =>
                new SpellDialogOption($"{spell.Name} - {spell.Description}", () => BuildTargetChoiceNode(caster, spell))
            ).ToList();

            if (!spellOptions.Any())
                spellOptions.Add(new SpellDialogOption("(No available spells)", null));

            return new SpellDialogNode("==Cast Spell==", "Choose a spell:", spellOptions);
        }

        private SpellDialogNode BuildTargetChoiceNode(FantasyPlayer caster, FantasySpell spell)
        {
            // Step 3: Handle spelltargetchoice
            if (spell.TargetChoice == FantasySpell.SpellTargetChoice.ChooseDirection)
            {
                var directions = new[] { "North", "South", "East", "West" };
                var dirOptions = directions.Select(dir =>
                    new SpellDialogOption(dir, () => { CastSpell(caster, spell, dir); return null; })
                ).ToList();
                return new SpellDialogNode("==Cast Spell==", "Choose a direction:", dirOptions);
            }
            else if (spell.TargetChoice == FantasySpell.SpellTargetChoice.ChoosePlayer)
            {
                var enabledPlayers = _players.Where(p => p.IsEnabled).ToList();
                var playerOptions = enabledPlayers.Select(p =>
                    new SpellDialogOption(p.Name, () => { CastSpell(caster, spell, p); return null; })
                ).ToList();
                return new SpellDialogNode("==Cast Spell==", "Choose a player:", playerOptions);
            }
            else // "All", "Immediate", or "None"
            {
                return new SpellDialogNode("==Cast Spell==", $"Cast {spell.Name}?", new List<SpellDialogOption>
                {
                    new SpellDialogOption("Cast", () => { CastSpell(caster, spell, null); return null; })
                });
            }
        }

        private bool HasReagents(FantasyPlayer caster, string[] requiredReagents)
        {
            // Check _saveGame for each reagent
            foreach (var reagent in requiredReagents)
            {
                if (!_saveGame.HasReagent(reagent))
                    return false;
            }
            return true;
        }

        public void CastSpell(FantasyPlayer caster, FantasySpell spell, object target)
        {
            //TODO
            // Implement your spell-casting logic here
            // Example: SpellSystem.Cast(caster, spell, target);
        }

    }
}