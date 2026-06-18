# Doom Launcher Project

## What is this project?

- A recreation of the ZDL launcher with a bit more personal approach
- The purpose of the project is to provide a well built and maintained DOOM launcher that works with any engine port
- The project also helps with the creation of online games (since we know how annoying it is to create a BAT file to launch them)

## Main functionalities

### Game Options Tab

This tab contains the options which change the game attributes, either single or multiplayer.

On this image you can see the Game Options panel:

<!-- markdownlint-disable-next-line MD033 -->
<img width="851" height="547" alt="image" src="https://github.com/user-attachments/assets/7d988a74-a42f-4958-b5c0-bf970cec808b" />

#### Singleplayer options

- Map selection list -> dropdown listing the levels actually present in the selected WAD (detected by scanning the WAD's own lump directory, so custom/fan-made WADs with non-standard level counts are picked up automatically), letting you choose which one to start on
- Skill selection list -> dropdown that allows the user to select which difficulty to start the game with
- Engine selection list -> dropdown that allows the user to choose which engine port to launch the selected IWAD with; engines with a config file assigned show `(cfg: filename.cfg)` next to their name
- Select WAD window -> the users may choose which IWAD to run from this panel, only one may be chosen at any given time
- Select mods window -> the user may optionally choose to run the game with mods (WAD, PK3, ZIP, PK7 or RAR files), which can be added and removed via this window

#### Multiplayer options

- Game mode selection -> contains 3 different multiplayer game modes which the user can choose from
- Players (host/join) selection -> this selection decides whether you are going to host the game (and for how many people), or if you are going to join a game using a provided IP
- Hostname/IP input field -> this field is used when joining other users' online game
- Port input field -> this field is optional to the Hostname/IP input field
- Frag limit input field -> an optional multiplayer attribute
- Time limit input field -> an optional multiplayer attribute
- DMFLAGS input field -> an optional multiplayer attribute
- DMFLAGS2 input field -> an optional multiplayer attribute

### Launcher Options Tab

This tab contains the options which change the launcher's settings.

On this image you can see the Launcher Options Panel:

<!-- markdownlint-disable-next-line MD033 -->
<img width="855" height="552" alt="image" src="https://github.com/user-attachments/assets/574ff309-7181-41b1-8151-e0d71a442d37" />

#### WAD Files panel

- This panel lists every game file you've added, both IWADs and mods (WAD, PK3, ZIP, PK7 or RAR), sorted automatically into the right place: IWADs become selectable on the Game Options tab's WAD dropdown, everything else becomes selectable in the mods list
- There are three buttons at the top of the panel: Add, Remove and Edit
- Using the Add button you can select WAD or mod files from your computer; each file is inspected to detect whether it's an IWAD or a mod, so there's no need to add them from different places anymore
- Using the Remove button you can delete files from the launcher's configuration (you have to preselect the files you want to delete)
- Using the Edit button you can rename an entry or change its file path, for either a WAD or a mod entry

#### Engines panel

- This panel contains the engines which are required to run the IWAD files
- There are three buttons at the top of the panel: Add, Remove and Edit
- Using the Add button you can select executables (engines) from your computer to be added to the launcher's configuration; each engine's display name is generated from its own file version (e.g. `gzdoom-4.11.0`)
- Using the Remove button you can delete executables (engines) from the launcher's configuration (you have to preselect the executables you want to delete)
- Using the Edit button you can change an engine's nickname or executable path, or assign it a config file to load automatically (passed as `-config <path>` at launch)

### General components

- Game launch command text box -> this component can be seen in the bottom part of the application; it shows the command which the launcher is going to execute (updated every 1 second)
- Play button -> this component will use the game execution command and launch your game (single or multiplayer)
