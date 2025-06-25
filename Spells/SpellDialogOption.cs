using System;

namespace Ultima45Monogame.Spells
{
    public class SpellDialogOption
    {
        public string Text { get; }
        public Func<SpellDialogNode?>? OnSelected { get; }
        public string? NextNodeId { get; set; }

        public SpellDialogOption(string text, Func<SpellDialogNode?>? onSelected)
        {
            Text = text;
            OnSelected = onSelected;
        }
    }
}