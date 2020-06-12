namespace View_GUI
{
    partial class DeveloperForm_Form12
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeveloperForm_Form12));
            this.top_Title_Background_panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Advokater_Top_label = new System.Windows.Forms.Label();
            this.Script_richTextBox = new System.Windows.Forms.RichTextBox();
            this.Dev_dataGridView = new System.Windows.Forms.DataGridView();
            this.Search_Script_textBox = new System.Windows.Forms.TextBox();
            this.Clear_SearchBox_button = new System.Windows.Forms.Button();
            this.copy_selected_column_button = new System.Windows.Forms.Button();
            this.Run_button = new System.Windows.Forms.Button();
            this.top_Title_Background_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dev_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // top_Title_Background_panel
            // 
            this.top_Title_Background_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.top_Title_Background_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.top_Title_Background_panel.Controls.Add(this.label2);
            this.top_Title_Background_panel.Controls.Add(this.label1);
            this.top_Title_Background_panel.Controls.Add(this.Advokater_Top_label);
            this.top_Title_Background_panel.Location = new System.Drawing.Point(18, 63);
            this.top_Title_Background_panel.Name = "top_Title_Background_panel";
            this.top_Title_Background_panel.Size = new System.Drawing.Size(300, 25);
            this.top_Title_Background_panel.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Liberation Mono", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(256, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "¨SQL¨";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Liberation Mono", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 8);
            this.label1.TabIndex = 2;
            this.label1.Text = "C#";
            // 
            // Advokater_Top_label
            // 
            this.Advokater_Top_label.AutoSize = true;
            this.Advokater_Top_label.Font = new System.Drawing.Font("Liberation Mono", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Advokater_Top_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(92)))));
            this.Advokater_Top_label.Location = new System.Drawing.Point(32, 0);
            this.Advokater_Top_label.Name = "Advokater_Top_label";
            this.Advokater_Top_label.Size = new System.Drawing.Size(218, 23);
            this.Advokater_Top_label.TabIndex = 1;
            this.Advokater_Top_label.Text = "~::Developer:: ~";
            // 
            // Script_richTextBox
            // 
            this.Script_richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Script_richTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(10)))), ((int)(((byte)(36)))));
            this.Script_richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Script_richTextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Script_richTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.Script_richTextBox.Location = new System.Drawing.Point(18, 130);
            this.Script_richTextBox.Name = "Script_richTextBox";
            this.Script_richTextBox.Size = new System.Drawing.Size(939, 257);
            this.Script_richTextBox.TabIndex = 8;
            this.Script_richTextBox.Text = "";
            this.Script_richTextBox.TextChanged += new System.EventHandler(this.Script_richTextBox_TextChanged);
            // 
            // Dev_dataGridView
            // 
            this.Dev_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dev_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Dev_dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Dev_dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.Dev_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dev_dataGridView.Location = new System.Drawing.Point(18, 429);
            this.Dev_dataGridView.Name = "Dev_dataGridView";
            this.Dev_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dev_dataGridView.Size = new System.Drawing.Size(939, 207);
            this.Dev_dataGridView.TabIndex = 9;
            // 
            // Search_Script_textBox
            // 
            this.Search_Script_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Search_Script_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Search_Script_textBox.Location = new System.Drawing.Point(703, 95);
            this.Search_Script_textBox.Name = "Search_Script_textBox";
            this.Search_Script_textBox.Size = new System.Drawing.Size(242, 20);
            this.Search_Script_textBox.TabIndex = 18;
            this.Search_Script_textBox.TextChanged += new System.EventHandler(this.Search_Script_textBox_TextChanged);
            this.Search_Script_textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Search_Script_textBox_MouseDown);
            // 
            // Clear_SearchBox_button
            // 
            this.Clear_SearchBox_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Clear_SearchBox_button.BackColor = System.Drawing.Color.Transparent;
            this.Clear_SearchBox_button.BackgroundImage = global::View_GUI.Properties.Resources.Actions_edit_delete_icon2;
            this.Clear_SearchBox_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Clear_SearchBox_button.FlatAppearance.BorderSize = 0;
            this.Clear_SearchBox_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Clear_SearchBox_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.Clear_SearchBox_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear_SearchBox_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clear_SearchBox_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Clear_SearchBox_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Clear_SearchBox_button.Location = new System.Drawing.Point(655, 89);
            this.Clear_SearchBox_button.Margin = new System.Windows.Forms.Padding(0);
            this.Clear_SearchBox_button.Name = "Clear_SearchBox_button";
            this.Clear_SearchBox_button.Size = new System.Drawing.Size(34, 34);
            this.Clear_SearchBox_button.TabIndex = 19;
            this.Clear_SearchBox_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Clear_SearchBox_button.UseVisualStyleBackColor = false;
            this.Clear_SearchBox_button.Click += new System.EventHandler(this.Clear_SearchBox_button_Click);
            // 
            // copy_selected_column_button
            // 
            this.copy_selected_column_button.BackColor = System.Drawing.Color.Transparent;
            this.copy_selected_column_button.BackgroundImage = global::View_GUI.Properties.Resources.copy_icon16;
            this.copy_selected_column_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.copy_selected_column_button.FlatAppearance.BorderSize = 0;
            this.copy_selected_column_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.copy_selected_column_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.copy_selected_column_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copy_selected_column_button.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copy_selected_column_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copy_selected_column_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.copy_selected_column_button.Location = new System.Drawing.Point(26, 400);
            this.copy_selected_column_button.Margin = new System.Windows.Forms.Padding(0);
            this.copy_selected_column_button.Name = "copy_selected_column_button";
            this.copy_selected_column_button.Size = new System.Drawing.Size(29, 26);
            this.copy_selected_column_button.TabIndex = 17;
            this.copy_selected_column_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.copy_selected_column_button.UseVisualStyleBackColor = false;
            this.copy_selected_column_button.Click += new System.EventHandler(this.copy_selected_column_button_Click);
            // 
            // Run_button
            // 
            this.Run_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Run_button.BackgroundImage")));
            this.Run_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Run_button.FlatAppearance.BorderSize = 0;
            this.Run_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Run_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.Run_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Run_button.Location = new System.Drawing.Point(26, 102);
            this.Run_button.Margin = new System.Windows.Forms.Padding(0);
            this.Run_button.Name = "Run_button";
            this.Run_button.Size = new System.Drawing.Size(26, 25);
            this.Run_button.TabIndex = 10;
            this.Run_button.UseVisualStyleBackColor = true;
            this.Run_button.Click += new System.EventHandler(this.Run_button_Click);
            // 
            // DeveloperForm_Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1000, 673);
            this.Controls.Add(this.Clear_SearchBox_button);
            this.Controls.Add(this.Search_Script_textBox);
            this.Controls.Add(this.copy_selected_column_button);
            this.Controls.Add(this.Run_button);
            this.Controls.Add(this.Dev_dataGridView);
            this.Controls.Add(this.Script_richTextBox);
            this.Controls.Add(this.top_Title_Background_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeveloperForm_Form12";
            this.Text = "DeveloperForm_Form12";
            this.Load += new System.EventHandler(this.DeveloperForm_Form12_Load);
            this.top_Title_Background_panel.ResumeLayout(false);
            this.top_Title_Background_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dev_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel top_Title_Background_panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Advokater_Top_label;
        private System.Windows.Forms.RichTextBox Script_richTextBox;
        private System.Windows.Forms.DataGridView Dev_dataGridView;
        private System.Windows.Forms.Button Run_button;
        private System.Windows.Forms.Button copy_selected_column_button;
        private System.Windows.Forms.TextBox Search_Script_textBox;
        private System.Windows.Forms.Button Clear_SearchBox_button;
    }
}