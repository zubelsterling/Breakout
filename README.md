# Breakout
The game breakout from scratch!

### Approach
 - I want to make a thorough, decoupled design, that can be iterated on easily.
 - There might be places where I use design principles that seem too robust for a simple game, but I would like to show my knowledge.

### File names cheat sheet
- Managers manage multiple scripts or game objects. Game manager is concerned with game level logic, such as whether to advance to the next level, whereas the brick manager is concerned with the number of bricks on screen.
 - Controllers are intended to control a game object. I could have a game object and a movement script, and the controller script is intended to be the middle man and possibly enable/disable the movement script.
 - Handlers generally have one job and are meant to do that task well.
 - The distinction between each of these classes is meant to allow for modularity and keep a close watch on separation of concern.

 - An example of the above structure is as follows.
 
 - The brick manager holds a brick spawner along with the bricks that get spawned.
 - Each brick is controlled by the brick controller. The controller script is only concerned with what behaviors the brick might be involved in (spawning, hiding, etc.).
 - Each brick controller also has a brick collision handler, the handler is only meant to handle the collision on the brick. Seperating out the collision allows for custom behavior.

### Controls
 - Arrow left/right -> move platform
 - esc - options / return to menu?

### preplanning
- Map editing
  - Will need to make this a config file pipeline, I am thinking the CSV format could work
  - Potential for a map editor in game
- Use OOP and Design prinicples where possible
- Int to Binary back to Int will be used in scoring


### Initial pass on class diagram
![image](https://github.com/user-attachments/assets/beccae63-e9fe-4821-8cea-2d07750153d6)

### In the base game, the platform has 6 distinct launch angles.
 - with that said, here is my interpretation of potential launch angles for the ball via drawing
![image](https://github.com/user-attachments/assets/576fdef3-d0e6-49a6-9618-aa852b0f200a)
