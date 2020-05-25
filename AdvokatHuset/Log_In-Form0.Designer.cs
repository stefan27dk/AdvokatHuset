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
            this.log_in_holder_panel.SuspendLayout();
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
            this.log_in_button.Location = new System.Drawing.Point(177, 163);
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
            this.wrong_log_in_label.Location = new System.Drawing.Point(62, 275);
            this.wrong_log_in_label.Name = "wrong_log_in_label";
            this.wrong_log_in_label.Size = new System.Drawing.Size(262, 16);
            this.wrong_log_in_label.TabIndex = 41;
            this.wrong_log_in_label.Text = "Bruger Navn eller kodeord er Forkert";
            this.wrong_log_in_label.Visible = false;
            // 
            // log_in_holder_panel
            // 
            this.log_in_holder_panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.log_in_holder_panel.Controls.Add(this.log_pass_textBox);
            this.log_in_holder_panel.Controls.Add(this.wrong_log_in_label);
            this.log_in_holder_panel.Controls.Add(this.pass_label);
            this.log_in_holder_panel.Controls.Add(this.log_in_button);
            this.log_in_holder_panel.Controls.Add(this.log_name_textBox);
            this.log_in_holder_panel.Controls.Add(this.remember_log_in_checkBox);
            this.log_in_holder_panel.Controls.Add(this.name_label);
            this.log_in_holder_panel.Controls.Add(this.log_in_label);
            this.log_in_holder_panel.Location = new System.Drawing.Point(623, 198);
            this.log_in_holder_panel.Name = "log_in_holder_panel";
            this.log_in_holder_panel.Size = new System.Drawing.Size(354, 356);
            this.log_in_holder_panel.TabIndex = 42;
            // 
            // Log_In_Form0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(54)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1600, 800);
            this.Controls.Add(this.log_in_holder_panel);
            this.Controls.Add(this.settings_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Log_In_Form0";
            this.Text = "Log_In_Form0";
            this.Load += new System.EventHandler(this.Log_In_Form0_Load);
            this.log_in_holder_panel.ResumeLayout(false);
            this.log_in_holder_panel.PerformLayout();
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
    }
}