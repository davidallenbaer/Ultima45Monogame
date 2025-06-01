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
        manager.LoadDialogTreeFromJson("Dialogs/NPC1.json");

        var tree = manager.GetDialogTree("NPC1");
        var startNode = manager.GetStartNode("NPC1");
     */

    // Represents the entire dialog tree for an NPC or entity
    public class DialogTree
    {
        public string Id { get; set; } // Unique identifier for the dialog tree (e.g., NPC name)
        public string StartNodeId { get; set; } // The starting node of the dialog
        public List<DialogNode> Nodes { get; set; } = new List<DialogNode>();

        // Helper to get a node by ID
        public DialogNode? GetNodeById(string id)
        {
            return Nodes.Find(n => n.Id == id);
        }
    }

    public class DialogEntityManager
    {
        private readonly Dictionary<string, DialogTree> _dialogTrees = new();

        // Load a dialog tree from a JSON file and add it to the manager
        public void LoadDialogTreeFromJson(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Dialog JSON file not found: {filePath}");

            var json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var dialogTree = JsonSerializer.Deserialize<DialogTree>(json, options);

            if (dialogTree == null || string.IsNullOrEmpty(dialogTree.Id))
                throw new InvalidOperationException("Invalid dialog tree JSON.");

            _dialogTrees[dialogTree.Id] = dialogTree;
        }

        // Get a dialog tree by its ID
        public DialogTree? GetDialogTree(string id)
        {
            _dialogTrees.TryGetValue(id, out var tree);
            return tree;
        }

        // Optionally, get the starting node for a dialog tree
        public DialogNode? GetStartNode(string dialogTreeId)
        {
            var tree = GetDialogTree(dialogTreeId);
            return tree?.GetNodeById(tree.StartNodeId);
        }
    }
}
