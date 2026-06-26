namespace DoomLauncherProject
{
    partial class LauncherWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherWindow));
            menu_control = new TabControl();
            profiles_tab = new TabPage();
            profiles_container = new TableLayoutPanel();
            remove_profile = new Button();
            profile_select = new ListBox();
            add_profile = new Button();
            edit_profile = new Button();
            profile_details_label = new Label();
            profile_select_label = new Label();
            profile_details_textbox = new RichTextBox();
            game_options_tab = new TabPage();
            game_options_container_outer = new TableLayoutPanel();
            game_options_container_inner_1 = new TableLayoutPanel();
            dmflags2 = new TextBox();
            dmflags = new TextBox();
            dmflags_label = new Label();
            dmflags2_label = new Label();
            time_limit = new TextBox();
            time_limit_label = new Label();
            frag_limit = new TextBox();
            frag_limit_label = new Label();
            port_textbox = new TextBox();
            hostname_ip_textbox = new TextBox();
            hostname_ip_label = new Label();
            port_label = new Label();
            players_host_select = new ComboBox();
            multiplayer_game_mode_select = new ComboBox();
            game_mode_label = new Label();
            players_host_label = new Label();
            map_selection_label = new Label();
            difficulty_selection_label = new Label();
            map_selection = new ComboBox();
            enable_multiplayer = new CheckBox();
            difficulty_selection = new ComboBox();
            additional_parameters_label = new Label();
            additional_parameters_textbox = new TextBox();
            game_options_container_inner_2 = new TableLayoutPanel();
            mods_selection = new CheckedListBox();
            wad_selection = new ListBox();
            mods_selection_label = new Label();
            wad_selection_label = new Label();
            engine_selection_label = new Label();
            engine_selection = new ComboBox();
            launcher_options_tab = new TabPage();
            launcher_options_container = new TableLayoutPanel();
            wads_info = new Label();
            edit_wad_button = new Button();
            remove_wads = new Button();
            add_wads_button = new Button();
            edit_engine_button = new Button();
            remove_engines = new Button();
            add_engines = new Button();
            wads_label = new Label();
            engines_label = new Label();
            engines_info = new Label();
            engines_list = new ListBox();
            wads_list = new ListBox();
            add_mod_button = new Button();
            remove_mod_button = new Button();
            play_button = new Button();
            command_line_view = new RichTextBox();
            launcher_container = new TableLayoutPanel();
            menu_control.SuspendLayout();
            profiles_tab.SuspendLayout();
            profiles_container.SuspendLayout();
            game_options_tab.SuspendLayout();
            game_options_container_outer.SuspendLayout();
            game_options_container_inner_1.SuspendLayout();
            game_options_container_inner_2.SuspendLayout();
            launcher_options_tab.SuspendLayout();
            launcher_options_container.SuspendLayout();
            launcher_container.SuspendLayout();
            SuspendLayout();
            // 
            // menu_control
            // 
            menu_control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            launcher_container.SetColumnSpan(menu_control, 2);
            menu_control.Controls.Add(profiles_tab);
            menu_control.Controls.Add(game_options_tab);
            menu_control.Controls.Add(launcher_options_tab);
            menu_control.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menu_control.Location = new Point(4, 4);
            menu_control.Margin = new Padding(4);
            menu_control.Name = "menu_control";
            menu_control.SelectedIndex = 0;
            menu_control.Size = new Size(985, 607);
            menu_control.TabIndex = 0;
            // 
            // profiles_tab
            // 
            profiles_tab.Controls.Add(profiles_container);
            profiles_tab.Location = new Point(4, 29);
            profiles_tab.Name = "profiles_tab";
            profiles_tab.Padding = new Padding(3);
            profiles_tab.Size = new Size(977, 574);
            profiles_tab.TabIndex = 2;
            profiles_tab.Text = "Profiles";
            profiles_tab.UseVisualStyleBackColor = true;
            // 
            // profiles_container
            // 
            profiles_container.AutoSize = true;
            profiles_container.ColumnCount = 5;
            profiles_container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.0740738F));
            profiles_container.ColumnStyles.Add(new ColumnStyle());
            profiles_container.ColumnStyles.Add(new ColumnStyle());
            profiles_container.ColumnStyles.Add(new ColumnStyle());
            profiles_container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.9259262F));
            profiles_container.Controls.Add(remove_profile, 2, 0);
            profiles_container.Controls.Add(profile_select, 0, 1);
            profiles_container.Controls.Add(add_profile, 3, 0);
            profiles_container.Controls.Add(edit_profile, 1, 0);
            profiles_container.Controls.Add(profile_details_label, 4, 0);
            profiles_container.Controls.Add(profile_select_label, 0, 0);
            profiles_container.Controls.Add(profile_details_textbox, 4, 1);
            profiles_container.Dock = DockStyle.Fill;
            profiles_container.Location = new Point(3, 3);
            profiles_container.Margin = new Padding(0);
            profiles_container.Name = "profiles_container";
            profiles_container.RowCount = 2;
            profiles_container.RowStyles.Add(new RowStyle());
            profiles_container.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            profiles_container.Size = new Size(971, 568);
            profiles_container.TabIndex = 5;
            // 
            // remove_profile
            // 
            remove_profile.BackgroundImage = Properties.Resources.Red_Minus_Symbol_PNG_Image;
            remove_profile.BackgroundImageLayout = ImageLayout.Zoom;
            remove_profile.Dock = DockStyle.Fill;
            remove_profile.Location = new Point(463, 2);
            remove_profile.Margin = new Padding(2);
            remove_profile.Name = "remove_profile";
            remove_profile.Size = new Size(27, 27);
            remove_profile.TabIndex = 3;
            remove_profile.UseVisualStyleBackColor = true;
            // 
            // profile_select
            // 
            profiles_container.SetColumnSpan(profile_select, 4);
            profile_select.Dock = DockStyle.Fill;
            profile_select.FormattingEnabled = true;
            profile_select.Location = new Point(4, 35);
            profile_select.Margin = new Padding(4);
            profile_select.Name = "profile_select";
            profile_select.Size = new Size(515, 529);
            profile_select.TabIndex = 6;
            // 
            // add_profile
            // 
            add_profile.BackgroundImage = Properties.Resources.add_icon_2;
            add_profile.BackgroundImageLayout = ImageLayout.Zoom;
            add_profile.Dock = DockStyle.Fill;
            add_profile.Location = new Point(494, 2);
            add_profile.Margin = new Padding(2);
            add_profile.Name = "add_profile";
            add_profile.Size = new Size(27, 27);
            add_profile.TabIndex = 2;
            add_profile.UseVisualStyleBackColor = true;
            // 
            // edit_profile
            // 
            edit_profile.BackgroundImage = Properties.Resources._45706;
            edit_profile.BackgroundImageLayout = ImageLayout.Zoom;
            edit_profile.Dock = DockStyle.Fill;
            edit_profile.Location = new Point(432, 2);
            edit_profile.Margin = new Padding(2);
            edit_profile.Name = "edit_profile";
            edit_profile.Size = new Size(27, 27);
            edit_profile.TabIndex = 4;
            edit_profile.UseVisualStyleBackColor = true;
            // 
            // profile_details_label
            // 
            profile_details_label.AutoSize = true;
            profile_details_label.Dock = DockStyle.Fill;
            profile_details_label.Location = new Point(525, 2);
            profile_details_label.Margin = new Padding(2);
            profile_details_label.Name = "profile_details_label";
            profile_details_label.Size = new Size(444, 27);
            profile_details_label.TabIndex = 7;
            profile_details_label.Text = "Details:";
            profile_details_label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // profile_select_label
            // 
            profile_select_label.AutoSize = true;
            profile_select_label.Dock = DockStyle.Fill;
            profile_select_label.Location = new Point(2, 2);
            profile_select_label.Margin = new Padding(2);
            profile_select_label.Name = "profile_select_label";
            profile_select_label.Size = new Size(426, 27);
            profile_select_label.TabIndex = 0;
            profile_select_label.Text = "Select Profile:";
            profile_select_label.TextAlign = ContentAlignment.MiddleLeft;
            profile_select_label.Click += profile_select_label_Click;
            // 
            // profile_details_textbox
            // 
            profile_details_textbox.Dock = DockStyle.Fill;
            profile_details_textbox.Location = new Point(526, 34);
            profile_details_textbox.Name = "profile_details_textbox";
            profile_details_textbox.ReadOnly = true;
            profile_details_textbox.Size = new Size(442, 531);
            profile_details_textbox.TabIndex = 8;
            profile_details_textbox.Text = "";
            // 
            // game_options_tab
            // 
            game_options_tab.Controls.Add(game_options_container_outer);
            game_options_tab.Location = new Point(4, 29);
            game_options_tab.Margin = new Padding(4, 3, 4, 3);
            game_options_tab.Name = "game_options_tab";
            game_options_tab.Padding = new Padding(4, 3, 4, 3);
            game_options_tab.Size = new Size(977, 574);
            game_options_tab.TabIndex = 0;
            game_options_tab.Text = "Game Options";
            game_options_tab.UseVisualStyleBackColor = true;
            // 
            // game_options_container_outer
            // 
            game_options_container_outer.AutoSize = true;
            game_options_container_outer.ColumnCount = 2;
            game_options_container_outer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            game_options_container_outer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            game_options_container_outer.Controls.Add(game_options_container_inner_1, 0, 0);
            game_options_container_outer.Controls.Add(game_options_container_inner_2, 1, 0);
            game_options_container_outer.Dock = DockStyle.Fill;
            game_options_container_outer.Location = new Point(4, 3);
            game_options_container_outer.Margin = new Padding(0);
            game_options_container_outer.Name = "game_options_container_outer";
            game_options_container_outer.RowCount = 1;
            game_options_container_outer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            game_options_container_outer.Size = new Size(969, 568);
            game_options_container_outer.TabIndex = 32;
            // 
            // game_options_container_inner_1
            // 
            game_options_container_inner_1.AutoSize = true;
            game_options_container_inner_1.ColumnCount = 2;
            game_options_container_inner_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            game_options_container_inner_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            game_options_container_inner_1.Controls.Add(dmflags2, 1, 10);
            game_options_container_inner_1.Controls.Add(dmflags, 0, 10);
            game_options_container_inner_1.Controls.Add(dmflags_label, 0, 9);
            game_options_container_inner_1.Controls.Add(dmflags2_label, 1, 9);
            game_options_container_inner_1.Controls.Add(time_limit, 1, 8);
            game_options_container_inner_1.Controls.Add(time_limit_label, 1, 7);
            game_options_container_inner_1.Controls.Add(frag_limit, 0, 8);
            game_options_container_inner_1.Controls.Add(frag_limit_label, 0, 7);
            game_options_container_inner_1.Controls.Add(port_textbox, 1, 6);
            game_options_container_inner_1.Controls.Add(hostname_ip_textbox, 0, 6);
            game_options_container_inner_1.Controls.Add(hostname_ip_label, 0, 5);
            game_options_container_inner_1.Controls.Add(port_label, 1, 5);
            game_options_container_inner_1.Controls.Add(players_host_select, 1, 4);
            game_options_container_inner_1.Controls.Add(multiplayer_game_mode_select, 0, 4);
            game_options_container_inner_1.Controls.Add(game_mode_label, 0, 3);
            game_options_container_inner_1.Controls.Add(players_host_label, 1, 3);
            game_options_container_inner_1.Controls.Add(map_selection_label, 0, 0);
            game_options_container_inner_1.Controls.Add(difficulty_selection_label, 1, 0);
            game_options_container_inner_1.Controls.Add(map_selection, 0, 1);
            game_options_container_inner_1.Controls.Add(enable_multiplayer, 0, 2);
            game_options_container_inner_1.Controls.Add(difficulty_selection, 1, 1);
            game_options_container_inner_1.Controls.Add(additional_parameters_label, 0, 11);
            game_options_container_inner_1.Controls.Add(additional_parameters_textbox, 0, 12);
            game_options_container_inner_1.Dock = DockStyle.Fill;
            game_options_container_inner_1.Location = new Point(0, 0);
            game_options_container_inner_1.Margin = new Padding(0, 0, 10, 0);
            game_options_container_inner_1.Name = "game_options_container_inner_1";
            game_options_container_inner_1.RowCount = 13;
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.RowStyles.Add(new RowStyle());
            game_options_container_inner_1.Size = new Size(474, 568);
            game_options_container_inner_1.TabIndex = 0;
            // 
            // dmflags2
            // 
            dmflags2.Dock = DockStyle.Fill;
            dmflags2.Location = new Point(241, 390);
            dmflags2.Margin = new Padding(4);
            dmflags2.Name = "dmflags2";
            dmflags2.Size = new Size(229, 26);
            dmflags2.TabIndex = 27;
            dmflags2.TextChanged += dmflags2_TextChanged;
            // 
            // dmflags
            // 
            dmflags.Dock = DockStyle.Fill;
            dmflags.Location = new Point(4, 390);
            dmflags.Margin = new Padding(4);
            dmflags.Name = "dmflags";
            dmflags.Size = new Size(229, 26);
            dmflags.TabIndex = 26;
            dmflags.TextChanged += dmflags_TextChanged;
            // 
            // dmflags_label
            // 
            dmflags_label.AutoSize = true;
            dmflags_label.Dock = DockStyle.Fill;
            dmflags_label.Location = new Point(4, 364);
            dmflags_label.Margin = new Padding(4, 20, 4, 2);
            dmflags_label.Name = "dmflags_label";
            dmflags_label.Size = new Size(229, 20);
            dmflags_label.TabIndex = 29;
            dmflags_label.Text = "DMFLAGS:";
            // 
            // dmflags2_label
            // 
            dmflags2_label.AutoSize = true;
            dmflags2_label.Dock = DockStyle.Fill;
            dmflags2_label.Location = new Point(241, 364);
            dmflags2_label.Margin = new Padding(4, 20, 4, 2);
            dmflags2_label.Name = "dmflags2_label";
            dmflags2_label.Size = new Size(229, 20);
            dmflags2_label.TabIndex = 30;
            dmflags2_label.Text = "DMFLAGS2:";
            // 
            // time_limit
            // 
            time_limit.Dock = DockStyle.Fill;
            time_limit.Location = new Point(241, 314);
            time_limit.Margin = new Padding(4);
            time_limit.Name = "time_limit";
            time_limit.Size = new Size(229, 26);
            time_limit.TabIndex = 24;
            time_limit.TextChanged += time_limit_TextChanged;
            // 
            // time_limit_label
            // 
            time_limit_label.AutoSize = true;
            time_limit_label.Dock = DockStyle.Fill;
            time_limit_label.Location = new Point(241, 288);
            time_limit_label.Margin = new Padding(4, 20, 4, 2);
            time_limit_label.Name = "time_limit_label";
            time_limit_label.Size = new Size(229, 20);
            time_limit_label.TabIndex = 28;
            time_limit_label.Text = "Time limit";
            // 
            // frag_limit
            // 
            frag_limit.Dock = DockStyle.Fill;
            frag_limit.Location = new Point(4, 314);
            frag_limit.Margin = new Padding(4);
            frag_limit.Name = "frag_limit";
            frag_limit.Size = new Size(229, 26);
            frag_limit.TabIndex = 23;
            frag_limit.TextChanged += frag_limit_TextChanged;
            // 
            // frag_limit_label
            // 
            frag_limit_label.AutoSize = true;
            frag_limit_label.Dock = DockStyle.Fill;
            frag_limit_label.Location = new Point(4, 288);
            frag_limit_label.Margin = new Padding(4, 20, 4, 2);
            frag_limit_label.Name = "frag_limit_label";
            frag_limit_label.Size = new Size(229, 20);
            frag_limit_label.TabIndex = 25;
            frag_limit_label.Text = "Frag limit:";
            // 
            // port_textbox
            // 
            port_textbox.Dock = DockStyle.Fill;
            port_textbox.Location = new Point(241, 238);
            port_textbox.Margin = new Padding(4);
            port_textbox.Name = "port_textbox";
            port_textbox.Size = new Size(229, 26);
            port_textbox.TabIndex = 18;
            port_textbox.TextChanged += port_textbox_TextChanged;
            // 
            // hostname_ip_textbox
            // 
            hostname_ip_textbox.Dock = DockStyle.Fill;
            hostname_ip_textbox.Location = new Point(4, 238);
            hostname_ip_textbox.Margin = new Padding(4);
            hostname_ip_textbox.Name = "hostname_ip_textbox";
            hostname_ip_textbox.Size = new Size(229, 26);
            hostname_ip_textbox.TabIndex = 17;
            hostname_ip_textbox.TextChanged += hostname_ip_textbox_TextChanged;
            // 
            // hostname_ip_label
            // 
            hostname_ip_label.AutoSize = true;
            hostname_ip_label.Dock = DockStyle.Fill;
            hostname_ip_label.Location = new Point(4, 212);
            hostname_ip_label.Margin = new Padding(4, 20, 4, 2);
            hostname_ip_label.Name = "hostname_ip_label";
            hostname_ip_label.Size = new Size(229, 20);
            hostname_ip_label.TabIndex = 19;
            hostname_ip_label.Text = "Hostname/IP:";
            // 
            // port_label
            // 
            port_label.AutoSize = true;
            port_label.Dock = DockStyle.Fill;
            port_label.Location = new Point(241, 212);
            port_label.Margin = new Padding(4, 20, 4, 2);
            port_label.Name = "port_label";
            port_label.Size = new Size(229, 20);
            port_label.TabIndex = 20;
            port_label.Text = "Port:";
            // 
            // players_host_select
            // 
            players_host_select.Dock = DockStyle.Fill;
            players_host_select.DropDownStyle = ComboBoxStyle.DropDownList;
            players_host_select.FormattingEnabled = true;
            players_host_select.Location = new Point(241, 165);
            players_host_select.Margin = new Padding(4);
            players_host_select.Name = "players_host_select";
            players_host_select.Size = new Size(229, 28);
            players_host_select.TabIndex = 21;
            players_host_select.SelectedIndexChanged += players_host_select_SelectedIndexChanged;
            // 
            // multiplayer_game_mode_select
            // 
            multiplayer_game_mode_select.Dock = DockStyle.Fill;
            multiplayer_game_mode_select.DropDownStyle = ComboBoxStyle.DropDownList;
            multiplayer_game_mode_select.FormattingEnabled = true;
            multiplayer_game_mode_select.Location = new Point(4, 165);
            multiplayer_game_mode_select.Margin = new Padding(4);
            multiplayer_game_mode_select.Name = "multiplayer_game_mode_select";
            multiplayer_game_mode_select.Size = new Size(229, 28);
            multiplayer_game_mode_select.TabIndex = 15;
            multiplayer_game_mode_select.SelectedIndexChanged += multiplayer_game_mode_select_SelectedIndexChanged;
            // 
            // game_mode_label
            // 
            game_mode_label.AutoSize = true;
            game_mode_label.Dock = DockStyle.Fill;
            game_mode_label.Location = new Point(4, 139);
            game_mode_label.Margin = new Padding(4, 20, 4, 2);
            game_mode_label.Name = "game_mode_label";
            game_mode_label.Size = new Size(229, 20);
            game_mode_label.TabIndex = 16;
            game_mode_label.Text = "Game mode:";
            // 
            // players_host_label
            // 
            players_host_label.AutoSize = true;
            players_host_label.Dock = DockStyle.Fill;
            players_host_label.Location = new Point(241, 139);
            players_host_label.Margin = new Padding(4, 20, 4, 2);
            players_host_label.Name = "players_host_label";
            players_host_label.Size = new Size(229, 20);
            players_host_label.TabIndex = 22;
            players_host_label.Text = "Players (host/join):";
            // 
            // map_selection_label
            // 
            map_selection_label.AutoSize = true;
            map_selection_label.Dock = DockStyle.Fill;
            map_selection_label.Location = new Point(4, 20);
            map_selection_label.Margin = new Padding(4, 20, 4, 2);
            map_selection_label.Name = "map_selection_label";
            map_selection_label.Size = new Size(229, 20);
            map_selection_label.TabIndex = 7;
            map_selection_label.Text = "Map:";
            // 
            // difficulty_selection_label
            // 
            difficulty_selection_label.AutoSize = true;
            difficulty_selection_label.Dock = DockStyle.Fill;
            difficulty_selection_label.Location = new Point(241, 20);
            difficulty_selection_label.Margin = new Padding(4, 20, 4, 2);
            difficulty_selection_label.Name = "difficulty_selection_label";
            difficulty_selection_label.Size = new Size(229, 20);
            difficulty_selection_label.TabIndex = 8;
            difficulty_selection_label.Text = "Skill:";
            // 
            // map_selection
            // 
            map_selection.Dock = DockStyle.Fill;
            map_selection.DropDownStyle = ComboBoxStyle.DropDownList;
            map_selection.FormattingEnabled = true;
            map_selection.Location = new Point(4, 46);
            map_selection.Margin = new Padding(4);
            map_selection.Name = "map_selection";
            map_selection.Size = new Size(229, 28);
            map_selection.TabIndex = 5;
            map_selection.SelectedIndexChanged += map_selection_SelectedIndexChanged;
            // 
            // enable_multiplayer
            // 
            enable_multiplayer.AutoSize = true;
            enable_multiplayer.Dock = DockStyle.Fill;
            enable_multiplayer.Location = new Point(4, 93);
            enable_multiplayer.Margin = new Padding(4, 20, 4, 2);
            enable_multiplayer.Name = "enable_multiplayer";
            enable_multiplayer.Size = new Size(229, 24);
            enable_multiplayer.TabIndex = 9;
            enable_multiplayer.Text = "Multiplayer Mode";
            enable_multiplayer.UseVisualStyleBackColor = true;
            enable_multiplayer.CheckedChanged += enable_multiplayer_CheckedChanged;
            // 
            // difficulty_selection
            // 
            difficulty_selection.Dock = DockStyle.Fill;
            difficulty_selection.DropDownStyle = ComboBoxStyle.DropDownList;
            difficulty_selection.FormattingEnabled = true;
            difficulty_selection.Location = new Point(241, 46);
            difficulty_selection.Margin = new Padding(4);
            difficulty_selection.Name = "difficulty_selection";
            difficulty_selection.Size = new Size(229, 28);
            difficulty_selection.TabIndex = 6;
            difficulty_selection.SelectedIndexChanged += difficulty_selection_SelectedIndexChanged;
            // 
            // additional_parameters_label
            // 
            additional_parameters_label.AutoSize = true;
            additional_parameters_label.Location = new Point(4, 440);
            additional_parameters_label.Margin = new Padding(4, 20, 4, 2);
            additional_parameters_label.Name = "additional_parameters_label";
            additional_parameters_label.Size = new Size(168, 20);
            additional_parameters_label.TabIndex = 31;
            additional_parameters_label.Text = "Additional parameters:";
            additional_parameters_label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // additional_parameters_textbox
            // 
            game_options_container_inner_1.SetColumnSpan(additional_parameters_textbox, 2);
            additional_parameters_textbox.Dock = DockStyle.Fill;
            additional_parameters_textbox.Location = new Point(4, 466);
            additional_parameters_textbox.Margin = new Padding(4);
            additional_parameters_textbox.Name = "additional_parameters_textbox";
            additional_parameters_textbox.Size = new Size(466, 26);
            additional_parameters_textbox.TabIndex = 32;
            additional_parameters_textbox.TextChanged += additional_parameters_textbox_TextChanged;
            // 
            // game_options_container_inner_2
            // 
            game_options_container_inner_2.AutoSize = true;
            game_options_container_inner_2.ColumnCount = 2;
            game_options_container_inner_2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            game_options_container_inner_2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            game_options_container_inner_2.Controls.Add(mods_selection, 0, 3);
            game_options_container_inner_2.Controls.Add(wad_selection, 1, 3);
            game_options_container_inner_2.Controls.Add(mods_selection_label, 0, 2);
            game_options_container_inner_2.Controls.Add(wad_selection_label, 1, 2);
            game_options_container_inner_2.Controls.Add(engine_selection_label, 1, 0);
            game_options_container_inner_2.Controls.Add(engine_selection, 1, 1);
            game_options_container_inner_2.Dock = DockStyle.Fill;
            game_options_container_inner_2.Location = new Point(494, 0);
            game_options_container_inner_2.Margin = new Padding(10, 0, 0, 0);
            game_options_container_inner_2.Name = "game_options_container_inner_2";
            game_options_container_inner_2.RowCount = 4;
            game_options_container_inner_2.RowStyles.Add(new RowStyle());
            game_options_container_inner_2.RowStyles.Add(new RowStyle());
            game_options_container_inner_2.RowStyles.Add(new RowStyle());
            game_options_container_inner_2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            game_options_container_inner_2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            game_options_container_inner_2.Size = new Size(475, 568);
            game_options_container_inner_2.TabIndex = 15;
            // 
            // mods_selection
            // 
            mods_selection.Dock = DockStyle.Fill;
            mods_selection.FormattingEnabled = true;
            mods_selection.IntegralHeight = false;
            mods_selection.Location = new Point(4, 119);
            mods_selection.Margin = new Padding(4);
            mods_selection.Name = "mods_selection";
            mods_selection.Size = new Size(229, 445);
            mods_selection.TabIndex = 14;
            mods_selection.ItemCheck += mods_selection_ItemCheck;
            // 
            // wad_selection
            // 
            wad_selection.Dock = DockStyle.Fill;
            wad_selection.FormattingEnabled = true;
            wad_selection.IntegralHeight = false;
            wad_selection.Location = new Point(241, 119);
            wad_selection.Margin = new Padding(4);
            wad_selection.Name = "wad_selection";
            wad_selection.Size = new Size(230, 445);
            wad_selection.TabIndex = 2;
            wad_selection.SelectedIndexChanged += wad_selection_SelectedIndexChanged;
            // 
            // mods_selection_label
            // 
            mods_selection_label.AutoSize = true;
            mods_selection_label.Dock = DockStyle.Fill;
            mods_selection_label.Location = new Point(4, 93);
            mods_selection_label.Margin = new Padding(4, 20, 4, 2);
            mods_selection_label.Name = "mods_selection_label";
            mods_selection_label.Size = new Size(229, 20);
            mods_selection_label.TabIndex = 11;
            mods_selection_label.Text = "Select Mods:";
            mods_selection_label.Click += mods_selection_label_Click;
            // 
            // wad_selection_label
            // 
            wad_selection_label.AutoSize = true;
            wad_selection_label.Dock = DockStyle.Fill;
            wad_selection_label.Location = new Point(241, 93);
            wad_selection_label.Margin = new Padding(4, 20, 4, 2);
            wad_selection_label.Name = "wad_selection_label";
            wad_selection_label.Size = new Size(230, 20);
            wad_selection_label.TabIndex = 4;
            wad_selection_label.Text = "Select WAD:";
            // 
            // engine_selection_label
            // 
            engine_selection_label.AutoSize = true;
            engine_selection_label.Dock = DockStyle.Fill;
            engine_selection_label.Location = new Point(241, 20);
            engine_selection_label.Margin = new Padding(4, 20, 4, 2);
            engine_selection_label.Name = "engine_selection_label";
            engine_selection_label.Size = new Size(230, 20);
            engine_selection_label.TabIndex = 1;
            engine_selection_label.Text = "Select engine:";
            engine_selection_label.Click += engine_selection_label_Click;
            // 
            // engine_selection
            // 
            engine_selection.Dock = DockStyle.Fill;
            engine_selection.DropDownStyle = ComboBoxStyle.DropDownList;
            engine_selection.FormattingEnabled = true;
            engine_selection.Location = new Point(241, 46);
            engine_selection.Margin = new Padding(4);
            engine_selection.Name = "engine_selection";
            engine_selection.Size = new Size(230, 28);
            engine_selection.TabIndex = 0;
            engine_selection.SelectedIndexChanged += engine_selection_SelectedIndexChanged;
            // 
            // launcher_options_tab
            // 
            launcher_options_tab.Controls.Add(launcher_options_container);
            launcher_options_tab.Location = new Point(4, 29);
            launcher_options_tab.Margin = new Padding(4, 3, 4, 3);
            launcher_options_tab.Name = "launcher_options_tab";
            launcher_options_tab.Padding = new Padding(4, 3, 4, 3);
            launcher_options_tab.Size = new Size(977, 574);
            launcher_options_tab.TabIndex = 1;
            launcher_options_tab.Text = "Launcher Options";
            launcher_options_tab.UseVisualStyleBackColor = true;
            // 
            // launcher_options_container
            // 
            launcher_options_container.AutoSize = true;
            launcher_options_container.ColumnCount = 8;
            launcher_options_container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            launcher_options_container.ColumnStyles.Add(new ColumnStyle());
            launcher_options_container.ColumnStyles.Add(new ColumnStyle());
            launcher_options_container.ColumnStyles.Add(new ColumnStyle());
            launcher_options_container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            launcher_options_container.ColumnStyles.Add(new ColumnStyle());
            launcher_options_container.ColumnStyles.Add(new ColumnStyle());
            launcher_options_container.ColumnStyles.Add(new ColumnStyle());
            launcher_options_container.Controls.Add(wads_info, 0, 1);
            launcher_options_container.Controls.Add(edit_wad_button, 1, 0);
            launcher_options_container.Controls.Add(remove_wads, 2, 0);
            launcher_options_container.Controls.Add(add_wads_button, 3, 0);
            launcher_options_container.Controls.Add(edit_engine_button, 5, 0);
            launcher_options_container.Controls.Add(remove_engines, 6, 0);
            launcher_options_container.Controls.Add(add_engines, 7, 0);
            launcher_options_container.Controls.Add(wads_label, 0, 0);
            launcher_options_container.Controls.Add(engines_label, 4, 0);
            launcher_options_container.Controls.Add(engines_info, 4, 1);
            launcher_options_container.Controls.Add(engines_list, 4, 2);
            launcher_options_container.Controls.Add(wads_list, 0, 2);
            launcher_options_container.Dock = DockStyle.Fill;
            launcher_options_container.Location = new Point(4, 3);
            launcher_options_container.Margin = new Padding(0);
            launcher_options_container.Name = "launcher_options_container";
            launcher_options_container.RowCount = 3;
            launcher_options_container.RowStyles.Add(new RowStyle());
            launcher_options_container.RowStyles.Add(new RowStyle());
            launcher_options_container.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            launcher_options_container.Size = new Size(969, 568);
            launcher_options_container.TabIndex = 3;
            // 
            // wads_info
            // 
            wads_info.AutoSize = true;
            wads_info.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            wads_info.Location = new Point(2, 33);
            wads_info.Margin = new Padding(2);
            wads_info.Name = "wads_info";
            wads_info.Size = new Size(198, 20);
            wads_info.TabIndex = 7;
            wads_info.Text = "(.WAD | .PK3 | .ZIP | .TAR)";
            wads_info.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // edit_wad_button
            // 
            edit_wad_button.BackgroundImage = Properties.Resources._45706;
            edit_wad_button.BackgroundImageLayout = ImageLayout.Zoom;
            edit_wad_button.Dock = DockStyle.Fill;
            edit_wad_button.Location = new Point(393, 2);
            edit_wad_button.Margin = new Padding(2);
            edit_wad_button.Name = "edit_wad_button";
            edit_wad_button.Size = new Size(27, 27);
            edit_wad_button.TabIndex = 5;
            edit_wad_button.UseVisualStyleBackColor = true;
            edit_wad_button.Click += edit_wad_button_Click;
            // 
            // remove_wads
            // 
            remove_wads.BackgroundImage = Properties.Resources.Red_Minus_Symbol_PNG_Image;
            remove_wads.BackgroundImageLayout = ImageLayout.Zoom;
            remove_wads.Dock = DockStyle.Fill;
            remove_wads.Location = new Point(424, 2);
            remove_wads.Margin = new Padding(2);
            remove_wads.Name = "remove_wads";
            remove_wads.Size = new Size(27, 27);
            remove_wads.TabIndex = 4;
            remove_wads.UseVisualStyleBackColor = true;
            remove_wads.Click += remove_wads_Click;
            // 
            // add_wads_button
            // 
            add_wads_button.BackgroundImage = (Image)resources.GetObject("add_wads_button.BackgroundImage");
            add_wads_button.BackgroundImageLayout = ImageLayout.Zoom;
            add_wads_button.Dock = DockStyle.Fill;
            add_wads_button.Location = new Point(455, 2);
            add_wads_button.Margin = new Padding(2);
            add_wads_button.Name = "add_wads_button";
            add_wads_button.Size = new Size(27, 27);
            add_wads_button.TabIndex = 2;
            add_wads_button.UseVisualStyleBackColor = true;
            add_wads_button.Click += add_wads_button_Click;
            // 
            // edit_engine_button
            // 
            edit_engine_button.BackgroundImage = Properties.Resources._45706;
            edit_engine_button.BackgroundImageLayout = ImageLayout.Zoom;
            edit_engine_button.Dock = DockStyle.Fill;
            edit_engine_button.Location = new Point(877, 2);
            edit_engine_button.Margin = new Padding(2);
            edit_engine_button.Name = "edit_engine_button";
            edit_engine_button.Size = new Size(27, 27);
            edit_engine_button.TabIndex = 6;
            edit_engine_button.UseVisualStyleBackColor = true;
            edit_engine_button.Click += edit_engine_button_Click;
            // 
            // remove_engines
            // 
            remove_engines.BackgroundImage = Properties.Resources.Red_Minus_Symbol_PNG_Image;
            remove_engines.BackgroundImageLayout = ImageLayout.Zoom;
            remove_engines.Dock = DockStyle.Fill;
            remove_engines.Location = new Point(908, 2);
            remove_engines.Margin = new Padding(2);
            remove_engines.Name = "remove_engines";
            remove_engines.Size = new Size(27, 27);
            remove_engines.TabIndex = 5;
            remove_engines.UseVisualStyleBackColor = true;
            remove_engines.Click += remove_engines_Click;
            // 
            // add_engines
            // 
            add_engines.BackgroundImage = Properties.Resources.add_icon_2;
            add_engines.BackgroundImageLayout = ImageLayout.Zoom;
            add_engines.Dock = DockStyle.Fill;
            add_engines.Location = new Point(939, 2);
            add_engines.Margin = new Padding(2);
            add_engines.Name = "add_engines";
            add_engines.Size = new Size(28, 27);
            add_engines.TabIndex = 5;
            add_engines.UseVisualStyleBackColor = true;
            add_engines.Click += add_engines_Click;
            // 
            // wads_label
            // 
            wads_label.AutoSize = true;
            wads_label.Dock = DockStyle.Fill;
            wads_label.Location = new Point(2, 2);
            wads_label.Margin = new Padding(2);
            wads_label.Name = "wads_label";
            wads_label.Size = new Size(387, 27);
            wads_label.TabIndex = 1;
            wads_label.Text = "Game files:";
            wads_label.TextAlign = ContentAlignment.MiddleLeft;
            wads_label.Click += label1_Click;
            // 
            // engines_label
            // 
            engines_label.AutoSize = true;
            engines_label.Dock = DockStyle.Fill;
            engines_label.Location = new Point(486, 2);
            engines_label.Margin = new Padding(2);
            engines_label.Name = "engines_label";
            engines_label.Size = new Size(387, 27);
            engines_label.TabIndex = 3;
            engines_label.Text = "Engines:";
            engines_label.TextAlign = ContentAlignment.MiddleLeft;
            engines_label.Click += label2_Click;
            // 
            // engines_info
            // 
            engines_info.AutoSize = true;
            engines_info.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            engines_info.Location = new Point(486, 33);
            engines_info.Margin = new Padding(2);
            engines_info.Name = "engines_info";
            engines_info.Size = new Size(56, 20);
            engines_info.TabIndex = 8;
            engines_info.Text = "(.EXE)";
            engines_info.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // engines_list
            // 
            launcher_options_container.SetColumnSpan(engines_list, 4);
            engines_list.Dock = DockStyle.Fill;
            engines_list.FormattingEnabled = true;
            engines_list.HorizontalScrollbar = true;
            engines_list.IntegralHeight = false;
            engines_list.Location = new Point(488, 59);
            engines_list.Margin = new Padding(4);
            engines_list.Name = "engines_list";
            engines_list.SelectionMode = SelectionMode.MultiSimple;
            engines_list.Size = new Size(477, 505);
            engines_list.TabIndex = 4;
            engines_list.SelectedIndexChanged += engines_list_SelectedIndexChanged;
            // 
            // wads_list
            // 
            launcher_options_container.SetColumnSpan(wads_list, 4);
            wads_list.Dock = DockStyle.Fill;
            wads_list.FormattingEnabled = true;
            wads_list.HorizontalScrollbar = true;
            wads_list.IntegralHeight = false;
            wads_list.Location = new Point(4, 59);
            wads_list.Margin = new Padding(4);
            wads_list.Name = "wads_list";
            wads_list.SelectionMode = SelectionMode.MultiSimple;
            wads_list.Size = new Size(476, 505);
            wads_list.TabIndex = 3;
            // 
            // add_mod_button
            // 
            add_mod_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            add_mod_button.BackgroundImage = Properties.Resources.R;
            add_mod_button.BackgroundImageLayout = ImageLayout.Zoom;
            add_mod_button.Enabled = false;
            add_mod_button.Location = new Point(976, 204);
            add_mod_button.Margin = new Padding(4, 0, 4, 0);
            add_mod_button.Name = "add_mod_button";
            add_mod_button.Size = new Size(23, 23);
            add_mod_button.TabIndex = 12;
            add_mod_button.UseVisualStyleBackColor = true;
            add_mod_button.Visible = false;
            add_mod_button.Click += add_mod_button_Click;
            // 
            // remove_mod_button
            // 
            remove_mod_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            remove_mod_button.BackgroundImage = Properties.Resources.Red_Minus_Symbol_PNG_Image;
            remove_mod_button.BackgroundImageLayout = ImageLayout.Zoom;
            remove_mod_button.Enabled = false;
            remove_mod_button.Location = new Point(976, 227);
            remove_mod_button.Margin = new Padding(4, 0, 4, 0);
            remove_mod_button.Name = "remove_mod_button";
            remove_mod_button.Size = new Size(23, 23);
            remove_mod_button.TabIndex = 13;
            remove_mod_button.UseVisualStyleBackColor = true;
            remove_mod_button.Visible = false;
            remove_mod_button.Click += remove_mod_button_Click;
            // 
            // play_button
            // 
            play_button.Dock = DockStyle.Fill;
            play_button.FlatStyle = FlatStyle.Flat;
            play_button.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            play_button.Location = new Point(889, 619);
            play_button.Margin = new Padding(4);
            play_button.Name = "play_button";
            play_button.Size = new Size(100, 56);
            play_button.TabIndex = 1;
            play_button.Text = "&Play";
            play_button.UseVisualStyleBackColor = true;
            play_button.Click += play_button_Click;
            // 
            // command_line_view
            // 
            command_line_view.BorderStyle = BorderStyle.FixedSingle;
            command_line_view.Dock = DockStyle.Fill;
            command_line_view.Location = new Point(4, 619);
            command_line_view.Margin = new Padding(4);
            command_line_view.Name = "command_line_view";
            command_line_view.ReadOnly = true;
            command_line_view.Size = new Size(877, 56);
            command_line_view.TabIndex = 2;
            command_line_view.Text = "";
            // 
            // launcher_container
            // 
            launcher_container.AutoSize = true;
            launcher_container.ColumnCount = 2;
            launcher_container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            launcher_container.ColumnStyles.Add(new ColumnStyle());
            launcher_container.Controls.Add(menu_control, 0, 0);
            launcher_container.Controls.Add(command_line_view, 0, 1);
            launcher_container.Controls.Add(play_button, 1, 1);
            launcher_container.Dock = DockStyle.Fill;
            launcher_container.Location = new Point(0, 0);
            launcher_container.Name = "launcher_container";
            launcher_container.RowCount = 2;
            launcher_container.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            launcher_container.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            launcher_container.Size = new Size(993, 679);
            launcher_container.TabIndex = 14;
            //
            // LauncherWindow
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(993, 679);
            Controls.Add(add_mod_button);
            Controls.Add(remove_mod_button);
            Controls.Add(launcher_container);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "LauncherWindow";
            Text = "Form1";
            FormClosing += LauncherWindow_FormClosing;
            FormClosed += LauncherWindow_FormClosed;
            Click += LauncherWindow_Click;
            menu_control.ResumeLayout(false);
            profiles_tab.ResumeLayout(false);
            profiles_tab.PerformLayout();
            profiles_container.ResumeLayout(false);
            profiles_container.PerformLayout();
            game_options_tab.ResumeLayout(false);
            game_options_tab.PerformLayout();
            game_options_container_outer.ResumeLayout(false);
            game_options_container_outer.PerformLayout();
            game_options_container_inner_1.ResumeLayout(false);
            game_options_container_inner_1.PerformLayout();
            game_options_container_inner_2.ResumeLayout(false);
            game_options_container_inner_2.PerformLayout();
            launcher_options_tab.ResumeLayout(false);
            launcher_options_tab.PerformLayout();
            launcher_options_container.ResumeLayout(false);
            launcher_options_container.PerformLayout();
            launcher_container.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TabControl menu_control;
        public System.Windows.Forms.TabPage game_options_tab;
        public System.Windows.Forms.TabPage launcher_options_tab;
        public System.Windows.Forms.Button play_button;
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
        public Button edit_profile;
        public Button remove_profile;
        public Button add_profile;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel game_options_container_inner_1;
        private TableLayoutPanel game_options_container_inner_2;
        private TableLayoutPanel launcher_options_container;
        public Label wads_info;
        public Label engines_info;
        private TableLayoutPanel game_options_container_outer;
        private TableLayoutPanel profiles_container;
        public ListBox profile_select;
        public Label profile_details_label;
        public RichTextBox profile_details_textbox;
        private TableLayoutPanel launcher_container;
        private Label additional_parameters_label;
        public TextBox additional_parameters_textbox;
    }
}

