DEBUGGING KEYS:
ESC - Exit game
F1 Toggle 
P - Pause game
Q - Save Game
F12 - Load Game
F2 - Teleport to Town Prev
F3 - Teleport to Town Next
F4 - Change Vehicle Prev
F5 - Change Vehicle Next
F6 - Show Combat Map Prev
F7 - Show Combat Map Next
E - Enter Town or Vehicle
X - Exit Vehicle
K - Klimb Stairs
D - Descend Stairs
H - Hole Up & Camp
G - Get Gold Chest
V - View (Peer at Gem)
J - Jimmy lock (Plus direction key)
O - Open door (Plus direction key)
S - Search
T - Talk to NPC (Plus direction key)
W - Wear Armor (select from armor dialog)
R - Ready Weapon (select from weapon dialog)
U - Use Item (select from item dialog)

C - Cast Spell (select from spell dialog, possible direction key)

Version 1.0.0 - COMPLETE - Proof of concept prototype
You should be able to walk around the overworld map, enter towns, and exit towns.
Walking on the overworld map will wrap around when you reach the edge of the map.
Walking in the towns will not wrap around but exit when you reach the edge of the map.
You can also enter and exit vehicles (Balloon, Horse, Ship). 
Music should play appropriately based on the map you are on.
The game is in a very early stage of development and is not yet playable.

Version 2.0.0 - COMPLETE - NES Random Attacks, Hole Up & Camp and Camp Combat Map,
	Leave Gold Chest on overworld map after combat,
	Full Monster catalog with TileTypes,
	Getting chest on overworld map increases party gold
	Add CombatTracker class to track combat events
	Place up to 16 Monsters on Combat Map using CombatTracker
	Place up to 8 Players on Combat Map using CombatTracker

Version 3.0.0 - COMPLETE - Shrine combat locations
	Peer at Gem on Overworld map and in Towns
	Stretch all the maps to fit the screen
	Town Entity, Town Entity Manager, Town Entity Factory
	Draw Lord British Town Entity on the map
	Prevent player from moving on top of NPCs in towns.
	Implement working doors in towns - Open door, Jimmy locked door.
	Implement Search in towns - Search for hidden items.
	Display message at bottom of screen
	Play music after pausing

Version 4.0.0 - COMPLETE
	Implement dialog/talking with NPCs.
	Pressing T to talk and then pressing a direction key will walk to the NPC and start dialog.
	Press O and then a direction key to open a door.
	Press J and then a direction key to jimmy a locked door.
	Add more properties to weapons, armor, and equipment.
	Add weapons and armor to players.
	Pressing W to Wear Armor	
	Pressing R to Ready a Weapon
	Pressing U to Use Item
	Proper default weapon and armor for players.

--TODO--
	Z - Stats (Pres Z to show player stats, right and left to next/prev player stats, inventory))
	C - Cast Spell (Non-Combat)
	
	Populate Britain with NPCs Town Entity's.

	Populate towns with shops.
	
Version 5.0.0 - Towns\Shops\Dialog

	Random # of monsters on the combat map needs to show less monsters more often - maybe based on the players level.
	
Version 6.0.0 - Menu System
	Implement a journal system.
	Implement a quest system.

Version 7.0.0 - Implement dungeons
	Dungeons should be a separate map that you can enter from the overworld map.
	A dungeon level will be similar to a tile based town map (Not first person view like in the original game).
	Saving in dungeons should be possible.

Future - Combat mode Setting #2 - Implement random monsters visibly on the map (like PC Ultima IV).
	Monsters are visible on the map - you get attacked if you are adjacent to the monster.
	Move these monsters around the map toward the player.
	
Future - Implement turn based combat

Future - Implement auto combat option.

Future - Randomly move NPCs around the town map.

--Extra Ideas--
Ability to purchase shops for income.
Implement an underworld that connects the dungeons like in Ultima 5.
Implement a mountain pass dungeon that leads to an outpost in the middle of the mountains.
