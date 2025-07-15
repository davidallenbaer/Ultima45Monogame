using System.Collections.Generic;

namespace Ultima45Monogame.Dialogs
{
    public class PurchaseDonationDialogEntityManager
    {
        private DialogTree? _purchaseDonationDialogTree;

        public void BuildPurchaseDonationJSON(Ultima4SaveGameVariables gamesave)
        {
            var dialogTree = new DialogTree
            {
                Id = "PurchaseDonation",
                DialogIndex = "PurchaseDonation",
                Nodes = new List<DialogNode>()
            };

            var startNode = new DialogNode
            {
                Id = "start",
                Speaker = "Merchant",
                Text = "Would you like to make a donation?",
                Options = new List<DialogOption>()
            };

            string optionId = $"buy_donation";
            startNode.Options.Add(new DialogOption
            {
                Text = $"Donate - 1 GP",
                NextNodeId = optionId + "_1"
            });

            startNode.Options.Add(new DialogOption
            {
                Text = $"Donate - 5 GP",
                NextNodeId = optionId + "_5"
            });

            startNode.Options.Add(new DialogOption
            {
                Text = $"Donate - 10 GP",
                NextNodeId = optionId + "_10"
            });

            startNode.Options.Add(new DialogOption
            {
                Text = $"Donate - 25 GP",
                NextNodeId = optionId + "_25"
            });

            startNode.Options.Add(new DialogOption
            {
                Text = $"Donate - 50 GP",
                NextNodeId = optionId + "_50"
            });

            startNode.Options.Add(new DialogOption
            {
                Text = $"Donate - 100 GP",
                NextNodeId = optionId + "_100"
            });

            var buyNode = new DialogNode
            {
                Id = optionId,
                Speaker = "Merchant",
                Text = $"You made a donation!",
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

            _purchaseDonationDialogTree = dialogTree;

        }

        public DialogTree? GetPurchaseDonationDialogTree()
        {
            return _purchaseDonationDialogTree;
        }
    }
}
