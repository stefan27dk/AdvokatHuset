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
            this.components = new System.ComponentModel.Container();
            this.Kunde_Top_label = new System.Windows.Forms.Label();
            this.backgroundName_Top_panel = new System.Windows.Forms.Panel();
            this.kunder_name_textBox = new System.Windows.Forms.TextBox();
            this.backPanel_Textboxes_panel = new System.Windows.Forms.Panel();
            this.email_label = new System.Windows.Forms.Label();
            this.kunde_email_textBox = new System.Windows.Forms.TextBox();
            this.kunder_Save_button = new System.Windows.Forms.Button();
            this.adr_label = new System.Windows.Forms.Label();
            this.kunder_adr_textBox = new System.Windows.Forms.TextBox();
            this.background_textboxes_top_panel = new System.Windows.Forms.Panel();
            this.opret_Kunder_label = new System.Windows.Forms.Label();
            this.zipCode_label = new System.Windows.Forms.Label();
            this.kunder_zipcCode_textBox = new System.Windows.Forms.TextBox();
            this.tlf_label = new System.Windows.Forms.Label();
            this.kunder_tlf_textBox = new System.Windows.Forms.TextBox();
            this.surname_label = new System.Windows.Forms.Label();
            this.kunder_surname_textBox = new System.Windows.Forms.TextBox();
            this.name_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vis_rediger_kunder_button = new System.Windows.Forms.Button();
            this.opret_kunde_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Kunde_dataGridView = new System.Windows.Forms.DataGridView();
            this.advokathusetDataSet = new View_GUI.AdvokathusetDataSet();
            this.advokathusetDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kundeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kundeTableAdapter = new View_GUI.AdvokathusetDataSetTableAdapters.KundeTableAdapter();
            this.kundeFornavnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kundeEfternavnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kundePostNrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kundeAdresseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kundeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kundeEmailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opretsDatoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundName_Top_panel.SuspendLayout();
            this.backPanel_Textboxes_panel.SuspendLayout();
            this.background_textboxes_top_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Kunde_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advokathusetDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advokathusetDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kundeBindingSource)).BeginInit();
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
            this.backPanel_Textboxes_panel.Location = new System.Drawing.Point(284, 170);
            this.backPanel_Textboxes_panel.Name = "backPanel_Textboxes_panel";
            this.backPanel_Textboxes_panel.Size = new System.Drawing.Size(394, 388);
            this.backPanel_Textboxes_panel.TabIndex = 11;
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
            // kunde_email_textBox
            // 
            this.kunde_email_textBox.Location = new System.Drawing.Point(158, 292);
            this.kunde_email_textBox.MaxLength = 49;
            this.kunde_email_textBox.Name = "kunde_email_textBox";
            this.kunde_email_textBox.Size = new System.Drawing.Size(100, 20);
            this.kunde_email_textBox.TabIndex = 23;
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
            // kunder_zipcCode_textBox
            // 
            this.kunder_zipcCode_textBox.Location = new System.Drawing.Point(158, 155);
            this.kunder_zipcCode_textBox.MaxLength = 4;
            this.kunder_zipcCode_textBox.Name = "kunder_zipcCode_textBox";
            this.kunder_zipcCode_textBox.Size = new System.Drawing.Size(100, 20);
            this.kunder_zipcCode_textBox.TabIndex = 18;
            this.kunder_zipcCode_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kunder_zipcCode_textBox_KeyPress);
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
            // kunder_tlf_textBox
            // 
            this.kunder_tlf_textBox.Location = new System.Drawing.Point(158, 247);
            this.kunder_tlf_textBox.MaxLength = 8;
            this.kunder_tlf_textBox.Name = "kunder_tlf_textBox";
            this.kunder_tlf_textBox.Size = new System.Drawing.Size(100, 20);
            this.kunder_tlf_textBox.TabIndex = 16;
            this.kunder_tlf_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kunder_tlf_textBox_KeyPress);
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
            // kunder_surname_textBox
            // 
            this.kunder_surname_textBox.Location = new System.Drawing.Point(158, 109);
            this.kunder_surname_textBox.MaxLength = 49;
            this.kunder_surname_textBox.Name = "kunder_surname_textBox";
            this.kunder_surname_textBox.Size = new System.Drawing.Size(100, 20);
            this.kunder_surname_textBox.TabIndex = 14;
            this.kunder_surname_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kunder_surname_textBox_KeyPress);
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
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::View_GUI.Properties.Resources.Untitled__3_;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.vis_rediger_kunder_button);
            this.panel1.Controls.Add(this.opret_kunde_button);
            this.panel1.Location = new System.Drawing.Point(359, 83);
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
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.Kunde_dataGridView);
            this.panel2.Location = new System.Drawing.Point(2, 220);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(896, 376);
            this.panel2.TabIndex = 13;
            // 
            // Kunde_dataGridView
            // 
            this.Kunde_dataGridView.AutoGenerateColumns = false;
            this.Kunde_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Kunde_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kundeFornavnDataGridViewTextBoxColumn,
            this.kundeEfternavnDataGridViewTextBoxColumn,
            this.kundePostNrDataGridViewTextBoxColumn,
            this.kundeAdresseDataGridViewTextBoxColumn,
            this.kundeIDDataGridViewTextBoxColumn,
            this.kundeEmailDataGridViewTextBoxColumn,
            this.opretsDatoDataGridViewTextBoxColumn});
            this.Kunde_dataGridView.DataSource = this.kundeBindingSource;
            this.Kunde_dataGridView.Location = new System.Drawing.Point(99, 28);
            this.Kunde_dataGridView.Name = "Kunde_dataGridView";
            this.Kunde_dataGridView.Size = new System.Drawing.Size(744, 270);
            this.Kunde_dataGridView.TabIndex = 0;
            // 
            // advokathusetDataSet
            // 
            this.advokathusetDataSet.DataSetName = "AdvokathusetDataSet";
            this.advokathusetDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // advokathusetDataSetBindingSource
            // 
            this.advokathusetDataSetBindingSource.DataSource = this.advokathusetDataSet;
            this.advokathusetDataSetBindingSource.Position = 0;
            // 
            // kundeBindingSource
            // 
            this.kundeBindingSource.DataMember = "Kunde";
            this.kundeBindingSource.DataSource = this.advokathusetDataSetBindingSource;
            // 
            // kundeTableAdapter
            // 
            this.kundeTableAdapter.ClearBeforeFill = true;
            // 
            // kundeFornavnDataGridViewTextBoxColumn
            // 
            this.kundeFornavnDataGridViewTextBoxColumn.DataPropertyName = "Kunde_Fornavn";
            this.kundeFornavnDataGridViewTextBoxColumn.HeaderText = "Kunde_Fornavn";
            this.kundeFornavnDataGridViewTextBoxColumn.Name = "kundeFornavnDataGridViewTextBoxColumn";
            // 
            // kundeEfternavnDataGridViewTextBoxColumn
            // 
            this.kundeEfternavnDataGridViewTextBoxColumn.DataPropertyName = "Kunde_Efternavn";
            this.kundeEfternavnDataGridViewTextBoxColumn.HeaderText = "Kunde_Efternavn";
            this.kundeEfternavnDataGridViewTextBoxColumn.Name = "kundeEfternavnDataGridViewTextBoxColumn";
            // 
            // kundePostNrDataGridViewTextBoxColumn
            // 
            this.kundePostNrDataGridViewTextBoxColumn.DataPropertyName = "Kunde_PostNr";
            this.kundePostNrDataGridViewTextBoxColumn.HeaderText = "Kunde_PostNr";
            this.kundePostNrDataGridViewTextBoxColumn.Name = "kundePostNrDataGridViewTextBoxColumn";
            // 
            // kundeAdresseDataGridViewTextBoxColumn
            // 
            this.kundeAdresseDataGridViewTextBoxColumn.DataPropertyName = "Kunde_Adresse";
            this.kundeAdresseDataGridViewTextBoxColumn.HeaderText = "Kunde_Adresse";
            this.kundeAdresseDataGridViewTextBoxColumn.Name = "kundeAdresseDataGridViewTextBoxColumn";
            // 
            // kundeIDDataGridViewTextBoxColumn
            // 
            this.kundeIDDataGridViewTextBoxColumn.DataPropertyName = "Kunde_ID";
            this.kundeIDDataGridViewTextBoxColumn.HeaderText = "Kunde_ID";
            this.kundeIDDataGridViewTextBoxColumn.Name = "kundeIDDataGridViewTextBoxColumn";
            // 
            // kundeEmailDataGridViewTextBoxColumn
            // 
            this.kundeEmailDataGridViewTextBoxColumn.DataPropertyName = "Kunde_Email";
            this.kundeEmailDataGridViewTextBoxColumn.HeaderText = "Kunde_Email";
            this.kundeEmailDataGridViewTextBoxColumn.Name = "kundeEmailDataGridViewTextBoxColumn";
            // 
            // opretsDatoDataGridViewTextBoxColumn
            // 
            this.opretsDatoDataGridViewTextBoxColumn.DataPropertyName = "Oprets_Dato";
            this.opretsDatoDataGridViewTextBoxColumn.HeaderText = "Oprets_Dato";
            this.opretsDatoDataGridViewTextBoxColumn.Name = "opretsDatoDataGridViewTextBoxColumn";
            // 
            // Kunder_Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.backPanel_Textboxes_panel);
            this.Controls.Add(this.backgroundName_Top_panel);
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
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Kunde_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advokathusetDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advokathusetDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kundeBindingSource)).EndInit();
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView Kunde_dataGridView;
        private AdvokathusetDataSet advokathusetDataSet;
        private System.Windows.Forms.BindingSource advokathusetDataSetBindingSource;
        private System.Windows.Forms.BindingSource kundeBindingSource;
        private AdvokathusetDataSetTableAdapters.KundeTableAdapter kundeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn kundeFornavnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kundeEfternavnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kundePostNrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kundeAdresseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kundeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kundeEmailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn opretsDatoDataGridViewTextBoxColumn;
    }
}