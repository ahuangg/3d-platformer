# MonsterMashup

Team: Wukong  
Team Members: Alan Huang, Kevin Liu, Peiqi Greene, Xuan Ma, YangLu Li  
Main Scene: GameScene

## Game Description:

MonsterMashup is an action-adventure platformer where players battle enemies and navigate challenging platforms to defeat the final dragon guarding the topmost platform. The game offers both combat and exploration elements, encouraging replayability through a timer and scoring system.

## How to play?

The following are the **controls** to MonsterMashup

-   ESC: Main Menu
-   WASD: Character Movement
-   Space: Jump
-   Q: Range attack
-   E or left click: Melee attack
-   G: God Mode (Player won't die and can move freely) , 1: Move upwards y axis, 2: Move downwards y axis, WASD : Move around
-   3, 4, 5: Checkpoints (Spawn, Checkpoint1, Boss Room)

## Technology Requirements

The following are the parts of the level to **observe** technology requirements

-   The player's objective is to defeat the dragon guarding the topmost platform. To reach the dragon, players must collect three keys and navigate through various platforms. To enhance the challenge, we've incorporated a combat system with both ranged and melee attacks, with limited ranged abilities. Additionally, we've included optional platforms that aren't necessary for game completion.To increase replayability, we've added a timer and a scoring system. Players earn scores based on their performance, whether they defeat the dragon or lose all three health points. This encourages players to strive for better scores in subsequent attempts.

-   Players can control their character using WASD keys for movement and the Spacebar for jumping. Smooth animations accompany each movement. The game offers both first-person and third-person perspectives, providing flexibility in viewing the game world.

-   Enemies possess detection capabilities and will actively pursue the player within a certain range. We've implemented both waypoint-based and aggro-based AI behaviors. Waypoint-based enemies, like turtles, follow predefined paths, while aggro-based enemies, such as slimes and the dragon, directly target the player. Press 5 to go to the Dragon for fly to the platform with the turtle/slimes

-   Platforms utilize physics and collision detection to interact with the player, potentially causing damage or providing a jump boost. Slippery platforms add an extra layer of challenge. The combat system relies on collision detection to register damage. Destructible crates with collectable items exhibit state changes upon destruction. Collectible items, including coins, health potions, keys, and mana potions, are detected through collision.

-   The UI displays the player's resource levels. The main menu offers options for restarting, quitting, and adjusting sound settings.

## Known Problem Areas:

-   Environment Collisions: Some areas in the environment still have less-than-ideal collision settings, leading to potential player frustration or unintended interactions.
-   Character Movement: Movement mechanics require further polishing to improve responsiveness, fluidity, and overall player control.
-   Animations: The game requires additional animations to better convey character actions and enhance overall visual appeal.
-   Combat Engagement: Combat feedback needs enhancement to make battles more immersive and satisfying.

## Manifest

The follow is a manifest of files **created** by their respective authors

### Kevin Liu

-   RootMotionControlScript.cs
-   CharacterInputController.cs
-   BasicControlScript.cs
-   Projectile.cs
-   Game elements created:
    Player

    Kevin mainly worked on the main character, including the control, movement, and animations.
    An object can be thrown by the character to a certain direction as his range attack, and the logic is inside Projectile.cs script.
    When the user enters the "Q" key, the projectile can be generated in the map as the range attack weapon.

### Yanglu Li

-   Worked on MainMenu scene to add some functionalities and art work in main menu.
-   Worked on In-game menu.
-   Implemented SoundDialogMenu to control music and SFX.
-   Implemented GamePlayDialogMenu to adjust controller sensitivity; to invert Y axis.
-   Implemented GraphicsDialogMenu to adjust brightness; to choose resolution; to choose quality; to select fullscreen.
-   Worked on Audio; Audio Mixer; Audio manager; and Volume Settings.
-   Imported some music and UI resources from Unity asset store.

-   GameStarter.cs
-   GameQuitter.cs
-   PauseMenuToggle.cs
-   PortalGateScript.cs
-   AudioManager.cs
-   VolumeSettings.cs
-   MenuController.cs
-   LoadPrefs.cs

### Peiqi Greene

-   Worked on the game map based on the initial block-out areas (placeholders) and environment game objects
-   Environment design and collision/physical material settings
-   Added moving, falling, bouncy, and damaging/spinning platforms and obstacles to the map
-   Platform placement fine-tuning and movements/waypoints to make sure places are reachable by the player character
-   Added environment details (including but not limited to hills, grass, flowers, butterflies, tress, stones/rocks, village-look decorations, clouds affected by mild wind directions, etc.)
-   Added collectibles: Placed coins throughout the map to roughly help indicate the directions; placed potions throughout the map; placed 3 key crates in the map, one on a falling platform, one hidden in a cave in the snow area, and one on the slippery platform
-   Helped fine-tune enemy collider ranges and health settings

-   Implemented environment game objects that are interactive or randomly move within certain ranges:
-   SinkableCloud.cs
-   ButterflySpawn_KG.cs
-   ButterflySpawnArea_KG.cs
-   MovingCloud.cs

-   External assets from unity asset store:
    Rocks and Terrains Pack - Low Poly;
    Idyllic Fantasy Nature;
    Low-Poly Simple Nature Pack;
    Lowpoly Forest Pack Winter;
    POLYART_Ancient Village

### Alan Huang

Alan contributed to multiple aspects of the project, beginning with the initial platform design, where he created the level layout and blocked out the platforms. He also developed several gameplay mechanics, including interactive platform features, a God Mode system that grants players invincibility, and a responsive combat system. Additionally, Alan implemented the collectable interaction system, ensuring smooth integration between collectable items and player interactions.

Beyond gameplay mechanics, Alan worked on placing game objects across platforms to enhance the environment and player experience. He also took responsibility for organizing the project structure by managing the hierarchy, file directories, and files to maintain a clean and efficient workflow.

These are the files **implemented** by Alan Huang

-   CameraController.cs
-   FlyingCharacterController.cs
-   CharacterRespawnController.cs
-   Coin.cs
-   Collectable.cs
-   Key.cs
-   MeleeAttack.cs
-   Projectile.cs
-   RangedAttack.cs
-   CheckpointManager.cs
-   DamageManager.cs
-   GodModeManager.cs
-   TimeManager.cs
-   Health.cs
-   Mana.cs
-   FallingPlatform.cs
-   JumpPlatform.cs
-   MovingPlatform.cs
-   PlatformRotator.cs
-   TextManager.cs
-   GameMenu.unity
-   GameScene.unity

These are the assets **imported** by Alan Huang

-   ProBuilder
-   RPG Pack(Health Potion, Mana Potion, Coin, Crate)
-   Rust Key(Key)
-   VarcanRex (Sword)
-   Training_dummy (training dummy)
-   Verfect (Fire Particles)
-   BoatAttack (Water System)
-

### Xuan Ma

-   AI Enemies
-   EnemyController.cs
-   EnemyController1.cs
-   Patrol.cs
-   SlimeAudio.cs
-   Worked on AI enemies, slime (chase the player), turtle (Patrol waypoints), spike (damage player near player) and the final boss dragon (chase the player). Updated the enemies with animations and sound effects.
