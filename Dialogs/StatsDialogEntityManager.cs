﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Ultima45Monogame.Player;

namespace Ultima45Monogame.Dialogs
{
    public class StatsDialogEntityManager
    {
        private DialogTree? _statsDialogTree;

        public void BuildStatsDialogJSON(List<FantasyPlayer> players, List<FantasyWeapon> weaponinventory, List<FantasyArmor> armorinventory, Ultima4SaveGameVariables gameSaveVariables)
        {
            if (weaponinventory.Count == 0)
            {
                weaponinventory.Add(FantasyWeaponFactory.GetFantasyWeapon(0));
            }

            if (armorinventory.Count == 0)
            {
                armorinventory.Add(FantasyArmorFactory.GetFantasyArmor(0));
            }

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

                node.Options.Add(new DialogOption
                {
                    Text = "NEXT",
                    NextNodeId = i < enabledPlayers.Count - 1 ? $"player_{i + 1}" : "weapon_0"
                });

                node.Options.Add(new DialogOption
                {
                    Text = "PREVIOUS",
                    NextNodeId = i == 0 ? "reagents" : $"player_{i - 1}"
                });

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
                            NextNodeId = i < weaponinventory.Count - 1 ? $"weapon_{i + 1}" : "armor_0"
                        },
                        new DialogOption
                        {
                            Text = "PREVIOUS",
                            NextNodeId = i > 0 ? $"weapon_{i - 1}" : $"player_{enabledPlayers.Count - 1}"
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
                            NextNodeId = i < armorinventory.Count - 1 ? $"armor_{i + 1}" : "equipment"
                        },
                        new DialogOption
                        {
                            Text = "PREVIOUS",
                            NextNodeId = i > 0 ? $"armor_{i - 1}" : $"weapon_{weaponinventory.Count - 1}"
                        },
                        new DialogOption
                        {
                            Text = "EXIT",
                            NextNodeId = "end"
                        }
                    }
                });
            }

            // === EQUIPMENT NODE ===
            dialogTree.Nodes.Add(new DialogNode
            {
                Id = "equipment",
                Speaker = "==Equipment==",
                Text = GetEquipmentText(gameSaveVariables),
                Options = new List<DialogOption>
                {
                    new DialogOption
                    {
                        Text = "NEXT",
                        NextNodeId = "specialitems"
                    },
                    new DialogOption
                    {
                        Text = "PREVIOUS",
                        NextNodeId = $"armor_{armorinventory.Count - 1}"
                    },
                    new DialogOption
                    {
                        Text = "EXIT",
                        NextNodeId = "end"
                    }
                }
            });

            // === SPECIAL ITEMS NODE ===
            dialogTree.Nodes.Add(new DialogNode
            {
                Id = "specialitems",
                Speaker = "==Special Items==",
                Text = GetSpecialItemsText(gameSaveVariables),
                Options = new List<DialogOption>
                {
                    new DialogOption
                    {
                        Text = "NEXT",
                        NextNodeId = "runes"
                    },
                    new DialogOption
                    {
                        Text = "PREVIOUS",
                        NextNodeId = $"equipment"
                    },
                    new DialogOption
                    {
                        Text = "EXIT",
                        NextNodeId = "end"
                    }
                }
            });

            // === RUNES NODE ===
            dialogTree.Nodes.Add(new DialogNode
            {
                Id = "runes",
                Speaker = "==Runes==",
                Text = GetRunesText(gameSaveVariables),
                Options = new List<DialogOption>
                {
                    new DialogOption
                    {
                        Text = "NEXT",
                        NextNodeId = "stones"
                    },
                    new DialogOption
                    {
                        Text = "PREVIOUS",
                        NextNodeId = $"specialitems"
                    },
                    new DialogOption
                    {
                        Text = "EXIT",
                        NextNodeId = "end"
                    }
                }
            });

            // === STONES NODE ===
            dialogTree.Nodes.Add(new DialogNode
            {
                Id = "stones",
                Speaker = "==Stones==",
                Text = GetStonesText(gameSaveVariables),
                Options = new List<DialogOption>
                {
                    new DialogOption
                    {
                        Text = "NEXT",
                        NextNodeId = "reagents"
                    },
                    new DialogOption
                    {
                        Text = "PREVIOUS",
                        NextNodeId = $"runes"
                    },
                    new DialogOption
                    {
                        Text = "EXIT",
                        NextNodeId = "end"
                    }
                }
            });

            // === REAGENTS NODE ===
            dialogTree.Nodes.Add(new DialogNode
            {
                Id = "reagents",
                Speaker = "==Reagents==",
                Text = GetReagentsText(gameSaveVariables),
                Options = new List<DialogOption>
                {
                    new DialogOption
                    {
                        Text = "NEXT",
                        NextNodeId = enabledPlayers.Count > 0 ? "player_0" : "end"
                    },
                    new DialogOption
                    {
                        Text = "PREVIOUS",
                        NextNodeId = $"stones"
                    },
                    new DialogOption
                    {
                        Text = "EXIT",
                        NextNodeId = "end"
                    }
                }
            });

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
            if (armor.Name == "None")
            {
                return "None\n";
            }

            int count = armorinventory.Count(a => a.Name == armor.Name);

            return $"{count} {armor.Name}\n";
        }

        private string GetWeaponInventoryStatsText(List<FantasyWeapon> weaponinventory, FantasyWeapon weapon)
        {
            if (weapon.Name == "None")
            {
                return "None\n";
            }

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

        private string GetEquipmentText(Ultima4SaveGameVariables gameSaveVariables)
        {
            string stats =
                $"Torches: {gameSaveVariables.Torches}\n" +
                $"Gems: {gameSaveVariables.Gems}\n" +
                $"Keys: {gameSaveVariables.Keys}\n" +
                $"Sextants: {gameSaveVariables.Sextants}\n" +
                $"Food: {gameSaveVariables.Food}\n" +
                $"Gold: {gameSaveVariables.GP}\n";

            return stats;
        }

        private string GetSpecialItemsText(Ultima4SaveGameVariables gameSaveVariables)
        {
            string skullText = gameSaveVariables.SkullDestroyed
                ? $"Skull: {gameSaveVariables.Skull} (Destroyed)\n"
                : $"Skull: {gameSaveVariables.Skull}\n";

            string stats =
                $"Candle: {gameSaveVariables.Candle}\n" +
                $"Book: {gameSaveVariables.Book}\n" +
                $"Bell: {gameSaveVariables.Bell}\n" +
                $"Horn: {gameSaveVariables.Horn}\n" +
                $"Wheel: {gameSaveVariables.Wheel}\n" +
                skullText +
                $"Key of Courage: {gameSaveVariables.KeyPartC}\n" +
                $"Key of Love: {gameSaveVariables.KeyPartL}\n" +
                $"Key of Truth: {gameSaveVariables.KeyPartT}\n" +
                $"Key of Infinity: {gameSaveVariables.KeyOfInfinity}\n";

            return stats;
        }

        private string GetRunesText(Ultima4SaveGameVariables gameSaveVariables)
        {
            string stats =
                $"Rune of Honesty: {gameSaveVariables.RuneHonesty}\n" +
                $"Rune of Compassion: {gameSaveVariables.RuneCompassion}\n" +
                $"Rune of Valor: {gameSaveVariables.RuneValor}\n" +
                $"Rune of Justice: {gameSaveVariables.RuneJustice}\n" +
                $"Rune of Sacrifice: {gameSaveVariables.RuneSacrifice}\n" +
                $"Rune of Honor: {gameSaveVariables.RuneHonor}\n" +
                $"Rune of Spirituality: {gameSaveVariables.RuneSpirituality}\n" +
                $"Rune of Humility: {gameSaveVariables.RuneHumility}\n";

            return stats;
        }

        private string GetStonesText(Ultima4SaveGameVariables gameSaveVariables)
        {
            string stats =
                $"Blue Stone (Honesty): {gameSaveVariables.StoneBlue}\n" +
                $"Yellow Stone (Compassion): {gameSaveVariables.StoneYellow}\n" +
                $"Red Stone (Valor): {gameSaveVariables.StoneRed}\n" +
                $"Green Stone (Justice): {gameSaveVariables.StoneGreen}\n" +
                $"Orange Stone (Sacrifice): {gameSaveVariables.StoneOrange}\n" +
                $"Purple Stone (Honor): {gameSaveVariables.StonePurple}\n" +
                $"White Stone (Spirituality): {gameSaveVariables.StoneWhite}\n" +
                $"Black Stone (Humility): {gameSaveVariables.StoneBlack}\n";

            return stats;
        }

        private string GetReagentsText(Ultima4SaveGameVariables gameSaveVariables)
        {
            string stats =
                $"Black Pearl: {gameSaveVariables.SpellReagent_BlackPearl}\n" +
                $"Blood Moss: {gameSaveVariables.SpellReagent_BloodMoss}\n" +
                $"Garlic: {gameSaveVariables.SpellReagent_Garlic}\n" +
                $"Ginseng: {gameSaveVariables.SpellReagent_Ginseng}\n" +
                $"Mandrake Root: {gameSaveVariables.SpellReagent_MandrakeRoot}\n" +
                $"Nightshade: {gameSaveVariables.SpellReagent_Nightshade}\n" +
                $"Spider Silk: {gameSaveVariables.SpellReagent_SpiderSilk}\n" +
                $"Sulfurous Ash: {gameSaveVariables.SpellReagent_SulfurousAsh}\n";

            return stats;
        }
    }
}
