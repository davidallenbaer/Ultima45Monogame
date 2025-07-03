using System;
using System.Collections.Generic;
using System.Linq;
using Ultima45Monogame.Player;

namespace Ultima45Monogame.Dialogs
{
    public class StatsDialogEntityManager
    {
        private DialogTree? _statsDialogTree;

        public void BuildStatsDialogJSON(List<FantasyPlayer> players, List<FantasyWeapon> weaponinventory, List<FantasyArmor> armorinventory, Ultima4SaveGameVariables gameSaveVariables)
        {
            var enabledPlayers = players.FindAll(p => p.IsEnabled);
            var dialogTree = new DialogTree
            {
                Id = "StatsDialog",
                DialogIndex = "StatsDialog",
                Nodes = new List<DialogNode>()
            };

            // === PLAYER STATS NODES ===
            for (int i = 0; i < enabledPlayers.Count; i++)
            {
                var player = enabledPlayers[i];
                var node = new DialogNode
                {
                    Id = $"player_{i}",
                    Speaker = $"=={player.Name}'s Stats==",
                    Text = GetPlayerStatsText(player),
                    Options = new List<DialogOption>()
                };

                if (i < enabledPlayers.Count - 1)
                {
                    node.Options.Add(new DialogOption
                    {
                        Text = "NEXT",
                        NextNodeId = $"player_{i + 1}"
                    });
                }
                else
                {
                    string nextId;
                    if (weaponinventory.Count > 0)
                        nextId = "weapon_0";
                    else if (armorinventory.Count > 0)
                        nextId = "armor_0";
                    else
                        nextId = "player_0"; // loop back if nothing else

                    node.Options.Add(new DialogOption
                    {
                        Text = "NEXT",
                        NextNodeId = nextId
                    });
                }

                if (i == 0)
                {
                    // Wrap to the last available node in reverse order: armor > weapon > player
                    string previousId;
                    if (armorinventory.Count > 0)
                        previousId = $"armor_{armorinventory.Count - 1}";
                    else if (weaponinventory.Count > 0)
                        previousId = $"weapon_{weaponinventory.Count - 1}";
                    else if (enabledPlayers.Count > 1)
                        previousId = $"player_{enabledPlayers.Count - 1}";
                    else
                        previousId = "end";

                    node.Options.Add(new DialogOption
                    {
                        Text = "PREVIOUS",
                        NextNodeId = previousId
                    });
                }
                else
                {
                    node.Options.Add(new DialogOption
                    {
                        Text = "PREVIOUS",
                        NextNodeId = $"player_{i - 1}"
                    });
                }

                node.Options.Add(new DialogOption
                {
                    Text = "EXIT",
                    NextNodeId = "end"
                });

                dialogTree.Nodes.Add(node);
            }

            // === WEAPON INVENTORY NODES ===
            for (int i = 0; i < weaponinventory.Count; i++)
            {
                dialogTree.Nodes.Add(new DialogNode
                {
                    Id = $"weapon_{i}",
                    Speaker = "==Weapon Inventory==",
                    Text = GetWeaponInventoryStatsText(weaponinventory, weaponinventory[i]),
                    Options = new List<DialogOption>
            {
                new DialogOption
                {
                    Text = "NEXT",
                    NextNodeId = i < weaponinventory.Count - 1
                        ? $"weapon_{i + 1}"
                        : (armorinventory.Count > 0 ? "armor_0" : "end") // link to armor_0
                },
                new DialogOption
                {
                    Text = "PREVIOUS",
                    NextNodeId = i > 0 ? $"weapon_{i - 1}" : (enabledPlayers.Count > 0 ? $"player_{enabledPlayers.Count - 1}" : "end")
                },
                new DialogOption
                {
                    Text = "EXIT",
                    NextNodeId = "end"
                }
            }
                });
            }

            // === ARMOR INVENTORY NODES ===
            for (int i = 0; i < armorinventory.Count; i++)
            {
                dialogTree.Nodes.Add(new DialogNode
                {
                    Id = $"armor_{i}",
                    Speaker = "==Armor Inventory==",
                    Text = GetArmorInventoryStatsText(armorinventory, armorinventory[i]),
                    Options = new List<DialogOption>
                    {
                        new DialogOption
                        {
                            Text = "NEXT",
                            NextNodeId = i < armorinventory.Count - 1 ? $"armor_{i + 1}" : "player_0" // Loop back to first player
                        },
                        new DialogOption
                        {
                            Text = "PREVIOUS",
                            NextNodeId = i > 0
                                ? $"armor_{i - 1}"
                                : (weaponinventory.Count > 0
                                    ? $"weapon_{weaponinventory.Count - 1}"
                                    : (players.Count > 0
                                        ? $"player_{players.FindAll(p => p.IsEnabled).Count - 1}"
                                        : "end"))
                        },
                        new DialogOption
                        {
                            Text = "EXIT",
                            NextNodeId = "end"
                        }
                    }
                });
            }

            // === END NODE ===
            dialogTree.Nodes.Add(new DialogNode
            {
                Id = "end",
                Speaker = "==Stats==",
                Text = "Exiting stats screen.",
                Options = new List<DialogOption>()
            });

            dialogTree.StartNodeId = enabledPlayers.Count > 0 ? "player_0" : "end";
            _statsDialogTree = dialogTree;
        }

