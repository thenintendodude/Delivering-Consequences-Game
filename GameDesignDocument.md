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
Left Arrow: Move character left
Right Arrow: Move character right
Up Arrow: Move character up
Down Arrow: Move character down

Hold j with Arrow Key: Sprint in corresonding direction

Walk into door from outside: Character enters house
Walk into door from inside: Character leaves house

Walk up to NPC and press Fire1: Initiate Conversation
When in conversation, press Fire1: View next bit of text
When in conversation, press 1: Make choice 1 in conversation
When in conversation, press 2: Make choice 2 in conversation

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
For realistic player movement speed that gives the user a sense of momentum
and friction, implementation will include use of ADSR envelope code.
Implementation of boundary checking will ensure player remains safely within
boundaries of town and any house they enter.

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

## Game Logic

___
# SUB-ROLES

## Audio
Windless Slopes: For outdoor music, Source: https://bakudas.itch.io/generic-rpg-pack
Our-Mountain_v003: For outdoor music, Source: https://soundimage.org/wp-content/uploads/2014/09/Our-Mountain_v003.mp3
Red Carpet Wooden Floor: For indoor music, Source: https://bakudas.itch.io/generic-rpg-pack
Squeaky Door Open: https://freesound.org/people/CastIronCarousel/sounds/216878/
Door Close: https://freesound.org/people/InspectorJ/sounds/339677/
Orchestral-victory-fanfare: Gained empathy, Source: https://freesound.org/people/Sheyvan/sounds/470083/
UI Confirmation Beep: https://freesound.org/people/paep3nguin/sounds/388046/
victory-fanfare: Beat the game, Source: https://freesound.org/people/humanoide9000/sounds/466133/

## Gameplay Testing
Gameplay testing will begin once the game is nearing the end of production.

## Narrative Design

## Press Kit and Trailer

## Game Feel
Player's character movement throughout the game should feel immediate and
match what you would expect from your surrounding terrain. NPC interactions
triggerable from reasonable range.
