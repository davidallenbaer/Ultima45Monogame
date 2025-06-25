using System.Collections.Generic;

namespace Ultima45Monogame.Spells
{
    public class SpellDialogTree
    {
        public string DialogIndex { get; set; }
        public string StartNodeId { get; set; }
        public List<SpellDialogNode> Nodes { get; set; }

        // Constructor that takes a root node
        public SpellDialogTree(SpellDialogNode root)
        {
            Nodes = new List<SpellDialogNode> { root };
            StartNodeId = "root";
            DialogIndex = "0";
        }

        // Helper to get a node by ID (if you add IDs to nodes)
        public SpellDialogNode? GetNodeById(string id)
        {
            // For now, just return the first node (root) since only one node is used
            return Nodes.Count > 0 ? Nodes[0] : null;
        }
    }
}