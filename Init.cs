using System;
using System.Collections.Generic;
using System.ComponentModel; // <-- Add this using directive
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
        public static RootConfig Profiles = new RootConfig();
        public static string wad_config_path = "wad_config.json";
        public static string engine_config_path = "engine_config.json";
        public static string mods_config_path = "mods_config.json";
        public static string game_config_path = "game_config.json";
        public static string wad_levels_db_path = "wad_levels_database.json";

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
            public string WAD_Name { get; set; } = string.Empty;
            public string WAD_Dir { get; set; } = string.Empty;
        }
        //creates the list that will contain the WADs
        public static BindingList<WADListStructure> WADList = new BindingList<WADListStructure>();

        //creates a template of the Engines list (the structure)
        public class EnginesListStructure
        {
            public string Engine_Nickname { get; set; } = string.Empty;
            public string Engine_Dir { get; set; } = string.Empty;
            public string Engine_Config { get; set; } = string.Empty;
        }
        //creates the list that will contain the Engines
        public static BindingList<EnginesListStructure> EnginesList = new BindingList<EnginesListStructure>();

        //creates a template of the Mods list (the structure)
        public class ModsListStructure
        {
            public string Mod_Name { get; set; } = string.Empty;
            public string Mod_Dir { get; set; } = string.Empty;
        }
        //creates the list that will contain the Mods
        public static BindingList<ModsListStructure> ModsList = new BindingList<ModsListStructure>();

        //creates a template of the Game config (the structure)
        public class GameConfigStructure
        {
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

        public class RootConfig
        {
            [JsonPropertyName("CONFIGURATION")]
            public Dictionary<string, GameConfigStructure> Configuration { get; set; } = new Dictionary<string, GameConfigStructure>();
            public string LastSelectedProfile { get; set; } = "Default"; // New property to store the last selected profile
        }
        //creates the variable that will contain the Game config
        public static BindingList<GameConfigStructure> GameConfig = new BindingList<GameConfigStructure>();
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
