using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultima45Monogame.Dialogs
{
    public class DialogOption
    {
        //Each response the player can choose, with a pointer to the next node.
        public string Text { get; set; }          // What the player says
        public string NextNodeId { get; set; }    // ID of the next DialogNode
        public Func<bool> Condition { get; set; } // Optional condition for showing this option
    }
}
