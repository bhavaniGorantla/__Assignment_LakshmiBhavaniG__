# __Assignment_LakshmiBhavaniG__
3D Snake Game

Specifications
Scenes
1. MainScene

Starting scene in the game
"Play" button loads the game scene
"Score" - shows the player's all time highest score

Game Scene

As soon as gamescene is loaded player[snake] starts to move forward .
Use keyboard keys to move in directions: 
A - to move left
W - to move upwards
S - to move down
D - to move right

Food & Score Logic: 

Food prefab spawns every time player eats the food. 

There are two types of food which are generated randomly: 
Yellow: Score += 20
Yellow Streak 2  - Score = 20 * Streak count (i.e 2)
Yellow Streak 3  - Score = 20 * Streak count (i.e 3)

Red: Score += 30
Red Streak 2  - Score = 30 * Streak count (i.e 2)
Red Streak 3  - Score = 30 * Streak count (i.e 3)

Gameover Logic:

If the player hits the wall, then the game ends. A gameover screen appears displaying

Score: Recent Score
BestScore: All time best score
"OK" button - On press, redirects to main scene

Video Link : 
https://drive.google.com/open?id=1_363cmOXGXUUsCG-92QvZzylOoX4xH6g


