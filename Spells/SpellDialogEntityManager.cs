using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using Ultima45Monogame.Dialogs;
using Ultima45Monogame.Player;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame.Spells
{
    public class SpellDialogEntityManager
    {
        private readonly Ultima4SaveGameVariables _saveGame;
        private readonly List<FantasyPlayer> _players;
        private readonly CastSpellMode _castspellmode;

        public FantasyPlayer SelectedCaster = null;
        public FantasySpell SelectedSpell = null;
        public object SelectedTarget = null; // Could be a direction, player, or null for immediate spells
        
        public SpellDialogTree SpellDialogTree { get; private set; }

        public SpellDialogEntityManager()
        { 
        }

        public SpellDialogEntityManager(Ultima4SaveGameVariables saveGame, List<FantasyPlayer> players, CastSpellMode castspellmode)
        {
            _saveGame = saveGame;
            _players = players;
            _castspellmode = castspellmode;
            SpellDialogTree = BuildDialogTree();
        }

        private SpellDialogTree BuildDialogTree()
        {
            var enabledPlayers = _players.Where(p => p.IsEnabled && p.CanCastSpells && (p.Status != PlayerStatus.Sleeping || p.Status != PlayerStatus.Dead)).ToList();

            var rootOptions = enabledPlayers.Select(p =>
                new SpellDialogOption(p.Name, () => BuildSpellListNode(p))
            ).ToList();

            AddCancelOption(rootOptions);

            var root = new SpellDialogNode("==Cast Spell==", "Choose a spellcaster:", rootOptions);

            return new SpellDialogTree(root);
        }


        private SpellDialogNode BuildSpellListNode(FantasyPlayer caster)
        {
            IEnumerable<FantasySpell> availableSpells = new List<FantasySpell>();
            IEnumerable<FantasySpell> spells = caster.Spells.Where(spell => HasReagents(caster, spell.Components)).ToList();

            if (_castspellmode == CastSpellMode.Combat)
            {
                availableSpells = spells.Where(spell => spell.Type == FantasySpell.SpellType.Combat || spell.Type == FantasySpell.SpellType.Both);
            }
            else if (_castspellmode == CastSpellMode.NonCombat)
            {
                availableSpells = spells.Where(spell => spell.Type == FantasySpell.SpellType.NonCombat || spell.Type == FantasySpell.SpellType.Both);
            }

            var spellOptions = availableSpells.Select(spell =>
                new SpellDialogOption($"{spell.Name} - {spell.Description}" , () => BuildTargetChoiceNode(caster, spell))
            ).ToList();

            if (!spellOptions.Any())
                spellOptions.Add(new SpellDialogOption("(No available spells)", null));

            AddCancelOption(spellOptions);

            return new SpellDialogNode("==Cast Spell==", "Choose a spell:", spellOptions);
        }

        private SpellDialogNode BuildTargetChoiceNode(FantasyPlayer caster, FantasySpell spell)
        {
            if (spell.TargetChoice == FantasySpell.SpellTargetChoice.ChooseDirection)
            {
                var directions = new[] { "North", "South", "East", "West" };
                var dirOptions = directions.Select(dir =>
                    new SpellDialogOption(dir, () => { SelectSpell(caster, spell, dir); return null; })
                ).ToList();

                AddCancelOption(dirOptions);

                return new SpellDialogNode("==Cast Spell==", "Choose a direction:", dirOptions);
            }
            else if (spell.TargetChoice == FantasySpell.SpellTargetChoice.ChoosePlayer)
            {
                var enabledPlayers = _players.Where(p => p.IsEnabled).ToList();
                var playerOptions = enabledPlayers.Select(p =>
                    new SpellDialogOption(p.Name, () => { SelectSpell(caster, spell, p); return null; })
                ).ToList();

                AddCancelOption(playerOptions);

                return new SpellDialogNode("==Cast Spell==", "Choose a player:", playerOptions);
            }
            else if (spell.TargetChoice == FantasySpell.SpellTargetChoice.ChooseMoonGate)
            {
                var moongates = GetHaveDiscovered(_saveGame);

                var gateOptions = moongates.Select(gate =>
                    new SpellDialogOption(gate, () => { SelectSpell(caster, spell, gate); return null; })
                ).ToList();

                AddCancelOption(gateOptions);

                return new SpellDialogNode("==Cast Spell==", "Choose a moongate:", gateOptions);
            }
            else
            {
                var finalOptions = new List<SpellDialogOption>
                {
                    new SpellDialogOption($"Cast  {spell.Name}", () => { SelectSpell(caster, spell, null); return null; }),
                };

                AddCancelOption(finalOptions);

                return new SpellDialogNode("==Cast Spell==", $"Cast {spell.Name}?", finalOptions);
            }
        }

        private static List<String>GetHaveDiscovered(Ultima4SaveGameVariables saveGame)
        {
            List<string> placesDiscovered = new List<string>();

            if (saveGame.HasDiscovered_Britain==1) { placesDiscovered.Add("Britain"); }
            if (saveGame.HasDiscovered_BuccaneersDen == 1) { placesDiscovered.Add("BuccaneersDen"); }
            if (saveGame.HasDiscovered_Cove == 1) { placesDiscovered.Add("Cove"); }
            if (saveGame.HasDiscovered_EmpathAbbey == 1) { placesDiscovered.Add("Empath Abbey"); }
            if (saveGame.HasDiscovered_Jhelom == 1) { placesDiscovered.Add("Jhelom"); }
            if (saveGame.HasDiscovered_Lycaeum == 1) { placesDiscovered.Add("Lycaeum"); }
            if (saveGame.HasDiscovered_Magincia == 1) { placesDiscovered.Add("Magincia"); }
            if (saveGame.HasDiscovered_Minoc == 1) { placesDiscovered.Add("Minoc"); }
            if (saveGame.HasDiscovered_Moonglow == 1) { placesDiscovered.Add("Moonglow"); }
            if (saveGame.HasDiscovered_Paws == 1) { placesDiscovered.Add("Paws"); }
            if (saveGame.HasDiscovered_SerpentIsle == 1) { placesDiscovered.Add("Serpent Isle"); }
            if (saveGame.HasDiscovered_SkaraBrae == 1) { placesDiscovered.Add("Skara Brae"); }
            if (saveGame.HasDiscovered_Trinsic == 1) { placesDiscovered.Add("Trinsic"); }
            if (saveGame.HasDiscovered_Vesper == 1) { placesDiscovered.Add("Vesper"); }
            if (saveGame.HasDiscovered_Yew == 1) { placesDiscovered.Add("Yew"); }

            return placesDiscovered;
        }

        private bool HasReagents(FantasyPlayer caster, string[] requiredReagents)
        {
            // Check _saveGame for each reagent
            foreach (var reagent in requiredReagents)
            {
                if (!_saveGame.HasReagent(reagent))
                {
                    return false;
                }
            }
            return true;
        }

        private void SelectSpell(FantasyPlayer caster, FantasySpell spell, object target)
        {
            SelectedCaster = caster;
            SelectedSpell = spell;
            SelectedTarget = target;
        }

        private void AddCancelOption(List<SpellDialogOption> options)
        {
            options.Add(new SpellDialogOption("CANCEL", () => null));
        }

    }
}