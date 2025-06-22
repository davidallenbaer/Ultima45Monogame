using System;
using System.Collections.Generic;
using Ultima45Monogame.Player;
using Ultima45Monogame.Dialogs;

namespace Ultima45Monogame.Dialogs
{
    public class UseItemDialogEntityManager
    {
        private DialogTree? _useItemDialogTree;

        public enum SpecialItem
        {
            Torch,
            PeerAtGem,
            Sextant,
            SkullOfMondain,
            Candle,
            Book,
            BellOfCourage,
            SilverHorn,
            WheelOfHMSCape
        }

        public void BuildUseItemJSON(Ultima4SaveGameVariables saveVars)
        {
            var dialogTree = new DialogTree
            {
                Id = "UseItem",
                DialogIndex = "UseItem",
                Nodes = new List<DialogNode>()
            };

            // Start node: List all usable items
            var startNode = new DialogNode
            {
                Id = "start",
                Speaker = "==Use Item==",
                Text = "Select an item to use:",
                Options = new List<DialogOption>()
            };

            // Add options for each item if available
            if (saveVars.Torches > 0)
            {
                startNode.Options.Add(new DialogOption
                {
                    Text = "Torch",
                    NextNodeId = "use_Torch"
                });
                startNode.Options.Add(new DialogOption
                {
                    Text = "Peer at Gem",
                    NextNodeId = "use_PeerAtGem"
                });
            }
            if (saveVars.Sextants > 0)
            {
                startNode.Options.Add(new DialogOption
                {
                    Text = "Sextant",
                    NextNodeId = "use_Sextant"
                });
            }
            if (saveVars.Skull > 0)
            {
                startNode.Options.Add(new DialogOption
                {
                    Text = "Skull of Mondain",
                    NextNodeId = "use_SkullOfMondain"
                });
            }
            if (saveVars.Candle > 0)
            {
                startNode.Options.Add(new DialogOption
                {
                    Text = "Candle",
                    NextNodeId = "use_Candle"
                });
            }
            if (saveVars.Book > 0)
            {
                startNode.Options.Add(new DialogOption
                {
                    Text = "Book",
                    NextNodeId = "use_Book"
                });
            }
            if (saveVars.Bell > 0)
            {
                startNode.Options.Add(new DialogOption
                {
                    Text = "Bell of Courage",
                    NextNodeId = "use_BellOfCourage"
                });
            }
            if (saveVars.Horn > 0)
            {
                startNode.Options.Add(new DialogOption
                {
                    Text = "Silver Horn",
                    NextNodeId = "use_SilverHorn"
                });
            }
            if (saveVars.Wheel > 0)
            {
                startNode.Options.Add(new DialogOption
                {
                    Text = "Wheel of HMS Cape",
                    NextNodeId = "use_WheelOfHMSCape"
                });
            }

            // Add CANCEL option
            startNode.Options.Add(new DialogOption
            {
                Text = "CANCEL",
                NextNodeId = "cancel"
            });

            dialogTree.StartNodeId = startNode.Id;
            dialogTree.Nodes.Add(startNode);

            // For each item, create a node that calls UseSpecialItem and ends dialog
            void AddUseNode(string id, string itemDisplay)
            {
                var useNode = new DialogNode
                {
                    Id = id,
                    Speaker = "==Use Item==",
                    Text = $"You use the {itemDisplay}.",
                    Options = new List<DialogOption>
                    {
                        new DialogOption
                        {
                            Text = "Done",
                            NextNodeId = "end"
                        }
                    }
                };
                dialogTree.Nodes.Add(useNode);
            }

            if (saveVars.Torches > 0)
            {
                AddUseNode("use_Torch", "Torch");
                AddUseNode("use_PeerAtGem", "Gem");
            }
            if (saveVars.Sextants > 0)
                AddUseNode("use_Sextant", "Sextant");
            if (saveVars.Skull > 0)
                AddUseNode("use_SkullOfMondain", "Skull of Mondain");
            if (saveVars.Candle > 0)
                AddUseNode("use_Candle", "Candle");
            if (saveVars.Book > 0)
                AddUseNode("use_Book", "Book");
            if (saveVars.Bell > 0)
                AddUseNode("use_BellOfCourage", "Bell of Courage");
            if (saveVars.Horn > 0)
                AddUseNode("use_SilverHorn", "Silver Horn");
            if (saveVars.Wheel > 0)
                AddUseNode("use_WheelOfHMSCape", "Wheel of HMS Cape");

            // End node
            var endNode = new DialogNode
            {
                Id = "end",
                Speaker = "==Use Item==",
                Text = "Item used.",
                Options = new List<DialogOption>()
            };
            dialogTree.Nodes.Add(endNode);

            // Cancel node
            var cancelNode = new DialogNode
            {
                Id = "cancel",
                Speaker = "==Use Item==",
                Text = "Use item dialog canceled.",
                Options = new List<DialogOption>()
            };
            dialogTree.Nodes.Add(cancelNode);

            _useItemDialogTree = dialogTree;
        }

        public DialogTree? GetUseItemDialogTree()
        {
            return _useItemDialogTree;
        }

        // Call this after transitioning to a node to handle item use
        public void ProcessNode(DialogNode currentNode, Action<SpecialItem> UseSpecialItem)
        {
            if (currentNode.Id.StartsWith("use_"))
            {
                SpecialItem? item = currentNode.Id switch
                {
                    "use_Torch" => SpecialItem.Torch,
                    "use_PeerAtGem" => SpecialItem.PeerAtGem,
                    "use_Sextant" => SpecialItem.Sextant,
                    "use_SkullOfMondain" => SpecialItem.SkullOfMondain,
                    "use_Candle" => SpecialItem.Candle,
                    "use_Book" => SpecialItem.Book,
                    "use_BellOfCourage" => SpecialItem.BellOfCourage,
                    "use_SilverHorn" => SpecialItem.SilverHorn,
                    "use_WheelOfHMSCape" => SpecialItem.WheelOfHMSCape,
                    _ => null
                };
                if (item.HasValue)
                {
                    UseSpecialItem(item.Value);
                }
            }
        }
    }
}