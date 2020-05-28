using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Domain;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Media;

namespace View_GUI
{
    public partial class Ydelser_Form8 : Form
    {
     
        

        // Local Folder
        string LocalFolderPath = "C://";  // Gets Assignet in initialize

        //DB
        Ydelse ydelseinstance = new Ydelse(); // Instance af Ydelse 
        DB_Connection_Write ConnWrite; // Sql Write "
        //static readonly  DB_Connection_String ConnectionString = DB_Connection_String.GetConnectionString(); // Global Connectionstring
        //static SqlConnection connection = null; 
      

       

        // Show Ydelse - Database
        //static string show_Ydelse_Query = "Select Ydelse.*, Ydelse_Tlf.Ydelse_Tlf  From Ydelse Full Join Ydelse_Tlf ON Ydelse.Ydelse_ID = Ydelse_Tlf.Ydelse_ID AND";
        static string show_Ydelse_Query = "Select* From Ydelse";



        DataSet Ydelse_Dataset = new DataSet(); // Dataset for "Show Ydelse" and "Show Ydelse_Tlf"
                                                
 

        // Row Edit
        DataGridViewRow enterRow = new DataGridViewRow(); // On Enter






        // Validate Textboxes bools
        bool isValid = true; // Inputboxes Validator
        bool successful = false; // Successful Transaction
     



        // Undo Delete
        List<DataGridViewRow> DeletedRowsList = new List<DataGridViewRow>(); // List with deleted Rows




        // Search string
        string SearchOptions = "";
        string SearchColumn_SearchString = "";



 

        // Initialize
        public Ydelser_Form8()
        {
            InitializeComponent();
        }





        // Load
        private void Ydelse_Form9_Load(object sender, EventArgs e)
        {
            DatagridviewSettings_Style();
            LoadYdelse();// Show all Ydelse "Populating the datagridview with Curtomers "Ydelse""
            Search_ComboBox_Options_Content(); // Populate Search Combobox
            Search_ComboBox_Column_Content(); // Populate Column Search Combobox
          
        }





        //-----------SETTINGS------------::START::--------------------------------------------------------------------------------------------

        // Datagridview Settings - Style - Setting on Load
        private void DatagridviewSettings_Style()
        {

            Black_DatagridviewStyle();
            // Datagridview DOUBLE BUFFERING // Double Buffer is Used so the Datagridview dont lagg on resize
            //Set Double buffering on the Grid using reflection and the bindingflags enum.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            Ydelse_dataGridView, new object[] { true });
        }



