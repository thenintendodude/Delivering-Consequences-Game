# MAIN ROLES

## User Interface
#### Dialogue popup panel
There is a popup dialogue panel that will appear whenever your character tries to talk to an NPC. The text will be parsed to show up without overflowing accordingly. If the player has a choice to make from the conversation, then the choice buttons will pop up on the screen. We have IDs that accordingly indicate what is the next conversation the player will have with the NPC. In implementing this panel that shows up, I had to create 2 separate panels, one for where the text would be displayed and one for where the buttons for the choices would be displayed. These panels were then hidden at the start of the game since no talking would happen at the beginning. I wrote the PlayerConversation script, which keeps track of which text node to display, whether there were choices to display or not and keep track of what the next conversation should be after the previous conversation had ended with the NPC. I added the appropriate scripts to each NPC and the reference objects needed. I also added a player interaction script which makes sure you do not go through two conversations at once if you are within the radius of two different npcs. You use "c" now to progress through the game to make sure you do not interact with two npcs at once.

#### Stats bars
There will be an "empathy" value measurement on the screen that indicates to the player how much closer they are to moving on in the game. There is also a power, charisma, and strategy bar that appears on the UI. This is done by having references to the bars for each NPC so that the values can be updated with each conversation the player has with them (through the InteractionPanel scipt). Whenever the player is trying to talk to an NPC, they have to be within a certain radius, and whenever they are in this radius, the phrase "press space to interact" appears and disappears from the screen accordingly. I added the appropriate scripts to each NPC and the reference objects needed.

#### Opening menu and dialogue scene
I also created the play menu and also opening dialogue scenes at the very beginning of the game. These rely on their respective scripts, which manage the buttons on the screen. 

## Movement/Physics

#### Initial Player / NPC Movement Design

