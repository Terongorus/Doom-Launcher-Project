using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Doom_Launcher_Project
{
    public class WAD_Options
    {
        public void AddWADs(Launcher_Window self)
        {
            if (File.Exists(Globals.wad_config_path))
            {
                if (string.IsNullOrEmpty(File.ReadAllText(Globals.wad_config_path)))
                {
                    Globals.WADList?.Clear();
                }
                else 
                {
                    string json = File.ReadAllText(Globals.wad_config_path);
                    Globals.WADList = JsonSerializer.Deserialize<BindingList<Globals.WADListStructure>>(json) ?? new();
                }
                
                //opens a file dialog to select WAD files
                OpenFileDialog WADFileDialog = new OpenFileDialog
                {
                    Title = "Select WAD Files",
                    Filter = "WAD Files (*.wad)|*.wad|All Files (*.*)|*.*",
                    Multiselect = true
                };
                if (WADFileDialog.ShowDialog() == DialogResult.OK && Globals.WADList != null && self.wads_list != null)
                {
                    foreach (string file in WADFileDialog.FileNames)
                    {
                        if (Globals.WADList.Any(w => w.WAD_Dir.Equals(file, StringComparison.OrdinalIgnoreCase)))
                        {
                            continue; // Skip adding this duplicate WAD
                        }
                        if (Globals.WADList.Any(w => w.WAD_Dir.Equals("", StringComparison.OrdinalIgnoreCase)) || Globals.WADList.Any(w => w.WAD_Name.Equals("", StringComparison.OrdinalIgnoreCase)))
                        {
                            Globals.WADList.RemoveAt(0);
                        }
                        Globals.WADListStructure wad_entry = new Globals.WADListStructure
                        {
                            WAD_Name = Path.GetFileNameWithoutExtension(file),
                            WAD_Dir = file
                        };
                        Globals.WADList.Add(wad_entry);
                    }
                    File.WriteAllText(Globals.wad_config_path, JsonSerializer.Serialize((Globals.WADList)));
                    MessageBox.Show("WAD/WADs added and configuration updated.", "WADs Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_WADs(self);
                }
                else
                {
                    MessageBox.Show("No WAD files were selected.", "Selection Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                Globals.WADList = new BindingList<Globals.WADListStructure>
                {
                    new Globals.WADListStructure {WAD_Name = "", WAD_Dir = ""}
                };
                File.WriteAllText(Globals.wad_config_path, JsonSerializer.Serialize(Globals.WADList));
                //MessageBox.Show("No configuration file found. A new one has been created. Please add WAD files again.", "Configuration File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Load_WADs(Launcher_Window self)
        {
            if (File.Exists(Globals.wad_config_path))
            {
                self.wads_list?.Items.Clear();
                string json = File.ReadAllText(Globals.wad_config_path);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    Globals.WADList = JsonSerializer.Deserialize<BindingList<Globals.WADListStructure>>(json) ?? new();
                    foreach (Globals.WADListStructure wad_file in Globals.WADList)
                    {
                        if (!string.IsNullOrEmpty(wad_file.WAD_Name) && !string.IsNullOrEmpty(wad_file.WAD_Dir))
                        {
                            self.wads_list?.Items.Add(wad_file.WAD_Name + " [" + wad_file.WAD_Dir + "]");
                        }
                        else
                        {
                            MessageBox.Show("One or more WAD entries in the configuration file are invalid. Please check wad_config.json.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                    Game_Options game_options = new Game_Options();
                    game_options.Load_WADsToList(self);
                }
                else
                {
                    return;
                }
            }
            else
            {
                //MessageBox.Show("No configuration file found. Please create a config.json file in the application directory.", "Configuration File Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Globals.WADList = new BindingList<Globals.WADListStructure>
                {
                    new Globals.WADListStructure {WAD_Name = "", WAD_Dir = ""}
                };
                File.WriteAllText(Globals.wad_config_path, JsonSerializer.Serialize(Globals.WADList));
            }
        }

        public void Remove_WAD(Launcher_Window self)
        {
            if (self.wads_list?.SelectedItems.Count > 0 && Globals.WADList != null)
            {
                // Batch removals and save once to disk
                var selectedIndices = self.wads_list.SelectedIndices.Cast<int>().OrderByDescending(i => i).ToList();
                foreach (int index in selectedIndices)
                {
                    self.wads_list?.Items.RemoveAt(index);
                    Globals.WADList.RemoveAt(index);
                }
                File.WriteAllText(Globals.wad_config_path, JsonSerializer.Serialize(Globals.WADList));

                Game_Options game_options = new Game_Options();
                game_options.Load_WADsToList(self);

                MessageBox.Show("Selected WAD/WADs removed and configuration updated.", "WAD/WADs Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No WAD/WADs selected to remove.", "Removal Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Edit_WAD(Launcher_Window self)
        {
            if (File.Exists(Globals.wad_config_path))
            {
                if (self.wads_list != null && self.wads_list.SelectedItems.Count <= 1)
                {
                    
                }
            }
        }
    }

    public class Engine_Options
    {
        public void AddEngines(Launcher_Window self)
        {
            if (File.Exists(Globals.engine_config_path))
            { 
                if (string.IsNullOrEmpty(File.ReadAllText(Globals.engine_config_path)))
                {
                    Globals.EnginesList?.Clear();
                }
                else 
                {
                    string json = File.ReadAllText(Globals.engine_config_path);
                    Globals.EnginesList = JsonSerializer.Deserialize<BindingList<Globals.EnginesListStructure>>(json) ?? new();
                }

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
                        if (Globals.EnginesList == null) Globals.EnginesList = new BindingList<Globals.EnginesListStructure>();

                        if (Globals.EnginesList.Any(e => e.Engine_Dir != null && e.Engine_Dir.Equals("", StringComparison.OrdinalIgnoreCase)) || 
                            Globals.EnginesList.Any(e => e.Engine_Name.Equals("", StringComparison.OrdinalIgnoreCase)) || 
                            Globals.EnginesList.Any(e => e.Engine_Nickname.Equals("", StringComparison.OrdinalIgnoreCase)))
                        {
                            Globals.EnginesList.RemoveAt(0);
                        }

                        FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(file);
                        string version = versionInfo.FileVersion?.Trim() ?? "Unknown";

                        // Normalize version: Strip leading 'g' (GZDoom) or 'v' to avoid "vg" or "vv" in the UI
                        if (version.Length > 1 && (version.StartsWith("g", StringComparison.OrdinalIgnoreCase) || version.StartsWith("v", StringComparison.OrdinalIgnoreCase)))
                        {
                            version = version.Substring(1);
                        }

                        Globals.EnginesListStructure engine_entry = new Globals.EnginesListStructure
                        {
                            Engine_Name = Path.GetFileNameWithoutExtension(file),
                            Engine_Nickname = $"{Path.GetFileNameWithoutExtension(file)} v{version}",
                            Engine_Dir = file,
                            Engine_Version = version
                        };
                        Globals.EnginesList.Add(engine_entry);
                    }
                    File.WriteAllText(Globals.engine_config_path, JsonSerializer.Serialize((Globals.EnginesList)));
                    MessageBox.Show("Engine/engines added and configuration updated.", "Engine/engines Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Engines(self);
                }
                else
                {
                    MessageBox.Show("No engine files were selected.", "Selection Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                Globals.EnginesList = new BindingList<Globals.EnginesListStructure>
                {
                    new Globals.EnginesListStructure {Engine_Name = "", Engine_Nickname = "", Engine_Dir = "", Engine_Version = ""}
                };
                File.WriteAllText(Globals.engine_config_path, JsonSerializer.Serialize(Globals.EnginesList));
                //MessageBox.Show("No configuration file found. A new one has been created. Please add engine files again.", "Configuration File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Load_Engines(Launcher_Window self)
        {
            if (File.Exists(Globals.engine_config_path))
            {
                self.engines_list?.Items.Clear();
                string json = File.ReadAllText(Globals.engine_config_path);
                Globals.EnginesList = JsonSerializer.Deserialize<BindingList<Globals.EnginesListStructure>>(json) ?? new();
                foreach (Globals.EnginesListStructure engine_file in Globals.EnginesList)
                {
                    if (!string.IsNullOrEmpty(engine_file.Engine_Name) && !string.IsNullOrEmpty(engine_file.Engine_Dir))
                    {
                        string version = engine_file.Engine_Version?.Trim() ?? "";

                        // Retroactively clean the display for existing entries that might have 'g' or 'v'
                        if (version.Length > 1 && (version.StartsWith("g", StringComparison.OrdinalIgnoreCase) || version.StartsWith("v", StringComparison.OrdinalIgnoreCase)))
                        {
                            version = version.Substring(1);
                        }

                        string displayText = engine_file.Engine_Name;
                        if (!string.IsNullOrEmpty(version))
                        {
                            displayText += " v" + version;
                        }
                        displayText += " [" + engine_file.Engine_Dir + "]";
                        self.engines_list?.Items.Add(displayText);
                    }
                    else
                    {
                        MessageBox.Show("One or more engine entries in the configuration file are invalid. Please check config.json.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
                Game_Options game_options = new Game_Options();
                game_options.Load_EnginesToList(self);
            }
            else
            {
                //MessageBox.Show("No configuration file found. Please create a config.json file in the application directory.", "Configuration File Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Globals.EnginesList = new BindingList<Globals.EnginesListStructure>
                {
                    new Globals.EnginesListStructure {Engine_Name = "", Engine_Nickname = "", Engine_Dir = "", Engine_Version = ""}
                };
                File.WriteAllText(Globals.engine_config_path, JsonSerializer.Serialize(Globals.EnginesList));
            }
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
                    File.WriteAllText(Globals.engine_config_path, JsonSerializer.Serialize((Globals.EnginesList)));
                }
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
    }

    public class Mods_Options
    {
        public void AddMods(Launcher_Window self)
        {
            if (File.Exists(Globals.mods_config_path))
            {
                string temp_name = string.Empty;
                if (string.IsNullOrEmpty(File.ReadAllText(Globals.mods_config_path)))
                {
                    Globals.ModsList?.Clear();
                }
                else
                {
                    string mods_json = File.ReadAllText(Globals.mods_config_path);
                    Globals.ModsList = JsonSerializer.Deserialize<BindingList<Globals.ModsListStructure>>(mods_json) ?? new();
                }

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
                        File.WriteAllText(Globals.mods_config_path, JsonSerializer.Serialize((Globals.ModsList)));
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
            else
            {
                Globals.ModsList = new BindingList<Globals.ModsListStructure>
                {
                    new Globals.ModsListStructure {Mod_Name = "", Mod_Dir = ""}
                };
                File.WriteAllText(Globals.mods_config_path, JsonSerializer.Serialize(Globals.ModsList));
                //MessageBox.Show("No configuration file found. A new one has been created. Please add mod files again.", "Configuration File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Load_Mods(Launcher_Window self)
        {
            if (File.Exists(Globals.mods_config_path))
            {
                self.mods_selection?.Items.Clear();
                string json = File.ReadAllText(Globals.mods_config_path);
                Globals.ModsList = JsonSerializer.Deserialize<BindingList<Globals.ModsListStructure>>(json) ?? new();
                foreach (Globals.ModsListStructure mod_file in Globals.ModsList)
                {
                    if (!string.IsNullOrEmpty(mod_file.Mod_Name))
                    {
                        self.mods_selection?.Items.Add(mod_file.Mod_Name!);
                    }
                    // If Mod_Name is empty, just skip it. No need for a MessageBox.
                }
            }
            else
            {
                Globals.ModsList = new BindingList<Globals.ModsListStructure>(); // Initialize as empty list
                File.WriteAllText(Globals.mods_config_path, JsonSerializer.Serialize(Globals.ModsList)); // Write empty list to file
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
                    File.WriteAllText(Globals.mods_config_path, JsonSerializer.Serialize((Globals.ModsList)));
                }
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

                // Clear multiplayer values from UI if the user manually disabled the mode
                if (!Globals.IsLoadingConfig)
                {
                    if (self.multiplayer_game_mode_select != null) self.multiplayer_game_mode_select.SelectedIndex = -1;
                    if (self.players_host_select != null) self.players_host_select.SelectedIndex = -1;
                    self.hostname_ip_textbox?.Clear();
                    self.port_textbox?.Clear();
                    self.frag_limit?.Clear();
                    self.time_limit?.Clear();
                    self.dmflags?.Clear();
                    self.dmflags2?.Clear();
                }
            }
        }

        public void Save_GameOptions(Launcher_Window self)
        {
            // If we are currently loading the config into the UI, do not save.
            // This prevents programmatic UI changes from overwriting the JSON with empty values.
            if (Globals.IsLoadingConfig)
                return;

            if (File.Exists(Globals.game_config_path))
            {
                Globals.Profiles.Configuration[Globals.SelectedProfile] = GetConfigFromUI(self);
                File.WriteAllText(Globals.game_config_path, JsonSerializer.Serialize(Globals.Profiles));
            }
            else
            {
                File.WriteAllText(Globals.game_config_path, string.Empty);
                MessageBox.Show("No configuration file found. A new one has been created. Please save game options again.", "Configuration File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Clear_GameOptionsUI(Launcher_Window self)
        {
            // Reset selections to defaults or -1
            if (self.engine_selection != null) self.engine_selection.SelectedIndex = -1;
            
            if (self.wad_selection != null) 
                self.wad_selection.SelectedIndex = self.wad_selection.Items.IndexOf("(None)");

            if (self.map_selection != null) self.map_selection.Items.Clear();
            if (self.difficulty_selection != null) self.difficulty_selection.SelectedIndex = -1;

            if (self.mods_selection != null)
            {
                for (int i = 0; i < self.mods_selection.Items.Count; i++)
                    self.mods_selection.SetItemChecked(i, false);
            }

            if (self.enable_multiplayer != null) self.enable_multiplayer.Checked = false;
            if (self.multiplayer_game_mode_select != null) self.multiplayer_game_mode_select.SelectedIndex = -1;
            if (self.players_host_select != null) self.players_host_select.SelectedIndex = -1;

            // Clear TextBoxes
            self.hostname_ip_textbox.Clear();
            self.port_textbox.Clear();
            if (self.frag_limit != null) self.frag_limit.Clear();
            if (self.time_limit != null) self.time_limit.Clear();
            if (self.dmflags != null) self.dmflags.Clear();
            if (self.dmflags2 != null) self.dmflags2.Clear();
        }

        public void Load_GameOptions(Launcher_Window self)
        {
            if (!File.Exists(Globals.game_config_path) || self.wad_selection.Items == null || self.engine_selection.Items == null)
                return;

            // Start the loading guard
            Globals.IsLoadingConfig = true;

            try
            {
                string game_json = File.ReadAllText(Globals.game_config_path);
                if (string.IsNullOrEmpty(game_json)) return;

                try { Globals.Profiles = JsonSerializer.Deserialize<Globals.RootConfig>(game_json) ?? new Globals.RootConfig(); }
                catch { Globals.Profiles = new Globals.RootConfig(); }

                if (File.Exists(Globals.wad_config_path))
                {
                    string wad_json = File.ReadAllText(Globals.wad_config_path);
                    Globals.WADList = JsonSerializer.Deserialize<BindingList<Globals.WADListStructure>>(wad_json) ?? new();
                }
                if (File.Exists(Globals.engine_config_path))
                {
                    string engine_json = File.ReadAllText(Globals.engine_config_path);
                    Globals.EnginesList = JsonSerializer.Deserialize<BindingList<Globals.EnginesListStructure>>(engine_json) ?? new();
                }
                if (File.Exists(Globals.mods_config_path))
                {
                    string mods_json = File.ReadAllText(Globals.mods_config_path);
                    Globals.ModsList = JsonSerializer.Deserialize<BindingList<Globals.ModsListStructure>>(mods_json) ?? new();
                }

                if (Globals.Profiles.Configuration.TryGetValue(Globals.SelectedProfile, out var config))
                {
                    // Only clear the UI if we have successfully found a profile to load.
                    // This prevents data loss if the selection change happens accidentally.
                    Clear_GameOptionsUI(self);

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
            if (File.Exists(Globals.wad_config_path))
            {
                self.wad_selection.Items.Clear();
                string temp_name = string.Empty;
                string json = File.ReadAllText(Globals.wad_config_path);
                Globals.WADList = JsonSerializer.Deserialize<BindingList<Globals.WADListStructure>>(json) ?? new();
                self.wad_selection.Items.Add("(None)");
                foreach (Globals.WADListStructure wad in Globals.WADList)
                {
                    temp_name = wad.WAD_Name ?? string.Empty;
                    self.wad_selection.Items.Add(temp_name);
                }
            }
        }

        public void Load_EnginesToList(Launcher_Window self)
        {
            if (File.Exists(Globals.engine_config_path))
            {
                self.engine_selection.Items.Clear();
                string temp_name = string.Empty;
                string json = File.ReadAllText(Globals.engine_config_path);
                Globals.EnginesList = JsonSerializer.Deserialize<BindingList<Globals.EnginesListStructure>>(json) ?? new();
                foreach (Globals.EnginesListStructure engine in Globals.EnginesList)
                {
                    temp_name = engine.Engine_Nickname ?? string.Empty;
                    self.engine_selection.Items.Add(temp_name);
                }
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
                string normalized = selectedWad.ToLowerInvariant();
                normalized = Regex.Replace(normalized, @"[^a-z0-9]", ""); // remove punctuation/space
                normalized = normalized + ".wad";
                if (Globals.match_1.Any(match => normalized.Contains(match.ToLowerInvariant())))
                {
                    if (self.map_selection != null) // Add null check for map_selection
                    {
                        self.map_selection.Items.Clear();
                        foreach (string map in Globals.doom_1_maps)
                        {
                            self.map_selection.Items.Add(map);
                        }
                        //make sure the default setting is applied for less confusion
                        self.map_selection.SelectedItem = self.map_selection.Items.IndexOf("(Default)");
                    }
                }
                else if (Globals.match_2.Any(match => normalized.Contains(match.ToLowerInvariant())))
                {
                    if (self.map_selection != null) // Add null check for map_selection
                    {
                        self.map_selection.Items.Clear();
                        foreach (string map in Globals.doom_2_maps)
                        {
                            self.map_selection.Items.Add(map);
                        }
                        //make sure the default setting is applied for less confusion
                        self.map_selection.SelectedItem = self.map_selection.Items.IndexOf("(Default)");
                    }
                }
                else
                {
                    self.map_selection.Items.Clear();
                    MessageBox.Show("No WAD match found in either database!", "No WAD match!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                self.map_selection?.Items.Clear();
                return;
            }
        }

        public void GenerateExecutable(Launcher_Window self)
        {
            if (Globals.IsLoadingConfig) return;

            if (File.Exists(Globals.engine_config_path) && File.Exists(Globals.wad_config_path))
            {
                List<string> args = new List<string>();
                string selected_engine = string.Empty;

                // multiplayer variables
                string selected_game_mode = string.Empty;
                string selected_frag_limit = string.Empty;
                string selected_time_limit = string.Empty;
                string selected_dmflags = string.Empty;
                string selected_dmflags2 = string.Empty;

                // 1. Engine Selection
                if (self.engine_selection?.SelectedIndex != -1)
                {
                    var engine = Globals.EnginesList.ElementAtOrDefault(self.engine_selection?.SelectedIndex ?? -1);
                    if (engine != null) selected_engine = engine.Engine_Dir;
                }

                // 2. IWAD Selection
                if (self.wad_selection?.SelectedItem != null && self.wad_selection.SelectedItem?.ToString() != "(None)")
                {
                    var wad = Globals.WADList.FirstOrDefault(w => w.WAD_Name == self.wad_selection?.SelectedItem?.ToString());
                    if (wad != null) args.Add($"-iwad \"{wad.WAD_Dir}\"");
                }

                // 3. Mods Selection
                if (self.mods_selection?.CheckedItems.Count > 0)
                {
                    string preselected_mod = string.Empty;
                    foreach (Globals.ModsListStructure mod in Globals.ModsList)
                    {
                        foreach (string selected_mod_item in self.mods_selection.CheckedItems)
                        {
                            if (mod.Mod_Name == selected_mod_item)
                            {
                                preselected_mod += $"\"{mod.Mod_Dir}\" ";
                                break;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(preselected_mod)) args.Add($"-file {preselected_mod.Trim()}");
                }

                // 4. Skill Level Selection
                if (self.difficulty_selection?.SelectedItem != null)
                {
                    string diff = self.difficulty_selection?.SelectedItem?.ToString() ?? string.Empty;
                    string skillArg = diff switch
                    {
                        "Very Easy" => "1",
                        "Easy" => "2",
                        "Medium" => "3",
                        "Hard" => "4",
                        "Very Hard" => "5",
                        _ => ""
                    };
                    if (!string.IsNullOrEmpty(skillArg)) args.Add($"-skill {skillArg}");
                }

                // 5. Map Selection (Dynamic Warp)
                if (self.map_selection?.SelectedItem != null)
                {
                    string map = self.map_selection?.SelectedItem?.ToString() ?? string.Empty;
                    if (map != "(Default)")
                    {
                        // Logic for E1M1 style
                        var matchE = Regex.Match(map ?? string.Empty, @"E(\d)M(\d)", RegexOptions.IgnoreCase);
                        if (matchE.Success)
                        {
                            args.Add($"-warp {matchE.Groups[1].Value} {matchE.Groups[2].Value}");
                        }
                        else
                        {
                            // Logic for MAP01 style
                            var matchM = Regex.Match(map ?? string.Empty, @"MAP(\d+)", RegexOptions.IgnoreCase);
                            if (matchM.Success) args.Add($"-warp {matchM.Groups[1].Value}");
                        }
                    }
                }

                // 6. Online game options
                if (self.enable_multiplayer?.Checked == true)
                {
                    string host = self.hostname_ip_textbox?.Text ?? string.Empty;
                    string port = self.port_textbox?.Text ?? string.Empty;

                    if (self.multiplayer_game_mode_select?.SelectedItem != null)
                    {
                        selected_game_mode = self.multiplayer_game_mode_select?.SelectedItem?.ToString() switch
                        {
                            "Deathmatch" => "-deathmatch",
                            "Alt Deathmatch" => "-altdeath",
                            _ => ""
                        };
                        if (!string.IsNullOrEmpty(selected_game_mode)) args.Add(selected_game_mode);
                    }

                    string playersStr = self.players_host_select?.SelectedItem?.ToString() ?? string.Empty;
                    if (playersStr == "Join" && !string.IsNullOrWhiteSpace(host))
                    {
                        // Join format: -join IP:Port
                        args.Add($"-join {host}{(string.IsNullOrWhiteSpace(port) ? "" : ":" + port)}");
                    }
                    else if (playersStr.StartsWith("Host "))
                    {
                        // Host format: -host <count> -port <port>
                        string playerCount = playersStr.Replace("Host ", "").Trim();
                        args.Add($"-host {playerCount}");
                        
                        if (!string.IsNullOrWhiteSpace(port))
                        {
                            args.Add($"-port {port}");
                        }
                    }

                    if (!string.IsNullOrEmpty(self.frag_limit?.Text)) args.Add($"+set fraglimit {self.frag_limit.Text}");
                    if (!string.IsNullOrEmpty(self.time_limit?.Text)) args.Add($"+set timelimit {self.time_limit.Text}");
                    if (!string.IsNullOrEmpty(self.dmflags?.Text)) args.Add($"+set dmflags {self.dmflags.Text}");
                    if (!string.IsNullOrEmpty(self.dmflags2?.Text)) args.Add($"+set dmflags2 {self.dmflags2.Text}");
                }

                string arguments = string.Join(" ", args);
                self.command_line_view.Text = $"\"{selected_engine}\" {arguments}";

                Globals.game_launch_engine = selected_engine;
                Globals.game_launch_arguments = arguments;
                Globals.game_launch_command = self.command_line_view.Text;
            }
        }

        public void PlayGame(Launcher_Window self)
        {
            GenerateExecutable(self);
            try
            {
                ProcessStartInfo game_info = new ProcessStartInfo
                {
                    FileName = Globals.game_launch_engine,
                    Arguments = Globals.game_launch_arguments,
                    UseShellExecute = false,
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
            if (File.Exists(Globals.game_config_path))
            {
                string json = File.ReadAllText(Globals.game_config_path);
                if (!string.IsNullOrEmpty(json))
                {
                    try { Globals.Profiles = JsonSerializer.Deserialize<Globals.RootConfig>(json) ?? new Globals.RootConfig(); }
                    catch { Globals.Profiles = new Globals.RootConfig(); }
                }
            }

            if (Globals.Profiles.Configuration.Count == 0)
                Globals.Profiles.Configuration["Default"] = new Globals.GameConfigStructure();

            self.profile_select.Items.Clear();
            foreach (var profile in Globals.Profiles.Configuration.Keys)
                self.profile_select.Items.Add(profile);

            // Set the selected profile based on LastSelectedProfile from config, or default to "Default"
            string profileToSelect = Globals.Profiles.LastSelectedProfile;
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
                if (Globals.Profiles.Configuration.ContainsKey(profileName))
                {
                    MessageBox.Show("Profile already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Game_Options gameOpts = new Game_Options();
                // Initialize a new empty configuration instead of pulling from the current UI
                Globals.Profiles.Configuration[profileName] = new Globals.GameConfigStructure();
                File.WriteAllText(Globals.game_config_path, JsonSerializer.Serialize(Globals.Profiles));
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
                    Globals.Profiles.Configuration.Remove(profileName);
                    File.WriteAllText(Globals.game_config_path, JsonSerializer.Serialize(Globals.Profiles));
                    Globals.SelectedProfile = "Default";
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
