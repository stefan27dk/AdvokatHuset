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

namespace View_GUI
{
    public partial class Kunder_Form9 : Form
    {


        // Local Folder
        string LocalFolderPath = "C://";  // Gets Assignet in initialize

        //DB
        Kunde kundeinstance; // Instance af Kunde 
        DB_Connection_Write ConnWrite; // Sql Write "
        //static readonly  DB_Connection_String ConnectionString = DB_Connection_String.GetConnectionString(); // Global Connectionstring
        //static SqlConnection connection = null; 
      

       

        // Show Kunder - Database
        static string show_Kunde_Query = "Select Kunde.*, Kunde_Tlf.Kunde_Tlf  From Kunde Full Join Kunde_Tlf ON Kunde.Kunde_ID = Kunde_Tlf.Kunde_ID";
        DataSet Kunde_Dataset = new DataSet(); // Dataset for "Show Kunde" and "Show Kunde_Tlf"
                                               //SqlDataAdapter showKundeAdapter = null;


        //TKunde_Tlf - Database
        static string Kunde_Tlf_Select_Query = "Select* From Kunde_Tlf";
        //static string Kunde_Tlf_Select_Query = "Select Kunde_Tlf.*, Kunde.Kunde_Fornavn, Kunde.Kunde_Efternavn From Kunde_Tlf Inner Join Kunde ON Kunde_Tlf.Kunde_ID = Kunde.Kunde_ID;";




        // Row Edit
        DataGridViewRow enterRow = new DataGridViewRow();





        // Validate Textboxes bools
        bool isValid = true; // Inputboxes Validator
        bool successful = false; // Successful Transaction
     



        // Undo Delete
        List<DataGridViewRow> DeletedRowsList = new List<DataGridViewRow>(); // List with deleted Rows




        // Search string
        string SearchOptions = "";
        string SearchColumn_SearchString = "";



        // Initialize
        public Kunder_Form9()
        {
            InitializeComponent();
        }





        // Load
        private void Kunder_Form9_Load(object sender, EventArgs e)
        {
            Black_DatagridviewStyle();
            LoadKunder();// Show all Kunder "Populating the datagridview with Curtomers "Kunder""
            Search_ComboBox_Options_Content(); // Populate Search Combobox
            Search_ComboBox_Column_Content(); // Populate Column Search Combobox

        }


