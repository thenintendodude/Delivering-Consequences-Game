# GAME DESIGN

## USER INTERFACE
There is a popup dialogue panel that will appear whenever your character tries to talk to an NPC. The text will be parsed to show up without overflowing accordingly. If the player has a choice to make from the conversation, then the choice buttons will pop up on the screen. We have IDs that accordingly indicate what is the next conversation the player will have with the NPC. 

There will be an "empathy" value measurement on the screen that indicates to the player how much closer they are to moving on in the game. 

## CHARACTER CREATION
You sort-of "create your character" as you play the game, since your responses
to npc interactions shape your character's personality.

However, there is no visual customization of your character.

## LEVELING UP

## SUCCESS
You move closer to winning the game by making the correct decisions in your
conversations with other NPCs. If you earn enough empathy, then you can speak
with the character blocking the exit to the village and you will be able to
leave (ALEX correct this if this description is wrong...)

## FAILURE
You lose the game if you do not earn enough empathy during your conversations
with other players. When you go to talk to the character blocking the exit to
village, (ALEX, please fill in what will happen...)

## PLAYER ACTIONS
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

## ENVIRONMENTS

## STORY

## NPC TYPES

## OTHER ASSETS

### Physics and Movement
For realistic player movement speed that gives the user a sense of momentum
and friction, implementation will include use of ADSR envelope code. 
Implementation of boundary checking will ensure player remains safely within
boundaries of town and any house they enter. 

### Sound
Windless Slopes: For outdoor music, Source: https://bakudas.itch.io/generic-rpg-pack
Red Carpet Wooden Floor: For indoor music, Source: https://bakudas.itch.io/generic-rpg-pack
Squeaky Door Open: https://freesound.org/people/CastIronCarousel/sounds/216878/
Door Close: https://freesound.org/people/InspectorJ/sounds/339677/
Orchestral-victory-fanfare: Gained empathy, Source: https://freesound.org/people/Sheyvan/sounds/470083/
UI Confirmation Beep: https://freesound.org/people/paep3nguin/sounds/388046/
victory-fanfare: Beat the game, Source: https://freesound.org/people/humanoide9000/sounds/466133/

### Game Feel
Player's character movement throughout the game should feel immediate and 
match what you would expect from your surrounding terrain. NPC interactions
triggerable from reasonable range. 

### Gameplay Testing
Gameplay testing will begin once the game is nearing the end of production. 

___
## Animation and Visuals
To keep the art style consistent, one main asset package will be used, the Liberated Pixel Cup (LPC) Base Assets: https://opengameart.org/content/liberated-pixel-cup-lpc-base-assets-sprites-map-tiles.

These assets are free to use, according to the site they were found on: https://opengameart.org/content/faq#q-how-to-credit and the credits are available in the CREDITS.txt file of the package, also noted here.

"Liberated Pixel Cup (LPC) Base Assets" by Lanea Zimmerman (AKA Sharm), Stephen Challener (AKA Redshrike), Charles Sanchez (AKA CharlesGabriel), Manuel Riecke (AKA MrBeast), and Daniel Armstrong (AKA HughSpectrum) licensed CC-BY 3.0, GPL 2.0, or GPL 3.0: https://opengameart.org/content/liberated-pixel-cup-lpc-base-assets-sprites-map-tiles.

The asset package includes environment tiles and character sprites of 32x32 pixels. The environment tiles will be used to create a village map and houses that a player character can explore. The character and NPCs will also be animated based on which X or Y direction they are moving in on the map. 
