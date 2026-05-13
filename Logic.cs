using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.ApplicationServices;
using System.Reflection;

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
                        if (Globals.EnginesList.Any(e => e.Engine_Dir.Equals("", StringComparison.OrdinalIgnoreCase)) || Globals.EnginesList.Any(e => e.Engine_Name.Equals("", StringComparison.OrdinalIgnoreCase)) || Globals.EnginesList.Any(e => e.Engine_Nickname.Equals("", StringComparison.OrdinalIgnoreCase)))
                        {
                            Globals.EnginesList.RemoveAt(0);
                        }
                        Globals.EnginesListStructure engine_entry = new Globals.EnginesListStructure
                        {
                            Engine_Name = Path.GetFileNameWithoutExtension(file),
                            Engine_Nickname = Path.GetDirectoryName(file) ?? string.Empty,
                            Engine_Dir = file
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
                    new Globals.EnginesListStructure {Engine_Name = "", Engine_Nickname = "", Engine_Dir = ""}
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
                        self.engines_list?.Items.Add(engine_file.Engine_Name + " [" + engine_file.Engine_Dir + "]");
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
                    new Globals.EnginesListStructure {Engine_Name = "", Engine_Nickname = "", Engine_Dir = ""}
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
            if (File.Exists(Globals.engine_config_path) && File.Exists(Globals.wad_config_path))
            {
                //command line to launch the game
                string arguments = string.Empty;

                //game arguments
                string selected_engine = string.Empty;
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

                //reload the lists from the config files
                string wad_json = File.ReadAllText(Globals.wad_config_path);
                string engine_json = File.ReadAllText(Globals.engine_config_path);

                if (!string.IsNullOrWhiteSpace(wad_json) && !string.IsNullOrWhiteSpace(engine_json))
                {
                    Globals.WADList = JsonSerializer.Deserialize<BindingList<Globals.WADListStructure>>(wad_json) ?? new();
                    Globals.EnginesList = JsonSerializer.Deserialize<BindingList<Globals.EnginesListStructure>>(engine_json) ?? new();
                }
                else
                {
                    return;
                }
                if (Globals.EnginesList == null || Globals.WADList == null) return;
                //check if an engine, mods and a wads are selected
                if (self.engine_selection?.SelectedItem != null)
                {
                    foreach (Globals.EnginesListStructure engine in Globals.EnginesList)
                    {
                        //string selection = self.engine_selection.Items.IndexOf(self.engine_selection.SelectedItem).ToString();
                        if (Globals.EnginesList.IndexOf(engine) == self.engine_selection.SelectedIndex)
                        {
                            selected_engine = engine.Engine_Dir;
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
                    switch (self.map_selection.SelectedItem.ToString())
                    {
                        case "(Default)":
                            selected_map = "";
                            break;
                        case "E1M1":
                            selected_map = " -warp 1 1";
                            break;
                        case "E1M2":
                            selected_map = " -warp 1 2";
                            break;
                        case "E1M3":
                            selected_map = " -warp 1 3";
                            break;
                        case "E1M4":
                            selected_map = " -warp 1 4";
                            break;
                        case "E1M5":
                            selected_map = " -warp 1 5";
                            break;
                        case "E1M6":
                            selected_map = " -warp 1 6";
                            break;
                        case "E1M7":
                            selected_map = " -warp 1 7";
                            break;
                        case "E1M8":
                            selected_map = " -warp 1 8";
                            break;
                        case "E1M9":
                            selected_map = " -warp 1 9";
                            break;
                        case "E2M1":
                            selected_map = " -warp 2 1";
                            break;
                        case "E2M2":
                            selected_map = " -warp 2 2";
                            break;
                        case "E2M3":
                            selected_map = " -warp 2 3";
                            break;
                        case "E2M4":
                            selected_map = " -warp 2 4";
                            break;
                        case "E2M5":
                            selected_map = " -warp 2 5";
                            break;
                        case "E2M6":
                            selected_map = " -warp 2 6";
                            break;
                        case "E2M7":
                            selected_map = " -warp 2 7";
                            break;
                        case "E2M8":
                            selected_map = " -warp 2 8";
                            break;
                        case "E2M9":
                            selected_map = " -warp 2 9";
                            break;
                        case "E3M1":
                            selected_map = " -warp 3 1";
                            break;
                        case "E3M2":
                            selected_map = " -warp 3 2";
                            break;
                        case "E3M3":
                            selected_map = " -warp 3 3";
                            break;
                        case "E3M4":
                            selected_map = " -warp 3 4";
                            break;
                        case "E3M5":
                            selected_map = " -warp 3 5";
                            break;
                        case "E3M6":
                            selected_map = " -warp 3 6";
                            break;
                        case "E3M7":
                            selected_map = " -warp 3 7";
                            break;
                        case "E3M8":
                            selected_map = " -warp 3 8";
                            break;
                        case "E3M9":
                            selected_map = " -warp 3 9";
                            break;
                        case "E4M1":
                            selected_map = " -warp 4 1";
                            break;
                        case "E4M2":
                            selected_map = " -warp 4 2";
                            break;
                        case "E4M3":
                            selected_map = " -warp 4 3";
                            break;
                        case "E4M4":
                            selected_map = " -warp 4 4";
                            break;
                        case "E4M5":
                            selected_map = " -warp 4 5";
                            break;
                        case "E4M6":
                            selected_map = " -warp 4 6";
                            break;
                        case "E4M7":
                            selected_map = " -warp 4 7";
                            break;
                        case "E4M8":
                            selected_map = " -warp 4 8";
                            break;
                        case "E4M9":
                            selected_map = " -warp 4 9";
                            break;
                        case "MAP01":
                            selected_map = " -warp 01";
                            break;
                        case "MAP02":
                            selected_map = " -warp 02";
                            break;
                        case "MAP03":
                            selected_map = " -warp 03";
                            break;
                        case "MAP04":
                            selected_map = " -warp 04";
                            break;
                        case "MAP05":
                            selected_map = " -warp 05";
                            break;
                        case "MAP06":
                            selected_map = " -warp 06";
                            break;
                        case "MAP07":
                            selected_map = " -warp 07";
                            break;
                        case "MAP08":
                            selected_map = " -warp 08";
                            break;
                        case "MAP09":
                            selected_map = " -warp 09";
                            break;
                        case "MAP10":
                            selected_map = " -warp 10";
                            break;
                        case "MAP11":
                            selected_map = " -warp 11";
                            break;
                        case "MAP12":
                            selected_map = " -warp 12";
                            break;
                        case "MAP13":
                            selected_map = " -warp 13";
                            break;
                        case "MAP14":
                            selected_map = " -warp 14";
                            break;
                        case "MAP15":
                            selected_map = " -warp 15";
                            break;
                        case "MAP16":
                            selected_map = " -warp 16";
                            break;
                        case "MAP17":
                            selected_map = " -warp 17";
                            break;
                        case "MAP18":
                            selected_map = " -warp 18";
                            break;
                        case "MAP19":
                            selected_map = " -warp 19";
                            break;
                        case "MAP20":
                            selected_map = " -warp 20";
                            break;
                        case "MAP21":
                            selected_map = " -warp 21";
                            break;
                        case "MAP22":
                            selected_map = " -warp 22";
                            break;
                        case "MAP23":
                            selected_map = " -warp 23";
                            break;
                        case "MAP24":
                            selected_map = " -warp 24";
                            break;
                        case "MAP25":
                            selected_map = " -warp 25";
                            break;
                        case "MAP26":
                            selected_map = " -warp 26";
                            break;
                        case "MAP27":
                            selected_map = " -warp 27";
                            break;
                        case "MAP28":
                            selected_map = " -warp 28";
                            break;
                        case "MAP29":
                            selected_map = " -warp 29";
                            break;
                        case "MAP30":
                            selected_map = " -warp 30";
                            break;
                        case "MAP31":
                            selected_map = " -warp 31";
                            break;
                        case "MAP32":
                            selected_map = " -warp 32";
                            break;
                        case "MAP33":
                            selected_map = " -warp 33";
                            break;
                        case "MAP34":
                            selected_map = " -warp 34";
                            break;
                        case "MAP35":
                            selected_map = " -warp 35";
                            break;
                        case "MAP36":
                            selected_map = " -warp 36";
                            break;
                        case "MAP37":
                            selected_map = " -warp 37";
                            break;
                        case "MAP38":
                            selected_map = " -warp 38";
                            break;
                        case "MAP39":
                            selected_map = " -warp 39";
                            break;
                        case "MAP40":
                            selected_map = " -warp 40";
                            break;
                        default:
                            self.map_selection.SelectedIndex = self.map_selection.Items.IndexOf("(Default)");
                            break;
                    }
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
                arguments = $"{selected_wad + selected_difficulty + selected_map + selected_mod + selected_dmflags + selected_dmflags2 + selected_game_mode + selected_players + selected_frag_limit + selected_time_limit}";
                self.command_line_view.Text = $"{selected_engine} {arguments}";
                //load the command line to globals for launching the game
                Globals.game_launch_engine = selected_engine;
                Globals.game_launch_arguments = arguments;
                Globals.game_launch_command = $"{selected_engine} {arguments}";
            }
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
                Globals.Profiles.Configuration[profileName] = gameOpts.GetConfigFromUI(self);
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
