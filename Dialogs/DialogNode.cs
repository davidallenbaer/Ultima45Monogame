using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultima45Monogame.Dialogs
{
    public class DialogNode
    {
        //A DialogNode class represents a single point in the conversation. 
        //It contains the speaker's text and a list of possible player responses (if any).
        public string Id { get; set; } // Unique identifier for this node
        public string Speaker { get; set; }
        public string Text { get; set; }
        public List<DialogOption> Options { get; set; } = new List<DialogOption>();
    }
}


