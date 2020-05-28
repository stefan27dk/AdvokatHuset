using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View_GUI
{
    class My_Timer
    {


         public My_Timer()
         {
            this.hours_textBox = new System.Windows.Forms.TextBox();
            this.minutes_textBox = new System.Windows.Forms.TextBox();
            this.seconds_textBox = new System.Windows.Forms.TextBox();
            this.timeTable_listView = new System.Windows.Forms.ListView();
            this.columnDays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMinutes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSeconds = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.edit_textBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.resize_trackBar = new System.Windows.Forms.TrackBar();
            this.fk1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hours_label = new System.Windows.Forms.Label();
            this.min_label = new System.Windows.Forms.Label();
            this.sec_label = new System.Windows.Forms.Label();
            this.day_label = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.timer_Controls_holder_panel = new System.Windows.Forms.Panel();
            this.equals_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.resetAndContinue_button = new System.Windows.Forms.Button();
            this.AddresetAnd_stop_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.refresh_label = new System.Windows.Forms.Label();
            this.add_label = new System.Windows.Forms.Label();
            this.start_label = new System.Windows.Forms.Label();
            this.stop_button = new System.Windows.Forms.Button();
            this.Up_Down_label = new System.Windows.Forms.Label();
            this.reset_button = new System.Windows.Forms.Button();
            this.count_down_button = new System.Windows.Forms.Button();
            this.StartPause_button1 = new System.Windows.Forms.Button();
            this.add_time_button = new System.Windows.Forms.Button();
            this.holder_panel = new System.Windows.Forms.Panel();
            this.save_button = new System.Windows.Forms.Button();
            this.open_folder_button = new System.Windows.Forms.Button();
            this.save_Edit_button = new System.Windows.Forms.Button();
            this.AbortEdit_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resize_trackBar)).BeginInit();
            this.timer_Controls_holder_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.holder_panel.SuspendLayout();
            // 
            // hours_textBox
            // 
            this.hours_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(255)))), ((int)(((byte)(171)))));
            this.hours_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hours_textBox.Location = new System.Drawing.Point(96, 22);
            this.hours_textBox.Name = "hours_textBox";
            this.hours_textBox.Size = new System.Drawing.Size(65, 20);
            this.hours_textBox.TabIndex = 0;
            this.hours_textBox.Text = "0";
            // 
            // minutes_textBox
            // 
            this.minutes_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(255)))), ((int)(((byte)(171)))));
            this.minutes_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minutes_textBox.Location = new System.Drawing.Point(177, 22);
            this.minutes_textBox.Name = "minutes_textBox";
            this.minutes_textBox.Size = new System.Drawing.Size(65, 20);
            this.minutes_textBox.TabIndex = 1;
            this.minutes_textBox.Text = "0";
            // 
            // seconds_textBox
            // 
            this.seconds_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(255)))), ((int)(((byte)(171)))));
            this.seconds_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seconds_textBox.Location = new System.Drawing.Point(260, 22);
            this.seconds_textBox.Name = "seconds_textBox";
            this.seconds_textBox.Size = new System.Drawing.Size(65, 20);
            this.seconds_textBox.TabIndex = 2;
            this.seconds_textBox.Text = "0";
            // 
            // timeTable_listView
            // 
            this.timeTable_listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeTable_listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeTable_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDays,
            this.columnHours,
            this.columnMinutes,
            this.columnSeconds,
            this.columnTag,
            this.columnName,
            this.columnEvent,
            this.columnType,
            this.columnDate});
            this.timeTable_listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeTable_listView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.timeTable_listView.FullRowSelect = true;
            this.timeTable_listView.HideSelection = false;
            this.timeTable_listView.Location = new System.Drawing.Point(0, 42);
            this.timeTable_listView.MaximumSize = new System.Drawing.Size(587, 100);
            this.timeTable_listView.MinimumSize = new System.Drawing.Size(370, 100);
            this.timeTable_listView.Name = "timeTable_listView";
            this.timeTable_listView.Size = new System.Drawing.Size(370, 100);
            this.timeTable_listView.TabIndex = 10;
            this.timeTable_listView.UseCompatibleStateImageBehavior = false;
            this.timeTable_listView.View = System.Windows.Forms.View.Details;
            this.timeTable_listView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.timeTable_listView_MouseUp);
            // 
            // columnDays
            // 
            this.columnDays.Text = "Days:";
            this.columnDays.Width = 55;
            // 
            // columnHours
            // 
            this.columnHours.Text = "Hours";
            this.columnHours.Width = 40;
            // 
            // columnMinutes
            // 
            this.columnMinutes.Text = "Min:";
            this.columnMinutes.Width = 40;
            // 
            // columnSeconds
            // 
            this.columnSeconds.Text = "Sec:";
            this.columnSeconds.Width = 40;
            // 
            // columnTag
            // 
            this.columnTag.Text = "Tag";
            this.columnTag.Width = 70;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 100;
            // 
            // columnEvent
            // 
            this.columnEvent.Text = "Event:";
            // 
            // columnType
            // 
            this.columnType.Text = "Type:";
            // 
            // columnDate
            // 
            this.columnDate.Text = "DateTime:";
            this.columnDate.Width = 120;
            // 
            // edit_textBox
            // 
            this.edit_textBox.Location = new System.Drawing.Point(3, 148);
            this.edit_textBox.Name = "edit_textBox";
            this.edit_textBox.Size = new System.Drawing.Size(100, 20);
            this.edit_textBox.TabIndex = 15;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox1.Location = new System.Drawing.Point(14, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(65, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "0";
            // 
            // resize_trackBar
            // 
            this.resize_trackBar.Location = new System.Drawing.Point(271, 148);
            this.resize_trackBar.Maximum = 600;
            this.resize_trackBar.Minimum = 370;
            this.resize_trackBar.Name = "resize_trackBar";
            this.resize_trackBar.Size = new System.Drawing.Size(71, 45);
            this.resize_trackBar.TabIndex = 19;
            this.resize_trackBar.Value = 370;
            this.resize_trackBar.ValueChanged += new System.EventHandler(this.resize_trackBar_ValueChanged);
            // 
            // fk1
            // 
            this.fk1.AutoSize = true;
            this.fk1.Font = new System.Drawing.Font("Miriam CLM", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.fk1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(106)))));
            this.fk1.Location = new System.Drawing.Point(165, 24);
            this.fk1.Name = "fk1";
            this.fk1.Size = new System.Drawing.Size(10, 15);
            this.fk1.TabIndex = 20;
            this.fk1.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miriam CLM", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(106)))));
            this.label1.Location = new System.Drawing.Point(246, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = ":";
            // 
            // hours_label
            // 
            this.hours_label.AutoSize = true;
            this.hours_label.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hours_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(106)))));
            this.hours_label.Location = new System.Drawing.Point(95, 4);
            this.hours_label.Name = "hours_label";
            this.hours_label.Size = new System.Drawing.Size(43, 15);
            this.hours_label.TabIndex = 22;
            this.hours_label.Text = "Hours:";
            // 
            // min_label
            // 
            this.min_label.AutoSize = true;
            this.min_label.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.min_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(106)))));
            this.min_label.Location = new System.Drawing.Point(177, 4);
            this.min_label.Name = "min_label";
            this.min_label.Size = new System.Drawing.Size(32, 15);
            this.min_label.TabIndex = 23;
            this.min_label.Text = "Min:";
            // 
            // sec_label
            // 
            this.sec_label.AutoSize = true;
            this.sec_label.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sec_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(106)))));
            this.sec_label.Location = new System.Drawing.Point(260, 4);
            this.sec_label.Name = "sec_label";
            this.sec_label.Size = new System.Drawing.Size(29, 15);
            this.sec_label.TabIndex = 24;
            this.sec_label.Text = "Sec:";
            // 
            // day_label
            // 
            this.day_label.AutoSize = true;
            this.day_label.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.day_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(106)))));
            this.day_label.Location = new System.Drawing.Point(15, 4);
            this.day_label.Name = "day_label";
            this.day_label.Size = new System.Drawing.Size(45, 15);
            this.day_label.TabIndex = 25;
            this.day_label.Text = "Days: =";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(341, 151);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(25, 20);
            this.textBox2.TabIndex = 26;
            // 
            // timer_Controls_holder_panel
            // 
            this.timer_Controls_holder_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timer_Controls_holder_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timer_Controls_holder_panel.Controls.Add(this.equals_label);
            this.timer_Controls_holder_panel.Controls.Add(this.panel1);
            this.timer_Controls_holder_panel.Controls.Add(this.label2);
            this.timer_Controls_holder_panel.Controls.Add(this.refresh_label);
            this.timer_Controls_holder_panel.Controls.Add(this.add_label);
            this.timer_Controls_holder_panel.Controls.Add(this.start_label);
            this.timer_Controls_holder_panel.Controls.Add(this.stop_button);
            this.timer_Controls_holder_panel.Controls.Add(this.Up_Down_label);
            this.timer_Controls_holder_panel.Controls.Add(this.hours_textBox);
            this.timer_Controls_holder_panel.Controls.Add(this.reset_button);
            this.timer_Controls_holder_panel.Controls.Add(this.day_label);
            this.timer_Controls_holder_panel.Controls.Add(this.count_down_button);
            this.timer_Controls_holder_panel.Controls.Add(this.minutes_textBox);
            this.timer_Controls_holder_panel.Controls.Add(this.sec_label);
            this.timer_Controls_holder_panel.Controls.Add(this.seconds_textBox);
            this.timer_Controls_holder_panel.Controls.Add(this.min_label);
            this.timer_Controls_holder_panel.Controls.Add(this.StartPause_button1);
            this.timer_Controls_holder_panel.Controls.Add(this.hours_label);
            this.timer_Controls_holder_panel.Controls.Add(this.label1);
            this.timer_Controls_holder_panel.Controls.Add(this.fk1);
            this.timer_Controls_holder_panel.Controls.Add(this.add_time_button);
            this.timer_Controls_holder_panel.Controls.Add(this.textBox1);
            this.timer_Controls_holder_panel.Location = new System.Drawing.Point(19, 187);
            this.timer_Controls_holder_panel.Name = "timer_Controls_holder_panel";
            this.timer_Controls_holder_panel.Size = new System.Drawing.Size(347, 124);
            this.timer_Controls_holder_panel.TabIndex = 27;
            // 
            // equals_label
            // 
            this.equals_label.AutoSize = true;
            this.equals_label.Font = new System.Drawing.Font("Miriam CLM", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.equals_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(106)))));
            this.equals_label.Location = new System.Drawing.Point(82, 25);
            this.equals_label.Name = "equals_label";
            this.equals_label.Size = new System.Drawing.Size(13, 15);
            this.equals_label.TabIndex = 31;
            this.equals_label.Text = "=";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.resetAndContinue_button);
            this.panel1.Controls.Add(this.AddresetAnd_stop_button);
            this.panel1.Location = new System.Drawing.Point(241, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(87, 58);
            this.panel1.TabIndex = 30;
            // 
            // resetAndContinue_button
            // 
            this.resetAndContinue_button.BackgroundImage = global::View_GUI.Properties.Resources.Untitled;
            this.resetAndContinue_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.resetAndContinue_button.FlatAppearance.BorderSize = 0;
            this.resetAndContinue_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.resetAndContinue_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.resetAndContinue_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetAndContinue_button.Location = new System.Drawing.Point(3, 3);
            this.resetAndContinue_button.Name = "resetAndContinue_button";
            this.resetAndContinue_button.Size = new System.Drawing.Size(77, 25);
            this.resetAndContinue_button.TabIndex = 8;
            this.resetAndContinue_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.resetAndContinue_button.UseVisualStyleBackColor = true;
            this.resetAndContinue_button.Click += new System.EventHandler(this.resetAndContinue_button_Click);
            // 
            // AddresetAnd_stop_button
            // 
            this.AddresetAnd_stop_button.BackgroundImage = global::View_GUI.Properties.Resources.Untitled__1_;
            this.AddresetAnd_stop_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddresetAnd_stop_button.FlatAppearance.BorderSize = 0;
            this.AddresetAnd_stop_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.AddresetAnd_stop_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.AddresetAnd_stop_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddresetAnd_stop_button.Location = new System.Drawing.Point(4, 27);
            this.AddresetAnd_stop_button.Name = "AddresetAnd_stop_button";
            this.AddresetAnd_stop_button.Size = new System.Drawing.Size(75, 23);
            this.AddresetAnd_stop_button.TabIndex = 14;
            this.AddresetAnd_stop_button.UseVisualStyleBackColor = true;
            this.AddresetAnd_stop_button.Click += new System.EventHandler(this.AddresetAnd_stop_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(102)))));
            this.label2.Location = new System.Drawing.Point(203, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 30;
            this.label2.Text = "Del";
            // 
            // refresh_label
            // 
            this.refresh_label.AutoSize = true;
            this.refresh_label.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refresh_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(102)))));
            this.refresh_label.Location = new System.Drawing.Point(106, 89);
            this.refresh_label.Name = "refresh_label";
            this.refresh_label.Size = new System.Drawing.Size(16, 14);
            this.refresh_label.TabIndex = 29;
            this.refresh_label.Text = "R";
            // 
            // add_label
            // 
            this.add_label.AutoSize = true;
            this.add_label.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(102)))));
            this.add_label.Location = new System.Drawing.Point(54, 89);
            this.add_label.Name = "add_label";
            this.add_label.Size = new System.Drawing.Size(33, 14);
            this.add_label.TabIndex = 28;
            this.add_label.Text = "Add";
            // 
            // start_label
            // 
            this.start_label.AutoSize = true;
            this.start_label.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(102)))));
            this.start_label.Location = new System.Drawing.Point(13, 89);
            this.start_label.Name = "start_label";
            this.start_label.Size = new System.Drawing.Size(26, 14);
            this.start_label.TabIndex = 27;
            this.start_label.Text = "S/S";
            // 
            // stop_button
            // 
            this.stop_button.BackgroundImage = global::View_GUI.Properties.Actions_stop_icon;
            this.stop_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stop_button.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.stop_button.FlatAppearance.BorderSize = 0;
            this.stop_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.stop_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.stop_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stop_button.Location = new System.Drawing.Point(199, 52);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(33, 33);
            this.stop_button.TabIndex = 6;
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.end_button_Click);
            // 
            // Up_Down_label
            // 
            this.Up_Down_label.AutoSize = true;
            this.Up_Down_label.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Up_Down_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(102)))));
            this.Up_Down_label.Location = new System.Drawing.Point(146, 89);
            this.Up_Down_label.Name = "Up_Down_label";
            this.Up_Down_label.Size = new System.Drawing.Size(30, 14);
            this.Up_Down_label.TabIndex = 26;
            this.Up_Down_label.Text = "U/D";
            // 
            // reset_button
            // 
            this.reset_button.BackgroundImage = global::View_GUI.Properties.Resources.Reload_icon;
            this.reset_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.reset_button.FlatAppearance.BorderSize = 0;
            this.reset_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.reset_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.reset_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset_button.Location = new System.Drawing.Point(99, 53);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(33, 33);
            this.reset_button.TabIndex = 5;
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // count_down_button
            // 
            this.count_down_button.BackgroundImage = global::View_GUI.Properties.Resources.Upload_icon__3_;
            this.count_down_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.count_down_button.FlatAppearance.BorderSize = 0;
            this.count_down_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.count_down_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.count_down_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.count_down_button.Location = new System.Drawing.Point(144, 52);
            this.count_down_button.Name = "count_down_button";
            this.count_down_button.Size = new System.Drawing.Size(33, 33);
            this.count_down_button.TabIndex = 11;
            this.count_down_button.UseVisualStyleBackColor = true;
            this.count_down_button.Click += new System.EventHandler(this.count_down_button_Click);
            // 
            // StartPause_button1
            // 
            this.StartPause_button1.BackgroundImage = global::View_GUI.Properties.Resources.Eject_Hot_icon;
            this.StartPause_button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StartPause_button1.FlatAppearance.BorderSize = 0;
            this.StartPause_button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.StartPause_button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.StartPause_button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartPause_button1.Location = new System.Drawing.Point(10, 52);
            this.StartPause_button1.Name = "StartPause_button1";
            this.StartPause_button1.Size = new System.Drawing.Size(33, 33);
            this.StartPause_button1.TabIndex = 4;
            this.StartPause_button1.UseVisualStyleBackColor = true;
            this.StartPause_button1.Click += new System.EventHandler(this.StartPause_button1_Click);
            // 
            // add_time_button
            // 
            this.add_time_button.BackgroundImage = global::View_GUI.Properties.Resources.add_icon;
            this.add_time_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.add_time_button.FlatAppearance.BorderSize = 0;
            this.add_time_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.add_time_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.add_time_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_time_button.Location = new System.Drawing.Point(57, 56);
            this.add_time_button.Name = "add_time_button";
            this.add_time_button.Size = new System.Drawing.Size(25, 25);
            this.add_time_button.TabIndex = 9;
            this.add_time_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.add_time_button.UseVisualStyleBackColor = true;
            this.add_time_button.Click += new System.EventHandler(this.add_time_button_Click);
            // 
            // holder_panel
            // 
            this.holder_panel.AutoSize = true;
            this.holder_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.holder_panel.Controls.Add(this.edit_textBox);
            this.holder_panel.Controls.Add(this.timer_Controls_holder_panel);
            this.holder_panel.Controls.Add(this.textBox2);
            this.holder_panel.Controls.Add(this.save_button);
            this.holder_panel.Controls.Add(this.open_folder_button);
            this.holder_panel.Controls.Add(this.timeTable_listView);
            this.holder_panel.Controls.Add(this.save_Edit_button);
            this.holder_panel.Controls.Add(this.AbortEdit_button);
            this.holder_panel.Controls.Add(this.resize_trackBar);
            this.holder_panel.Location = new System.Drawing.Point(12, 12);
            this.holder_panel.Name = "holder_panel";
            this.holder_panel.Size = new System.Drawing.Size(373, 314);
            this.holder_panel.TabIndex = 29;
            // 
            // save_button
            // 
            this.save_button.BackgroundImage = global::View_GUI.Properties.Resources.Actions_document_save_icon;
            this.save_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.save_button.Location = new System.Drawing.Point(8, 3);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(33, 33);
            this.save_button.TabIndex = 12;
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // open_folder_button
            // 
            this.open_folder_button.BackgroundImage = global::View_GUI.Properties.Resources.win7_ico_shell32_dll_003;
            this.open_folder_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.open_folder_button.Location = new System.Drawing.Point(47, 3);
            this.open_folder_button.Name = "open_folder_button";
            this.open_folder_button.Size = new System.Drawing.Size(33, 33);
            this.open_folder_button.TabIndex = 28;
            this.open_folder_button.UseVisualStyleBackColor = true;
            this.open_folder_button.Click += new System.EventHandler(this.open_folder_button_Click);
            // 
            // save_Edit_button
            // 
            this.save_Edit_button.BackgroundImage = global::View_GUI.Properties.Resources.floppy_icon;
            this.save_Edit_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.save_Edit_button.Location = new System.Drawing.Point(109, 148);
            this.save_Edit_button.Name = "save_Edit_button";
            this.save_Edit_button.Size = new System.Drawing.Size(23, 23);
            this.save_Edit_button.TabIndex = 16;
            this.save_Edit_button.UseVisualStyleBackColor = true;
            this.save_Edit_button.Click += new System.EventHandler(this.save_Edit_button_Click);
            // 
            // AbortEdit_button
            // 
            this.AbortEdit_button.BackgroundImage = global::View_GUI.Properties.Resources.Actions_edit_delete_icon;
            this.AbortEdit_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AbortEdit_button.Location = new System.Drawing.Point(134, 148);
            this.AbortEdit_button.Name = "AbortEdit_button";
            this.AbortEdit_button.Size = new System.Drawing.Size(23, 23);
            this.AbortEdit_button.TabIndex = 17;
            this.AbortEdit_button.UseVisualStyleBackColor = true;
            this.AbortEdit_button.Click += new System.EventHandler(this.AbortEdit_button_Click);
            // 
           


         }



        private System.Windows.Forms.TextBox hours_textBox;
        private System.Windows.Forms.TextBox minutes_textBox;
        private System.Windows.Forms.TextBox seconds_textBox;
        private System.Windows.Forms.Button StartPause_button1;
        private System.Windows.Forms.Button reset_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Button resetAndContinue_button;
        private System.Windows.Forms.Button add_time_button;
        private System.Windows.Forms.ListView timeTable_listView;
        private System.Windows.Forms.ColumnHeader columnHours;
        private System.Windows.Forms.ColumnHeader columnMinutes;
        private System.Windows.Forms.ColumnHeader columnSeconds;
        private System.Windows.Forms.ColumnHeader columnDays;
        private System.Windows.Forms.ColumnHeader columnTag;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnEvent;
        private System.Windows.Forms.ColumnHeader columnDate;
        private System.Windows.Forms.Button count_down_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button AddresetAnd_stop_button;
        private System.Windows.Forms.TextBox edit_textBox;
        private System.Windows.Forms.Button save_Edit_button;
        private System.Windows.Forms.Button AbortEdit_button;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar resize_trackBar;
        private System.Windows.Forms.Label fk1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label hours_label;
        private System.Windows.Forms.Label min_label;
        private System.Windows.Forms.Label sec_label;
        private System.Windows.Forms.Label day_label;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel timer_Controls_holder_panel;
        private System.Windows.Forms.Button open_folder_button;
        private System.Windows.Forms.Panel holder_panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label refresh_label;
        private System.Windows.Forms.Label add_label;
        private System.Windows.Forms.Label start_label;
        private System.Windows.Forms.Label Up_Down_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label equals_label;















       //--------METHODS-----------------::SATRT::-------------------------------------------------------------------



        string savePath = "C://";
        string saveName = "";




        bool countDownTrigger = false;
        int seconds = 0;
        int minutes = 0;
        int hours = 0;
        int selecdedItemForEdit = 0;
        string PressedButton = ""; // String to determain wich button was pressed "Gets recorded in the listview box on added time"

        // Timer
        System.Windows.Forms.Timer timer1;

   



   







        // Timmer Body
        private void Timer1()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer_Tick);

            // Tick
            void timer_Tick(object sender, EventArgs e)
            {
                Count();
            }

        }




        // Timer on Tick
        private void Count()
        {
            if (countDownTrigger == false)
            {
                CountUP();

            }
            else
            {
                CountDown();
            }

        }





        private void CountDown()
        {
            seconds -= 1;

            if (seconds == -1)
            {

                if (minutes != 0)
                {
                    minutes -= 1;
                    seconds = 59;
                }

                else if (hours != 0) // If minutes "0"
                {


                    hours -= 1;
                    minutes = 60;
                    minutes -= 1;
                    seconds = 60;

                    hours_textBox.Text = hours.ToString();
                }

                else
                {

                    timer1.Stop();
                    seconds = 0;
                    ChangeTextBoxColorReset();

                    // Sound End "Tada"
                    System.Media.SoundPlayer endsound = new System.Media.SoundPlayer(@"C:\Windows\Media\tada.wav");
                    endsound.Play();

                }



                minutes_textBox.Text = minutes.ToString();
            }


            seconds_textBox.Text = seconds.ToString();
        }










        // Count UP
        private void CountUP()
        {



            // Add second
            seconds += 1;


            if (seconds == 60)// If 1 minute
            {
                seconds = 0; // Reset Seconds
                minutes += 1; // Add minute to minutes




                if (minutes == 60)// IF 1 Hour
                {
                    minutes = 0;
                    hours += 1;

                    // Update Hour Textbox
                    hours_textBox.Text = hours.ToString();

                }


            }

            minutes_textBox.Text = minutes.ToString();
            seconds_textBox.Text = seconds.ToString();
        }


        // Textboxes Update
        private void TimerTextBoxesUpdate()
        {
            //hundreds_textBox.Text = hundreds.ToString();
            seconds_textBox.Text = seconds.ToString();
            minutes_textBox.Text = minutes.ToString();
            hours_textBox.Text = hours.ToString();
        }




        //END- Button
        private void end_button_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            seconds = 0;
            minutes = 0;
            hours = 0;

            // Make the textboxes "0"
            TimerTextBoxesUpdate();

            // Allow to write in the textboxes
            EnableTextboxes(); // Enable Textboxes
        }




        // Enable Textboxes
        private void EnableTextboxes()
        {
            hours_textBox.ReadOnly = false;
            minutes_textBox.ReadOnly = false;
            seconds_textBox.ReadOnly = false;

        }



        // Disable Textboxes
        private void DisableTextboxes()
        {
            hours_textBox.ReadOnly = true;
            minutes_textBox.ReadOnly = true;
            seconds_textBox.ReadOnly = true;

        }




        // Change Time
        private void ChangeTime()
        {
            //bool hu = int.TryParse(hundreds_textBox.Text, out hundreds);
            bool se = int.TryParse(seconds_textBox.Text, out seconds);
            bool mi = int.TryParse(minutes_textBox.Text, out minutes);
            bool ho = int.TryParse(hours_textBox.Text, out hours);


            // Validate Input "Maximum number"


            if (seconds > 60 || seconds < 0)
            {
                seconds = 0;
            }

            if (minutes > 60 || minutes < 0)
            {
                minutes = 0;
            }

            if (hours < 0)
            {
                hours = 0;
                hours_textBox.Text = "0";
            }

        }






        //Start / Pause
        private void StartPause_button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {


                ChangeTime();
                timer1.Enabled = true;
                DisableTextboxes();// Disable Textboxes
                timer1.Start();

                // If time is 0 and the time is set to count down
                if (countDownTrigger == true && (hours_textBox.Text == "0" && minutes_textBox.Text == "0" && seconds_textBox.Text == "0"))
                {
                    // Info Message
                    MessageBox.Show("The Time is set to count down please change to count UP or \"Change the start time in the textboxes so its not 0\"", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                // Time Count Up Color
                if (countDownTrigger == false)
                {
                    ChangeTextBoxColorCountUp();
                }

            }
            else
            {   // Pause
                timer1.Enabled = false;
                EnableTextboxes(); // Enable Textboxes
                ChangeTextBoxColorInactive();
            }
        }




        // Count Up Color
        private void ChangeTextBoxColorCountUp()
        {
            seconds_textBox.BackColor = Color.FromArgb(150, 236, 255);
            minutes_textBox.BackColor = Color.FromArgb(150, 236, 255);
            hours_textBox.BackColor = Color.FromArgb(150, 236, 255);

        }




        // Inactive textboxzes Color "On Stop this color"
        private void ChangeTextBoxColorInactive()
        {
            seconds_textBox.BackColor = Color.FromArgb(255, 150, 150);
            minutes_textBox.BackColor = Color.FromArgb(255, 150, 150);
            hours_textBox.BackColor = Color.FromArgb(255, 150, 150);

        }



        // Reset Color Textboxes
        private void ChangeTextBoxColorReset()
        {
            seconds_textBox.BackColor = Color.FromArgb(228, 255, 171);
            minutes_textBox.BackColor = Color.FromArgb(228, 255, 171);
            hours_textBox.BackColor = Color.FromArgb(228, 255, 171);

        }



        // Color Count Down
        private void ChangeTextBoxColorCountDown()
        {
            seconds_textBox.BackColor = Color.FromArgb(255, 186, 133);
            minutes_textBox.BackColor = Color.FromArgb(255, 186, 133);
            hours_textBox.BackColor = Color.FromArgb(255, 186, 133);

        }




        // CountDown "TRUE" / "FALSE"
        private void count_down_button_Click(object sender, EventArgs e)
        {
            if (countDownTrigger == false)
            {
                countDownTrigger = true;
                count_down_button.BackgroundImage = Properties.Resources.Upload_icon__2_;
                ChangeTextBoxColorCountDown(); // Color
            }

            else
            {

                countDownTrigger = false;
                count_down_button.BackgroundImage = Properties.Resources.Upload_icon__3_;
                ChangeTextBoxColorCountUp(); // Color

            }

        }





        //Add Time to List and continue - Button
        private void add_time_button_Click(object sender, EventArgs e)
        {
            PressedButton = "Add";
            AddTimeToList();
        }



        // Add to list
        private void AddTimeToList()
        {

            string type = "";
            if (countDownTrigger == true)
            {
                type = "Down";
            }
            else
            {
                type = "Up";
            }


            string[] row = { "<" + ((double)hours / 24).ToString("N2") + ">" + "=".ToString(), hours_textBox.Text, minutes_textBox.Text, seconds_textBox.Text, "N", "None", PressedButton, type, DateTime.Now.ToString() };
            ListViewItem item = new ListViewItem(row);
            timeTable_listView.Items.Add(item);
        }



        // Reset and Continue
        private void resetAndContinue_button_Click(object sender, EventArgs e)
        {
            PressedButton = "ARC";
            AddTimeToList();
            Reset();
        }


        //Only reset Values
        private void Reset()
        {
            seconds = 0;
            minutes = 0;
            hours = 0;

            seconds_textBox.Text = "0";
            minutes_textBox.Text = "0";
            hours_textBox.Text = "0";
        }



        // Reset and stop
        private void reset_button_Click(object sender, EventArgs e)
        {
            Reset();

            // Reset Color
            ChangeTextBoxColorReset();
        }


        // Add Reset and Stop
        private void AddresetAnd_stop_button_Click(object sender, EventArgs e)
        {
            PressedButton = "ARS";
            AddTimeToList();
            Reset();
            timer1.Stop();
            EnableTextboxes();
        }



        // Get Item on click
        private void timeTable_listView_MouseUp(object sender, MouseEventArgs e)
        {
            Point mousePos = timeTable_listView.PointToClient(Control.MousePosition);
            ListViewHitTestInfo hitTest = timeTable_listView.HitTest(mousePos);


            try
            {
                int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);
                edit_textBox.Text = timeTable_listView.SelectedItems[0].SubItems[columnIndex].Text;

                // Last Viewwd Color
                timeTable_listView.SelectedItems[0].BackColor = Color.FromArgb(86, 91, 92);

                selecdedItemForEdit = columnIndex; // Remember the Index so you can save the edit
            }
            catch (Exception)
            {

            }



        }

        // Save Edit
        private void save_Edit_button_Click(object sender, EventArgs e)
        {
            try
            {
                timeTable_listView.SelectedItems[0].SubItems[selecdedItemForEdit].Text = edit_textBox.Text;
                timeTable_listView.SelectedItems[0].BackColor = Color.FromArgb(255, 199, 94);
                timeTable_listView.SelectedItems[0].ForeColor = Color.Blue;

            }
            catch (Exception)
            {
                MessageBox.Show("Failed Saving: Please select item to edit first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Abort Edit // Cancel Edit
        private void AbortEdit_button_Click(object sender, EventArgs e)
        {
            edit_textBox.Text = "";
        }







        // Resize Listview  "Trackbar"
        private void resize_trackBar_ValueChanged(object sender, EventArgs e)
        {

            timeTable_listView.Width = resize_trackBar.Value;

            textBox2.Text = resize_trackBar.Value.ToString();

        }






        // Save File Button
        private void save_button_Click(object sender, EventArgs e)
        {
            SaveListView();

        }



        // Save main Method
        private void SaveListView()
        {
            // Make the file name so it maches all streamwriters "If it is at the top it gets the time when the application was started and the name with date will not change"
            saveName = "Timer -" + DateTime.Now.ToString("dd -MM-yyyy  HH-mm-ss") + ".txt";


            System.IO.File.AppendAllText(savePath + saveName, Environment.NewLine + Environment.NewLine);

            // Columns NAMES
            for (int c = 0; c < timeTable_listView.Columns.Count; c++)
            {
                System.IO.File.AppendAllText(savePath + saveName, timeTable_listView.Columns[c].Text + "\t");
            }

            // Add new Line int the txt file
            System.IO.File.AppendAllText(savePath + saveName, Environment.NewLine + Environment.NewLine);


            // Get all Items  "loop All items"
            for (int i = 0; i < timeTable_listView.Items.Count; i++)
            {

                // Loop all Sub Items of the Current Item "[i]"
                for (int a = 0; a < timeTable_listView.Items[i].SubItems.Count; a++)
                {
                    // Write the sub item "[a]" to the file with "tab betwen each item"
                    System.IO.File.AppendAllText(savePath + saveName, timeTable_listView.Items[i].SubItems[a].Text + "\t");
                }

                // Add new Line "the new Row" starts at new line
                System.IO.File.AppendAllText(savePath + saveName, Environment.NewLine);
            }

        }



        // Open Local Folder
        private void open_folder_button_Click(object sender, EventArgs e)
        {
            Process.Start(savePath);
        }


        // Save before Exit
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveListView();
        }





























    }
}
