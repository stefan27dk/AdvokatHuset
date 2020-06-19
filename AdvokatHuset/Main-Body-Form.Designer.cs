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
            this.opacity_trackBar = new System.Windows.Forms.TrackBar();
            this.opacity_min_button = new System.Windows.Forms.Button();
            this.opacity_max_button = new System.Windows.Forms.Button();
            this.TitleBar_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.close_form_button = new System.Windows.Forms.Button();
            this.minimize_button = new System.Windows.Forms.Button();
            this.Move_Form_Top_button = new System.Windows.Forms.Button();
            this.maximize_button = new System.Windows.Forms.Button();
            this.Move_Form_Bottom_button = new System.Windows.Forms.Button();
            this.Normal_Size_Form_button = new System.Windows.Forms.Button();
            this.Show_Only_TitleBar_button = new System.Windows.Forms.Button();
            this.Form_Screenshot_button_button = new System.Windows.Forms.Button();
            this.allays_on_top_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.opacity_trackBar)).BeginInit();
            this.TitleBar_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_Body_Loader_panel
            // 
            this.Main_Body_Loader_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_Body_Loader_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.Main_Body_Loader_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Main_Body_Loader_panel.Location = new System.Drawing.Point(0, 38);
            this.Main_Body_Loader_panel.Name = "Main_Body_Loader_panel";
            this.Main_Body_Loader_panel.Size = new System.Drawing.Size(1601, 741);
            this.Main_Body_Loader_panel.TabIndex = 0;
            // 
            // opacity_trackBar
            // 
            this.opacity_trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.opacity_trackBar.AutoSize = false;
            this.opacity_trackBar.LargeChange = 1;
            this.opacity_trackBar.Location = new System.Drawing.Point(1475, 779);
            this.opacity_trackBar.Maximum = 100;
            this.opacity_trackBar.Minimum = 30;
            this.opacity_trackBar.Name = "opacity_trackBar";
            this.opacity_trackBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.opacity_trackBar.Size = new System.Drawing.Size(104, 32);
            this.opacity_trackBar.TabIndex = 0;
            this.opacity_trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.opacity_trackBar.Value = 100;
            this.opacity_trackBar.ValueChanged += new System.EventHandler(this.opacity_trackBar_ValueChanged);
            // 
            // opacity_min_button
            // 
            this.opacity_min_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.opacity_min_button.BackColor = System.Drawing.Color.Transparent;
            this.opacity_min_button.BackgroundImage = global::View_GUI.Properties.Resources.To_Bar_Only_11111;
            this.opacity_min_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.opacity_min_button.FlatAppearance.BorderSize = 0;
            this.opacity_min_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.opacity_min_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.opacity_min_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opacity_min_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.opacity_min_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.opacity_min_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opacity_min_button.Location = new System.Drawing.Point(1373, 785);
            this.opacity_min_button.Margin = new System.Windows.Forms.Padding(0);
            this.opacity_min_button.Name = "opacity_min_button";
            this.opacity_min_button.Size = new System.Drawing.Size(24, 26);
            this.opacity_min_button.TabIndex = 46;
            this.opacity_min_button.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.opacity_min_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.opacity_min_button.UseVisualStyleBackColor = false;
            // 
            // opacity_max_button
            // 
            this.opacity_max_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.opacity_max_button.BackColor = System.Drawing.Color.Transparent;
            this.opacity_max_button.BackgroundImage = global::View_GUI.Properties.Resources.Left_Arrow_1243;
            this.opacity_max_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opacity_max_button.FlatAppearance.BorderSize = 0;
            this.opacity_max_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.opacity_max_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.opacity_max_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opacity_max_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.opacity_max_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.opacity_max_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opacity_max_button.Location = new System.Drawing.Point(1454, 782);
            this.opacity_max_button.Margin = new System.Windows.Forms.Padding(0);
            this.opacity_max_button.Name = "opacity_max_button";
            this.opacity_max_button.Size = new System.Drawing.Size(18, 19);
            this.opacity_max_button.TabIndex = 45;
            this.opacity_max_button.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.opacity_max_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.opacity_max_button.UseVisualStyleBackColor = false;
            // 
            // TitleBar_panel
            // 
            this.TitleBar_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleBar_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TitleBar_panel.BackColor = System.Drawing.Color.Transparent;
            this.TitleBar_panel.BackgroundImage = global::View_GUI.Properties.Resources._23424;
            this.TitleBar_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TitleBar_panel.CausesValidation = false;
            this.TitleBar_panel.Controls.Add(this.panel1);
            this.TitleBar_panel.Controls.Add(this.close_form_button);
            this.TitleBar_panel.Controls.Add(this.minimize_button);
            this.TitleBar_panel.Controls.Add(this.Move_Form_Top_button);
            this.TitleBar_panel.Controls.Add(this.maximize_button);
            this.TitleBar_panel.Controls.Add(this.Move_Form_Bottom_button);
            this.TitleBar_panel.Controls.Add(this.Normal_Size_Form_button);
            this.TitleBar_panel.Controls.Add(this.Show_Only_TitleBar_button);
            this.TitleBar_panel.Controls.Add(this.Form_Screenshot_button_button);
            this.TitleBar_panel.Controls.Add(this.allays_on_top_button);
            this.TitleBar_panel.Location = new System.Drawing.Point(0, 0);
            this.TitleBar_panel.Name = "TitleBar_panel";
            this.TitleBar_panel.Size = new System.Drawing.Size(1608, 38);
            this.TitleBar_panel.TabIndex = 1;
            this.TitleBar_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_panel_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(471, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(70, 22);
            this.panel1.TabIndex = 0;
            // 
            // close_form_button
            // 
            this.close_form_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close_form_button.BackColor = System.Drawing.Color.Transparent;
            this.close_form_button.BackgroundImage = global::View_GUI.Properties.Resources.Exit_Form14321;
            this.close_form_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.close_form_button.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.close_form_button.FlatAppearance.BorderSize = 0;
            this.close_form_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.close_form_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.close_form_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_form_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close_form_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.close_form_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.close_form_button.Location = new System.Drawing.Point(1567, 4);
            this.close_form_button.Margin = new System.Windows.Forms.Padding(0);
            this.close_form_button.Name = "close_form_button";
            this.close_form_button.Size = new System.Drawing.Size(25, 25);
            this.close_form_button.TabIndex = 33;
            this.close_form_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.close_form_button.UseVisualStyleBackColor = false;
            this.close_form_button.Click += new System.EventHandler(this.close_form_button_Click);
            this.close_form_button.MouseEnter += new System.EventHandler(this.close_form_button_MouseEnter);
            this.close_form_button.MouseLeave += new System.EventHandler(this.close_form_button_MouseLeave);
            // 
            // minimize_button
            // 
            this.minimize_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimize_button.BackColor = System.Drawing.Color.Transparent;
            this.minimize_button.BackgroundImage = global::View_GUI.Properties.Resources.Minimize12342;
            this.minimize_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minimize_button.FlatAppearance.BorderSize = 0;
            this.minimize_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.minimize_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.minimize_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minimize_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.minimize_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.minimize_button.Location = new System.Drawing.Point(1473, 7);
            this.minimize_button.Margin = new System.Windows.Forms.Padding(0);
            this.minimize_button.Name = "minimize_button";
            this.minimize_button.Size = new System.Drawing.Size(32, 20);
            this.minimize_button.TabIndex = 34;
            this.minimize_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.minimize_button.UseVisualStyleBackColor = false;
            this.minimize_button.Click += new System.EventHandler(this.minimize_button_Click);
            this.minimize_button.MouseEnter += new System.EventHandler(this.minimize_button_MouseEnter);
            this.minimize_button.MouseLeave += new System.EventHandler(this.minimize_button_MouseLeave);
            // 
            // Move_Form_Top_button
            // 
            this.Move_Form_Top_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Move_Form_Top_button.BackColor = System.Drawing.Color.Transparent;
            this.Move_Form_Top_button.BackgroundImage = global::View_GUI.Properties.Resources.Top777777;
            this.Move_Form_Top_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Move_Form_Top_button.FlatAppearance.BorderSize = 0;
            this.Move_Form_Top_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Move_Form_Top_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.Move_Form_Top_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Move_Form_Top_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Move_Form_Top_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Move_Form_Top_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Move_Form_Top_button.Location = new System.Drawing.Point(1224, 1);
            this.Move_Form_Top_button.Margin = new System.Windows.Forms.Padding(0);
            this.Move_Form_Top_button.Name = "Move_Form_Top_button";
            this.Move_Form_Top_button.Size = new System.Drawing.Size(33, 32);
            this.Move_Form_Top_button.TabIndex = 37;
            this.Move_Form_Top_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Move_Form_Top_button.UseVisualStyleBackColor = false;
            this.Move_Form_Top_button.Click += new System.EventHandler(this.Move_Form_Top_button_Click);
            // 
            // maximize_button
            // 
            this.maximize_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximize_button.BackColor = System.Drawing.Color.Transparent;
            this.maximize_button.BackgroundImage = global::View_GUI.Properties.Resources.Hover_Maximize_Now;
            this.maximize_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.maximize_button.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.maximize_button.FlatAppearance.BorderSize = 0;
            this.maximize_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.maximize_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.maximize_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximize_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maximize_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.maximize_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.maximize_button.Location = new System.Drawing.Point(1516, 0);
            this.maximize_button.Margin = new System.Windows.Forms.Padding(0);
            this.maximize_button.Name = "maximize_button";
            this.maximize_button.Size = new System.Drawing.Size(40, 35);
            this.maximize_button.TabIndex = 35;
            this.maximize_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.maximize_button.UseVisualStyleBackColor = false;
            this.maximize_button.Click += new System.EventHandler(this.maximize_button_Click);
            this.maximize_button.MouseEnter += new System.EventHandler(this.maximize_button_MouseEnter);
            this.maximize_button.MouseLeave += new System.EventHandler(this.maximize_button_MouseLeave);
            // 
            // Move_Form_Bottom_button
            // 
            this.Move_Form_Bottom_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Move_Form_Bottom_button.BackColor = System.Drawing.Color.Transparent;
            this.Move_Form_Bottom_button.BackgroundImage = global::View_GUI.Properties.Resources.Bottom5555;
            this.Move_Form_Bottom_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Move_Form_Bottom_button.FlatAppearance.BorderSize = 0;
            this.Move_Form_Bottom_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Move_Form_Bottom_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.Move_Form_Bottom_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Move_Form_Bottom_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Move_Form_Bottom_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Move_Form_Bottom_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Move_Form_Bottom_button.Location = new System.Drawing.Point(1182, 1);
            this.Move_Form_Bottom_button.Margin = new System.Windows.Forms.Padding(0);
            this.Move_Form_Bottom_button.Name = "Move_Form_Bottom_button";
            this.Move_Form_Bottom_button.Size = new System.Drawing.Size(33, 32);
            this.Move_Form_Bottom_button.TabIndex = 41;
            this.Move_Form_Bottom_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Move_Form_Bottom_button.UseVisualStyleBackColor = false;
            this.Move_Form_Bottom_button.Click += new System.EventHandler(this.Move_Form_Bottom_button_Click);
            // 
            // Normal_Size_Form_button
            // 
            this.Normal_Size_Form_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Normal_Size_Form_button.BackColor = System.Drawing.Color.Transparent;
            this.Normal_Size_Form_button.BackgroundImage = global::View_GUI.Properties.Resources.Center32222;
            this.Normal_Size_Form_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Normal_Size_Form_button.FlatAppearance.BorderSize = 0;
            this.Normal_Size_Form_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Normal_Size_Form_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.Normal_Size_Form_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Normal_Size_Form_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Normal_Size_Form_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Normal_Size_Form_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Normal_Size_Form_button.Location = new System.Drawing.Point(1139, 1);
            this.Normal_Size_Form_button.Margin = new System.Windows.Forms.Padding(0);
            this.Normal_Size_Form_button.Name = "Normal_Size_Form_button";
            this.Normal_Size_Form_button.Size = new System.Drawing.Size(33, 32);
            this.Normal_Size_Form_button.TabIndex = 42;
            this.Normal_Size_Form_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Normal_Size_Form_button.UseVisualStyleBackColor = false;
            this.Normal_Size_Form_button.Click += new System.EventHandler(this.Normal_Size_Form_button_Click);
            // 
            // Show_Only_TitleBar_button
            // 
            this.Show_Only_TitleBar_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Show_Only_TitleBar_button.BackColor = System.Drawing.Color.Transparent;
            this.Show_Only_TitleBar_button.BackgroundImage = global::View_GUI.Properties.Resources.To_Bar_Only_11111;
            this.Show_Only_TitleBar_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Show_Only_TitleBar_button.FlatAppearance.BorderSize = 0;
            this.Show_Only_TitleBar_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Show_Only_TitleBar_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.Show_Only_TitleBar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Show_Only_TitleBar_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Show_Only_TitleBar_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Show_Only_TitleBar_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Show_Only_TitleBar_button.Location = new System.Drawing.Point(1095, 1);
            this.Show_Only_TitleBar_button.Margin = new System.Windows.Forms.Padding(0);
            this.Show_Only_TitleBar_button.Name = "Show_Only_TitleBar_button";
            this.Show_Only_TitleBar_button.Size = new System.Drawing.Size(33, 32);
            this.Show_Only_TitleBar_button.TabIndex = 43;
            this.Show_Only_TitleBar_button.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Show_Only_TitleBar_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Show_Only_TitleBar_button.UseVisualStyleBackColor = false;
            this.Show_Only_TitleBar_button.Click += new System.EventHandler(this.Show_Only_TitleBar_button_Click);
            // 
            // Form_Screenshot_button_button
            // 
            this.Form_Screenshot_button_button.BackColor = System.Drawing.Color.Transparent;
            this.Form_Screenshot_button_button.BackgroundImage = global::View_GUI.Properties.Resources.Camera_Next_icon3;
            this.Form_Screenshot_button_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Form_Screenshot_button_button.FlatAppearance.BorderSize = 0;
            this.Form_Screenshot_button_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Form_Screenshot_button_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.Form_Screenshot_button_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Form_Screenshot_button_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Form_Screenshot_button_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Form_Screenshot_button_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Form_Screenshot_button_button.Location = new System.Drawing.Point(21, 4);
            this.Form_Screenshot_button_button.Margin = new System.Windows.Forms.Padding(0);
            this.Form_Screenshot_button_button.Name = "Form_Screenshot_button_button";
            this.Form_Screenshot_button_button.Size = new System.Drawing.Size(41, 29);
            this.Form_Screenshot_button_button.TabIndex = 44;
            this.Form_Screenshot_button_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Form_Screenshot_button_button.UseVisualStyleBackColor = false;
            this.Form_Screenshot_button_button.Click += new System.EventHandler(this.Form_Screenshot_button_button_Click);
            // 
            // allays_on_top_button
            // 
            this.allays_on_top_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.allays_on_top_button.BackColor = System.Drawing.Color.Transparent;
            this.allays_on_top_button.BackgroundImage = global::View_GUI.Properties.Resources.flash_kard_icon__1___5___3_1;
            this.allays_on_top_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.allays_on_top_button.FlatAppearance.BorderSize = 0;
            this.allays_on_top_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.allays_on_top_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.allays_on_top_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.allays_on_top_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allays_on_top_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.allays_on_top_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.allays_on_top_button.Location = new System.Drawing.Point(1267, 2);
            this.allays_on_top_button.Margin = new System.Windows.Forms.Padding(0);
            this.allays_on_top_button.Name = "allays_on_top_button";
            this.allays_on_top_button.Size = new System.Drawing.Size(33, 32);
            this.allays_on_top_button.TabIndex = 36;
            this.allays_on_top_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.allays_on_top_button.UseVisualStyleBackColor = false;
            this.allays_on_top_button.Click += new System.EventHandler(this.allays_on_top_button_Click);
            // 
            // Main_Body_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1601, 800);
            this.Controls.Add(this.opacity_min_button);
            this.Controls.Add(this.opacity_max_button);
            this.Controls.Add(this.opacity_trackBar);
            this.Controls.Add(this.TitleBar_panel);
            this.Controls.Add(this.Main_Body_Loader_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "Main_Body_Form";
            this.Text = "Advokathuset";
            this.Load += new System.EventHandler(this.Main_Body_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.opacity_trackBar)).EndInit();
            this.TitleBar_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Main_Body_Loader_panel;
        private System.Windows.Forms.Panel TitleBar_panel;
        private System.Windows.Forms.Button close_form_button;
        private System.Windows.Forms.Button minimize_button;
        private System.Windows.Forms.Button maximize_button;
        private System.Windows.Forms.Button allays_on_top_button;
        private System.Windows.Forms.Button Move_Form_Top_button;
        private System.Windows.Forms.Button Move_Form_Bottom_button;
        private System.Windows.Forms.Button Normal_Size_Form_button;
        private System.Windows.Forms.Button Show_Only_TitleBar_button;
        private System.Windows.Forms.Button Form_Screenshot_button_button;
        private System.Windows.Forms.TrackBar opacity_trackBar;
        private System.Windows.Forms.Button opacity_max_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button opacity_min_button;
    }
}