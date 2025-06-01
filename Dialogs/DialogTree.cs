// Represents the entire dialog tree for an NPC or entity
using System.Collections.Generic;
using Ultima45Monogame.Dialogs;

namespace Ultima45Monogame.Dialogs
{
    public class DialogTree
    {
        public string Id { get; set; } // Unique identifier for the dialog tree (e.g., NPC name)
        public string DialogIndex { get; set; } // Index to differentiate dialog sets
        public string StartNodeId { get; set; } // The starting node of the dialog
        public List<DialogNode> Nodes { get; set; } = new List<DialogNode>();

        // Helper to get a node by ID
        public DialogNode? GetNodeById(string id)
        {
            return Nodes.Find(n => n.Id == id);
        }
    }
}