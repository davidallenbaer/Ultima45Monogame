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

        //TODO Do not think I need this method
        //public void ProcessNode(Ultima4SaveGameVariables gameSave, DialogNode currentNode)
        //{
        //    if (currentNode.Id.StartsWith("buy_"))
        //    {
        //        var parts = currentNode.Id.Split('_');
        //        if (parts.Length == 2 && int.TryParse(parts[1], out int reagentId))
        //        {
        //            var reagent = _merchantReagents.Find(w => w.ID == reagentId);
        //            if (reagent != null)
        //            {
        //                // Clone armor to avoid shared reference
        //                var purchasedReagent = new FantasyReagent
        //                {
        //                    ID = reagent.ID,
        //                    Name = reagent.Name,
        //                    Description = reagent.Description,
        //                    Cost = reagent.Cost
        //                };

        //                if (gameSave.GP >= reagent.Cost)
        //                {
        //                    gameSave.GP -= reagent.Cost;

        //                    //Add 25 reagents to inventory
        //                    if (reagent.Name == "Black Pearl")
        //                    {
        //                        gameSave.SpellReagent_BlackPearl += 25;
        //                    }
        //                    else if (reagent.Name == "Blood Moss")
        //                    {
        //                        gameSave.SpellReagent_BloodMoss += 25;
        //                    }
        //                    else if (reagent.Name == "Garlic")
        //                    {
        //                        gameSave.SpellReagent_Garlic += 25;
        //                    }
        //                    else if (reagent.Name == "Ginseng")
        //                    {
        //                        gameSave.SpellReagent_Ginseng += 25;
        //                    }
        //                    else if (reagent.Name == "Mandrake Root")
        //                    {
        //                        gameSave.SpellReagent_MandrakeRoot += 25;
        //                    }
        //                    else if (reagent.Name == "Nightshade")
        //                    {
        //                        gameSave.SpellReagent_Nightshade += 25;
        //                    }
        //                    else if (reagent.Name == "Spider Silk")
        //                    {
        //                        gameSave.SpellReagent_SpiderSilk += 25;
        //                    }
        //                    else if (reagent.Name == "Sulfurous Ash")
        //                    {
        //                        gameSave.SpellReagent_SulfurousAsh += 25;
        //                    }
        //                }
        //                else
        //                {
        //                    //TODO Optionally, handle insufficient funds (e.g., show a message)
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
