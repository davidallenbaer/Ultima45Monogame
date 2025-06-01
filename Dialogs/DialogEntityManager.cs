using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Ultima45Monogame.Dialogs;

namespace Ultima45Monogame.Dialogs
{
    /*
        Usage:

        var manager = new DialogEntityManager();
        manager.LoadAllDialogTreesFromJson("Dialogs/UltimaIV_Dialogs.json");
        var tree = manager.GetDialogTreeByIndex("2"); // DialogIndex as string
        var startNode = tree?.GetNodeById(tree.StartNodeId);
     */

    public class DialogEntityManager
    {
        // Keyed by DialogIndex for fast lookup
        private readonly Dictionary<string, DialogTree> _dialogTreesByIndex = new();
        // Optionally, also keyed by Id (NPC name) if needed
        private readonly Dictionary<string, DialogTree> _dialogTreesById = new();

        // Load all dialog trees from a JSON file containing an array of dialog trees
        public void LoadAllDialogTreesFromJson(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Dialog JSON file not found: {filePath}");

            var json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var dialogTrees = JsonSerializer.Deserialize<List<DialogTree>>(json, options);

            if (dialogTrees == null)
                throw new InvalidOperationException("Invalid dialog trees JSON.");

            _dialogTreesByIndex.Clear();
            _dialogTreesById.Clear();

            foreach (var tree in dialogTrees)
            {
                if (!string.IsNullOrEmpty(tree.DialogIndex))
                    _dialogTreesByIndex[tree.DialogIndex] = tree;
                if (!string.IsNullOrEmpty(tree.Id))
                    _dialogTreesById[tree.Id] = tree;
            }
        }

        // Get a dialog tree by its DialogIndex
        public DialogTree? GetDialogTreeByIndex(string dialogIndex)
        {
            _dialogTreesByIndex.TryGetValue(dialogIndex, out var tree);
            return tree;
        }

        // Optionally, get a dialog tree by its Id (NPC name)
        public DialogTree? GetDialogTreeById(string id)
        {
            _dialogTreesById.TryGetValue(id, out var tree);
            return tree;
        }
    }
}