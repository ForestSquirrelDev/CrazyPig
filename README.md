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

### Classes
From time to time i use C# classes, MonoBehaviours and ScriptableObjects. Here is my general abstract pattern for choosing: 
- Does Unity framework let us create non-monobehaviour for desired purposes? If yes, does turning the script into non-MonoBehaviour make it easier to read and/or maintain the code?
- If the answer is still yes: does the script need to be modular, have multiple instances and/or be shared between components? Yes - ScriptableObject. No - C# class
- Otherwise i use MonoBehaviours

### Tweening
When i was working with DOTween in my previous project, i found out that my tweening methods are hevily tied to in-game references and are completely unreusable. I tried to learn from my comistakes - now tweening classes are pluggable scriptable objects, derived from abstract class TweenPlugin. If i want to tween something, i simply drag the scriptable object in MonoBehaviour field in the inspector and call the tweening method from this script. Or instantiate the scriptable object in memory if i need multiple copies.

### Scriptable object events
Long story short, this is basically a variation of observer pattern represented as a bit extended UnityEvent. Greatest advantages of this pattern is persistency of ScriptableObjects and possibility  to subscribe to events that do not exist in the scene yet. I used it to manage bombs, enemies and a lot more.

### Scriptable object variables pattern
One of the two patterns i used here to avoid singletons. [Here](https://github.com/ForestSquirrelDev/DependencyInversion#scriptableobject-variables) i've described my thoughts about this pattern. Long story short - it's a great solution to reference values (e.g. in UI) without creating tons of dependencies and references between components.

### Runtime sets
Another great pattern to avoid singletons. I used runtime sets to store count of all bombs and enemies in the scene.
