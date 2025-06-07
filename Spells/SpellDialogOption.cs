using System;

namespace Ultima45Monogame.Spells
{
    public class SpellDialogOption
    {
        public string Text { get; set; }
        public string NextNodeId { get; set; }
        public Func<bool> Condition { get; set; }
    }
}
