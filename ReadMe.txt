DEBUGGING KEYS:
ESC - Exit game
F1 Toggle 
P - Pause game
Shift-F12 - Save Game
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
J - Jimmy lock
O - Open door

Version 1.0.0 - COMPLETE - Proof of concept prototype
You should be able to walk around the overworld map, enter towns, and exit towns.
Walking on the overworld map will wrap around when you reach the edge of the map.
Walking in the towns will not wrap around but exit when you reach the edge of the map.
You can also enter and exit vehicles (Balloon, Horse, Ship). 
Music should play appropriately based on the map you are on.
The game is in a very early stage of development and is not yet playable.

Version 2.0.0 - NES Random Attacks, Hole Up & Camp and Camp Combat Map,
	Leave Gold Chest on overworld map after combat,
	Full Monster catalog with TileTypes,
	Getting chest on overworld map increases party gold
	Add CombatTracker class to track combat events
	Place up to 16 Monsters on Combat Map using CombatTracker
	Place up to 8 Players on Combat Map using CombatTracker

Version 3.0.0 - Shrine combat locations
	Peer at Gem on Overworld map and in Towns
	Stretch all the maps to fit the screen
	Town Entity, Town Entity Manager, Town Entity Factory
	Draw Lord British Town Entity on the map
	Prevent player from moving on top of NPCs in towns.
	Implement working doors in towns - Open door, Jimmy locked door.

--TODO--	
	
	Populate towns with NPCs Town Entity's.

	Random # of monsters on the combat map needs to show less monsters more often - maybe based on the players level.
	
Version 3.0.0 - Towns\Shops\Dialog

	Randomly move NPCs around the town map.

	Populate towns with shops.

	Implement dialog/talking with NPCs.

Version 4.0.0 - Menu System
	Implement a quest system.
	Implement a spell system.
	Implement a journal.
	Implement a menu to equip and unequip items.
	Implement a spell book with a spell system.

Version 5.0.0 - Implement dungeons
	Dungeons should be a separate map that you can enter from the overworld map.
	A dungeon level will be similar to a tile based town map (Not first person view like in the original game).
	Saving in dungeons should be possible.

Future - Combat mode Setting #2 - Implement random monsters visibly on the map (like PC Ultima IV).
	Monsters are visible on the map - you get attacked if you are adjacent to the monster.
	Move these monsters around the map toward the player.
	
Future - Implement turn based combat

Future - Implement auto combat option.

--Extra Ideas--
Ability to purchase shops for income.
Implement an underworld that connects the dungeons like in Ultima 5.
Implement a mountain pass dungeon that leads to an outpost in the middle of the mountains.
