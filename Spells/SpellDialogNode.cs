using System.Collections.Generic;

namespace Ultima45Monogame.Spells
{
    public class SpellDialogNode
    {
        public string Id { get; set; }
        public string Speaker { get; set; }
        public string Text { get; set; }
        public List<SpellDialogOption> Options { get; set; } = new();
    }
}