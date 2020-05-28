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
            this.panel1 = new System.Windows.Forms.Panel();
            this.home_webBrowser = new System.Windows.Forms.WebBrowser();
            this.web_browser_Search_button = new System.Windows.Forms.Button();
            this.wbbeowser_Search_textBox = new System.Windows.Forms.TextBox();
            this.backgroundName_Top_panel.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::View_GUI.Properties.Resources.Long_4455;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.home_webBrowser);
            this.panel1.Controls.Add(this.web_browser_Search_button);
            this.panel1.Controls.Add(this.wbbeowser_Search_textBox);
            this.panel1.Location = new System.Drawing.Point(8, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1580, 640);
            this.panel1.TabIndex = 23;
            // 
            // home_webBrowser
            // 
            this.home_webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.home_webBrowser.Location = new System.Drawing.Point(23, 73);
            this.home_webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.home_webBrowser.Name = "home_webBrowser";
            this.home_webBrowser.Size = new System.Drawing.Size(1533, 540);
            this.home_webBrowser.TabIndex = 20;
            this.home_webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.home_webBrowser_Navigated);
            // 
            // web_browser_Search_button
            // 
            this.web_browser_Search_button.BackColor = System.Drawing.Color.Transparent;
            this.web_browser_Search_button.BackgroundImage = global::View_GUI.Properties.Resources.Actions_page_zoom_icon1;
            this.web_browser_Search_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.web_browser_Search_button.FlatAppearance.BorderSize = 0;
            this.web_browser_Search_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.web_browser_Search_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.web_browser_Search_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.web_browser_Search_button.Location = new System.Drawing.Point(1010, 42);
            this.web_browser_Search_button.Margin = new System.Windows.Forms.Padding(0);
            this.web_browser_Search_button.Name = "web_browser_Search_button";
            this.web_browser_Search_button.Size = new System.Drawing.Size(30, 30);
            this.web_browser_Search_button.TabIndex = 22;
            this.web_browser_Search_button.UseVisualStyleBackColor = false;
            this.web_browser_Search_button.Click += new System.EventHandler(this.web_browser_Search_button_Click);
            // 
            // wbbeowser_Search_textBox
            // 
            this.wbbeowser_Search_textBox.Location = new System.Drawing.Point(464, 47);
            this.wbbeowser_Search_textBox.Name = "wbbeowser_Search_textBox";
            this.wbbeowser_Search_textBox.Size = new System.Drawing.Size(540, 20);
            this.wbbeowser_Search_textBox.TabIndex = 21;
            this.wbbeowser_Search_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wbbeowser_Search_textBox_KeyDown);
            // 
            // Home_Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1600, 800);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.backgroundName_Top_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home_Form11";
            this.Text = "Home_Form11";
            this.Load += new System.EventHandler(this.Home_Form11_Load);
            this.MouseEnter += new System.EventHandler(this.Home_Form11_MouseEnter);
            this.backgroundName_Top_panel.ResumeLayout(false);
            this.backgroundName_Top_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Home_Top_label;
        private System.Windows.Forms.Panel backgroundName_Top_panel;
        private System.Windows.Forms.Button web_browser_Search_button;
        private System.Windows.Forms.TextBox wbbeowser_Search_textBox;
        private System.Windows.Forms.WebBrowser home_webBrowser;
        private System.Windows.Forms.Panel panel1;
    }
}