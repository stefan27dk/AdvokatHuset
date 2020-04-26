namespace View_GUI
{
    partial class SelectionScreenshot_Form4
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
            this.help_label = new System.Windows.Forms.Label();
            this.help_button = new System.Windows.Forms.Button();
            this.openFolder_button = new System.Windows.Forms.Button();
            this.closeForm_button = new System.Windows.Forms.Button();
            this.selectionScreenshot_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // help_label
            // 
            this.help_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.help_label.AutoSize = true;
            this.help_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.help_label.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.help_label.ForeColor = System.Drawing.Color.Lavender;
            this.help_label.Location = new System.Drawing.Point(223, 413);
            this.help_label.Name = "help_label";
            this.help_label.Size = new System.Drawing.Size(663, 25);
            this.help_label.TabIndex = 4;
            this.help_label.Text = "Press Mouse Left button and drag, than press save button or Mouse Right Click";
            this.help_label.UseCompatibleTextRendering = true;
            this.help_label.Visible = false;
            // 
            // help_button
            // 
            this.help_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.help_button.BackColor = System.Drawing.SystemColors.Control;
            this.help_button.BackgroundImage = global::View_GUI.Properties.Resources.win7_ico_shell32_dll_154;
            this.help_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.help_button.Location = new System.Drawing.Point(164, 404);
            this.help_button.Name = "help_button";
            this.help_button.Size = new System.Drawing.Size(34, 34);
            this.help_button.TabIndex = 3;
            this.help_button.UseVisualStyleBackColor = false;
            this.help_button.Click += new System.EventHandler(this.help_button_Click);
            // 
            // openFolder_button
            // 
            this.openFolder_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.openFolder_button.BackgroundImage = global::View_GUI.Properties.Resources.win7_ico_shell32_dll_0041;
            this.openFolder_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openFolder_button.Location = new System.Drawing.Point(79, 404);
            this.openFolder_button.Name = "openFolder_button";
            this.openFolder_button.Size = new System.Drawing.Size(28, 34);
            this.openFolder_button.TabIndex = 2;
            this.openFolder_button.UseVisualStyleBackColor = true;
            this.openFolder_button.Click += new System.EventHandler(this.openFolder_button_Click);
            // 
            // closeForm_button
            // 
            this.closeForm_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeForm_button.BackColor = System.Drawing.SystemColors.Control;
            this.closeForm_button.BackgroundImage = global::View_GUI.Properties.Resources.win7_ico_shell32_dll_131;
            this.closeForm_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeForm_button.Location = new System.Drawing.Point(124, 404);
            this.closeForm_button.Name = "closeForm_button";
            this.closeForm_button.Size = new System.Drawing.Size(34, 34);
            this.closeForm_button.TabIndex = 1;
            this.closeForm_button.UseVisualStyleBackColor = false;
            this.closeForm_button.Click += new System.EventHandler(this.closeForm_button_Click);
            // 
            // selectionScreenshot_button
            // 
            this.selectionScreenshot_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectionScreenshot_button.BackgroundImage = global::View_GUI.Properties.Resources.Actions_document_save_icon__1_;
            this.selectionScreenshot_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectionScreenshot_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectionScreenshot_button.Location = new System.Drawing.Point(39, 404);
            this.selectionScreenshot_button.Name = "selectionScreenshot_button";
            this.selectionScreenshot_button.Size = new System.Drawing.Size(34, 34);
            this.selectionScreenshot_button.TabIndex = 0;
            this.selectionScreenshot_button.UseVisualStyleBackColor = true;
            this.selectionScreenshot_button.Click += new System.EventHandler(this.selectionScreenshot_button_Click);
            // 
            // SelectionScreenshot_Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.help_label);
            this.Controls.Add(this.help_button);
            this.Controls.Add(this.openFolder_button);
            this.Controls.Add(this.closeForm_button);
            this.Controls.Add(this.selectionScreenshot_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectionScreenshot_Form4";
            this.Text = "SelectionScreenshot_Form4";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectionScreenshot_Form4_FormClosing);
            this.Load += new System.EventHandler(this.SelectionScreenshot_Form4_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectionScreenshot_Form4_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectionScreenshot_Form4_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SelectionScreenshot_Form4_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SelectionScreenshot_Form4_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectionScreenshot_button;
        private System.Windows.Forms.Button closeForm_button;
        private System.Windows.Forms.Button openFolder_button;
        private System.Windows.Forms.Button help_button;
        private System.Windows.Forms.Label help_label;
    }
}