using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View_GUI
{
    public partial class DeveloperForm_Form12 : Form
    {

        //Resources
        DataSet DEV_DataSet;
        Datagridview_Loader Load_Script;

        private string Script_For_Run = "";



        public DeveloperForm_Form12()
        {
            InitializeComponent();
        }




         // Load
        private void DeveloperForm_Form12_Load(object sender, EventArgs e)
        {
            DatagridviewSettings_Style(); // DGV - Settings
            
        }












       //------------------------::RUN::----------::START::---------------------------------------------------------
        // Run - Button
        private void Run_button_Click(object sender, EventArgs e)
        {    
           Run_Script(); 
        }

           
         // Run Script
        private void Run_Script()
        {

            try
            {
                Script_Selector();
              
                //Script_richTextBox
                DEV_DataSet = new DataSet(); // 1# New Dataset - This will be the Source
                Load_Script = new Datagridview_Loader(); // Loader DGV Class
              
              
                Load_Script.DB_Populate(Script_richTextBox.SelectedText, DEV_DataSet, "DEV"); // Loader Method to Populate the Dataset
                Dev_dataGridView.DataSource = DEV_DataSet; // Datagridview Source is the Dataset that was populated in the Loader Class
                Dev_dataGridView.DataMember = "DEV"; // Data Member is the Part of the DataSet we want to read from "You can have different Datamembers in the same Dataset ans just switch trought them"
              
                Script_richTextBox.DeselectAll();
            }
            catch (Exception)
            {

            }
          
        }



           // Select Script /Selected or All
          private void Script_Selector()
          {
              if(Script_richTextBox.SelectedText != String.Empty)
              {
                Script_For_Run = Script_richTextBox.SelectedText;
              }
              else
              {
                Script_richTextBox.SelectAll();
                Script_For_Run = Script_richTextBox.SelectedText;
                
              }
          }

        //------------------------::RUN::----------::END::---------------------------------------------------------













        // Datagridview Settings - Style - Setting on Load
        private void DatagridviewSettings_Style()
        {

            Black_DatagridviewStyle();
            // Datagridview DOUBLE BUFFERING // Double Buffer is Used so the Datagridview dont lagg on resize
            //Set Double buffering on the Grid using reflection and the bindingflags enum.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            Dev_dataGridView, new object[] { true });
        }



        // Datagridview Color Style
        private void Black_DatagridviewStyle()
        {

            this.Dev_dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.Dev_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 34);
            this.Dev_dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(59, 203, 255);  // Datagridview Fore Color
            this.Dev_dataGridView.GridColor = Color.Gray;
            this.Dev_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point
            this.Dev_dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 94);
            this.Dev_dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 32, 29);

            //this.Advokat_dataGridView.DefaultCellStyle..Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold);

        }















        //Shortcut keys-----KEY WATCHER-----------::START::--------------------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            // Run Script
            if (keyData == (Keys.F5))
            {
                Run_Script();
            }

         

            return base.ProcessCmdKey(ref msg, keyData);
        }




        // Copy - Selected Cell
        private void copy_selected_column_button_Click(object sender, EventArgs e)
        {
            if(Dev_dataGridView.SelectedRows.Count != 0)
            {
            Clipboard.SetText(Dev_dataGridView.SelectedRows[0].Cells[Dev_dataGridView.CurrentCell.ColumnIndex].Value.ToString());

            }
        }

        //Shortcut keys-----KEY WATCHER---------::END::------------------------------------------------------------------------------------













           

         // Keyword Colors
         private void Stylize_Custom_SQL_Words(string word, Color color, int startIndex)  // StartIndex is not required
         {


            int index = -1; // Word index  
            int selectStart = Script_richTextBox.SelectionStart;  // The Index of the Typer

            while ((index = Script_richTextBox.Text.IndexOf(word, (index + 1), StringComparison.OrdinalIgnoreCase)) != -1)   // index = word start index // if there is no more words than returns  -1 Text ended
            {
                Script_richTextBox.Select((index + startIndex), word.Length); // Select the word
                Script_richTextBox.SelectionColor = color; // Change color of the Selected Word
                Script_richTextBox.Select(selectStart, 0); // Selecteion start is the Typers last position before i began to select word
                Script_richTextBox.SelectionColor = Color.FromArgb(255, 204, 64); // Reset Fore Color
                Script_richTextBox.SelectionBackColor = Script_richTextBox.BackColor;
            }

        }




        // On Text Changed - Change Word Color
        private void Script_richTextBox_TextChanged(object sender, EventArgs e)
        {

            int selectStart = Script_richTextBox.SelectionStart;  // Remember The Index of the Typer
            Script_richTextBox.SelectAll(); // Select The whole text
            Script_richTextBox.SelectionColor = Color.FromArgb(255, 204, 64); // The whole text to Yellow 
            Script_richTextBox.Select(selectStart, 0); // Move the typper to the previeous position


            Stylize_Custom_SQL_Words("Select", Color.FromArgb(187, 255, 69), 0);
            Stylize_Custom_SQL_Words("From", Color.FromArgb(82, 233, 255), 0); // StartIndex is not required
            Stylize_Custom_SQL_Words("Where", Color.FromArgb(0, 133, 250), 0);
            Stylize_Custom_SQL_Words("if", Color.Red, 0);
            Stylize_Custom_SQL_Words("Inner", Color.BlueViolet, 0);
            Stylize_Custom_SQL_Words("Join", Color.Azure, 0);
            Stylize_Custom_SQL_Words("Outter", Color.Bisque, 0);
            Stylize_Custom_SQL_Words("Full", Color.Green, 0);
            Stylize_Custom_SQL_Words("Date", Color.Green, 0);
            Stylize_Custom_SQL_Words("Delete", Color.Red, 0);
            Stylize_Custom_SQL_Words("Update", Color.Orange, 0);
            Stylize_Custom_SQL_Words("Values", Color.FromArgb(0, 250, 62), 0);
            Stylize_Custom_SQL_Words("Insert", Color.ForestGreen, 0);
            Stylize_Custom_SQL_Words("Else", Color.FromArgb(66, 135, 245), 0);
        }

       

    

     












        //-----------SEARCH---------::START::---------------------------------------------------------------------------------------

        // Search TextBox
        private void Search_Script_textBox_TextChanged(object sender, EventArgs e)
        {
            Search_In_Script();
        }





        // Search
        private void Search_In_Script()
        {

            int index = -1;
            int selectStart = Script_richTextBox.SelectionStart;  // The Index of the Typer


            // Reset Back Color
            Script_richTextBox.SelectAll();
            Script_richTextBox.SelectionBackColor = Script_richTextBox.BackColor;
            Script_richTextBox.Select(selectStart, 0);


            // Search
            if(Search_Script_textBox.Text.Length > 0) // IF SearxhTexbox is not empty
            {
                while ((index = Script_richTextBox.Text.IndexOf(Search_Script_textBox.Text, (index +1), StringComparison.OrdinalIgnoreCase)) != -1)
                {
                 
                   Script_richTextBox.Select((index), Search_Script_textBox.Text.Length); // Select the word
                   Script_richTextBox.SelectionBackColor = Color.FromArgb(196, 49, 86); // Change color of the Selected Word
                   Script_richTextBox.Select(selectStart, 0); // Selecteion start is the Typers last position before i began to select word
                   Script_richTextBox.SelectionBackColor = Script_richTextBox.BackColor; // Reset Fore Color
                   Script_richTextBox.ScrollToCaret();  // Scroll To Word
                }

            }

       

        }




        // Search on Textbox Click
        private void Search_Script_textBox_MouseDown(object sender, MouseEventArgs e)
        {
            Search_In_Script();
        }





        // Clear SearchBox
        private void Clear_SearchBox_button_Click(object sender, EventArgs e)
        {
            Search_Script_textBox.Clear();
        }


        // Clear Script
        private void Clear_Script_button_Click(object sender, EventArgs e)
        {
            Script_richTextBox.Clear();
        }


        //-----------SEARCH---------::END::---------------------------------------------------------------------------------------

    }
}
