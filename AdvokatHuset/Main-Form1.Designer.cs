namespace AdvokatHuset
{
    partial class Main_Form1
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
            this.Loader_panel = new System.Windows.Forms.Panel();
            this.Top_Menu_panel = new System.Windows.Forms.Panel();
            this.General_Menu_Panel = new System.Windows.Forms.Panel();
            this.General_menuStrip = new System.Windows.Forms.MenuStrip();
            this.sagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visSagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ydelserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advokaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sekretærToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Menu_Search_button = new System.Windows.Forms.Button();
            this.Loacal_Folder_button = new System.Windows.Forms.Button();
            this.Screenshot_button = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Home_Button = new System.Windows.Forms.Button();
            this.Back_Button = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.Forward_Button = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Top_Menu_panel.SuspendLayout();
            this.General_Menu_Panel.SuspendLayout();
            this.General_menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Loader_panel
            // 
            this.Loader_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(80)))), ((int)(((byte)(72)))));
            this.Loader_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Loader_panel.Location = new System.Drawing.Point(0, 38);
            this.Loader_panel.Name = "Loader_panel";
            this.Loader_panel.Size = new System.Drawing.Size(1070, 561);
            this.Loader_panel.TabIndex = 9;
            this.Loader_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Loader_panel_Paint);
            // 
            // Top_Menu_panel
            // 
            this.Top_Menu_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Top_Menu_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Top_Menu_panel.Controls.Add(this.comboBox1);
            this.Top_Menu_panel.Controls.Add(this.Menu_Search_button);
            this.Top_Menu_panel.Controls.Add(this.textBox1);
            this.Top_Menu_panel.Controls.Add(this.Loacal_Folder_button);
            this.Top_Menu_panel.Controls.Add(this.Screenshot_button);
            this.Top_Menu_panel.Controls.Add(this.button3);
            this.Top_Menu_panel.Controls.Add(this.Home_Button);
            this.Top_Menu_panel.Controls.Add(this.Back_Button);
            this.Top_Menu_panel.Controls.Add(this.button6);
            this.Top_Menu_panel.Controls.Add(this.Forward_Button);
            this.Top_Menu_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_Menu_panel.Location = new System.Drawing.Point(0, 0);
            this.Top_Menu_panel.Name = "Top_Menu_panel";
            this.Top_Menu_panel.Size = new System.Drawing.Size(1070, 41);
            this.Top_Menu_panel.TabIndex = 0;
            // 
            // General_Menu_Panel
            // 
            this.General_Menu_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.General_Menu_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.General_Menu_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.General_Menu_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.General_Menu_Panel.Controls.Add(this.General_menuStrip);
            this.General_Menu_Panel.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.General_Menu_Panel.Location = new System.Drawing.Point(280, 38);
            this.General_Menu_Panel.Name = "General_Menu_Panel";
            this.General_Menu_Panel.Size = new System.Drawing.Size(524, 34);
            this.General_Menu_Panel.TabIndex = 1;
            // 
            // General_menuStrip
            // 
            this.General_menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.General_menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.General_menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.General_menuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.General_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sagerToolStripMenuItem,
            this.ydelserToolStripMenuItem,
            this.advokaterToolStripMenuItem,
            this.sekretærToolStripMenuItem});
            this.General_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.General_menuStrip.Name = "General_menuStrip";
            this.General_menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.General_menuStrip.Size = new System.Drawing.Size(522, 32);
            this.General_menuStrip.TabIndex = 2;
            this.General_menuStrip.Text = "menuStrip1";
            // 
            // sagerToolStripMenuItem
            // 
            this.sagerToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visSagerToolStripMenuItem});
            this.sagerToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sagerToolStripMenuItem.Name = "sagerToolStripMenuItem";
            this.sagerToolStripMenuItem.Size = new System.Drawing.Size(57, 28);
            this.sagerToolStripMenuItem.Text = "Sager";
            // 
            // visSagerToolStripMenuItem
            // 
            this.visSagerToolStripMenuItem.Name = "visSagerToolStripMenuItem";
            this.visSagerToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.visSagerToolStripMenuItem.Text = "Vis Sager";
            // 
            // ydelserToolStripMenuItem
            // 
            this.ydelserToolStripMenuItem.Name = "ydelserToolStripMenuItem";
            this.ydelserToolStripMenuItem.Size = new System.Drawing.Size(57, 28);
            this.ydelserToolStripMenuItem.Text = "Ydelser";
            // 
            // advokaterToolStripMenuItem
            // 
            this.advokaterToolStripMenuItem.Name = "advokaterToolStripMenuItem";
            this.advokaterToolStripMenuItem.Size = new System.Drawing.Size(73, 28);
            this.advokaterToolStripMenuItem.Text = "Advokater";
            // 
            // sekretærToolStripMenuItem
            // 
            this.sekretærToolStripMenuItem.Name = "sekretærToolStripMenuItem";
            this.sekretærToolStripMenuItem.Size = new System.Drawing.Size(65, 28);
            this.sekretærToolStripMenuItem.Text = "Sekretær";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(456, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 10;
            // 
            // Menu_Search_button
            // 
            this.Menu_Search_button.BackgroundImage = global::AdvokatHuset.Properties.Resources.win7_ico_shell32_dll_022;
            this.Menu_Search_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Menu_Search_button.Location = new System.Drawing.Point(609, 4);
            this.Menu_Search_button.Margin = new System.Windows.Forms.Padding(0);
            this.Menu_Search_button.Name = "Menu_Search_button";
            this.Menu_Search_button.Size = new System.Drawing.Size(25, 26);
            this.Menu_Search_button.TabIndex = 11;
            this.Menu_Search_button.UseVisualStyleBackColor = true;
            // 
            // Loacal_Folder_button
            // 
            this.Loacal_Folder_button.BackgroundImage = global::AdvokatHuset.Properties.Resources.win7_ico_shell32_dll_0041;
            this.Loacal_Folder_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Loacal_Folder_button.Location = new System.Drawing.Point(225, 4);
            this.Loacal_Folder_button.Margin = new System.Windows.Forms.Padding(0);
            this.Loacal_Folder_button.Name = "Loacal_Folder_button";
            this.Loacal_Folder_button.Size = new System.Drawing.Size(28, 29);
            this.Loacal_Folder_button.TabIndex = 9;
            this.Loacal_Folder_button.UseVisualStyleBackColor = true;
            // 
            // Screenshot_button
            // 
            this.Screenshot_button.BackgroundImage = global::AdvokatHuset.Properties.Resources.unnamed__1_1;
            this.Screenshot_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Screenshot_button.Location = new System.Drawing.Point(922, 4);
            this.Screenshot_button.Margin = new System.Windows.Forms.Padding(0);
            this.Screenshot_button.Name = "Screenshot_button";
            this.Screenshot_button.Size = new System.Drawing.Size(33, 33);
            this.Screenshot_button.TabIndex = 8;
            this.Screenshot_button.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::AdvokatHuset.Properties.Resources.win7_ico_shell32_dll_1121;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(11, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 33);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Home_Button
            // 
            this.Home_Button.BackgroundImage = global::AdvokatHuset.Properties.Resources.images__1___1_;
            this.Home_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Home_Button.Location = new System.Drawing.Point(101, 5);
            this.Home_Button.Name = "Home_Button";
            this.Home_Button.Size = new System.Drawing.Size(30, 30);
            this.Home_Button.TabIndex = 6;
            this.Home_Button.UseVisualStyleBackColor = true;
            // 
            // Back_Button
            // 
            this.Back_Button.BackgroundImage = global::AdvokatHuset.Properties.Resources.Background;
            this.Back_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Back_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Back_Button.Location = new System.Drawing.Point(65, 5);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(30, 30);
            this.Back_Button.TabIndex = 2;
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::AdvokatHuset.Properties.Resources._23234;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(1024, 8);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(33, 27);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // Forward_Button
            // 
            this.Forward_Button.BackgroundImage = global::AdvokatHuset.Properties.Resources.Background___Copy;
            this.Forward_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Forward_Button.Location = new System.Drawing.Point(137, 5);
            this.Forward_Button.Name = "Forward_Button";
            this.Forward_Button.Size = new System.Drawing.Size(30, 30);
            this.Forward_Button.TabIndex = 4;
            this.Forward_Button.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(386, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(64, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // Main_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 599);
            this.Controls.Add(this.General_Menu_Panel);
            this.Controls.Add(this.Top_Menu_panel);
            this.Controls.Add(this.Loader_panel);
            this.MainMenuStrip = this.General_menuStrip;
            this.Name = "Main_Form1";
            this.Text = "Main_Form1";
            this.Load += new System.EventHandler(this.Main_Form1_Load);
            this.Top_Menu_panel.ResumeLayout(false);
            this.Top_Menu_panel.PerformLayout();
            this.General_Menu_Panel.ResumeLayout(false);
            this.General_Menu_Panel.PerformLayout();
            this.General_menuStrip.ResumeLayout(false);
            this.General_menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Loader_panel;
        private System.Windows.Forms.Panel Top_Menu_panel;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button Forward_Button;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.Panel General_Menu_Panel;
        private System.Windows.Forms.Button Home_Button;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip General_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem sagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visSagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ydelserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advokaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sekretærToolStripMenuItem;
        private System.Windows.Forms.Button Screenshot_button;
        private System.Windows.Forms.Button Loacal_Folder_button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Menu_Search_button;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}