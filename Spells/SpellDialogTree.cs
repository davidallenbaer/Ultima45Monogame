using System.Collections.Generic;
using Ultima45Monogame.Spells;

namespace Ultima45Monogame.Spells
{
    public class SpellDialogTree
    {
        private List<SpellDialogNode> nodes = new List<SpellDialogNode>();

        public string Id { get; set; }
        public string DialogIndex { get; set; }
        public string StartNodeId { get; set; }
        public List<SpellDialogNode> Nodes { get; set; } = new List<SpellDialogNode>();

        // Helper to get a node by ID
        public SpellDialogNode? GetNodeById(string id)
        {
            return Nodes.Find(n => n.Id == id);
        }
    }
}
