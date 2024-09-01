Algorithms:
1. Randomization:
    * Random Slice Sound: The PlayRandomSliceSound method in GameManager selects a random sound from an array of slice sounds using Random.Range.
    * Random Fruit Spawning: The Spawner class uses Random.Range to select random spawn positions, spawn intervals, and to determine whether a bomb or a fruit should be spawned.
2. Collision Detection:
    * Blade Movement Detection: The IsMouseMoving method in Blade calculates the movement of the blade by comparing the current and last mouse positions to determine if the blade is moving.
    * Fruit Slicing: The OnTriggerEnter2D methods in Fruit and Bomb detect collisions with the Blade and trigger appropriate actions (e.g., slicing fruit, triggering a bomb).
3. Physics Simulation:
    * Explosion Force: The CreateSlicedFruit method in Fruit applies explosion forces to the sliced fruit pieces using Rigidbody.AddExplosionForce to simulate a realistic cutting effect.

Design Patterns:
1. Singleton Pattern:
    * GameManager: The GameManager class implements a Singleton pattern by ensuring only one instance of the class exists. This is done through a static instance variable and the Awake method, which enforces the singleton behavior.
2. Observer Pattern (implicit):
    * Highscore Management: Although not a full implementation of the observer pattern, the highscore is updated and saved whenever the score changes, similar to how observers react to changes in the subject's state.
3. Factory Pattern:
    * Fruit and Bomb Instantiation: The Spawner class acts as a simple factory by instantiating fruit and bomb objects based on random probability and spawning logic.
4. State Pattern (implicit):
    * Game States: The game transitions between different states (playing, game over) managed by methods like OnBombHit and RestartGame in GameManager.
5. Component Pattern:
    * Unity Components: The classes (Blade, Bomb, Fruit, Spawner, and GameManager) derive from MonoBehaviour and utilize Unity's component-based architecture to define game behavior.


Detailed Breakdown of Each Script:

GameManager:
* Manages the game state, score, highscore, and audio.
* Uses Singleton to ensure only one instance is active.
* Handles score updates and game over logic.
* Plays sounds using the AudioSource component.

Blade:
* Handles blade movement based on mouse input.
* Enables or disables the collider based on movement to detect collisions only when the blade is moving.

Bomb:
* Detects collisions with the blade and triggers the game over sequence via GameManager.
Fruit:
* Handles slicing logic, including playing sounds, instantiating sliced fruit pieces, and applying physics forces.
* Increases the score via GameManager.

Spawner:
* Continuously spawns fruits and bombs at random intervals and positions.
* Applies force to spawned objects to simulate throwing them into the air.
