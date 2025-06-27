using System.Collections.Generic;

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


