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
    public partial class Medarbejder_Form6 : Form
    {
     
        

        // Local Folder
        string LocalFolderPath = "C://";  // Gets Assignet in initialize

        //DB
        Medarbejder medarbejderinstance; // Instance af Medarbejder 
        DB_Connection_Write ConnWrite; // Sql Write "
                                   




        // Show Medarbejdere - Database
        static string show_Medarbejder_Query = "Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr; ";



        DataSet Medarbejder_Dataset = new DataSet(); // Dataset for "Show Medarbejder" and "Show Medarbejder_Tlf"



        //Medarbejder_Tlf - Database
        //static string Medarbejder_Tlf_Select_Query = "Select Medarbejder_Tlf.*, Medarbejder.Me_Fornavn, Medarbejder.Me_Efternavn From Medarbejder_Tlf inner join Medarbejder ON Medarbejder_Tlf.Me_ID = Medarbejder.Me_ID  Where Medarbejder.Me_Type = 'Medarbejder';";




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
        public Medarbejder_Form6()
        {
            InitializeComponent();
        }





        // Load
        private void Medarbejdere_Form9_Load(object sender, EventArgs e)
        {
            DatagridviewSettings_Style();
            LoadMedarbejdere();// Show all Medarbejdere "Populating the datagridview with Curtomers "Medarbejdere""
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
            Medarbejder_dataGridView, new object[] { true });
        }



        // Datagridview Color Style
        private void Black_DatagridviewStyle()
         {

            this.Medarbejder_dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.Medarbejder_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 34);
            this.Medarbejder_dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(59, 203, 255);  // Datagridview Fore Color
            this.Medarbejder_dataGridView.GridColor = Color.Gray;
            this.Medarbejder_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point
            this.Medarbejder_dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 94);
            this.Medarbejder_dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 32, 29);
            
            //this.Medarbejder_dataGridView.DefaultCellStyle..Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold);

         }





        //  Datagridview Color Style "White" 
        private void White_DatagridviewStyle()
        {

            this.Medarbejder_dataGridView.RowsDefaultCellStyle.BackColor = DefaultBackColor;
            this.Medarbejder_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = DefaultBackColor;
            this.Medarbejder_dataGridView.DefaultCellStyle.ForeColor = DefaultForeColor;  // Datagridview Fore Color
            this.Medarbejder_dataGridView.GridColor = Color.Gray;
            this.Medarbejder_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point

        }


        //-----------SETTINGS------------::END::--------------------------------------------------------------------------------------------









        // Create Medarbejder
        private void CreateMedarbejder()
        {
            medarbejderinstance = new Medarbejder();
            medarbejderinstance.Fornavn = medarbejdere_name_textBox.Text;
            medarbejderinstance.Efternavn = medarbejdere_surname_textBox.Text;
            medarbejderinstance.PostNr = Convert.ToInt32(medarbejdere_zipcCode_textBox.Text);
            medarbejderinstance.Adresse = medarbejdere_adr_textBox.Text;
            medarbejderinstance.TlfNr = Convert.ToInt32(medarbejdere_tlf_textBox.Text);
            medarbejderinstance.Mail = medarbejder_email_textBox.Text;
          
        }





        // Insert to DB  "Insert Medarbejder to DB"
        private void InsertToDB()
        {
            ConnWrite = new DB_Connection_Write(); // "Write to DB Class instance"
            string MedarbejderQuery = $"BEGIN DECLARE @UNIQUEX UNIQUEIDENTIFIER SET @UNIQUEX = NEWID(); Insert Into Medarbejder Values('{medarbejderinstance.Fornavn}','{medarbejderinstance.Efternavn}',{medarbejderinstance.PostNr},'{medarbejderinstance.Adresse}', (@UNIQUEX),'Chef','{medarbejderinstance.Mail}', '{DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss")}'); Insert INTO Medarbejder_Tlf Values('{medarbejdere_tlf_textBox.Text}',(@UNIQUEX)); END;"; // Query
            successful = ConnWrite.CreateCommand(MedarbejderQuery); // Write to DB Input and "Execution"
        }









        // Key Events--Validating--Textboxes----::START::---------------------------------------------- 
      
        // Validate Name
        private void medarbejdere_name_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = (int.TryParse(e.KeyChar.ToString(), out int isNumber) || (e.KeyChar == (char)Keys.Space));///Prevent Numbers and Spaces

        }



        // Validate Surname
        private void medarbejdere_surname_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (int.TryParse(e.KeyChar.ToString(), out int isNumber));///Prevent Numbers and Spaces
        }




        // Zip Code Validating
        private void medarbejdere_zipcCode_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && e.KeyChar != (char)26)/// "Allow backspace"  and CTRL+Z
            {
                    e.Handled = !int.TryParse(e.KeyChar.ToString(), out int isNumber);///Prevent letters
            }
        
        }




        // TLF Validating
        private void medarbejdere_tlf_textBox_KeyPress(object sender, KeyPressEventArgs e)
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
            if (medarbejdere_name_textBox.TextLength < 2)
            {
                isValid = false; // Now you cant proceed because its not valid
                medarbejdere_name_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }

            else
            {
                
                  for (int i = 0; i < medarbejdere_name_textBox.TextLength; i++)
                  {
                 
                      if(String.IsNullOrEmpty(medarbejdere_name_textBox.Text[i].ToString()) || int.TryParse(medarbejdere_name_textBox.Text[i].ToString(), out int isNumber) || medarbejdere_name_textBox.Text[i].ToString() == " ") // Check for numbers, null, 
                      {
                          isValid = false; // Now you cant proceed because its not valid
                          medarbejdere_name_textBox.BackColor = Color.FromArgb(255, 128, 128);
                        break;
                      }
                      
                  }

            }




            // Surname Validation------------------------------------------------------------------------> 
            if (medarbejdere_surname_textBox.TextLength < 2)
            {
                isValid = false; // Now you cant proceed because its not valid
                medarbejdere_surname_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
            
                 for (int i = 0; i < medarbejdere_surname_textBox.TextLength; i++)
                 {
                
                     if (String.IsNullOrEmpty(medarbejdere_surname_textBox.Text[i].ToString()) || int.TryParse(medarbejdere_surname_textBox.Text[i].ToString(), out int isNumber))  
                     {
                         isValid = false; // Now you cant proceed because its not valid
                         medarbejdere_surname_textBox.BackColor = Color.FromArgb(255, 128, 128);
                        break;
                     }
                
                 }

            }



             // TLF Validation--------------------------------------------------------------------------->

             if (medarbejdere_tlf_textBox.TextLength < 8)
             {
                isValid = false;
                medarbejdere_tlf_textBox.BackColor = Color.FromArgb(255, 128, 128);

            }

            else if(!int.TryParse(medarbejdere_tlf_textBox.Text, out int isNumber))
            {
                isValid = false;
                medarbejdere_tlf_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }



             // Email Validation------------------------------------------------------------------------->
              if(medarbejder_email_textBox.TextLength < 5)
              {
                isValid = false;
                medarbejder_email_textBox.BackColor = Color.FromArgb(255, 128, 128);

              }

              else  
              {
                // Check for "@"
                bool at = false;

                for (int i = 0; i < medarbejder_email_textBox.TextLength; i++)
                {
                     if(medarbejder_email_textBox.Text[i] == '@')
                     {
                        at = true; // Contains "@"
                     }

                }

                 // If itdont contains "@"
                if(at == false)
                {
                    isValid = false;
                    medarbejder_email_textBox.BackColor = Color.FromArgb(255, 128, 128);

                }


            }



              //Zip Code Valiadtion---------------------------------------------------------------------->
               if(medarbejdere_zipcCode_textBox.TextLength < 4)
               {
                isValid = false;
                medarbejdere_zipcCode_textBox.BackColor = Color.FromArgb(255, 128, 128);
               }
               else if(!int.TryParse(medarbejdere_zipcCode_textBox.Text, out int isNumber))
               {
                isValid = false;
                medarbejdere_zipcCode_textBox.BackColor = Color.FromArgb(255, 128, 128);
               }
            



            // Adress Validation------------------------------------------------------------------------>
            if(medarbejdere_adr_textBox.TextLength < 2)
            {
                isValid = false;
                medarbejdere_adr_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }
            
           
        }















        //-----------------CREATE---TEXTBOXES-SETTINGS---------::START::----------------------------------------------

        // Reset Textbox Color
        private void TextboxesResetColor()
        {
            medarbejdere_name_textBox.BackColor = Color.FromArgb(220, 243, 250);
            medarbejdere_surname_textBox.BackColor = Color.FromArgb(220, 243, 250);
            medarbejdere_tlf_textBox.BackColor = Color.FromArgb(220, 243, 250);
            medarbejder_email_textBox.BackColor = Color.FromArgb(220, 243, 250);
            medarbejdere_zipcCode_textBox.BackColor = Color.FromArgb(220, 243, 250);
            medarbejdere_adr_textBox.BackColor = Color.FromArgb(220, 243, 250);

        }




        // Clear All Textboxes
        private void ClearTextboxes()
        {
            medarbejdere_name_textBox.Clear();
            medarbejdere_surname_textBox.Clear();
            medarbejdere_tlf_textBox.Clear();
            medarbejder_email_textBox.Clear();
            medarbejdere_zipcCode_textBox.Clear();
            medarbejdere_adr_textBox.Clear();
        }




        // Save Button 
        private void medarbejdere_Save_button_Click(object sender, EventArgs e)
        {
            TextboxesResetColor(); // Reset Color
            ValidateALL(); // Validate All

            if (isValid == true)// If all is valid
            {
                CreateMedarbejder();  
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
        private void vis_rediger_medarbejdere_button_Click(object sender, EventArgs e)
        {
            backPanel_Textboxes_panel.Visible = false; // Opret
            speciale_BACK_panel.Visible = false;    // Speciale
            datagridviewBackground_panel.Visible = true; // Datagridview
            //this.medarbejderTableAdapter.Fill(this.medarbejderhusetDataSet.Medarbejder);
        }



  

        // Opret Button
        private void opret_medarbejder_button_Click(object sender, EventArgs e)
        {
            datagridviewBackground_panel.Visible = false;// Hide Datagridview
            speciale_BACK_panel.Visible = false; // Speciale
            backPanel_Textboxes_panel.Visible = true; // Opret
           
        }

        // Form Menu-----------::END::----------------------------------------------



        
       







        //Shortcut keys-----KEY WATCHER-----------::START::--------------------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            // Open Item Menu Shortcut
            if (keyData == (Keys.Delete))
            {
                if(Medarbejder_dataGridView.Focused && Medarbejder_dataGridView.SelectedRows.Count > 0)
                {
                    DeleteFromDatagridview();
                }
            }

            // Copy Editing Cell
            if (keyData == (Keys.Control | Keys.C | Keys.Alt))
            {
                for (int i = 0; i < Medarbejder_dataGridView.SelectedRows[0].Cells.Count; i++)
                {
                    if(Medarbejder_dataGridView.SelectedCells[i].IsInEditMode)
                    {
                      Clipboard.SetText(Medarbejder_dataGridView.SelectedCells[i].Value.ToString());
                    }
                }
                
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
                if(Medarbejder_dataGridView.SelectedRows.Count > 0) // Check if any row is selected
                {
                   DialogResult deleteDialog = MessageBox.Show("Are you sure that you want to delete the selected row?", "Delete: Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                   if (deleteDialog == DialogResult.Yes)
                   {
                       AddRowToList(); // Add to list the row that will be deleted
                       Medarbejder_dataGridView.Rows.RemoveAt(Medarbejder_dataGridView.SelectedRows[0].Index); //  Delete selected row
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
           
            if (Medarbejder_dataGridView.CurrentRow.Cells.Count == Medarbejder_dataGridView.ColumnCount) // If all cels are selected on the current row
            {
                
                DataGridViewRow row = (DataGridViewRow)Medarbejder_dataGridView.SelectedRows[0].Clone();
                for (int i = 0; i < Medarbejder_dataGridView.SelectedCells.Count; i++)
                {
                    row.Cells[i].Value = Medarbejder_dataGridView.SelectedCells[i].Value;
                }
                DeletedRowsList.Add(row);
            }
        }





        // Undo  DELETE - Button
        private void undo_button_Click(object sender, EventArgs e)
        {
         
            // UNDO
            if (DeletedRowsList.Count > 0 && Medarbejder_dataGridView.DataMember == "Medarbejder")
            {
                int lastindex = DeletedRowsList.Count - 1;
               Medarbejder_Dataset.Tables[0].Rows.Add(DeletedRowsList[lastindex].Cells[0].Value, DeletedRowsList[lastindex].Cells[1].Value, DeletedRowsList[lastindex].Cells[2].Value, DeletedRowsList[lastindex].Cells[3].Value, DeletedRowsList[lastindex].Cells[4].Value, DeletedRowsList[lastindex].Cells[5].Value, DeletedRowsList[lastindex].Cells[6].Value, DeletedRowsList[lastindex].Cells[7].Value, DeletedRowsList[lastindex].Cells[8].Value, DeletedRowsList[lastindex].Cells[9].Value);
               SaveDataGridView(); // Save to DB  

                //inserdetindex.Add(medarbejder);
                DeletedRowsList.RemoveAt(lastindex); // Remove Last index
                RefreshDatagridview(); //REFRESH
            }


        }

        //----------DELETE------------------::END::-------------------------------------------------------------------------------------- 










        // Show Customers "Medarbejdere" - Main Method
        private void LoadMedarbejdere()
        {
            // Clear the Columns "Column Change order because of the second Table Medarbejder_Tlf" TLF Colum becomes the first
            if(Medarbejder_dataGridView.DataMember == "Medarbejder_Tlf")
            {
              Medarbejder_dataGridView.Columns.Clear();
            }
            Medarbejder_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"
            Datagridview_Loader Load_Customers = new Datagridview_Loader();
            Load_Customers.DB_Populate(show_Medarbejder_Query, Medarbejder_Dataset, "Medarbejder");
            Medarbejder_dataGridView.DataSource = Medarbejder_Dataset;
            Medarbejder_dataGridView.DataMember = "Medarbejder";
            Medarbejder_dataGridView.Columns[3].ReadOnly = true;  // Forbid Editing Medarbejder_Tlf
            Medarbejder_dataGridView.Columns[6].ReadOnly = true;  // Forbid Editing Medarbejder_Tlf
           
        }



        // Show_Medarbejder-Tlf - Load Medarbejder_Tlf - Main Method
        private void LoadMedarbejder_Tlf()
        {
            string Medarbejder_Tlf_Medarbejder_Navn_Select = "Select T.Me_Tlf AS Medarbejder_Tlf, T.Me_ID AS Medarbejder_ID, M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn, M.Me_Type AS Type From Medarbejder_Tlf AS T Inner Join Medarbejder AS M ON T.Me_ID = M.Me_ID;";
            // Clear the Columns 
            if (Medarbejder_dataGridView.DataMember == "Medarbejder")
            {
                Medarbejder_dataGridView.Columns.Clear();
            }

            // Medarbejder_Tlf
            Medarbejder_Dataset.Clear();
            Datagridview_Loader Load_Medarbejder_Tlf = new Datagridview_Loader();
            Load_Medarbejder_Tlf.DB_Populate(Medarbejder_Tlf_Medarbejder_Navn_Select, Medarbejder_Dataset, "Medarbejder_Tlf");
            Medarbejder_dataGridView.DataSource = Medarbejder_Dataset;
            Medarbejder_dataGridView.DataMember = "Medarbejder_Tlf";
            Medarbejder_dataGridView.Columns[2].ReadOnly = true;  // Forbid Editing Medarbejder_ForNavn
            Medarbejder_dataGridView.Columns[3].ReadOnly = true;  // Forbid Editing Medarbejder_EfterNavn
            Medarbejder_dataGridView.Columns[4].ReadOnly = true;  // Type

        }



            

        //----SAVE-UPDATE--DATAGRIDVIEW-------::START::---------------------------------------------------------------------------------- 

        // Save Cutomers "MedarbejderER"
        private void SaveDataGridView()
        {          
            
            // Save changes to DB  "UPDATE Medarbejdere"
            if(Medarbejder_dataGridView.DataMember == "Medarbejder_Tlf") // Medarbejder_Tlf
            {
                Medarbejder_dataGridView.EndEdit();
                DatagridView_Save Update_Medarbejdere = new DatagridView_Save();
                Update_Medarbejdere.DatagridView_Update("Select Medarbejder_Tlf.Me_Tlf AS Medarbejder_Tlf, Medarbejder_Tlf.Me_ID AS Medarbejder_ID From Medarbejder_Tlf", Medarbejder_Dataset, "Medarbejder_Tlf", this.Medarbejder_dataGridView);

            }

            else if(Medarbejder_dataGridView.DataMember == "Medarbejder")   // Medarbejder
            {
                Medarbejder_dataGridView.EndEdit();
                DatagridView_Save Update_Medarbejdere = new DatagridView_Save();
                Update_Medarbejdere.DatagridView_Update("Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M", Medarbejder_Dataset, "Medarbejder", this.Medarbejder_dataGridView);
            }
         

        }

           
     

        // UPDATE - Get row to Compare on Row enter "Used to determine if the row have been changed so we know when to "Save the changes""
        private void Medarbejder_dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Selected_Row_For_Compare();
        }




       // Row Enter - Main Method "It is used also for reseting the row Comparison when Column Header Is Clicked"
       private void Selected_Row_For_Compare()
        {
            if (Medarbejder_dataGridView.SelectedRows.Count > 0) // I there is selected row
            {

                // Clone Row
                enterRow = (DataGridViewRow)Medarbejder_dataGridView.SelectedRows[0].Clone();

                // Add Data to the Cloned Row
                for (int i = 0; i < Medarbejder_dataGridView.SelectedRows[0].Cells.Count; i++)
                {
                    enterRow.Cells[i].Value = Medarbejder_dataGridView.SelectedRows[0].Cells[i].Value;
                }


            }

        }





        // Row Leave - "ON - Validattion" - UPDATE "SAVE" - On ROW LEAVE AFTER VALIDATION  "Save"
        private void Medarbejder_dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
             bool edited = false; // Check if the Row was edited

            if (Medarbejder_dataGridView.SelectedRows.Count > 0) // Selected minimum 1 row
            {


                for (int j = 0; j < Medarbejder_dataGridView.SelectedRows[0].Cells.Count; j++)
                {
                

                    if (Medarbejder_dataGridView.SelectedRows[0].Cells[j].Value != null && !Medarbejder_dataGridView.SelectedRows[0].Cells[j].Value.Equals(enterRow.Cells[j].Value))
                    {
                        edited = true;
                        break;
                    }
                }
               
               

                if (edited == true )
                {
                    DialogResult saveDialog = MessageBox.Show("Er du sikker på at du vil gemme?", "GEM", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
        private void Medarbejder_dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Selected_Row_For_Compare();
        }

      

        // RefreshDatagridview "After Update OR Cancelation"
        private void RefreshDatagridview()
        {
            if (Medarbejder_dataGridView.DataMember == "Medarbejder")
            {
                LoadMedarbejdere();
            }
            else if (Medarbejder_dataGridView.DataMember == "Medarbejder_Tlf")
            {
                LoadMedarbejder_Tlf();
            }
        }


        //----SAVE-UPDATE--DATAGRIDVIEW-------::END::--------------------------------------------------------------------------------------- 











      










        //-------------BUTTONS-Datagridview--Menu-------::START::----------------------------------------------------------------------------

        // Local Folder
        private void local_folder_button_Click(object sender, EventArgs e)
        {
            Open_Local_Folder();
        }




        // Show All Customers "Medarbejdere" - Button
        private void show_all_button_Click(object sender, EventArgs e)
        {
            LoadMedarbejdere();


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




        // Medarbejder_Tlf- Button - Show Tlf
        private void Medarbejder_Tlf_button_Click(object sender, EventArgs e)
        {
            LoadMedarbejder_Tlf();
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
                    SearchColumn_SearchString = $"IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr  Where M.Me_Fornavn {SearchOptions} OR M.Me_Efternavn {SearchOptions} OR P.Distrikt {SearchOptions} OR M.Me_Adresse {SearchOptions} OR M.Me_Email {SearchOptions} OR M.Me_ID {SearchOptions} OR M.Me_Oprets_Dato {SearchOptions} END ELSE BEGIN Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr  Where M.Me_Fornavn {SearchOptions} OR M.Me_Efternavn {SearchOptions} OR M.Me_PostNr {SearchOptions} OR P.Distrikt {SearchOptions} OR M.Me_Adresse {SearchOptions} OR M.Me_Email {SearchOptions} OR T.Me_Tlf {SearchOptions} OR M.Me_ID {SearchOptions} OR M.Me_Oprets_Dato {SearchOptions} END;";
                    break;
                case 1: // Name
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Fornavn {SearchOptions}";
                    break;
                case 2:   // Surname
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Efternavn {SearchOptions}";
                    break;
                case 3:  //Adress
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Adresse {SearchOptions}";
                    break;
                case 4:  // Zip-Code
                    SearchColumn_SearchString = $" IF(ISNUMERIC('{search_textBox.Text}') = 1) BEGIN Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_PostNr {SearchOptions} END";
                    break;
                case 5: // Ditrict
                    SearchColumn_SearchString = $" Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where P.Distrikt {SearchOptions}";
                    break;
                case 6: //TLF
                    SearchColumn_SearchString = $" IF(ISNUMERIC('{search_textBox.Text}') = 1) BEGIN Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where T.Me_Tlf {SearchOptions} END";
                    break;
                case 7: // ID
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_ID {SearchOptions}";
                    break;
                case 8: // Email
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Email {SearchOptions}";
                    break;
                case 9: // Date
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Oprets_Dato {SearchOptions}";
                    break;
               
                                 
            }
        }



        // Search - DB - Connection
        private void Search()
        {
            Medarbejder_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"
            Datagridview_Loader Load_Search_Result = new Datagridview_Loader();
            Load_Search_Result.DB_Populate(SearchColumn_SearchString, Medarbejder_Dataset, "Medarbejder");
            Medarbejder_dataGridView.DataSource = Medarbejder_Dataset;
            Medarbejder_dataGridView.DataMember = "Medarbejder";
 
        }




        // MAIN - Search Method
        private void Search_Resources()
        {
            LoadMedarbejdere(); // Used for refreshing the datagridview Because of the Medarbejder_Tlf Table appears first again
            Search_Options(); // Like
            Search_Column(); // Column and Search String
            Search(); // Ask the DB and Get Answer
        }




        // Search On Text Changed
        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            
            Search_Resources();

            if (search_textBox.Text == "")
            {
                LoadMedarbejdere();
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
            LoadMedarbejdere(); // Show All
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
            if (this.Medarbejder_dataGridView.RowsDefaultCellStyle.BackColor == Color.FromArgb(64, 64, 64))
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
            if(Medarbejder_dataGridView.CurrentRow != null)
            { 
                    if (Medarbejder_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor != Color.FromArgb(191, 50, 95))
                    {
                       Medarbejder_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.FromArgb(191, 50, 95);
                       Medarbejder_dataGridView.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Black;
                    }
                   else
                   {
                       Medarbejder_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.FromArgb(2, 222, 160);
                       Medarbejder_dataGridView.SelectedRows[0].DefaultCellStyle.ForeColor = DefaultForeColor;
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
               PdfPTable Pdf_DGV = new PdfPTable(Medarbejder_dataGridView.Columns.Count);
               Pdf_DGV.DefaultCell.Padding = 3;
               Pdf_DGV.WidthPercentage = 100;
               Pdf_DGV.HorizontalAlignment = Element.ALIGN_LEFT;
               Pdf_DGV.DefaultCell.BorderWidth = 1;
             
             
               // Adding the Columns with their txt to the PDF 
               foreach(DataGridViewColumn column in Medarbejder_dataGridView.Columns)
               {
                   PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                   cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255); // White Color
                   Pdf_DGV.AddCell(cell);
               }
             
             
               //Add Rows and Cells to the Pdf

              for (int i = 0; i < Medarbejder_dataGridView.Rows.Count; i++)
              {
                  for (int a = 0; a < Medarbejder_dataGridView.Rows[i].Cells.Count; a++)
                  {
                      if (Medarbejder_dataGridView.Rows[i].Cells[a].Value != null)
                      {
             
                          Pdf_DGV.AddCell(Medarbejder_dataGridView.Rows[i].Cells[a].Value.ToString());
             
                      }
             
             
                  }
              }



              // Export to PDF

            if(!Directory.Exists(LocalFolderPath))
            {
                Directory.CreateDirectory(LocalFolderPath);
            }

            using(FileStream stream = new FileStream(LocalFolderPath + "Medarbejdere_PDF -  "+DateTime.Now.ToString("dd-MM-yyyy   HH-mm-ss")+".pdf", FileMode.Create))
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


            int oldHeight = Medarbejder_dataGridView.Height;
            Medarbejder_dataGridView.Height = Medarbejder_dataGridView.RowCount * Medarbejder_dataGridView.RowTemplate.Height;




            // Bitmap
            Bitmap bitmapScreenshot = new Bitmap(this.Medarbejder_dataGridView.Width, this.Medarbejder_dataGridView.Height);

            // Draw to the bitmap
            Medarbejder_dataGridView.DrawToBitmap(bitmapScreenshot, new System.Drawing.Rectangle(0, 0, this.Medarbejder_dataGridView.Width, this.Medarbejder_dataGridView.Height));

            // Reset the height
            Medarbejder_dataGridView.Height = oldHeight;

            // Save bitmap
            bitmapScreenshot.Save(LocalFolderPath + "Medarbejder_Snapshot  " + DateTime.Now.ToString("dd-MM-yyyy  HH-mm-ss") + ".png");
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
        private void medarbejdere_name_textBox_TextChanged(object sender, EventArgs e)
        {
            medarbejdere_name_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }





        // Surname - Reset Color
        private void medarbejdere_surname_textBox_TextChanged(object sender, EventArgs e)
        {
            medarbejdere_surname_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }





        // Zip Code - Reset Background
        private void medarbejdere_zipcCode_textBox_TextChanged(object sender, EventArgs e)
        {
            medarbejdere_zipcCode_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }




        // Adress - Reset Background
        private void medarbejdere_adr_textBox_TextChanged(object sender, EventArgs e)
        {
            medarbejdere_adr_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }




        // Tlf - Reset Background
        private void medarbejdere_tlf_textBox_TextChanged(object sender, EventArgs e)
        {
            medarbejdere_tlf_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }


        // Email - Reset Background 
        private void medarbejder_email_textBox_TextChanged(object sender, EventArgs e)
        {
            medarbejder_email_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }

        //-------------CREATE-TEXTBOXES -- Reset Color on Typing-------------------::END:--------------------------------------------------










        // ERROR - Handling - Default Datagridview Error handling
        private void Medarbejder_dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Medarbejder_dataGridView.RefreshEdit(); // Reset
            MessageBox.Show("Der Opståd Fejl, Input er ikke i korekt format","Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
 






        // Specialer - MAIN - BUTTON
        private void main_specialer_button_Click(object sender, EventArgs e)
        {
            speciale_BACK_panel.Visible = true; // Speciale
            datagridviewBackground_panel.Visible = false;  // Datagridview
            backPanel_Textboxes_panel.Visible = false; // Opret
        }





        //Medarbejder-----SPECIALER-------::START::-----------------------------------------------------------------------------
        // Load Specialer Medarbejder in Combobox
        private void speciale_comboBox_Click(object sender, EventArgs e)
        {
            Load_Specialer((ComboBox)sender);
        }




        // Clear Medarbejder Speciale Textbox-- Button
        private void clear_medarbejder_speciale_button_Click(object sender, EventArgs e)
        {
            speciale_medarbejder_id_textBox.Clear();
            speciale_comboBox.Items.Clear();
        }



        // Save Medarbejder - Speciale
        private void save_Medarbejder_specaile_button_Click(object sender, EventArgs e)
        {
            DB_Connection_Write Save_Medarbejder_Speciale = new DB_Connection_Write();

            if(speciale_medarbejder_id_textBox.Text !="" && speciale_comboBox.SelectedItem != null)
            {
            Save_Medarbejder_Speciale.CreateCommand($"Insert INTO Medarbejder_Uddannelser VALUES ('{speciale_comboBox.SelectedItem.ToString()}', '{speciale_medarbejder_id_textBox.Text}');");
            speciale_comboBox.Items.Clear();
            speciale_medarbejder_id_textBox.Clear();
            }
            else
            {
                MessageBox.Show("Felterne er ugyldig","Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        //Medarbejder-----SPECIALER-------::END::-----------------------------------------------------------------------------






        // Load Specialer Main Methods ----||Advoakt-Specialer and Create Speciale||
        private void Load_Specialer(ComboBox combo)
        {
            speciale_comboBox.Items.Clear();
            Load_Combobox Load_Specialer = new Load_Combobox();
            string Query = "Select* From Uddannelser";
            combo = Load_Specialer.Populate_Combobox_Speciale(Query, combo);
        }









        //---Create Speciale----------------::START::---------------------------------------------

        // Save new Speciale --- CREATE SPECIALE
        private void save_speciale_button_Click(object sender, EventArgs e)
        {
            DB_Connection_Write Save_Speciale = new DB_Connection_Write();
            Save_Speciale.CreateCommand($"Insert Into Uddannelser Values('{Add_Specaile_To_DB_comboBox.Text}');");
            Add_Specaile_To_DB_comboBox.Items.Clear();
            Add_Specaile_To_DB_comboBox.Text = "";

        }




        // Clear Speciale "Uddanelse" Textbox --BUTTON
        private void clear_speciale_button_Click(object sender, EventArgs e)
        {
            Add_Specaile_To_DB_comboBox.Items.Clear();
            Add_Specaile_To_DB_comboBox.Text = "";
        }






        //Add Speciale to DB ----::SAVE::---- 
        private void Add_Specaile_To_DB_comboBox_Click(object sender, EventArgs e)
        {
            Add_Specaile_To_DB_comboBox.Items.Clear();
            Load_Specialer((ComboBox)sender);

        }

        private void Add_Specaile_To_DB_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_Specaile_To_DB_comboBox.SelectedIndex = -1; 
                
        }


        //---Create Speciale----------------::END::---------------------------------------------















        //----DELETE SPECIALE-------------::START::----------------------------------------------

    

            // Delete Speciale - Combobox - SELECT
        private void delete_speciale_comboBox_MouseClick(object sender, MouseEventArgs e)
        {
           delete_speciale_comboBox.Items.Clear();
           Load_Specialer((ComboBox)sender);
        }




        // Delete - Speciale - Button
        private void delete_speciale_button_Click(object sender, EventArgs e)
        {
            if(delete_speciale_comboBox.SelectedIndex != -1)
            {
              DB_Connection_Write Delete_Speciale = new DB_Connection_Write();
              Delete_Speciale.CreateCommand($"Delete FROM Uddannelser Where Medarbejder_Uddanelse = '{delete_speciale_comboBox.SelectedItem.ToString()}';");
              delete_speciale_comboBox.Items.Clear();
            }
            else
            {
                MessageBox.Show("Ugyldig Input","Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //----DELETE SPECIALE-------------::END::----------------------------------------------















        //----DELETE SPECIALE- From Medarbejdere------------::START::----------------------------------------------

        // Delete_ Speciale_ From _ medarbejdere
        private void delete_speciale_from_medarbejder_comboBox_Click(object sender, EventArgs e)
        {
            delete_speciale_from_medarbejder_comboBox.Items.Clear();
            Load_Specialer((ComboBox)sender);

        }



        // Delete Speciale From Medarbejder  Button
        private void delete_speciale_from_medarbejder_delete_button_Click(object sender, EventArgs e)
        {
            if (delete_speciale_from_medarbejder_comboBox.SelectedIndex != -1)
            {
  
                DB_Connection_Write Delete_Speciale_From_Medarbejder = new DB_Connection_Write();
                Delete_Speciale_From_Medarbejder.CreateCommand($"Delete FROM Medarbejder_Uddannelser Where Medarbejder_Uddannelser.Medarbejder_Uddanelse = '{delete_speciale_from_medarbejder_comboBox.SelectedItem.ToString()}' AND Medarbejder_Uddannelser.Me_ID = '{delete_speciale_from_medarbejder_textBox.Text}';");
                delete_speciale_from_medarbejder_comboBox.Items.Clear();
                delete_speciale_from_medarbejder_textBox.Clear();
            }
            else
            {
                MessageBox.Show("Ugyldig Input", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----DELETE SPECIALE- From Medarbejdere------------::END::----------------------------------------------














    }
}
