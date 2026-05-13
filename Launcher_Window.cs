using System.Text.Json;

namespace Doom_Launcher_Project
{
    public partial class Launcher_Window : Form
    {
        //loads the whole frame and all the components
        public Launcher_Window()
        {
            InitializeComponent();
            Game_Options product_details = new Game_Options();
            product_details.ProductDetails(this);
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
            game_options.Load_OnlineGameplayModes(this);
            game_options.Load_PlayerSelectList(this);

            Profile_Options profile_options = new Profile_Options();
            profile_options.Load_Profiles(this);

            game_options.OnlineModeEnable(this);

            this.add_profile.Click += new System.EventHandler(this.add_profile_Click);
            this.remove_profile.Click += new System.EventHandler(this.remove_profile_Click);
            this.edit_profile.Click += new System.EventHandler(this.edit_profile_Click);
            this.profile_select.SelectedIndexChanged += new System.EventHandler(this.profile_select_SelectedIndexChanged);
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
            game_Options.Save_GameOptions(this);
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
            game_options.Save_GameOptions(this);
            game_options.GenerateExecutable(this);
        }

        private void Launcher_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Game_Options game_options = new Game_Options();
            game_options.Save_GameOptions(this);
        }

        private void Launcher_Window_Click(object sender, EventArgs e)
        {
            Game_Options game_options = new Game_Options();
            game_options.Save_GameOptions(this);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Game_Options game_options = new Game_Options();
            game_options.GenerateExecutable(this);
        }

        private void enable_multiplayer_CheckedChanged(object sender, EventArgs e)
        {
            Game_Options game_options = new Game_Options();
            game_options.OnlineModeEnable(this);
        }

        private void mods_selection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void profile_select_label_Click(object sender, EventArgs e)
        {

        }

        private void add_profile_Click(object? sender, EventArgs e)
        {
            Profile_Options profile_options = new Profile_Options();
            profile_options.AddProfile(this);
        }

        private void remove_profile_Click(object? sender, EventArgs e)
        {
            Profile_Options profile_options = new Profile_Options();
            profile_options.RemoveProfile(this);
        }

        private void edit_profile_Click(object? sender, EventArgs e)
        {
            this.menu_control.SelectedTab = this.game_options_tab;
        }

        private void profile_select_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (profile_select.SelectedItem != null)
            {
                Globals.SelectedProfile = profile_select.SelectedItem!.ToString() ?? string.Empty;
                // Update LastSelectedProfile in Globals.Profiles and save
                Globals.Profiles.LastSelectedProfile = Globals.SelectedProfile;
                File.WriteAllText(Globals.game_config_path, JsonSerializer.Serialize(Globals.Profiles));

                Game_Options game_options = new Game_Options();
                game_options.Load_GameOptions(this);
            }
        }

        private void map_selection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
