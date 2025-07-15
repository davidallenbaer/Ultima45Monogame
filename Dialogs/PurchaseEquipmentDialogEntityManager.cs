using System.Collections.Generic;

namespace Ultima45Monogame.Dialogs
{
    public class PurchaseEquipmentDialogEntityManager
    {
        private DialogTree? _purchaseEquipmentDialogTree;

        public void BuildPurchaseEquipmentJSON(Ultima4SaveGameVariables gamesave,
            bool bShowTorches = true,
            bool bShowKeys = true,
            bool bShowGems = false,
            bool bShowSextant = false)
        {
            var dialogTree = new DialogTree
            {
                Id = "PurchaseEquipment",
                DialogIndex = "PurchaseEquipment",
                Nodes = new List<DialogNode>()
            };

            var startNode = new DialogNode
            {
                Id = "start",
                Speaker = "Merchant",
                Text = "Welcome! Would you like to by equipment?",
                Options = new List<DialogOption>()
            };

            string optionId = "";

            if (bShowTorches)
            {
                optionId = $"buy_torches";
                startNode.Options.Add(new DialogOption
                {
                    Text = $"Torches - 25 gold",
                    NextNodeId = optionId
                });
            }

            if (bShowKeys)
            {
                optionId = $"buy_keys";
                startNode.Options.Add(new DialogOption
                {
                    Text = $"Keys - 25 gold",
                    NextNodeId = optionId
                });
            }

            if (bShowGems)
            {
                optionId = $"buy_gems";
                startNode.Options.Add(new DialogOption
                {
                    Text = $"Gems - 25 gold",
                    NextNodeId = optionId
                });
            }

            if (bShowSextant)
            {
                optionId = $"buy_sextant";
                startNode.Options.Add(new DialogOption
                {
                    Text = $"Sextant - 25 gold",
                    NextNodeId = optionId
                });
            }

            var buyNode = new DialogNode
            {
                Id = optionId,
                Speaker = "Merchant",
                Text = $"Thank you for your purchase!",
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

            _purchaseEquipmentDialogTree = dialogTree;

        }

        public DialogTree? GetPurchaseEquipmentDialogTree()
        {
            return _purchaseEquipmentDialogTree;
        }
    }
}
