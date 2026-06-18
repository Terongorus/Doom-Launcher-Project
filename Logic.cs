using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.ApplicationServices;
using System.Reflection;

namespace Doom_Launcher_Project
{
    // Parses the raw WAD binary format (header + lump directory) instead of matching
    // against hardcoded filename/lump lists.
    public static class WadBinaryUtils
    {
        private static readonly Regex ExMyLumpPattern = new Regex(@"^E[0-9]M[0-9]$", RegexOptions.Compiled);
        private static readonly Regex MapxyLumpPattern = new Regex(@"^MAP[0-9]{2}$", RegexOptions.Compiled);

        // Reads the 4-byte "IWAD"/"PWAD" signature from the start of a WAD file.
        public static string ReadWadIdentification(string path)
        {
            try
            {
                using FileStream fs = File.OpenRead(path);
                byte[] header = new byte[4];
                if (fs.Read(header, 0, 4) != 4) return string.Empty;
                return System.Text.Encoding.ASCII.GetString(header);
            }
            catch
            {
                return string.Empty;
            }
        }

        // Walks the WAD's lump directory and returns every ExMy/MAPxy level marker lump
        // found, in directory order, deduplicated.
        public static List<string> ScanLevelLumps(string path)
        {
            List<string> levels = new List<string>();
            try
            {
                using FileStream fs = File.OpenRead(path);
                using BinaryReader reader = new BinaryReader(fs);
                if (fs.Length < 12) return levels;

                string identification = System.Text.Encoding.ASCII.GetString(reader.ReadBytes(4));
                if (identification != "IWAD" && identification != "PWAD") return levels;

                int numLumps = reader.ReadInt32();
                int dirOffset = reader.ReadInt32();
                if (numLumps <= 0 || dirOffset < 0 || dirOffset + (long)numLumps * 16 > fs.Length) return levels;

                fs.Seek(dirOffset, SeekOrigin.Begin);
                for (int i = 0; i < numLumps; i++)
                {
                    reader.ReadInt32(); // lump data offset, unused for level detection
                    reader.ReadInt32(); // lump size, unused for level detection
                    string name = System.Text.Encoding.ASCII.GetString(reader.ReadBytes(8)).TrimEnd('\0').ToUpperInvariant();

                    if ((ExMyLumpPattern.IsMatch(name) || MapxyLumpPattern.IsMatch(name)) && !levels.Contains(name))
                        levels.Add(name);
                }
            }
            catch
            {
                return new List<string>();
            }
            return levels;
        }
    }

    // Caches the level lumps found in each WAD so a given file only needs to be
    // binary-scanned once. Backed by Globals.Config.Configuration.WADLevelsCache
    // (part of the single combined config file) rather than its own file.
    public static class WadLevelDatabase
    {
        public static List<string> GetLevels(string wadPath)
        {
            string key = Path.GetFullPath(wadPath);
            List<Globals.WadLevelsCacheEntry> cache = Globals.Config.Configuration.WADLevelsCache;

            Globals.WadLevelsCacheEntry? existing = cache.FirstOrDefault(e => string.Equals(e.WAD_Path, key, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
                return existing.Levels;

            List<string> levels = WadBinaryUtils.ScanLevelLumps(wadPath);
            levels.Sort((a, b) => GetSortKey(a).CompareTo(GetSortKey(b)));

            cache.Add(new Globals.WadLevelsCacheEntry { WAD_Path = key, Levels = levels });
            ConfigStore.SaveAll();
            return levels;
        }

        private static int GetSortKey(string name)
        {
            if (name.Length == 4 && name[0] == 'E' && name[2] == 'M')
                return (name[1] - '0') * 10 + (name[3] - '0');
            if (name.Length == 5 && name.StartsWith("MAP"))
                return 1000 + int.Parse(name.Substring(3, 2));
            return int.MaxValue;
        }
    }

    // Centralizes all reads/writes of the single combined launcher_config.json file
    // that replaces the formerly separate engine/wad/mods/game/wad-levels files.
    public static class ConfigStore
    {
        public static void LoadAll()
        {
            if (!File.Exists(Globals.launcher_config_path))
                MigrateLegacyFiles();

            string json = File.Exists(Globals.launcher_config_path) ? File.ReadAllText(Globals.launcher_config_path) : string.Empty;
            Globals.Config = string.IsNullOrWhiteSpace(json)
                ? new Globals.RootConfig()
                : JsonSerializer.Deserialize<Globals.RootConfig>(json, Globals.JsonOptions) ?? new Globals.RootConfig();

            Globals.EnginesList = Globals.Config.Configuration.Engines;
            Globals.WADList = Globals.Config.Configuration.WADs;
            Globals.ModsList = Globals.Config.Configuration.Mods;
        }

        public static void SaveAll()
        {
            // Re-sync in case a caller replaced the list reference wholesale instead of mutating in place.
            Globals.Config.Configuration.Engines = Globals.EnginesList;
            Globals.Config.Configuration.WADs = Globals.WADList;
            Globals.Config.Configuration.Mods = Globals.ModsList;

            AssignSequentialIds(Globals.Config.Configuration.Engines, (e, id) => e.Id = id);
            AssignSequentialIds(Globals.Config.Configuration.WADs, (w, id) => w.Id = id);
            AssignSequentialIds(Globals.Config.Configuration.Mods, (m, id) => m.Id = id);
            AssignSequentialIds(Globals.Config.Configuration.Profiles.Entries, (p, id) => p.Id = id);
            AssignSequentialIds(Globals.Config.Configuration.WADLevelsCache, (c, id) => c.Id = id);

            File.WriteAllText(Globals.launcher_config_path, JsonSerializer.Serialize(Globals.Config, Globals.JsonOptions));
        }

        private static void AssignSequentialIds<T>(IList<T> entries, Action<T, int> setId)
        {
            for (int i = 0; i < entries.Count; i++)
                setId(entries[i], i + 1);
        }

        // Runs at most once: imports the legacy per-feature files into the new combined
        // file the first time launcher_config_path is missing. Old files are left on disk untouched.
        private static void MigrateLegacyFiles()
        {
            Globals.RootConfig root = new Globals.RootConfig();

            if (File.Exists(Globals.legacy_engine_config_path))
            {
                string json = File.ReadAllText(Globals.legacy_engine_config_path);
                if (!string.IsNullOrWhiteSpace(json))
                    root.Configuration.Engines = JsonSerializer.Deserialize<BindingList<Globals.EnginesListStructure>>(json) ?? new();
            }

            if (File.Exists(Globals.legacy_wad_config_path))
            {
                string json = File.ReadAllText(Globals.legacy_wad_config_path);
                if (!string.IsNullOrWhiteSpace(json))
                    root.Configuration.WADs = JsonSerializer.Deserialize<BindingList<Globals.WADListStructure>>(json) ?? new();
            }

            if (File.Exists(Globals.legacy_mods_config_path))
            {
                string json = File.ReadAllText(Globals.legacy_mods_config_path);
                if (!string.IsNullOrWhiteSpace(json))
                    root.Configuration.Mods = JsonSerializer.Deserialize<BindingList<Globals.ModsListStructure>>(json) ?? new();
            }

            if (File.Exists(Globals.legacy_game_config_path))
            {
                string json = File.ReadAllText(Globals.legacy_game_config_path);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    LegacyGameConfig? legacy = JsonSerializer.Deserialize<LegacyGameConfig>(json);
                    if (legacy != null)
                    {
                        root.Configuration.Profiles.LastSelectedProfile = legacy.LastSelectedProfile;
                        foreach (KeyValuePair<string, Globals.GameConfigStructure> kvp in legacy.Configuration)
                        {
                            kvp.Value.Name = kvp.Key;
                            root.Configuration.Profiles.Entries.Add(kvp.Value);
                        }
                    }
                }
            }

            if (File.Exists(Globals.legacy_wad_levels_db_path))
            {
                string json = File.ReadAllText(Globals.legacy_wad_levels_db_path);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    Dictionary<string, List<string>>? legacyCache = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
                    if (legacyCache != null)
                    {
                        foreach (KeyValuePair<string, List<string>> kvp in legacyCache)
                            root.Configuration.WADLevelsCache.Add(new Globals.WadLevelsCacheEntry { WAD_Path = kvp.Key, Levels = kvp.Value });
                    }
                }
            }

            AssignSequentialIds(root.Configuration.Engines, (e, id) => e.Id = id);
            AssignSequentialIds(root.Configuration.WADs, (w, id) => w.Id = id);
            AssignSequentialIds(root.Configuration.Mods, (m, id) => m.Id = id);
            AssignSequentialIds(root.Configuration.Profiles.Entries, (p, id) => p.Id = id);
            AssignSequentialIds(root.Configuration.WADLevelsCache, (c, id) => c.Id = id);

            File.WriteAllText(Globals.launcher_config_path, JsonSerializer.Serialize(root, Globals.JsonOptions));
        }

