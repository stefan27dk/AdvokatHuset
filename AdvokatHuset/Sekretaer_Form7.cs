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
    public partial class Sekretaer_Form7 : Form
    {
     
        

        // Local Folder
        string LocalFolderPath = "C://";  // Gets Assignet in initialize

        //DB
        Sekretær sekretaerinstance; // Instance af Sekretaer 
        DB_Connection_Write ConnWrite; // Sql Write "
        //static readonly  DB_Connection_String ConnectionString = DB_Connection_String.GetConnectionString(); // Global Connectionstring
        //static SqlConnection connection = null; 
      

       

        // Show Sekretaerer - Database
        //static string show_Sekretaer_Query = "Select Sekretaer.*, Sekretaer_Tlf.Sekretaer_Tlf  From Sekretaer Full Join Sekretaer_Tlf ON Sekretaer.Sekretaer_ID = Sekretaer_Tlf.Sekretaer_ID AND";
        static string show_Sekretaer_Query = "Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, P.Distrikt, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, T.Me_Tlf AS Sekretær_Tlf, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type = 'Sekretær'";



        DataSet Sekretaer_Dataset = new DataSet(); // Dataset for "Show Sekretaer" and "Show Sekretaer_Tlf"
                                                


        //Sekretaer_Tlf - Database
        static string Sekretaer_Tlf_Select_Query = "Select* From Medarbejder_Tlf";
        //static string Sekretaer_Tlf_Select_Query = "Select Sekretaer_Tlf.*, Sekretaer.Sekretaer_Fornavn, Sekretaer.Sekretaer_Efternavn From Sekretaer_Tlf Inner Join Sekretaer ON Sekretaer_Tlf.Sekretaer_ID = Sekretaer.Sekretaer_ID;";




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
        public Sekretaer_Form7()
        {
            InitializeComponent();
        }





        // Load
        private void Sekretaerer_Form9_Load(object sender, EventArgs e)
        {
            DatagridviewSettings_Style();
            LoadSekretaerer();// Show all Sekretaerer "Populating the datagridview with Curtomers "Sekretaerer""
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
            Sekretaer_dataGridView, new object[] { true });
        }



        // Datagridview Color Style
        private void Black_DatagridviewStyle()
         {

            this.Sekretaer_dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.Sekretaer_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 34);
            this.Sekretaer_dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(59, 203, 255);  // Datagridview Fore Color
            this.Sekretaer_dataGridView.GridColor = Color.Gray;
            this.Sekretaer_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point
            this.Sekretaer_dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 94);
            this.Sekretaer_dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 32, 29);
            
            //this.Sekretaer_dataGridView.DefaultCellStyle..Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold);

         }





        //  Datagridview Color Style "White" 
        private void White_DatagridviewStyle()
        {

            this.Sekretaer_dataGridView.RowsDefaultCellStyle.BackColor = DefaultBackColor;
            this.Sekretaer_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = DefaultBackColor;
            this.Sekretaer_dataGridView.DefaultCellStyle.ForeColor = DefaultForeColor;  // Datagridview Fore Color
            this.Sekretaer_dataGridView.GridColor = Color.Gray;
            this.Sekretaer_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point

        }


        //-----------SETTINGS------------::END::--------------------------------------------------------------------------------------------









        // Create Sekretaer
        private void CreateSekretaer()
        {
            sekretaerinstance = new Sekretær();
            sekretaerinstance.Fornavn = sekretaerer_name_textBox.Text;
            sekretaerinstance.Efternavn = sekretaerer_surname_textBox.Text;
            sekretaerinstance.PostNr = Convert.ToInt32(sekretaerer_zipcCode_textBox.Text);
            sekretaerinstance.Adresse = sekretaerer_adr_textBox.Text;
            sekretaerinstance.TlfNr = Convert.ToInt32(sekretaerer_tlf_textBox.Text);
            sekretaerinstance.Mail = sekretaer_email_textBox.Text;

        }





        // Insert to DB  "Insert Sekretaer to DB"
        private void InsertToDB()
        {
            ConnWrite = new DB_Connection_Write(); // "Write to DB Class instance"
            string SekretaerQuery = $"BEGIN DECLARE @UNIQUEX UNIQUEIDENTIFIER SET @UNIQUEX = NEWID(); Insert Into Medarbejder Values('{sekretaerinstance.Fornavn}','{sekretaerinstance.Efternavn}',{sekretaerinstance.PostNr},'{sekretaerinstance.Adresse}', (@UNIQUEX),'Sekretær','{sekretaerinstance.Mail}', '{DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss")}'); Insert INTO Medarbejder_Tlf Values('{sekretaerer_tlf_textBox.Text}',(@UNIQUEX)); END;"; // Query
            successful = ConnWrite.CreateCommand(SekretaerQuery); // Write to DB Input and "Execution"
        }









        // Key Events--Validating--Textboxes----::START::---------------------------------------------- 
      
        // Validate Name
        private void sekretaerer_name_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = (int.TryParse(e.KeyChar.ToString(), out int isNumber) || (e.KeyChar == (char)Keys.Space));///Prevent Numbers and Spaces

        }



        // Validate Surname
        private void sekretaerer_surname_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (int.TryParse(e.KeyChar.ToString(), out int isNumber));///Prevent Numbers and Spaces
        }




        // Zip Code Validating
        private void sekretaerer_zipcCode_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && e.KeyChar != (char)26)/// "Allow backspace"  and CTRL+Z
            {
                    e.Handled = !int.TryParse(e.KeyChar.ToString(), out int isNumber);///Prevent letters
            }
        
        }




        // TLF Validating
        private void sekretaerer_tlf_textBox_KeyPress(object sender, KeyPressEventArgs e)
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
            if (sekretaerer_name_textBox.TextLength < 2)
            {
                isValid = false; // Now you cant proceed because its not valid
                sekretaerer_name_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }

            else
            {
                
                  for (int i = 0; i < sekretaerer_name_textBox.TextLength; i++)
                  {
                 
                      if(String.IsNullOrEmpty(sekretaerer_name_textBox.Text[i].ToString()) || int.TryParse(sekretaerer_name_textBox.Text[i].ToString(), out int isNumber) || sekretaerer_name_textBox.Text[i].ToString() == " ") // Check for numbers, null, 
                      {
                          isValid = false; // Now you cant proceed because its not valid
                          sekretaerer_name_textBox.BackColor = Color.FromArgb(255, 128, 128);
                        break;
                      }
                      
                  }

            }




            // Surname Validation------------------------------------------------------------------------> 
            if (sekretaerer_surname_textBox.TextLength < 2)
            {
                isValid = false; // Now you cant proceed because its not valid
                sekretaerer_surname_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
            
                 for (int i = 0; i < sekretaerer_surname_textBox.TextLength; i++)
                 {
                
                     if (String.IsNullOrEmpty(sekretaerer_surname_textBox.Text[i].ToString()) || int.TryParse(sekretaerer_surname_textBox.Text[i].ToString(), out int isNumber))  
                     {
                         isValid = false; // Now you cant proceed because its not valid
                         sekretaerer_surname_textBox.BackColor = Color.FromArgb(255, 128, 128);
                        break;
                     }
                
                 }

            }



             // TLF Validation--------------------------------------------------------------------------->

             if (sekretaerer_tlf_textBox.TextLength < 8)
             {
                isValid = false;
                sekretaerer_tlf_textBox.BackColor = Color.FromArgb(255, 128, 128);

            }

            else if(!int.TryParse(sekretaerer_tlf_textBox.Text, out int isNumber))
            {
                isValid = false;
                sekretaerer_tlf_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }



             // Email Validation------------------------------------------------------------------------->
              if(sekretaer_email_textBox.TextLength < 5)
              {
                isValid = false;
                sekretaer_email_textBox.BackColor = Color.FromArgb(255, 128, 128);

              }

              else  
              {
                // Check for "@"
                bool at = false;

                for (int i = 0; i < sekretaer_email_textBox.TextLength; i++)
                {
                     if(sekretaer_email_textBox.Text[i] == '@')
                     {
                        at = true; // Contains "@"
                     }

                }

                 // If itdont contains "@"
                if(at == false)
                {
                    isValid = false;
                    sekretaer_email_textBox.BackColor = Color.FromArgb(255, 128, 128);

                }


            }



              //Zip Code Valiadtion---------------------------------------------------------------------->
               if(sekretaerer_zipcCode_textBox.TextLength < 4)
               {
                isValid = false;
                sekretaerer_zipcCode_textBox.BackColor = Color.FromArgb(255, 128, 128);
               }
               else if(!int.TryParse(sekretaerer_zipcCode_textBox.Text, out int isNumber))
               {
                isValid = false;
                sekretaerer_zipcCode_textBox.BackColor = Color.FromArgb(255, 128, 128);
               }
            



            // Adress Validation------------------------------------------------------------------------>
            if(sekretaerer_adr_textBox.TextLength < 2)
            {
                isValid = false;
                sekretaerer_adr_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }
            
           
        }















        //-----------------CREATE---TEXTBOXES-SETTINGS---------::START::----------------------------------------------

        // Reset Textbox Color
        private void TextboxesResetColor()
        {
            sekretaerer_name_textBox.BackColor = Color.FromArgb(220, 243, 250);
            sekretaerer_surname_textBox.BackColor = Color.FromArgb(220, 243, 250);
            sekretaerer_tlf_textBox.BackColor = Color.FromArgb(220, 243, 250);
            sekretaer_email_textBox.BackColor = Color.FromArgb(220, 243, 250);
            sekretaerer_zipcCode_textBox.BackColor = Color.FromArgb(220, 243, 250);
            sekretaerer_adr_textBox.BackColor = Color.FromArgb(220, 243, 250);

        }




        // Clear All Textboxes
        private void ClearTextboxes()
        {
            sekretaerer_name_textBox.Clear();
            sekretaerer_surname_textBox.Clear();
            sekretaerer_tlf_textBox.Clear();
            sekretaer_email_textBox.Clear();
            sekretaerer_zipcCode_textBox.Clear();
            sekretaerer_adr_textBox.Clear();
        }




        // Save Button 
        private void sekretaerer_Save_button_Click(object sender, EventArgs e)
        {
            TextboxesResetColor(); // Reset Color
            ValidateALL(); // Validate All

            if (isValid == true)// If all is valid
            {
                CreateSekretaer();  
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
        private void vis_rediger_sekretaerer_button_Click(object sender, EventArgs e)
        {
            datagridviewBackground_panel.Visible = true;
            backPanel_Textboxes_panel.Visible = false;
            //this.sekretaerTableAdapter.Fill(this.advokathusetDataSet.Sekretaer);
        }



  

        // Opret Button
        private void opret_sekretaer_button_Click(object sender, EventArgs e)
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
                if(Sekretaer_dataGridView.Focused && Sekretaer_dataGridView.SelectedRows.Count > 0)
                {
                    DeleteFromDatagridview();
                }
            }

            // Copy Editing Cell
            if (keyData == (Keys.Control | Keys.C | Keys.Alt))
            {
            Clipboard.SetText(Sekretaer_dataGridView.SelectedRows[0].Cells[Sekretaer_dataGridView.CurrentCell.ColumnIndex].Value.ToString());

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
                if(Sekretaer_dataGridView.SelectedRows.Count > 0) // Check if any row is selected
                {
                   DialogResult deleteDialog = MessageBox.Show("Er du sikker på a t du vil slette?", "Slet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                   if (deleteDialog == DialogResult.Yes)
                   {
                       AddRowToList(); // Add to list the row that will be deleted
                       Sekretaer_dataGridView.Rows.RemoveAt(Sekretaer_dataGridView.SelectedRows[0].Index); //  Delete selected row
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
           
            if (Sekretaer_dataGridView.CurrentRow.Cells.Count == Sekretaer_dataGridView.ColumnCount) // If all cels are selected on the current row
            {
                
                DataGridViewRow row = (DataGridViewRow)Sekretaer_dataGridView.SelectedRows[0].Clone();
                for (int i = 0; i < Sekretaer_dataGridView.SelectedCells.Count; i++)
                {
                    row.Cells[i].Value = Sekretaer_dataGridView.SelectedCells[i].Value;
                }
                DeletedRowsList.Add(row);
            }
        }





        // Undo  DELETE - Button
        private void undo_button_Click(object sender, EventArgs e)
        {
     
            // Always the last item
            if (DeletedRowsList.Count > 0 && Sekretaer_dataGridView.DataMember == "Medarbejder")
            {
                int lastindex = DeletedRowsList.Count - 1;
               Sekretaer_Dataset.Tables[0].Rows.Add(DeletedRowsList[lastindex].Cells[0].Value, DeletedRowsList[lastindex].Cells[1].Value, DeletedRowsList[lastindex].Cells[2].Value, DeletedRowsList[lastindex].Cells[3].Value, DeletedRowsList[lastindex].Cells[4].Value, DeletedRowsList[lastindex].Cells[5].Value, DeletedRowsList[lastindex].Cells[6].Value, DeletedRowsList[lastindex].Cells[7].Value, DeletedRowsList[lastindex].Cells[8].Value, DeletedRowsList[lastindex].Cells[9].Value);
               SaveDataGridView(); // Save to DB  

                //inserdetindex.Add(sekretaer);
                DeletedRowsList.RemoveAt(lastindex); // Remove Last index
                RefreshDatagridview(); // Refresh
            }


        }

        //----------DELETE------------------::END::-------------------------------------------------------------------------------------- 










        // Show Customers "Sekretaerer" - Main Method
        private void LoadSekretaerer()
        {
            // Clear the Columns "Column Change order because of the second Table Sekretaer_Tlf" TLF Colum becomes the first
            if(Sekretaer_dataGridView.DataMember == "Medarbejder_Tlf")
            {
              Sekretaer_dataGridView.Columns.Clear();
            }
            Sekretaer_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"
            Datagridview_Loader Load_Customers = new Datagridview_Loader();
            Load_Customers.DB_Populate(show_Sekretaer_Query, Sekretaer_Dataset, "Medarbejder");
            Sekretaer_dataGridView.DataSource = Sekretaer_Dataset;
            Sekretaer_dataGridView.DataMember = "Medarbejder";
            Sekretaer_dataGridView.Columns[3].ReadOnly = true;  // Forbid Editing Sekretaer_Tlf
            Sekretaer_dataGridView.Columns[6].ReadOnly = true;  // Forbid Editing Sekretaer_Tlf
           
        }



        // Show_Sekretaer-Tlf - Load Sekretaer_Tlf - Main Method
        private void LoadSekretaer_Tlf()
        {
            string Sekretaer_Tlf_Sekretaer_navn_Select = "Select Medarbejder_Tlf.*, M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn  AS Sekretær_Efternavn, M.Me_Type AS Type From Medarbejder_Tlf Inner Join Medarbejder AS M ON Medarbejder_Tlf.Me_ID = M.Me_ID  Where M.Me_Type = 'Sekretær' ;";
            // Clear the Columns 
            if (Sekretaer_dataGridView.DataMember == "Medarbejder")
            {
                Sekretaer_dataGridView.Columns.Clear();
            }

            // Sekretaer_Tlf
            Sekretaer_Dataset.Clear();
            Datagridview_Loader Load_Sekretaer_Tlf = new Datagridview_Loader();
            Load_Sekretaer_Tlf.DB_Populate(Sekretaer_Tlf_Sekretaer_navn_Select, Sekretaer_Dataset, "Medarbejder_Tlf");
            Sekretaer_dataGridView.DataSource = Sekretaer_Dataset;
            Sekretaer_dataGridView.DataMember = "Medarbejder_Tlf";
            Sekretaer_dataGridView.Columns[2].ReadOnly = true;  // Forbid Editing Sekretaer_ForNavn
            Sekretaer_dataGridView.Columns[3].ReadOnly = true;  // Forbid Editing Sekretaer_EfterNavn
            Sekretaer_dataGridView.Columns[4].ReadOnly = true;  // Forbid Editing Medarbejder Type

        }










         //----SAVE-UPDATE--DATAGRIDVIEW-------::START::---------------------------------------------------------------------------------- 

        // Save  "Sekretaer"
        private void SaveDataGridView()
        {          
            
            // Save changes to DB  "UPDATE Sekretaerer"
            if(Sekretaer_dataGridView.DataMember == "Medarbejder_Tlf") // Sekretaer_Tlf
            {
                Sekretaer_dataGridView.EndEdit();
                DatagridView_Save Update_Sekretaerer = new DatagridView_Save();
                Update_Sekretaerer.DatagridView_Update(Sekretaer_Tlf_Select_Query, Sekretaer_Dataset, "Medarbejder_Tlf", this.Sekretaer_dataGridView);

            }

            else if(Sekretaer_dataGridView.DataMember == "Medarbejder")   // Sekretaer
            {
                string Sekretaer_Query = "Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M";
                Sekretaer_dataGridView.EndEdit();
                DatagridView_Save Update_Sekretaerer = new DatagridView_Save();
                Update_Sekretaerer.DatagridView_Update(Sekretaer_Query, Sekretaer_Dataset, "Medarbejder", this.Sekretaer_dataGridView);
            }
         

        }

           
     

        // UPDATE - Get row to Compare on Row enter "Used to determine if the row have been changed so we know when to "Save the changes""
        private void Sekretaer_dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Selected_Row_For_Compare();
        }




       // Row Enter - Main Method "It is used also for reseting the row Comparison when Column Header Is Clicked"
       private void Selected_Row_For_Compare()
        {
            if (Sekretaer_dataGridView.SelectedRows.Count > 0) // I there is selected row
            {

                // Clone Row
                enterRow = (DataGridViewRow)Sekretaer_dataGridView.SelectedRows[0].Clone();

                // Add Data to the Cloned Row
                for (int i = 0; i < Sekretaer_dataGridView.SelectedRows[0].Cells.Count; i++)
                {
                    enterRow.Cells[i].Value = Sekretaer_dataGridView.SelectedRows[0].Cells[i].Value;
                }


            }

        }





        // Row Leave - "ON - Validattion" - UPDATE "SAVE" - On ROW LEAVE AFTER VALIDATION  "Save"
        private void Sekretaer_dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
             bool edited = false; // Check if the Row was edited

            if (Sekretaer_dataGridView.SelectedRows.Count > 0) // Selected minimum 1 row
            {


                for (int j = 0; j < Sekretaer_dataGridView.SelectedRows[0].Cells.Count; j++)
                {
                

                    if (Sekretaer_dataGridView.SelectedRows[0].Cells[j].Value != null && !Sekretaer_dataGridView.SelectedRows[0].Cells[j].Value.Equals(enterRow.Cells[j].Value))
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
        private void Sekretaer_dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Selected_Row_For_Compare();
        }

      

        // RefreshDatagridview "After Update OR Cancelation"
        private void RefreshDatagridview()
        {
            if (Sekretaer_dataGridView.DataMember == "Medarbejder")
            {
                LoadSekretaerer();
            }
            else if (Sekretaer_dataGridView.DataMember == "Medarbejder_Tlf")
            {
                LoadSekretaer_Tlf();
            }
        }


        //----SAVE-UPDATE--DATAGRIDVIEW-------::END::--------------------------------------------------------------------------------------- 











      










        //-------------BUTTONS-Datagridview--Menu-------::START::----------------------------------------------------------------------------

        // Local Folder
        private void local_folder_button_Click(object sender, EventArgs e)
        {
            Open_Local_Folder();
        }




        // Show All Customers "Sekretaerer" - Button
        private void show_all_button_Click(object sender, EventArgs e)
        {
            LoadSekretaerer();


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




        // Sekretaer_Tlf- Button - Show Tlf
        private void Sekretaer_Tlf_button_Click(object sender, EventArgs e)
        {
            LoadSekretaer_Tlf();
            if(search_textBox.TextLength > 0)
            {
                search_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }


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
            Search_Column_comboBox.Items.Add("Efternavn");
            Search_Column_comboBox.Items.Add("Adresse");
            Search_Column_comboBox.Items.Add("PostNr");
            Search_Column_comboBox.Items.Add("Distrikt");
            Search_Column_comboBox.Items.Add("Tlf");
            Search_Column_comboBox.Items.Add("ID");
            Search_Column_comboBox.Items.Add("Email");
            Search_Column_comboBox.Items.Add("Dato");
            Search_Column_comboBox.SelectedIndex = 0;

        }


        // Search Queries - / Columns / Search - Text
        private void Search_Column()
        {
            //SearchColumn_SearchString

            switch (Search_Column_comboBox.SelectedIndex)
            {
                case 0: // ALL
                    SearchColumn_SearchString = $"IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, P.Distrikt, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, T.Me_Tlf AS Sekretær_Tlf, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type ='Sekretær' AND (M.Me_Fornavn {SearchOptions} OR M.Me_Efternavn {SearchOptions} OR P.Distrikt {SearchOptions} OR M.Me_Adresse {SearchOptions} OR M.Me_Email {SearchOptions} OR M.Me_ID {SearchOptions} OR M.Me_Oprets_Dato {SearchOptions}) END ELSE BEGIN Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, P.Distrikt, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, T.Me_Tlf AS Sekretær_Tlf, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type ='Sekretær' AND (M.Me_Fornavn {SearchOptions} OR M.Me_Efternavn {SearchOptions} OR M.Me_PostNr {SearchOptions} OR P.Distrikt {SearchOptions} OR M.Me_Adresse {SearchOptions} OR M.Me_Email {SearchOptions} OR T.Me_Tlf {SearchOptions} OR M.Me_ID {SearchOptions} OR M.Me_Oprets_Dato {SearchOptions}) END;";
                    //IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select* From Sekretaer Where  Sekretaer_Fornavn {SearchOptions} OR Sekretaer_Efternavn {SearchOptions} OR Sekretaer_Adresse {SearchOptions} OR Sekretaer_Email {SearchOptions} OR Sekretaer_Oprets_Dato {SearchOptions} OR Sekretaer_ID {SearchOptions} END ELSE  BEGIN SELECT Sekretaer.*, Sekretaer_Tlf.Sekretaer_Tlf From Sekretaer Full Join Sekretaer_Tlf ON Sekretaer.Sekretaer_ID = Sekretaer_Tlf.Sekretaer_ID Where Sekretaer_PostNr {SearchOptions} OR Sekretaer_Tlf.Sekretaer_Tlf {SearchOptions} OR Sekretaer_Fornavn {SearchOptions} OR Sekretaer_Efternavn {SearchOptions} OR Sekretaer_Adresse {SearchOptions} OR Sekretaer_Email {SearchOptions} OR Sekretaer_Oprets_Dato {SearchOptions} OR Sekretaer.Sekretaer_ID {SearchOptions} END;
                    break;
                case 1: // Name
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, P.Distrikt, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, T.Me_Tlf AS Sekretær_Tlf, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type = 'Sekretær' AND M.Me_Fornavn {SearchOptions}";
                    break;
                case 2:   // Surname
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, P.Distrikt, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, T.Me_Tlf AS Sekretær_Tlf, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type = 'Sekretær' AND M.Me_Efternavn {SearchOptions}";
                    break;
                case 3:  //Adress
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, P.Distrikt, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, T.Me_Tlf AS Sekretær_Tlf, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type = 'Sekretær' AND M.Me_Adresse {SearchOptions}";
                    break;
                case 4:  // Zip-Code
                    SearchColumn_SearchString = $" IF(ISNUMERIC('{search_textBox.Text}') = 1) BEGIN Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, P.Distrikt, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, T.Me_Tlf AS Sekretær_Tlf, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type = 'Sekretær' AND M.Me_PostNr {SearchOptions} END";
                    break;
                case 5: // Ditrict
                    SearchColumn_SearchString = $" Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, P.Distrikt, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, T.Me_Tlf AS Sekretær_Tlf, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type = 'Sekretær' AND P.Distrikt {SearchOptions};";
                    break;
                case 6: //TLF
                    SearchColumn_SearchString = $" IF(ISNUMERIC('{search_textBox.Text}') = 1) BEGIN Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, P.Distrikt, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, T.Me_Tlf AS Sekretær_Tlf, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type = 'Sekretær' AND T.Me_Tlf {SearchOptions} END";
                    break;
                case 7: // ID
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, P.Distrikt, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, T.Me_Tlf AS Sekretær_Tlf, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type = 'Sekretær' AND M.Me_ID {SearchOptions}";
                    break;
                case 8: // Email
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, P.Distrikt, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, T.Me_Tlf AS Sekretær_Tlf, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type = 'Sekretær' AND M.Me_Email {SearchOptions}";
                    break;
                case 9: // Date
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Sekretær_Fornavn, M.Me_Efternavn AS Sekretær_Efternavn , M.Me_PostNr AS Sekretær_PostNr, P.Distrikt, M.Me_Adresse AS Sekretær_Adresse, M.Me_Email AS Sekretær_Email, T.Me_Tlf AS Sekretær_Tlf, M.Me_ID AS Sekretær_ID, M.Me_Type, M.Me_Oprets_Dato AS Sekretær_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type = 'Sekretær' AND M.Me_Oprets_dato {SearchOptions}";

                    break;
                  
                    //SearchColumn_SearchString = $"IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select* From Sekretaer Where  Sekretaer_Fornavn {SearchOptions} " +
                    //    $"OR Sekretaer_Efternavn {SearchOptions} OR Sekretaer_Adresse {SearchOptions} OR Sekretaer_Email {SearchOptions} OR Sekretaer_Oprets_Dato {SearchOptions} " +
                    //    $"OR Sekretaer_ID {SearchOptions} END ELSE BEGIN SELECT Sekretaer.*, Sekretaer_Tlf.Sekretaer_Tlf From Sekretaer Full Join Sekretaer_Tlf ON Sekretaer.Sekretaer_ID = Sekretaer_Tlf.Sekretaer_ID Where Sekretaer_PostNr {SearchOptions} OR Sekretaer_Tlf.Sekretaer_Tlf {SearchOptions} END;";
            }
        }



        // Search - DB - Connection
        private void Search()
        {
            Sekretaer_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"
            Datagridview_Loader Load_Search_Result = new Datagridview_Loader();
            Load_Search_Result.DB_Populate(SearchColumn_SearchString, Sekretaer_Dataset, "Medarnejder");
            Sekretaer_dataGridView.DataSource = Sekretaer_Dataset;
            Sekretaer_dataGridView.DataMember = "Medarnejder";
 
        }




        // MAIN - Search Method
        private void Search_Resources()
        {
            LoadSekretaerer(); // Used for refreshing the datagridview Because of the Sekretaer_Tlf Table appears first again
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
                LoadSekretaerer();
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
            LoadSekretaerer(); // Show All
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
            if (this.Sekretaer_dataGridView.RowsDefaultCellStyle.BackColor == Color.FromArgb(64, 64, 64))
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
             if(Sekretaer_dataGridView.CurrentRow != null)
             {

          
                if(Sekretaer_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor != Color.FromArgb(191, 50, 95))
                {
                Sekretaer_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.FromArgb(191, 50, 95);
                Sekretaer_dataGridView.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    Sekretaer_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.FromArgb(2, 222, 160);
                    Sekretaer_dataGridView.SelectedRows[0].DefaultCellStyle.ForeColor = DefaultForeColor;
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
               PdfPTable Pdf_DGV = new PdfPTable(Sekretaer_dataGridView.Columns.Count);
               Pdf_DGV.DefaultCell.Padding = 3;
               Pdf_DGV.WidthPercentage = 100;
               Pdf_DGV.HorizontalAlignment = Element.ALIGN_LEFT;
               Pdf_DGV.DefaultCell.BorderWidth = 1;
             
             
               // Adding the Columns with their txt to the PDF 
               foreach(DataGridViewColumn column in Sekretaer_dataGridView.Columns)
               {
                   PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                   cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255); // White Color
                   Pdf_DGV.AddCell(cell);
               }
             
             
               //Add Rows and Cells to the Pdf

              for (int i = 0; i < Sekretaer_dataGridView.Rows.Count; i++)
              {
                  for (int a = 0; a < Sekretaer_dataGridView.Rows[i].Cells.Count; a++)
                  {
                      if (Sekretaer_dataGridView.Rows[i].Cells[a].Value != null)
                      {
             
                          Pdf_DGV.AddCell(Sekretaer_dataGridView.Rows[i].Cells[a].Value.ToString());
             
                      }
             
             
                  }
              }



              // Export to PDF

            if(!Directory.Exists(LocalFolderPath))
            {
                Directory.CreateDirectory(LocalFolderPath);
            }

            using(FileStream stream = new FileStream(LocalFolderPath + "Sekretaerer_PDF -  "+DateTime.Now.ToString("dd-MM-yyyy   HH-mm-ss")+".pdf", FileMode.Create))
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


            int oldHeight = Sekretaer_dataGridView.Height;
            Sekretaer_dataGridView.Height = Sekretaer_dataGridView.RowCount * Sekretaer_dataGridView.RowTemplate.Height;




            // Bitmap
            Bitmap bitmapScreenshot = new Bitmap(this.Sekretaer_dataGridView.Width, this.Sekretaer_dataGridView.Height);

            // Draw to the bitmap
            Sekretaer_dataGridView.DrawToBitmap(bitmapScreenshot, new System.Drawing.Rectangle(0, 0, this.Sekretaer_dataGridView.Width, this.Sekretaer_dataGridView.Height));

            // Reset the height
            Sekretaer_dataGridView.Height = oldHeight;

            // Save bitmap
            bitmapScreenshot.Save(LocalFolderPath + "Sekretaer_Snapshot  " + DateTime.Now.ToString("dd-MM-yyyy  HH-mm-ss") + ".png");
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

        // Name - Reset Color
        private void sekretaerer_name_textBox_TextChanged(object sender, EventArgs e)
        {
            sekretaerer_name_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }





        // Surname - Reset Color
        private void sekretaerer_surname_textBox_TextChanged(object sender, EventArgs e)
        {
            sekretaerer_surname_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }





        // Zip Code - Reset Background
        private void sekretaerer_zipcCode_textBox_TextChanged(object sender, EventArgs e)
        {
            sekretaerer_zipcCode_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }




        // Adress - Reset Background
        private void sekretaerer_adr_textBox_TextChanged(object sender, EventArgs e)
        {
            sekretaerer_adr_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }




        // Tlf - Reset Background
        private void sekretaerer_tlf_textBox_TextChanged(object sender, EventArgs e)
        {
            sekretaerer_tlf_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }


        // Email - Reset Background 
        private void sekretaer_email_textBox_TextChanged(object sender, EventArgs e)
        {
            sekretaer_email_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }


        // ERROR - Handling - Default Datagridview Error handling
        private void Sekretaer_dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Sekretaer_dataGridView.RefreshEdit(); // Reset
            MessageBox.Show("Der Opståd Fejl, Input er ikke i korekt format","Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }




        //-------------CREATE-TEXTBOXES -- Reset Color on Typing-------------------::END:--------------------------------------------------



         // Copy Selected Column
        private void copy_selected_column_button_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Sekretaer_dataGridView.SelectedRows[0].Cells[Sekretaer_dataGridView.CurrentCell.ColumnIndex].Value.ToString());

        }














    }
}
