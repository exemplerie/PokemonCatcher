# PokemonCatcher
Unity 3D game for Innopolis "Game Development with Unity" course.

### **Project Description**

The "Pokemon Catcher" project is the first-person Pokemon-catching adventure. The game mechanic closely resembles a traditional first-person shooter, where the player catches Pokemon using a capturing mechanism instead of shooting. The objective of the game is to catch a specific number of Pokemon of designated types within each level. The game features a world with five distinct levels, each set in different environments like forest, underwater world, glaciers, and haunt mansion, with varied Pokemon populations and levels of difficulty. The Pokemon exhibit diverse behaviors and appearances, making each encounter unique. Some Pokemon are more shy and try to escape, others are ready to fight for their freedom. Players use items like pokeballs and food from their inventory to aid in their quest to catch 'em all.

### List of implemented features

- **First-person shooting** - shooting pokeballs, which are taken from the player's inventory. Pokeballs are affected by physics. The main purpose of shooting is to hit Pokemon.
- **Pokemon Catching** - When a pokeball hits a Pokemon with a successful catch, it gets into the player's collection. There is random probability of catching, which is calculated using a special formula (it is influenced by the type of pokeball and the type of Pokemon).
- **World exploration** - 3 of the 5 levels are large worlds with a well-designed environment and a beautiful visual style based on Unity Terrain. Resources, pokeballs and Pokemon spawn in random places, so exploring the world becomes a necessity for the player.
- **Different types of Pokemon** - Each level is inhabited by Pokemon of different types. Each type has its own unique behavior and probability of capture. Types of Pokemon:
    - Normal - walks around the world, easy to catch.
    - Bunny - a very timid Pokemon. Shakes and hides underground after a couple of seconds if the player gets too close.
    - Viking - an aggressive Pokemon. Starts chasing the player and throwing fireballs at him, which can cause damage to the player.
    - Water - very light, because it pops up from any touch (pokeball or player). Player has to change the direction of the pokeball throw to catch it.
    - Seaweed - a shy Pokemon that starts running away from the player when approaching.
    - Snow - a big Pokemon,  walks around the world, easy to catch.
    - Ice - an extremely dangerous Pokemon, throws ice balls in 6 directions around itself when a player approaches and chases him. It is also very small, which makes it difficult to catch.
    - Ghost - a creepy fast Pokemon that chases the player and causes damage when it comes into contact with him.
- **Random generation** - resources, pokeballs and Pokemon spawn in random map places. We use a script to generate resources in a game world within specified bounds and conditions (distance, height, range, spawn chance probability). It utilizes raycasting to ensure that resources are placed on valid surfaces within the game environment.
- **Quests** - at each level there is a quest for the player. The quest is a list of Pokemon types and the number of them that need to be caught. The player can track the progress of the quest in a special menu window
- **Level-based gameplay** - the game is divided into 5 levels. Each level provides a unique environment, Pokemon and quest. Player can change the level in the main menu or go to the next level by completing the quest.
- **Inventory** - the game has a functional inventory displayed in the GUI. It allows the player to pick up and store items in slots, change the selected slot using the mouse scroll wheel, and retrieve the selected item. Implemented using Scriptable objects.
- **Underwater breathing** - at the underwater level, the user has an air indicator that needs to be replenished in special randomly generated zones. When the air runs out, the health begins to decrease.
- **Imitation of ice** - with the help of Unity physical material and inertia control of the player, we created an imitation of skiing on the Frozen level.
- **Intractable objects** - on the Haunt Mansion level, there is a key (object) and a door that needs to be opened with the found key.
- **GUI** - the interface of the main menu is implemented; the menu at each level, which opens with the Esc key, where the player can change the volume of music, sounds, watch the quest, go to the main menu and return to the game.
- **Audio** - each level has its own music for the atmosphere; sounds for a variety of actions.

Screenshots:

<img width="1440" alt="Снимок экрана 2023-11-22 в 13 23 06" src="https://github.com/exemplerie/PokemonCatcher/assets/57341007/31f20081-9d08-4b59-81fa-2c3a11bd165a">

<img width="1440" alt="Снимок экрана 2023-11-22 в 13 07 38" src="https://github.com/exemplerie/PokemonCatcher/assets/57341007/8b562f96-ddf9-4c7a-8c4c-e02289607cbb">

<img width="1440" alt="Снимок экрана 2023-11-22 в 13 24 06" src="https://github.com/exemplerie/PokemonCatcher/assets/57341007/390cfade-af95-446c-bf5c-5da7f090ba33">

<img width="1440" alt="Снимок экрана 2023-11-22 в 13 24 18" src="https://github.com/exemplerie/PokemonCatcher/assets/57341007/0dce2986-dd5f-4289-9b3d-35afb832c5c1">

<img width="1440" alt="Снимок экрана 2023-11-22 в 13 24 45" src="https://github.com/exemplerie/PokemonCatcher/assets/57341007/7b78292f-040e-4a3a-9f18-2edb89d8855a">

<img width="1440" alt="Снимок экрана 2023-11-22 в 13 17 31" src="https://github.com/exemplerie/PokemonCatcher/assets/57341007/052c1e5d-0cd0-4070-a69b-d9692939ce49">

<img width="1440" alt="Снимок экрана 2023-11-22 в 13 25 41" src="https://github.com/exemplerie/PokemonCatcher/assets/57341007/1f41bded-d3a7-4303-befe-e35c4078cb10">
