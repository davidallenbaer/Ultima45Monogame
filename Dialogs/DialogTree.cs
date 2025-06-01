using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultima45Monogame.Dialogs;

namespace Ultima45Monogame.Dialogs
{
    public class DialogTree
    {
        //Use a Dictionary to hold all dialog nodes by their Id, 
        //making it fast and easy to navigate between nodes.    
        public Dictionary<string, DialogNode> Nodes { get; set; } = new Dictionary<string, DialogNode>();
        public DialogNode CurrentNode { get; private set; }

        public void Start(string nodeId)
        {
            CurrentNode = Nodes[nodeId];
        }

        public void ChooseOption(int index)
        {
            var selectedOption = CurrentNode.Options[index];
            if (Nodes.ContainsKey(selectedOption.NextNodeId))
            {
                CurrentNode = Nodes[selectedOption.NextNodeId];
            }
        }
    }
}


