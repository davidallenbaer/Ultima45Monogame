using System.Collections.Generic;

namespace Ultima45Monogame.Dialogs
{
    public class PurchaseHealingDialogEntityManager
    {
        private DialogTree? _purchaseHealingDialogTree;

        List<FantasyPlayer> _merchantHealing = new List<FantasyPlayer>();

        public void BuildPurchaseHealingJSON(List<FantasyPlayer> merchantHealing)
        {
            _merchantHealing = merchantHealing;

            var dialogTree = new DialogTree
            {
                Id = "PurchaseHealing",
                DialogIndex = "PurchaseHealing",
                Nodes = new List<DialogNode>()
            };

            var startNode = new DialogNode
            {
                Id = "start",
                Speaker = "Merchant",
                Text = "Welcome! Who would you like to heal?",
                Options = new List<DialogOption>()
            };

            foreach (var player in _merchantHealing)
            {
                if (player.HP != player.MaxHP || player.Status != RPGEnums.PlayerStatus.Good)
                {
                    string optionId = $"buy_{player.Name}";
                    startNode.Options.Add(new DialogOption
                    {
                        Text = $"{player.Name} - 25 gold",
                        NextNodeId = optionId
                    });

                    var buyNode = new DialogNode
                    {
                        Id = optionId,
                        Speaker = "Merchant",
                        Text = $"{player.Name} is healed!",
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

            _purchaseHealingDialogTree = dialogTree;
        }

        public DialogTree? GetPurchaseHealingDialogTree()
        {
            return _purchaseHealingDialogTree;
        }

    }
}
