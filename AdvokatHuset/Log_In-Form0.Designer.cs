namespace View_GUI
{
    partial class Log_In_Form0
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
            this.log_pass_textBox = new System.Windows.Forms.TextBox();
            this.log_name_textBox = new System.Windows.Forms.TextBox();
            this.log_in_label = new System.Windows.Forms.Label();
            this.remember_log_in_checkBox = new System.Windows.Forms.CheckBox();
            this.log_in_button = new System.Windows.Forms.Button();
            this.settings_button = new System.Windows.Forms.Button();
            this.name_label = new System.Windows.Forms.Label();
            this.pass_label = new System.Windows.Forms.Label();
            this.wrong_log_in_label = new System.Windows.Forms.Label();
            this.log_in_holder_panel = new System.Windows.Forms.Panel();
            this.delete_login_file_button = new System.Windows.Forms.Button();
            this.log_in_Clear_all_button = new System.Windows.Forms.Button();
            this.settings_myPanel = new View_GUI.MyPanel();
            this.secret_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.conn_string__Save_button = new System.Windows.Forms.Button();
            this.conn_ex2_label = new System.Windows.Forms.Label();
            this.conn_string_textBox = new System.Windows.Forms.TextBox();
            this.connection_string_label = new System.Windows.Forms.Label();
            this.secret_developer_mode_button = new System.Windows.Forms.Button();
            this.log_in_holder_panel.SuspendLayout();
            this.settings_myPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // log_pass_textBox
            // 
            this.log_pass_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.log_pass_textBox.Location = new System.Drawing.Point(127, 126);
            this.log_pass_textBox.MaxLength = 49;
            this.log_pass_textBox.Name = "log_pass_textBox";
            this.log_pass_textBox.Size = new System.Drawing.Size(142, 20);
            this.log_pass_textBox.TabIndex = 36;
            this.log_pass_textBox.TextChanged += new System.EventHandler(this.log_pass_textBox_TextChanged);
            // 
            // log_name_textBox
            // 
            this.log_name_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.log_name_textBox.Location = new System.Drawing.Point(127, 83);
            this.log_name_textBox.MaxLength = 49;
            this.log_name_textBox.Name = "log_name_textBox";
            this.log_name_textBox.Size = new System.Drawing.Size(142, 20);
            this.log_name_textBox.TabIndex = 33;
            this.log_name_textBox.TextChanged += new System.EventHandler(this.log_name_textBox_TextChanged);
            // 
            // log_in_label
            // 
            this.log_in_label.AutoSize = true;
            this.log_in_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log_in_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.log_in_label.Location = new System.Drawing.Point(159, 21);
            this.log_in_label.Name = "log_in_label";
            this.log_in_label.Size = new System.Drawing.Size(68, 24);
            this.log_in_label.TabIndex = 37;
            this.log_in_label.Text = "Log In";
            // 
            // remember_log_in_checkBox
            // 
            this.remember_log_in_checkBox.AutoSize = true;
            this.remember_log_in_checkBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.remember_log_in_checkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.remember_log_in_checkBox.Location = new System.Drawing.Point(141, 219);
            this.remember_log_in_checkBox.Name = "remember_log_in_checkBox";
            this.remember_log_in_checkBox.Size = new System.Drawing.Size(112, 20);
            this.remember_log_in_checkBox.TabIndex = 39;
            this.remember_log_in_checkBox.Text = "Husk Log In";
            this.remember_log_in_checkBox.UseVisualStyleBackColor = true;
            // 
            // log_in_button
            // 
            this.log_in_button.BackgroundImage = global::View_GUI.Properties.Resources.system_log_out_icon;
            this.log_in_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.log_in_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.log_in_button.FlatAppearance.BorderSize = 0;
            this.log_in_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.log_in_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(186)))), ((int)(((byte)(82)))));
            this.log_in_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.log_in_button.Location = new System.Drawing.Point(190, 163);
            this.log_in_button.Name = "log_in_button";
            this.log_in_button.Size = new System.Drawing.Size(41, 39);
            this.log_in_button.TabIndex = 40;
            this.log_in_button.UseVisualStyleBackColor = true;
            this.log_in_button.Click += new System.EventHandler(this.log_in_button_Click);
            // 
            // settings_button
            // 
            this.settings_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settings_button.BackgroundImage = global::View_GUI.Properties.Resources.Categories_preferences_system_icon;
            this.settings_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settings_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settings_button.FlatAppearance.BorderSize = 0;
            this.settings_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.settings_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(186)))), ((int)(((byte)(82)))));
            this.settings_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings_button.Location = new System.Drawing.Point(1517, 730);
            this.settings_button.Name = "settings_button";
            this.settings_button.Size = new System.Drawing.Size(41, 39);
            this.settings_button.TabIndex = 38;
            this.settings_button.UseVisualStyleBackColor = true;
            this.settings_button.Click += new System.EventHandler(this.settings_button_Click);
            // 
            // name_label
            // 
            this.name_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.name_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.name_label.Image = global::View_GUI.Properties.Resources.ID_icon;
            this.name_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.name_label.Location = new System.Drawing.Point(26, 80);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(92, 24);
            this.name_label.TabIndex = 34;
            this.name_label.Text = "Navn:";
            this.name_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pass_label
            // 
            this.pass_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pass_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.pass_label.Image = global::View_GUI.Properties.Resources.Pass2;
            this.pass_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pass_label.Location = new System.Drawing.Point(15, 123);
            this.pass_label.Name = "pass_label";
            this.pass_label.Size = new System.Drawing.Size(107, 25);
            this.pass_label.TabIndex = 35;
            this.pass_label.Text = "Kodeord:";
            this.pass_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wrong_log_in_label
            // 
            this.wrong_log_in_label.AutoSize = true;
            this.wrong_log_in_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wrong_log_in_label.ForeColor = System.Drawing.Color.Red;
            this.wrong_log_in_label.Location = new System.Drawing.Point(67, 286);
            this.wrong_log_in_label.Name = "wrong_log_in_label";
            this.wrong_log_in_label.Size = new System.Drawing.Size(262, 16);
            this.wrong_log_in_label.TabIndex = 41;
            this.wrong_log_in_label.Text = "Bruger Navn eller kodeord er Forkert";
            this.wrong_log_in_label.Visible = false;
            // 
            // log_in_holder_panel
            // 
            this.log_in_holder_panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.log_in_holder_panel.Controls.Add(this.delete_login_file_button);
            this.log_in_holder_panel.Controls.Add(this.log_in_Clear_all_button);
            this.log_in_holder_panel.Controls.Add(this.log_pass_textBox);
            this.log_in_holder_panel.Controls.Add(this.wrong_log_in_label);
            this.log_in_holder_panel.Controls.Add(this.pass_label);
            this.log_in_holder_panel.Controls.Add(this.log_in_button);
            this.log_in_holder_panel.Controls.Add(this.log_name_textBox);
            this.log_in_holder_panel.Controls.Add(this.remember_log_in_checkBox);
            this.log_in_holder_panel.Controls.Add(this.name_label);
            this.log_in_holder_panel.Controls.Add(this.log_in_label);
            this.log_in_holder_panel.Location = new System.Drawing.Point(621, 198);
            this.log_in_holder_panel.Name = "log_in_holder_panel";
            this.log_in_holder_panel.Size = new System.Drawing.Size(354, 356);
            this.log_in_holder_panel.TabIndex = 42;
            // 
            // delete_login_file_button
            // 
            this.delete_login_file_button.BackgroundImage = global::View_GUI.Properties.Resources.Delete_file_icon;
            this.delete_login_file_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.delete_login_file_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete_login_file_button.FlatAppearance.BorderSize = 0;
            this.delete_login_file_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.delete_login_file_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(186)))), ((int)(((byte)(82)))));
            this.delete_login_file_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_login_file_button.Location = new System.Drawing.Point(188, 246);
            this.delete_login_file_button.Name = "delete_login_file_button";
            this.delete_login_file_button.Size = new System.Drawing.Size(26, 31);
            this.delete_login_file_button.TabIndex = 43;
            this.delete_login_file_button.UseVisualStyleBackColor = true;
            this.delete_login_file_button.Click += new System.EventHandler(this.delete_login_file_button_Click);
            // 
            // log_in_Clear_all_button
            // 
            this.log_in_Clear_all_button.BackColor = System.Drawing.Color.Transparent;
            this.log_in_Clear_all_button.BackgroundImage = global::View_GUI.Properties.Resources.Actions_edit_delete_icon1;
            this.log_in_Clear_all_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.log_in_Clear_all_button.FlatAppearance.BorderSize = 0;
            this.log_in_Clear_all_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.log_in_Clear_all_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.log_in_Clear_all_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.log_in_Clear_all_button.ForeColor = System.Drawing.Color.Black;
            this.log_in_Clear_all_button.Location = new System.Drawing.Point(154, 171);
            this.log_in_Clear_all_button.Name = "log_in_Clear_all_button";
            this.log_in_Clear_all_button.Size = new System.Drawing.Size(28, 23);
            this.log_in_Clear_all_button.TabIndex = 42;
            this.log_in_Clear_all_button.UseVisualStyleBackColor = false;
            this.log_in_Clear_all_button.Click += new System.EventHandler(this.log_in_Clear_all_button_Click);
            // 
            // settings_myPanel
            // 
            this.settings_myPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settings_myPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.settings_myPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settings_myPanel.Controls.Add(this.secret_label);
            this.settings_myPanel.Controls.Add(this.label1);
            this.settings_myPanel.Controls.Add(this.textBox1);
            this.settings_myPanel.Controls.Add(this.conn_string__Save_button);
            this.settings_myPanel.Controls.Add(this.conn_ex2_label);
            this.settings_myPanel.Controls.Add(this.conn_string_textBox);
            this.settings_myPanel.Controls.Add(this.connection_string_label);
            this.settings_myPanel.Location = new System.Drawing.Point(406, 546);
            this.settings_myPanel.Name = "settings_myPanel";
            this.settings_myPanel.Size = new System.Drawing.Size(1103, 188);
            this.settings_myPanel.TabIndex = 43;
            this.settings_myPanel.Visible = false;
            // 
            // secret_label
            // 
            this.secret_label.AutoSize = true;
            this.secret_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secret_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(45)))));
            this.secret_label.Location = new System.Drawing.Point(45, 166);
            this.secret_label.Name = "secret_label";
            this.secret_label.Size = new System.Drawing.Size(336, 13);
            this.secret_label.TabIndex = 25;
            this.secret_label.Text = "Hvis du vil finde den Ubegrænset magt find den ved placering \"0;0\" . ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(45, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(944, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Vær opmærksom på den dobbelte \\\\ efter BG-1-PC \\\\ . Det kan give en fejl. Den Lav" +
    "er det automatisk til // hvis du sætter /. Kommer end på tilfælden";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Lime;
            this.textBox1.Location = new System.Drawing.Point(291, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(685, 22);
            this.textBox1.TabIndex = 23;
            this.textBox1.Text = "Data source=BG-1-PC\\\\SQLEXPRESS; Database = Advokathuset; User Id = abc; Password" +
    " = abc;";
            // 
            // conn_string__Save_button
            // 
            this.conn_string__Save_button.FlatAppearance.BorderSize = 0;
            this.conn_string__Save_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.conn_string__Save_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.conn_string__Save_button.Font = new System.Drawing.Font("Gentium Basic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conn_string__Save_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(143)))), ((int)(((byte)(235)))));
            this.conn_string__Save_button.Image = global::View_GUI.Properties.Resources.Actions_document_save_icon;
            this.conn_string__Save_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.conn_string__Save_button.Location = new System.Drawing.Point(973, 45);
            this.conn_string__Save_button.Name = "conn_string__Save_button";
            this.conn_string__Save_button.Size = new System.Drawing.Size(90, 30);
            this.conn_string__Save_button.TabIndex = 22;
            this.conn_string__Save_button.Text = "Gem";
            this.conn_string__Save_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.conn_string__Save_button.UseVisualStyleBackColor = true;
            this.conn_string__Save_button.Click += new System.EventHandler(this.conn_string__Save_button_Click);
            // 
            // conn_ex2_label
            // 
            this.conn_ex2_label.AutoSize = true;
            this.conn_ex2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.conn_ex2_label.ForeColor = System.Drawing.Color.Aqua;
            this.conn_ex2_label.Location = new System.Drawing.Point(44, 97);
            this.conn_ex2_label.Name = "conn_ex2_label";
            this.conn_ex2_label.Size = new System.Drawing.Size(241, 20);
            this.conn_ex2_label.TabIndex = 3;
            this.conn_ex2_label.Text = "Connection String Eksempel:";
            // 
            // conn_string_textBox
            // 
            this.conn_string_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.conn_string_textBox.Location = new System.Drawing.Point(48, 49);
            this.conn_string_textBox.Name = "conn_string_textBox";
            this.conn_string_textBox.Size = new System.Drawing.Size(907, 20);
            this.conn_string_textBox.TabIndex = 1;
            // 
            // connection_string_label
            // 
            this.connection_string_label.AutoSize = true;
            this.connection_string_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connection_string_label.ForeColor = System.Drawing.Color.Lime;
            this.connection_string_label.Location = new System.Drawing.Point(44, 15);
            this.connection_string_label.Name = "connection_string_label";
            this.connection_string_label.Size = new System.Drawing.Size(183, 24);
            this.connection_string_label.TabIndex = 0;
            this.connection_string_label.Text = "Connection String:";
            // 
            // secret_developer_mode_button
            // 
            this.secret_developer_mode_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.secret_developer_mode_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.secret_developer_mode_button.FlatAppearance.BorderSize = 0;
            this.secret_developer_mode_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.secret_developer_mode_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(186)))), ((int)(((byte)(82)))));
            this.secret_developer_mode_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secret_developer_mode_button.Location = new System.Drawing.Point(5, 4);
            this.secret_developer_mode_button.Name = "secret_developer_mode_button";
            this.secret_developer_mode_button.Size = new System.Drawing.Size(41, 39);
            this.secret_developer_mode_button.TabIndex = 44;
            this.secret_developer_mode_button.UseVisualStyleBackColor = true;
            this.secret_developer_mode_button.Click += new System.EventHandler(this.secret_developer_mode_button_Click);
            this.secret_developer_mode_button.MouseEnter += new System.EventHandler(this.secret_developer_mode_button_MouseEnter);
            this.secret_developer_mode_button.MouseLeave += new System.EventHandler(this.secret_developer_mode_button_MouseLeave);
            // 
            // Log_In_Form0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(54)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1600, 800);
            this.Controls.Add(this.secret_developer_mode_button);
            this.Controls.Add(this.settings_myPanel);
            this.Controls.Add(this.log_in_holder_panel);
            this.Controls.Add(this.settings_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Log_In_Form0";
            this.Text = "Log_In_Form0";
            this.Load += new System.EventHandler(this.Log_In_Form0_Load);
            this.log_in_holder_panel.ResumeLayout(false);
            this.log_in_holder_panel.PerformLayout();
            this.settings_myPanel.ResumeLayout(false);
            this.settings_myPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox log_pass_textBox;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.TextBox log_name_textBox;
        private System.Windows.Forms.Label pass_label;
        private System.Windows.Forms.Label log_in_label;
        private System.Windows.Forms.Button settings_button;
        private System.Windows.Forms.CheckBox remember_log_in_checkBox;
        private System.Windows.Forms.Button log_in_button;
        private System.Windows.Forms.Label wrong_log_in_label;
        private System.Windows.Forms.Panel log_in_holder_panel;
        private System.Windows.Forms.Button log_in_Clear_all_button;
        private MyPanel settings_myPanel;
        private System.Windows.Forms.TextBox conn_string_textBox;
        private System.Windows.Forms.Label connection_string_label;
        private System.Windows.Forms.Label conn_ex2_label;
        private System.Windows.Forms.Button conn_string__Save_button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label secret_label;
        private System.Windows.Forms.Button secret_developer_mode_button;
        private System.Windows.Forms.Button delete_login_file_button;
    }
}