namespace Doom_Launcher_Project
{
    partial class Launcher_Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher_Window));
            menu_control = new TabControl();
            profiles_tab = new TabPage();
            edit_profile = new Button();
            remove_profile = new Button();
            add_profile = new Button();
            profile_select_label = new Label();
            profile_select = new ComboBox();
            game_options_tab = new TabPage();
            game_mode_label = new Label();
            multiplayer_game_mode_select = new ComboBox();
            players_host_label = new Label();
            players_host_select = new ComboBox();
            hostname_ip_label = new Label();
            hostname_ip_textbox = new TextBox();
            port_label = new Label();
            port_textbox = new TextBox();
            frag_limit_label = new Label();
            frag_limit = new TextBox();
            time_limit_label = new Label();
            time_limit = new TextBox();
            dmflags_label = new Label();
            dmflags = new TextBox();
            dmflags2_label = new Label();
            dmflags2 = new TextBox();
            enable_multiplayer = new CheckBox();
            difficulty_selection_label = new Label();
            difficulty_selection = new ComboBox();
            map_selection_label = new Label();
            map_selection = new ComboBox();
            engine_selection_label = new Label();
            engine_selection = new ComboBox();
            wad_selection_label = new Label();
            wad_selection = new ListBox();
            add_mod_button = new Button();
            remove_mod_button = new Button();
            mods_selection_label = new Label();
            mods_selection = new CheckedListBox();
            launcher_options_tab = new TabPage();
            launcher_options_container = new SplitContainer();
            wads_list = new ListBox();
            wads_panel = new Panel();
            add_wads_button = new Button();
            remove_wads = new Button();
            edit_wad_button = new Button();
            wads_label = new Label();
            engines_list = new ListBox();
            engines_panel = new Panel();
            engines_label = new Label();
            edit_engine_button = new Button();
            remove_engines = new Button();
            add_engines = new Button();
            play_button = new Button();
            command_line_view = new RichTextBox();
            menu_control.SuspendLayout();
            profiles_tab.SuspendLayout();
            game_options_tab.SuspendLayout();
            launcher_options_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)launcher_options_container).BeginInit();
            launcher_options_container.Panel1.SuspendLayout();
            launcher_options_container.Panel2.SuspendLayout();
            launcher_options_container.SuspendLayout();
            wads_panel.SuspendLayout();
            engines_panel.SuspendLayout();
            SuspendLayout();
            // 
            // menu_control
            // 
            menu_control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            menu_control.Controls.Add(profiles_tab);
            menu_control.Controls.Add(game_options_tab);
            menu_control.Controls.Add(launcher_options_tab);
            menu_control.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menu_control.Location = new Point(14, 14);
            menu_control.Margin = new Padding(4, 3, 4, 3);
            menu_control.Name = "menu_control";
            menu_control.SelectedIndex = 0;
            menu_control.Size = new Size(965, 507);
            menu_control.TabIndex = 0;
            // 
            // profiles_tab
            // 
            profiles_tab.Controls.Add(edit_profile);
            profiles_tab.Controls.Add(remove_profile);
            profiles_tab.Controls.Add(add_profile);
            profiles_tab.Controls.Add(profile_select_label);
            profiles_tab.Controls.Add(profile_select);
            profiles_tab.Location = new Point(4, 29);
            profiles_tab.Name = "profiles_tab";
            profiles_tab.Padding = new Padding(3);
            profiles_tab.Size = new Size(957, 474);
            profiles_tab.TabIndex = 2;
            profiles_tab.Text = "Profiles";
            profiles_tab.UseVisualStyleBackColor = true;
            // 
            // edit_profile
            // 
            edit_profile.AutoSize = true;
            edit_profile.Location = new Point(524, 251);
            edit_profile.Name = "edit_profile";
            edit_profile.Size = new Size(80, 30);
            edit_profile.TabIndex = 4;
            edit_profile.Text = "Edit";
            edit_profile.UseVisualStyleBackColor = true;
            // 
            // remove_profile
            // 
            remove_profile.AutoSize = true;
            remove_profile.Location = new Point(438, 251);
            remove_profile.Name = "remove_profile";
            remove_profile.Size = new Size(80, 30);
            remove_profile.TabIndex = 3;
            remove_profile.Text = "Remove";
            remove_profile.UseVisualStyleBackColor = true;
            // 
            // add_profile
            // 
            add_profile.AutoSize = true;
            add_profile.Location = new Point(352, 251);
            add_profile.Name = "add_profile";
            add_profile.Size = new Size(80, 30);
            add_profile.TabIndex = 2;
            add_profile.Text = "Add";
            add_profile.UseVisualStyleBackColor = true;
            // 
            // profile_select_label
            // 
            profile_select_label.AutoSize = true;
            profile_select_label.Location = new Point(425, 194);
            profile_select_label.Name = "profile_select_label";
            profile_select_label.Size = new Size(106, 20);
            profile_select_label.TabIndex = 0;
            profile_select_label.Text = "Select Profile:";
            profile_select_label.Click += profile_select_label_Click;
            // 
            // profile_select
            // 
            profile_select.DropDownStyle = ComboBoxStyle.DropDownList;
            profile_select.FormattingEnabled = true;
            profile_select.Location = new Point(352, 217);
            profile_select.Name = "profile_select";
            profile_select.Size = new Size(252, 28);
            profile_select.TabIndex = 1;
            // 
            // game_options_tab
            // 
            game_options_tab.Controls.Add(game_mode_label);
            game_options_tab.Controls.Add(multiplayer_game_mode_select);
            game_options_tab.Controls.Add(players_host_label);
            game_options_tab.Controls.Add(players_host_select);
            game_options_tab.Controls.Add(hostname_ip_label);
            game_options_tab.Controls.Add(hostname_ip_textbox);
            game_options_tab.Controls.Add(port_label);
            game_options_tab.Controls.Add(port_textbox);
            game_options_tab.Controls.Add(frag_limit_label);
            game_options_tab.Controls.Add(frag_limit);
            game_options_tab.Controls.Add(time_limit_label);
            game_options_tab.Controls.Add(time_limit);
            game_options_tab.Controls.Add(dmflags_label);
            game_options_tab.Controls.Add(dmflags);
            game_options_tab.Controls.Add(dmflags2_label);
            game_options_tab.Controls.Add(dmflags2);
            game_options_tab.Controls.Add(enable_multiplayer);
            game_options_tab.Controls.Add(difficulty_selection_label);
            game_options_tab.Controls.Add(difficulty_selection);
            game_options_tab.Controls.Add(map_selection_label);
            game_options_tab.Controls.Add(map_selection);
            game_options_tab.Controls.Add(engine_selection_label);
            game_options_tab.Controls.Add(engine_selection);
            game_options_tab.Controls.Add(wad_selection_label);
            game_options_tab.Controls.Add(wad_selection);
            game_options_tab.Controls.Add(add_mod_button);
            game_options_tab.Controls.Add(remove_mod_button);
            game_options_tab.Controls.Add(mods_selection_label);
            game_options_tab.Controls.Add(mods_selection);
            game_options_tab.Location = new Point(4, 29);
            game_options_tab.Margin = new Padding(4, 3, 4, 3);
            game_options_tab.Name = "game_options_tab";
            game_options_tab.Padding = new Padding(4, 3, 4, 3);
            game_options_tab.Size = new Size(957, 474);
            game_options_tab.TabIndex = 0;
            game_options_tab.Text = "Game Options";
            game_options_tab.UseVisualStyleBackColor = true;
            // 
            // game_mode_label
            // 
            game_mode_label.AutoSize = true;
            game_mode_label.Location = new Point(2, 152);
            game_mode_label.Margin = new Padding(4, 0, 4, 0);
            game_mode_label.Name = "game_mode_label";
            game_mode_label.Size = new Size(101, 20);
            game_mode_label.TabIndex = 16;
            game_mode_label.Text = "Game mode:";
            // 
            // multiplayer_game_mode_select
            // 
            multiplayer_game_mode_select.DropDownStyle = ComboBoxStyle.DropDownList;
            multiplayer_game_mode_select.FormattingEnabled = true;
            multiplayer_game_mode_select.Location = new Point(7, 179);
            multiplayer_game_mode_select.Margin = new Padding(4, 3, 4, 3);
            multiplayer_game_mode_select.Name = "multiplayer_game_mode_select";
            multiplayer_game_mode_select.Size = new Size(208, 28);
            multiplayer_game_mode_select.TabIndex = 15;
            // 
            // players_host_label
            // 
            players_host_label.AutoSize = true;
            players_host_label.Location = new Point(218, 152);
            players_host_label.Margin = new Padding(4, 0, 4, 0);
            players_host_label.Name = "players_host_label";
            players_host_label.Size = new Size(137, 20);
            players_host_label.TabIndex = 22;
            players_host_label.Text = "Players (host/join):";
            // 
            // players_host_select
            // 
            players_host_select.DropDownStyle = ComboBoxStyle.DropDownList;
            players_host_select.FormattingEnabled = true;
            players_host_select.Location = new Point(223, 179);
            players_host_select.Margin = new Padding(4, 3, 4, 3);
            players_host_select.Name = "players_host_select";
            players_host_select.Size = new Size(208, 28);
            players_host_select.TabIndex = 21;
            // 
            // hostname_ip_label
            // 
            hostname_ip_label.AutoSize = true;
            hostname_ip_label.Location = new Point(2, 225);
            hostname_ip_label.Margin = new Padding(4, 0, 4, 0);
            hostname_ip_label.Name = "hostname_ip_label";
            hostname_ip_label.Size = new Size(106, 20);
            hostname_ip_label.TabIndex = 19;
            hostname_ip_label.Text = "Hostname/IP:";
            // 
            // hostname_ip_textbox
            // 
            hostname_ip_textbox.Location = new Point(7, 252);
            hostname_ip_textbox.Margin = new Padding(4, 3, 4, 3);
            hostname_ip_textbox.Name = "hostname_ip_textbox";
            hostname_ip_textbox.Size = new Size(208, 26);
            hostname_ip_textbox.TabIndex = 17;
            // 
            // port_label
            // 
            port_label.AutoSize = true;
            port_label.Location = new Point(218, 225);
            port_label.Margin = new Padding(4, 0, 4, 0);
            port_label.Name = "port_label";
            port_label.Size = new Size(42, 20);
            port_label.TabIndex = 20;
            port_label.Text = "Port:";
            // 
            // port_textbox
            // 
            port_textbox.Location = new Point(223, 252);
            port_textbox.Margin = new Padding(4, 3, 4, 3);
            port_textbox.Name = "port_textbox";
            port_textbox.Size = new Size(208, 26);
            port_textbox.TabIndex = 18;
            // 
            // frag_limit_label
            // 
            frag_limit_label.AutoSize = true;
            frag_limit_label.Location = new Point(2, 298);
            frag_limit_label.Margin = new Padding(4, 0, 4, 0);
            frag_limit_label.Name = "frag_limit_label";
            frag_limit_label.Size = new Size(77, 20);
            frag_limit_label.TabIndex = 25;
            frag_limit_label.Text = "Frag limit:";
            // 
            // frag_limit
            // 
            frag_limit.Location = new Point(7, 324);
            frag_limit.Margin = new Padding(4, 3, 4, 3);
            frag_limit.Name = "frag_limit";
            frag_limit.Size = new Size(208, 26);
            frag_limit.TabIndex = 23;
            // 
            // time_limit_label
            // 
            time_limit_label.AutoSize = true;
            time_limit_label.Location = new Point(218, 298);
            time_limit_label.Margin = new Padding(4, 0, 4, 0);
            time_limit_label.Name = "time_limit_label";
            time_limit_label.Size = new Size(74, 20);
            time_limit_label.TabIndex = 28;
            time_limit_label.Text = "Time limit";
            // 
            // time_limit
            // 
            time_limit.Location = new Point(223, 324);
            time_limit.Margin = new Padding(4, 3, 4, 3);
            time_limit.Name = "time_limit";
            time_limit.Size = new Size(208, 26);
            time_limit.TabIndex = 24;
            // 
            // dmflags_label
            // 
            dmflags_label.AutoSize = true;
            dmflags_label.Location = new Point(2, 370);
            dmflags_label.Margin = new Padding(4, 0, 4, 0);
            dmflags_label.Name = "dmflags_label";
            dmflags_label.Size = new Size(92, 20);
            dmflags_label.TabIndex = 29;
            dmflags_label.Text = "DMFLAGS:";
            // 
            // dmflags
            // 
            dmflags.Location = new Point(7, 397);
            dmflags.Margin = new Padding(4, 3, 4, 3);
            dmflags.Name = "dmflags";
            dmflags.Size = new Size(208, 26);
            dmflags.TabIndex = 26;
            // 
            // dmflags2_label
            // 
            dmflags2_label.AutoSize = true;
            dmflags2_label.Location = new Point(218, 370);
            dmflags2_label.Margin = new Padding(4, 0, 4, 0);
            dmflags2_label.Name = "dmflags2_label";
            dmflags2_label.Size = new Size(101, 20);
            dmflags2_label.TabIndex = 30;
            dmflags2_label.Text = "DMFLAGS2:";
            // 
            // dmflags2
            // 
            dmflags2.Location = new Point(223, 397);
            dmflags2.Margin = new Padding(4, 3, 4, 3);
            dmflags2.Name = "dmflags2";
            dmflags2.Size = new Size(208, 26);
            dmflags2.TabIndex = 27;
            // 
            // enable_multiplayer
            // 
            enable_multiplayer.AutoSize = true;
            enable_multiplayer.Location = new Point(7, 98);
            enable_multiplayer.Margin = new Padding(4, 3, 4, 3);
            enable_multiplayer.Name = "enable_multiplayer";
            enable_multiplayer.Size = new Size(147, 24);
            enable_multiplayer.TabIndex = 9;
            enable_multiplayer.Text = "Multiplayer Mode";
            enable_multiplayer.UseVisualStyleBackColor = true;
            enable_multiplayer.CheckedChanged += enable_multiplayer_CheckedChanged;
            // 
            // difficulty_selection_label
            // 
            difficulty_selection_label.AutoSize = true;
            difficulty_selection_label.Location = new Point(190, 10);
            difficulty_selection_label.Margin = new Padding(4, 0, 4, 0);
            difficulty_selection_label.Name = "difficulty_selection_label";
            difficulty_selection_label.Size = new Size(41, 20);
            difficulty_selection_label.TabIndex = 8;
            difficulty_selection_label.Text = "Skill:";
            // 
            // difficulty_selection
            // 
            difficulty_selection.DropDownStyle = ComboBoxStyle.DropDownList;
            difficulty_selection.FormattingEnabled = true;
            difficulty_selection.Location = new Point(195, 37);
            difficulty_selection.Margin = new Padding(23, 3, 4, 3);
            difficulty_selection.Name = "difficulty_selection";
            difficulty_selection.Size = new Size(140, 28);
            difficulty_selection.TabIndex = 6;
            // 
            // map_selection_label
            // 
            map_selection_label.AutoSize = true;
            map_selection_label.Location = new Point(2, 10);
            map_selection_label.Margin = new Padding(4, 0, 4, 0);
            map_selection_label.Name = "map_selection_label";
            map_selection_label.Size = new Size(44, 20);
            map_selection_label.TabIndex = 7;
            map_selection_label.Text = "Map:";
            // 
            // map_selection
            // 
            map_selection.DropDownStyle = ComboBoxStyle.DropDownList;
            map_selection.FormattingEnabled = true;
            map_selection.Location = new Point(7, 37);
            map_selection.Margin = new Padding(4, 3, 23, 3);
            map_selection.Name = "map_selection";
            map_selection.Size = new Size(140, 28);
            map_selection.TabIndex = 5;
            map_selection.SelectedIndexChanged += map_selection_SelectedIndexChanged;
            // 
            // engine_selection_label
            // 
            engine_selection_label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            engine_selection_label.AutoSize = true;
            engine_selection_label.Location = new Point(722, 10);
            engine_selection_label.Margin = new Padding(4, 3, 4, 3);
            engine_selection_label.Name = "engine_selection_label";
            engine_selection_label.Size = new Size(110, 20);
            engine_selection_label.TabIndex = 1;
            engine_selection_label.Text = "Select engine:";
            // 
            // engine_selection
            // 
            engine_selection.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            engine_selection.DropDownStyle = ComboBoxStyle.DropDownList;
            engine_selection.FormattingEnabled = true;
            engine_selection.Location = new Point(727, 37);
            engine_selection.Margin = new Padding(4, 3, 4, 3);
            engine_selection.Name = "engine_selection";
            engine_selection.Size = new Size(221, 28);
            engine_selection.TabIndex = 0;
            engine_selection.SelectedIndexChanged += engine_selection_SelectedIndexChanged;
            // 
            // wad_selection_label
            // 
            wad_selection_label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            wad_selection_label.AutoSize = true;
            wad_selection_label.Location = new Point(722, 96);
            wad_selection_label.Margin = new Padding(4, 0, 4, 0);
            wad_selection_label.Name = "wad_selection_label";
            wad_selection_label.Size = new Size(100, 20);
            wad_selection_label.TabIndex = 4;
            wad_selection_label.Text = "Select WAD:";
            // 
            // wad_selection
            // 
            wad_selection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            wad_selection.FormattingEnabled = true;
            wad_selection.IntegralHeight = false;
            wad_selection.Location = new Point(727, 122);
            wad_selection.Margin = new Padding(4, 3, 4, 3);
            wad_selection.Name = "wad_selection";
            wad_selection.Size = new Size(221, 337);
            wad_selection.TabIndex = 2;
            wad_selection.SelectedIndexChanged += wad_selection_SelectedIndexChanged;
            // 
            // add_mod_button
            // 
            add_mod_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            add_mod_button.BackgroundImage = Properties.Resources.R;
            add_mod_button.BackgroundImageLayout = ImageLayout.Zoom;
            add_mod_button.Location = new Point(696, 99);
            add_mod_button.Margin = new Padding(4, 0, 4, 0);
            add_mod_button.Name = "add_mod_button";
            add_mod_button.Size = new Size(23, 23);
            add_mod_button.TabIndex = 12;
            add_mod_button.UseVisualStyleBackColor = true;
            add_mod_button.Click += add_mod_button_Click;
            // 
            // remove_mod_button
            // 
            remove_mod_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            remove_mod_button.BackgroundImage = Properties.Resources.Red_Minus_Symbol_PNG_Image;
            remove_mod_button.BackgroundImageLayout = ImageLayout.Zoom;
            remove_mod_button.Location = new Point(666, 99);
            remove_mod_button.Margin = new Padding(4, 0, 4, 0);
            remove_mod_button.Name = "remove_mod_button";
            remove_mod_button.Size = new Size(23, 23);
            remove_mod_button.TabIndex = 13;
            remove_mod_button.UseVisualStyleBackColor = true;
            remove_mod_button.Click += remove_mod_button_Click;
            // 
            // mods_selection_label
            // 
            mods_selection_label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            mods_selection_label.AutoSize = true;
            mods_selection_label.Location = new Point(493, 96);
            mods_selection_label.Margin = new Padding(4, 0, 4, 0);
            mods_selection_label.Name = "mods_selection_label";
            mods_selection_label.Size = new Size(101, 20);
            mods_selection_label.TabIndex = 11;
            mods_selection_label.Text = "Select mods:";
            // 
            // mods_selection
            // 
            mods_selection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            mods_selection.FormattingEnabled = true;
            mods_selection.IntegralHeight = false;
            mods_selection.Location = new Point(498, 122);
            mods_selection.Margin = new Padding(4, 3, 4, 3);
            mods_selection.Name = "mods_selection";
            mods_selection.Size = new Size(221, 337);
            mods_selection.TabIndex = 14;
            mods_selection.SelectedIndexChanged += mods_selection_SelectedIndexChanged;
            // 
            // launcher_options_tab
            // 
            launcher_options_tab.Controls.Add(launcher_options_container);
            launcher_options_tab.Location = new Point(4, 29);
            launcher_options_tab.Margin = new Padding(4, 3, 4, 3);
            launcher_options_tab.Name = "launcher_options_tab";
            launcher_options_tab.Padding = new Padding(4, 3, 4, 3);
            launcher_options_tab.Size = new Size(957, 474);
            launcher_options_tab.TabIndex = 1;
            launcher_options_tab.Text = "Launcher Options";
            launcher_options_tab.UseVisualStyleBackColor = true;
            // 
            // launcher_options_container
            // 
            launcher_options_container.Dock = DockStyle.Fill;
            launcher_options_container.Location = new Point(4, 3);
            launcher_options_container.Margin = new Padding(5, 3, 5, 3);
            launcher_options_container.Name = "launcher_options_container";
            // 
            // launcher_options_container.Panel1
            // 
            launcher_options_container.Panel1.Controls.Add(wads_list);
            launcher_options_container.Panel1.Controls.Add(wads_panel);
            // 
            // launcher_options_container.Panel2
            // 
            launcher_options_container.Panel2.Controls.Add(engines_list);
            launcher_options_container.Panel2.Controls.Add(engines_panel);
            launcher_options_container.Size = new Size(949, 468);
            launcher_options_container.SplitterDistance = 476;
            launcher_options_container.SplitterWidth = 6;
            launcher_options_container.TabIndex = 2;
            // 
            // wads_list
            // 
            wads_list.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wads_list.FormattingEnabled = true;
            wads_list.HorizontalScrollbar = true;
            wads_list.IntegralHeight = false;
            wads_list.Location = new Point(0, 60);
            wads_list.Margin = new Padding(0, 40, 0, 0);
            wads_list.Name = "wads_list";
            wads_list.SelectionMode = SelectionMode.MultiSimple;
            wads_list.Size = new Size(475, 407);
            wads_list.TabIndex = 3;
            // 
            // wads_panel
            // 
            wads_panel.Controls.Add(add_wads_button);
            wads_panel.Controls.Add(remove_wads);
            wads_panel.Controls.Add(edit_wad_button);
            wads_panel.Controls.Add(wads_label);
            wads_panel.Dock = DockStyle.Top;
            wads_panel.Location = new Point(0, 0);
            wads_panel.Name = "wads_panel";
            wads_panel.Size = new Size(476, 57);
            wads_panel.TabIndex = 6;
            // 
            // add_wads_button
            // 
            add_wads_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            add_wads_button.BackgroundImage = Properties.Resources.R;
            add_wads_button.BackgroundImageLayout = ImageLayout.Zoom;
            add_wads_button.Location = new Point(439, 10);
            add_wads_button.Margin = new Padding(10);
            add_wads_button.Name = "add_wads_button";
            add_wads_button.Size = new Size(27, 27);
            add_wads_button.TabIndex = 2;
            add_wads_button.UseVisualStyleBackColor = true;
            add_wads_button.Click += add_wads_button_Click;
            // 
            // remove_wads
            // 
            remove_wads.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            remove_wads.BackgroundImage = Properties.Resources.Red_Minus_Symbol_PNG_Image;
            remove_wads.BackgroundImageLayout = ImageLayout.Zoom;
            remove_wads.Location = new Point(392, 10);
            remove_wads.Margin = new Padding(10);
            remove_wads.Name = "remove_wads";
            remove_wads.Size = new Size(27, 27);
            remove_wads.TabIndex = 4;
            remove_wads.UseVisualStyleBackColor = true;
            remove_wads.Click += remove_wads_Click;
            // 
            // edit_wad_button
            // 
            edit_wad_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            edit_wad_button.BackgroundImage = Properties.Resources._45706;
            edit_wad_button.BackgroundImageLayout = ImageLayout.Zoom;
            edit_wad_button.Location = new Point(345, 10);
            edit_wad_button.Margin = new Padding(10);
            edit_wad_button.Name = "edit_wad_button";
            edit_wad_button.Size = new Size(27, 27);
            edit_wad_button.TabIndex = 5;
            edit_wad_button.UseVisualStyleBackColor = true;
            edit_wad_button.Click += edit_wad_button_Click;
            // 
            // wads_label
            // 
            wads_label.AutoSize = true;
            wads_label.Location = new Point(5, 10);
            wads_label.Margin = new Padding(5, 0, 5, 0);
            wads_label.Name = "wads_label";
            wads_label.Size = new Size(83, 20);
            wads_label.TabIndex = 1;
            wads_label.Text = "WAD files:";
            wads_label.Click += label1_Click;
            // 
            // engines_list
            // 
            engines_list.Dock = DockStyle.Fill;
            engines_list.FormattingEnabled = true;
            engines_list.HorizontalScrollbar = true;
            engines_list.IntegralHeight = false;
            engines_list.Location = new Point(0, 57);
            engines_list.Margin = new Padding(0, 40, 0, 0);
            engines_list.Name = "engines_list";
            engines_list.SelectionMode = SelectionMode.MultiSimple;
            engines_list.Size = new Size(467, 411);
            engines_list.TabIndex = 4;
            // 
            // engines_panel
            // 
            engines_panel.Controls.Add(engines_label);
            engines_panel.Controls.Add(edit_engine_button);
            engines_panel.Controls.Add(remove_engines);
            engines_panel.Controls.Add(add_engines);
            engines_panel.Dock = DockStyle.Top;
            engines_panel.Location = new Point(0, 0);
            engines_panel.Name = "engines_panel";
            engines_panel.Size = new Size(467, 57);
            engines_panel.TabIndex = 7;
            // 
            // engines_label
            // 
            engines_label.AutoSize = true;
            engines_label.Location = new Point(8, 10);
            engines_label.Margin = new Padding(8, 0, 5, 0);
            engines_label.Name = "engines_label";
            engines_label.Size = new Size(71, 20);
            engines_label.TabIndex = 3;
            engines_label.Text = "Engines:";
            engines_label.Click += label2_Click;
            // 
            // edit_engine_button
            // 
            edit_engine_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            edit_engine_button.BackgroundImage = Properties.Resources._45706;
            edit_engine_button.BackgroundImageLayout = ImageLayout.Zoom;
            edit_engine_button.Location = new Point(336, 10);
            edit_engine_button.Margin = new Padding(10);
            edit_engine_button.Name = "edit_engine_button";
            edit_engine_button.Size = new Size(27, 27);
            edit_engine_button.TabIndex = 6;
            edit_engine_button.UseVisualStyleBackColor = true;
            edit_engine_button.Click += edit_engine_button_Click;
            // 
            // remove_engines
            // 
            remove_engines.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            remove_engines.BackgroundImage = Properties.Resources.Red_Minus_Symbol_PNG_Image;
            remove_engines.BackgroundImageLayout = ImageLayout.Zoom;
            remove_engines.Location = new Point(383, 10);
            remove_engines.Margin = new Padding(10);
            remove_engines.Name = "remove_engines";
            remove_engines.Size = new Size(27, 27);
            remove_engines.TabIndex = 5;
            remove_engines.UseVisualStyleBackColor = true;
            remove_engines.Click += remove_engines_Click;
            // 
            // add_engines
            // 
            add_engines.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            add_engines.BackgroundImage = Properties.Resources.R;
            add_engines.BackgroundImageLayout = ImageLayout.Zoom;
            add_engines.Location = new Point(430, 10);
            add_engines.Margin = new Padding(10);
            add_engines.Name = "add_engines";
            add_engines.Size = new Size(27, 27);
            add_engines.TabIndex = 5;
            add_engines.UseVisualStyleBackColor = true;
            add_engines.Click += add_engines_Click;
            // 
            // play_button
            // 
            play_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            play_button.Location = new Point(891, 527);
            play_button.Margin = new Padding(4, 3, 4, 3);
            play_button.Name = "play_button";
            play_button.Size = new Size(88, 58);
            play_button.TabIndex = 1;
            play_button.Text = "Play";
            play_button.UseVisualStyleBackColor = true;
            play_button.Click += play_button_Click;
            // 
            // command_line_view
            // 
            command_line_view.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            command_line_view.Location = new Point(14, 528);
            command_line_view.Margin = new Padding(4, 3, 4, 3);
            command_line_view.Name = "command_line_view";
            command_line_view.ReadOnly = true;
            command_line_view.Size = new Size(870, 56);
            command_line_view.TabIndex = 2;
            command_line_view.Text = "";
            // 
            // Launcher_Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 599);
            Controls.Add(command_line_view);
            Controls.Add(play_button);
            Controls.Add(menu_control);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Launcher_Window";
            Text = "Form1";
            FormClosed += Launcher_Window_FormClosed;
            Click += Launcher_Window_Click;
            menu_control.ResumeLayout(false);
            profiles_tab.ResumeLayout(false);
            profiles_tab.PerformLayout();
            game_options_tab.ResumeLayout(false);
            game_options_tab.PerformLayout();
            launcher_options_tab.ResumeLayout(false);
            launcher_options_container.Panel1.ResumeLayout(false);
            launcher_options_container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)launcher_options_container).EndInit();
            launcher_options_container.ResumeLayout(false);
            wads_panel.ResumeLayout(false);
            wads_panel.PerformLayout();
            engines_panel.ResumeLayout(false);
            engines_panel.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl menu_control;
        public System.Windows.Forms.TabPage game_options_tab;
        public System.Windows.Forms.TabPage launcher_options_tab;
        public System.Windows.Forms.Button play_button;
        public System.Windows.Forms.SplitContainer launcher_options_container;
        public System.Windows.Forms.Label wads_label;
        public System.Windows.Forms.Label engines_label;
        public System.Windows.Forms.Button add_wads_button;
        public System.Windows.Forms.ListBox wads_list;
        public System.Windows.Forms.ListBox engines_list;
        public System.Windows.Forms.Button add_engines;
        public System.Windows.Forms.Button remove_wads;
        public System.Windows.Forms.Button remove_engines;
        public System.Windows.Forms.Button edit_wad_button;
        public System.Windows.Forms.Button edit_engine_button;
        public System.Windows.Forms.Label engine_selection_label;
        public System.Windows.Forms.ComboBox engine_selection;
        public System.Windows.Forms.Label wad_selection_label;
        public System.Windows.Forms.ListBox wad_selection;
        public System.Windows.Forms.ComboBox difficulty_selection;
        public System.Windows.Forms.ComboBox map_selection;
        public System.Windows.Forms.Label difficulty_selection_label;
        public System.Windows.Forms.Label map_selection_label;
        public System.Windows.Forms.RichTextBox command_line_view;
        public System.Windows.Forms.CheckBox enable_multiplayer;
        public System.Windows.Forms.Label mods_selection_label;
        public System.Windows.Forms.Button add_mod_button;
        public System.Windows.Forms.Button remove_mod_button;
        public System.Windows.Forms.CheckedListBox mods_selection;
        public System.Windows.Forms.Label hostname_ip_label;
        public System.Windows.Forms.Label game_mode_label;
        public System.Windows.Forms.ComboBox multiplayer_game_mode_select;
        public System.Windows.Forms.TextBox hostname_ip_textbox;
        public System.Windows.Forms.TextBox port_textbox;
        public System.Windows.Forms.Label port_label;
        public System.Windows.Forms.Label players_host_label;
        public System.Windows.Forms.ComboBox players_host_select;
        public System.Windows.Forms.TextBox frag_limit;
        public System.Windows.Forms.Label frag_limit_label;
        public System.Windows.Forms.Label time_limit_label;
        public System.Windows.Forms.TextBox time_limit;
        public System.Windows.Forms.Label dmflags_label;
        public System.Windows.Forms.TextBox dmflags;
        public System.Windows.Forms.Label dmflags2_label;
        public System.Windows.Forms.TextBox dmflags2;
        public TabPage profiles_tab;
        public Label profile_select_label;
        public ComboBox profile_select;
        public Button edit_profile;
        public Button remove_profile;
        public Button add_profile;
        private Panel engines_panel;
        private Panel wads_panel;
    }
}

