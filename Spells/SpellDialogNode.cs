using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultima45Monogame.Dialogs;

namespace Ultima45Monogame.Spells
{
    public class SpellDialogNode
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Prompt { get; set; }
        public List<SpellDialogOption> Options { get; set; } = new List<SpellDialogOption>();

        public SpellDialogNode(string title, string prompt, List<SpellDialogOption> options)
        {
            Title = title;
            Prompt = prompt;
            Options = options ?? new List<SpellDialogOption>();
        }
    }
}