This portion was implemented initially by our animator. (JOANNE explain why you implemented this in your role as animator here: probably mention inspiration from Zee's Final Combat game)

#### Collision Detection and Natural Boundaries
Physics and animation worked closely on placement of 2D sprites witin the town to tell an implicit story as well as give the town more realism. For example, the graveyard in the middle of town hints at the town's grim past. 

In implementing collisions I had to determine which sprites would make sense to collide with. The collidable town border is intended to give the player an illusion of an infinite game world as well as keep them safely within the designed portion of the town. Collidable objects encompass all objects we would naturally not be able to walk over in a standard physics model (i.e. ponds, rocks, houses, etc.). By setting the box collider to only the Player's feet and setting it to a higher layer than all other sprites, we allow the Player to realistically stand in front of objects in the town. 

#### Camera Design
The Main Camera, which is utilized while the player traverses the outside town, follows a position lock lerp camera controller script called **CameraController** which is locked on the Player. This camera is clamped to specific X and Y values so the player never sees beyond the edges of the designed game world and the infinite game world illusion is preserved.  

Upon colliding with the door of each of the three NPC's homes, a camera switch to the respective home. An empty game object with a 2D Box Collider (RedDoor, CastleDoor, BarrelDoor) is positioned on each door step to trigger this camera switch in the **EnterHouse** script. The player is transported to the inside of the house they attempted to answer. The camera positioned on each house are fixed (not lerp) because the inside of houses are smaller than the camera size. 

Upon colliding with the doormat of each of the three NPC's homes, the game switches back to the main camera and transports the player just outside the door of the house they entered before. Similar to entry, an empty game object with a 2D Box Collider (RedDoormat, CastleDoormat, BarrelDoormat) is positioned on the doormat of each home that triggers a camera switch in the **ExitHouse** script. The size of these colliders were finetuned so that the entrance places the player at a reasonable distance inside the home without triggering the exit collider while it still appears the player has just entered the home. The separation of the **EnterHouse** and **ExitHouse** house scripts allows different behaviors, such as sound effects, to be associated with entering and exiting a home. 

#### Conversation Triggers
Once within a certain circular radius of NPCs that can be talked to, a conversation can be triggered. To implement this I created empty gameobjects with 2D circle colliders for each NPC that can be talked to (CCharacterRadius, GuardRadius, etc.). The **TriggerConversation** script ensures this gameobject snaps to it's respective NPC each frame. The **TriggerConversation** script provides the framing that allows us to trigger certain behavior when the Player enters the circle collider and when they exit. In the main use case, only when a Player has entered and remains within the circle collider, they will be able to trigger a conversation with the NPC.


## Animation and Visuals

#### Asset Sources and Licenses
To keep the art style consistent, the main asset packages used are all of the Liberated Pixel Cup (LPC) art style. More about the LPC can be found here: http://lpc.opengameart.org. More specifically, the following asset packages used are for tilemaps and character sprites in this game:
* "Liberated Pixel Cup (LPC) Base Assets (sprites & map tiles)" by Lanea Zimmerman (AKA Sharm), Stephen Challener (AKA Redshrike), Charles Sanchez (AKA CharlesGabriel), Manuel Riecke (AKA MrBeast), and Daniel Armstrong (AKA HughSpectrum) licensed CC-BY-SA 3.0 or GPL 3.0: https://opengameart.org/content/liberated-pixel-cup-lpc-base-assets-sprites-map-tiles.
* "LPC Tile Atlas2" by Barbara Rivera, Casper Nilsson, Chris Phillips, Daniel Eddeland, Anamaris and Krusmira (AKA Emilio J Sanchez), Jonas Klinger, Joshua Taylor, Leo Villeveygoux, Mark Weyer, Matthew Nash, Skyler Robert Colladay, Lanea Zimmerman (AKA Sharm), Stephen Challener (AKA Redshrike), Charles Sanchez (AKA CharlesGabriel), Manuel Riecke (AKA MrBeast), and Daniel Armstrong (AKA HughSpectrum) licensed CC-BY-SA 3.0 or GPL 3.0: https://opengameart.org/content/lpc-tile-atlas2.
* “Bunny Rabbit LPC style for PixelFarm” by Stephen Challener (AKA Redshrike) licensed CC-BY 3.0, CC-BY-SA 3.0, or OGA-BY 3.0: https://opengameart.org/content/bunny-rabbit-lpc-style-for-pixelfarm.

#### Visual Style Guide
As previously mentioned, every asset used is of the LPC art style in order to look visually consistent throughout the entire game. As a top-down 2D semi-open world game, explorable areas are necessary, and thus visuals are especially important as that is what the player will be primarily focusing on while navigating through the game. For this purpose, I used the 32x32 pixel tile squares found in the "Liberated Pixel Cup (LPC) Base Assets (sprites & map tiles)" package and the "LPC Tile Atlas2" package to draw out maps of the village and buildings that the player character will be able to explore in. These maps are all drawn at different locations on the same Unity Scene so that the game will only have to load once after starting. 

The main map is a large village area with various explorable areas and three buildings that the player character is able to enter and also explore in. In each of these areas and buildings, there are many different non-player characters that the player character should be able to interact with. To make the explorable areas in the village seem diverse yet connected, each of these areas are drawn with a different theme in mind. For example, one area is meant to be a workers’ camp while another area is meant to be a workers’ field, in which the visual implication of the logs, dead trees, and carts is that these workers are lumberjacks. 

Meanwhile, the interiors of each of the three buildings have been made to be similar in appearance but decorated with different furniture and wall colors to give the impression that these three buildings are inhabited by different people of the same village. A black background has also been drawn behind each of these buildings’ rooms so that an empty or blue screen outside of these rooms cannot be seen by the camera while playing the game. 

To indicate the village’s exit, the border of rocks surrounding the village is implied to enclose a route beyond the village on the right side of the map that is blocked off by wooden fencing. As a further hint to the player that this is where the game ends, a non-player character has been placed in front of this wooden fencing to “guard” the exit. 

#### Collaboration with Physics
Working with the physics role, we decided what tiles would be drawn on different layers in order to separate the maps’ visual representations from collidable objects. Collidable objects includes any tile that represents things that a person would realistically not be able to walk through, such as building walls, fences, boulders, trees, ponds, and so on. Meanwhile, although these characters should be able to walk over ground tiles, I did not want the characters to be able to walk over tiles that represent overhangings, such as tree tops and gate arcs. Thus, I had to separate these two main types of tiles into separate tilemaps on different layer levels, with the ground tiles being at a layer level below the characters and the overhanging tiles being at a layer above the characters. 

#### In-game Characters
As an explorable top-down 2D game, interactable characters are required in order to make the game not appear empty and lifeless. For this game, we wanted to initially have at least one playable character and five non-playable characters. Although the "Liberated Pixel Cup (LPC) Base Assets (sprites & map tiles)" package only contains two premade character sprites, the package does include blank character templates to make additional male and female characters. So, using the provided “base walkcycle” and “hairstyle” files, four custom character sprites with drawn walking cycles were created for usage alongside the two already premade characters. One of these custom characters is used to represent the main playable character, while the other three custom characters are to be used to represent more prominent side characters in the game’s story. 

We decided that these were not enough characters for the game, however. So, to further populate the village, I created several more custom character sprites to present more visually different looking NPCs in the game and had these NPCs placed in random locations scattered across the village’s map. Unlike the initial four custom characters, however, these new stationary NPCs only have one sprite drawn of them each. Thus, to ensure that the player character can only approach each of these new NPCs from one direction, I added in more tiles to the layers containing collidable objects in order to block off any other direction that these new NPCs are not facing. For example, a villager NPC that only has a sprite facing left will have collidable objects placed above, below, and to the right of that NPC so that the player can only approach that NPC from the NPC’s left side. For organization, these additional NPCs have also been placed on separate layers apart from the other characters, under Grid in the Hierarchy tab. 

To depict child NPCs in the game, a couple of the character sprites were made smaller and placed in a specific building to represent an orphanage. Next, for even more stationary NPCs, the premade soldier sprites from the "Liberated Pixel Cup (LPC) Base Assets (sprites & map tiles)" package were also used multiple times to represent guards in the village. Then, to make the village feel more alive, the premade bunny sprites from the “Bunny Rabbit LPC style for PixelFarm” package were used to implement an animated bunny whose purpose is to just randomly hop around the main village map. The following section discusses how I did the animations for this game more in-depthly. 

#### Animation Scripts
To animate each of these characters, the “walkcycle” sprites of each premade and custom character was spliced up into 64x64 pixel tiles and then used to create animation files for Left, Right, Up, and Down direction walk cycles. Afterwards, I wanted to see if the animations I had implemented and created actually worked beyond the preview that the Animation tab showed. 

For this purpose, I created two scripts called **PlayerMovement** and **VillagerMovement** for the custom characters with custom walking cycles that I had made earlier. In the **PlayerMovement** script, an X value and a Y value are obtained based on player input and these values are passed along to the player character’s Animator. Similarly, in the **VillagerMovement** script, a direction that a particular NPC should move in and the speed in which that NPC should move at are randomly generated and then passed to that NPC’s Animator. The point of this random movement for the main villagers is to give the feel that the village is actually alive with living people. The single bunny in the game also uses the VillagerMovement script. Afterwards, in the Animator controller of each of these movable characters, I implemented a State Machine to decide which animation to display depending on which direction (X or Y direction) the character is moving in on the map. 

I later worked with the person in charge of physics and movement to further improve these movement scripts so that the moving NPCs would stop realistically when in close proximity to the player character. For this task, once the player character is detected to be very close to an NPC on the map, then the animator for that NPC is turned off and the NPC sprite is replaced with a sprite facing in the direction of the player character. This is described more in-depthly in the Game Feel section of the documentation, as the person tasked with physics and movement was also the one in charge of game feel. 


## Input

### The Input Scheme
Left Arrow (or A): Move character left
Right Arrow (or D): Move character right
Up Arrow (or W): Move character up
Down Arrow (or S): Move character down

Hold Mouse Right-Click (while moving): Run

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

I decided to make the control for running to be right-clicking the mouse because
the player would already have their hand on the mouse for when making decisions
during conversations. So, it seemed like an easy button for them to press
without making them change their finger positions.

To intitiate conversations with characters, as well as to continue seeing more
text in the conversation, we found it convenient to simply use
the spacebar.

For making choices about how to respond to NPCs, we at first thought to
use the 1 and 2 keys on the keyboard to make choices 1 and 2, respectively.
However, we soon realized it was much more intuitive to have UI buttons for
the user to select with their cursor.

### Some side notes on my role
Since overall the Input role isn't very large, I decided to help some other
teammates with their roles. For instance, I created a detailed pseudocode
for the PlayerConversation.cs script [here](https://github.com/thenintendodude/Delivering-Consequences-Game/blob/master/Conversation%20Handler%20and%20Communication%20with%20Other%20Classes.pdf),
 I made some footage that went into the Trailer, and I implemented the logic
 that made run happen (changing movement and animation speed).

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

The first few gameplay testers happened once the game was not quite finished and the storyline had not been implemented yet. These were simply to test out what else we could implement without the story being involved, such as did the controls feel good and how did the music sound. 


## Narrative Design


## Press Kit and Trailer

#### Press Kit
[Press Kit](https://github.com/thenintendodude/Delivering-Consequences-Game/blob/master/README.md) - The press kit is available here in the GitHub repository, posted in the README.md file

For this press kit, I chose to describe the game in a one-page ad format in the README.md file so that the press kit is the first document that anyone accessing our game’s main GitHub repository will see. In this format, I first chose to give a brief overview of what this game is and linked to our game’s original pitch to grab the viewer’s attention. In the next parts of this one-page ad, I then put in various screenshots with brief descriptions featuring different core mechanics of the game, a section dedicated to the game’s 1-minute trailer (described below), and another section about the development team of this game as a conclusion. 

#### Trailer
[Trailer](http://www.youtube.com/) - The trailer is available as a video on YouTube. 

The main goal of the trailer is to hook the audience into wanting to play the game. As this is a top-down 2D game with an emphasis on story, the trailer starts out dramatically in order to first engage the audience with the game’s lore. Additionally, I also wanted to feature each of the core mechanics of the game, including exploration, dialogue choices, and character interactions. So, in between a supercut of gameplay clips, I flashed text emphasizing each main feature of the game in the center of the screen. At the end of the trailer, I then flashed the game’s title to remind the audience what game they were watching a trailer about. The music used in this trailer is all in-game music, as listed in the Audio section of this game design document. 


## Game Feel

#### Camera + Visual Improvements 
As mentioned before, in addition to lerping, I tweaked the camera script to clamp and ensure that players could never view beyond the edges of the designed map to preserve the illusion of an infinite world. I also worked with the animator to add additional assets that filled the town map and tell an implicit story. 

When entering an NPC home, where we switch to a fixed camera, the home is always smaller than the camera size. To give this a more complete look I give the scene a fitted black background. This style of adjusting the scene is similar to many topdown 2D games such as Stardew Valley.

![alt text](https://i.pinimg.com/originals/33/e9/e6/33e9e6a8505092cc233bfac4dedb8864.jpg)

#### NPC Acknowledgement
Also as mentioned before, the **TriggerConversation** script can be reused to both enable and disable behaviors when a Player is near an NPC. To add to the realism and make it appear that an NPC is actively acknowledging your player, the NPC turns to face your player. This also means that whenever a conversation is triggered that the NPC will be facing the player. When the **TriggerConversation** script is triggered we set a bool that enables this NPC facing player behavior in the **VillagerMovement** script. By modifying the random movement behavior and adding an UpdateToFacePlayer() function I ensure that the NPC stops random movement as soon as the Player is close enough and turns to face the Player. 

This behavior takes inspiration many 2D games where NPCs actively acknowledge the Player and their movement. One prime example is Pokemon, where an NPC is actively looking to find the player to start a battle encounter.

![alt text](https://vignette.wikia.nocookie.net/pokemon/images/b/bc/HGSS_-_Route_30_5.png/revision/latest?cb=20100411034322)

#### Hey! Stop Pushing Me!  

While colliding with furniture or a rock may have no more meaning than not being able to walk over it, there are other purposeful collisions that should be more meaningful. If you push around an NPC they are bound to get frustrated eventually! This is implemented by adding extra box colliders set to "isTrigger" to the walking NPCs (house characters and bunny), and implementing a script called **PushDetection**. When a Player starts pushing an NPC a timer starts that triggers behavior once the Player has exhausted the NPCs patience completely. When a timer has run out the NPC might just force a conversation. All NPCs have different weights and different levels of patience. If you push an NPCs patience long enough you may just get an adverse reaction... and what if that had some effect on your stats? 

These interactions are very similar to some elements of Animal Crossing. In Animal Crossing if you annoy a NPC enough, (like hitting them with a net) they will force a conversation and express their unhappiness!

![alt text](https://koukoupuffs.files.wordpress.com/2013/07/hni_0044.jpg)
