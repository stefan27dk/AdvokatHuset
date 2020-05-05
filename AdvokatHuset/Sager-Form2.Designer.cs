namespace View_GUI
{
    partial class Sager_Form2
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
            this.Sager_Top_label = new System.Windows.Forms.Label();
            this.backgroundName_Top_panel = new System.Windows.Forms.Panel();
            this.top_background_panel = new System.Windows.Forms.Panel();
            this.backPanel_Textboxes_panel = new System.Windows.Forms.Panel();
            this.sager_type_comboBox = new System.Windows.Forms.ComboBox();
            this.sager_kunde_id_texbox = new System.Windows.Forms.TextBox();
            this.background_textboxes_top_panel = new System.Windows.Forms.Panel();
            this.opret_Sager_label = new System.Windows.Forms.Label();
            this.sager_id_textBox = new System.Windows.Forms.TextBox();
            this.sager_advokat_id_textBox = new System.Windows.Forms.TextBox();
            this.sager_vise_rediger_button = new System.Windows.Forms.Button();
            this.sager_opret_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ydelse_Save_button = new System.Windows.Forms.Button();
            this.art_label = new System.Windows.Forms.Label();
            this.type_label = new System.Windows.Forms.Label();
            this.id_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.sager_oprets_dato_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.backgroundName_Top_panel.SuspendLayout();
            this.top_background_panel.SuspendLayout();
            this.backPanel_Textboxes_panel.SuspendLayout();
            this.background_textboxes_top_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Sager_Top_label
            // 
            this.Sager_Top_label.AutoSize = true;
            this.Sager_Top_label.Font = new System.Drawing.Font("Miriam CLM", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Sager_Top_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(92)))));
            this.Sager_Top_label.Location = new System.Drawing.Point(10, 10);
            this.Sager_Top_label.Name = "Sager_Top_label";
            this.Sager_Top_label.Size = new System.Drawing.Size(63, 23);
            this.Sager_Top_label.TabIndex = 3;
            this.Sager_Top_label.Text = "Sager";
            // 
            // backgroundName_Top_panel
            // 
            this.backgroundName_Top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.backgroundName_Top_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundName_Top_panel.Controls.Add(this.Sager_Top_label);
            this.backgroundName_Top_panel.Location = new System.Drawing.Point(18, 58);
            this.backgroundName_Top_panel.Name = "backgroundName_Top_panel";
            this.backgroundName_Top_panel.Size = new System.Drawing.Size(84, 44);
            this.backgroundName_Top_panel.TabIndex = 9;
            // 
            // top_background_panel
            // 
            this.top_background_panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.top_background_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.top_background_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.top_background_panel.Controls.Add(this.sager_vise_rediger_button);
            this.top_background_panel.Controls.Add(this.sager_opret_button);
            this.top_background_panel.Location = new System.Drawing.Point(365, 76);
            this.top_background_panel.Name = "top_background_panel";
            this.top_background_panel.Size = new System.Drawing.Size(238, 70);
            this.top_background_panel.TabIndex = 16;
            // 
            // backPanel_Textboxes_panel
            // 
            this.backPanel_Textboxes_panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.backPanel_Textboxes_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.backPanel_Textboxes_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backPanel_Textboxes_panel.Controls.Add(this.sager_oprets_dato_dateTimePicker);
            this.backPanel_Textboxes_panel.Controls.Add(this.label1);
            this.backPanel_Textboxes_panel.Controls.Add(this.sager_advokat_id_textBox);
            this.backPanel_Textboxes_panel.Controls.Add(this.sager_type_comboBox);
            this.backPanel_Textboxes_panel.Controls.Add(this.ydelse_Save_button);
            this.backPanel_Textboxes_panel.Controls.Add(this.art_label);
            this.backPanel_Textboxes_panel.Controls.Add(this.sager_kunde_id_texbox);
            this.backPanel_Textboxes_panel.Controls.Add(this.background_textboxes_top_panel);
            this.backPanel_Textboxes_panel.Controls.Add(this.type_label);
            this.backPanel_Textboxes_panel.Controls.Add(this.id_label);
            this.backPanel_Textboxes_panel.Controls.Add(this.sager_id_textBox);
            this.backPanel_Textboxes_panel.Controls.Add(this.name_label);
            this.backPanel_Textboxes_panel.Location = new System.Drawing.Point(284, 155);
            this.backPanel_Textboxes_panel.Name = "backPanel_Textboxes_panel";
            this.backPanel_Textboxes_panel.Size = new System.Drawing.Size(394, 388);
            this.backPanel_Textboxes_panel.TabIndex = 15;
            // 
            // sager_type_comboBox
            // 
            this.sager_type_comboBox.FormattingEnabled = true;
            this.sager_type_comboBox.Location = new System.Drawing.Point(178, 155);
            this.sager_type_comboBox.Name = "sager_type_comboBox";
            this.sager_type_comboBox.Size = new System.Drawing.Size(138, 21);
            this.sager_type_comboBox.TabIndex = 22;
            // 
            // sager_kunde_id_texbox
            // 
            this.sager_kunde_id_texbox.Location = new System.Drawing.Point(178, 249);
            this.sager_kunde_id_texbox.Name = "sager_kunde_id_texbox";
            this.sager_kunde_id_texbox.Size = new System.Drawing.Size(39, 20);
            this.sager_kunde_id_texbox.TabIndex = 20;
            // 
            // background_textboxes_top_panel
            // 
            this.background_textboxes_top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.background_textboxes_top_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.background_textboxes_top_panel.Controls.Add(this.opret_Sager_label);
            this.background_textboxes_top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.background_textboxes_top_panel.Location = new System.Drawing.Point(0, 0);
            this.background_textboxes_top_panel.Name = "background_textboxes_top_panel";
            this.background_textboxes_top_panel.Size = new System.Drawing.Size(392, 26);
            this.background_textboxes_top_panel.TabIndex = 10;
            // 
            // opret_Sager_label
            // 
            this.opret_Sager_label.AutoSize = true;
            this.opret_Sager_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.opret_Sager_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(92)))));
            this.opret_Sager_label.Location = new System.Drawing.Point(151, 3);
            this.opret_Sager_label.Name = "opret_Sager_label";
            this.opret_Sager_label.Size = new System.Drawing.Size(88, 21);
            this.opret_Sager_label.TabIndex = 1;
            this.opret_Sager_label.Text = "Opret Sag";
            // 
            // sager_id_textBox
            // 
            this.sager_id_textBox.Location = new System.Drawing.Point(178, 63);
            this.sager_id_textBox.Name = "sager_id_textBox";
            this.sager_id_textBox.Size = new System.Drawing.Size(39, 20);
            this.sager_id_textBox.TabIndex = 12;
            // 
            // sager_advokat_id_textBox
            // 
            this.sager_advokat_id_textBox.Location = new System.Drawing.Point(178, 200);
            this.sager_advokat_id_textBox.Name = "sager_advokat_id_textBox";
            this.sager_advokat_id_textBox.Size = new System.Drawing.Size(39, 20);
            this.sager_advokat_id_textBox.TabIndex = 24;
            // 
            // sager_vise_rediger_button
            // 
            this.sager_vise_rediger_button.BackgroundImage = global::View_GUI.Properties.Resources.addressbook_edit_icon__3_;
            this.sager_vise_rediger_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.sager_vise_rediger_button.FlatAppearance.BorderSize = 0;
            this.sager_vise_rediger_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.sager_vise_rediger_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.sager_vise_rediger_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sager_vise_rediger_button.Font = new System.Drawing.Font("OpenSymbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sager_vise_rediger_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.sager_vise_rediger_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sager_vise_rediger_button.Location = new System.Drawing.Point(121, -4);
            this.sager_vise_rediger_button.Name = "sager_vise_rediger_button";
            this.sager_vise_rediger_button.Size = new System.Drawing.Size(94, 68);
            this.sager_vise_rediger_button.TabIndex = 1;
            this.sager_vise_rediger_button.Text = "Vis / Rediger";
            this.sager_vise_rediger_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sager_vise_rediger_button.UseVisualStyleBackColor = true;
            // 
            // sager_opret_button
            // 
            this.sager_opret_button.BackgroundImage = global::View_GUI.Properties.Resources.sign_up_icon1;
            this.sager_opret_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.sager_opret_button.FlatAppearance.BorderSize = 0;
            this.sager_opret_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.sager_opret_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.sager_opret_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sager_opret_button.Font = new System.Drawing.Font("OpenSymbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sager_opret_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.sager_opret_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sager_opret_button.Location = new System.Drawing.Point(42, -17);
            this.sager_opret_button.Name = "sager_opret_button";
            this.sager_opret_button.Size = new System.Drawing.Size(50, 80);
            this.sager_opret_button.TabIndex = 0;
            this.sager_opret_button.Text = "Opret";
            this.sager_opret_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sager_opret_button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.label1.Image = global::View_GUI.Properties.Resources.ID_icon1;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(33, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 24);
            this.label1.TabIndex = 23;
            this.label1.Text = "Advokat ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ydelse_Save_button
            // 
            this.ydelse_Save_button.FlatAppearance.BorderSize = 0;
            this.ydelse_Save_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ydelse_Save_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.ydelse_Save_button.Font = new System.Drawing.Font("Gentium Basic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ydelse_Save_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(143)))), ((int)(((byte)(235)))));
            this.ydelse_Save_button.Image = global::View_GUI.Properties.Resources.Actions_document_save_icon;
            this.ydelse_Save_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ydelse_Save_button.Location = new System.Drawing.Point(163, 335);
            this.ydelse_Save_button.Name = "ydelse_Save_button";
            this.ydelse_Save_button.Size = new System.Drawing.Size(90, 30);
            this.ydelse_Save_button.TabIndex = 21;
            this.ydelse_Save_button.Text = "Gem";
            this.ydelse_Save_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ydelse_Save_button.UseVisualStyleBackColor = true;
            // 
            // art_label
            // 
            this.art_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.art_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.art_label.Image = global::View_GUI.Properties.Resources.name_card_icon1;
            this.art_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.art_label.Location = new System.Drawing.Point(48, 241);
            this.art_label.Name = "art_label";
            this.art_label.Size = new System.Drawing.Size(125, 33);
            this.art_label.TabIndex = 19;
            this.art_label.Text = "Kunde ID:";
            this.art_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // type_label
            // 
            this.type_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.type_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.type_label.Image = global::View_GUI.Properties.Resources.App_klickety_game_icon1;
            this.type_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.type_label.Location = new System.Drawing.Point(82, 146);
            this.type_label.Name = "type_label";
            this.type_label.Size = new System.Drawing.Size(90, 35);
            this.type_label.TabIndex = 17;
            this.type_label.Text = "Type:";
            this.type_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // id_label
            // 
            this.id_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.id_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.id_label.Image = global::View_GUI.Properties.Resources.barcode_icon;
            this.id_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.id_label.Location = new System.Drawing.Point(67, 59);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(105, 24);
            this.id_label.TabIndex = 11;
            this.id_label.Text = "Sag ID:";
            this.id_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // name_label
            // 
            this.name_label.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.name_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.name_label.Image = global::View_GUI.Properties.Resources.date_icon2;
            this.name_label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.name_label.Location = new System.Drawing.Point(23, 107);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(150, 24);
            this.name_label.TabIndex = 2;
            this.name_label.Text = "Oprets Dato:";
            this.name_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sager_oprets_dato_dateTimePicker
            // 
            this.sager_oprets_dato_dateTimePicker.Location = new System.Drawing.Point(176, 111);
            this.sager_oprets_dato_dateTimePicker.Name = "sager_oprets_dato_dateTimePicker";
            this.sager_oprets_dato_dateTimePicker.Size = new System.Drawing.Size(140, 20);
            this.sager_oprets_dato_dateTimePicker.TabIndex = 25;
            // 
            // Sager_Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(900, 555);
            this.Controls.Add(this.top_background_panel);
            this.Controls.Add(this.backPanel_Textboxes_panel);
            this.Controls.Add(this.backgroundName_Top_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sager_Form2";
            this.Text = "Sager_Form2";
            this.Load += new System.EventHandler(this.Sager_Form2_Load);
            this.backgroundName_Top_panel.ResumeLayout(false);
            this.backgroundName_Top_panel.PerformLayout();
            this.top_background_panel.ResumeLayout(false);
            this.backPanel_Textboxes_panel.ResumeLayout(false);
            this.backPanel_Textboxes_panel.PerformLayout();
            this.background_textboxes_top_panel.ResumeLayout(false);
            this.background_textboxes_top_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Sager_Top_label;
        private System.Windows.Forms.Panel backgroundName_Top_panel;
        private System.Windows.Forms.Panel top_background_panel;
        private System.Windows.Forms.Button sager_vise_rediger_button;
        private System.Windows.Forms.Button sager_opret_button;
        private System.Windows.Forms.Panel backPanel_Textboxes_panel;
        private System.Windows.Forms.ComboBox sager_type_comboBox;
        private System.Windows.Forms.Button ydelse_Save_button;
        private System.Windows.Forms.Label art_label;
        private System.Windows.Forms.TextBox sager_kunde_id_texbox;
        private System.Windows.Forms.Panel background_textboxes_top_panel;
        private System.Windows.Forms.Label opret_Sager_label;
        private System.Windows.Forms.Label type_label;
        private System.Windows.Forms.Label id_label;
        private System.Windows.Forms.TextBox sager_id_textBox;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sager_advokat_id_textBox;
        private System.Windows.Forms.DateTimePicker sager_oprets_dato_dateTimePicker;
    }
}