        // Datagridview Color Style
        private void Black_DatagridviewStyle()
         {

            this.Ydelse_dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.Ydelse_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 34);
            this.Ydelse_dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(59, 203, 255);  // Datagridview Fore Color
            this.Ydelse_dataGridView.GridColor = Color.Gray;
            this.Ydelse_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point
            this.Ydelse_dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 94);
            this.Ydelse_dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 32, 29);
            
            //this.Ydelse_dataGridView.DefaultCellStyle..Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold);

         }





        //  Datagridview Color Style "White" 
        private void White_DatagridviewStyle()
        {

            this.Ydelse_dataGridView.RowsDefaultCellStyle.BackColor = DefaultBackColor;
            this.Ydelse_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = DefaultBackColor;
            this.Ydelse_dataGridView.DefaultCellStyle.ForeColor = DefaultForeColor;  // Datagridview Fore Color
            this.Ydelse_dataGridView.GridColor = Color.Gray;
            this.Ydelse_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point

        }


        //-----------SETTINGS------------::END::--------------------------------------------------------------------------------------------









        // Create Ydelse
        private void CreateYdelse()
        {
            ydelseinstance = new Ydelse();
            ydelseinstance.Navn = Ydelse_name_comboBox.Text;
            ydelseinstance.Pris = Convert.ToDouble(Ydelse_Pris_textBox.Text);
            ydelseinstance.Type = load_Type_Ydelse_comboBox.SelectedItem.ToString();
            ydelseinstance.Art = Ydelse_Art_textBox.Text;

        }





        // Insert to DB  "Insert Ydelse to DB"
        private void InsertToDB()
        {
            ConnWrite = new DB_Connection_Write(); // "Write to DB Class instance"
            string YdelseQuery = $"BEGIN DECLARE @UNIQUEX UNIQUEIDENTIFIER SET @UNIQUEX = NEWID(); Insert Into Ydelse Values('{ydelseinstance.Navn}', {ydelseinstance.Pris},'{ydelseinstance.Type}','{ydelseinstance.Art}', (@UNIQUEX), '{DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss")}') END;"; // Query
            successful = ConnWrite.CreateCommand(YdelseQuery); // Write to DB Input and "Execution"
        }









        // Key Events--Validating--Textboxes----::START::---------------------------------------------- 

  


        // Validate Ydelse_Pris
        private void Ydelse_Pris_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            bool have_comma = false;
            if (e.KeyChar != (char)8 && e.KeyChar != (char)26)/// "Allow backspace"  and CTRL+Z
            {
                e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out decimal isNumber);///Prevent letters
            }


            // Comma To Dot Convert
            if (e.KeyChar == (char)44)//If Comma
            {
                e.KeyChar = (char)46;
            }




            // Check for comma
            for (int i = 0; i < Ydelse_Pris_textBox.Text.Length; i++)
            {
                int commaIndex = 0;

                if (Ydelse_Pris_textBox.Text[i] == '.')
                {
                    commaIndex = i;
                    have_comma = true;


                    

                    // Max 2 digits after Comma
                    if (Ydelse_Pris_textBox.Text.Length > commaIndex + 2 && e.KeyChar != (char)8)
                    {
                        e.Handled = true;
                    }

                }


            }

            if (e.KeyChar == (char)46 && have_comma == false && Ydelse_Pris_textBox.Text != "")//If Comma and ther is no comma in the textbox than Add it
            {
                e.Handled = false;
            }





        }







        // Ydelse_Type Validating
        private void Ydelse_Type_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (int.TryParse(e.KeyChar.ToString(), out int isNumber));///Prevent Numbers and Spaces


        }

      

        // Key Events------::END::----------------------------------------------------------------------


       






        // Validate ALL Inputs ------------::START::----------------------------------------------------------------------------
        private void ValidateALL()
        {
            isValid = true; // Reset it here

            //Name Validation---------------------------------------------------------------------------->
            if (Ydelse_name_comboBox.Text.Length < 2)
            {
                isValid = false; // Now you cant proceed because its not valid
                
            }

          


            // PRIS Validation------------------------------------------------------------------------> 
            if (Ydelse_Pris_textBox.TextLength < 1)
            {
                isValid = false; // Now you cant proceed because its not valid
                Ydelse_Pris_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
            
                 for (int i = 0; i < Ydelse_Pris_textBox.TextLength; i++)
                 {
                
                     if (String.IsNullOrEmpty(Ydelse_Pris_textBox.Text[i].ToString()) || !decimal.TryParse(Ydelse_Pris_textBox.Text.ToString(), out decimal isNumber))  
                     {
                         isValid = false; // Now you cant proceed because its not valid
                         Ydelse_Pris_textBox.BackColor = Color.FromArgb(255, 128, 128);
                        break;
                     }
                
                 }

            }


           


            // Ydelse_Art_textBox Validation------------------------------------------------------------------------>
            if (Ydelse_Art_textBox.TextLength < 1)
            {
                isValid = false;
                Ydelse_Art_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }


            if (load_Type_Ydelse_comboBox.SelectedIndex == -1)
            {
                isValid = false;
            }


           
        }

        // Validate ALL Inputs ------------::END::----------------------------------------------------------------------------














        //-----------------CREATE---TEXTBOXES-SETTINGS---------::START::----------------------------------------------

        // Reset Textbox Color
        private void TextboxesResetColor()
        {
         
            Ydelse_Pris_textBox.BackColor = Color.FromArgb(220, 243, 250);
            Ydelse_Art_textBox.BackColor = Color.FromArgb(220, 243, 250);

        }




        // Clear All Textboxes
        private void ClearTextboxes()
        {
            Ydelse_name_comboBox.Items.Clear();
            Ydelse_name_comboBox.Text = "";
            Ydelse_Pris_textBox.Clear();
            load_Type_Ydelse_comboBox.Items.Clear();
            Ydelse_Art_textBox.Clear();
        }




        // Save Button 
        private void Ydelse_Save_button_Click(object sender, EventArgs e)
        {
            TextboxesResetColor(); // Reset Color
            ValidateALL(); // Validate All

            if (isValid == true)// If all is valid
            {
                CreateYdelse();  
                InsertToDB();


                // If transaction was successful Clear the textboxes
                if (successful == true)
                {
                ClearTextboxes(); 
                }


            }

        }




        // Clear ALL -Textboxes - BUTTON
        private void create_Clear_All_textboxes_button_Click(object sender, EventArgs e)
        {
            ClearTextboxes();
            TextboxesResetColor();
        }

 
        //-----------------CREATE---TEXTBOXES-SETTINGS---------::END::----------------------------------------------












        // Form Menu-----------::START::-------------------------------------------

        // Vis Rediger // Show Datagridview
        private void vis_rediger_Ydelse_button_Click(object sender, EventArgs e)
        {
            datagridviewBackground_panel.Visible = true;
            backPanel_Textboxes_panel.Visible = false;
            //this.YdelseTableAdapter.Fill(this.advokathusetDataSet.Ydelse);
        }



  

        // Opret Button
        private void opret_Ydelse_button_Click(object sender, EventArgs e)
        {
            backPanel_Textboxes_panel.Visible = true;
            datagridviewBackground_panel.Visible = false;// Hide Datagridview
           
        }

        // Form Menu-----------::END::----------------------------------------------



        
       







        //Shortcut keys-----KEY WATCHER-----------::START::--------------------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            // Open Item Menu Shortcut
            if (keyData == (Keys.Delete))
            {
                if(Ydelse_dataGridView.Focused && Ydelse_dataGridView.SelectedRows.Count > 0)
                {
                    DeleteFromDatagridview();
                }
            }

            // Copy Editing Cell
            if (keyData == (Keys.Control | Keys.C | Keys.Alt))
            {
            Clipboard.SetText(Ydelse_dataGridView.SelectedRows[0].Cells[Ydelse_dataGridView.CurrentCell.ColumnIndex].Value.ToString());
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Shortcut keys-----KEY WATCHER---------::END::------------------------------------------------------------------------------------














        //----------DELETE------------------::START::-------------------------------------------------------------------------------------- 

        // Delete Button
        private void delete_button_Click(object sender, EventArgs e)    
        {
            DeleteFromDatagridview();
        }
   



        // Delete From Datagridview
        private void DeleteFromDatagridview()
        {
            try
            {
                if(Ydelse_dataGridView.SelectedRows.Count > 0) // Check if any row is selected
                {
                   DialogResult deleteDialog = MessageBox.Show("Are you sure that you want to delete the selected row?", "Delete: Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                   if (deleteDialog == DialogResult.Yes)
                   {
                       AddRowToList(); // Add to list the row that will be deleted
                       Ydelse_dataGridView.Rows.RemoveAt(Ydelse_dataGridView.SelectedRows[0].Index); //  Delete selected row
                       SaveDataGridView(); // Save to DB
                   }
                    else if(deleteDialog == DialogResult.No)
                    {
                        RefreshDatagridview();
                    }

                }
            }


               catch (Exception a)  // If No row is Selected Catch the Exception
               {
              
                   DialogResult errordialog = MessageBox.Show("Please Select Row in order to delete:  Do you want to see additional information about the error", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error); // Error Message
                   if (errordialog == DialogResult.Yes) // Do you want to see more info about the error
                   {
                       MessageBox.Show($"{a.Message}:{a.Data}", "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Information); // Additional Information
                   }
              
               }
        }





         // Add the row for deletion to list   "Part of Undo"
        private void AddRowToList()
        {
           
            if (Ydelse_dataGridView.CurrentRow.Cells.Count == Ydelse_dataGridView.ColumnCount) // If all cels are selected on the current row
            {
                
                DataGridViewRow row = (DataGridViewRow)Ydelse_dataGridView.SelectedRows[0].Clone();
                for (int i = 0; i < Ydelse_dataGridView.SelectedCells.Count; i++)
                {
                    row.Cells[i].Value = Ydelse_dataGridView.SelectedCells[i].Value;
                }
                DeletedRowsList.Add(row);
            }
        }





        // Undo  DELETE - Button
        private void undo_button_Click(object sender, EventArgs e)
        {
            //DataTable dtImage = Ydelse_Dataset.Tables[0];

            //    Ydelse_Dataset.Tables.Add(dtImage);


            // Always the last item
            if (DeletedRowsList.Count > 0 && Ydelse_dataGridView.DataMember == "Ydelse")
            {
                int lastindex = DeletedRowsList.Count - 1;
               Ydelse_Dataset.Tables[0].Rows.Add(DeletedRowsList[lastindex].Cells[0].Value, DeletedRowsList[lastindex].Cells[1].Value, DeletedRowsList[lastindex].Cells[2].Value, DeletedRowsList[lastindex].Cells[3].Value, DeletedRowsList[lastindex].Cells[4].Value, DeletedRowsList[lastindex].Cells[5].Value);
               SaveDataGridView(); // Save to DB  

                //inserdetindex.Add(Ydelse);
                DeletedRowsList.RemoveAt(lastindex); // Remove Last index
                RefreshDatagridview(); // Refresh
            }


        }

        //----------DELETE------------------::END::-------------------------------------------------------------------------------------- 










        // Show Customers "Ydelse" - Main Method
        private void LoadYdelse()
        {
            // Clear the Columns "Column Change order because of the second Table Ydelse_Tlf" TLF Colum becomes the first
            if(Ydelse_dataGridView.DataMember == "Ydelse_Tlf")
            {
              Ydelse_dataGridView.Columns.Clear();
            }


            Ydelse_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"

            ydelseinstance.Ydelse_Datagridview_Loader(show_Ydelse_Query, Ydelse_Dataset, "Ydelse");
            Ydelse_dataGridView.DataSource = Ydelse_Dataset;
            Ydelse_dataGridView.DataMember = "Ydelse";
 
           
        }


     
        

         //----SAVE-UPDATE--DATAGRIDVIEW-------::START::---------------------------------------------------------------------------------- 

        // Save  "Ydelse"
        private void SaveDataGridView()
        {          
            
            if(Ydelse_dataGridView.DataMember == "Ydelse")   // Ydelse
            {
                Ydelse_dataGridView.EndEdit();
                DatagridView_Save Update_Ydelse = new DatagridView_Save();
                Update_Ydelse.DatagridView_Update("Select* From Ydelse", Ydelse_Dataset, "Ydelse", this.Ydelse_dataGridView);
            }
         

        }

           
     

        // UPDATE - Get row to Compare on Row enter "Used to determine if the row have been changed so we know when to "Save the changes""
        private void Ydelse_dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Selected_Row_For_Compare();
        }




       // Row Enter - Main Method "It is used also for reseting the row Comparison when Column Header Is Clicked"
       private void Selected_Row_For_Compare()
        {
            if (Ydelse_dataGridView.SelectedRows.Count > 0) // I there is selected row
            {

                // Clone Row
                enterRow = (DataGridViewRow)Ydelse_dataGridView.SelectedRows[0].Clone();

                // Add Data to the Cloned Row
                for (int i = 0; i < Ydelse_dataGridView.SelectedRows[0].Cells.Count; i++)
                {
                    enterRow.Cells[i].Value = Ydelse_dataGridView.SelectedRows[0].Cells[i].Value;
                }


            }

        }





        // Row Leave - "ON - Validattion" - UPDATE "SAVE" - On ROW LEAVE AFTER VALIDATION  "Save"
        private void Ydelse_dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
             bool edited = false; // Check if the Row was edited

            if (Ydelse_dataGridView.SelectedRows.Count > 0) // Selected minimum 1 row
            {


                for (int j = 0; j < Ydelse_dataGridView.SelectedRows[0].Cells.Count; j++)
                {
                

                    if (Ydelse_dataGridView.SelectedRows[0].Cells[j].Value != null && !Ydelse_dataGridView.SelectedRows[0].Cells[j].Value.Equals(enterRow.Cells[j].Value))
                    {
                        edited = true;
                        break;
                    }
                }
               
               

                if (edited == true )
                {
                    DialogResult saveDialog = MessageBox.Show("Are you sure that you want ot save the changes?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (saveDialog == DialogResult.Yes)
                    {
                        SaveDataGridView(); // Save
                        RefreshDatagridview(); // Refresh
                                               //MessageBox.Show("Changes Are Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (saveDialog == DialogResult.No) // Refresh if DialogResult == No
                    {
                        RefreshDatagridview(); // Refresh
                    }

                }



            }
        }


      


        // Reset Row Selection "For Save"
        private void Ydelse_dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Selected_Row_For_Compare();
        }

      

        // RefreshDatagridview "After Update OR Cancelation"
        private void RefreshDatagridview()
        {
          
                LoadYdelse();
            
        }


        //----SAVE-UPDATE--DATAGRIDVIEW-------::END::--------------------------------------------------------------------------------------- 











      










        //-------------BUTTONS-Datagridview--Menu-------::START::----------------------------------------------------------------------------

        // Local Folder
        private void local_folder_button_Click(object sender, EventArgs e)
        {
            Open_Local_Folder();
        }




        // Show All Customers "Ydelse" - Button
        private void show_all_button_Click(object sender, EventArgs e)
        {
            LoadYdelse();


            // ResetSearch_Textbox Color
            if (search_textBox.Text.Length > 0)
            {
                search_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }


        }




        // Open Local Folder
        private void Open_Local_Folder()
        {
            Process.Start(LocalFolderPath);
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\recycle.wav");
            simpleSound.Play();
        }



        




        //Button
        // Clear Search_Text-Box "RESET" - CHANGE IMAGE ON HOVER
        private void reset_Search_Textbox_button_MouseEnter(object sender, EventArgs e)
        {
            reset_Search_Textbox_button.BackgroundImage = Properties.Resources.Hover_Del_3;
        }




         //Button
        // Clear Search_Text-Box "RESET" - CHANGE IMAGE On Leave - Reset Image
        private void reset_Search_Textbox_button_MouseLeave(object sender, EventArgs e)
        {
            reset_Search_Textbox_button.BackgroundImage = Properties.Resources.Untitled2;
        }

        //-------------BUTTONS-Datagridview--Menu-------::END::--------------------------------------------------------------------------


















        //------------------------(SEARCH)-----::START::---------------------------------------------------------------------------------

        // Search ComboBox - Content
        private void Search_ComboBox_Options_Content()
        {
            search_options_comboBox.Items.Add("Indholder");
            search_options_comboBox.Items.Add("Præcis");
            search_options_comboBox.Items.Add("Start");
            search_options_comboBox.Items.Add("Slut");
            search_options_comboBox.SelectedIndex = 0;
        }
     
        // Search Options
        private void Search_Options()
        {
            switch(search_options_comboBox.SelectedIndex) //If Combobox index --->
            {
                // ---> Equals 0,1,2,3 // Assign SearchOptions // Accordingly

                case 0: //Contains
                    SearchOptions = $"Like  '%{search_textBox.Text}%'";
                    break;
                case 1: // Exact
                    SearchOptions = $"Like '{search_textBox.Text}'";
                    break;

                case 2: // Start
                    SearchOptions = $"Like '{search_textBox.Text}%'";
                    break;

                case 3: //End
                    SearchOptions = $"Like  '%{search_textBox.Text}'";
                    break;

               
            
            }
           
        }




        // Search Column - Content
        private void Search_ComboBox_Column_Content()
        {
            Search_Column_comboBox.Items.Add("Alle");
            Search_Column_comboBox.Items.Add("Navn");
            Search_Column_comboBox.Items.Add("Pris");
            Search_Column_comboBox.Items.Add("Type");
            Search_Column_comboBox.Items.Add("Art");
            Search_Column_comboBox.Items.Add("Nr");
            Search_Column_comboBox.Items.Add("Oprets_dato");
 
            Search_Column_comboBox.SelectedIndex = 0;

        }


        // Search Queries - / Columns / Search - Text
        private void Search_Column()
        {
            //SearchColumn_SearchString

            switch (Search_Column_comboBox.SelectedIndex)
            {
                case 0: // ALL
                    SearchColumn_SearchString = $"IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select* From Ydelse Where Ydelse.Ydelse_Navn {SearchOptions} OR Ydelse.Ydelse_Art {SearchOptions} OR Ydelse.Ydelse_Nr {SearchOptions} OR Ydelse.Ydelse_Oprets_Dato {SearchOptions} OR Ydelse.Ydelse_Type {SearchOptions} END ELSE BEGIN Select* From Ydelse Where Ydelse.Ydelse_Navn {SearchOptions} OR Ydelse.Ydelse_Art {SearchOptions} OR Ydelse.Ydelse_Nr {SearchOptions} OR Ydelse.Ydelse_Oprets_Dato {SearchOptions} OR Ydelse.Ydelse_Pris {SearchOptions} OR Ydelse.Ydelse_Type {SearchOptions} END;";
                    //IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select* From Ydelse Where  Ydelse_Fornavn {SearchOptions} OR Ydelse_Efternavn {SearchOptions} OR Ydelse_Adresse {SearchOptions} OR Ydelse_Email {SearchOptions} OR Ydelse_Oprets_Dato {SearchOptions} OR Ydelse_ID {SearchOptions} END ELSE  BEGIN SELECT Ydelse.*, Ydelse_Tlf.Ydelse_Tlf From Ydelse Full Join Ydelse_Tlf ON Ydelse.Ydelse_ID = Ydelse_Tlf.Ydelse_ID Where Ydelse_PostNr {SearchOptions} OR Ydelse_Tlf.Ydelse_Tlf {SearchOptions} OR Ydelse_Fornavn {SearchOptions} OR Ydelse_Efternavn {SearchOptions} OR Ydelse_Adresse {SearchOptions} OR Ydelse_Email {SearchOptions} OR Ydelse_Oprets_Dato {SearchOptions} OR Ydelse.Ydelse_ID {SearchOptions} END;
                    break;
                case 1: // Name
                    SearchColumn_SearchString = $"Select* From Ydelse Where Ydelse.Ydelse_Navn {SearchOptions};";
                    break;
                case 2:   // Pris
                    SearchColumn_SearchString = $"IF(ISNUMERIC('{search_textBox.Text}') = 1) BEGIN Select* From Ydelse Where Ydelse.Ydelse_Pris {SearchOptions} END;";
                    break;
                case 3:  //Type
                    SearchColumn_SearchString = $"Select* From Ydelse Where Ydelse.Ydelse_Type {SearchOptions};";
                    break;
                case 4:  // ART
                    SearchColumn_SearchString = $" Select* From Ydelse Where Ydelse.Ydelse_Art {SearchOptions};";
                    break;
                case 5: // NR
                    SearchColumn_SearchString = $" Select* From Ydelse Where Ydelse.Ydelse_Nr {SearchOptions};";
                    break;
                case 6: //TLF
                    SearchColumn_SearchString = $"Select* From Ydelse Where Ydelse.Ydelse_Oprets_Dato {SearchOptions} ";
                    break;
                  
                    //SearchColumn_SearchString = $"IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select* From Ydelse Where  Ydelse_Fornavn {SearchOptions} " +
                    //    $"OR Ydelse_Efternavn {SearchOptions} OR Ydelse_Adresse {SearchOptions} OR Ydelse_Email {SearchOptions} OR Ydelse_Oprets_Dato {SearchOptions} " +
                    //    $"OR Ydelse_ID {SearchOptions} END ELSE BEGIN SELECT Ydelse.*, Ydelse_Tlf.Ydelse_Tlf From Ydelse Full Join Ydelse_Tlf ON Ydelse.Ydelse_ID = Ydelse_Tlf.Ydelse_ID Where Ydelse_PostNr {SearchOptions} OR Ydelse_Tlf.Ydelse_Tlf {SearchOptions} END;";
            }
        }



        // Search - DB - Connection
        private void Search()
        {
            Ydelse_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"

            ydelseinstance.Ydelse_Datagridview_Loader(SearchColumn_SearchString, Ydelse_Dataset, "Ydelse");
            Ydelse_dataGridView.DataSource = Ydelse_Dataset;
            Ydelse_dataGridView.DataMember = "Ydelse";
 
        }




        // MAIN - Search Method
        private void Search_Resources()
        {
            LoadYdelse(); // Used for refreshing the datagridview Because of the Ydelse_Tlf Table appears first again
            Search_Options(); // Like
            Search_Column(); // Column and Search String
            Search(); // Ask the DB and Get Answer
        }




        // Search On Text Changed
        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            Search_Resources();

            if(search_textBox.Text == "")
            {
                LoadYdelse();
            }
        }

       


        // Automaticly Search on "Option Change"
        private void search_options_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (search_textBox.Text.Length > 0)// Search if Textbox is not empty
            {
                Search_Resources();
            }
        }




        // Search Automaticly when you change "Column Option"
        private void Search_Column_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(search_textBox.Text.Length >0)// Search if Textbox is not empty
            {
                Search_Resources(); 
            }
        }



        // Clear SearchBox
        private void reset_Search_Textbox_button_Click(object sender, EventArgs e)
        {
            search_textBox.Clear(); // Clear SearchBox
            search_textBox.BackColor = Color.FromArgb(222, 249, 255);
            LoadYdelse(); // Show All
        }



        // Search Textbox Search on Mouse Down
        private void search_textBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(search_textBox.Text.Length >0)
            {
                search_textBox.BackColor = Color.FromArgb(222, 249, 255);
                Search_Resources();
            }

        }

        //------------------------(SEARCH)-----::END::---------------------------------------------------------------------------------


















        //--------------Datagridview - Change - Color------------::START:--------------------------------------------------------------
        // Datagridview Change Color Button
        private void change_DatagridView_Color_button_Click(object sender, EventArgs e)
        {
            Change_Datgridview_Color();
        }


        // Datagridview Change Color - Main Method
        private void Change_Datgridview_Color()
        {
            if (this.Ydelse_dataGridView.RowsDefaultCellStyle.BackColor == Color.FromArgb(64, 64, 64))
            {
                White_DatagridviewStyle();
            }

            else
            {
                Black_DatagridviewStyle();
            }
        }



        // Mark Current row
        private void mark_current_row_button_Click(object sender, EventArgs e)
        {
             if(Ydelse_dataGridView.CurrentRow != null)
             {

          
                if(Ydelse_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor != Color.FromArgb(191, 50, 95))
                {
                Ydelse_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.FromArgb(191, 50, 95);
                Ydelse_dataGridView.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    Ydelse_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.FromArgb(2, 222, 160);
                    Ydelse_dataGridView.SelectedRows[0].DefaultCellStyle.ForeColor = DefaultForeColor;
                }
             }
        }
        //--------------Datagridview - Change - Color------------::END:----------------------------------------------------------------


















        //------------PDF--PRINT------------------::START::----------------------------------------------------------------------------
        // Print Datagridview
        private void print_button_Click(object sender, EventArgs e)
        {
            Datagridview_To_PDF(); // Method for Converting the Current Datagridview result to PDF
            OpenLastFile();

        }



        // Open Last File
        private void OpenLastFile()
        {
       

            // Open Last File
            DirectoryInfo directory = new DirectoryInfo(LocalFolderPath); // Create Directory with path "Not phisical Directory!"
            FileInfo Last_File = (from f in directory.GetFiles() // Get all files in the directory
                               orderby f.LastWriteTime descending // Ascending // Decending
          
                               select f).First();


            string selectFile = "/select, \"" + Last_File.FullName + "\""; // Selects the file in the folder

            // Opens Last file
            Process.Start(Last_File.FullName); // Open PDF,Png etc.
            Process.Start("explorer.exe", selectFile); // Selects the file in the folder



            // SOUND
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\recycle.wav");
            simpleSound.Play();
        }



        // PFD - Print
        private void Datagridview_To_PDF()
          {
               //USING -  iTextSharp - Class
               PdfPTable Pdf_DGV = new PdfPTable(Ydelse_dataGridView.Columns.Count);
               Pdf_DGV.DefaultCell.Padding = 3;
               Pdf_DGV.WidthPercentage = 100;
               Pdf_DGV.HorizontalAlignment = Element.ALIGN_LEFT;
               Pdf_DGV.DefaultCell.BorderWidth = 1;
             
             
               // Adding the Columns with their txt to the PDF 
               foreach(DataGridViewColumn column in Ydelse_dataGridView.Columns)
               {
                   PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                   cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255); // White Color
                   Pdf_DGV.AddCell(cell);
               }
             
             
               //Add Rows and Cells to the Pdf

              for (int i = 0; i < Ydelse_dataGridView.Rows.Count; i++)
              {
                  for (int a = 0; a < Ydelse_dataGridView.Rows[i].Cells.Count; a++)
                  {
                      if (Ydelse_dataGridView.Rows[i].Cells[a].Value != null)
                      {
             
                          Pdf_DGV.AddCell(Ydelse_dataGridView.Rows[i].Cells[a].Value.ToString());
             
                      }
             
             
                  }
              }



              // Export to PDF

            if(!Directory.Exists(LocalFolderPath))
            {
                Directory.CreateDirectory(LocalFolderPath);
            }

            using(FileStream stream = new FileStream(LocalFolderPath + "Ydelse_PDF -  "+DateTime.Now.ToString("dd-MM-yyyy   HH-mm-ss")+".pdf", FileMode.Create))
            {
                Document PDF_DOC = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(PDF_DOC, stream);
                PDF_DOC.Open();
                PDF_DOC.Add(Pdf_DGV);
                PDF_DOC.Close();
                stream.Close();


            }
          
        }



        //------------PDF--PRINT------------------::END::-------------------------------------------------------------------------------















        //-------Datagridview-Screenshot-----------------::START::---------------------------------------------------------------------- 

        // Datagridview Screenshot - Main Mehtod
        private void DatagridviewScreenshot()
        {


            int oldHeight = Ydelse_dataGridView.Height;
            Ydelse_dataGridView.Height = Ydelse_dataGridView.RowCount * Ydelse_dataGridView.RowTemplate.Height;




            // Bitmap
            Bitmap bitmapScreenshot = new Bitmap(this.Ydelse_dataGridView.Width, this.Ydelse_dataGridView.Height);

            // Draw to the bitmap
            Ydelse_dataGridView.DrawToBitmap(bitmapScreenshot, new System.Drawing.Rectangle(0, 0, this.Ydelse_dataGridView.Width, this.Ydelse_dataGridView.Height));

            // Reset the height
            Ydelse_dataGridView.Height = oldHeight;

            // Save bitmap
            bitmapScreenshot.Save(LocalFolderPath + "Ydelse_Snapshot  " + DateTime.Now.ToString("dd-MM-yyyy  HH-mm-ss") + ".png");
            Clipboard.SetDataObject(bitmapScreenshot);  // Copy Image to Clipboard Also

        
        }



        // Datagridview Screnshot - Button
        private void screenshot_datagridview_button_Click(object sender, EventArgs e)
        {
            White_DatagridviewStyle(); // Datagridview White Color
            DatagridviewScreenshot(); // Screenshot
            Black_DatagridviewStyle(); // Datagridview Color Style
            OpenLastFile();
        }


        //-------Datagridview-Screenshot-----------------::END::------------------------------------------------------------------------ 
















        //-------------CREATE-TEXTBOXES -- Reset Color on Typing-------------------::START:----------------------------------------------

  

        // Ydelse_Pris - Reset Color
        private void Ydelse_Pris_textBox_TextChanged(object sender, EventArgs e)
        {
            Ydelse_Pris_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }


 
        


        // Ydelse_Art - Reset Background
        private void Ydelse_Art_textBox_TextChanged(object sender, EventArgs e)
        {
            Ydelse_Art_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }


        //-------------CREATE-TEXTBOXES -- Reset Color on Typing-------------------::END:--------------------------------------------------







        // ERROR - Handling - Default Datagridview Error handling
        private void Ydelse_dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Ydelse_dataGridView.RefreshEdit(); // Reset
            MessageBox.Show("Der Opståd Fejl, Input er ikke i korekt format","Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }






        // Load Specialer Main Methods ----||Advoakt-Specialer and Create Speciale||
        private void Load_Type_ydelse(ComboBox combo)
        {
            load_Type_Ydelse_comboBox.Items.Clear();
            DB_Loader Load_Type_ydelse = new DB_Loader();
            string Query = "Select* From Type_Ydelse";
            combo = Load_Type_ydelse.Populate_Combobox(Query, combo);
        }


        // Load TYPE Ydelse
        private void load_Type_Ydelse_comboBox_Click(object sender, EventArgs e)
        {
            Load_Type_ydelse((ComboBox)sender);
        }


        // Copy Selected Column Cell Text
        private void copy_selected_column_button_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Ydelse_dataGridView.SelectedRows[0].Cells[Ydelse_dataGridView.CurrentCell.ColumnIndex].Value.ToString());

        }





        // Ydelse Name Combobox - Load
        private void Ydelse_name_comboBox_Click(object sender, EventArgs e)
        {
            Ydelse_name_comboBox.Items.Clear(); // Clear
            DB_Loader ydelse_Name = new DB_Loader();
            Ydelse_name_comboBox = ydelse_Name.Populate_Combobox("Select Ydelse_Navn From Ydelse", Ydelse_name_comboBox);

        }



        // Prevent Selecting Item From the dropDown
        private void Ydelse_name_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ydelse_name_comboBox.SelectedIndex = -1;
        }


    }
}
