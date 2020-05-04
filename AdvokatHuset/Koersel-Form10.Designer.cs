namespace View_GUI
{
    partial class Koersel_Form10
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
            this.korsel_Top_label = new System.Windows.Forms.Label();
            this.backgroundName_Top_panel = new System.Windows.Forms.Panel();
            this.backgroundName_Top_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // korsel_Top_label
            // 
            this.korsel_Top_label.AutoSize = true;
            this.korsel_Top_label.Font = new System.Drawing.Font("Miriam CLM", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.korsel_Top_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(92)))));
            this.korsel_Top_label.Location = new System.Drawing.Point(11, 10);
            this.korsel_Top_label.Name = "korsel_Top_label";
            this.korsel_Top_label.Size = new System.Drawing.Size(67, 23);
            this.korsel_Top_label.TabIndex = 6;
            this.korsel_Top_label.Text = "Kørsel";
            // 
            // backgroundName_Top_panel
            // 
            this.backgroundName_Top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.backgroundName_Top_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundName_Top_panel.Controls.Add(this.korsel_Top_label);
            this.backgroundName_Top_panel.Location = new System.Drawing.Point(18, 58);
            this.backgroundName_Top_panel.Name = "backgroundName_Top_panel";
            this.backgroundName_Top_panel.Size = new System.Drawing.Size(90, 44);
            this.backgroundName_Top_panel.TabIndex = 7;
            // 
            // Koersel_Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backgroundName_Top_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Koersel_Form10";
            this.Text = "Koersel_Form10";
            this.backgroundName_Top_panel.ResumeLayout(false);
            this.backgroundName_Top_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label korsel_Top_label;
        private System.Windows.Forms.Panel backgroundName_Top_panel;
    }
}