namespace View_GUI
{
    partial class Kunder_Form9
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
            this.Kunde_Top_label = new System.Windows.Forms.Label();
            this.backgroundName_Top_panel = new System.Windows.Forms.Panel();
            this.kunder_name_textBox = new System.Windows.Forms.TextBox();
            this.backPanel_Textboxes_panel = new System.Windows.Forms.Panel();
            this.kunde_email_textBox = new System.Windows.Forms.TextBox();
            this.kunder_adr_textBox = new System.Windows.Forms.TextBox();
            this.background_textboxes_top_panel = new System.Windows.Forms.Panel();
            this.opret_Kunder_label = new System.Windows.Forms.Label();
            this.kunder_zipcCode_textBox = new System.Windows.Forms.TextBox();
            this.kunder_tlf_textBox = new System.Windows.Forms.TextBox();
            this.kunder_surname_textBox = new System.Windows.Forms.TextBox();
            this.datagridviewBackground_panel = new System.Windows.Forms.Panel();
            this.Kunde_dataGridView = new System.Windows.Forms.DataGridView();
            this.finished_checkBox = new System.Windows.Forms.CheckBox();
            this.search_options_comboBox = new System.Windows.Forms.ComboBox();
            this.search_textBox = new System.Windows.Forms.TextBox();
            this.SAVE_BUTTON_KUNDE_TLF = new System.Windows.Forms.Button();
            this.print_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.screenshot_datagridview_button = new System.Windows.Forms.Button();
            this.undo_button = new System.Windows.Forms.Button();
            this.show_all_button = new System.Windows.Forms.Button();
            this.show_Tlf_Nr_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vis_rediger_kunder_button = new System.Windows.Forms.Button();
            this.opret_kunde_button = new System.Windows.Forms.Button();
            this.email_label = new System.Windows.Forms.Label();
            this.kunder_Save_button = new System.Windows.Forms.Button();
            this.adr_label = new System.Windows.Forms.Label();
            this.zipCode_label = new System.Windows.Forms.Label();
            this.tlf_label = new System.Windows.Forms.Label();
            this.surname_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.backgroundName_Top_panel.SuspendLayout();
            this.backPanel_Textboxes_panel.SuspendLayout();
            this.background_textboxes_top_panel.SuspendLayout();
            this.datagridviewBackground_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Kunde_dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Kunde_Top_label
            // 
            this.Kunde_Top_label.AutoSize = true;
            this.Kunde_Top_label.Font = new System.Drawing.Font("Miriam CLM", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Kunde_Top_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(92)))));
            this.Kunde_Top_label.Location = new System.Drawing.Point(11, 10);
            this.Kunde_Top_label.Name = "Kunde_Top_label";
            this.Kunde_Top_label.Size = new System.Drawing.Size(74, 23);
            this.Kunde_Top_label.TabIndex = 0;
            this.Kunde_Top_label.Text = "Kunder";
            // 
            // backgroundName_Top_panel
            // 
            this.backgroundName_Top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.backgroundName_Top_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundName_Top_panel.Controls.Add(this.Kunde_Top_label);
            this.backgroundName_Top_panel.Location = new System.Drawing.Point(18, 58);
            this.backgroundName_Top_panel.Name = "backgroundName_Top_panel";
            this.backgroundName_Top_panel.Size = new System.Drawing.Size(95, 44);
            this.backgroundName_Top_panel.TabIndex = 9;
            // 
            // kunder_name_textBox
            // 
            this.kunder_name_textBox.Location = new System.Drawing.Point(158, 63);
            this.kunder_name_textBox.MaxLength = 49;
            this.kunder_name_textBox.Name = "kunder_name_textBox";
            this.kunder_name_textBox.Size = new System.Drawing.Size(100, 20);
            this.kunder_name_textBox.TabIndex = 10;
            this.kunder_name_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kunder_name_textBox_KeyPress);
            // 
            // backPanel_Textboxes_panel
            // 
            this.backPanel_Textboxes_panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.backPanel_Textboxes_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.backPanel_Textboxes_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backPanel_Textboxes_panel.Controls.Add(this.email_label);
            this.backPanel_Textboxes_panel.Controls.Add(this.kunde_email_textBox);
            this.backPanel_Textboxes_panel.Controls.Add(this.kunder_Save_button);
            this.backPanel_Textboxes_panel.Controls.Add(this.adr_label);
            this.backPanel_Textboxes_panel.Controls.Add(this.kunder_adr_textBox);
            this.backPanel_Textboxes_panel.Controls.Add(this.background_textboxes_top_panel);
            this.backPanel_Textboxes_panel.Controls.Add(this.zipCode_label);
            this.backPanel_Textboxes_panel.Controls.Add(this.kunder_zipcCode_textBox);
            this.backPanel_Textboxes_panel.Controls.Add(this.tlf_label);
            this.backPanel_Textboxes_panel.Controls.Add(this.kunder_tlf_textBox);
            this.backPanel_Textboxes_panel.Controls.Add(this.surname_label);
            this.backPanel_Textboxes_panel.Controls.Add(this.kunder_surname_textBox);
            this.backPanel_Textboxes_panel.Controls.Add(this.name_label);
            this.backPanel_Textboxes_panel.Controls.Add(this.kunder_name_textBox);
            this.backPanel_Textboxes_panel.Location = new System.Drawing.Point(500, 170);
            this.backPanel_Textboxes_panel.Name = "backPanel_Textboxes_panel";
            this.backPanel_Textboxes_panel.Size = new System.Drawing.Size(394, 388);
            this.backPanel_Textboxes_panel.TabIndex = 11;
            // 
            // kunde_email_textBox
            // 
            this.kunde_email_textBox.Location = new System.Drawing.Point(158, 292);
            this.kunde_email_textBox.MaxLength = 49;
            this.kunde_email_textBox.Name = "kunde_email_textBox";
            this.kunde_email_textBox.Size = new System.Drawing.Size(100, 20);
            this.kunde_email_textBox.TabIndex = 23;
            // 
            // kunder_adr_textBox
            // 
            this.kunder_adr_textBox.Location = new System.Drawing.Point(158, 201);
            this.kunder_adr_textBox.MaxLength = 49;
            this.kunder_adr_textBox.Name = "kunder_adr_textBox";
            this.kunder_adr_textBox.Size = new System.Drawing.Size(100, 20);
            this.kunder_adr_textBox.TabIndex = 20;
            // 
            // background_textboxes_top_panel
            // 
            this.background_textboxes_top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.background_textboxes_top_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.background_textboxes_top_panel.Controls.Add(this.opret_Kunder_label);
            this.background_textboxes_top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.background_textboxes_top_panel.Location = new System.Drawing.Point(0, 0);
            this.background_textboxes_top_panel.Name = "background_textboxes_top_panel";
            this.background_textboxes_top_panel.Size = new System.Drawing.Size(392, 26);
            this.background_textboxes_top_panel.TabIndex = 10;
            // 
            // opret_Kunder_label
            // 
            this.opret_Kunder_label.AutoSize = true;
            this.opret_Kunder_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.opret_Kunder_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(92)))));
            this.opret_Kunder_label.Location = new System.Drawing.Point(151, 3);
            this.opret_Kunder_label.Name = "opret_Kunder_label";
            this.opret_Kunder_label.Size = new System.Drawing.Size(106, 21);
            this.opret_Kunder_label.TabIndex = 1;
            this.opret_Kunder_label.Text = "Opret Kunde";
            // 
            // kunder_zipcCode_textBox
            // 
            this.kunder_zipcCode_textBox.Location = new System.Drawing.Point(158, 155);
            this.kunder_zipcCode_textBox.MaxLength = 4;
            this.kunder_zipcCode_textBox.Name = "kunder_zipcCode_textBox";
            this.kunder_zipcCode_textBox.Size = new System.Drawing.Size(100, 20);
            this.kunder_zipcCode_textBox.TabIndex = 18;
            this.kunder_zipcCode_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kunder_zipcCode_textBox_KeyPress);
            // 
            // kunder_tlf_textBox
            // 
            this.kunder_tlf_textBox.Location = new System.Drawing.Point(158, 247);
            this.kunder_tlf_textBox.MaxLength = 8;
            this.kunder_tlf_textBox.Name = "kunder_tlf_textBox";
            this.kunder_tlf_textBox.Size = new System.Drawing.Size(100, 20);
            this.kunder_tlf_textBox.TabIndex = 16;
            this.kunder_tlf_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kunder_tlf_textBox_KeyPress);
            // 
            // kunder_surname_textBox
            // 
            this.kunder_surname_textBox.Location = new System.Drawing.Point(158, 109);
            this.kunder_surname_textBox.MaxLength = 49;
            this.kunder_surname_textBox.Name = "kunder_surname_textBox";
            this.kunder_surname_textBox.Size = new System.Drawing.Size(100, 20);
            this.kunder_surname_textBox.TabIndex = 14;
            this.kunder_surname_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kunder_surname_textBox_KeyPress);
            // 
            // datagridviewBackground_panel
            // 
            this.datagridviewBackground_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.datagridviewBackground_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.datagridviewBackground_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.datagridviewBackground_panel.Controls.Add(this.SAVE_BUTTON_KUNDE_TLF);
            this.datagridviewBackground_panel.Controls.Add(this.Kunde_dataGridView);
            this.datagridviewBackground_panel.Controls.Add(this.print_button);
            this.datagridviewBackground_panel.Controls.Add(this.delete_button);
            this.datagridviewBackground_panel.Controls.Add(this.screenshot_datagridview_button);
            this.datagridviewBackground_panel.Controls.Add(this.undo_button);
            this.datagridviewBackground_panel.Controls.Add(this.show_all_button);
            this.datagridviewBackground_panel.Controls.Add(this.finished_checkBox);
            this.datagridviewBackground_panel.Controls.Add(this.search_options_comboBox);
            this.datagridviewBackground_panel.Controls.Add(this.show_Tlf_Nr_button);
            this.datagridviewBackground_panel.Controls.Add(this.search_button);
            this.datagridviewBackground_panel.Controls.Add(this.search_textBox);
            this.datagridviewBackground_panel.Location = new System.Drawing.Point(292, 170);
            this.datagridviewBackground_panel.Name = "datagridviewBackground_panel";
            this.datagridviewBackground_panel.Size = new System.Drawing.Size(802, 488);
            this.datagridviewBackground_panel.TabIndex = 13;
            // 
            // Kunde_dataGridView
            // 
            this.Kunde_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Kunde_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Kunde_dataGridView.Location = new System.Drawing.Point(15, 59);
            this.Kunde_dataGridView.MultiSelect = false;
            this.Kunde_dataGridView.Name = "Kunde_dataGridView";
            this.Kunde_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Kunde_dataGridView.Size = new System.Drawing.Size(773, 412);
            this.Kunde_dataGridView.TabIndex = 22;
            this.Kunde_dataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Kunde_dataGridView_RowEnter);
            this.Kunde_dataGridView.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.Kunde_dataGridView_RowValidated);
            // 
            // finished_checkBox
            // 
            this.finished_checkBox.AutoSize = true;
            this.finished_checkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.finished_checkBox.Location = new System.Drawing.Point(15, 18);
            this.finished_checkBox.Name = "finished_checkBox";
            this.finished_checkBox.Size = new System.Drawing.Size(61, 17);
            this.finished_checkBox.TabIndex = 15;
            this.finished_checkBox.Text = "Afslutet";
            this.finished_checkBox.UseVisualStyleBackColor = true;
            // 
            // search_options_comboBox
            // 
            this.search_options_comboBox.FormattingEnabled = true;
            this.search_options_comboBox.Location = new System.Drawing.Point(82, 15);
            this.search_options_comboBox.Name = "search_options_comboBox";
            this.search_options_comboBox.Size = new System.Drawing.Size(71, 21);
            this.search_options_comboBox.TabIndex = 14;
            // 
            // search_textBox
            // 
            this.search_textBox.Location = new System.Drawing.Point(159, 15);
            this.search_textBox.Name = "search_textBox";
            this.search_textBox.Size = new System.Drawing.Size(154, 20);
            this.search_textBox.TabIndex = 1;
            // 
            // SAVE_BUTTON_KUNDE_TLF
            // 
            this.SAVE_BUTTON_KUNDE_TLF.FlatAppearance.BorderSize = 0;
            this.SAVE_BUTTON_KUNDE_TLF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.SAVE_BUTTON_KUNDE_TLF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.SAVE_BUTTON_KUNDE_TLF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAVE_BUTTON_KUNDE_TLF.ForeColor = System.Drawing.Color.Black;
            this.SAVE_BUTTON_KUNDE_TLF.Image = global::View_GUI.Properties.Resources.navigate_left_icon__1_;
            this.SAVE_BUTTON_KUNDE_TLF.Location = new System.Drawing.Point(447, 2);
            this.SAVE_BUTTON_KUNDE_TLF.Name = "SAVE_BUTTON_KUNDE_TLF";
            this.SAVE_BUTTON_KUNDE_TLF.Size = new System.Drawing.Size(32, 45);
            this.SAVE_BUTTON_KUNDE_TLF.TabIndex = 23;
            this.SAVE_BUTTON_KUNDE_TLF.UseVisualStyleBackColor = true;
            this.SAVE_BUTTON_KUNDE_TLF.Click += new System.EventHandler(this.SAVE_BUTTON_KUNDE_TLF_Click);
            // 
            // print_button
            // 
            this.print_button.FlatAppearance.BorderSize = 0;
            this.print_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.print_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.print_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print_button.ForeColor = System.Drawing.Color.Black;
            this.print_button.Image = global::View_GUI.Properties.Resources.Apps_preferences_desktop_printer_icon;
            this.print_button.Location = new System.Drawing.Point(716, -1);
            this.print_button.Name = "print_button";
            this.print_button.Size = new System.Drawing.Size(43, 44);
            this.print_button.TabIndex = 21;
            this.print_button.UseVisualStyleBackColor = true;
            // 
            // delete_button
            // 
            this.delete_button.BackgroundImage = global::View_GUI.Properties.Resources.Actions_edit_delete_icon1;
            this.delete_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delete_button.FlatAppearance.BorderSize = 0;
            this.delete_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.delete_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.delete_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_button.ForeColor = System.Drawing.Color.Black;
            this.delete_button.Location = new System.Drawing.Point(558, 4);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(38, 35);
            this.delete_button.TabIndex = 20;
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // screenshot_datagridview_button
            // 
            this.screenshot_datagridview_button.FlatAppearance.BorderSize = 0;
            this.screenshot_datagridview_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.screenshot_datagridview_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.screenshot_datagridview_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.screenshot_datagridview_button.ForeColor = System.Drawing.Color.Black;
            this.screenshot_datagridview_button.Image = global::View_GUI.Properties.Resources.Document_txt_icon__1_;
            this.screenshot_datagridview_button.Location = new System.Drawing.Point(665, -2);
            this.screenshot_datagridview_button.Name = "screenshot_datagridview_button";
            this.screenshot_datagridview_button.Size = new System.Drawing.Size(43, 44);
            this.screenshot_datagridview_button.TabIndex = 19;
            this.screenshot_datagridview_button.UseVisualStyleBackColor = true;
            // 
            // undo_button
            // 
            this.undo_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.undo_button.FlatAppearance.BorderSize = 0;
            this.undo_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.undo_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.undo_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undo_button.ForeColor = System.Drawing.Color.Black;
            this.undo_button.Image = global::View_GUI.Properties.Resources.Actions_go_previous_view_icon__1_;
            this.undo_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.undo_button.Location = new System.Drawing.Point(506, 2);
            this.undo_button.Name = "undo_button";
            this.undo_button.Size = new System.Drawing.Size(38, 39);
            this.undo_button.TabIndex = 17;
            this.undo_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.undo_button.UseVisualStyleBackColor = true;
            this.undo_button.Click += new System.EventHandler(this.undo_button_Click);
            // 
            // show_all_button
            // 
            this.show_all_button.FlatAppearance.BorderSize = 0;
            this.show_all_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.show_all_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.show_all_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_all_button.ForeColor = System.Drawing.Color.Black;
            this.show_all_button.Image = global::View_GUI.Properties.Resources.Documents_icon2;
            this.show_all_button.Location = new System.Drawing.Point(368, -2);
            this.show_all_button.Name = "show_all_button";
            this.show_all_button.Size = new System.Drawing.Size(38, 45);
            this.show_all_button.TabIndex = 16;
            this.show_all_button.UseVisualStyleBackColor = true;
            this.show_all_button.Click += new System.EventHandler(this.show_all_button_Click);
            // 
            // show_Tlf_Nr_button
            // 
            this.show_Tlf_Nr_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.show_Tlf_Nr_button.FlatAppearance.BorderSize = 0;
            this.show_Tlf_Nr_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.show_Tlf_Nr_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.show_Tlf_Nr_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_Tlf_Nr_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.show_Tlf_Nr_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.show_Tlf_Nr_button.Image = global::View_GUI.Properties.Resources.Phone_icon__1_;
            this.show_Tlf_Nr_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.show_Tlf_Nr_button.Location = new System.Drawing.Point(620, -1);
            this.show_Tlf_Nr_button.Margin = new System.Windows.Forms.Padding(0);
            this.show_Tlf_Nr_button.Name = "show_Tlf_Nr_button";
            this.show_Tlf_Nr_button.Size = new System.Drawing.Size(42, 43);
            this.show_Tlf_Nr_button.TabIndex = 13;
            this.show_Tlf_Nr_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.show_Tlf_Nr_button.UseVisualStyleBackColor = true;
            this.show_Tlf_Nr_button.Click += new System.EventHandler(this.show_Tlf_Nr_button_Click);
            // 
            // search_button
            // 
            this.search_button.BackgroundImage = global::View_GUI.Properties.Resources.Actions_page_zoom_icon1;
            this.search_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.search_button.FlatAppearance.BorderSize = 0;
            this.search_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.search_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_button.Location = new System.Drawing.Point(317, -1);
            this.search_button.Margin = new System.Windows.Forms.Padding(0);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(27, 45);
            this.search_button.TabIndex = 12;
            this.search_button.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::View_GUI.Properties.Resources.Untitled__3_;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.vis_rediger_kunder_button);
            this.panel1.Controls.Add(this.opret_kunde_button);
            this.panel1.Location = new System.Drawing.Point(575, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 82);
            this.panel1.TabIndex = 12;
            // 
            // vis_rediger_kunder_button
            // 
            this.vis_rediger_kunder_button.BackgroundImage = global::View_GUI.Properties.Resources.addressbook_edit_icon__3_;
            this.vis_rediger_kunder_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.vis_rediger_kunder_button.FlatAppearance.BorderSize = 0;
            this.vis_rediger_kunder_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.vis_rediger_kunder_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.vis_rediger_kunder_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vis_rediger_kunder_button.Font = new System.Drawing.Font("OpenSymbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vis_rediger_kunder_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.vis_rediger_kunder_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.vis_rediger_kunder_button.Location = new System.Drawing.Point(121, 6);
            this.vis_rediger_kunder_button.Name = "vis_rediger_kunder_button";
            this.vis_rediger_kunder_button.Size = new System.Drawing.Size(94, 68);
            this.vis_rediger_kunder_button.TabIndex = 1;
            this.vis_rediger_kunder_button.Text = "Vis / Rediger";
            this.vis_rediger_kunder_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.vis_rediger_kunder_button.UseVisualStyleBackColor = true;
            this.vis_rediger_kunder_button.Click += new System.EventHandler(this.vis_rediger_kunder_button_Click);
            // 
            // opret_kunde_button
            // 
            this.opret_kunde_button.BackgroundImage = global::View_GUI.Properties.Resources.sign_up_icon1;
            this.opret_kunde_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.opret_kunde_button.FlatAppearance.BorderSize = 0;
            this.opret_kunde_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.opret_kunde_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.opret_kunde_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opret_kunde_button.Font = new System.Drawing.Font("OpenSymbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opret_kunde_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.opret_kunde_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.opret_kunde_button.Location = new System.Drawing.Point(42, -7);
            this.opret_kunde_button.Name = "opret_kunde_button";
            this.opret_kunde_button.Size = new System.Drawing.Size(50, 80);
            this.opret_kunde_button.TabIndex = 0;
            this.opret_kunde_button.Text = "Opret";
            this.opret_kunde_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.opret_kunde_button.UseVisualStyleBackColor = true;
            this.opret_kunde_button.Click += new System.EventHandler(this.opret_kunde_button_Click);
            // 
            // email_label
            // 
            this.email_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.email_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.email_label.Image = global::View_GUI.Properties.Resources.At_Mail_icon;
            this.email_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.email_label.Location = new System.Drawing.Point(53, 287);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(98, 33);
            this.email_label.TabIndex = 22;
            this.email_label.Text = "Email:";
            this.email_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kunder_Save_button
            // 
            this.kunder_Save_button.FlatAppearance.BorderSize = 0;
            this.kunder_Save_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.kunder_Save_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.kunder_Save_button.Font = new System.Drawing.Font("Gentium Basic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kunder_Save_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(143)))), ((int)(((byte)(235)))));
            this.kunder_Save_button.Image = global::View_GUI.Properties.Resources.Actions_document_save_icon;
            this.kunder_Save_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kunder_Save_button.Location = new System.Drawing.Point(160, 336);
            this.kunder_Save_button.Name = "kunder_Save_button";
            this.kunder_Save_button.Size = new System.Drawing.Size(90, 30);
            this.kunder_Save_button.TabIndex = 21;
            this.kunder_Save_button.Text = "Gem";
            this.kunder_Save_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kunder_Save_button.UseVisualStyleBackColor = true;
            this.kunder_Save_button.Click += new System.EventHandler(this.kunder_Save_button_Click);
            // 
            // adr_label
            // 
            this.adr_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.adr_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.adr_label.Image = global::View_GUI.Properties.Resources.my_numbers_icon;
            this.adr_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.adr_label.Location = new System.Drawing.Point(70, 197);
            this.adr_label.Name = "adr_label";
            this.adr_label.Size = new System.Drawing.Size(80, 25);
            this.adr_label.TabIndex = 19;
            this.adr_label.Text = "Adr:";
            this.adr_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // zipCode_label
            // 
            this.zipCode_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.zipCode_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.zipCode_label.Image = global::View_GUI.Properties.Resources.Compressed_File_Zip_icon;
            this.zipCode_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zipCode_label.Location = new System.Drawing.Point(49, 150);
            this.zipCode_label.Name = "zipCode_label";
            this.zipCode_label.Size = new System.Drawing.Size(105, 25);
            this.zipCode_label.TabIndex = 17;
            this.zipCode_label.Text = "PostNr:";
            this.zipCode_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlf_label
            // 
            this.tlf_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tlf_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.tlf_label.Image = global::View_GUI.Properties.Resources.Phone_icon__1_;
            this.tlf_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tlf_label.Location = new System.Drawing.Point(80, 243);
            this.tlf_label.Name = "tlf_label";
            this.tlf_label.Size = new System.Drawing.Size(73, 24);
            this.tlf_label.TabIndex = 15;
            this.tlf_label.Text = "Tlf:";
            this.tlf_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // surname_label
            // 
            this.surname_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.surname_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.surname_label.Image = global::View_GUI.Properties.Resources.name_card_icon;
            this.surname_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.surname_label.Location = new System.Drawing.Point(25, 104);
            this.surname_label.Name = "surname_label";
            this.surname_label.Size = new System.Drawing.Size(125, 25);
            this.surname_label.TabIndex = 13;
            this.surname_label.Text = "Efternavn:";
            this.surname_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // name_label
            // 
            this.name_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.name_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.name_label.Image = global::View_GUI.Properties.Resources.ID_icon;
            this.name_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.name_label.Location = new System.Drawing.Point(56, 59);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(95, 24);
            this.name_label.TabIndex = 2;
            this.name_label.Text = "Navn:";
            this.name_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Kunder_Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1333, 700);
            this.Controls.Add(this.datagridviewBackground_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.backPanel_Textboxes_panel);
            this.Controls.Add(this.backgroundName_Top_panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Kunder_Form9";
            this.Text = "Kunder_Form9";
            this.Load += new System.EventHandler(this.Kunder_Form9_Load);
            this.backgroundName_Top_panel.ResumeLayout(false);
            this.backgroundName_Top_panel.PerformLayout();
            this.backPanel_Textboxes_panel.ResumeLayout(false);
            this.backPanel_Textboxes_panel.PerformLayout();
            this.background_textboxes_top_panel.ResumeLayout(false);
            this.background_textboxes_top_panel.PerformLayout();
            this.datagridviewBackground_panel.ResumeLayout(false);
            this.datagridviewBackground_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Kunde_dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Kunde_Top_label;
        private System.Windows.Forms.Panel backgroundName_Top_panel;
        private System.Windows.Forms.TextBox kunder_name_textBox;
        private System.Windows.Forms.Panel backPanel_Textboxes_panel;
        private System.Windows.Forms.Panel background_textboxes_top_panel;
        private System.Windows.Forms.Label opret_Kunder_label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label adr_label;
        private System.Windows.Forms.TextBox kunder_adr_textBox;
        private System.Windows.Forms.Label zipCode_label;
        private System.Windows.Forms.TextBox kunder_zipcCode_textBox;
        private System.Windows.Forms.Label tlf_label;
        private System.Windows.Forms.TextBox kunder_tlf_textBox;
        private System.Windows.Forms.Label surname_label;
        private System.Windows.Forms.TextBox kunder_surname_textBox;
        private System.Windows.Forms.Button kunder_Save_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button opret_kunde_button;
        private System.Windows.Forms.Button vis_rediger_kunder_button;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.TextBox kunde_email_textBox;
        private System.Windows.Forms.Panel datagridviewBackground_panel;
        private System.Windows.Forms.TextBox search_textBox;
        private System.Windows.Forms.Button show_Tlf_Nr_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.CheckBox finished_checkBox;
        private System.Windows.Forms.ComboBox search_options_comboBox;
        private System.Windows.Forms.Button show_all_button;
        private System.Windows.Forms.Button undo_button;
        private System.Windows.Forms.Button screenshot_datagridview_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button print_button;
        private System.Windows.Forms.DataGridView Kunde_dataGridView;
        private System.Windows.Forms.Button SAVE_BUTTON_KUNDE_TLF;
    }
}