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
        Medarbejder medarbejderinstance = new Medarbejder(); // Instance af Medarbejder 
        Domain_DB_Connection_Write ConnWrite; // Sql Write "
                                   




        // Show Medarbejdere - Database
        static string show_Medarbejder_Query = "Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, P.Distrikt, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, T.Me_Tlf AS Medarbejder_Tlf, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Inner Join Post AS P ON M.Me_PostNr = P.PostNr; ";



        DataSet Medarbejder_Dataset = new DataSet(); // Dataset for "Show Medarbejder" and "Show Medarbejder_Tlf"



        //Medarbejder_Tlf - Database
        //static string Medarbejder_Tlf_Select_Query = "Select Medarbejder_Tlf.*, Medarbejder.Me_Fornavn, Medarbejder.Me_Efternavn From Medarbejder_Tlf inner join Medarbejder ON Medarbejder_Tlf.Me_ID = Medarbejder.Me_ID  Where Medarbejder.Me_Type = 'Medarbejder';";




        // Row Edit
        DataGridViewRow enterRow = new DataGridViewRow(); // On Enter






        // Validate Textboxes bools
        bool isValid = true; // Inputboxes Validator
        bool successful = false; // Successful Transaction



        // Validate Log In
        bool Log_In_Valid = true;


        // Vis Rediger Log IN Validate
        bool Vis_rediger_validated = true;




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
            ConnWrite = new Domain_DB_Connection_Write(); // "Write to DB Class instance"
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
            Log_In_BACK_panel.Visible = false;    // Speciale
            datagridviewBackground_panel.Visible = true; // Datagridview
            //this.medarbejderTableAdapter.Fill(this.medarbejderhusetDataSet.Medarbejder);
        }



  

        // Opret Button
        private void opret_medarbejder_button_Click(object sender, EventArgs e)
        {
            datagridviewBackground_panel.Visible = false;// Hide Datagridview
            Log_In_BACK_panel.Visible = false; // Speciale
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
            Clipboard.SetText(Medarbejder_dataGridView.SelectedRows[0].Cells[Medarbejder_dataGridView.CurrentCell.ColumnIndex].Value.ToString());

            }



            // Open Login Menu
            if (keyData == (Keys.Control | Keys.Alt | Keys.X))
            {
                Log_In_Create_Edit();

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

            medarbejderinstance.Person_Datagridview_Loader(show_Medarbejder_Query, Medarbejder_Dataset, "Medarbejder");
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

            medarbejderinstance.Person_Datagridview_Loader(Medarbejder_Tlf_Medarbejder_Navn_Select, Medarbejder_Dataset, "Medarbejder_Tlf");
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
                medarbejderinstance.Person_Save_DGV("Select Medarbejder_Tlf.Me_Tlf AS Medarbejder_Tlf, Medarbejder_Tlf.Me_ID AS Medarbejder_ID From Medarbejder_Tlf", Medarbejder_Dataset, "Medarbejder_Tlf", this.Medarbejder_dataGridView);

            }

            else if(Medarbejder_dataGridView.DataMember == "Medarbejder")   // Medarbejder
            {
                Medarbejder_dataGridView.EndEdit();
                medarbejderinstance.Person_Save_DGV("Select M.Me_Fornavn AS Medarbejder_Fornavn, M.Me_Efternavn AS Medarbejder_Efternavn , M.Me_PostNr AS Medarbejder_PostNr, M.Me_Adresse AS Medarbejder_Adresse, M.Me_Email AS Medarbejder_Email, M.Me_ID AS Medarbejder_ID, M.Me_Type, M.Me_Oprets_Dato AS Medarbejder_Oprets_Dato From Medarbejder AS M", Medarbejder_Dataset, "Medarbejder", this.Medarbejder_dataGridView);
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

            medarbejderinstance.Person_Datagridview_Loader(SearchColumn_SearchString, Medarbejder_Dataset, "Medarbejder");
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





       // Copy Selected Column to CLipboard
        private void copy_selected_column_button_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Medarbejder_dataGridView.SelectedRows[0].Cells[Medarbejder_dataGridView.CurrentCell.ColumnIndex].Value.ToString());
        }



























        // Log-IN - MAIN - BUTTON
        private void main_specialer_button_Click(object sender, EventArgs e)
        {

            // Get Log in Info
            Log_In_Info Allow_acces_To_log_In = Log_In_Info.Get_Log_In_Info();

            // Log Ins can be accessed only from Me_Type Chef
            if(Allow_acces_To_log_In.Log_IN_Type == "Chef")
            {
                Log_In_Create_Edit();

            }

        }






         // Show log In - Edit, Create etc.
         private void Log_In_Create_Edit()
         {
            datagridviewBackground_panel.Visible = false;  // Datagridview
            backPanel_Textboxes_panel.Visible = false; // Opret
            Log_In_BACK_panel.Visible = true; // Log In
         }










        //-------------Create---LOG---IN----::START::----------------------------------------------------------------------------------

        // Log IN - Medarbejder Load Names
        private void load_ME_Names_comboBox_Click(object sender, EventArgs e)
        {
            string Query_Load_Me_Without_LogIN = "Select M.Me_Fornavn From Medarbejder AS M Left Join Log_In AS L ON M.Me_ID = L.Me_ID Where L.Me_ID IS Null; ";
            Load_Me_Names_In_Combobx((ComboBox)sender, Query_Load_Me_Without_LogIN);
        }






        // Load - Medarbejder Names From DB in Combobx
        private void Load_Me_Names_In_Combobx(ComboBox CBox, String Query)
        {
            CBox.Items.Clear();
            Domain_DB_Loader Load_Advokat_names = new Domain_DB_Loader();
            CBox = Load_Advokat_names.Populate_Combobox(Query, CBox);
        }








        // Populate Textbox - Medarbejder Name to ID
        private void load_ME_Names_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Me_Name_To_Me_ID((ComboBox) sender, Me_ID_textBox);
        }






        


        // Medarbejder Name TO ID
        private void Me_Name_To_Me_ID(ComboBox CBox, TextBox TBox)
        {
            TBox.Clear();
            Domain_DB_Loader Get_Advokat_ID = new Domain_DB_Loader();
            TBox.Text = Get_Advokat_ID.PopulateTextbox($"Select M.Me_ID From Medarbejder As M Where M.Me_Fornavn = '{CBox.SelectedItem.ToString()}' ");
        }










         //Validate Log In
        private void Validate_Input_Log_In()
        {
            Log_In_Valid = true;

            if(Me_ID_textBox.Text.Length < 1)
            {
                Log_In_Valid = false;
                Me_ID_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }

            if(log_in_textBox.Text.Length < 1)
            {

                Log_In_Valid = false;
                log_in_textBox.BackColor = Color.FromArgb(255, 192, 192);

            }

            if (pass_textBox.Text.Length < 1)
            {

                Log_In_Valid = false;
                pass_textBox.BackColor = Color.FromArgb(255, 192, 192);

            }


        }






        //Save Log IN
        private void Save_Log_IN()
        {
            Domain_DB_Connection_Write Save_Log_In_DB = new Domain_DB_Connection_Write();
            bool successful_Saved  = Save_Log_In_DB.CreateCommand($"Insert INTO Log_In Values('{Me_ID_textBox.Text}','{log_in_textBox.Text}','{pass_textBox.Text}');");


            // Clear if Succesfull Saved
            if (successful_Saved == true)
            {
                Clear_Log_In_Input();
            }
        }






        // Save Log In Button
        private void save_log_in_button_Click(object sender, EventArgs e)
        {
            Validate_Input_Log_In();

            if (Log_In_Valid == true)
            {
              Save_Log_IN();
            }
          
        }


        // Clear and reset Color

        private void Clear_Log_In_Input()
        {
            pass_textBox.BackColor = DefaultBackColor;
            log_in_textBox.BackColor = DefaultBackColor;
            Me_ID_textBox.BackColor = DefaultBackColor;

            load_ME_Names_comboBox.Items.Clear();
            pass_textBox.Clear();
            log_in_textBox.Clear();
            Me_ID_textBox.Clear();
          
        }




        // Clear All Inputs - Button
        private void clear_all_log_in_button_Click(object sender, EventArgs e)
        {
            Clear_Log_In_Input();
        }

        //-------------Create---LOG---IN----::START::----------------------------------------------------------------------------------





















        //------DELETE----LOG--IN-----::START::--------------------------------------------------------------------
        // Load ME _Names For deletion of Log IN
        private void Del_Me_name_comboBox_Click(object sender, EventArgs e)
        {
            string Load_Me_With_LogIN_For_Del = "Select M.Me_Fornavn  From Log_In AS L Inner Join Medarbejder AS M ON L.Me_ID = M.Me_ID";
            Load_Me_Names_In_Combobx((ComboBox)sender, Load_Me_With_LogIN_For_Del);

        }



        // Medarbejder Name To ID -- Delete Log IN
        private void Del_Me_name_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Me_Name_To_Me_ID((ComboBox)sender, Del_ME_ID_textBox);
        }





               



        // Clear Input - Del - Log In - Main Method
        private void Clear_Del_Log_In_Input()
        {
            Del_ME_ID_textBox.Clear();
            Del_ME_ID_textBox.BackColor = DefaultBackColor;
            Del_Me_name_comboBox.Items.Clear();

        }





        // Clear - Input for Deletion Log In - Button
        private void Del_Clear_button_Click(object sender, EventArgs e)
        {
            Clear_Del_Log_In_Input();
        }









          // Dell Log IN Button
        private void Delete_Log_In_Save()
        {
            if(Del_ME_ID_textBox.Text.Length > 15)
            {
                Domain_DB_Connection_Write Del_log_IN = new Domain_DB_Connection_Write();

                DialogResult Slet = MessageBox.Show("Er du sikker på at du vil SLETTE: Hvis du trykker på Ja så sletter du det Permanent", "SLET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(Slet == DialogResult.Yes)
                {
                    bool successful = Del_log_IN.CreateCommand($"DELETE FROM LOG_IN Where LOG_IN.Me_ID = '{Del_ME_ID_textBox.Text}'");

                    if(successful == true)
                    {
                        Clear_Del_Log_In_Input();
                    }

                }


            }


            else
            {
                Del_ME_ID_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }

        }








         // Delete Log IN - Save - Button
        private void Del_button_Click(object sender, EventArgs e)
        {
            Delete_Log_In_Save();
        }

        //------DELETE----LOG--IN-----::END::--------------------------------------------------------------------

























         // Vis -Rediger - Log _IN ---- ::START::-------------------------------------------------------------------------------



        // Vis Rediger - Show ME_Names - Combobox
        private void vis_rediger_Me_Navn_comboBox_Click(object sender, EventArgs e)
        {
            string Load_Me_With_LogIN_For_vis_rediger = "Select M.Me_Fornavn  From Log_In AS L Inner Join Medarbejder AS M ON L.Me_ID = M.Me_ID";
            Load_Me_Names_In_Combobx((ComboBox)sender, Load_Me_With_LogIN_For_vis_rediger);
        }






        // Load ID In textbox
        private void vis_rediger_Me_Navn_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset_Color_All_Input(); // Reset Colors
            Me_Name_To_Me_ID((ComboBox)sender, vis_rediger_Me_Id_textBox);
            Load_Log_IN(); // Load Log IN

            //if(vis_rediger_Me_Id_textBox.Text.Length > 15)
            //{


            //}
        }






        // Load Log IN Name and Pass
         private void Load_Log_IN()
         {
             if(vis_rediger_Me_Id_textBox.Text.Length > 15)
             {
                // Load User Name
                Domain_DB_Loader Load_Log_IN_Name = new Domain_DB_Loader();
                 vis_rediger_Log_In_Navn_textBox.Text = Load_Log_IN_Name.PopulateTextbox($"Select L.Log_In_Navn From Log_In AS L Where L.Me_ID = '{vis_rediger_Me_Id_textBox.Text}'");


                // Load Password
                Domain_DB_Loader Load_Log_IN_Pass = new Domain_DB_Loader();
                 Vis_rediger_Log_In_Pass_textBox.Text = Load_Log_IN_Pass.PopulateTextbox($"Select L.Log_In_Pass From Log_In AS L Where L.Me_ID = '{vis_rediger_Me_Id_textBox.Text}'");

             }

         }







        // ID - Textbox - Validated 
        private void vis_rediger_Me_Id_textBox_Validated(object sender, EventArgs e)
        {
            Load_Log_IN(); // Load Log IN

            if(vis_rediger_Me_Id_textBox.Text.Length <1)
            {
                vis_rediger_Log_In_Navn_textBox.Clear();
                Vis_rediger_Log_In_Pass_textBox.Clear();
                vis_rediger_Me_Navn_comboBox.Items.Clear();
            }
            
        }




            // Validate
           private void Validate_Vis_Rediger_Log_In()
           {

            Vis_rediger_validated = true;

                // Id Textbox Validating
               if(vis_rediger_Me_Id_textBox.Text.Length < 15)
               {
                Vis_rediger_validated = false;
                vis_rediger_Me_Id_textBox.BackColor = Color.FromArgb(255, 192, 192);
               }


               // Log_IN- Name
               if(vis_rediger_Log_In_Navn_textBox.Text.Length < 1)
               {
                Vis_rediger_validated = false;
                vis_rediger_Log_In_Navn_textBox.BackColor = Color.FromArgb(255, 192, 192);

               }



               // Log In Pass
               if(Vis_rediger_Log_In_Pass_textBox.Text.Length < 1)
               {

                  Vis_rediger_validated = false;
                  Vis_rediger_Log_In_Pass_textBox.BackColor = Color.FromArgb(255, 192, 192);

               }




           }




          // Clear All Inputs and Reset Color
          private void Clear_All_Input_Vis_rediger_Log_IN()
          {
            vis_rediger_Me_Navn_comboBox.Items.Clear();
            vis_rediger_Me_Id_textBox.Clear();
            vis_rediger_Log_In_Navn_textBox.Clear();
            Vis_rediger_Log_In_Pass_textBox.Clear();
            Reset_Color_All_Input(); // reset Color


          }



        // reset Colors
          private void Reset_Color_All_Input()
          {
            vis_rediger_Me_Id_textBox.BackColor = DefaultBackColor;
            vis_rediger_Log_In_Navn_textBox.BackColor = DefaultBackColor;
            Vis_rediger_Log_In_Pass_textBox.BackColor = DefaultBackColor;
          }







        // Clear All Inputs- Vis Rediger - Button
        private void vis_rediger_clear_All_button_Click(object sender, EventArgs e)
        {
            Clear_All_Input_Vis_rediger_Log_IN();
        }



         // SAve Edited Log IN - Main Method
         private void Save_Edited_Log_IN()
         {

            if(Vis_rediger_validated == true)
            {
                Domain_DB_Connection_Write save_edited_log_in = new Domain_DB_Connection_Write();
               DialogResult log_in_save_Changes = MessageBox.Show("Er du sikker på at du vil gemme ændringerne af denne Log In","GEM", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
             
               if(log_in_save_Changes == DialogResult.Yes)
               {
                bool successfull_saved = save_edited_log_in.CreateCommand($"Update Log_In Set Log_In_Navn = '{vis_rediger_Log_In_Navn_textBox.Text}', Log_In_Pass = '{Vis_rediger_Log_In_Pass_textBox.Text}'  Where Log_In.Me_ID = '{vis_rediger_Me_Id_textBox.Text}'");


                    if(successfull_saved == true)
                    {
                        Clear_All_Input_Vis_rediger_Log_IN();
                    }


               }
            }

         }









        // Vis_rediger_Log_IN - Save Button
        private void vis_rediger_save_button_Click(object sender, EventArgs e)
        {
            Validate_Vis_Rediger_Log_In(); // Validate
            Save_Edited_Log_IN();


        }







        // Me_ID - Reset Color
        private void vis_rediger_Me_Id_textBox_TextChanged(object sender, EventArgs e)
        {
            vis_rediger_Me_Id_textBox.BackColor = DefaultBackColor;
        }







        // Log In Name - Reset Color
        private void vis_rediger_Log_In_Navn_textBox_TextChanged(object sender, EventArgs e)
        {
            vis_rediger_Log_In_Navn_textBox.BackColor = DefaultBackColor;
        }








        // Log_In_Pass - Color Reset
        private void Vis_rediger_Log_In_Pass_textBox_TextChanged(object sender, EventArgs e)
        {
            Vis_rediger_Log_In_Pass_textBox.BackColor = DefaultBackColor;
        }









        // Vis -Rediger - Log _IN --------::END::-------------------------------------------------------------------------------


    }
}
