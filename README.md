# Meltdown Minigame
---------------------

This is a Meltdown-style game developed in Unity 2021.3. Players must jump over the obstacles and the last one to survive wins.

-----------
Features
------------

- The game uses a modular state machine to handle player and npc actions. <br>
- The player can jump, and duck to avoid the obstacles.<br>
- NPCs can be created and customized, and their behavior can be programmed using the state machine.<br>
- The game flow diagram provides an overview of the different stages of the game and how they are connected.<br>
- The player state diagram shows the different states the player can be in and how they transition between each other.<br>
- The game supports customizable controls, allowing the player to assign keys and buttons to different actions.<br>

-----------
How to Play
------------

The objective of the game is to be the last player standing in a battle royale-style game. Players must jump, duck, and dodge obstacles to avoid being knocked out by incoming obstacles. 

The controls for the game are simple. Players can jump by pressing the "Jump" button assigned and duck by pressing the "Duck" button assigned in the selection menu. Players must use their timing and reflexes to dodge incoming obstacles.

-----------
Game Flow Diagram
------------
![alt text](https://github.com/FcoReyesV/MeltdownMinigame/blob/86b811d8519aafef2afc527d33baab831e359e8c/Assets/Diagrams/Meltdown%20Diagrams_GameFlow.jpg)

-----------
Player FSM Diagram
------------
![alt text](https://github.com/FcoReyesV/MeltdownMinigame/blob/86b811d8519aafef2afc527d33baab831e359e8c/Assets/Diagrams/Meltdown%20Diagrams_PlayerFSM.jpg)
