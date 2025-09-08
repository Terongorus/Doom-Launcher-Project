using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel; // <-- Add this using directive

namespace Doom_Launcher_Project
{
    public static class  Globals
    {
        public static string game_launch_engine = string.Empty;
        public static string game_launch_arguments = string.Empty;
        public static string game_launch_command = string.Empty;

        //config file paths
        public static string wad_config_path = "wad_config.json";
        public static string engine_config_path = "engine_config.json";
        public static string mods_config_path = "mods_config.json";
        public static string game_config_path = "game_config.json";
        public static string match = "iwad_variants_doom_names.json";

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

        //maps container for Doom 1
        public static string[] doom_1_maps = new string[]
        {
            "(Default)",
            "E1M1",
            "E1M2",
            "E1M3",
            "E1M4",
            "E1M5",
            "E1M6",
            "E1M7",
            "E1M8",
            "E1M9",
            "E2M1",
            "E2M2",
            "E2M3",
            "E2M4",
            "E2M5",
            "E2M6",
            "E2M7",
            "E2M8",
            "E2M9",
            "E3M1",
            "E3M2",
            "E3M3",
            "E3M4",
            "E3M5",
            "E3M6",
            "E3M7",
            "E3M8",
            "E3M9",
            "E4M1",
            "E4M2",
            "E4M3",
            "E4M4",
            "E4M5",
            "E4M6",
            "E4M7",
            "E4M8",
            "E4M9"
        };

        //maps container for Doom 2
        public static string[] doom_2_maps = new string[]
        {
            "(Default)",
            "MAP01",
            "MAP02",
            "MAP03",
            "MAP04",
            "MAP05",
            "MAP06",
            "MAP07",
            "MAP08",
            "MAP09",
            "MAP10",
            "MAP11",
            "MAP12",
            "MAP13",
            "MAP14",
            "MAP15",
            "MAP16",
            "MAP17",
            "MAP18",
            "MAP19",
            "MAP20",
            "MAP21",
            "MAP22",
            "MAP23",
            "MAP24",
            "MAP25",
            "MAP26",
            "MAP27",
            "MAP28",
            "MAP29",
            "MAP30",
            "MAP31",
            "MAP32",
            "MAP33",
            "MAP34",
            "MAP35",
            "MAP36",
            "MAP37",
            "MAP38",
            "MAP39",
            "MAP40"
        };

        public class WADMatchListStructure
        {
            public string wad_name { get; set; }
            public string wad_name_2 { get; set; }
        }
        public static BindingList<WADMatchListStructure> MATCHWADLIST1 = new BindingList<WADMatchListStructure>();
        public static BindingList<WADMatchListStructure> MATCHWADLIST2 = new BindingList<WADMatchListStructure>();

        //creates a template of the WAD list (the structure)
        public class WADListStructure
        {
            public string WAD_Name { get; set; }
            public string WAD_Dir { get; set; }
        }
        //creates the list that will contain the WADs
        public static BindingList<WADListStructure> WADList = new BindingList<WADListStructure>();

        //creates a template of the Engines list (the structure)
        public class EnginesListStructure
        {
            public string Engine_Name { get; set; }
            public string Engine_Dir { get; set; }
        }
        //creates the list that will contain the Engines
        public static BindingList<EnginesListStructure> EnginesList = new BindingList<EnginesListStructure>();

        //creates a template of the Mods list (the structure)
        public class ModsListStructure
        {
            public string Mod_Name { get; set; }
            public string Mod_Dir { get; set; }
        }
        //creates the list that will contain the Mods
        public static BindingList<ModsListStructure> ModsList = new BindingList<ModsListStructure>();

        //creates a template of the Game config (the structure)
        public class GameConfigStructure
        {
            public string Selected_Engine { get; set; }
            public string Selected_WAD { get; set; }
            public string Selected_Map { get; set; }
            public string Selected_SkillLevel { get; set; }
            public string Selected_Mods { get; set; }
            public bool Enable_Multiplayer { get; set; }
            public string Selected_Game_Mode { get; set; }
            public string Selected_Players { get; set; }
            public string Host { get; set; }
            public string Port { get; set; }
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
