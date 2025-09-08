using Doom_Launcher_Project.Properties;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    Globals.WADList.Clear();
                }
                else 
                {
                    string json = File.ReadAllText(Globals.wad_config_path);
                    Globals.WADList = JsonSerializer.Deserialize<BindingList<Globals.WADListStructure>>(json);
                }
                
                //opens a file dialog to select WAD files
                OpenFileDialog WADFileDialog = new OpenFileDialog
                {
                    Title = "Select WAD Files",
                    Filter = "WAD Files (*.wad)|*.wad|All Files (*.*)|*.*",
                    Multiselect = true
                };
                if (WADFileDialog.ShowDialog() == DialogResult.OK)
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
                self.wads_list.Items.Clear();
                if (File.ReadAllText(Globals.wad_config_path) != null || File.ReadAllText(Globals.wad_config_path) != string.Empty)
                {
                    string json = File.ReadAllText(Globals.wad_config_path);
                    Globals.WADList = JsonSerializer.Deserialize<BindingList<Globals.WADListStructure>>(json);
                    foreach (Globals.WADListStructure wad_file in Globals.WADList)
                    {
                        if ((wad_file.WAD_Name != null || wad_file.WAD_Name != string.Empty) && (wad_file.WAD_Dir != null || wad_file.WAD_Dir != string.Empty))
                        {
                            self.wads_list.Items.Add(wad_file.WAD_Name + " [" + wad_file.WAD_Dir + "]");
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
            if (self.wads_list.SelectedItem != null)
            {
                while (self.wads_list.SelectedItems.Count > 0)
                {
                    int selectedIndex = self.wads_list.SelectedIndex;
                    self.wads_list.Items.RemoveAt(selectedIndex);
                    Globals.WADList.RemoveAt(selectedIndex);
                    File.WriteAllText(Globals.wad_config_path, JsonSerializer.Serialize((Globals.WADList)));
                }
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
                if (self.wads_list.SelectedItems != null && !(self.wads_list.SelectedItems.Count > 1))
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
                    Globals.EnginesList.Clear();
                }
                else 
                {
                    string json = File.ReadAllText(Globals.engine_config_path);
                    Globals.EnginesList = JsonSerializer.Deserialize<BindingList<Globals.EnginesListStructure>>(json);
                }

                //opens a file dialog to select engine files
                OpenFileDialog EngineFileDialog = new OpenFileDialog
                {
                    Title = "Select Engine Files",
                    Filter = "Engine Files (*.exe)|*.exe|All Files (*.*)|*.*",
                    Multiselect = true
                };
                if (EngineFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in EngineFileDialog.FileNames)
                    {
                        if (Globals.EnginesList.Any(e => e.Engine_Dir.Equals(file, StringComparison.OrdinalIgnoreCase)))
                        {
                            continue; // Skip adding this duplicate engine
                        }
                        if (Globals.EnginesList.Any(e => e.Engine_Dir.Equals("", StringComparison.OrdinalIgnoreCase)) || Globals.EnginesList.Any(e => e.Engine_Name.Equals("", StringComparison.OrdinalIgnoreCase)))
                        {
                            Globals.EnginesList.RemoveAt(0);
                        }
                        Globals.EnginesListStructure engine_entry = new Globals.EnginesListStructure
                        {
                            Engine_Name = Path.GetFileNameWithoutExtension(file),
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
                    new Globals.EnginesListStructure {Engine_Name = "", Engine_Dir = ""}
                };
                File.WriteAllText(Globals.engine_config_path, JsonSerializer.Serialize(Globals.EnginesList));
                //MessageBox.Show("No configuration file found. A new one has been created. Please add engine files again.", "Configuration File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Load_Engines(Launcher_Window self)
        {
            if (File.Exists(Globals.engine_config_path))
            {
                self.engines_list.Items.Clear();
                string json = File.ReadAllText(Globals.engine_config_path);
                Globals.EnginesList = JsonSerializer.Deserialize<BindingList<Globals.EnginesListStructure>>(json);
                foreach (Globals.EnginesListStructure engine_file in Globals.EnginesList)
                {
                    if ((engine_file.Engine_Name != null || engine_file.Engine_Name != string.Empty) && (engine_file.Engine_Dir != null || engine_file.Engine_Dir != string.Empty))
                    {
                        self.engines_list.Items.Add(engine_file.Engine_Name + " [" + engine_file.Engine_Dir + "]");
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
                    new Globals.EnginesListStructure {Engine_Name = "", Engine_Dir = ""}
                };
                File.WriteAllText(Globals.engine_config_path, JsonSerializer.Serialize(Globals.EnginesList));
            }
        }

        public void Remove_Engine(Launcher_Window self)
        {
            if (self.engines_list.SelectedItem != null)
            {
                while (self.engines_list.SelectedItems.Count > 0)
                {
                    int selectedIndex = self.engines_list.SelectedIndex;
                    self.engines_list.Items.RemoveAt(selectedIndex);
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
                    Globals.ModsList.Clear();
                }
                else
                {
                    string mods_json = File.ReadAllText(Globals.mods_config_path);
                    Globals.ModsList = JsonSerializer.Deserialize<BindingList<Globals.ModsListStructure>>(mods_json);
                }

                //opens a file dialog to select mod files
                OpenFileDialog ModFileDialog = new OpenFileDialog
                {
                    Title = "Select Mod Files",
                    Filter = "Mod Files (*.wad, *.pk3, *.zip, *.pk7, *.rar)|*.wad;*.pk3;*.zip;*.pk7;*.rar|All Files (*.*)|*.*",
                    Multiselect = true
                };
                if (ModFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ModFileDialog.FileNames)
                    {
                        if (Globals.ModsList.Any(m => m.Mod_Dir.Equals(file, StringComparison.OrdinalIgnoreCase)))
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
                self.mods_selection.Items.Clear();
                string json = File.ReadAllText(Globals.mods_config_path);
                Globals.ModsList = JsonSerializer.Deserialize<BindingList<Globals.ModsListStructure>>(json);
                foreach (Globals.ModsListStructure mod_file in Globals.ModsList)
                {
                    if ((mod_file.Mod_Name != null || mod_file.Mod_Name != string.Empty) && (mod_file.Mod_Dir != null || mod_file.Mod_Dir != string.Empty))
                    {
                        self.mods_selection.Items.Add(mod_file.Mod_Name);
                    }
                    else
                    {
                        MessageBox.Show("One or more mod entries in the configuration file are invalid. Please check mods_config.json.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
            else
            {
                Globals.ModsList = new BindingList<Globals.ModsListStructure>
                {
                    new Globals.ModsListStructure {Mod_Name = "", Mod_Dir = ""}
                };
                File.WriteAllText(Globals.mods_config_path, JsonSerializer.Serialize(Globals.ModsList));
                //MessageBox.Show("No configuration file found. Please create a config.json file in the application directory.", "Configuration File Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
            }
        }

        public void Remove_Mod(Launcher_Window self)
        {
            if (self.mods_selection.SelectedItem != null)
            {
                while (self.mods_selection.SelectedItems.Count > 0)
                {
                    int selectedIndex = self.mods_selection.SelectedIndex;
                    self.mods_selection.Items.RemoveAt(selectedIndex);
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
        public void OnlineModeEnable(Launcher_Window self)
        {
            if (self.enable_multiplayer.Checked == true)
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
            if (File.Exists(Globals.game_config_path))
            {
                Globals.GameConfig.Clear();
                Globals.GameConfigStructure game_config_entry = new Globals.GameConfigStructure
                {
                    Selected_Engine = self.engine_selection.SelectedItem != null ? self.engine_selection.SelectedItem.ToString() : string.Empty,
                    Selected_WAD = self.wad_selection.SelectedItem != null ? self.wad_selection.SelectedItem.ToString() : string.Empty,
                    Selected_Map = self.map_selection.SelectedItem != null ? self.map_selection.SelectedItem.ToString() : string.Empty,
                    Selected_SkillLevel = self.difficulty_selection.SelectedItem != null ? self.difficulty_selection.SelectedItem.ToString() : string.Empty,
                    Selected_Mods = self.mods_selection.CheckedItems.Count > 0 ? string.Join(";", self.mods_selection.CheckedItems.Cast<string>()) : string.Empty,
                    //online gameplay options save
                    Enable_Multiplayer = self.enable_multiplayer.Checked,
                    Selected_Game_Mode = self.multiplayer_game_mode_select.SelectedItem != null ? self.multiplayer_game_mode_select.SelectedItem.ToString() : string.Empty,
                    Selected_Players = self.players_host_select.SelectedItem != null ? self.players_host_select.SelectedItem.ToString() : string.Empty,  
                    Host = self.hostname_ip_textbox.Text != null ? self.hostname_ip_textbox.Text : string.Empty,
                    Port = self.port_textbox.Text != null ? self.port_textbox.Text : string.Empty
                };
                Globals.GameConfig.Add(game_config_entry);
                File.WriteAllText(Globals.game_config_path, JsonSerializer.Serialize((Globals.GameConfig)));
            }
            else
            {
                File.WriteAllText(Globals.game_config_path, string.Empty);
                MessageBox.Show("No configuration file found. A new one has been created. Please save game options again.", "Configuration File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Load_GameOptions(Launcher_Window self)
        {
            if (File.Exists(Globals.game_config_path) && self.wad_selection.Items != null && self.engine_selection.Items != null)
            {
                if (!string.IsNullOrEmpty(File.ReadAllText(Globals.game_config_path)) && (Globals.GameConfig != null))
                {
                    string game_json = File.ReadAllText(Globals.game_config_path);
                    string wad_json = File.ReadAllText(Globals.wad_config_path);
                    string engine_json = File.ReadAllText(Globals.engine_config_path);
                    Globals.GameConfig = JsonSerializer.Deserialize<BindingList<Globals.GameConfigStructure>>(game_json);
                    Globals.WADList = JsonSerializer.Deserialize<BindingList<Globals.WADListStructure>>(wad_json);
                    Globals.EnginesList = JsonSerializer.Deserialize<BindingList<Globals.EnginesListStructure>>(engine_json);
                    foreach (Globals.GameConfigStructure config in Globals.GameConfig.ToList())
                    {
                        foreach (Globals.WADListStructure wad in Globals.WADList)
                        {
                            if (wad.WAD_Name == config.Selected_WAD)
                            {
                                self.wad_selection.SelectedIndex = self.wad_selection.Items.IndexOf(wad.WAD_Name.ToString());
                                this.Load_MapsToList(self);
                                break;
                            }
                            else
                            {
                                self.wad_selection.SelectedIndex = -1;
                            }
                        }
                    }
                    foreach (Globals.GameConfigStructure config in Globals.GameConfig.ToList())
                    {
                        foreach (Globals.EnginesListStructure engine in Globals.EnginesList)
                        {
                            if (engine.Engine_Name == config.Selected_Engine)
                            {
                                self.engine_selection.SelectedIndex = self.engine_selection.Items.IndexOf(engine.Engine_Name.ToString());
                                break;
                            }
                            else
                            { 
                                self.engine_selection.SelectedIndex = -1;
                            }
                        }
                    }
                    foreach (Globals.GameConfigStructure config in Globals.GameConfig)
                    {
                        foreach (Globals.ModsListStructure mod in Globals.ModsList)
                        {
                            foreach (string selected_mod in config.Selected_Mods.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (mod.Mod_Name == selected_mod)
                                {
                                    self.mods_selection.SetItemChecked(self.mods_selection.Items.IndexOf(mod.Mod_Name.ToString()), true);
                                    break;
                                }
                                else
                                {
                                    self.mods_selection.SetItemChecked(self.mods_selection.Items.IndexOf(mod.Mod_Name.ToString()), false);
                                    break;
                                }
                            }
                        }
                    }
                    foreach (Globals.GameConfigStructure config in Globals.GameConfig.ToList())
                    {
                        //load online settings
                        self.enable_multiplayer.Checked = config.Enable_Multiplayer == true ? true : false;
                        self.multiplayer_game_mode_select.SelectedItem = config.Selected_Game_Mode != string.Empty ? self.multiplayer_game_mode_select.Items.IndexOf(config.Selected_Game_Mode.ToString()).ToString() : string.Empty;
                        self.players_host_select.SelectedItem = config.Selected_Players != string.Empty ? self.players_host_select.Items.IndexOf(config.Selected_Players.ToString()).ToString() : string.Empty;
                        self.hostname_ip_textbox.Text = config.Host != string.Empty ? config.Host.ToString() : string.Empty;
                        self.port_textbox.Text = config.Port != string.Empty ? config.Port.ToString() : string.Empty;

                        //map load settings
                        self.difficulty_selection.SelectedItem = config.Selected_SkillLevel != string.Empty ? config.Selected_SkillLevel.ToString() : "(Default)";
                        if (self.wad_selection.SelectedItem != null)
                        {
                            self.map_selection.SelectedItem = config.Selected_Map != string.Empty ? config.Selected_Map.ToString() : null;
                        }
                        else
                        {
                            self.map_selection.SelectedItem = null;
                        }
                    }
                }
            }
            else
            {
                File.WriteAllText(Globals.game_config_path, string.Empty);
                MessageBox.Show("No configuration file found. A new one has been created. Please save game options again.", "Configuration File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Load_WADsToList(Launcher_Window self)
        {
            if (File.Exists(Globals.wad_config_path))
            {
                self.wad_selection.Items.Clear();
                string temp_name = string.Empty;
                string json = File.ReadAllText(Globals.wad_config_path);
                Globals.WADList = JsonSerializer.Deserialize<BindingList<Globals.WADListStructure>>(json);
                foreach (Globals.WADListStructure wad in Globals.WADList)
                {
                    temp_name = wad.WAD_Name;
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
                Globals.EnginesList = JsonSerializer.Deserialize<BindingList<Globals.EnginesListStructure>>(json);
                foreach (Globals.EnginesListStructure engine in Globals.EnginesList)
                {
                    temp_name = engine.Engine_Name;
                    self.engine_selection.Items.Add(temp_name);
                }
            }
        }

        public void Load_OnlineGameplayModes(Launcher_Window self)
        {
            //populate the game mode selection
            self.multiplayer_game_mode_select.Items.Clear();
            self.multiplayer_game_mode_select.Items.Add("CO-OP");
            self.multiplayer_game_mode_select.Items.Add("Deathmatch");
            self.multiplayer_game_mode_select.Items.Add("Alt Deathmatch");
        }

        public void Load_PlayerSelectList(Launcher_Window self)
        {
            //populate the players (host/join) selection
            self.players_host_select.Items.Clear();
            self.players_host_select.Items.Add("Join");
            for (int cnt1 = 1; cnt1 < 9; cnt1++)
            {
                self.players_host_select.Items.Add("Host " + cnt1);
            }
            self.players_host_select.Items.Add("(More)");
        }

        public void Load_SkillLevelsToList(Launcher_Window self)
        {
            self.difficulty_selection.Items.Clear();
            self.difficulty_selection.Items.Add("(Default)");
            self.difficulty_selection.Items.Add("Very Easy");
            self.difficulty_selection.Items.Add("Easy");
            self.difficulty_selection.Items.Add("Medium");
            self.difficulty_selection.Items.Add("Hard");
            self.difficulty_selection.Items.Add("Very Hard");
        }

        public void Load_MapsToList(Launcher_Window self)
        {
            string match_1_json = File.ReadAllText(Globals.match);
            Globals.MATCHWADLIST1 = JsonSerializer.Deserialize<BindingList<Globals.WADMatchListStructure>>(match_1_json);

            string normalized = self.wad_selection.SelectedItem.ToString().ToLowerInvariant();
            normalized = Regex.Replace(normalized, @"[^a-z0-9]", ""); // remove punctuation/space
            normalized = normalized + ".wad";
            if (Globals.match_1.Any(match => normalized.Contains(match.ToLowerInvariant())))
            {
                self.map_selection.Items.Clear();
                foreach (string map in Globals.doom_1_maps)
                {
                    self.map_selection.Items.Add(map);
                }
            }
            else if (Globals.match_2.Any(match => normalized.Contains(match.ToLowerInvariant())))
            {
                self.map_selection.Items.Clear();
                foreach (string map in Globals.doom_2_maps)
                {
                    self.map_selection.Items.Add(map);
                }
            }
            else 
            {
                self.map_selection.Items.Clear();
                MessageBox.Show("No WAD match found in either database!", "No WAD match!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((File.ReadAllText(Globals.wad_config_path) != null || File.ReadAllText(Globals.wad_config_path) != string.Empty) && (File.ReadAllText(Globals.engine_config_path) != null || File.ReadAllText(Globals.engine_config_path) != string.Empty))
                {
                    string wad_json = File.ReadAllText(Globals.wad_config_path);
                    string engine_json = File.ReadAllText(Globals.engine_config_path);
                    Globals.WADList = JsonSerializer.Deserialize<BindingList<Globals.WADListStructure>>(wad_json);
                    Globals.EnginesList = JsonSerializer.Deserialize<BindingList<Globals.EnginesListStructure>>(engine_json);
                }
                else
                {
                    return;
                }

                //check if an engine, mods and a wads are selected
                if (self.engine_selection.SelectedItem != null)
                {
                    foreach (Globals.EnginesListStructure engine in Globals.EnginesList)
                    {
                        if (engine.Engine_Name == self.engine_selection.SelectedItem.ToString())
                        {
                            selected_engine = engine.Engine_Dir;
                            break;
                        }
                    }
                }
                if (self.wad_selection.SelectedItem != null)
                {
                    foreach (Globals.WADListStructure wad in Globals.WADList)
                    {
                        if (wad.WAD_Name == self.wad_selection.SelectedItem.ToString())
                        {
                            selected_wad = wad.WAD_Dir;
                            break;
                        }
                    }
                }
                if (self.mods_selection.SelectedItem != null)
                {
                    foreach (Globals.ModsListStructure mod in Globals.ModsList)
                    {
                        foreach (string selected_mod_item in self.mods_selection.CheckedItems)
                        {
                            if (mod.Mod_Name == selected_mod_item.ToString())
                            {
                                selected_mod = selected_mod + "\"" + mod.Mod_Dir + "\" ";
                                break;
                            }
                        }
                    }
                }

                //dufficulty and map selection
                if (self.difficulty_selection.SelectedItem != null)
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
                if (self.map_selection.SelectedItem != null)
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
                if (self.enable_multiplayer.Checked == true)
                {
                    //select the game mode for a multiplayer game
                    if (self.multiplayer_game_mode_select.SelectedItem != null)
                    {
                        switch (self.multiplayer_game_mode_select.SelectedItem.ToString())
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
                    if (self.hostname_ip_textbox.Text != null && self.hostname_ip_textbox.Text != string.Empty)
                    {
                        host = self.hostname_ip_textbox.Text;
                    }
                    //no need to return if port is not available (it's an optional feature)
                    if (self.port_textbox.Text != null && self.port_textbox.Text != string.Empty)
                    {
                        port = self.port_textbox.Text;
                    }
                    //select whether to host or join a game
                    if (self.players_host_select.SelectedItem != null)
                    {
                        switch (self.players_host_select.SelectedItem.ToString())
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
                    if (self.frag_limit.Text != null && self.frag_limit.Text != string.Empty)
                    {
                        selected_frag_limit = $"{" +set fraglimit " + self.frag_limit.Text}";
                    }
                    else 
                    {
                        selected_frag_limit = "";
                    }
                    if (self.time_limit.Text != null && self.time_limit.Text != string.Empty)
                    {
                        selected_time_limit = $"{" +set timelimit " + self.time_limit.Text}";
                    }
                    else
                    {
                        selected_time_limit = "";
                    }
                    if (self.dmflags.Text != null && self.dmflags.Text != string.Empty)
                    {
                        selected_dmflags = $"{" +set dmflags " + self.dmflags.Text}";
                    }
                    else 
                    {
                        selected_dmflags = "";
                    }
                    if (self.dmflags2.Text != null && self.dmflags2.Text != string.Empty)
                    {
                        selected_dmflags2 = $"{" +set dmflags2 " + self.dmflags2.Text}";
                    }
                    else
                    {
                        selected_dmflags2 = "";
                    }
                }

                //build the play command
                arguments = $"{"-iwad \"" + selected_wad + "\"" + selected_difficulty + selected_map + " -file " + selected_mod + selected_dmflags + selected_dmflags2 + selected_game_mode + selected_players + selected_frag_limit + selected_time_limit}";
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
}
