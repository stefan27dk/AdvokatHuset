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
            this.browser_back_panel = new System.Windows.Forms.Panel();
            this.home_webBrowser = new System.Windows.Forms.WebBrowser();
            this.wbbeowser_Search_textBox = new System.Windows.Forms.TextBox();
            this.Browser_menu_panel = new System.Windows.Forms.Panel();
            this.web_browser_google_button = new System.Windows.Forms.Button();
            this.Web_Browser_Home_button = new System.Windows.Forms.Button();
            this.browser_back_button = new System.Windows.Forms.Button();
            this.web_browser_Search_button = new System.Windows.Forms.Button();
            this.Webbrowser_Gog_Forward_button = new System.Windows.Forms.Button();
            this.backgroundName_Top_panel.SuspendLayout();
            this.browser_back_panel.SuspendLayout();
            this.Browser_menu_panel.SuspendLayout();
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
            // browser_back_panel
            // 
            this.browser_back_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browser_back_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.browser_back_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.browser_back_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.browser_back_panel.Controls.Add(this.Browser_menu_panel);
            this.browser_back_panel.Controls.Add(this.home_webBrowser);
            this.browser_back_panel.Location = new System.Drawing.Point(66, 108);
            this.browser_back_panel.Name = "browser_back_panel";
            this.browser_back_panel.Size = new System.Drawing.Size(1454, 640);
            this.browser_back_panel.TabIndex = 23;
            // 
            // home_webBrowser
            // 
            this.home_webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.home_webBrowser.Location = new System.Drawing.Point(1, 52);
            this.home_webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.home_webBrowser.Name = "home_webBrowser";
            this.home_webBrowser.Size = new System.Drawing.Size(1448, 583);
            this.home_webBrowser.TabIndex = 20;
            this.home_webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.home_webBrowser_Navigated);
            // 
            // wbbeowser_Search_textBox
            // 
            this.wbbeowser_Search_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.wbbeowser_Search_textBox.Location = new System.Drawing.Point(467, 13);
            this.wbbeowser_Search_textBox.Name = "wbbeowser_Search_textBox";
            this.wbbeowser_Search_textBox.Size = new System.Drawing.Size(540, 20);
            this.wbbeowser_Search_textBox.TabIndex = 21;
            this.wbbeowser_Search_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wbbeowser_Search_textBox_KeyDown);
            // 
            // Browser_menu_panel
            // 
            this.Browser_menu_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Browser_menu_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.Browser_menu_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Browser_menu_panel.Controls.Add(this.web_browser_google_button);
            this.Browser_menu_panel.Controls.Add(this.Web_Browser_Home_button);
            this.Browser_menu_panel.Controls.Add(this.browser_back_button);
            this.Browser_menu_panel.Controls.Add(this.web_browser_Search_button);
            this.Browser_menu_panel.Controls.Add(this.Webbrowser_Gog_Forward_button);
            this.Browser_menu_panel.Controls.Add(this.wbbeowser_Search_textBox);
            this.Browser_menu_panel.Location = new System.Drawing.Point(1, 1);
            this.Browser_menu_panel.Name = "Browser_menu_panel";
            this.Browser_menu_panel.Size = new System.Drawing.Size(1450, 48);
            this.Browser_menu_panel.TabIndex = 24;
            // 
            // web_browser_google_button
            // 
            this.web_browser_google_button.BackColor = System.Drawing.Color.Transparent;
            this.web_browser_google_button.BackgroundImage = global::View_GUI.Properties.Resources._360_Chrome_icon;
            this.web_browser_google_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.web_browser_google_button.FlatAppearance.BorderSize = 0;
            this.web_browser_google_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.web_browser_google_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.web_browser_google_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.web_browser_google_button.Location = new System.Drawing.Point(152, 2);
            this.web_browser_google_button.Margin = new System.Windows.Forms.Padding(0);
            this.web_browser_google_button.Name = "web_browser_google_button";
            this.web_browser_google_button.Size = new System.Drawing.Size(45, 43);
            this.web_browser_google_button.TabIndex = 26;
            this.web_browser_google_button.UseVisualStyleBackColor = false;
            this.web_browser_google_button.Click += new System.EventHandler(this.web_browser_google_button_Click);
            // 
            // Web_Browser_Home_button
            // 
            this.Web_Browser_Home_button.BackColor = System.Drawing.Color.Transparent;
            this.Web_Browser_Home_button.BackgroundImage = global::View_GUI.Properties.Resources.Actions_home_icon;
            this.Web_Browser_Home_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Web_Browser_Home_button.FlatAppearance.BorderSize = 0;
            this.Web_Browser_Home_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Web_Browser_Home_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.Web_Browser_Home_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Web_Browser_Home_button.Location = new System.Drawing.Point(54, 13);
            this.Web_Browser_Home_button.Margin = new System.Windows.Forms.Padding(0);
            this.Web_Browser_Home_button.Name = "Web_Browser_Home_button";
            this.Web_Browser_Home_button.Size = new System.Drawing.Size(30, 30);
            this.Web_Browser_Home_button.TabIndex = 25;
            this.Web_Browser_Home_button.UseVisualStyleBackColor = false;
            this.Web_Browser_Home_button.Click += new System.EventHandler(this.Web_Browser_Home_button_Click);
            // 
            // browser_back_button
            // 
            this.browser_back_button.BackColor = System.Drawing.Color.Transparent;
            this.browser_back_button.BackgroundImage = global::View_GUI.Properties.Resources.navigate_left_icon__1_;
            this.browser_back_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.browser_back_button.FlatAppearance.BorderSize = 0;
            this.browser_back_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.browser_back_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.browser_back_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browser_back_button.Location = new System.Drawing.Point(10, 13);
            this.browser_back_button.Margin = new System.Windows.Forms.Padding(0);
            this.browser_back_button.Name = "browser_back_button";
            this.browser_back_button.Size = new System.Drawing.Size(30, 30);
            this.browser_back_button.TabIndex = 23;
            this.browser_back_button.UseVisualStyleBackColor = false;
            this.browser_back_button.Click += new System.EventHandler(this.browser_back_button_Click);
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
            this.web_browser_Search_button.Location = new System.Drawing.Point(1019, 9);
            this.web_browser_Search_button.Margin = new System.Windows.Forms.Padding(0);
            this.web_browser_Search_button.Name = "web_browser_Search_button";
            this.web_browser_Search_button.Size = new System.Drawing.Size(30, 30);
            this.web_browser_Search_button.TabIndex = 22;
            this.web_browser_Search_button.UseVisualStyleBackColor = false;
            this.web_browser_Search_button.Click += new System.EventHandler(this.web_browser_Search_button_Click);
            // 
            // Webbrowser_Gog_Forward_button
            // 
            this.Webbrowser_Gog_Forward_button.BackColor = System.Drawing.Color.Transparent;
            this.Webbrowser_Gog_Forward_button.BackgroundImage = global::View_GUI.Properties.Resources.navigate_left_icon__1___1_;
            this.Webbrowser_Gog_Forward_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Webbrowser_Gog_Forward_button.FlatAppearance.BorderSize = 0;
            this.Webbrowser_Gog_Forward_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Webbrowser_Gog_Forward_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.Webbrowser_Gog_Forward_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Webbrowser_Gog_Forward_button.Location = new System.Drawing.Point(94, 13);
            this.Webbrowser_Gog_Forward_button.Margin = new System.Windows.Forms.Padding(0);
            this.Webbrowser_Gog_Forward_button.Name = "Webbrowser_Gog_Forward_button";
            this.Webbrowser_Gog_Forward_button.Size = new System.Drawing.Size(30, 30);
            this.Webbrowser_Gog_Forward_button.TabIndex = 24;
            this.Webbrowser_Gog_Forward_button.UseVisualStyleBackColor = false;
            this.Webbrowser_Gog_Forward_button.Click += new System.EventHandler(this.Webbrowser_Go_Forward_button_Click);
            // 
            // Home_Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1600, 800);
            this.Controls.Add(this.browser_back_panel);
            this.Controls.Add(this.backgroundName_Top_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home_Form11";
            this.Text = "Home_Form11";
            this.Load += new System.EventHandler(this.Home_Form11_Load);
            this.MouseEnter += new System.EventHandler(this.Home_Form11_MouseEnter);
            this.backgroundName_Top_panel.ResumeLayout(false);
            this.backgroundName_Top_panel.PerformLayout();
            this.browser_back_panel.ResumeLayout(false);
            this.Browser_menu_panel.ResumeLayout(false);
            this.Browser_menu_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Home_Top_label;
        private System.Windows.Forms.Panel backgroundName_Top_panel;
        private System.Windows.Forms.Button web_browser_Search_button;
        private System.Windows.Forms.TextBox wbbeowser_Search_textBox;
        private System.Windows.Forms.WebBrowser home_webBrowser;
        private System.Windows.Forms.Panel browser_back_panel;
        private System.Windows.Forms.Button browser_back_button;
        private System.Windows.Forms.Button Webbrowser_Gog_Forward_button;
        private System.Windows.Forms.Button Web_Browser_Home_button;
        private System.Windows.Forms.Panel Browser_menu_panel;
        private System.Windows.Forms.Button web_browser_google_button;
    }
}