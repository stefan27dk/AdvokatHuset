namespace View_GUI
{
    partial class Transparent_Form
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
            this.pointer_hole_panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pointer_hole_panel
            // 
            this.pointer_hole_panel.BackColor = System.Drawing.Color.Blue;
            this.pointer_hole_panel.Location = new System.Drawing.Point(194, 184);
            this.pointer_hole_panel.Name = "pointer_hole_panel";
            this.pointer_hole_panel.Size = new System.Drawing.Size(1, 1);
            this.pointer_hole_panel.TabIndex = 0;
            // 
            // Transparent_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pointer_hole_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Transparent_Form";
            this.Opacity = 0.2D;
            this.Text = "Transparent_Form";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Transparent_Form_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Transparent_Form_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pointer_hole_panel;
    }
}