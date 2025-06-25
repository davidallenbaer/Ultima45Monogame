using System.Collections.Generic;

namespace Ultima45Monogame.Spells
{
    public class SpellDialogNode
    {
        public string Prompt { get; set; }
        public List<SpellDialogOption> Options { get; set; }

        public SpellDialogNode(string prompt, List<SpellDialogOption> options)
        {
            Prompt = prompt;
            Options = options ?? new List<SpellDialogOption>();
        }
    }
}