        public DialogTree? GetStatsDialogTree()
        {
            return _statsDialogTree;
        }

        private string GetArmorInventoryStatsText(List<FantasyArmor> armorinventory, FantasyArmor armor)
        {
            int count = armorinventory.Count(a => a.Name == armor.Name);
            return $"{count} {armor.Name}\n";
        }

        private string GetWeaponInventoryStatsText(List<FantasyWeapon> weaponinventory, FantasyWeapon weapon)
        {
            int count = weaponinventory.Count(a => a.Name == weapon.Name);
            return $"{count} {weapon.Name}\n";
        }

        private string GetPlayerStatsText(FantasyPlayer player)
        {
            string classText = string.Empty;
            string weaponText = string.Empty;
            string armorText = string.Empty;

            if (player.Weapons != null && player.Weapons.Count > 0)
            {
                foreach (var weapon in player.Weapons)
                {
                    if (weaponText.Length > 0)
                    {
                        weaponText += ", ";
                    }

                    if (weapon.IsEquipped)
                    {
                        weaponText += $"{weapon.Name}";
                    }

                }
            }

            if (player.Armor != null && player.Armor.Count > 0)
            {
                foreach (var armor in player.Armor)
                {
                    if (armorText.Length > 0)
                    {
                        armorText += ", ";
                    }

                    if (armor.IsEquipped)
                    {
                        armorText += $"{armor.Name}";
                    }

                }
            }

            if (player.Classes != null && player.Classes.Count > 0)
            {
                foreach (var pcClass in player.Classes)
                {
                    if (classText.Length > 0)
                    {
                        classText += ", ";
                    }

                    classText += $"{pcClass.Name}";
                }
            }

            string stats =
                $"Name: {player.Name}\n" +
                $"Class: {classText}\n" +
                $"Level: {player.Level}\n" +
                $"HP: {player.HP} / {player.MaxHP}\n" +
                $"MP: {player.MP} / {player.MaxMP}\n" +
                $"STR: {player.Strength}  " + $"DEX: {player.Dexterity}  " + $"CON: {player.Constitution}\n" +
                $"INT: {player.Intelligence}  " + $"WIS: {player.Wisdom}  " + $"CHA: {player.Charisma}\n" +
                $"Weapon: {weaponText}\n" +
                $"Armor: {armorText}\n" +
                $"XP: {player.XP}\n";

            return stats;
        }
    }
}
