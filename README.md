# CrazyPig


https://user-images.githubusercontent.com/82777171/129457013-5d9fc33a-83f0-4312-8735-9765fbaf7535.mp4


## Gameplay.
1. Player. Pig can move around, pick bombs and drop them. Pig has hp - currently it's not enough to survive a single hit, but it's adjustable to any value. For movement it's possible to pick between editor movement and mobile input.
2. Bombs. They are spawned at the start of the level and/or after all bombs are used. Random or constant number of bombs to spawn might be chosen and adjusted in the inspector. Bomb sticks to the player if he picks it and can be released before explosion.
3. Enemies are driven by NavMesh. If player is not in the line of sight, enemies just pick random points on the map to run around. If they spot player (line of sight is made through circle trigger collider), they speed up and start chasing him until player dies or runs out of aggro range. For killing the enemy player gets score. All parameters of enemies are stored in ScriptableObject and are adjustable: default speed, raged speed (when spotted player), HP etc.
4. Enemy spawner. It has two options: first one is to spawn enemies simply by timer, second one - periodically check if all enemies are dead and call new troops after that. 

## Code architecture
### What i was sctrictly avoiding code-wise
1. Singletons. My general rule is - if it can be done without singleton, it probably should be. Singletons are very hard-to-debug and restrictive. Also in project of such size there is simply no need in singletons.
2. Global static fields. They break many rules of clean code and make project architecture harder to maintain, scale and test.
3. Giant game managers/controllers. In most situations responsibilities can be split between different classes.
