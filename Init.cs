using System;
using System.Collections.Generic;
using System.ComponentModel; // <-- Add this using directive
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Windows;

namespace TeronDoomLauncher
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

        // Local (not Roaming) AppData, matching this user's other apps - single-machine
        // settings shouldn't roam, and writing next to the installed .exe (the old behavior)
        // could fail for non-admin users since Program Files isn't normally writable.
        public static readonly string appdata_folder =
            System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TeronDoomLauncher");
        public static string launcher_config_path = System.IO.Path.Combine(appdata_folder, "launcher_config.json");
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
            public string Additional_Parameters { get; set; } = string.Empty;
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
        private static Mutex? _singleInstanceMutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _singleInstanceMutex = new Mutex(true, "TeronDoomLauncher.SingleInstance", out bool createdNew);
            if (!createdNew)
            {
                MessageBox.Show(
                    $"{GetDisplayName()} is already running.",
                    GetDisplayName(),
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            var app = new Application();
            app.DispatcherUnhandledException += (_, args) =>
            {
                LogException(args.Exception);
                args.Handled = true;
            };
            AppDomain.CurrentDomain.UnhandledException += (_, args) =>
            {
                if (args.ExceptionObject is Exception ex)
                    LogException(ex);
            };
            System.Threading.Tasks.TaskScheduler.UnobservedTaskException += (_, args) =>
            {
                LogException(args.Exception);
                args.SetObserved();
            };

            app.Run(new LauncherWindow());

            _singleInstanceMutex.ReleaseMutex();
        }

        // Reads from the assembly's <Product> metadata (set in TeronDoomLauncher.csproj) rather
        // than a hardcoded literal, so it can't drift from the project file. The "(TDL)"
        // abbreviation suffix is dropped, matching the main window title bar.
        private static string GetDisplayName()
        {
            string product = ((AssemblyProductAttribute?)Attribute.GetCustomAttribute(
                Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute)))?.Product ?? "TeronDoomLauncher";
            int parenIndex = product.IndexOf(" (", StringComparison.Ordinal);
            return parenIndex > 0 ? product[..parenIndex] : product;
        }

        private static void LogException(Exception ex)
        {
            try
            {
                string logPath = System.IO.Path.Combine(Globals.appdata_folder, "error.log");
                System.IO.Directory.CreateDirectory(Globals.appdata_folder);
                System.IO.File.AppendAllText(logPath, $"{DateTime.Now:O}{Environment.NewLine}{ex}{Environment.NewLine}{Environment.NewLine}");
            }
            catch
            {
                // Logging is best-effort; nothing else we can do if it fails.
            }
        }
    }
}
