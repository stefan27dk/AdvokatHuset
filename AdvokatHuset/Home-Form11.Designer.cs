namespace View_GUI
{
    partial class Home_Form11
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
            this.Home_Top_label = new System.Windows.Forms.Label();
            this.backgroundName_Top_panel = new System.Windows.Forms.Panel();
            this.backgroundName_Top_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Home_Top_label
            // 
            this.Home_Top_label.AutoSize = true;
            this.Home_Top_label.Font = new System.Drawing.Font("Miriam CLM", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Home_Top_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(92)))));
            this.Home_Top_label.Location = new System.Drawing.Point(8, 9);
            this.Home_Top_label.Name = "Home_Top_label";
            this.Home_Top_label.Size = new System.Drawing.Size(53, 23);
            this.Home_Top_label.TabIndex = 2;
            this.Home_Top_label.Text = "Start";
            // 
            // backgroundName_Top_panel
            // 
            this.backgroundName_Top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.backgroundName_Top_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundName_Top_panel.Controls.Add(this.Home_Top_label);
            this.backgroundName_Top_panel.Location = new System.Drawing.Point(18, 58);
            this.backgroundName_Top_panel.Name = "backgroundName_Top_panel";
            this.backgroundName_Top_panel.Size = new System.Drawing.Size(70, 44);
            this.backgroundName_Top_panel.TabIndex = 8;
            // 
            // Home_Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.backgroundName_Top_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home_Form11";
            this.Text = "Home_Form11";
            this.backgroundName_Top_panel.ResumeLayout(false);
            this.backgroundName_Top_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Home_Top_label;
        private System.Windows.Forms.Panel backgroundName_Top_panel;
    }
}