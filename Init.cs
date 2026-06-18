using System;
using System.Collections.Generic;
using System.ComponentModel; // <-- Add this using directive
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace Doom_Launcher_Project
{
    public static class  Globals
    {
        // Flag to prevent Save_GameOptions from triggering while Load_GameOptions is setting UI values
        public static bool IsLoadingConfig = false;
        public static string game_launch_engine = string.Empty;
        public static string game_launch_arguments = string.Empty;
        public static string game_launch_command = string.Empty;
        public static string SelectedProfile = "Default";
        public static RootConfig Config = new RootConfig();
        public static string launcher_config_path = "launcher_config.json";
        public static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        // Legacy per-feature files. Referenced only by ConfigStore.MigrateLegacyFiles,
        // which folds them into launcher_config_path the first time it's missing.
        public static string legacy_wad_config_path = "wad_config.json";
        public static string legacy_engine_config_path = "engine_config.json";
        public static string legacy_mods_config_path = "mods_config.json";
        public static string legacy_game_config_path = "game_config.json";
        public static string legacy_wad_levels_db_path = "wad_levels_database.json";

        //regular wad names container
        public static string[] match_1 =
        {
            "chex.wad",  
            "chex2.wad",
            "chex3.wad",
            "doom.wad",
            "freedoom1.wad",
            "heretic.wad",
            "ultdoom.wad",
            "doomshareware.wad"
        };
        public static string[] match_2 =
        {            
            "doom2.wad",
            "tnt.wad",
            "tnt(evilution).wad",
            "tntevilution.wad",
            "plutonia.wad",
            "plutonia2.wad",
            "hexen.wad",
            "strife1.wad",
            "freedoom2.wad",
            "doomzero.wad"
        };

        public class WADMatchListStructure
        {
            public string wad_name { get; set; } = string.Empty;
            public string wad_name_2 { get; set; } = string.Empty;
        }
        public static BindingList<WADMatchListStructure> MATCHWADLIST1 = new BindingList<WADMatchListStructure>();
        public static BindingList<WADMatchListStructure> MATCHWADLIST2 = new BindingList<WADMatchListStructure>();

        //creates a template of the WAD list (the structure)
        public class WADListStructure
        {
            public int Id { get; set; }
            public string WAD_Name { get; set; } = string.Empty;
            public string WAD_Dir { get; set; } = string.Empty;
        }
        //creates the list that will contain the WADs
        public static BindingList<WADListStructure> WADList = new BindingList<WADListStructure>();

        //creates a template of the Engines list (the structure)
        public class EnginesListStructure
        {
            public int Id { get; set; }
            public string Engine_Nickname { get; set; } = string.Empty;
            public string Engine_Dir { get; set; } = string.Empty;
            public string Engine_Config { get; set; } = string.Empty;
        }
        //creates the list that will contain the Engines
        public static BindingList<EnginesListStructure> EnginesList = new BindingList<EnginesListStructure>();

        //creates a template of the Mods list (the structure)
        public class ModsListStructure
        {
            public int Id { get; set; }
            public string Mod_Name { get; set; } = string.Empty;
            public string Mod_Dir { get; set; } = string.Empty;
        }
        //creates the list that will contain the Mods
        public static BindingList<ModsListStructure> ModsList = new BindingList<ModsListStructure>();

        //creates a template of the Game config (the structure) - also doubles as a profile entry
        public class GameConfigStructure
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Selected_Engine { get; set; } = string.Empty;
            public string Selected_WAD { get; set; } = string.Empty;
            public string Selected_Map { get; set; } = string.Empty;
            public string Selected_SkillLevel { get; set; } = string.Empty;
            public string Selected_Mods { get; set; } = string.Empty;
            public bool Enable_Multiplayer { get; set; }
            public string Selected_Game_Mode { get; set; } = string.Empty;
            public string Selected_Players { get; set; } = string.Empty;
            public string Host { get; set; } = string.Empty;
            public string Port { get; set; } = string.Empty;
            public string Selected_FragLimit { get; set; } = string.Empty;
            public string Selected_TimeLimit { get; set; } = string.Empty;
            public string Selected_DMFlags { get; set; } = string.Empty;
            public string Selected_DMFlags2 { get; set; } = string.Empty;
        }

        //creates a template of a cached WAD level-lump scan result
        public class WadLevelsCacheEntry
        {
            public int Id { get; set; }
            public string WAD_Path { get; set; } = string.Empty;
            public List<string> Levels { get; set; } = new();
        }

        public class ProfilesContainer
        {
            public string LastSelectedProfile { get; set; } = "Default";
            public List<GameConfigStructure> Entries { get; set; } = new();
        }

        //creates a template of the saved main window position/size (0/0 = not saved yet, falls back to the designer default)
        public class WindowSettings
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public bool Maximized { get; set; }
        }

        public class ConfigurationRoot
        {
            public BindingList<EnginesListStructure> Engines { get; set; } = new();
            public BindingList<WADListStructure> WADs { get; set; } = new();
            public BindingList<ModsListStructure> Mods { get; set; } = new();
            public ProfilesContainer Profiles { get; set; } = new();
            public List<WadLevelsCacheEntry> WADLevelsCache { get; set; } = new();
            public WindowSettings Window { get; set; } = new();
        }

        public class RootConfig
        {
            [JsonPropertyName("CONFIGURATION")]
            public ConfigurationRoot Configuration { get; set; } = new ConfigurationRoot();
        }
    }

    internal static class Init
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Launcher_Window());
        }
    }
}
