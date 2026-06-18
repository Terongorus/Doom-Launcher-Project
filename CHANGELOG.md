# Changelog

All notable changes to Teron's Doom Launcher are documented in this file.

## [1.3.0] - 2026-06-18

### New Features

- **Reworked Profiles tab** (#13) — the profile picker is now a list view instead of a dropdown, with a dedicated details pane next to it that previews the selected profile's saved settings (WAD, mods, skill, starting map, multiplayer options, and engine) read straight from `launcher_config.json`, so you can see what you're about to launch without switching to the Game Options tab. The Add/Remove/Edit buttons were repositioned above the list to make room.

## [1.2.2] - 2026-06-18

### Bug Fixes

- Fixed the generated command line not refreshing immediately after switching profiles — it kept showing the previous profile's command until something else (e.g. changing a dropdown) triggered a regeneration.

## [1.2.1] - 2026-06-18

### Bug Fixes

- Fixed the saved profile's settings not being applied to the Game Options UI on launch — selecting a profile from the dropdown always worked, but the profile auto-selected on startup never had its engine/WAD/map/skill/mods/multiplayer fields populated until you manually reselected it.
- Fixed the generated launch command including mods based on which row was highlighted in the mods list instead of which checkboxes were actually checked — checked mods with no row selected (or selected rows that weren't checked) were handled incorrectly in the `-file` argument.

## [1.2.0] - 2026-06-18

### New Features

- **Single consolidated configuration file** — `engine_config.json`, `wad_config.json`, `mods_config.json`, `game_config.json`, and `wad_levels_database.json` are now merged into one `launcher_config.json`, with one root `CONFIGURATION` object containing `Engines`, `WADs`, `Mods`, `Profiles`, and `WADLevelsCache` sections.
- **Entry indexation** — every entry in every section (engines, WADs, mods, profiles, cached WAD level scans) now carries a sequential `Id`, renumbered 1..N on every save.
- **Automatic one-time migration** — the first time the new file is missing, the launcher imports the existing 4 legacy files (and the levels cache) and writes them into the new combined format. The old files are left on disk, untouched.

### Improvements

- Configuration is now written with indentation instead of one dense unformatted line, so it's readable when opened directly.

### Bug Fixes

- Fixed a regression (#11) where most Game Options fields — skill, map, mods, and every multiplayer field (game mode, players, host, port, frag/time limit, DMFLAGS/DMFLAGS2) — silently stopped updating the generated launch command and saved profile when changed. The event wiring for these controls had been dropped during the Engine Config File Support merge; it's been restored, and the mods checklist now reacts to checkbox toggles (`ItemCheck`) instead of row selection.

## [1.1.0] - 2026-06-18

### New Features

- **Engine config files** — each engine can now have a dedicated config file bound to it, applied automatically on launch (`-config "<path>"`). The Engines panel shows `(cfg: filename.cfg)` next to engines that have one set.
- **Engine & WAD edit dialogs** — the previously non-functional edit (pencil) buttons on the Engines and WAD panels now open real edit dialogs: nickname, executable path (with Browse), and config file (with Browse) for engines; name and file path (with Browse) for WADs.
- **Dynamic per-WAD level detection** — map list detection now parses the actual WAD lump directory (the binary header and lump names) instead of guessing from filenames or scanning for a couple of known strings. Every ExMy/MAPxy level lump found is cached per-WAD, so a given file only needs to be scanned once. Custom/fan WADs (e.g. Doom: The Way We Remember It, ATCLEV) now show exactly their own levels — no hardcoded map list required, and no upper limit on episode/map numbers.
- **Unified WAD/mod adding** — the "Add" button on the WAD files panel now accepts `.wad`, `.pk3`, `.zip`, `.pk7`, and `.rar` files in one dialog. Each file is binary-inspected for its IWAD/PWAD signature and routed automatically: IWADs land in the WAD dropdown, everything else lands in the mods list — no more switching tabs to add mods separately.

### Improvements

- Engine nicknames are now generated from the executable's own file version metadata (e.g. `gzdoom-4.11.0`) instead of being a meaningless placeholder. Existing entries self-repair the next time engines are loaded.
- Removed the redundant `Engine_Name` field from the engine config schema — `Engine_Nickname` is now the single name field, consistent with how WADs and mods already work.
- The `-warp` launch argument is now derived directly from the selected level's name, so any discovered map works — not just a fixed, hardcoded set.
- Relabeled the WAD panel header to "WAD/Mod files:" to reflect that it now manages both.

### Bug Fixes

- Fixed an annoying popup ("No WAD match found in either database!") that appeared every time a custom or fan-made WAD was selected — map selection now clears silently when no level format is detected.
