using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultima45Monogame.Dialogs
{
    public class DialogNode
    {
        public string Id { get; set; }
        public string Speaker { get; set; }
        public string Text { get; set; }
        public List<DialogOption> Options { get; set; } = new List<DialogOption>();
    }
}


