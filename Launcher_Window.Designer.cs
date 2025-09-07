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
            this.menu_control = new System.Windows.Forms.TabControl();
            this.game_options_tab = new System.Windows.Forms.TabPage();
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
            this.menu_control.Size = new System.Drawing.Size(776, 370);
            this.menu_control.TabIndex = 0;
            // 
            // game_options_tab
            // 
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
            this.game_options_tab.Size = new System.Drawing.Size(768, 337);
            this.game_options_tab.TabIndex = 0;
            this.game_options_tab.Text = "Game Options";
            this.game_options_tab.UseVisualStyleBackColor = true;
            this.game_options_tab.MouseClick += new System.Windows.Forms.MouseEventHandler(this.new_selection_MouseClick);
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
            this.enable_multiplayer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.new_selection_MouseClick);
            // 
            // difficulty_selection_label
            // 
            this.difficulty_selection_label.AutoSize = true;
            this.difficulty_selection_label.Location = new System.Drawing.Point(172, 9);
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
            this.difficulty_selection.SelectedIndexChanged += new System.EventHandler(this.difficulty_selection_SelectedIndexChanged);
            this.difficulty_selection.MouseClick += new System.Windows.Forms.MouseEventHandler(this.new_selection_MouseClick);
            // 
            // map_selection_label
            // 
            this.map_selection_label.AutoSize = true;
            this.map_selection_label.Location = new System.Drawing.Point(6, 9);
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
            this.map_selection.SelectedIndexChanged += new System.EventHandler(this.map_selection_SelectedIndexChanged);
            this.map_selection.MouseClick += new System.Windows.Forms.MouseEventHandler(this.new_selection_MouseClick);
            // 
            // engine_selection_label
            // 
            this.engine_selection_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.engine_selection_label.AutoSize = true;
            this.engine_selection_label.Location = new System.Drawing.Point(568, 9);
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
            this.engine_selection.Location = new System.Drawing.Point(572, 32);
            this.engine_selection.Name = "engine_selection";
            this.engine_selection.Size = new System.Drawing.Size(190, 28);
            this.engine_selection.TabIndex = 0;
            this.engine_selection.SelectedIndexChanged += new System.EventHandler(this.engine_selection_SelectedIndexChanged);
            this.engine_selection.MouseClick += new System.Windows.Forms.MouseEventHandler(this.new_selection_MouseClick);
            // 
            // wad_selection_label
            // 
            this.wad_selection_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wad_selection_label.AutoSize = true;
            this.wad_selection_label.Location = new System.Drawing.Point(568, 83);
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
            this.wad_selection.Location = new System.Drawing.Point(572, 106);
            this.wad_selection.Name = "wad_selection";
            this.wad_selection.Size = new System.Drawing.Size(190, 224);
            this.wad_selection.TabIndex = 2;
            this.wad_selection.MouseClick += new System.Windows.Forms.MouseEventHandler(this.new_selection_MouseClick);
            this.wad_selection.SelectedIndexChanged += new System.EventHandler(this.wad_selection_SelectedIndexChanged);
            // 
            // add_mod_button
            // 
            this.add_mod_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.add_mod_button.BackgroundImage = global::Doom_Launcher_Project.Properties.Resources.R;
            this.add_mod_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.add_mod_button.Location = new System.Drawing.Point(546, 86);
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
            this.remove_mod_button.Location = new System.Drawing.Point(520, 86);
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
            this.mods_selection_label.Location = new System.Drawing.Point(372, 83);
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
            this.mods_selection.Location = new System.Drawing.Point(376, 106);
            this.mods_selection.Name = "mods_selection";
            this.mods_selection.Size = new System.Drawing.Size(190, 224);
            this.mods_selection.TabIndex = 14;
            this.mods_selection.MouseClick += new System.Windows.Forms.MouseEventHandler(this.new_selection_MouseClick);
            this.mods_selection.SelectedIndexChanged += new System.EventHandler(this.mods_selection_SelectedIndexChanged);
            // 
            // launcher_options_tab
            // 
            this.launcher_options_tab.Controls.Add(this.launcher_options_container);
            this.launcher_options_tab.Location = new System.Drawing.Point(4, 29);
            this.launcher_options_tab.Name = "launcher_options_tab";
            this.launcher_options_tab.Padding = new System.Windows.Forms.Padding(3);
            this.launcher_options_tab.Size = new System.Drawing.Size(768, 337);
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
            this.launcher_options_container.Size = new System.Drawing.Size(768, 337);
            this.launcher_options_container.SplitterDistance = 386;
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
            this.wads_list.Size = new System.Drawing.Size(386, 292);
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
            this.engines_list.Size = new System.Drawing.Size(378, 292);
            this.engines_list.TabIndex = 4;
            // 
            // play_button
            // 
            this.play_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.play_button.Location = new System.Drawing.Point(713, 388);
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
            this.command_line_view.Location = new System.Drawing.Point(12, 389);
            this.command_line_view.Name = "command_line_view";
            this.command_line_view.ReadOnly = true;
            this.command_line_view.Size = new System.Drawing.Size(695, 49);
            this.command_line_view.TabIndex = 2;
            this.command_line_view.Text = "";
            // 
            // Launcher_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.command_line_view);
            this.Controls.Add(this.play_button);
            this.Controls.Add(this.menu_control);
            this.Name = "Launcher_Window";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Launcher_Window_FormClosed);
            this.Load += new System.EventHandler(this.Launcher_Window_Load);
            this.Click += new System.EventHandler(this.Launcher_Window_Click);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.new_selection_MouseClick);
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
    }
}

