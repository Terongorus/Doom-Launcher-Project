using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doom_Launcher_Project
{
    public partial class Launcher_Window : Form
    {
        //loads the whole frame and all the components
        public Launcher_Window()
        {
            InitializeComponent();

            //loads the WADs from the config files
            WAD_Options wad_options = new WAD_Options();
            wad_options.Load_WADs(this);
            //loads the engines from the config files
            Engine_Options engine_options = new Engine_Options();
            engine_options.Load_Engines(this);
            //loads the mods from the config files
            Mods_Options mods_options = new Mods_Options();
            mods_options.Load_Mods(this);
            //loads the skill levels into the skill level dropdown menu
            Game_Options game_options = new Game_Options();
            game_options.Load_SkillLevelsToList(this);
            //loads the game options from the config file
            Game_Options game_Options = new Game_Options();
            game_Options.LoadGameOptions(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void add_wads_button_Click(object sender, EventArgs e)
        {
           WAD_Options wad_options = new WAD_Options();
           wad_options.AddWADs(this);
        }

        private void add_engines_Click(object sender, EventArgs e)
        {
            Engine_Options engine_options = new Engine_Options();
            engine_options.AddEngines(this);
        }

        private void remove_wads_Click(object sender, EventArgs e)
        {
            WAD_Options wad_options = new WAD_Options();
            wad_options.Remove_WAD(this);
        }

        private void remove_engines_Click(object sender, EventArgs e)
        {
            Engine_Options engine_options = new Engine_Options();
            engine_options.Remove_Engine(this);
        }

        private void edit_wad_button_Click(object sender, EventArgs e)
        {

        }

        private void edit_engine_button_Click(object sender, EventArgs e)
        {

        }

        private void engine_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Game_Options game_Options = new Game_Options();
            game_Options.SaveGameOptions(this);
            game_Options.GenerateExecutable(this);
        }

        private void play_button_Click(object sender, EventArgs e)
        {
            Game_Options game_options = new Game_Options();
            game_options.PlayGame(this);
        }

        private void wad_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Game_Options game_options = new Game_Options();
            game_options.Load_MapsToList(this);
            game_options.SaveGameOptions(this);
            game_options.GenerateExecutable(this);
        }

        private void Launcher_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Game_Options game_options = new Game_Options();
            game_options.SaveGameOptions(this);
        }

        private void Launcher_Window_Click(object sender, EventArgs e)
        {
            Game_Options game_options = new Game_Options();
            game_options.SaveGameOptions(this);
            game_options.GenerateExecutable(this);
        }

        private void add_mod_button_Click(object sender, EventArgs e)
        {
            Mods_Options mods_options = new Mods_Options();
            mods_options.AddMods(this);
        }

        private void remove_mod_button_Click(object sender, EventArgs e)
        {
            Mods_Options mods_options = new Mods_Options();
            mods_options.Remove_Mod(this);
        }

        private void Launcher_Window_Load(object sender, EventArgs e)
        {

        }

        private void new_selection_MouseClick(object sender, MouseEventArgs e)
        {
            Game_Options game_options = new Game_Options();
            game_options.SaveGameOptions(this);
            game_options.GenerateExecutable(this);
        }

        private void mods_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Game_Options game_options = new Game_Options();
            game_options.SaveGameOptions(this);
            game_options.GenerateExecutable(this);
        }

        private void map_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Game_Options game_options = new Game_Options();
            game_options.SaveGameOptions(this);
            game_options.GenerateExecutable(this);
        }

        private void difficulty_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Game_Options game_Options = new Game_Options();
            game_Options.SaveGameOptions(this);
            game_Options.GenerateExecutable(this);
        }
    }
}
