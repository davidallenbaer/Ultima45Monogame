using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Ultima45Monogame.Dialogs;

namespace Ultima45Monogame.Dialogs
{
    public class ReadyWeaponDialogEntityManager
    {
        private DialogTree? _readyWeaponDialogTree;

        public void BuildReadyWeaponJSON(List<FantasyPlayer> players)
        {
            // Get all enabled FantasyPlayers
            var enabledPlayers = players.FindAll(p => p.Enabled);

            var dialogTree = new DialogTree
            {
                Id = "ReadyWeapon",
                DialogIndex = "ReadyWeapon",
                Nodes = new List<DialogNode>()
            };

            // Start node: List all enabled players
            var startNode = new DialogNode
            {
                Id = "start",
                Speaker = "==Ready Weapon==",
                Text = "Select a character to ready a weapon:",
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

            // For each player, create a node listing their weapons
            foreach (var player in enabledPlayers)
            {
                var weaponNode = new DialogNode
                {
                    Id = $"player_{player.Name}",
                    Speaker = player.Name,
                    Text = "Select a weapon to ready:",
                    Options = new List<DialogOption>()
                };

                if (player.Weapons != null && player.Weapons.Count > 0)
                {
                    foreach (var weapon in player.Weapons)
                    {
                        // If equipped, wrap with asterisks
                        string weaponText = weapon.IsEquipped ? $"*{weapon.Name}*" : weapon.Name;

                        weaponNode.Options.Add(new DialogOption
                        {
                            Text = weaponText,
                            NextNodeId = $"equip_{player.Name}_{weapon.ID}"
                        });

                        // Equip node: sets IsEquipped and ends dialog
                        var equipNode = new DialogNode
                        {
                            Id = $"equip_{player.Name}_{weapon.ID}",
                            Speaker = player.Name,
                            Text = $"{weapon.Name} is now equipped.",
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
                    weaponNode.Text = "No weapons available.";
                    weaponNode.Options.Add(new DialogOption
                    {
                        Text = "Back",
                        NextNodeId = "start"
                    });
                }

                // Add CANCEL option to weapon node
                weaponNode.Options.Add(new DialogOption
                {
                    Text = "CANCEL",
                    NextNodeId = "cancel"
                });

                dialogTree.Nodes.Add(weaponNode);
            }

            // End node
            var endNode = new DialogNode
            {
                Id = "end",
                Speaker = "==Ready Weapon==",
                Text = "Weapon readied.",
                Options = new List<DialogOption>()
            };
            dialogTree.Nodes.Add(endNode);

            // Cancel node
            var cancelNode = new DialogNode
            {
                Id = "cancel",
                Speaker = "==Ready Weapon==",
                Text = "Ready weapon dialog canceled.",
                Options = new List<DialogOption>()
            };
            dialogTree.Nodes.Add(cancelNode);

            // Store in memory for retrieval
            _readyWeaponDialogTree = dialogTree;
        }

        // Get a dialog tree by its DialogIndex
        public DialogTree? GetReadyWeaponDialogTree()
        {
            return _readyWeaponDialogTree;
        }

        private void EquipWeaponForPlayer(List<FantasyPlayer> players, string playerName, int weaponId)
        {
            var player = players.Find(p => p.Name == playerName);
            if (player != null && player.Weapons != null)
            {
                foreach (var weapon in player.Weapons)
                {
                    weapon.IsEquipped = (weapon.ID == weaponId);
                }
            }
        }

        public void ProcessNode(List<FantasyPlayer> players, DialogNode currentNode)
        {
            if (currentNode.Id.StartsWith("equip_"))
            {
                // Node ID format: equip_{playerName}_{weaponID}
                var parts = currentNode.Id.Split('_');
                if (parts.Length == 3)
                {
                    string playerName = parts[1];
                    if (int.TryParse(parts[2], out int weaponId))
                    {
                        EquipWeaponForPlayer(players, playerName, weaponId);
                    }
                }
            }
        }
    }
}