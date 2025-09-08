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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher_Window));
            this.menu_control = new System.Windows.Forms.TabControl();
            this.game_options_tab = new System.Windows.Forms.TabPage();
            this.game_mode_label = new System.Windows.Forms.Label();
            this.multiplayer_game_mode_select = new System.Windows.Forms.ComboBox();
            this.players_host_label = new System.Windows.Forms.Label();
            this.players_host_select = new System.Windows.Forms.ComboBox();
            this.hostname_ip_label = new System.Windows.Forms.Label();
            this.hostname_ip_textbox = new System.Windows.Forms.TextBox();
            this.port_label = new System.Windows.Forms.Label();
            this.port_textbox = new System.Windows.Forms.TextBox();
            this.frag_limit_label = new System.Windows.Forms.Label();
            this.frag_limit = new System.Windows.Forms.TextBox();
            this.time_limit_label = new System.Windows.Forms.Label();
            this.time_limit = new System.Windows.Forms.TextBox();
            this.dmflags_label = new System.Windows.Forms.Label();
            this.dmflags = new System.Windows.Forms.TextBox();
            this.dmflags2_label = new System.Windows.Forms.Label();
            this.dmflags2 = new System.Windows.Forms.TextBox();
            this.enable_multiplayer = new System.Windows.Forms.CheckBox();
            this.difficulty_selection_label = new System.Windows.Forms.Label();
            this.difficulty_selection = new System.Windows.Forms.ComboBox();
            this.map_selection_label = new System.Windows.Forms.Label();
            this.map_selection = new System.Windows.Forms.ComboBox();
            this.engine_selection_label = new System.Windows.Forms.Label();
            this.engine_selection = new System.Windows.Forms.ComboBox();
            this.wad_selection_label = new System.Windows.Forms.Label();
            this.wad_selection = new System.Windows.Forms.ListBox();
            this.add_mod_button = new System.Windows.Forms.Button();
            this.remove_mod_button = new System.Windows.Forms.Button();
            this.mods_selection_label = new System.Windows.Forms.Label();
            this.mods_selection = new System.Windows.Forms.CheckedListBox();
            this.launcher_options_tab = new System.Windows.Forms.TabPage();
            this.launcher_options_container = new System.Windows.Forms.SplitContainer();
            this.add_wads_button = new System.Windows.Forms.Button();
            this.remove_wads = new System.Windows.Forms.Button();
            this.edit_wad_button = new System.Windows.Forms.Button();
            this.wads_label = new System.Windows.Forms.Label();
            this.wads_list = new System.Windows.Forms.ListBox();
            this.add_engines = new System.Windows.Forms.Button();
            this.remove_engines = new System.Windows.Forms.Button();
            this.edit_engine_button = new System.Windows.Forms.Button();
            this.engines_label = new System.Windows.Forms.Label();
            this.engines_list = new System.Windows.Forms.ListBox();
            this.play_button = new System.Windows.Forms.Button();
            this.command_line_view = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menu_control.SuspendLayout();
            this.game_options_tab.SuspendLayout();
            this.launcher_options_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.launcher_options_container)).BeginInit();
            this.launcher_options_container.Panel1.SuspendLayout();
            this.launcher_options_container.Panel2.SuspendLayout();
            this.launcher_options_container.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_control
            // 
            this.menu_control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menu_control.Controls.Add(this.game_options_tab);
            this.menu_control.Controls.Add(this.launcher_options_tab);
            this.menu_control.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_control.Location = new System.Drawing.Point(12, 12);
            this.menu_control.Name = "menu_control";
            this.menu_control.SelectedIndex = 0;
            this.menu_control.Size = new System.Drawing.Size(827, 439);
            this.menu_control.TabIndex = 0;
            // 
            // game_options_tab
            // 
            this.game_options_tab.Controls.Add(this.game_mode_label);
            this.game_options_tab.Controls.Add(this.multiplayer_game_mode_select);
            this.game_options_tab.Controls.Add(this.players_host_label);
            this.game_options_tab.Controls.Add(this.players_host_select);
            this.game_options_tab.Controls.Add(this.hostname_ip_label);
            this.game_options_tab.Controls.Add(this.hostname_ip_textbox);
            this.game_options_tab.Controls.Add(this.port_label);
            this.game_options_tab.Controls.Add(this.port_textbox);
            this.game_options_tab.Controls.Add(this.frag_limit_label);
            this.game_options_tab.Controls.Add(this.frag_limit);
            this.game_options_tab.Controls.Add(this.time_limit_label);
            this.game_options_tab.Controls.Add(this.time_limit);
            this.game_options_tab.Controls.Add(this.dmflags_label);
            this.game_options_tab.Controls.Add(this.dmflags);
            this.game_options_tab.Controls.Add(this.dmflags2_label);
            this.game_options_tab.Controls.Add(this.dmflags2);
            this.game_options_tab.Controls.Add(this.enable_multiplayer);
            this.game_options_tab.Controls.Add(this.difficulty_selection_label);
            this.game_options_tab.Controls.Add(this.difficulty_selection);
            this.game_options_tab.Controls.Add(this.map_selection_label);
            this.game_options_tab.Controls.Add(this.map_selection);
            this.game_options_tab.Controls.Add(this.engine_selection_label);
            this.game_options_tab.Controls.Add(this.engine_selection);
            this.game_options_tab.Controls.Add(this.wad_selection_label);
            this.game_options_tab.Controls.Add(this.wad_selection);
            this.game_options_tab.Controls.Add(this.add_mod_button);
            this.game_options_tab.Controls.Add(this.remove_mod_button);
            this.game_options_tab.Controls.Add(this.mods_selection_label);
            this.game_options_tab.Controls.Add(this.mods_selection);
            this.game_options_tab.Location = new System.Drawing.Point(4, 29);
            this.game_options_tab.Name = "game_options_tab";
            this.game_options_tab.Padding = new System.Windows.Forms.Padding(3);
            this.game_options_tab.Size = new System.Drawing.Size(819, 406);
            this.game_options_tab.TabIndex = 0;
            this.game_options_tab.Text = "Game Options";
            this.game_options_tab.UseVisualStyleBackColor = true;
            // 
            // game_mode_label
            // 
            this.game_mode_label.AutoSize = true;
            this.game_mode_label.Location = new System.Drawing.Point(2, 132);
            this.game_mode_label.Name = "game_mode_label";
            this.game_mode_label.Size = new System.Drawing.Size(101, 20);
            this.game_mode_label.TabIndex = 16;
            this.game_mode_label.Text = "Game mode:";
            // 
            // multiplayer_game_mode_select
            // 
            this.multiplayer_game_mode_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.multiplayer_game_mode_select.FormattingEnabled = true;
            this.multiplayer_game_mode_select.Location = new System.Drawing.Point(6, 155);
            this.multiplayer_game_mode_select.Name = "multiplayer_game_mode_select";
            this.multiplayer_game_mode_select.Size = new System.Drawing.Size(179, 28);
            this.multiplayer_game_mode_select.TabIndex = 15;
            // 
            // players_host_label
            // 
            this.players_host_label.AutoSize = true;
            this.players_host_label.Location = new System.Drawing.Point(187, 132);
            this.players_host_label.Name = "players_host_label";
            this.players_host_label.Size = new System.Drawing.Size(137, 20);
            this.players_host_label.TabIndex = 22;
            this.players_host_label.Text = "Players (host/join):";
            // 
            // players_host_select
            // 
            this.players_host_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.players_host_select.FormattingEnabled = true;
            this.players_host_select.Location = new System.Drawing.Point(191, 155);
            this.players_host_select.Name = "players_host_select";
            this.players_host_select.Size = new System.Drawing.Size(179, 28);
            this.players_host_select.TabIndex = 21;
            // 
            // hostname_ip_label
            // 
            this.hostname_ip_label.AutoSize = true;
            this.hostname_ip_label.Location = new System.Drawing.Point(2, 195);
            this.hostname_ip_label.Name = "hostname_ip_label";
            this.hostname_ip_label.Size = new System.Drawing.Size(106, 20);
            this.hostname_ip_label.TabIndex = 19;
            this.hostname_ip_label.Text = "Hostname/IP:";
            // 
            // hostname_ip_textbox
            // 
            this.hostname_ip_textbox.Location = new System.Drawing.Point(6, 218);
            this.hostname_ip_textbox.Name = "hostname_ip_textbox";
            this.hostname_ip_textbox.Size = new System.Drawing.Size(179, 26);
            this.hostname_ip_textbox.TabIndex = 17;
            // 
            // port_label
            // 
            this.port_label.AutoSize = true;
            this.port_label.Location = new System.Drawing.Point(187, 195);
            this.port_label.Name = "port_label";
            this.port_label.Size = new System.Drawing.Size(42, 20);
            this.port_label.TabIndex = 20;
            this.port_label.Text = "Port:";
            // 
            // port_textbox
            // 
            this.port_textbox.Location = new System.Drawing.Point(191, 218);
            this.port_textbox.Name = "port_textbox";
            this.port_textbox.Size = new System.Drawing.Size(179, 26);
            this.port_textbox.TabIndex = 18;
            // 
            // frag_limit_label
            // 
            this.frag_limit_label.AutoSize = true;
            this.frag_limit_label.Location = new System.Drawing.Point(2, 258);
            this.frag_limit_label.Name = "frag_limit_label";
            this.frag_limit_label.Size = new System.Drawing.Size(77, 20);
            this.frag_limit_label.TabIndex = 25;
            this.frag_limit_label.Text = "Frag limit:";
            // 
            // frag_limit
            // 
            this.frag_limit.Location = new System.Drawing.Point(6, 281);
            this.frag_limit.Name = "frag_limit";
            this.frag_limit.Size = new System.Drawing.Size(179, 26);
            this.frag_limit.TabIndex = 23;
            // 
            // time_limit_label
            // 
            this.time_limit_label.AutoSize = true;
            this.time_limit_label.Location = new System.Drawing.Point(187, 258);
            this.time_limit_label.Name = "time_limit_label";
            this.time_limit_label.Size = new System.Drawing.Size(74, 20);
            this.time_limit_label.TabIndex = 28;
            this.time_limit_label.Text = "Time limit";
            // 
            // time_limit
            // 
            this.time_limit.Location = new System.Drawing.Point(191, 281);
            this.time_limit.Name = "time_limit";
            this.time_limit.Size = new System.Drawing.Size(179, 26);
            this.time_limit.TabIndex = 24;
            // 
            // dmflags_label
            // 
            this.dmflags_label.AutoSize = true;
            this.dmflags_label.Location = new System.Drawing.Point(2, 321);
            this.dmflags_label.Name = "dmflags_label";
            this.dmflags_label.Size = new System.Drawing.Size(92, 20);
            this.dmflags_label.TabIndex = 29;
            this.dmflags_label.Text = "DMFLAGS:";
            // 
            // dmflags
            // 
            this.dmflags.Location = new System.Drawing.Point(6, 344);
            this.dmflags.Name = "dmflags";
            this.dmflags.Size = new System.Drawing.Size(179, 26);
            this.dmflags.TabIndex = 26;
            // 
            // dmflags2_label
            // 
            this.dmflags2_label.AutoSize = true;
            this.dmflags2_label.Location = new System.Drawing.Point(187, 321);
            this.dmflags2_label.Name = "dmflags2_label";
            this.dmflags2_label.Size = new System.Drawing.Size(101, 20);
            this.dmflags2_label.TabIndex = 30;
            this.dmflags2_label.Text = "DMFLAGS2:";
            // 
            // dmflags2
            // 
            this.dmflags2.Location = new System.Drawing.Point(191, 344);
            this.dmflags2.Name = "dmflags2";
            this.dmflags2.Size = new System.Drawing.Size(179, 26);
            this.dmflags2.TabIndex = 27;
            // 
            // enable_multiplayer
            // 
            this.enable_multiplayer.AutoSize = true;
            this.enable_multiplayer.Location = new System.Drawing.Point(6, 85);
            this.enable_multiplayer.Name = "enable_multiplayer";
            this.enable_multiplayer.Size = new System.Drawing.Size(147, 24);
            this.enable_multiplayer.TabIndex = 9;
            this.enable_multiplayer.Text = "Multiplayer Mode";
            this.enable_multiplayer.UseVisualStyleBackColor = true;
            this.enable_multiplayer.CheckedChanged += new System.EventHandler(this.enable_multiplayer_CheckedChanged);
            // 
            // difficulty_selection_label
            // 
            this.difficulty_selection_label.AutoSize = true;
            this.difficulty_selection_label.Location = new System.Drawing.Point(163, 9);
            this.difficulty_selection_label.Name = "difficulty_selection_label";
            this.difficulty_selection_label.Size = new System.Drawing.Size(41, 20);
            this.difficulty_selection_label.TabIndex = 8;
            this.difficulty_selection_label.Text = "Skill:";
            // 
            // difficulty_selection
            // 
            this.difficulty_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficulty_selection.FormattingEnabled = true;
            this.difficulty_selection.Location = new System.Drawing.Point(167, 32);
            this.difficulty_selection.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.difficulty_selection.Name = "difficulty_selection";
            this.difficulty_selection.Size = new System.Drawing.Size(121, 28);
            this.difficulty_selection.TabIndex = 6;
            // 
            // map_selection_label
            // 
            this.map_selection_label.AutoSize = true;
            this.map_selection_label.Location = new System.Drawing.Point(2, 9);
            this.map_selection_label.Name = "map_selection_label";
            this.map_selection_label.Size = new System.Drawing.Size(44, 20);
            this.map_selection_label.TabIndex = 7;
            this.map_selection_label.Text = "Map:";
            // 
            // map_selection
            // 
            this.map_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.map_selection.FormattingEnabled = true;
            this.map_selection.Location = new System.Drawing.Point(6, 32);
            this.map_selection.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.map_selection.Name = "map_selection";
            this.map_selection.Size = new System.Drawing.Size(121, 28);
            this.map_selection.TabIndex = 5;
            // 
            // engine_selection_label
            // 
            this.engine_selection_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.engine_selection_label.AutoSize = true;
            this.engine_selection_label.Location = new System.Drawing.Point(619, 9);
            this.engine_selection_label.Margin = new System.Windows.Forms.Padding(3);
            this.engine_selection_label.Name = "engine_selection_label";
            this.engine_selection_label.Size = new System.Drawing.Size(110, 20);
            this.engine_selection_label.TabIndex = 1;
            this.engine_selection_label.Text = "Select engine:";
            // 
            // engine_selection
            // 
            this.engine_selection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.engine_selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.engine_selection.FormattingEnabled = true;
            this.engine_selection.Location = new System.Drawing.Point(623, 32);
            this.engine_selection.Name = "engine_selection";
            this.engine_selection.Size = new System.Drawing.Size(190, 28);
            this.engine_selection.TabIndex = 0;
            this.engine_selection.SelectedIndexChanged += new System.EventHandler(this.engine_selection_SelectedIndexChanged);
            // 
            // wad_selection_label
            // 
            this.wad_selection_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wad_selection_label.AutoSize = true;
            this.wad_selection_label.Location = new System.Drawing.Point(619, 83);
            this.wad_selection_label.Name = "wad_selection_label";
            this.wad_selection_label.Size = new System.Drawing.Size(100, 20);
            this.wad_selection_label.TabIndex = 4;
            this.wad_selection_label.Text = "Select WAD:";
            // 
            // wad_selection
            // 
            this.wad_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wad_selection.FormattingEnabled = true;
            this.wad_selection.IntegralHeight = false;
            this.wad_selection.ItemHeight = 20;
            this.wad_selection.Location = new System.Drawing.Point(623, 106);
            this.wad_selection.Name = "wad_selection";
            this.wad_selection.Size = new System.Drawing.Size(190, 293);
            this.wad_selection.TabIndex = 2;
            this.wad_selection.SelectedIndexChanged += new System.EventHandler(this.wad_selection_SelectedIndexChanged);
            // 
            // add_mod_button
            // 
            this.add_mod_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.add_mod_button.BackgroundImage = global::Doom_Launcher_Project.Properties.Resources.R;
            this.add_mod_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.add_mod_button.Location = new System.Drawing.Point(597, 86);
            this.add_mod_button.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.add_mod_button.Name = "add_mod_button";
            this.add_mod_button.Size = new System.Drawing.Size(20, 20);
            this.add_mod_button.TabIndex = 12;
            this.add_mod_button.UseVisualStyleBackColor = true;
            this.add_mod_button.Click += new System.EventHandler(this.add_mod_button_Click);
            // 
            // remove_mod_button
            // 
            this.remove_mod_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remove_mod_button.BackgroundImage = global::Doom_Launcher_Project.Properties.Resources.Red_Minus_Symbol_PNG_Image;
            this.remove_mod_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.remove_mod_button.Location = new System.Drawing.Point(571, 86);
            this.remove_mod_button.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.remove_mod_button.Name = "remove_mod_button";
            this.remove_mod_button.Size = new System.Drawing.Size(20, 20);
            this.remove_mod_button.TabIndex = 13;
            this.remove_mod_button.UseVisualStyleBackColor = true;
            this.remove_mod_button.Click += new System.EventHandler(this.remove_mod_button_Click);
            // 
            // mods_selection_label
            // 
            this.mods_selection_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mods_selection_label.AutoSize = true;
            this.mods_selection_label.Location = new System.Drawing.Point(423, 83);
            this.mods_selection_label.Name = "mods_selection_label";
            this.mods_selection_label.Size = new System.Drawing.Size(101, 20);
            this.mods_selection_label.TabIndex = 11;
            this.mods_selection_label.Text = "Select mods:";
            // 
            // mods_selection
            // 
            this.mods_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mods_selection.FormattingEnabled = true;
            this.mods_selection.IntegralHeight = false;
            this.mods_selection.Location = new System.Drawing.Point(427, 106);
            this.mods_selection.Name = "mods_selection";
            this.mods_selection.Size = new System.Drawing.Size(190, 293);
            this.mods_selection.TabIndex = 14;
            this.mods_selection.SelectedIndexChanged += new System.EventHandler(this.mods_selection_SelectedIndexChanged);
            // 
            // launcher_options_tab
            // 
            this.launcher_options_tab.Controls.Add(this.launcher_options_container);
            this.launcher_options_tab.Location = new System.Drawing.Point(4, 29);
            this.launcher_options_tab.Name = "launcher_options_tab";
            this.launcher_options_tab.Padding = new System.Windows.Forms.Padding(3);
            this.launcher_options_tab.Size = new System.Drawing.Size(819, 406);
            this.launcher_options_tab.TabIndex = 1;
            this.launcher_options_tab.Text = "Launcher Options";
            this.launcher_options_tab.UseVisualStyleBackColor = true;
            // 
            // launcher_options_container
            // 
            this.launcher_options_container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.launcher_options_container.Location = new System.Drawing.Point(0, 0);
            this.launcher_options_container.Name = "launcher_options_container";
            // 
            // launcher_options_container.Panel1
            // 
            this.launcher_options_container.Panel1.Controls.Add(this.add_wads_button);
            this.launcher_options_container.Panel1.Controls.Add(this.remove_wads);
            this.launcher_options_container.Panel1.Controls.Add(this.edit_wad_button);
            this.launcher_options_container.Panel1.Controls.Add(this.wads_label);
            this.launcher_options_container.Panel1.Controls.Add(this.wads_list);
            // 
            // launcher_options_container.Panel2
            // 
            this.launcher_options_container.Panel2.Controls.Add(this.add_engines);
            this.launcher_options_container.Panel2.Controls.Add(this.remove_engines);
            this.launcher_options_container.Panel2.Controls.Add(this.edit_engine_button);
            this.launcher_options_container.Panel2.Controls.Add(this.engines_label);
            this.launcher_options_container.Panel2.Controls.Add(this.engines_list);
            this.launcher_options_container.Size = new System.Drawing.Size(819, 406);
            this.launcher_options_container.SplitterDistance = 411;
            this.launcher_options_container.TabIndex = 2;
            // 
            // add_wads_button
            // 
            this.add_wads_button.BackgroundImage = global::Doom_Launcher_Project.Properties.Resources.R;
            this.add_wads_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.add_wads_button.Location = new System.Drawing.Point(363, 11);
            this.add_wads_button.Name = "add_wads_button";
            this.add_wads_button.Size = new System.Drawing.Size(20, 20);
            this.add_wads_button.TabIndex = 2;
            this.add_wads_button.UseVisualStyleBackColor = true;
            this.add_wads_button.Click += new System.EventHandler(this.add_wads_button_Click);
            // 
            // remove_wads
            // 
            this.remove_wads.BackgroundImage = global::Doom_Launcher_Project.Properties.Resources.Red_Minus_Symbol_PNG_Image;
            this.remove_wads.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.remove_wads.Location = new System.Drawing.Point(337, 11);
            this.remove_wads.Name = "remove_wads";
            this.remove_wads.Size = new System.Drawing.Size(20, 20);
            this.remove_wads.TabIndex = 4;
            this.remove_wads.UseVisualStyleBackColor = true;
            this.remove_wads.Click += new System.EventHandler(this.remove_wads_Click);
            // 
            // edit_wad_button
            // 
            this.edit_wad_button.BackgroundImage = global::Doom_Launcher_Project.Properties.Resources._45706;
            this.edit_wad_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.edit_wad_button.Location = new System.Drawing.Point(311, 11);
            this.edit_wad_button.Name = "edit_wad_button";
            this.edit_wad_button.Size = new System.Drawing.Size(20, 20);
            this.edit_wad_button.TabIndex = 5;
            this.edit_wad_button.UseVisualStyleBackColor = true;
            this.edit_wad_button.Click += new System.EventHandler(this.edit_wad_button_Click);
            // 
            // wads_label
            // 
            this.wads_label.AutoSize = true;
            this.wads_label.Location = new System.Drawing.Point(6, 11);
            this.wads_label.Name = "wads_label";
            this.wads_label.Size = new System.Drawing.Size(83, 20);
            this.wads_label.TabIndex = 1;
            this.wads_label.Text = "WAD files:";
            this.wads_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // wads_list
            // 
            this.wads_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wads_list.FormattingEnabled = true;
            this.wads_list.HorizontalScrollbar = true;
            this.wads_list.IntegralHeight = false;
            this.wads_list.ItemHeight = 20;
            this.wads_list.Location = new System.Drawing.Point(0, 45);
            this.wads_list.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.wads_list.Name = "wads_list";
            this.wads_list.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.wads_list.Size = new System.Drawing.Size(411, 361);
            this.wads_list.TabIndex = 3;
            // 
            // add_engines
            // 
            this.add_engines.BackgroundImage = global::Doom_Launcher_Project.Properties.Resources.R;
            this.add_engines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.add_engines.Location = new System.Drawing.Point(352, 11);
            this.add_engines.Name = "add_engines";
            this.add_engines.Size = new System.Drawing.Size(20, 20);
            this.add_engines.TabIndex = 5;
            this.add_engines.UseVisualStyleBackColor = true;
            this.add_engines.Click += new System.EventHandler(this.add_engines_Click);
            // 
            // remove_engines
            // 
            this.remove_engines.BackgroundImage = global::Doom_Launcher_Project.Properties.Resources.Red_Minus_Symbol_PNG_Image;
            this.remove_engines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.remove_engines.Location = new System.Drawing.Point(326, 11);
            this.remove_engines.Name = "remove_engines";
            this.remove_engines.Size = new System.Drawing.Size(20, 20);
            this.remove_engines.TabIndex = 5;
            this.remove_engines.UseVisualStyleBackColor = true;
            this.remove_engines.Click += new System.EventHandler(this.remove_engines_Click);
            // 
            // edit_engine_button
            // 
            this.edit_engine_button.BackgroundImage = global::Doom_Launcher_Project.Properties.Resources._45706;
            this.edit_engine_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.edit_engine_button.Location = new System.Drawing.Point(300, 11);
            this.edit_engine_button.Name = "edit_engine_button";
            this.edit_engine_button.Size = new System.Drawing.Size(20, 20);
            this.edit_engine_button.TabIndex = 6;
            this.edit_engine_button.UseVisualStyleBackColor = true;
            this.edit_engine_button.Click += new System.EventHandler(this.edit_engine_button_Click);
            // 
            // engines_label
            // 
            this.engines_label.AutoSize = true;
            this.engines_label.Location = new System.Drawing.Point(6, 11);
            this.engines_label.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.engines_label.Name = "engines_label";
            this.engines_label.Size = new System.Drawing.Size(71, 20);
            this.engines_label.TabIndex = 3;
            this.engines_label.Text = "Engines:";
            this.engines_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // engines_list
            // 
            this.engines_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.engines_list.FormattingEnabled = true;
            this.engines_list.HorizontalScrollbar = true;
            this.engines_list.IntegralHeight = false;
            this.engines_list.ItemHeight = 20;
            this.engines_list.Location = new System.Drawing.Point(0, 45);
            this.engines_list.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.engines_list.Name = "engines_list";
            this.engines_list.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.engines_list.Size = new System.Drawing.Size(404, 361);
            this.engines_list.TabIndex = 4;
            // 
            // play_button
            // 
            this.play_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.play_button.Location = new System.Drawing.Point(764, 457);
            this.play_button.Name = "play_button";
            this.play_button.Size = new System.Drawing.Size(75, 50);
            this.play_button.TabIndex = 1;
            this.play_button.Text = "Play";
            this.play_button.UseVisualStyleBackColor = true;
            this.play_button.Click += new System.EventHandler(this.play_button_Click);
            // 
            // command_line_view
            // 
            this.command_line_view.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.command_line_view.Location = new System.Drawing.Point(12, 458);
            this.command_line_view.Name = "command_line_view";
            this.command_line_view.ReadOnly = true;
            this.command_line_view.Size = new System.Drawing.Size(746, 49);
            this.command_line_view.TabIndex = 2;
            this.command_line_view.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Launcher_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 519);
            this.Controls.Add(this.command_line_view);
            this.Controls.Add(this.play_button);
            this.Controls.Add(this.menu_control);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher_Window";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Launcher_Window_FormClosed);
            this.Click += new System.EventHandler(this.Launcher_Window_Click);
            this.menu_control.ResumeLayout(false);
            this.game_options_tab.ResumeLayout(false);
            this.game_options_tab.PerformLayout();
            this.launcher_options_tab.ResumeLayout(false);
            this.launcher_options_container.Panel1.ResumeLayout(false);
            this.launcher_options_container.Panel1.PerformLayout();
            this.launcher_options_container.Panel2.ResumeLayout(false);
            this.launcher_options_container.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.launcher_options_container)).EndInit();
            this.launcher_options_container.ResumeLayout(false);
            this.ResumeLayout(false);

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
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.TextBox frag_limit;
        public System.Windows.Forms.Label frag_limit_label;
        public System.Windows.Forms.Label time_limit_label;
        public System.Windows.Forms.TextBox time_limit;
        public System.Windows.Forms.Label dmflags_label;
        public System.Windows.Forms.TextBox dmflags;
        public System.Windows.Forms.Label dmflags2_label;
        public System.Windows.Forms.TextBox dmflags2;
    }
}