        // Datagridview Color Style
        private void Black_DatagridviewStyle()
         {

            this.Kunde_dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.Kunde_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 34);
            this.Kunde_dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(59, 203, 255);  // Datagridview Fore Color
            this.Kunde_dataGridView.GridColor = Color.Gray;
            this.Kunde_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point
            this.Kunde_dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 94);
            this.Kunde_dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 32, 29);
            
            //this.Kunde_dataGridView.DefaultCellStyle..Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold);

         }





        //  Datagridview Color Style "White" 
        private void White_DatagridviewStyle()
        {

            this.Kunde_dataGridView.RowsDefaultCellStyle.BackColor = DefaultBackColor;
            this.Kunde_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = DefaultBackColor;
            this.Kunde_dataGridView.DefaultCellStyle.ForeColor = DefaultForeColor;  // Datagridview Fore Color
            this.Kunde_dataGridView.GridColor = Color.Gray;
            this.Kunde_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point

        }


        // Create Kunde
        private void CreateKunde()
        {
            kundeinstance = new Kunde();
            kundeinstance.Fornavn = kunder_name_textBox.Text;
            kundeinstance.Efternavn = kunder_surname_textBox.Text;
            kundeinstance.PostNr = Convert.ToInt32(kunder_zipcCode_textBox.Text);
            kundeinstance.Adresse = kunder_adr_textBox.Text;
            kundeinstance.TlfNr = Convert.ToInt32(kunder_tlf_textBox.Text);
            kundeinstance.Mail = kunde_email_textBox.Text;

        }





        // Insert to DB  "Insert Kunde to DB"
        private void InsertToDB()
        {
            ConnWrite = new DB_Connection_Write(); // "Write to DB Class instance"
            string KundeQuery = $"BEGIN DECLARE @UNIQUEX UNIQUEIDENTIFIER SET @UNIQUEX = NEWID(); Insert into Kunde Values('{kundeinstance.Fornavn}','{kundeinstance.Efternavn}',{kundeinstance.PostNr},'{kundeinstance.Adresse}', (@UNIQUEX),'{kundeinstance.Mail}', '{DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss")}'); Insert INTO Kunde_Tlf Values('{kunder_tlf_textBox.Text}',(@UNIQUEX)); END;"; // Query
            successful = ConnWrite.CreateCommand(KundeQuery); // Write to DB Input and "Execution"
        }









        // Key Events--Validating--Textboxes----::START::---------------------------------------------- 
      
        // Validate Name
        private void kunder_name_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = (int.TryParse(e.KeyChar.ToString(), out int isNumber) || (e.KeyChar == (char)Keys.Space));///Prevent Numbers and Spaces

        }



        // Validate Surname
        private void kunder_surname_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (int.TryParse(e.KeyChar.ToString(), out int isNumber));///Prevent Numbers and Spaces
        }




        // Zip Code Validating
        private void kunder_zipcCode_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && e.KeyChar != (char)26)/// "Allow backspace"  and CTRL+Z
            {
                    e.Handled = !int.TryParse(e.KeyChar.ToString(), out int isNumber);///Prevent letters
            }
        
        }




        // TLF Validating
        private void kunder_tlf_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar != (char)8 && e.KeyChar != (char)26) // If not Backspace or CTRL+Z
            {
                e.Handled =  !int.TryParse(e.KeyChar.ToString(), out int isNumber); // Enable/ Disable e.Handled  "If Not int than disable it" 
            }
        }

        // Key Events------::END::----------------------------------------------------------------------










        // Validate ALL Inputs
        private void ValidateALL()
        {
            isValid = true; // Reset it here

            //Name Validation---------------------------------------------------------------------------->
            if (kunder_name_textBox.TextLength < 2)
            {
                isValid = false; // Now you cant proceed because its not valid
                kunder_name_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }

            else
            {
                
                  for (int i = 0; i < kunder_name_textBox.TextLength; i++)
                  {
                 
                      if(String.IsNullOrEmpty(kunder_name_textBox.Text[i].ToString()) || int.TryParse(kunder_name_textBox.Text[i].ToString(), out int isNumber) || kunder_name_textBox.Text[i].ToString() == " ") // Check for numbers, null, 
                      {
                          isValid = false; // Now you cant proceed because its not valid
                          kunder_name_textBox.BackColor = Color.FromArgb(255, 128, 128);
                        break;
                      }
                      
                  }

            }




            // Surname Validation------------------------------------------------------------------------> 
            if (kunder_surname_textBox.TextLength < 2)
            {
                isValid = false; // Now you cant proceed because its not valid
                kunder_surname_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
            
                 for (int i = 0; i < kunder_surname_textBox.TextLength; i++)
                 {
                
                     if (String.IsNullOrEmpty(kunder_surname_textBox.Text[i].ToString()) || int.TryParse(kunder_surname_textBox.Text[i].ToString(), out int isNumber))  
                     {
                         isValid = false; // Now you cant proceed because its not valid
                         kunder_surname_textBox.BackColor = Color.FromArgb(255, 128, 128);
                        break;
                     }
                
                 }

            }



             // TLF Validation--------------------------------------------------------------------------->

             if (kunder_tlf_textBox.TextLength < 8)
             {
                isValid = false;
                kunder_tlf_textBox.BackColor = Color.FromArgb(255, 128, 128);

            }

            else if(!int.TryParse(kunder_tlf_textBox.Text, out int isNumber))
            {
                isValid = false;
                kunder_tlf_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }



             // Email Validation------------------------------------------------------------------------->
              if(kunde_email_textBox.TextLength < 5)
              {
                isValid = false;
                kunde_email_textBox.BackColor = Color.FromArgb(255, 128, 128);

              }

              else  
              {
                // Check for "@"
                bool at = false;

                for (int i = 0; i < kunde_email_textBox.TextLength; i++)
                {
                     if(kunde_email_textBox.Text[i] == '@')
                     {
                        at = true; // Contains "@"
                     }

                }

                 // If itdont contains "@"
                if(at == false)
                {
                    isValid = false;
                    kunde_email_textBox.BackColor = Color.FromArgb(255, 128, 128);

                }


            }



              //Zip Code Valiadtion---------------------------------------------------------------------->
               if(kunder_zipcCode_textBox.TextLength < 4)
               {
                isValid = false;
                kunder_zipcCode_textBox.BackColor = Color.FromArgb(255, 128, 128);
               }
               else if(!int.TryParse(kunder_zipcCode_textBox.Text, out int isNumber))
               {
                isValid = false;
                kunder_zipcCode_textBox.BackColor = Color.FromArgb(255, 128, 128);
               }
            



            // Adress Validation------------------------------------------------------------------------>
            if(kunder_adr_textBox.TextLength < 2)
            {
                isValid = false;
                kunder_adr_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }
            
           
        }




        // Reset Textbox Color
        private void TextboxesResetColor()
        {
            kunder_name_textBox.BackColor = Color.White;
            kunder_surname_textBox.BackColor = Color.White;
            kunder_tlf_textBox.BackColor = Color.White;
            kunde_email_textBox.BackColor = Color.White;
            kunder_zipcCode_textBox.BackColor = Color.White;
            kunder_adr_textBox.BackColor = Color.White;

        }




        // Clear All Textboxes
        private void ClearTextboxes()
        {
            kunder_name_textBox.Clear();
            kunder_surname_textBox.Clear();
            kunder_tlf_textBox.Clear();
            kunde_email_textBox.Clear();
            kunder_zipcCode_textBox.Clear();
            kunder_adr_textBox.Clear();
        }




        // Save Button 
        private void kunder_Save_button_Click(object sender, EventArgs e)
        {
            TextboxesResetColor(); // Reset Color
            ValidateALL(); // Validate All

            if (isValid == true)// If all is valid
            {
                CreateKunde();  
                InsertToDB();


                // If transaction was successful Clear the textboxes
                if (successful == true)
                {
                ClearTextboxes(); 
                }


            }

        }










        // Form Menu-----------::START::-------------------------------------------

        // Vis Rediger // Show Datagridview
        private void vis_rediger_kunder_button_Click(object sender, EventArgs e)
        {
            datagridviewBackground_panel.Visible = true;
            backPanel_Textboxes_panel.Visible = false;
            //this.kundeTableAdapter.Fill(this.advokathusetDataSet.Kunde);
        }










        // Opret Button
        private void opret_kunde_button_Click(object sender, EventArgs e)
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
                if(Kunde_dataGridView.Focused && Kunde_dataGridView.SelectedRows.Count > 0)
                {
                    DeleteFromDatagridview();
                }
            }

            // Copy Editing Cell
            if (keyData == (Keys.Control | Keys.C | Keys.Alt))
            {
                for (int i = 0; i < Kunde_dataGridView.SelectedRows[0].Cells.Count; i++)
                {
                    if(Kunde_dataGridView.SelectedCells[i].IsInEditMode)
                    {
                      Clipboard.SetText(Kunde_dataGridView.SelectedCells[i].Value.ToString());
                    }
                }
                
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Shortcut keys-----KEY WATCHER---------::END::------------------------------------------------------------------------------------








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
                if(Kunde_dataGridView.SelectedRows.Count > 0) // Check if any row is selected
                {
                   DialogResult deleteDialog = MessageBox.Show("Are you sure that you want to delete the selected row?", "Delete: Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                   if (deleteDialog == DialogResult.Yes)
                   {
                       AddRowToList(); // Add to list the row that will be deleted
                       Kunde_dataGridView.Rows.RemoveAt(Kunde_dataGridView.SelectedRows[0].Index); //  Delete selected row
                       SaveDataGridView(); // Save to DB
                   }
                    else if(deleteDialog == DialogResult.No)
                    {
                        //RefreshDatagridview();
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
           
            if (Kunde_dataGridView.CurrentRow.Cells.Count == Kunde_dataGridView.ColumnCount) // If all cels are selected on the current row
            {
                
                DataGridViewRow row = (DataGridViewRow)Kunde_dataGridView.SelectedRows[0].Clone();
                for (int i = 0; i < Kunde_dataGridView.SelectedCells.Count; i++)
                {
                    row.Cells[i].Value = Kunde_dataGridView.SelectedCells[i].Value;
                }
                DeletedRowsList.Add(row);
            }
        }


      





        // Undo  Button
        private void undo_button_Click(object sender, EventArgs e)
        {
            //DataTable dtImage = Kunde_Dataset.Tables[0];

            //    Kunde_Dataset.Tables.Add(dtImage);


            // Always the last item
            if (DeletedRowsList.Count > 0 && Kunde_dataGridView.DataMember == "Kunde")
            {
                int lastindex = DeletedRowsList.Count - 1;
               Kunde_Dataset.Tables[0].Rows.Add(DeletedRowsList[lastindex].Cells[0].Value, DeletedRowsList[lastindex].Cells[1].Value, DeletedRowsList[lastindex].Cells[2].Value, DeletedRowsList[lastindex].Cells[3].Value, DeletedRowsList[lastindex].Cells[4].Value, DeletedRowsList[lastindex].Cells[5].Value, DeletedRowsList[lastindex].Cells[6].Value);
               SaveDataGridView(); // Save to DB  

                //inserdetindex.Add(kunde);
                DeletedRowsList.RemoveAt(lastindex); // Remove Last index

            }


        }



     



        // Show Customers "Kunder" - Main Method
        private void LoadKunder()
        {
            // Clear the Columns "Column Change order because of the second Table Kunde_Tlf" TLF Colum becomes the first
            if(Kunde_dataGridView.DataMember == "Kunde_Tlf")
            {
              Kunde_dataGridView.Columns.Clear();
            }
            Kunde_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"
            Datagridview_Loader Load_Customers = new Datagridview_Loader();
            Load_Customers.DB_Populate(show_Kunde_Query, Kunde_Dataset, "Kunde");
            Kunde_dataGridView.DataSource = Kunde_Dataset;
            Kunde_dataGridView.DataMember = "Kunde";
            Kunde_dataGridView.Columns[7].ReadOnly = true;  // Forbid Editing Kunde_Tlf
           
        }

        // Load Kunde_Tlf
        private void LoadKunde_Tlf()
        {
            string Kunde_Tlf_Kunde_navn_Select = "Select Kunde_Tlf.*, Kunde.Kunde_Fornavn, Kunde.Kunde_Efternavn From Kunde_Tlf Inner Join Kunde ON Kunde_Tlf.Kunde_ID = Kunde.Kunde_ID;";
            // Clear the Columns 
            if (Kunde_dataGridView.DataMember == "Kunde")
            {
                Kunde_dataGridView.Columns.Clear();
            }

            // Kunde_Tlf
            Kunde_Dataset.Clear();
            Datagridview_Loader Load_Kunde_Tlf = new Datagridview_Loader();
            Load_Kunde_Tlf.DB_Populate(Kunde_Tlf_Kunde_navn_Select, Kunde_Dataset, "Kunde_Tlf");
            Kunde_dataGridView.DataSource = Kunde_Dataset;
            Kunde_dataGridView.DataMember = "Kunde_Tlf";
            Kunde_dataGridView.Columns[2].ReadOnly = true;  // Forbid Editing Kunde_ForNavn
            Kunde_dataGridView.Columns[3].ReadOnly = true;  // Forbid Editing Kunde_EfterNavn

        }




        // Show All Customers "Kunder" - Button
        private void show_all_button_Click(object sender, EventArgs e)
        {
            LoadKunder();

            if(search_textBox.Text.Length > 0)
            {
                search_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }


        }






        // Save Cutomers "KUNDER"
        private void SaveDataGridView()
        {          
            
            // Save changes to DB  "UPDATE Kunder"
            if(Kunde_dataGridView.DataMember == "Kunde_Tlf") // Kunde_Tlf
            {
                Kunde_dataGridView.EndEdit();
                DatagridView_Save Update_Kunder = new DatagridView_Save();
                Update_Kunder.DatagridView_Update(Kunde_Tlf_Select_Query, Kunde_Dataset, "Kunde_Tlf");

            }

            else if(Kunde_dataGridView.DataMember == "Kunde")   // KUNDE
            {
                    Kunde_dataGridView.EndEdit();
                    DatagridView_Save Update_Kunder = new DatagridView_Save();
                    Update_Kunder.DatagridView_Update("Select* From Kunde", Kunde_Dataset, "Kunde");
            }
         

        }

           









        // UPDATE - Get row to Compare on Row enter "Used to determine if the row have been changed so we know when to edit "Save the changes""
        private void Kunde_dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Selected_Row_For_Compare();
        }




       // Row Enter - Main Method "It is used also for reseting the row Comparison when Column Header Is Clicked"
       private void Selected_Row_For_Compare()
        {
            if (Kunde_dataGridView.SelectedRows.Count > 0) // I there are
            {

                // Clone Row
                enterRow = (DataGridViewRow)Kunde_dataGridView.SelectedRows[0].Clone();

                // Add Data to the Cloned Row
                for (int i = 0; i < Kunde_dataGridView.SelectedRows[0].Cells.Count; i++)
                {
                    enterRow.Cells[i].Value = Kunde_dataGridView.SelectedRows[0].Cells[i].Value;
                }


            }

        }




        // Reset Row Selection "For Save"
        private void Kunde_dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Selected_Row_For_Compare();
        }









        // UPDATE "SAVE" - On ROW LEAVE AFTER VALIDATION  "Save"
        private void Kunde_dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            bool edited = false; // Check if the Row was edited

            if (Kunde_dataGridView.SelectedRows.Count > 0) // Selected minimum 1 row
            {


                  for (int j = 0; j < Kunde_dataGridView.SelectedRows[0].Cells.Count; j++)
                  {
                      if (Kunde_dataGridView.SelectedRows[0].Cells[j].Value != null && !Kunde_dataGridView.SelectedRows[0].Cells[j].Value.Equals(enterRow.Cells[j].Value))
                      {
                          edited = true;
                          break;
                      }
                  }
                
                
                  if (edited == true)
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



        // RefreshDatagridview "After Update OR Cancelation"
        private void RefreshDatagridview()
        {
            if (Kunde_dataGridView.DataMember == "Kunde")
            {
                LoadKunder();
            }
            else if (Kunde_dataGridView.DataMember == "Kunde_Tlf")
            {
                LoadKunde_Tlf();
            }
        }
    



        // Datagridview Screenshot - Main Mehtod
        private void DatagridviewScreenshot()
        {
          

            int oldHeight = Kunde_dataGridView.Height;
            Kunde_dataGridView.Height = Kunde_dataGridView.RowCount * Kunde_dataGridView.RowTemplate.Height;




            // Bitmap
            Bitmap bitmapScreenshot = new Bitmap(this.Kunde_dataGridView.Width, this.Kunde_dataGridView.Height);

            // Draw to the bitmap
            Kunde_dataGridView.DrawToBitmap(bitmapScreenshot, new System.Drawing.Rectangle(0, 0, this.Kunde_dataGridView.Width, this.Kunde_dataGridView.Height));

            // Reset the height
            Kunde_dataGridView.Height = oldHeight;

            // Save bitmap
            bitmapScreenshot.Save(LocalFolderPath+"Kunde_Snapshot  "+DateTime.Now.ToString("dd-MM-yyyy  HH-mm-ss")+".png");
            Clipboard.SetDataObject(bitmapScreenshot);  // Copy Image to Clipboard Also

      

        }

   




        // Datagridview Screnshot - Button
        private void screenshot_datagridview_button_Click(object sender, EventArgs e)
        {
            White_DatagridviewStyle(); // Datagridview White Color
            DatagridviewScreenshot(); // Screenshot
            Black_DatagridviewStyle(); // Datagridview Color Style
           
        }








        // Local Folder
        private void local_folder_button_Click(object sender, EventArgs e)
        {
            Open_Local_Folder();
        }



        // Open Local Folder
        private void Open_Local_Folder()
        {
            Process.Start(@"C://");
        }



        // Kunde_Tlf- Button - Show Tlf
        private void Kunde_Tlf_button_Click(object sender, EventArgs e)
        {
            LoadKunde_Tlf();
            if(search_textBox.TextLength > 0)
            {
                search_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }


        }












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
            Search_Column_comboBox.Items.Add("Efternavn");
            Search_Column_comboBox.Items.Add("Adresse");
            Search_Column_comboBox.Items.Add("PostNr");
            Search_Column_comboBox.Items.Add("Tlf");
            Search_Column_comboBox.Items.Add("ID");
            Search_Column_comboBox.Items.Add("Email");
            Search_Column_comboBox.Items.Add("Dato");
            Search_Column_comboBox.SelectedIndex = 0;

        }

        private void Search_Column()
        {
            //SearchColumn_SearchString

            switch (Search_Column_comboBox.SelectedIndex)
            {
                case 0: // ALL
                    SearchColumn_SearchString = $"IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select* From Kunde Where  Kunde_Fornavn {SearchOptions} OR Kunde_Efternavn {SearchOptions} OR Kunde_Adresse {SearchOptions} OR Kunde_Email {SearchOptions} OR Kunde_Oprets_Dato {SearchOptions} OR Kunde_ID {SearchOptions} END ELSE  BEGIN SELECT Kunde.*, Kunde_Tlf.Kunde_Tlf From Kunde Full Join Kunde_Tlf ON Kunde.Kunde_ID = Kunde_Tlf.Kunde_ID Where Kunde_PostNr {SearchOptions} OR Kunde_Tlf.Kunde_Tlf {SearchOptions} OR Kunde_Fornavn {SearchOptions} OR Kunde_Efternavn {SearchOptions} OR Kunde_Adresse {SearchOptions} OR Kunde_Email {SearchOptions} OR Kunde_Oprets_Dato {SearchOptions} OR Kunde.Kunde_ID {SearchOptions} END;  ";
                    break;
                case 1: // Name
                    SearchColumn_SearchString = $"SELECT* From Kunde Where Kunde.Kunde_Fornavn {SearchOptions}";
                    break;
                case 2:   // Surname
                    SearchColumn_SearchString = $"SELECT* From Kunde Where Kunde.Kunde_Efternavn {SearchOptions}";
                    break;
                case 3:  //Adress
                    SearchColumn_SearchString = $"SELECT* From Kunde Where Kunde.Kunde_Adresse {SearchOptions}";
                    break;
                case 4:  // Zip-Code
                    SearchColumn_SearchString = $" IF(ISNUMERIC('{search_textBox.Text}') = 1) BEGIN SELECT* From Kunde Where Kunde_PostNr {SearchOptions} END";
                    break;
                case 5: //TLF
                    SearchColumn_SearchString = $" IF(ISNUMERIC('{search_textBox.Text}') = 1) BEGIN SELECT Kunde.*, Kunde_Tlf.Kunde_Tlf From Kunde Full Join Kunde_Tlf ON  Kunde.Kunde_ID = Kunde_Tlf.Kunde_ID Where Kunde_Tlf.Kunde_Tlf {SearchOptions} END";
                    break;
                case 6: // ID
                    SearchColumn_SearchString = $"SELECT* From Kunde Where Kunde.Kunde_ID {SearchOptions}";
                    break;
                case 7: // Email
                    SearchColumn_SearchString = $"SELECT* From Kunde Where Kunde.Kunde_Email {SearchOptions}";
                    break;
                case 8: // Date
                    SearchColumn_SearchString = $"SELECT* From Kunde Where Kunde.Kunde_Oprets_Dato {SearchOptions}";

                    break;
                  
                    //SearchColumn_SearchString = $"IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select* From Kunde Where  Kunde_Fornavn {SearchOptions} " +
                    //    $"OR Kunde_Efternavn {SearchOptions} OR Kunde_Adresse {SearchOptions} OR Kunde_Email {SearchOptions} OR Kunde_Oprets_Dato {SearchOptions} " +
                    //    $"OR Kunde_ID {SearchOptions} END ELSE BEGIN SELECT Kunde.*, Kunde_Tlf.Kunde_Tlf From Kunde Full Join Kunde_Tlf ON Kunde.Kunde_ID = Kunde_Tlf.Kunde_ID Where Kunde_PostNr {SearchOptions} OR Kunde_Tlf.Kunde_Tlf {SearchOptions} END;";
            }
        }



        // Search - DB - Connection
        private void Search()
        {
            Kunde_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"
            Datagridview_Loader Load_Search_Result = new Datagridview_Loader();
            Load_Search_Result.DB_Populate(SearchColumn_SearchString, Kunde_Dataset, "Kunde");
            Kunde_dataGridView.DataSource = Kunde_Dataset;
            Kunde_dataGridView.DataMember = "Kunde";
 
        }




        // MAIN - Search Method
        private void Search_Resources()
        {
            LoadKunder(); // Used for refreshing the datagridview Because of the Kunde_Tlf Table appears first again
            Search_Options(); // Like
            Search_Column(); // Column and Search String
            Search(); // Ask the DB and Get Answer
        }




        // Search On Text Changed
        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            
            Search_Resources();
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
            search_textBox.BackColor = DefaultBackColor;
            LoadKunder(); // Show All
        }



        // Search Textbox Search on Mouse Down
        private void search_textBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(search_textBox.Text.Length >0)
            {
            search_textBox.BackColor = DefaultBackColor;
            Search_Resources();
            }

        }

        //------------------------(SEARCH)-----::END::---------------------------------------------------------------------------------









   




        //--------------Datagridview - Change - Color------------::START:------------------------------------------------
        // Datagridview Change Color Button
        private void change_DatagridView_Color_button_Click(object sender, EventArgs e)
        {
            Change_Datgridview_Color();
        }


        // Datagridview Change Color - Main Method
        private void Change_Datgridview_Color()
        {
            if (this.Kunde_dataGridView.RowsDefaultCellStyle.BackColor == Color.FromArgb(64, 64, 64))
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
            if(Kunde_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor != Color.FromArgb(191, 50, 95))
            {
            Kunde_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.FromArgb(191, 50, 95);
            Kunde_dataGridView.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                Kunde_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.FromArgb(2, 222, 160);
                Kunde_dataGridView.SelectedRows[0].DefaultCellStyle.ForeColor = DefaultForeColor;
            }

        }









        //------------PDF--PRINT------------------::START::-------------------------------------------------------------------------------------------------------------------
        // Print Datagridview
        private void print_button_Click(object sender, EventArgs e)
        {
            Datagridview_To_PDF();
            Process.Start(LocalFolderPath);


            // Open Last File
            DirectoryInfo directory = new DirectoryInfo(LocalFolderPath); // Create Directory with path "Not phisical Directory!"
            FileInfo myFile = (from f in directory.GetFiles() // Get all files in the directory
            orderby f.LastWriteTime descending // Ascending // Decending
            select f).First();

            // Opens Last file
            Process.Start(myFile.FullName);
          
        }




        // PFD - Print
        private void Datagridview_To_PDF()
          {
               //USING -  iTextSharp - Class
               PdfPTable Pdf_DGV = new PdfPTable(Kunde_dataGridView.Columns.Count);
               Pdf_DGV.DefaultCell.Padding = 3;
               Pdf_DGV.WidthPercentage = 100;
               Pdf_DGV.HorizontalAlignment = Element.ALIGN_LEFT;
               Pdf_DGV.DefaultCell.BorderWidth = 1;
             
             
               // Adding the Columns with their txt to the PDF 
               foreach(DataGridViewColumn column in Kunde_dataGridView.Columns)
               {
                   PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                   cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255); // White Color
                   Pdf_DGV.AddCell(cell);
               }
             
             
               //Add Rows and Cells to the Pdf

              for (int i = 0; i < Kunde_dataGridView.Rows.Count; i++)
              {
                  for (int a = 0; a < Kunde_dataGridView.Rows[i].Cells.Count; a++)
                  {
                      if (Kunde_dataGridView.Rows[i].Cells[a].Value != null)
                      {
             
                          Pdf_DGV.AddCell(Kunde_dataGridView.Rows[i].Cells[a].Value.ToString());
             
                      }
             
             
                  }
              }



              // Export to PDF

            if(!Directory.Exists(LocalFolderPath))
            {
                Directory.CreateDirectory(LocalFolderPath);
            }

            using(FileStream stream = new FileStream(LocalFolderPath + "Kunder_PDF -  "+DateTime.Now.ToString("dd-MM-yyyy   HH-mm-ss")+".pdf", FileMode.Create))
            {
                Document PDF_DOC = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(PDF_DOC, stream);
                PDF_DOC.Open();
                PDF_DOC.Add(Pdf_DGV);
                PDF_DOC.Close();
                stream.Close();


            }



            ////USING -  iTextSharp - Class
            //PdfPTable pdfTable = new PdfPTable(Kunde_dataGridView.ColumnCount);
            //pdfTable.DefaultCell.Padding = 3;
            //pdfTable.WidthPercentage = 100;
            //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            //pdfTable.DefaultCell.BorderWidth = 1;

            ////Adding Columns to the Pdf
            //foreach (DataGridViewColumn column in Kunde_dataGridView.Columns)
            //{
            //    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
            //    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
            //    pdfTable.AddCell(cell);
            //}

            ////Add Rows and Cells to the Pdf

            //for (int i = 0; i < Kunde_dataGridView.Rows.Count; i++)
            //{
            //    for (int a = 0; a < Kunde_dataGridView.Rows[i].Cells.Count; a++)
            //    {
            //        if (Kunde_dataGridView.Rows[i].Cells[a].Value != null)
            //        {

            //            pdfTable.AddCell(Kunde_dataGridView.Rows[i].Cells[a].Value.ToString());

            //        }


            //    }
            //}


            ////Export to PDF
            //string folderPath = "C:\\PDFs\\";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            //using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
            //{
            //    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
            //    PdfWriter.GetInstance(pdfDoc, stream);
            //    pdfDoc.Open();
            //    pdfDoc.Add(pdfTable);
            //    pdfDoc.Close();
            //    stream.Close();
            //}

        }

        //------------PDF--PRINT------------------::END::--------------------------------------------------------------------------------------------------------------------













        //--------------Datagridview - Change - Color------------::END:------------------------------------------------













    }
}
