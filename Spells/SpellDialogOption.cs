using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultima45Monogame.Spells
{
    public class SpellDialogOption
    {
        public string Text { get; set; }
        public string NextNodeId { get; set; }
        public Func<bool> Condition { get; set; }
    }
}