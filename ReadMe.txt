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
 
Version 1.0.0 - COMPLETE - Proof of concept prototype
You should be able to walk around the overworld map, enter towns, and exit towns.
Walking on the overworld map will wrap around when you reach the edge of the map.
Walking in the towns will not wrap around but exit when you reach the edge of the map.
You can also enter and exit vehicles (Balloon, Horse, Ship). 
Music should play appropriately based on the map you are on.
The game is in a very early stage of development and is not yet playable.

--TODO--

Version 2.0.0 - Implement Combat
	1) Combat mode Setting #1 - Implement random monsters on the map like the NES version with random attacks.
	Monsters are not visible on the map - you just get randomly attacked and go into combat mode.

	2) Combat mode Setting #2 - Implement random monsters visibly on the map (like PC Ultima IV).
	Monsters are visible on the map - you get attacked if you are adjacent to the monster.
	Move these monsters around the map toward the player.
	
	3) Implement turn based combat
		Show Combat map.
		Position all enemies on combat map.
		Position all the players on combat map.
	
	4) Implement auto combat option.

	5) After combat show gold chest on the map.

Version 3.0.0 - Towns\Shops\Dialog

	Populate towns with NPCs

	Randomly move NPCs around the town map.

	Populate towns with shops.

	Implement dialog/talking with NPCs.

Version 4.0.0 - Menu System
	Implement a quest system.
	Implement a spell system.
	Implement a journal.
	Implement a map.
	Implement a menu to equip and unequip items.
	Implement a spell book with a spell system.

Version 5.0.0 - Implement dungeons
	Dungeons should be a separate map that you can enter from the overworld map.
	A dungeon level will be similar to a tile based town map (Not first person view like in the original game).
	Saving in dungeons should be possible.

--Extra Ideas--
Ability to purchase shops for income.
Implement an underworld that connects the dungeons like in Ultima 5.
Implement a mountain pass dungeon that leads to an outpost in the middle of the mountains.