        // Mirrors the legacy game_config.json shape (a dictionary keyed by profile name),
        // used only to read that one file during migration.
        private class LegacyGameConfig
        {
            [JsonPropertyName("CONFIGURATION")]
            public Dictionary<string, Globals.GameConfigStructure> Configuration { get; set; } = new();
            public string LastSelectedProfile { get; set; } = "Default";
        }
    }

    public class WAD_Options
    {
        public void AddWADs(Launcher_Window self)
        {
            ConfigStore.LoadAll();

            // Drop placeholder empty entries left over from earlier bootstrapping
            for (int i = Globals.WADList.Count - 1; i >= 0; i--)
                if (string.IsNullOrEmpty(Globals.WADList[i].WAD_Dir) && string.IsNullOrEmpty(Globals.WADList[i].WAD_Name))
                    Globals.WADList.RemoveAt(i);
            for (int i = Globals.ModsList.Count - 1; i >= 0; i--)
                if (string.IsNullOrEmpty(Globals.ModsList[i].Mod_Dir) && string.IsNullOrEmpty(Globals.ModsList[i].Mod_Name))
                    Globals.ModsList.RemoveAt(i);

            //opens a file dialog to select WAD or mod files - they get sorted automatically below
            OpenFileDialog WADFileDialog = new OpenFileDialog
            {
                Title = "Select WAD/Mod Files",
                Filter = "WAD/Mod Files (*.wad;*.pk3;*.zip;*.pk7;*.rar)|*.wad;*.pk3;*.zip;*.pk7;*.rar|All Files (*.*)|*.*",
                Multiselect = true
            };

            if (WADFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("No WAD/mod files were selected.", "Selection Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int addedWads = 0, addedMods = 0;
            foreach (string file in WADFileDialog.FileNames)
            {
                if (Globals.WADList.Any(w => w.WAD_Dir.Equals(file, StringComparison.OrdinalIgnoreCase)) ||
                    Globals.ModsList.Any(m => m.Mod_Dir.Equals(file, StringComparison.OrdinalIgnoreCase)))
                {
                    continue; // Skip adding this duplicate
                }

                // Binary-detect the WAD type rather than trusting the file extension: IWADs
                // (main game data) go to the WAD list, PWADs and everything else (pk3/zip/etc.,
                // which are loaded the same way as PWADs) go to the mods list.
                if (WadBinaryUtils.ReadWadIdentification(file) == "IWAD")
                {
                    Globals.WADList.Add(new Globals.WADListStructure
                    {
                        WAD_Name = Path.GetFileNameWithoutExtension(file),
                        WAD_Dir = file
                    });
                    addedWads++;
                }
                else
                {
                    Globals.ModsList.Add(new Globals.ModsListStructure
                    {
                        Mod_Name = Path.GetFileNameWithoutExtension(file),
                        Mod_Dir = file
                    });
                    addedMods++;
                }
            }

            if (addedWads == 0 && addedMods == 0)
            {
                MessageBox.Show("All selected files were already in the WAD/mod list.", "Nothing Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ConfigStore.SaveAll();

            MessageBox.Show($"{addedWads} WAD(s) and {addedMods} mod(s) added and configuration updated.", "Files Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Load_WADs(self);
            if (addedMods > 0)
            {
                Mods_Options mods_options = new Mods_Options();
                mods_options.Load_Mods(self);
            }
        }

        public void Load_WADs(Launcher_Window self)
        {
            ConfigStore.LoadAll();

            self.wads_list?.Items.Clear();
            foreach (Globals.WADListStructure wad_file in Globals.WADList)
            {
                if (!string.IsNullOrEmpty(wad_file.WAD_Name) && !string.IsNullOrEmpty(wad_file.WAD_Dir))
                {
                    self.wads_list?.Items.Add(wad_file.WAD_Name + " [" + wad_file.WAD_Dir + "]");
                }
                else
                {
                    MessageBox.Show("One or more WAD entries in the configuration file are invalid. Please check launcher_config.json.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }

            // wads_list lists every game file added via AddWADs (IWADs and mods alike);
            // wad_selection/mods_selection are the ones that sort IWADs from mods.
            foreach (Globals.ModsListStructure mod_file in Globals.ModsList)
            {
                if (!string.IsNullOrEmpty(mod_file.Mod_Name) && !string.IsNullOrEmpty(mod_file.Mod_Dir))
                    self.wads_list?.Items.Add(mod_file.Mod_Name + " [" + mod_file.Mod_Dir + "]");
            }

            Game_Options game_options = new Game_Options();
            game_options.Load_WADsToList(self);
        }

        public void Remove_WAD(Launcher_Window self)
        {
            if (self.wads_list == null || self.wads_list.SelectedIndices.Count == 0)
            {
                MessageBox.Show("No WAD/WADs selected to remove.", "Removal Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // wads_list displays WADList entries followed by ModsList entries (see Load_WADs),
            // so anything at or past wadCount belongs to ModsList.
            int wadCount = Globals.WADList.Count;
            var selectedIndices = self.wads_list.SelectedIndices.Cast<int>().OrderByDescending(i => i).ToList();

            bool removedWad = false, removedMod = false;
            foreach (int index in selectedIndices)
            {
                if (index < wadCount)
                {
                    Globals.WADList.RemoveAt(index);
                    removedWad = true;
                }
                else
                {
                    Globals.ModsList.RemoveAt(index - wadCount);
                    removedMod = true;
                }
            }

            if (removedWad || removedMod)
                ConfigStore.SaveAll();

            this.Load_WADs(self);
            if (removedMod)
            {
                Mods_Options mods_options = new Mods_Options();
                mods_options.Load_Mods(self);
            }

            MessageBox.Show("Selected WAD/WADs removed and configuration updated.", "WAD/WADs Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Edit_WAD(Launcher_Window self)
        {
            if (self.wads_list?.SelectedItem == null)
            {
                MessageBox.Show("No WAD/mod selected to edit.", "Edit Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = self.wads_list.SelectedIndex;
            int wadCount = Globals.WADList.Count;

            if (selectedIndex >= 0 && selectedIndex < wadCount)
            {
                EditWadEntry(self, Globals.WADList[selectedIndex]);
            }
            else if (selectedIndex >= wadCount && selectedIndex < wadCount + Globals.ModsList.Count)
            {
                EditModEntry(self, Globals.ModsList[selectedIndex - wadCount]);
            }
        }

        private void EditWadEntry(Launcher_Window self, Globals.WADListStructure wad)
        {
            Form dialog = new Form()
            {
                Width = 560, Height = 230, FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = $"Edit WAD: {wad.WAD_Name}", StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false, MinimizeBox = false
            };

            Label nameLabel = new Label() { Left = 10, Top = 20, Width = 530, Text = "WAD name:" };
            TextBox nameBox = new TextBox() { Left = 10, Top = 45, Width = 520, Text = wad.WAD_Name ?? string.Empty };

            Label dirLabel = new Label() { Left = 10, Top = 85, Width = 530, Text = "WAD file path:" };
            TextBox dirBox = new TextBox() { Left = 10, Top = 110, Width = 430, Text = wad.WAD_Dir ?? string.Empty };
            Button browseBtn = new Button() { Text = "Browse...", Left = 450, Top = 108, Width = 80 };
            browseBtn.Click += (s, e) =>
            {
                using OpenFileDialog ofd = new OpenFileDialog
                {
                    Title = "Select WAD File",
                    Filter = "WAD Files (*.wad)|*.wad|All Files (*.*)|*.*"
                };
                if (!string.IsNullOrEmpty(dirBox.Text) && File.Exists(dirBox.Text))
                    ofd.InitialDirectory = Path.GetDirectoryName(dirBox.Text) ?? string.Empty;
                if (ofd.ShowDialog() == DialogResult.OK)
                    dirBox.Text = ofd.FileName;
            };

            Button okBtn = new Button() { Text = "OK", Left = 360, Top = 155, Width = 80, DialogResult = DialogResult.OK };
            Button cancelBtn = new Button() { Text = "Cancel", Left = 450, Top = 155, Width = 80, DialogResult = DialogResult.Cancel };

            dialog.Controls.AddRange(new Control[] { nameLabel, nameBox, dirLabel, dirBox, browseBtn, okBtn, cancelBtn });
            dialog.AcceptButton = okBtn;
            dialog.CancelButton = cancelBtn;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                wad.WAD_Name = nameBox.Text.Trim();
                wad.WAD_Dir = dirBox.Text.Trim();
                ConfigStore.SaveAll();

                this.Load_WADs(self);
                Game_Options game_options = new Game_Options();
                game_options.Load_WADsToList(self);
            }
        }

        private void EditModEntry(Launcher_Window self, Globals.ModsListStructure mod)
        {
            Form dialog = new Form()
            {
                Width = 560, Height = 230, FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = $"Edit Mod: {mod.Mod_Name}", StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false, MinimizeBox = false
            };

            Label nameLabel = new Label() { Left = 10, Top = 20, Width = 530, Text = "Mod name:" };
            TextBox nameBox = new TextBox() { Left = 10, Top = 45, Width = 520, Text = mod.Mod_Name ?? string.Empty };

            Label dirLabel = new Label() { Left = 10, Top = 85, Width = 530, Text = "Mod file path:" };
            TextBox dirBox = new TextBox() { Left = 10, Top = 110, Width = 430, Text = mod.Mod_Dir ?? string.Empty };
            Button browseBtn = new Button() { Text = "Browse...", Left = 450, Top = 108, Width = 80 };
            browseBtn.Click += (s, e) =>
            {
                using OpenFileDialog ofd = new OpenFileDialog
                {
                    Title = "Select Mod File",
                    Filter = "Mod Files (*.wad;*.pk3;*.zip;*.pk7;*.rar)|*.wad;*.pk3;*.zip;*.pk7;*.rar|All Files (*.*)|*.*"
                };
                if (!string.IsNullOrEmpty(dirBox.Text) && File.Exists(dirBox.Text))
                    ofd.InitialDirectory = Path.GetDirectoryName(dirBox.Text) ?? string.Empty;
                if (ofd.ShowDialog() == DialogResult.OK)
                    dirBox.Text = ofd.FileName;
            };

            Button okBtn = new Button() { Text = "OK", Left = 360, Top = 155, Width = 80, DialogResult = DialogResult.OK };
            Button cancelBtn = new Button() { Text = "Cancel", Left = 450, Top = 155, Width = 80, DialogResult = DialogResult.Cancel };

            dialog.Controls.AddRange(new Control[] { nameLabel, nameBox, dirLabel, dirBox, browseBtn, okBtn, cancelBtn });
            dialog.AcceptButton = okBtn;
            dialog.CancelButton = cancelBtn;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mod.Mod_Name = nameBox.Text.Trim();
                mod.Mod_Dir = dirBox.Text.Trim();
                ConfigStore.SaveAll();

                this.Load_WADs(self);
                Mods_Options mods_options = new Mods_Options();
                mods_options.Load_Mods(self);
            }
        }
    }

    public class Engine_Options
    {
        // Builds a default nickname from the executable's own file version metadata
        // (e.g. "gzdoom-4.11.0") instead of guessing from the file path.
        private static string BuildDefaultNickname(string file)
        {
            string baseName = Path.GetFileNameWithoutExtension(file);
            try
            {
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(file);
                string version = versionInfo.FileVersion?.Trim() ?? string.Empty;

                // Some files (e.g. Windows system binaries) append build metadata after a
                // space, like "10.0.26100.8457 (WinBuild.160101.0800)" - keep just the version.
                int spaceIndex = version.IndexOf(' ');
                if (spaceIndex > 0)
                    version = version.Substring(0, spaceIndex);

                // Strip a leading 'g' (GZDoom) or 'v' so we don't end up with "gzdoom-g4.11.0"
                if (version.Length > 1 && (version[0] is 'g' or 'G' or 'v' or 'V'))
                    version = version.Substring(1);

                return string.IsNullOrEmpty(version) ? baseName : $"{baseName}-{version}";
            }
            catch
            {
                return baseName;
            }
        }

        public void AddEngines(Launcher_Window self)
        {
            ConfigStore.LoadAll();

            //opens a file dialog to select engine files
            OpenFileDialog EngineFileDialog = new OpenFileDialog
            {
                Title = "Select Engine Files",
                Filter = "Engine Files (*.exe)|*.exe|All Files (*.*)|*.*",
                Multiselect = true
            };
            if (EngineFileDialog.ShowDialog() == DialogResult.OK && Globals.EnginesList != null && self.engines_list != null)
            {
                foreach (string file in EngineFileDialog.FileNames)
                {
                    if (Globals.EnginesList.Any(e => e.Engine_Dir != null && e.Engine_Dir.Equals(file, StringComparison.OrdinalIgnoreCase)))
                    {
                        continue; // Skip adding this duplicate engine
                    }
                    if (Globals.EnginesList.Any(e => e.Engine_Dir.Equals("", StringComparison.OrdinalIgnoreCase)) || Globals.EnginesList.Any(e => e.Engine_Nickname.Equals("", StringComparison.OrdinalIgnoreCase)))
                    {
                        Globals.EnginesList.RemoveAt(0);
                    }
                    Globals.EnginesListStructure engine_entry = new Globals.EnginesListStructure
                    {
                        Engine_Nickname = BuildDefaultNickname(file),
                        Engine_Dir = file
                    };
                    Globals.EnginesList.Add(engine_entry);
                }
                ConfigStore.SaveAll();
                MessageBox.Show("Engine/engines added and configuration updated.", "Engine/engines Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Load_Engines(self);
            }
            else
            {
                MessageBox.Show("No engine files were selected.", "Selection Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        public void Load_Engines(Launcher_Window self)
        {
            ConfigStore.LoadAll();

            self.engines_list?.Items.Clear();

            // Repair legacy entries whose nickname is actually a directory path (a past bug),
            // regenerating it from the executable's file version metadata instead.
            bool repairedNicknames = false;
            foreach (Globals.EnginesListStructure engine_file in Globals.EnginesList)
            {
                if (!string.IsNullOrEmpty(engine_file.Engine_Dir) &&
                    (string.IsNullOrEmpty(engine_file.Engine_Nickname) ||
                     engine_file.Engine_Nickname.Contains(Path.DirectorySeparatorChar) ||
                     engine_file.Engine_Nickname.Contains(Path.AltDirectorySeparatorChar)))
                {
                    engine_file.Engine_Nickname = BuildDefaultNickname(engine_file.Engine_Dir);
                    repairedNicknames = true;
                }
            }
            if (repairedNicknames)
                ConfigStore.SaveAll();

            foreach (Globals.EnginesListStructure engine_file in Globals.EnginesList)
            {
                if (!string.IsNullOrEmpty(engine_file.Engine_Nickname) && !string.IsNullOrEmpty(engine_file.Engine_Dir))
                {
                    string display = engine_file.Engine_Nickname + " [" + engine_file.Engine_Dir + "]";
                    if (!string.IsNullOrEmpty(engine_file.Engine_Config))
                        display += " (cfg: " + Path.GetFileName(engine_file.Engine_Config) + ")";
                    self.engines_list?.Items.Add(display);
                }
                else
                {
                    MessageBox.Show("One or more engine entries in the configuration file are invalid. Please check launcher_config.json.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            Game_Options game_options = new Game_Options();
            game_options.Load_EnginesToList(self);
        }

        public void Remove_Engine(Launcher_Window self)
        {
            if (self.engines_list?.SelectedItem != null && Globals.EnginesList != null)
            {
                while (self.engines_list?.SelectedItems.Count > 0)
                {
                    int selectedIndex = self.engines_list.SelectedIndex;
                    self.engines_list?.Items.RemoveAt(selectedIndex);
                    Globals.EnginesList.RemoveAt(selectedIndex);
                }
                ConfigStore.SaveAll();
                Game_Options game_options = new Game_Options();
                game_options.Load_EnginesToList(self);

                MessageBox.Show("Selected engine/engines removed and configuration updated.", "Engine/engines Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No engine/engines selected to remove.", "Removal Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        public void Edit_Engine(Launcher_Window self)
        {
            if (self.engines_list?.SelectedItem == null || Globals.EnginesList == null)
            {
                MessageBox.Show("No engine selected to edit.", "Edit Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = self.engines_list.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= Globals.EnginesList.Count) return;

            var engine = Globals.EnginesList[selectedIndex];

            Form dialog = new Form()
            {
                Width = 560, Height = 360, FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = $"Edit Engine: {engine.Engine_Nickname}", StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false, MinimizeBox = false
            };

            // Nickname
            Label nicknameLabel = new Label() { Left = 10, Top = 20, Width = 530, Text = "Nickname (shown in engine dropdown):" };
            TextBox nicknameBox = new TextBox() { Left = 10, Top = 45, Width = 520, Text = engine.Engine_Nickname ?? string.Empty };

            // Engine executable path
            Label dirLabel = new Label() { Left = 10, Top = 85, Width = 530, Text = "Engine executable path:" };
            TextBox dirBox = new TextBox() { Left = 10, Top = 110, Width = 430, Text = engine.Engine_Dir ?? string.Empty };
            Button browseExeBtn = new Button() { Text = "Browse...", Left = 450, Top = 108, Width = 80 };
            browseExeBtn.Click += (s, e) =>
            {
                using OpenFileDialog ofd = new OpenFileDialog
                {
                    Title = "Select Engine Executable",
                    Filter = "Engine Files (*.exe)|*.exe|All Files (*.*)|*.*"
                };
                if (!string.IsNullOrEmpty(dirBox.Text) && File.Exists(dirBox.Text))
                    ofd.InitialDirectory = Path.GetDirectoryName(dirBox.Text) ?? string.Empty;
                if (ofd.ShowDialog() == DialogResult.OK)
                    dirBox.Text = ofd.FileName;
            };

            // Config file
            Label configLabel = new Label() { Left = 10, Top = 150, Width = 530, Text = "Config file path (passed as -config <path> to the engine):" };
            TextBox configBox = new TextBox() { Left = 10, Top = 175, Width = 430, Text = engine.Engine_Config ?? string.Empty };
            Button browseConfigBtn = new Button() { Text = "Browse...", Left = 450, Top = 173, Width = 80 };
            browseConfigBtn.Click += (s, e) =>
            {
                using OpenFileDialog ofd = new OpenFileDialog
                {
                    Title = "Select Config File",
                    Filter = "Config Files (*.cfg;*.ini)|*.cfg;*.ini|All Files (*.*)|*.*"
                };
                if (!string.IsNullOrEmpty(configBox.Text) && File.Exists(configBox.Text))
                    ofd.InitialDirectory = Path.GetDirectoryName(configBox.Text) ?? string.Empty;
                else if (!string.IsNullOrEmpty(dirBox.Text))
                    ofd.InitialDirectory = Path.GetDirectoryName(dirBox.Text) ?? string.Empty;
                if (ofd.ShowDialog() == DialogResult.OK)
                    configBox.Text = ofd.FileName;
            };
            Button okBtn = new Button() { Text = "OK", Left = 360, Top = 285, Width = 80, DialogResult = DialogResult.OK };
            Button cancelBtn = new Button() { Text = "Cancel", Left = 450, Top = 285, Width = 80, DialogResult = DialogResult.Cancel };

            dialog.Controls.AddRange(new Control[] {
                nicknameLabel, nicknameBox,
                dirLabel, dirBox, browseExeBtn,
                configLabel, configBox, browseConfigBtn,
                okBtn, cancelBtn
            });
            dialog.AcceptButton = okBtn;
            dialog.CancelButton = cancelBtn;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                engine.Engine_Nickname = nicknameBox.Text.Trim();
                engine.Engine_Dir = dirBox.Text.Trim();
                engine.Engine_Config = configBox.Text.Trim();
                ConfigStore.SaveAll();
                this.Load_Engines(self);
            }
        }
    }

    public class Mods_Options
    {
        public void AddMods(Launcher_Window self)
        {
            ConfigStore.LoadAll();

            //opens a file dialog to select mod files
            OpenFileDialog ModFileDialog = new OpenFileDialog
            {
                Title = "Select Mod Files",
                Filter = "Mod Files (*.wad, *.pk3, *.zip, *.pk7, *.rar)|*.wad;*.pk3;*.zip;*.pk7;*.rar|All Files (*.*)|*.*",
                Multiselect = true
            };
            if (ModFileDialog.ShowDialog() == DialogResult.OK && Globals.ModsList != null)
            {
                foreach (string file in ModFileDialog.FileNames)
                {
                    if (Globals.ModsList.Any(m => m.Mod_Dir != null && m.Mod_Dir.Equals(file, StringComparison.OrdinalIgnoreCase)))
                    {
                        continue;
                    }
                    if (Globals.ModsList.Any(m => m.Mod_Dir.Equals("", StringComparison.OrdinalIgnoreCase)) || Globals.ModsList.Any(m => m.Mod_Name.Equals("", StringComparison.OrdinalIgnoreCase)))
                    {
                        Globals.ModsList.RemoveAt(0);
                    }
                    Globals.ModsListStructure mod_entry = new Globals.ModsListStructure
                    {
                        Mod_Name = Path.GetFileNameWithoutExtension(file),
                        Mod_Dir = file
                    };
                    Globals.ModsList.Add(mod_entry);
                    ConfigStore.SaveAll();
                    this.Load_Mods(self);
                    MessageBox.Show("Mod/mods added and configuration updated.", "Mod/mods Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No mod files were selected.", "Selection Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        public void Load_Mods(Launcher_Window self)
        {
            ConfigStore.LoadAll();

            self.mods_selection?.Items.Clear();
            foreach (Globals.ModsListStructure mod_file in Globals.ModsList)
            {
                if (!string.IsNullOrEmpty(mod_file.Mod_Name))
                {
                    self.mods_selection?.Items.Add(mod_file.Mod_Name!);
                }
                // If Mod_Name is empty, just skip it. No need for a MessageBox.
            }
        }

        public void Remove_Mod(Launcher_Window self)
        {
            if (self.mods_selection != null && self.mods_selection.SelectedItem != null && Globals.ModsList != null)
            {
                while (self.mods_selection?.SelectedItems.Count > 0)
                {
                    int selectedIndex = self.mods_selection.SelectedIndex;
                    self.mods_selection?.Items.RemoveAt(selectedIndex);
                    Globals.ModsList.RemoveAt(selectedIndex);
                }
                ConfigStore.SaveAll();
                MessageBox.Show("Selected mod/mods removed and configuration updated.", "Mod/mods Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No mod/mods selected to remove.", "Removal Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }

    public class Game_Options
    {
        public Globals.GameConfigStructure GetConfigFromUI(Launcher_Window self)
        {
            return new Globals.GameConfigStructure
            {
                Selected_Engine = self.engine_selection?.SelectedItem?.ToString() ?? string.Empty,
                Selected_WAD = self.wad_selection?.SelectedItem?.ToString() ?? string.Empty,
                Selected_Map = self.map_selection?.SelectedItem?.ToString() ?? string.Empty,
                Selected_SkillLevel = self.difficulty_selection?.SelectedItem?.ToString() ?? string.Empty,
                Selected_Mods = self.mods_selection?.CheckedItems.Count > 0 ? string.Join(";", self.mods_selection.CheckedItems.Cast<string>()) : string.Empty,
                //online gameplay options save
                Enable_Multiplayer = self.enable_multiplayer?.Checked ?? false,
                Selected_Game_Mode = self.multiplayer_game_mode_select?.SelectedItem?.ToString() ?? string.Empty,
                Selected_Players = self.players_host_select?.SelectedItem?.ToString() ?? string.Empty,
                Host = self.hostname_ip_textbox?.Text ?? string.Empty,
                Port = self.port_textbox?.Text ?? string.Empty,
                Selected_FragLimit = self.frag_limit?.Text ?? string.Empty,
                Selected_TimeLimit = self.time_limit?.Text ?? string.Empty,
                Selected_DMFlags = self.dmflags?.Text ?? string.Empty,
                Selected_DMFlags2 = self.dmflags2?.Text ?? string.Empty
            };
        }

        public void ProductDetails(Launcher_Window self)
        {
            string ProductName = Assembly.GetExecutingAssembly().GetName().Name ?? "Unknown";
            string ProductVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Unknown";
            self.Text = $"{ProductName} - v{ProductVersion}";
        }

        public void OnlineModeEnable(Launcher_Window self)
        {
            if (self.enable_multiplayer?.Checked == true)
            {
                self.game_mode_label.Enabled = true;
                self.multiplayer_game_mode_select.Enabled = true;
                self.players_host_label.Enabled = true;
                self.players_host_select.Enabled = true;
                self.hostname_ip_label.Enabled = true;
                self.hostname_ip_textbox.Enabled = true;
                self.port_label.Enabled = true;
                self.port_textbox.Enabled = true;
                self.frag_limit_label.Enabled = true;
                self.frag_limit.Enabled = true;
                self.time_limit_label.Enabled = true;
                self.time_limit.Enabled = true;
                self.dmflags_label.Enabled = true;
                self.dmflags.Enabled = true;
                self.dmflags2_label.Enabled = true;
                self.dmflags2.Enabled = true;
            }
            else 
            {
                self.game_mode_label.Enabled = false;
                self.multiplayer_game_mode_select.Enabled = false;
                self.players_host_label.Enabled = false;
                self.players_host_select.Enabled = false;
                self.hostname_ip_label.Enabled = false;
                self.hostname_ip_textbox.Enabled = false;
                self.port_label.Enabled = false;
                self.port_textbox.Enabled = false;
                self.frag_limit_label.Enabled = false;
                self.frag_limit.Enabled = false;
                self.time_limit_label.Enabled = false;
                self.time_limit.Enabled = false;
                self.dmflags_label.Enabled = false;
                self.dmflags.Enabled = false;
                self.dmflags2_label.Enabled = false;
                self.dmflags2.Enabled = false;
            }
        }

        public void Save_GameOptions(Launcher_Window self)
        {
            // If we are currently loading the config into the UI, do not save.
            // This prevents programmatic UI changes from overwriting the JSON with empty values.
            if (Globals.IsLoadingConfig)
                return;

            List<Globals.GameConfigStructure> entries = Globals.Config.Configuration.Profiles.Entries;
            Globals.GameConfigStructure? existing = entries.FirstOrDefault(p => p.Name == Globals.SelectedProfile);
            Globals.GameConfigStructure updated = GetConfigFromUI(self);
            updated.Name = Globals.SelectedProfile;

            if (existing != null)
                entries[entries.IndexOf(existing)] = updated;
            else
                entries.Add(updated);

            ConfigStore.SaveAll();
        }

        public void Load_GameOptions(Launcher_Window self)
        {
            if (self.wad_selection.Items == null || self.engine_selection.Items == null)
                return;

            // Start the loading guard
            Globals.IsLoadingConfig = true;

            try
            {
                ConfigStore.LoadAll();

                Globals.GameConfigStructure? config = Globals.Config.Configuration.Profiles.Entries.FirstOrDefault(p => p.Name == Globals.SelectedProfile);
                if (config != null)
                {

                    if (!string.IsNullOrEmpty(config.Selected_WAD))
                    {
                        Globals.WADListStructure? selectedWadEntry = Globals.WADList.FirstOrDefault(w => w.WAD_Name == config.Selected_WAD);
                        if (selectedWadEntry != null)
                        {
                            int index = self.wad_selection.Items.IndexOf(selectedWadEntry.WAD_Name);
                            if (index != -1)
                            {
                                self.wad_selection.SelectedIndex = index;
                                this.Load_MapsToList(self);
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(config.Selected_Engine))
                    {
                        Globals.EnginesListStructure? selectedEngineEntry = Globals.EnginesList.FirstOrDefault(e => e.Engine_Nickname == config.Selected_Engine);
                        if (selectedEngineEntry != null)
                        {
                            int index = self.engine_selection.Items.IndexOf(selectedEngineEntry.Engine_Nickname);
                            if (index != -1)
                                self.engine_selection.SelectedIndex = index;
                        }
                    }

                    for (int i = 0; i < self.mods_selection.Items.Count; i++)
                        self.mods_selection.SetItemChecked(i, false);

                    if (!string.IsNullOrEmpty(config.Selected_Mods))
                    {
                        string[] selectedModNames = config.Selected_Mods.Split(';', StringSplitOptions.RemoveEmptyEntries);
                        foreach (string modName in selectedModNames)
                        {
                            int index = self.mods_selection.Items.IndexOf(modName);
                            if (index != -1)
                                self.mods_selection.SetItemChecked(index, true);
                        }
                    }

                    self.enable_multiplayer.Checked = config.Enable_Multiplayer;

                    if (!string.IsNullOrEmpty(config.Selected_Game_Mode))
                    {
                        int index = self.multiplayer_game_mode_select.Items.IndexOf(config.Selected_Game_Mode);
                        if (index != -1) self.multiplayer_game_mode_select.SelectedIndex = index;
                    }

                    if (!string.IsNullOrEmpty(config.Selected_Players))
                    {
                        int index = self.players_host_select.Items.IndexOf(config.Selected_Players);
                        if (index != -1) self.players_host_select.SelectedIndex = index;
                    }

                    self.hostname_ip_textbox.Text = config.Host;
                    self.port_textbox.Text = config.Port;
                    if (self.frag_limit != null) self.frag_limit.Text = config.Selected_FragLimit;
                    if (self.time_limit != null) self.time_limit.Text = config.Selected_TimeLimit;
                    if (self.dmflags != null) self.dmflags.Text = config.Selected_DMFlags;
                    if (self.dmflags2 != null) self.dmflags2.Text = config.Selected_DMFlags2;

                    if (!string.IsNullOrEmpty(config.Selected_SkillLevel))
                    {
                        int index = self.difficulty_selection.Items.IndexOf(config.Selected_SkillLevel);
                        if (index != -1) self.difficulty_selection.SelectedIndex = index;
                    }

                    if (self.wad_selection.SelectedItem != null && !string.IsNullOrEmpty(config.Selected_Map))
                    {
                        int index = self.map_selection.Items.IndexOf(config.Selected_Map);
                        if (index != -1) self.map_selection.SelectedIndex = index;
                    }
                }
            }
            finally
            {
                // Always ensure the guard is released
                Globals.IsLoadingConfig = false;
            }
        }

        public void Load_WADsToList(Launcher_Window self)
        {
            ConfigStore.LoadAll();

            self.wad_selection.Items.Clear();
            string temp_name = string.Empty;
            self.wad_selection.Items.Add("(None)");
            foreach (Globals.WADListStructure wad in Globals.WADList)
            {
                temp_name = wad.WAD_Name ?? string.Empty;
                self.wad_selection.Items.Add(temp_name);
            }
        }

        public void Load_EnginesToList(Launcher_Window self)
        {
            ConfigStore.LoadAll();

            self.engine_selection.Items.Clear();
            string temp_name = string.Empty;
            foreach (Globals.EnginesListStructure engine in Globals.EnginesList)
            {
                temp_name = engine.Engine_Nickname ?? string.Empty;
                self.engine_selection.Items.Add(temp_name);
            }
        }

        public void Load_OnlineGameplayModes(Launcher_Window self)
        {
            //populate the game mode selection
            self.multiplayer_game_mode_select?.Items.Clear();
            self.multiplayer_game_mode_select?.Items.Add("CO-OP");
            self.multiplayer_game_mode_select?.Items.Add("Deathmatch");
            self.multiplayer_game_mode_select?.Items.Add("Alt Deathmatch");
        }

        public void Load_PlayerSelectList(Launcher_Window self)
        {
            //populate the players (host/join) selection
            self.players_host_select?.Items.Clear();
            self.players_host_select?.Items.Add("Join");
            for (int cnt1 = 1; cnt1 < 9; cnt1++)
            {
                self.players_host_select?.Items.Add("Host " + cnt1);
            }
            self.players_host_select?.Items.Add("(More)");
        }

        public void Load_SkillLevelsToList(Launcher_Window self)
        {
            self.difficulty_selection?.Items.Clear();
            self.difficulty_selection?.Items.Add("(Default)");
            self.difficulty_selection?.Items.Add("Very Easy");
            self.difficulty_selection?.Items.Add("Easy");
            self.difficulty_selection?.Items.Add("Medium");
            self.difficulty_selection?.Items.Add("Hard");
            self.difficulty_selection?.Items.Add("Very Hard");
        }

        public void Load_MapsToList(Launcher_Window self)
        {
            if (self.wad_selection?.SelectedItem?.ToString() is string selectedWad && selectedWad != "(None)")
            {
                string? wadPath = Globals.WADList.FirstOrDefault(w => w.WAD_Name == selectedWad)?.WAD_Dir;

                if (string.IsNullOrEmpty(wadPath) || !File.Exists(wadPath))
                {
                    self.map_selection?.Items.Clear();
                    return;
                }

                // Pull the actual level lumps present in this WAD (cached after the first scan)
                // instead of dumping a hardcoded list of every possible Doom 1/2 map.
                List<string> levels = WadLevelDatabase.GetLevels(wadPath);

                if (self.map_selection != null)
                {
                    self.map_selection.Items.Clear();
                    if (levels.Count > 0)
                    {
                        self.map_selection.Items.Add("(Default)");
                        foreach (string level in levels)
                            self.map_selection.Items.Add(level);
                        self.map_selection.SelectedIndex = 0;
                    }
                    // No ExMy/MAPxy lumps found: leave the list empty silently, no popup.
                }
            }
            else
            {
                self.map_selection?.Items.Clear();
            }
        }

        public void GenerateExecutable(Launcher_Window self)
        {
            ConfigStore.LoadAll();
            {
                //command line to launch the game
                string arguments = string.Empty;

                //game arguments
                string selected_engine = string.Empty;
                string selected_config = string.Empty;
                string selected_wad = string.Empty;
                string selected_map = string.Empty;
                string selected_difficulty = string.Empty;
                string selected_mod = string.Empty;

                //multiplayers game arguments
                string selected_game_mode = string.Empty;
                string selected_players = string.Empty;
                string host = string.Empty;
                string port = string.Empty;
                string selected_frag_limit = string.Empty;
                string selected_time_limit = string.Empty;
                string selected_dmflags = string.Empty;
                string selected_dmflags2 = string.Empty;

                //check if an engine, mods and a wads are selected
                if (self.engine_selection?.SelectedItem != null)
                {
                    foreach (Globals.EnginesListStructure engine in Globals.EnginesList)
                    {
                        if (Globals.EnginesList.IndexOf(engine) == self.engine_selection.SelectedIndex)
                        {
                            selected_engine = engine.Engine_Dir;
                            if (!string.IsNullOrEmpty(engine.Engine_Config))
                                selected_config = $" -config \"{engine.Engine_Config}\"";
                            break;
                        }
                    }
                }
                else
                {
                    selected_engine = "";
                }
                if (self.wad_selection?.SelectedItem != null && self.wad_selection.SelectedItem.ToString() != "(None)")
                {
                    foreach (Globals.WADListStructure wad in Globals.WADList)
                    {
                        if (wad.WAD_Name == self.wad_selection.SelectedItem.ToString())
                        {
                            selected_wad = $"{" -iwad \"" + wad.WAD_Dir + "\""}";
                            break;
                        }
                    }
                }
                else
                {
                    selected_wad = "";
                }
                if (self.mods_selection?.SelectedItem != null)
                {
                    string preselected_mod = string.Empty;
                    foreach (Globals.ModsListStructure mod in Globals.ModsList)
                    {
                        foreach (string selected_mod_item in self.mods_selection.CheckedItems)
                        {
                            if (mod.Mod_Name == selected_mod_item?.ToString())
                            {
                                preselected_mod = preselected_mod + "\"" + mod.Mod_Dir + "\" ";
                                break;
                            }
                        }
                    }
                    selected_mod = $"{" -file " + preselected_mod}";
                }

                //dufficulty and map selection
                if (self.difficulty_selection?.SelectedItem != null)
                {
                    switch (self.difficulty_selection.SelectedItem.ToString())
                    {
                        case "(Default)":
                            selected_difficulty = "";
                            break;
                        case "Very Easy":
                            selected_difficulty = " -skill 1";
                            break;
                        case "Easy":
                            selected_difficulty = " -skill 2";
                            break;
                        case "Medium":
                            selected_difficulty = " -skill 3";
                            break;
                        case "Hard":
                            selected_difficulty = " -skill 4";
                            break;
                        case "Very Hard":
                            selected_difficulty = " -skill 5";
                            break;
                        default:
                            selected_difficulty = "";
                            break;
                    }
                }
                if (self.map_selection?.SelectedItem != null)
                {
                    selected_map = BuildWarpArgument(self.map_selection.SelectedItem.ToString());
                }
                
                //online game options
                if (self.enable_multiplayer?.Checked == true)
                {
                    //select the game mode for a multiplayer game
                    if (self.multiplayer_game_mode_select?.SelectedItem != null)
                    {
                        switch (self.multiplayer_game_mode_select.SelectedItem.ToString()!)
                        {
                            case "CO_OP":
                                selected_game_mode = "";
                                break;
                            case "Deathmatch":
                                selected_game_mode = " -deathmatch";
                                break;
                            case "Alt Deathmatch":
                                selected_game_mode = " -altdeath";
                                break;
                            default:
                                selected_game_mode = "";
                                break;
                        }
                    }
                    if (self.hostname_ip_textbox?.Text != null && self.hostname_ip_textbox.Text != string.Empty)
                    {
                        host = self.hostname_ip_textbox.Text;
                    }
                    //no need to return if port is not available (it's an optional feature)
                    if (self.port_textbox?.Text != null && self.port_textbox.Text != string.Empty)
                    {
                        port = self.port_textbox.Text;
                    }
                    //select whether to host or join a game
                    if (self.players_host_select?.SelectedItem != null)
                    {
                        switch (self.players_host_select.SelectedItem.ToString()!)
                        {
                            case "Join":
                                if (port == null || port == string.Empty)
                                {
                                    selected_players = $"{" -join " + host}";
                                }
                                else if (port != null || port != string.Empty)
                                {
                                    selected_players = $"{" -join " + host + ":" + port}";
                                }
                                break;
                            case "Host 1":
                                selected_players = " -host 1";
                                break;
                            case "Host 2":
                                selected_players = " -host 2";
                                break;
                            case "Host 3":
                                selected_players = " -host 3";
                                break;
                            case "Host 4":
                                selected_players = " -host 4";
                                break;
                            case "Host 5":
                                selected_players = " -host 5";
                                break;
                            case "Host 6":
                                selected_players = " -host 6";
                                break;
                            case "Host 7":
                                selected_players = " -host 7";
                                break;
                            case "Host 8":
                                selected_players = " -host 8";
                                break;
                            case "(More)":
                                break;
                            default:
                                selected_players = "";
                                break;
                        }
                    }

                    //extra online game arguments
                    if (self.frag_limit?.Text != null && self.frag_limit.Text != string.Empty)
                    {
                        selected_frag_limit = $"{" +set fraglimit " + self.frag_limit.Text}";
                    }
                    else 
                    {
                        selected_frag_limit = "";
                    }
                    if (self.time_limit?.Text != null && self.time_limit.Text != string.Empty)
                    {
                        selected_time_limit = $"{" +set timelimit " + self.time_limit.Text}";
                    }
                    else
                    {
                        selected_time_limit = "";
                    }
                    if (self.dmflags?.Text != null && self.dmflags.Text != string.Empty)
                    {
                        selected_dmflags = $"{" +set dmflags " + self.dmflags.Text}";
                    }
                    else 
                    {
                        selected_dmflags = "";
                    }
                    if (self.dmflags2?.Text != null && self.dmflags2.Text != string.Empty)
                    {
                        selected_dmflags2 = $"{" +set dmflags2 " + self.dmflags2.Text}";
                    }
                    else
                    {
                        selected_dmflags2 = "";
                    }
                }

                //build the play command
                arguments = $"{selected_config + selected_wad + selected_difficulty + selected_map + selected_mod + selected_dmflags + selected_dmflags2 + selected_game_mode + selected_players + selected_frag_limit + selected_time_limit}";
                self.command_line_view.Text = $"{selected_engine} {arguments}";
                //load the command line to globals for launching the game
                Globals.game_launch_engine = selected_engine;
                Globals.game_launch_arguments = arguments;
                Globals.game_launch_command = $"{selected_engine} {arguments}";
            }
        }

        // Turns a dynamically-discovered level lump name (ExMy/MAPxy) into the engine's
        // -warp argument, instead of looking it up in a hardcoded table.
        private string BuildWarpArgument(string? mapName)
        {
            if (string.IsNullOrEmpty(mapName) || mapName == "(Default)")
                return string.Empty;

            Match episodeMap = Regex.Match(mapName, "^E([0-9])M([0-9])$");
            if (episodeMap.Success)
                return $" -warp {episodeMap.Groups[1].Value} {episodeMap.Groups[2].Value}";

            Match mapNumber = Regex.Match(mapName, "^MAP([0-9]{2})$");
            if (mapNumber.Success)
                return $" -warp {mapNumber.Groups[1].Value}";

            return string.Empty;
        }

        public void PlayGame(Launcher_Window self)
        {
            this.GenerateExecutable(self);
            try
            {
                ProcessStartInfo game_info = new ProcessStartInfo
                {
                    FileName = Globals.game_launch_engine,
                    Arguments = Globals.game_launch_arguments,
                    UseShellExecute = false,
                    //CreateNoWindow = false
                };
                Process.Start(game_info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to launch the game: " + ex.Message, "Launch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }

    public class Profile_Options
    {
        public void Load_Profiles(Launcher_Window self)
        {
            ConfigStore.LoadAll();

            Globals.ProfilesContainer profiles = Globals.Config.Configuration.Profiles;
            if (profiles.Entries.Count == 0)
                profiles.Entries.Add(new Globals.GameConfigStructure { Name = "Default" });

            self.profile_select.Items.Clear();
            foreach (Globals.GameConfigStructure profile in profiles.Entries)
                self.profile_select.Items.Add(profile.Name);

            // Set the selected profile based on LastSelectedProfile from config, or default to "Default"
            string profileToSelect = profiles.LastSelectedProfile;
            if (!self.profile_select.Items.Contains(profileToSelect))
            {
                profileToSelect = "Default"; // Fallback to "Default" if LastSelectedProfile is not found
            }

            Globals.SelectedProfile = profileToSelect;
            self.profile_select.SelectedItem = profileToSelect;

        }

        public void AddProfile(Launcher_Window self)
        {
            string profileName = Prompt.ShowDialog("Enter profile name:", "New Profile");
            if (!string.IsNullOrWhiteSpace(profileName))
            {
                List<Globals.GameConfigStructure> entries = Globals.Config.Configuration.Profiles.Entries;
                if (entries.Any(p => p.Name == profileName))
                {
                    MessageBox.Show("Profile already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Game_Options gameOpts = new Game_Options();
                Globals.GameConfigStructure newProfile = gameOpts.GetConfigFromUI(self);
                newProfile.Name = profileName;
                entries.Add(newProfile);
                ConfigStore.SaveAll();
                Load_Profiles(self);
                self.profile_select.SelectedItem = profileName;
            }
        }

        public void RemoveProfile(Launcher_Window self)
        {
            if (self.profile_select.SelectedItem != null)
            {
                string profileName = self.profile_select.SelectedItem.ToString() ?? string.Empty;
                if (profileName == "Default") { MessageBox.Show("Cannot remove Default profile."); return; }
                if (MessageBox.Show($"Delete profile '{profileName}'?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Globals.Config.Configuration.Profiles.Entries.RemoveAll(p => p.Name == profileName);
                    Globals.SelectedProfile = "Default";
                    ConfigStore.SaveAll();
                    Load_Profiles(self);
                }
            }
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form() { Width = 500, Height = 150, FormBorderStyle = FormBorderStyle.FixedDialog, Text = caption, StartPosition = FormStartPosition.CenterParent };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 400 };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox); prompt.Controls.Add(confirmation); prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
