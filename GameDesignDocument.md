# MAIN ROLES

## User Interface
There is a popup dialogue panel that will appear whenever your character tries to talk to an NPC. The text will be parsed to show up without overflowing accordingly. If the player has a choice to make from the conversation, then the choice buttons will pop up on the screen. We have IDs that accordingly indicate what is the next conversation the player will have with the NPC.

There will be an "empathy" value measurement on the screen that indicates to the player how much closer they are to moving on in the game.

## Movement/Physics

#### H4 Initial Player / NPC Movement Design

This portion was implemented initially by our animator. (JOANNE explain why you implemented this in your role as animator here: probably mention inspiration from Zee's Final Combat game)

#### H4 Collision Detection and Natural Boundaries
Physics and animation worked closely on placement of 2D sprites witin the town to tell an implicit story as well as give the town more realism. For example, the graveyard in the middle of town hints at the town's grim past. 

In implementing collisions I had to determine which sprites would make sense to collide with. The collidable town border is intended to give the player an illusion of an infinite game world as well as keep them safely within the designed portion of the town. Collidable objects encompass all objects we would naturally not be able to walk over in a standard physics model (i.e. ponds, rocks, houses, etc.). By setting the box collider to only the Player's feet and setting it to a higher layer than all other sprites, we allow the Player to realistically stand in front of objects in the town. 

#### H4 Camera Design
The Main Camera, which is utilized while the player traverses the outside town, follows a position lock lerp camera controller script called **CameraController** which is locked on the Player. This camera is clamped to specific X and Y values so the player never sees beyond the edges of the designed game world and the infinite game world illusion is preserved.  

Upon colliding with the door of each of the three NPC's homes, a camera switch to the respective home. An empty game object with a 2D Box Collider (RedDoor, CastleDoor, BarrelDoor) is positioned on each door step to trigger this camera switch in the **EnterHouse** script. The player is transported to the inside of the house they attempted to answer. The camera positioned on each house are fixed (not lerp) because the inside of houses are smaller than the camera size. 

Upon colliding with the doormat of each of the three NPC's homes, the game switches back to the main camera and transports the player just outside the door of the house they entered before. Similar to entry, an empty game object with a 2D Box Collider (RedDoormat, CastleDoormat, BarrelDoormat) is positioned on the doormat of each home that triggers a camera switch in the **ExitHouse** script. The size of these colliders were finetuned so that the entrance places the player at a reasonable distance inside the home without triggering the exit collider while it still appears the player has just entered the home. The separation of the **EnterHouse** and **ExitHouse** house scripts allows different behaviors, such as sound effects, to be associated with entering and exiting a home. 

#### H4 Conversation Triggers
Once within a certain circular radius of NPCs that can be talked to, a conversation can be triggered. To implement this I created empty gameobjects with 2D circle colliders for each NPC that can be talked to (CCharacterRadius, GuardRadius, etc.). The **TriggerConversation** script ensures this gameobject snaps to it's respective NPC each frame. The **TriggerConversation** script provides the framing that allows us to trigger certain behavior when the Player enters the circle collider and when they exit. In the main use case, only when a Player has entered and remains within the circle collider, they will be able to trigger a conversation with the NPC.

## Animation and Visuals
To keep the art style consistent, the main asset packages used will all be of the Liberated Pixel Cup (LPC) art style. More about the LPC can be found here: http://lpc.opengameart.org. More specifically, the following asset packages will be used for tilemaps and character sprites for this game:
* "Liberated Pixel Cup (LPC) Base Assets (sprites & map tiles)" by Lanea Zimmerman (AKA Sharm), Stephen Challener (AKA Redshrike), Charles Sanchez (AKA CharlesGabriel), Manuel Riecke (AKA MrBeast), and Daniel Armstrong (AKA HughSpectrum) licensed CC-BY-SA 3.0 or GPL 3.0: https://opengameart.org/content/liberated-pixel-cup-lpc-base-assets-sprites-map-tiles.
* “Bunny Rabbit LPC style for PixelFarm” by Stephen Challener (AKA Redshrike) licensed CC-BY 3.0, CC-BY-SA 3.0, or OGA-BY 3.0: https://opengameart.org/content/bunny-rabbit-lpc-style-for-pixelfarm.
* "LPC Tile Atlas2" by Barbara Rivera, Casper Nilsson, Chris Phillips, Daniel Eddeland, Anamaris and Krusmira (AKA Emilio J Sanchez), Jonas Klinger, Joshua Taylor, Leo Villeveygoux, Mark Weyer, Matthew Nash, Skyler Robert Colladay, Lanea Zimmerman (AKA Sharm), Stephen Challener (AKA Redshrike), Charles Sanchez (AKA CharlesGabriel), Manuel Riecke (AKA MrBeast), and Daniel Armstrong (AKA HughSpectrum) licensed CC-BY-SA 3.0 or GPL 3.0: https://opengameart.org/content/lpc-tile-atlas2.

The first of these packages includes environmental 32x32 pixel tile squares that will be used to draw out maps of the village and houses that the player character will be able to explore. The tiles will be drawn on different layers to separate the maps’ visual representation from collidable objects for physics. The main village will contain three houses that the player character will be able to enter and meet different NPCs in. The interiors of each of these three houses will be similar in appearance but decorated with different furnitures and wall colors to give the impression that these houses are inhabited by different people.

For this game, we want to have a player character and five non-playable characters. Although the LPC Base Assets package only contains two premade character sprites, the package does include blank character templates to make additional male and female characters. So, using the provided “base walkcycle” and “hairstyle” files, four custom character sprites will be created to present visually different looking NPCs in the game.

To animate each of these characters, the “walkcycle” sprites of each character will be spliced up and then used to create Left / Right / Up / Down animations. Code will be written to decide which animation to display depending on which direction (X or Y direction) the character is moving in on the map. The player character’s movement will be based on player input, while the NPCs will be set to randomly move about the map upon the game’s start to give the feel that the village is alive with living people.

The second of the listed asset packages contains more tile squares that will be used to further decorate the village map with additional village-related objects and explorable areas, such as a graveyard. These tiles will all contribute to making the village feel more like an actual village.

The last asset package will be used for a bunny NPC. This package specifically contains premade sprites of an animated bunny, which will be placed to randomly move about on the main village map to help make the village appear more alive.

## Input

### The Input Scheme
Left Arrow (or A): Move character left
Right Arrow (or D): Move character right
Up Arrow (or W): Move character up
Down Arrow (or S): Move character down

Walk up to NPC and press Spacebar: Initiate Conversation
When in conversation (or backstory), press Spacebar: View next bit of text
When in conversation, press Left UI Button: Make choice 1 in conversation
When in conversation, press Right UI Button: Make choice 2 in conversation

When viewing Main Menu scene, click on UI Button "Play" to start the game.
When viewing Main Menu scene, click on UI Button "Quit" to exit the game.

### Input Scheme Reasoning
We chose a very standard input scheme for 2D movement of our character, using
WASD or the arrow keys to move around in 8 directions. Complex movement wasn't
very important for our game as it is primariliy story-focused.

To intitiate conversations with characters, as well as to continue seeing more
text in the conversation, we found it convenient to simply use
the spacebar.

For making choices about how to respond to NPCs, we at first thought to
use the 1 and 2 keys on the keyboard to make choices 1 and 2, respectively.
However, we soon realized it was much more intuitive to have UI buttons for
the user to select with their cursor.

### Some side notes on my role
Since overall my Input role wasn't very large, I decided to help some other
teammates with their roles. For instance, I created a detailed pseudocode
for the PlayerConversation.cs script [here](https://github.com/thenintendodude/Delivering-Consequences-Game/blob/master/Conversation%20Handler%20and%20Communication%20with%20Other%20Classes.pdf),
and I made some footage that went into the Trailer.

## Game Logic

___
# SUB-ROLES

## Audio

### Music Style
For the music, I wanted to choose mostly tracks that sounded serious, somber, and mysterious. This was particularly true for the main menu screen and background,
since these are the player's first impressions of the game. The reason I wanted
to portray these feelings is because our story is of a character who has just
fallen from great power and is now unsure of his state in the world.

The only place where'd I say the music isn't as somber is in the houses of the
NPCs, since I wanted the player to feel like the homes were safe
and welcoming places for them to go, since it is these places where they can
actually progress in the game.

### Sound Effects
Since I know that sound effects provide nice interactivity and satisfcation when
playing games, I wanted to make sure to include some sound effects in our game. Specifically, I chose sound effects related to opening and closing
doors, initiating conversation with characters, and beating the game. I found
that these "transition" sound effects were very impactful in the flow of the
game.

### Audio System
The Audio systems for the main menu and backstory scenes were fairly simple, as
I just had to play one song in the background on a continuous loop. However, the
Audio system for the main gameplay was much more complicated...

I organized all audio for the main gameplay under an Audio GameObject in the
scene, which contained child objects that each held one audio track that would
be played during the game. Then, attached to the Audio object I had a script
called AudioManager, so that all sound effects and switching between
music tracks could be easily abstracted away and handled elegantly.

Specifically, the AudioManager deals with the details of gathering together
all the audio tracks, triggering sound effects, toggling music between different
tracks in a smooth way that fades from one track to another, and providing an easy
interface for the rest of the scripts to deal with audio. By providing
Enums to list all possible Sound Effects and Music, it made it easy to see
what audio options you had and caused less mistakes for the programmers using
AudioManager.

### Audio Tracks Used (All are royalty-free)
Our-Mountain_v003: For outdoor music, Source: https://soundimage.org/wp-content/uploads/2014/09/Our-Mountain_v003.mp3
Fantasy_Game_Background: For menu screen music, Source: http://soundimage.org/wp-content/uploads/2014/04/Fantasy_Game_Background.mp3
The Foyer: For Backstory,Source: https://www.playonloop.com/2019-music-loops/the-foyer/#free-download
Red Carpet Wooden Floor: For indoor music, Source: https://bakudas.itch.io/generic-rpg-pack
Squeaky Door Open: https://freesound.org/people/CastIronCarousel/sounds/216878/
Door Close: https://freesound.org/people/InspectorJ/sounds/339677/
UI Confirmation Beep: https://freesound.org/people/paep3nguin/sounds/388046/
victory-fanfare: Beat the game, Source: https://freesound.org/people/humanoide9000/sounds/466133/

### Unused Audio, but wanted to link them here since they could be useful should we continue our game in the future):
Windless Slopes: For outdoor music, Source: https://bakudas.itch.io/generic-rpg-pack
Orchestral-victory-fanfare: Made Progress in some way, Source: https://freesound.org/people/Sheyvan/sounds/470083/
Long Beep: For Main Menu Select Confirmation, Source: https://www.partnersinrhyme.com/soundfx/PUBLIC-DOMAIN-SOUNDS/beep_sounds/beep_beep-fm_wav.shtml
Short Beep: For Input Confirmation, Source:https://www.partnersinrhyme.com/soundfx/PUBLIC-DOMAIN-SOUNDS/beep_sounds/beep_beep-pure_wav.shtml
Double Short Bee: For Input Confirmation, Source: https://www.partnersinrhyme.com/soundfx/PUBLIC-DOMAIN-SOUNDS/beep_sounds/beep_beep-doub_wav.shtml

## Gameplay Testing
Gameplay testing will begin once the game is nearing the end of production.

## Narrative Design

## Press Kit and Trailer

## Game Feel

#### H4 Camera + Visual Improvements 
As mentioned before, in addition to lerping, I tweaked the camera script to clamp and ensure that players could never view beyond the edges of the designed map to preserve the illusion of an infinite world. I also worked with the animator to add additional assets that filled the town map and tell an implicit story. 

When entering an NPC home, where we switch to a fixed camera, the home is always smaller than the camera size. To give this a more complete look I give the scene a fitted black background. This style of adjusting the scene is similar to many topdown 2D games such as Stardew Valley.

![alt text](https://i.pinimg.com/originals/33/e9/e6/33e9e6a8505092cc233bfac4dedb8864.jpg)

#### H4 NPC Acknowledgement
Also as mentioned before, the **TriggerConversation** script can be reused to both enable and disable behaviors when a Player is near an NPC. To add to the realism and make it appear that an NPC is actively acknowledging your player, the NPC turns to face your player. This also means that whenever a conversation is triggered that the NPC will be facing the player. When the **TriggerConversation** script is triggered we set a bool that enables this NPC facing player behavior in the **VillagerMovement** script. By modifying the random movement behavior and adding an UpdateToFacePlayer() function I ensure that the NPC stops random movement as soon as the Player is close enough and turns to face the Player. 

This behavior takes inspiration many 2D games where NPCs actively acknowledge the Player and their movement. One prime example is Pokemon, where an NPC is actively looking to find the player to start a battle encounter.

![alt text](https://vignette.wikia.nocookie.net/pokemon/images/b/bc/HGSS_-_Route_30_5.png/revision/latest?cb=20100411034322)

#### H4 Hey! Stop Pushing Me!  

While colliding with furniture or a rock may have no more meaning than not being able to walk over it, there are other purposeful collisions that should be more meaningful. If you push around an NPC they are bound to get frustrated eventually! This is implemented by adding extra box colliders set to "isTrigger" to the walking NPCs (house characters and bunny), and implementing a script called **PushDetection**. When a Player starts pushing an NPC a timer starts that triggers behavior once the Player has exhausted the NPCs patience completely. When a timer has run out the NPC might just force a conversation. All NPCs have different weights and different levels of patience. If you push an NPCs patience long enough you may just get an adverse reaction... and what if that had some effect on your stats? 

These interactions are very similar to some elements of Animal Crossing. In Animal Crossing if you annoy a NPC enough, (like hitting them with a net) they will force a conversation and express their unhappiness!

![alt text](https://koukoupuffs.files.wordpress.com/2013/07/hni_0044.jpg)