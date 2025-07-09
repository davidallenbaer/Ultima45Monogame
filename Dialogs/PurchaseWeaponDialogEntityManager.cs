using System.Collections.Generic;

namespace Ultima45Monogame.Dialogs
{
    public class PurchaseWeaponDialogEntityManager
    {
        private DialogTree? _purchaseWeaponDialogTree;

        List<FantasyWeapon> _merchantWeapons = new List<FantasyWeapon>();

        public void BuildPurchaseWeaponJSON(List<FantasyWeapon> merchantWeapons)
        {
            _merchantWeapons = merchantWeapons;

            var dialogTree = new DialogTree
            {
                Id = "PurchaseWeapon",
                DialogIndex = "PurchaseWeapon",
                Nodes = new List<DialogNode>()
            };

            var startNode = new DialogNode
            {
                Id = "start",
                Speaker = "Merchant",
                Text = "Welcome! What weapon would you like to buy?",
                Options = new List<DialogOption>()
            };

            foreach (var weapon in _merchantWeapons)
            {
                string optionId = $"buy_{weapon.ID}";
                startNode.Options.Add(new DialogOption
                {
                    Text = $"{weapon.Name} - {weapon.Cost} gold",
                    NextNodeId = optionId
                });

                var buyNode = new DialogNode
                {
                    Id = optionId,
                    Speaker = "Merchant",
                    Text = $"You purchased a {weapon.Name}!",
                    Options = new List<DialogOption>
                    {
                        new DialogOption
                        {
                            Text = "Back to Shop",
                            NextNodeId = "start"
                        },
                        new DialogOption
                        {
                            Text = "Leave",
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

            _purchaseWeaponDialogTree = dialogTree;
        }

        public DialogTree? GetPurchaseWeaponDialogTree()
        {
            return _purchaseWeaponDialogTree;
        }

        public void ProcessNode(Ultima4SaveGameVariables gameSave, DialogNode currentNode)
        {
            if (currentNode.Id.StartsWith("buy_"))
            {
                var parts = currentNode.Id.Split('_');
                if (parts.Length == 2 && int.TryParse(parts[1], out int weaponId))
                {
                    var weapon = _merchantWeapons.Find(w => w.ID == weaponId);
                    if (weapon != null)
                    {
                        // Clone weapon to avoid shared reference
                        var purchasedWeapon = new FantasyWeapon
                        {
                            ID = weapon.ID,
                            Name = weapon.Name,
                            Cost = weapon.Cost,
                            IsEquipped = false
                        };

                        gameSave.WeaponInventory.Add(purchasedWeapon);
                    }
                }
            }
        }
    }
}
