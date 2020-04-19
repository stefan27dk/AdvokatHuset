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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.advokatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sekretærToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visAlleMedarbejderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opretSagToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.visSagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opretAdvokatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.visAdvokaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opretSekretærToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.visAlleSekretærToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel_Loader = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sagToolStripMenuItem,
            this.advokatToolStripMenuItem,
            this.sekretærToolStripMenuItem,
            this.visAlleMedarbejderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(973, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // advokatToolStripMenuItem
            // 
            this.advokatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opretAdvokatToolStripMenuItem1,
            this.visAdvokaterToolStripMenuItem});
            this.advokatToolStripMenuItem.Name = "advokatToolStripMenuItem";
            this.advokatToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.advokatToolStripMenuItem.Text = "Advokater";
            this.advokatToolStripMenuItem.Click += new System.EventHandler(this.advokatToolStripMenuItem_Click);
            // 
            // sekretærToolStripMenuItem
            // 
            this.sekretærToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opretSekretærToolStripMenuItem1,
            this.visAlleSekretærToolStripMenuItem});
            this.sekretærToolStripMenuItem.Name = "sekretærToolStripMenuItem";
            this.sekretærToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.sekretærToolStripMenuItem.Text = "Sekretær";
            // 
            // visAlleMedarbejderToolStripMenuItem
            // 
            this.visAlleMedarbejderToolStripMenuItem.Name = "visAlleMedarbejderToolStripMenuItem";
            this.visAlleMedarbejderToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.visAlleMedarbejderToolStripMenuItem.Text = "Vis alle medarbejder";
            // 
            // sagToolStripMenuItem
            // 
            this.sagToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opretSagToolStripMenuItem1,
            this.visSagerToolStripMenuItem});
            this.sagToolStripMenuItem.Name = "sagToolStripMenuItem";
            this.sagToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.sagToolStripMenuItem.Text = "Sager";
            this.sagToolStripMenuItem.Click += new System.EventHandler(this.sagToolStripMenuItem_Click);
            // 
            // opretSagToolStripMenuItem1
            // 
            this.opretSagToolStripMenuItem1.Name = "opretSagToolStripMenuItem1";
            this.opretSagToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.opretSagToolStripMenuItem1.Text = "Opret Sag";
            // 
            // visSagerToolStripMenuItem
            // 
            this.visSagerToolStripMenuItem.Name = "visSagerToolStripMenuItem";
            this.visSagerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.visSagerToolStripMenuItem.Text = "Vis Sager";
            // 
            // opretAdvokatToolStripMenuItem1
            // 
            this.opretAdvokatToolStripMenuItem1.Name = "opretAdvokatToolStripMenuItem1";
            this.opretAdvokatToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.opretAdvokatToolStripMenuItem1.Text = "Opret Advokat";
            // 
            // visAdvokaterToolStripMenuItem
            // 
            this.visAdvokaterToolStripMenuItem.Name = "visAdvokaterToolStripMenuItem";
            this.visAdvokaterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.visAdvokaterToolStripMenuItem.Text = "Vis Advokater";
            // 
            // opretSekretærToolStripMenuItem1
            // 
            this.opretSekretærToolStripMenuItem1.Name = "opretSekretærToolStripMenuItem1";
            this.opretSekretærToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.opretSekretærToolStripMenuItem1.Text = "Opret Sekretær";
            // 
            // visAlleSekretærToolStripMenuItem
            // 
            this.visAlleSekretærToolStripMenuItem.Name = "visAlleSekretærToolStripMenuItem";
            this.visAlleSekretærToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.visAlleSekretærToolStripMenuItem.Text = "Vis alle Sekretær";
            // 
            // Panel_Loader
            // 
            this.Panel_Loader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Panel_Loader.Location = new System.Drawing.Point(0, 27);
            this.Panel_Loader.Name = "Panel_Loader";
            this.Panel_Loader.Size = new System.Drawing.Size(973, 502);
            this.Panel_Loader.TabIndex = 9;
            // 
            // Main_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 527);
            this.Controls.Add(this.Panel_Loader);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Main_Form1";
            this.Text = "Main_Form1";
            this.Load += new System.EventHandler(this.Main_Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem advokatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sekretærToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visAlleMedarbejderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opretSagToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem visSagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opretAdvokatToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem visAdvokaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opretSekretærToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem visAlleSekretærToolStripMenuItem;
        private System.Windows.Forms.Panel Panel_Loader;
    }
}