namespace View_GUI
{
    partial class Main_Body_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Body_Form));
            this.Main_Body_Loader_panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Main_Body_Loader_panel
            // 
            this.Main_Body_Loader_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Main_Body_Loader_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Body_Loader_panel.Location = new System.Drawing.Point(0, 0);
            this.Main_Body_Loader_panel.Name = "Main_Body_Loader_panel";
            this.Main_Body_Loader_panel.Size = new System.Drawing.Size(1584, 762);
            this.Main_Body_Loader_panel.TabIndex = 0;
            // 
            // Main_Body_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 762);
            this.Controls.Add(this.Main_Body_Loader_panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_Body_Form";
            this.Text = "Advokathuset";
            this.Load += new System.EventHandler(this.Main_Body_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Main_Body_Loader_panel;
    }
}