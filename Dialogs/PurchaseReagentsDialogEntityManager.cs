using System.Collections.Generic;
using Ultima45Monogame.Player;

namespace Ultima45Monogame.Dialogs
{
    public class PurchaseReagentsDialogEntityManager
    {
        private DialogTree? _purchaseReagentsDialogTree;

        List<FantasyReagent> _merchantReagents = new List<FantasyReagent>();

        public void BuildPurchaseReagentsJSON(List<FantasyReagent> merchantReagents)
        {
            _merchantReagents = merchantReagents;

            var dialogTree = new DialogTree
            {
                Id = "PurchaseReagent",
                DialogIndex = "PurchaseReagent",
                Nodes = new List<DialogNode>()
            };

            var startNode = new DialogNode
            {
                Id = "start",
                Speaker = "Merchant",
                Text = "Welcome! What reagent would you like to buy?",
                Options = new List<DialogOption>()
            };

            foreach (var reagent in _merchantReagents)
            {
                string optionId = $"buy_{reagent.ID}";
                startNode.Options.Add(new DialogOption
                {
                    Text = $"{reagent.Name} - {reagent.Cost} gold",
                    NextNodeId = optionId
                });

                var buyNode = new DialogNode
                {
                    Id = optionId,
                    Speaker = "Merchant",
                    Text = $"You purchased a {reagent.Name}!",
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
            }

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

            _purchaseReagentsDialogTree = dialogTree;
        }

        public DialogTree? GetPurchaseReagentDialogTree()
        {
            return _purchaseReagentsDialogTree;
        }

    }
}
