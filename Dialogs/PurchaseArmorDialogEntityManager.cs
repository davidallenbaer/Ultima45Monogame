using System.Collections.Generic;

namespace Ultima45Monogame.Dialogs
{
    public class PurchaseArmorDialogEntityManager
    {
        private DialogTree? _purchaseArmorDialogTree;

        List<FantasyArmor> _merchantArmors = new List<FantasyArmor>();

        public void BuildPurchaseArmorJSON(List<FantasyArmor> merchantArmors)
        {
            _merchantArmors = merchantArmors;

            var dialogTree = new DialogTree
            {
                Id = "PurchaseArmor",
                DialogIndex = "PurchaseArmor",
                Nodes = new List<DialogNode>()
            };

            var startNode = new DialogNode
            {
                Id = "start",
                Speaker = "Merchant",
                Text = "Welcome! What armor would you like to buy?",
                Options = new List<DialogOption>()
            };

            foreach (var armor in _merchantArmors)
            {
                string optionId = $"buy_{armor.ID}";
                startNode.Options.Add(new DialogOption
                {
                    Text = $"{armor.Name} - {armor.Cost} gold",
                    NextNodeId = optionId
                });

                var buyNode = new DialogNode
                {
                    Id = optionId,
                    Speaker = "Merchant",
                    Text = $"You purchased a {armor.Name}!",
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

            _purchaseArmorDialogTree = dialogTree;
        }

        public DialogTree? GetPurchaseArmorDialogTree()
        {
            return _purchaseArmorDialogTree;
        }

        public void ProcessNode(Ultima4SaveGameVariables gameSave, DialogNode currentNode)
        {
            if (currentNode.Id.StartsWith("buy_"))
            {
                var parts = currentNode.Id.Split('_');
                if (parts.Length == 2 && int.TryParse(parts[1], out int armorId))
                {
                    var armor = _merchantArmors.Find(w => w.ID == armorId);
                    if (armor != null)
                    {
                        // Clone armor to avoid shared reference
                        var purchasedArmor = new FantasyArmor
                        {
                            ID = armor.ID,
                            Name = armor.Name,
                            Cost = armor.Cost,
                            IsEquipped = false
                        };

                        gameSave.ArmorInventory.Add(purchasedArmor);
                    }
                }
            }
        }
    }
}
