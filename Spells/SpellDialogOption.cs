using System;

namespace Ultima45Monogame.Spells
{
    public class SpellDialogOption
    {
        public string Text { get; }
        public Func<SpellDialogNode> Action { get; set; }
        public Func<SpellDialogNode?>? OnSelected { get; }
        
        public string? NextNodeId { get; set; }

        public SpellDialogOption(string text, Func<SpellDialogNode> action = null, string nextNodeId = null)
        {
            Text = text;
            Action = action;
            NextNodeId = nextNodeId;
        }
    }
}