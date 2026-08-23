using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TeronDoomLauncher
{
    public partial class LauncherWindow : Window
    {
        //loads the whole frame and all the components
        public LauncherWindow()
        {
            InitializeComponent();
            //restores the saved window position/size before the form is first shown
            WindowOptions window_options = new WindowOptions();
            window_options.LoadWindowSettings(this);

            GameOptions product_details = new GameOptions();
            product_details.ProductDetails(this);
            //loads the WADs from the config files
            WADOptions wad_options = new WADOptions();
            wad_options.Load_WADs(this);
            //loads the engines from the config files
            EngineOptions engine_options = new EngineOptions();
            engine_options.Load_Engines(this);
            //loads the mods from the config files
            ModsOptions mods_options = new ModsOptions();
            mods_options.Load_Mods(this);
            //loads the skill levels into the skill level dropdown menu
            GameOptions game_options = new GameOptions();
            game_options.Load_SkillLevelsToList(this);
            game_options.Load_OnlineGameplayModes(this);
            game_options.Load_PlayerSelectList(this);

            ProfileOptions profile_options = new ProfileOptions();
            profile_options.Load_Profiles(this);

            game_options.Load_GameOptions(this);
            game_options.OnlineModeEnable(this);
            game_options.GenerateExecutable(this);
        }

        private void add_wads_button_Click(object sender, RoutedEventArgs e)
        {
            WADOptions wad_options = new WADOptions();
            wad_options.AddWADs(this);
        }

        private void add_engines_Click(object sender, RoutedEventArgs e)
        {
            EngineOptions engine_options = new EngineOptions();
            engine_options.AddEngines(this);
        }

        private void remove_wads_Click(object sender, RoutedEventArgs e)
        {
            WADOptions wad_options = new WADOptions();
            wad_options.Remove_WAD(this);
        }

        private void remove_engines_Click(object sender, RoutedEventArgs e)
        {
            EngineOptions engine_options = new EngineOptions();
            engine_options.Remove_Engine(this);
        }

        private void edit_wad_button_Click(object sender, RoutedEventArgs e)
        {
            WADOptions wad_options = new WADOptions();
            wad_options.Edit_WAD(this);
        }

        private void edit_engine_button_Click(object sender, RoutedEventArgs e)
        {
            EngineOptions engine_options = new EngineOptions();
            engine_options.Edit_Engine(this);
        }

        private void SyncConfig()
        {
            GameOptions game_options = new GameOptions();
            game_options.Save_GameOptions(this);
            game_options.GenerateExecutable(this);

            ProfileOptions profile_options = new ProfileOptions();
            profile_options.UpdateProfileDetails(this);
        }

        private void engine_selection_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            SyncConfig();
        }

        private void play_button_Click(object sender, RoutedEventArgs e)
        {
            GameOptions game_options = new GameOptions();
            game_options.PlayGame(this);
        }

        private void wad_selection_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            GameOptions game_options = new GameOptions();
            game_options.Load_MapsToList(this);
            SyncConfig();
        }

        private void LauncherWindow_FormClosed(object? sender, System.EventArgs e)
        {
            GameOptions game_options = new GameOptions();
            game_options.Save_GameOptions(this);
        }

        private void LauncherWindow_FormClosing(object? sender, CancelEventArgs e)
        {
            // Capture bounds before the window actually closes/minimizes, since
            // RestoreBounds/WindowState are no longer reliable once the handle is torn down.
            WindowOptions window_options = new WindowOptions();
            window_options.SaveWindowSettings(this);
        }

        private void add_mod_button_Click(object sender, RoutedEventArgs e)
        {
            ModsOptions mods_options = new ModsOptions();
            mods_options.AddMods(this);
        }

        private void remove_mod_button_Click(object sender, RoutedEventArgs e)
        {
            ModsOptions mods_options = new ModsOptions();
            mods_options.Remove_Mod(this);
        }

        private void enable_multiplayer_CheckedChanged(object sender, RoutedEventArgs e)
        {
            GameOptions game_options = new GameOptions();
            game_options.OnlineModeEnable(this);
            SyncConfig();
        }

        // WPF's CheckBox.Checked/Unchecked already fire AFTER the bound IsChecked property has
        // committed (unlike WinForms' ItemCheck, which fires before commit and needed a
        // BeginInvoke-deferred sync) - safe to sync directly here.
        private void mods_selection_ItemCheck(object sender, RoutedEventArgs e)
        {
            if (!Globals.IsLoadingConfig)
                SyncConfig();
        }

        private void add_profile_Click(object? sender, RoutedEventArgs e)
        {
            ProfileOptions profile_options = new ProfileOptions();
            profile_options.AddProfile(this);
        }

        private void remove_profile_Click(object? sender, RoutedEventArgs e)
        {
            ProfileOptions profile_options = new ProfileOptions();
            profile_options.RemoveProfile(this);
        }

        private void edit_profile_Click(object? sender, RoutedEventArgs e)
        {
            this.menu_control.SelectedItem = this.game_options_tab;
        }

        private void profile_select_SelectedIndexChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (profile_select.SelectedItem != null)
            {
                Globals.SelectedProfile = profile_select.SelectedItem!.ToString() ?? string.Empty;
                // Update LastSelectedProfile in Globals.Config and save
                Globals.Config.Configuration.Profiles.LastSelectedProfile = Globals.SelectedProfile;
                ConfigStore.SaveAll();

                GameOptions game_options = new GameOptions();
                game_options.Load_GameOptions(this);
                SyncConfig();
            }
        }

        private void profile_select_MouseDoubleClick(object? sender, MouseButtonEventArgs e)
        {
            // Only act on an actual double-click that landed on a profile row, not on
            // empty list space below the last entry.
            if (e.ClickCount != 2)
                return;

            if (!IsDescendantOfListBoxItem(e.OriginalSource as DependencyObject))
                return;

            GameOptions game_options = new GameOptions();
            game_options.PlayGame(this);
        }

        private static bool IsDescendantOfListBoxItem(DependencyObject? source)
        {
            while (source != null)
            {
                if (source is ListBoxItem)
                    return true;
                source = VisualTreeHelper.GetParent(source);
            }
            return false;
        }

        private void map_selection_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            SyncConfig();
        }

        private void engines_list_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void difficulty_selection_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            SyncConfig();
        }

        private void multiplayer_game_mode_select_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            SyncConfig();
        }

        private void players_host_select_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            SyncConfig();
        }

        private void hostname_ip_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SyncConfig();
        }

        private void port_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SyncConfig();
        }

        private void frag_limit_TextChanged(object sender, TextChangedEventArgs e)
        {
            SyncConfig();
        }

        private void time_limit_TextChanged(object sender, TextChangedEventArgs e)
        {
            SyncConfig();
        }

        private void dmflags_TextChanged(object sender, TextChangedEventArgs e)
        {
            SyncConfig();
        }

        private void dmflags2_TextChanged(object sender, TextChangedEventArgs e)
        {
            SyncConfig();
        }

        private void additional_parameters_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SyncConfig();
        }
    }
}
