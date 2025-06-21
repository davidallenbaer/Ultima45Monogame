using System;
using System.Collections.Generic;
using Ultima45Monogame.Dialogs;

namespace Ultima45Monogame.Dialogs
{
    public class WearArmorDialogEntityManager
    {
        private DialogTree? _wearArmorDialogTree;

        public void BuildWearArmorJSON(List<FantasyPlayer> players)
        {
            // Get all enabled FantasyPlayers
            var enabledPlayers = players.FindAll(p => p.Enabled);

            var dialogTree = new DialogTree
            {
                Id = "WearArmor",
                DialogIndex = "WearArmor",
                Nodes = new List<DialogNode>()
            };

            // Start node: List all enabled players
            var startNode = new DialogNode
            {
                Id = "start",
                Speaker = "==Wear Armor==",
                Text = "Select a character to wear armor:",
                Options = new List<DialogOption>()
            };

            foreach (var player in enabledPlayers)
            {
                startNode.Options.Add(new DialogOption
                {
                    Text = player.Name,
                    NextNodeId = $"player_{player.Name}"
                });
            }
            // Add CANCEL option to start node
            startNode.Options.Add(new DialogOption
            {
                Text = "CANCEL",
                NextNodeId = "cancel"
            });

            dialogTree.StartNodeId = startNode.Id;
            dialogTree.Nodes.Add(startNode);

            // For each player, create a node listing their armor
            foreach (var player in enabledPlayers)
            {
                var armorNode = new DialogNode
                {
                    Id = $"player_{player.Name}",
                    Speaker = player.Name,
                    Text = "Select armor to wear:",
                    Options = new List<DialogOption>()
                };

                if (player.Armor != null && player.Armor.Count > 0)
                {
                    foreach (var armor in player.Armor)
                    {
                        // If equipped, wrap with asterisks
                        string armorText = armor.IsEquipped ? $"*{armor.Name}*" : armor.Name;

                        armorNode.Options.Add(new DialogOption
                        {
                            Text = armorText,
                            NextNodeId = $"equip_{player.Name}_{armor.ID}"
                        });

                        // Equip node: sets IsEquipped and ends dialog
                        var equipNode = new DialogNode
                        {
                            Id = $"equip_{player.Name}_{armor.ID}",
                            Speaker = player.Name,
                            Text = $"{armor.Name} is now equipped.",
                            Options = new List<DialogOption>()
                        };

                        equipNode.Options.Add(new DialogOption
                        {
                            Text = "Done",
                            NextNodeId = "end"
                        });

                        dialogTree.Nodes.Add(equipNode);
                    }
                }
                else
                {
                    armorNode.Text = "No armor available.";
                    armorNode.Options.Add(new DialogOption
                    {
                        Text = "Back",
                        NextNodeId = "start"
                    });
                }

                // Add CANCEL option to armor node
                armorNode.Options.Add(new DialogOption
                {
                    Text = "CANCEL",
                    NextNodeId = "cancel"
                });

                dialogTree.Nodes.Add(armorNode);
            }

            // End node
            var endNode = new DialogNode
            {
                Id = "end",
                Speaker = "==Wear Armor==",
                Text = "Armor equipped.",
                Options = new List<DialogOption>()
            };
            dialogTree.Nodes.Add(endNode);

            // Cancel node
            var cancelNode = new DialogNode
            {
                Id = "cancel",
                Speaker = "==Wear Armor==",
                Text = "Wear armor dialog canceled.",
                Options = new List<DialogOption>()
            };
            dialogTree.Nodes.Add(cancelNode);

            // Store in memory for retrieval
            _wearArmorDialogTree = dialogTree;
        }

        // Get a dialog tree by its DialogIndex
        public DialogTree? GetWearArmorDialogTree()
        {
            return _wearArmorDialogTree;
        }

        private void EquipArmorForPlayer(List<FantasyPlayer> players, string playerName, int armorId)
        {
            var player = players.Find(p => p.Name == playerName);
            if (player != null && player.Armor != null)
            {
                foreach (var armor in player.Armor)
                {
                    armor.IsEquipped = (armor.ID == armorId);
                }
            }
        }

        public void ProcessNode(List<FantasyPlayer> players, DialogNode currentNode)
        {
            if (currentNode.Id.StartsWith("equip_"))
            {
                // Node ID format: equip_{playerName}_{armorID}
                var parts = currentNode.Id.Split('_');
                if (parts.Length == 3)
                {
                    string playerName = parts[1];
                    if (int.TryParse(parts[2], out int armorId))
                    {
                        EquipArmorForPlayer(players, playerName, armorId);
                    }
                }
            }
        }
    }
}