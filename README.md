# CrazyPig
## Gameplay.
1. Player. Pig can move around, pick bombs and drop them. Pig has hp - currently it's not enough to survive a single hit, but it's adjustable to any value.
2. Bombs. They are spawned at the start of the level and/or after all bombs are used. Random or constant number of bombs to spawn might be chosen. Bomb sticks to the player if he picks it and can be released before explosion.
3. Enemies are driven by NavMesh. If player is not in the line of sight, enemies just pick random points on the map to run around. If they spot player (line of sight is made through circle trigger collider), they speed up and start chasing him until player dies or runs out of aggro range. For killing the enemy player gets score, value for every enemy is adjustable in editor.
4. Enemy spawner. It has two options: first one is to spawn enemies simply by timer, second one - periodically check if all enemies are dead and call new troops after that.

## General code architecture
### What i was sctrictly avoiding code-wise
1. Singletons. My general rule is - if it can be done without singleton, it probably should be. Singletons are very hard-to-debug and restrictive.
2. Global static fields. They break many rules of clean code and make project architecture harder to maintain, scale and test.
3. Giant game managers/controllers. In most situations responsibilities can be split between different classes.
