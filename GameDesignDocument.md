# GAME DESIGN

## SUMMARY
[A paragraph-length pitch for your game.]

## GAMEPLAY EXPLANATION
[In this section, explain how the game should be played. Treat this like a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.]

## Character Creation
You sort-of "create your character" as you play the game, since your responses
to npc interactions shape your character's personality.

However, there is no visual customization of your character.

## Leveling Up

## Success
You move closer to winning the game by making the correct decisions in your
conversations with other NPCs. If you earn enough empathy, then you can speak
with the character blocking the exit to the village and you will be able to
leave (ALEX correct this if this description is wrong...)

## Failure
You lose the game if you do not earn enough empathy during your conversations
with other players. When you go to talk to the character blocking the exit to
village, (ALEX, please fill in what will happen...)

## Player Actions

## Environments

## Story

## NPC Types

## Other Assets

___
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
Left Arrow (or A): Move character left
Right Arrow (or D): Move character right
Up Arrow (or W): Move character up
Down Arrow (or S): Move character down

Hold j with Arrow Key: Sprint in corresonding direction

Walk into door from outside: Character enters house
Walk into door from inside: Character leaves house

Walk up to NPC and press Fire1: Initiate Conversation
When in conversation, press Fire1: View next bit of text
When in conversation, press 1: Make choice 1 in conversation
When in conversation, press 2: Make choice 2 in conversation

## Game Logic

___
# SUB-ROLES

## Audio
Our-Mountain_v003: For outdoor music, Source: https://soundimage.org/wp-content/uploads/2014/09/Our-Mountain_v003.mp3
Fantasy_Game_Background: For menu screen music, Source: http://soundimage.org/wp-content/uploads/2014/04/Fantasy_Game_Background.mp3
Red Carpet Wooden Floor: For indoor music, Source: https://bakudas.itch.io/generic-rpg-pack
Squeaky Door Open: https://freesound.org/people/CastIronCarousel/sounds/216878/
Door Close: https://freesound.org/people/InspectorJ/sounds/339677/
UI Confirmation Beep: https://freesound.org/people/paep3nguin/sounds/388046/
victory-fanfare: Beat the game, Source: https://freesound.org/people/humanoide9000/sounds/466133/

### Unused Audio, but may use in the future:
Windless Slopes: For outdoor music, Source: https://bakudas.itch.io/generic-rpg-pack
Orchestral-victory-fanfare: Made Progress in some way, Source: https://freesound.org/people/Sheyvan/sounds/470083/
Short Beep: For Input Confirmation, Source:https://www.partnersinrhyme.com/soundfx/PUBLIC-DOMAIN-SOUNDS/beep_sounds/beep_beep-pure_wav.shtml
Double Short Bee: For Input Confirmation, Source: https://www.partnersinrhyme.com/soundfx/PUBLIC-DOMAIN-SOUNDS/beep_sounds/beep_beep-doub_wav.shtml
Long Beep: For Input Confirmation, Source: https://www.partnersinrhyme.com/soundfx/PUBLIC-DOMAIN-SOUNDS/beep_sounds/beep_beep-fm_wav.shtml

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