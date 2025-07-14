using System.Collections.Generic;

namespace Ultima45Monogame.Dialogs
{
    public class PurchaseFoodDialogEntityManager
    {
        private DialogTree? _purchaseFoodDialogTree;

        public void BuildPurchaseFoodJSON(Ultima4SaveGameVariables gamesave)
        {
            var dialogTree = new DialogTree
            {
                Id = "PurchaseFood",
                DialogIndex = "PurchaseFood",
                Nodes = new List<DialogNode>()
            };

            var startNode = new DialogNode
            {
                Id = "start",
                Speaker = "Merchant",
                Text = "Welcome! Would you like to by food?",
                Options = new List<DialogOption>()
            };

            string optionId = $"buy_food";
            startNode.Options.Add(new DialogOption
            {
                Text = $"Food - 25 gold",
                NextNodeId = optionId
            });

            var buyNode = new DialogNode
            {
                Id = optionId,
                Speaker = "Merchant",
                Text = $"You purchased food!",
                Options = new List<DialogOption>
                {
                    new DialogOption
                    {
                        Text = "BACK TO SHOP",
                        NextNodeId = "start"
                    },
                    new DialogOption
                    {
                        Text = "LEAVE",
                        NextNodeId = "end"
                    }
                }
            };

            dialogTree.Nodes.Add(buyNode);

            // Cancel/end node
            var endNode = new DialogNode
            {
                Id = "end",
                Speaker = "Merchant",
                Text = "Thank you for visiting!",
                Options = new List<DialogOption>()
            };
            dialogTree.Nodes.Add(endNode);

            startNode.Options.Add(new DialogOption
            {
                Text = "CANCEL",
                NextNodeId = "end"
            });

            dialogTree.StartNodeId = startNode.Id;
            dialogTree.Nodes.Add(startNode);

            _purchaseFoodDialogTree = dialogTree;

        }

        public DialogTree? GetPurchaseFoodDialogTree()
        {
            return _purchaseFoodDialogTree;
        }
    }
}
