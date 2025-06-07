using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Ultima45Monogame.Spells;

namespace Ultima45Monogame.Spells
{
    /*
        Usage:

        var manager = new SpellDialogEntityManager();
        manager.LoadAllSpellDialogTreesFromJson("Spells/UltimaIV_SpellDialogs.json");
        var tree = manager.GetSpellDialogTreeByIndex("2"); // SpellDialogIndex as string
        var startNode = tree?.GetNodeById(tree.StartNodeId);
     */

    public class SpellDialogEntityManager
    {
        // Keyed by SpellDialogIndex for fast lookup
        private readonly Dictionary<string, SpellDialogTree> _spellDialogTreesByIndex = new();
        // Optionally, also keyed by Id (NPC name) if needed
        private readonly Dictionary<string, SpellDialogTree> _spellDialogTreesById = new();

        // Load all spell dialog trees from a JSON file containing an array of dialog trees
        public void LoadAllSpellDialogTreesFromJson(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Dialog JSON file not found: {filePath}");

            var json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var spellDialogTrees = JsonSerializer.Deserialize<List<SpellDialogTree>>(json, options);

            if (spellDialogTrees == null)
                throw new InvalidOperationException("Invalid dialog trees JSON.");

            _spellDialogTreesByIndex.Clear();
            _spellDialogTreesById.Clear();

            foreach (var tree in spellDialogTrees)
            {
                if (!string.IsNullOrEmpty(tree.DialogIndex))
                    _spellDialogTreesByIndex[tree.DialogIndex] = tree;
                if (!string.IsNullOrEmpty(tree.Id))
                    _spellDialogTreesById[tree.Id] = tree;
            }
        }

        // Get a spell dialog tree by its DialogIndex
        public SpellDialogTree? GetSpellDialogTreeByIndex(string spellDialogIndex)
        {
            _spellDialogTreesByIndex.TryGetValue(spellDialogIndex, out var tree);
            return tree;
        }

        // Optionally, get a dialog tree by its Id (NPC name)
        public SpellDialogTree? GetSpellDialogTreeById(string id)
        {
            _spellDialogTreesById.TryGetValue(id, out var tree);
            return tree;
        }
    }
}