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
    public partial class Advokater_Form3 : Form
    {
     
        

        // Local Folder
        string LocalFolderPath = "C://";  // Gets Assignet in initialize

        //DB
        Advokat advokatinstance; // Instance af Advokat 
        DB_Connection_Write ConnWrite; // Sql Write "
                                   




        // Show Advokater - Database
        static string show_Advokat_Query = "Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Type = 'Advokat'; ";



        DataSet Advokat_Dataset = new DataSet(); // Dataset for "Show Advokat" and "Show Advokat_Tlf"



        //Advokat_Tlf - Database
        //static string Advokat_Tlf_Select_Query = "Select Medarbejder_Tlf.*, Medarbejder.Me_Fornavn, Medarbejder.Me_Efternavn From Medarbejder_Tlf inner join Medarbejder ON Medarbejder_Tlf.Me_ID = Medarbejder.Me_ID  Where Medarbejder.Me_Type = 'Advokat';";




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
        public Advokater_Form3()
        {
            InitializeComponent();
        }





        // Load
        private void Advokater_Form9_Load(object sender, EventArgs e)
        {
            DatagridviewSettings_Style();
            LoadAdvokater();// Show all Advokater "Populating the datagridview with Curtomers "Advokater""
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
            Advokat_dataGridView, new object[] { true });
        }



        // Datagridview Color Style
        private void Black_DatagridviewStyle()
         {

            this.Advokat_dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.Advokat_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 34);
            this.Advokat_dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(59, 203, 255);  // Datagridview Fore Color
            this.Advokat_dataGridView.GridColor = Color.Gray;
            this.Advokat_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point
            this.Advokat_dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 94);
            this.Advokat_dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 32, 29);
            
            //this.Advokat_dataGridView.DefaultCellStyle..Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold);

         }





        //  Datagridview Color Style "White" 
        private void White_DatagridviewStyle()
        {

            this.Advokat_dataGridView.RowsDefaultCellStyle.BackColor = DefaultBackColor;
            this.Advokat_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = DefaultBackColor;
            this.Advokat_dataGridView.DefaultCellStyle.ForeColor = DefaultForeColor;  // Datagridview Fore Color
            this.Advokat_dataGridView.GridColor = Color.Gray;
            this.Advokat_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point

        }


        //-----------SETTINGS------------::END::--------------------------------------------------------------------------------------------









        // Create Advokat
        private void CreateAdvokat()
        {
            advokatinstance = new Advokat();
            advokatinstance.Fornavn = advokater_name_textBox.Text;
            advokatinstance.Efternavn = advokater_surname_textBox.Text;
            advokatinstance.PostNr = Convert.ToInt32(advokater_zipcCode_textBox.Text);
            advokatinstance.Adresse = advokater_adr_textBox.Text;
            advokatinstance.TlfNr = Convert.ToInt32(advokater_tlf_textBox.Text);
            advokatinstance.Mail = advokat_email_textBox.Text;
          
        }





        // Insert to DB  "Insert Advokat to DB"
        private void InsertToDB()
        {
            ConnWrite = new DB_Connection_Write(); // "Write to DB Class instance"
            string AdvokatQuery = $"BEGIN DECLARE @UNIQUEX UNIQUEIDENTIFIER SET @UNIQUEX = NEWID(); Insert Into Medarbejder Values('{advokatinstance.Fornavn}','{advokatinstance.Efternavn}',{advokatinstance.PostNr},'{advokatinstance.Adresse}', (@UNIQUEX),'Advokat','{advokatinstance.Mail}', '{DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss")}'); Insert INTO Medarbejder_Tlf Values('{advokater_tlf_textBox.Text}',(@UNIQUEX)); END;"; // Query
            successful = ConnWrite.CreateCommand(AdvokatQuery); // Write to DB Input and "Execution"
        }









        // Key Events--Validating--Textboxes----::START::---------------------------------------------- 
      
        // Validate Name
        private void advokater_name_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = (int.TryParse(e.KeyChar.ToString(), out int isNumber) || (e.KeyChar == (char)Keys.Space));///Prevent Numbers and Spaces

        }



        // Validate Surname
        private void advokater_surname_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (int.TryParse(e.KeyChar.ToString(), out int isNumber));///Prevent Numbers and Spaces
        }




        // Zip Code Validating
        private void advokater_zipcCode_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && e.KeyChar != (char)26)/// "Allow backspace"  and CTRL+Z
            {
                    e.Handled = !int.TryParse(e.KeyChar.ToString(), out int isNumber);///Prevent letters
            }
        
        }




        // TLF Validating
        private void advokater_tlf_textBox_KeyPress(object sender, KeyPressEventArgs e)
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
            if (advokater_name_textBox.TextLength < 2)
            {
                isValid = false; // Now you cant proceed because its not valid
                advokater_name_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }

            else
            {
                
                  for (int i = 0; i < advokater_name_textBox.TextLength; i++)
                  {
                 
                      if(String.IsNullOrEmpty(advokater_name_textBox.Text[i].ToString()) || int.TryParse(advokater_name_textBox.Text[i].ToString(), out int isNumber) || advokater_name_textBox.Text[i].ToString() == " ") // Check for numbers, null, 
                      {
                          isValid = false; // Now you cant proceed because its not valid
                          advokater_name_textBox.BackColor = Color.FromArgb(255, 128, 128);
                        break;
                      }
                      
                  }

            }




            // Surname Validation------------------------------------------------------------------------> 
            if (advokater_surname_textBox.TextLength < 2)
            {
                isValid = false; // Now you cant proceed because its not valid
                advokater_surname_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
            
                 for (int i = 0; i < advokater_surname_textBox.TextLength; i++)
                 {
                
                     if (String.IsNullOrEmpty(advokater_surname_textBox.Text[i].ToString()) || int.TryParse(advokater_surname_textBox.Text[i].ToString(), out int isNumber))  
                     {
                         isValid = false; // Now you cant proceed because its not valid
                         advokater_surname_textBox.BackColor = Color.FromArgb(255, 128, 128);
                        break;
                     }
                
                 }

            }



             // TLF Validation--------------------------------------------------------------------------->

             if (advokater_tlf_textBox.TextLength < 8)
             {
                isValid = false;
                advokater_tlf_textBox.BackColor = Color.FromArgb(255, 128, 128);

            }

            else if(!int.TryParse(advokater_tlf_textBox.Text, out int isNumber))
            {
                isValid = false;
                advokater_tlf_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }



             // Email Validation------------------------------------------------------------------------->
              if(advokat_email_textBox.TextLength < 5)
              {
                isValid = false;
                advokat_email_textBox.BackColor = Color.FromArgb(255, 128, 128);

              }

              else  
              {
                // Check for "@"
                bool at = false;

                for (int i = 0; i < advokat_email_textBox.TextLength; i++)
                {
                     if(advokat_email_textBox.Text[i] == '@')
                     {
                        at = true; // Contains "@"
                     }

                }

                 // If itdont contains "@"
                if(at == false)
                {
                    isValid = false;
                    advokat_email_textBox.BackColor = Color.FromArgb(255, 128, 128);

                }


            }



              //Zip Code Valiadtion---------------------------------------------------------------------->
               if(advokater_zipcCode_textBox.TextLength < 4)
               {
                isValid = false;
                advokater_zipcCode_textBox.BackColor = Color.FromArgb(255, 128, 128);
               }
               else if(!int.TryParse(advokater_zipcCode_textBox.Text, out int isNumber))
               {
                isValid = false;
                advokater_zipcCode_textBox.BackColor = Color.FromArgb(255, 128, 128);
               }
            



            // Adress Validation------------------------------------------------------------------------>
            if(advokater_adr_textBox.TextLength < 2)
            {
                isValid = false;
                advokater_adr_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }
            
           
        }















        //-----------------CREATE---TEXTBOXES-SETTINGS---------::START::----------------------------------------------

        // Reset Textbox Color
        private void TextboxesResetColor()
        {
            advokater_name_textBox.BackColor = Color.FromArgb(220, 243, 250);
            advokater_surname_textBox.BackColor = Color.FromArgb(220, 243, 250);
            advokater_tlf_textBox.BackColor = Color.FromArgb(220, 243, 250);
            advokat_email_textBox.BackColor = Color.FromArgb(220, 243, 250);
            advokater_zipcCode_textBox.BackColor = Color.FromArgb(220, 243, 250);
            advokater_adr_textBox.BackColor = Color.FromArgb(220, 243, 250);

        }




        // Clear All Textboxes
        private void ClearTextboxes()
        {
            advokater_name_textBox.Clear();
            advokater_surname_textBox.Clear();
            advokater_tlf_textBox.Clear();
            advokat_email_textBox.Clear();
            advokater_zipcCode_textBox.Clear();
            advokater_adr_textBox.Clear();
        }




        // Save Button 
        private void advokater_Save_button_Click(object sender, EventArgs e)
        {
            TextboxesResetColor(); // Reset Color
            ValidateALL(); // Validate All

            if (isValid == true)// If all is valid
            {
                CreateAdvokat();  
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
        private void vis_rediger_advokater_button_Click(object sender, EventArgs e)
        {
            backPanel_Textboxes_panel.Visible = false; // Opret
            speciale_BACK_panel.Visible = false;    // Speciale
            datagridviewBackground_panel.Visible = true; // Datagridview
            //this.advokatTableAdapter.Fill(this.advokathusetDataSet.Advokat);
        }



  

        // Opret Button
        private void opret_advokat_button_Click(object sender, EventArgs e)
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
                if(Advokat_dataGridView.Focused && Advokat_dataGridView.SelectedRows.Count > 0)
                {
                    DeleteFromDatagridview();
                }
            }

            // Copy Editing Cell
            if (keyData == (Keys.Control | Keys.C | Keys.Alt))
            {
                for (int i = 0; i < Advokat_dataGridView.SelectedRows[0].Cells.Count; i++)
                {
                    if(Advokat_dataGridView.SelectedCells[i].IsInEditMode)
                    {
                      Clipboard.SetText(Advokat_dataGridView.SelectedCells[i].Value.ToString());
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
                if(Advokat_dataGridView.SelectedRows.Count > 0) // Check if any row is selected
                {
                   DialogResult deleteDialog = MessageBox.Show("Are you sure that you want to delete the selected row?", "Delete: Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                   if (deleteDialog == DialogResult.Yes)
                   {
                       AddRowToList(); // Add to list the row that will be deleted
                       Advokat_dataGridView.Rows.RemoveAt(Advokat_dataGridView.SelectedRows[0].Index); //  Delete selected row
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
           
            if (Advokat_dataGridView.CurrentRow.Cells.Count == Advokat_dataGridView.ColumnCount) // If all cels are selected on the current row
            {
                
                DataGridViewRow row = (DataGridViewRow)Advokat_dataGridView.SelectedRows[0].Clone();
                for (int i = 0; i < Advokat_dataGridView.SelectedCells.Count; i++)
                {
                    row.Cells[i].Value = Advokat_dataGridView.SelectedCells[i].Value;
                }
                DeletedRowsList.Add(row);
            }
        }





        // Undo  DELETE - Button
        private void undo_button_Click(object sender, EventArgs e)
        {
         
            // UNDO
            if (DeletedRowsList.Count > 0 && Advokat_dataGridView.DataMember == "Medarbejder")
            {
                int lastindex = DeletedRowsList.Count - 1;
               Advokat_Dataset.Tables[0].Rows.Add(DeletedRowsList[lastindex].Cells[0].Value, DeletedRowsList[lastindex].Cells[1].Value, DeletedRowsList[lastindex].Cells[2].Value, DeletedRowsList[lastindex].Cells[3].Value, DeletedRowsList[lastindex].Cells[4].Value, DeletedRowsList[lastindex].Cells[5].Value, DeletedRowsList[lastindex].Cells[6].Value, DeletedRowsList[lastindex].Cells[7].Value, DeletedRowsList[lastindex].Cells[8].Value, DeletedRowsList[lastindex].Cells[9].Value);
               SaveDataGridView(); // Save to DB  

                //inserdetindex.Add(advokat);
                DeletedRowsList.RemoveAt(lastindex); // Remove Last index
                RefreshDatagridview(); //REFRESH
            }


        }

        //----------DELETE------------------::END::-------------------------------------------------------------------------------------- 










        // Show Customers "Advokater" - Main Method
        private void LoadAdvokater()
        {
            // Clear the Columns "Column Change order because of the second Table Advokat_Tlf" TLF Colum becomes the first
            if(Advokat_dataGridView.DataMember == "Medarbejder_Tlf")
            {
              Advokat_dataGridView.Columns.Clear();
            }
            Advokat_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"
            Datagridview_Loader Load_Customers = new Datagridview_Loader();
            Load_Customers.DB_Populate(show_Advokat_Query, Advokat_Dataset, "Medarbejder");
            Advokat_dataGridView.DataSource = Advokat_Dataset;
            Advokat_dataGridView.DataMember = "Medarbejder";
            Advokat_dataGridView.Columns[3].ReadOnly = true;  // Forbid Editing Advokat_Tlf
            Advokat_dataGridView.Columns[6].ReadOnly = true;  // Forbid Editing Advokat_Tlf
           
        }



        // Show_Advokat-Tlf - Load Advokat_Tlf - Main Method
        private void LoadAdvokat_Tlf()
        {
            string Advokat_Tlf_Advokat_Navn_Select = "Select Medarbejder_Tlf.Me_Tlf AS Advokat_Tlf, Medarbejder_Tlf.Me_ID AS Advokat_ID, Medarbejder.Me_Fornavn AS Advokat_Fornavn, Medarbejder.Me_Efternavn AS Advokat_Efternavn From Medarbejder_Tlf inner join Medarbejder ON Medarbejder_Tlf.Me_ID = Medarbejder.Me_ID  Where Medarbejder.Me_Type = 'Advokat';";
            // Clear the Columns 
            if (Advokat_dataGridView.DataMember == "Medarbejder")
            {
                Advokat_dataGridView.Columns.Clear();
            }

            // Advokat_Tlf
            Advokat_Dataset.Clear();
            Datagridview_Loader Load_Advokat_Tlf = new Datagridview_Loader();
            Load_Advokat_Tlf.DB_Populate(Advokat_Tlf_Advokat_Navn_Select, Advokat_Dataset, "Medarbejder_Tlf");
            Advokat_dataGridView.DataSource = Advokat_Dataset;
            Advokat_dataGridView.DataMember = "Medarbejder_Tlf";
            Advokat_dataGridView.Columns[2].ReadOnly = true;  // Forbid Editing Advokat_ForNavn
            Advokat_dataGridView.Columns[3].ReadOnly = true;  // Forbid Editing Advokat_EfterNavn

        }



            

        //----SAVE-UPDATE--DATAGRIDVIEW-------::START::---------------------------------------------------------------------------------- 

        // Save Cutomers "ADVOKATER"
        private void SaveDataGridView()
        {          
            
            // Save changes to DB  "UPDATE Advokater"
            if(Advokat_dataGridView.DataMember == "Medarbejder_Tlf") // Advokat_Tlf
            {
                Advokat_dataGridView.EndEdit();
                DatagridView_Save Update_Advokater = new DatagridView_Save();
                Update_Advokater.DatagridView_Update("Select Medarbejder_Tlf.Me_Tlf AS Advokat_Tlf, Medarbejder_Tlf.Me_ID AS Advokat_ID From Medarbejder_Tlf", Advokat_Dataset, "Medarbejder_Tlf", this.Advokat_dataGridView);

            }

            else if(Advokat_dataGridView.DataMember == "Medarbejder")   // ADVOKAT
            {
                Advokat_dataGridView.EndEdit();
                DatagridView_Save Update_Advokater = new DatagridView_Save();
                Update_Advokater.DatagridView_Update("SELECT Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato FROM Medarbejder Where Medarbejder.Me_Type = 'Medarbejder';", Advokat_Dataset, "Medarbejder", this.Advokat_dataGridView);
            }
         

        }

           
     

        // UPDATE - Get row to Compare on Row enter "Used to determine if the row have been changed so we know when to "Save the changes""
        private void Advokat_dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Selected_Row_For_Compare();
        }




       // Row Enter - Main Method "It is used also for reseting the row Comparison when Column Header Is Clicked"
       private void Selected_Row_For_Compare()
        {
            if (Advokat_dataGridView.SelectedRows.Count > 0) // I there is selected row
            {

                // Clone Row
                enterRow = (DataGridViewRow)Advokat_dataGridView.SelectedRows[0].Clone();

                // Add Data to the Cloned Row
                for (int i = 0; i < Advokat_dataGridView.SelectedRows[0].Cells.Count; i++)
                {
                    enterRow.Cells[i].Value = Advokat_dataGridView.SelectedRows[0].Cells[i].Value;
                }


            }

        }





        // Row Leave - "ON - Validattion" - UPDATE "SAVE" - On ROW LEAVE AFTER VALIDATION  "Save"
        private void Advokat_dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
             bool edited = false; // Check if the Row was edited

            if (Advokat_dataGridView.SelectedRows.Count > 0) // Selected minimum 1 row
            {


                for (int j = 0; j < Advokat_dataGridView.SelectedRows[0].Cells.Count; j++)
                {
                

                    if (Advokat_dataGridView.SelectedRows[0].Cells[j].Value != null && !Advokat_dataGridView.SelectedRows[0].Cells[j].Value.Equals(enterRow.Cells[j].Value))
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
        private void Advokat_dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Selected_Row_For_Compare();
        }

      

        // RefreshDatagridview "After Update OR Cancelation"
        private void RefreshDatagridview()
        {
            if (Advokat_dataGridView.DataMember == "Medarbejder")
            {
                LoadAdvokater();
            }
            else if (Advokat_dataGridView.DataMember == "Medarbejder_Tlf")
            {
                LoadAdvokat_Tlf();
            }
        }


        //----SAVE-UPDATE--DATAGRIDVIEW-------::END::--------------------------------------------------------------------------------------- 











      










        //-------------BUTTONS-Datagridview--Menu-------::START::----------------------------------------------------------------------------

        // Local Folder
        private void local_folder_button_Click(object sender, EventArgs e)
        {
            Open_Local_Folder();
        }




        // Show All Customers "Advokater" - Button
        private void show_all_button_Click(object sender, EventArgs e)
        {
            LoadAdvokater();


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




        // Advokat_Tlf- Button - Show Tlf
        private void Advokat_Tlf_button_Click(object sender, EventArgs e)
        {
            LoadAdvokat_Tlf();
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
            Search_Column_comboBox.Items.Add("Speciale");
            Search_Column_comboBox.SelectedIndex = 0;

        }


        // Search Queries - / Columns / Search - Text
        private void Search_Column()
        {
            //SearchColumn_SearchString

            switch (Search_Column_comboBox.SelectedIndex)
            {
                case 0: // ALL
                    SearchColumn_SearchString = $"IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Fornavn {SearchOptions} OR M.Me_Efternavn {SearchOptions} OR P.Distrikt {SearchOptions} OR M.Me_Adresse {SearchOptions} OR M.Me_Email {SearchOptions} OR M.Me_ID {SearchOptions} OR M.Me_Oprets_Dato {SearchOptions} END ELSE BEGIN Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Fornavn {SearchOptions} OR M.Me_Efternavn {SearchOptions} OR M.Me_PostNr {SearchOptions} OR P.Distrikt {SearchOptions} OR M.Me_Adresse {SearchOptions} OR M.Me_Email {SearchOptions} OR T.Me_Tlf {SearchOptions} OR M.Me_ID {SearchOptions} OR M.Me_Oprets_Dato {SearchOptions} END;";
                    break;
                case 1: // Name
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Fornavn {SearchOptions} AND M.Me_Type = 'Advokat';";
                    break;
                case 2:   // Surname
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Efternavn {SearchOptions} AND M.Me_Type = 'Advokat';";
                    break;
                case 3:  //Adress
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Adresse {SearchOptions} AND M.Me_Type = 'Advokat';";
                    break;
                case 4:  // Zip-Code
                    SearchColumn_SearchString = $" IF(ISNUMERIC('{search_textBox.Text}') = 1) BEGIN Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_PostNr {SearchOptions} AND M.Me_Type = 'Advokat'; END";
                    break;
                case 5: // Ditrict
                    SearchColumn_SearchString = $" Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where P.Distrikt {SearchOptions} AND M.Me_Type = 'Advokat';";
                    break;
                case 6: //TLF
                    SearchColumn_SearchString = $" IF(ISNUMERIC('{search_textBox.Text}') = 1) BEGIN Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where T.Me_Tlf {SearchOptions} AND M.Me_Type = 'Advokat'; END";
                    break;
                case 7: // ID
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_ID {SearchOptions} AND M.Me_Type = 'Advokat';";
                    break;
                case 8: // Email
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Email {SearchOptions} AND M.Me_Type = 'Advokat';";
                    break;
                case 9: // Date
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr Where M.Me_Oprets_Dato {SearchOptions} AND M.Me_Type = 'Advokat';";
                    break;
                case 10: // Speciale
                    SearchColumn_SearchString = $"Select M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn , M.Me_PostNr AS Advokat_PostNr, P.Distrikt, M.Me_Adresse AS Advokat_Adresse, M.Me_Email AS Advokat_Email, T.Me_Tlf AS Advokat_Tlf, M.Me_ID AS Advokat_ID, M.Me_Type, U.Advokat_Uddanelse AS Speciale, M.Me_Oprets_Dato AS Advokat_Oprets_Dato From Medarbejder AS M FULL JOIN Medarbejder_Tlf As T ON M.Me_ID = T.Me_ID Full Join Post AS P ON M.Me_PostNr = P.PostNr FULL Join Advokat_Uddannelser As U ON M.Me_ID = U.Me_Id Where U.Advokat_Uddanelse {SearchOptions} AND M.Me_Type = 'Advokat';";
                    break;
                  
                    //SearchColumn_SearchString = $"IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select* From Advokat Where  Advokat_Fornavn {SearchOptions} " +
                    //    $"OR Advokat_Efternavn {SearchOptions} OR Advokat_Adresse {SearchOptions} OR Advokat_Email {SearchOptions} OR Advokat_Oprets_Dato {SearchOptions} " +
                    //    $"OR Advokat_ID {SearchOptions} END ELSE BEGIN SELECT Advokat.*, Advokat_Tlf.Advokat_Tlf From Advokat Full Join Advokat_Tlf ON Advokat.Advokat_ID = Advokat_Tlf.Advokat_ID Where Advokat_PostNr {SearchOptions} OR Advokat_Tlf.Advokat_Tlf {SearchOptions} END;";
            }
        }



        // Search - DB - Connection
        private void Search()
        {
            Advokat_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"
            Datagridview_Loader Load_Search_Result = new Datagridview_Loader();
            Load_Search_Result.DB_Populate(SearchColumn_SearchString, Advokat_Dataset, "Medarbejder");
            Advokat_dataGridView.DataSource = Advokat_Dataset;
            Advokat_dataGridView.DataMember = "Medarbejder";
 
        }




        // MAIN - Search Method
        private void Search_Resources()
        {
            LoadAdvokater(); // Used for refreshing the datagridview Because of the Advokat_Tlf Table appears first again
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
                LoadAdvokater();
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
            LoadAdvokater(); // Show All
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
            if (this.Advokat_dataGridView.RowsDefaultCellStyle.BackColor == Color.FromArgb(64, 64, 64))
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
            if(Advokat_dataGridView.CurrentRow != null)
            { 
                    if (Advokat_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor != Color.FromArgb(191, 50, 95))
                    {
                       Advokat_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.FromArgb(191, 50, 95);
                       Advokat_dataGridView.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Black;
                    }
                   else
                   {
                       Advokat_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.FromArgb(2, 222, 160);
                       Advokat_dataGridView.SelectedRows[0].DefaultCellStyle.ForeColor = DefaultForeColor;
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
               PdfPTable Pdf_DGV = new PdfPTable(Advokat_dataGridView.Columns.Count);
               Pdf_DGV.DefaultCell.Padding = 3;
               Pdf_DGV.WidthPercentage = 100;
               Pdf_DGV.HorizontalAlignment = Element.ALIGN_LEFT;
               Pdf_DGV.DefaultCell.BorderWidth = 1;
             
             
               // Adding the Columns with their txt to the PDF 
               foreach(DataGridViewColumn column in Advokat_dataGridView.Columns)
               {
                   PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                   cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255); // White Color
                   Pdf_DGV.AddCell(cell);
               }
             
             
               //Add Rows and Cells to the Pdf

              for (int i = 0; i < Advokat_dataGridView.Rows.Count; i++)
              {
                  for (int a = 0; a < Advokat_dataGridView.Rows[i].Cells.Count; a++)
                  {
                      if (Advokat_dataGridView.Rows[i].Cells[a].Value != null)
                      {
             
                          Pdf_DGV.AddCell(Advokat_dataGridView.Rows[i].Cells[a].Value.ToString());
             
                      }
             
             
                  }
              }



              // Export to PDF

            if(!Directory.Exists(LocalFolderPath))
            {
                Directory.CreateDirectory(LocalFolderPath);
            }

            using(FileStream stream = new FileStream(LocalFolderPath + "Advokater_PDF -  "+DateTime.Now.ToString("dd-MM-yyyy   HH-mm-ss")+".pdf", FileMode.Create))
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


            int oldHeight = Advokat_dataGridView.Height;
            Advokat_dataGridView.Height = Advokat_dataGridView.RowCount * Advokat_dataGridView.RowTemplate.Height;




            // Bitmap
            Bitmap bitmapScreenshot = new Bitmap(this.Advokat_dataGridView.Width, this.Advokat_dataGridView.Height);

            // Draw to the bitmap
            Advokat_dataGridView.DrawToBitmap(bitmapScreenshot, new System.Drawing.Rectangle(0, 0, this.Advokat_dataGridView.Width, this.Advokat_dataGridView.Height));

            // Reset the height
            Advokat_dataGridView.Height = oldHeight;

            // Save bitmap
            bitmapScreenshot.Save(LocalFolderPath + "Advokat_Snapshot  " + DateTime.Now.ToString("dd-MM-yyyy  HH-mm-ss") + ".png");
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
        private void advokater_name_textBox_TextChanged(object sender, EventArgs e)
        {
            advokater_name_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }





        // Surname - Reset Color
        private void advokater_surname_textBox_TextChanged(object sender, EventArgs e)
        {
            advokater_surname_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }





        // Zip Code - Reset Background
        private void advokater_zipcCode_textBox_TextChanged(object sender, EventArgs e)
        {
            advokater_zipcCode_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }




        // Adress - Reset Background
        private void advokater_adr_textBox_TextChanged(object sender, EventArgs e)
        {
            advokater_adr_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }




        // Tlf - Reset Background
        private void advokater_tlf_textBox_TextChanged(object sender, EventArgs e)
        {
            advokater_tlf_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }


        // Email - Reset Background 
        private void advokat_email_textBox_TextChanged(object sender, EventArgs e)
        {
            advokat_email_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }

        //-------------CREATE-TEXTBOXES -- Reset Color on Typing-------------------::END:--------------------------------------------------










        // ERROR - Handling - Default Datagridview Error handling
        private void Advokat_dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Advokat_dataGridView.RefreshEdit(); // Reset
            MessageBox.Show("Der Opståd Fejl, Input er ikke i korekt format","Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
 






        // Specialer - MAIN - BUTTON
        private void main_specialer_button_Click(object sender, EventArgs e)
        {
            speciale_BACK_panel.Visible = true; // Speciale
            datagridviewBackground_panel.Visible = false;  // Datagridview
            backPanel_Textboxes_panel.Visible = false; // Opret
        }





        //Advokat-----SPECIALER-------::START::-----------------------------------------------------------------------------
        // Load Specialer Advokat in Combobox
        private void speciale_comboBox_Click(object sender, EventArgs e)
        {
            Load_Specialer((ComboBox)sender);
        }




        // Clear Advokat Speciale Textbox-- Button
        private void clear_advokat_speciale_button_Click(object sender, EventArgs e)
        {
            speciale_advokat_id_textBox.Clear();
            speciale_comboBox.Items.Clear();
        }



        // Save Advokat - Speciale
        private void save_Advokat_specaile_button_Click(object sender, EventArgs e)
        {
            DB_Connection_Write Save_Advokat_Speciale = new DB_Connection_Write();

            if(speciale_advokat_id_textBox.Text !="" && speciale_comboBox.SelectedItem != null)
            {
            Save_Advokat_Speciale.CreateCommand($"Insert INTO Advokat_Uddannelser VALUES ('{speciale_comboBox.SelectedItem.ToString()}', '{speciale_advokat_id_textBox.Text}');");
            speciale_comboBox.Items.Clear();
            speciale_advokat_id_textBox.Clear();
            }
            else
            {
                MessageBox.Show("Felterne er ugyldig","Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        //Advokat-----SPECIALER-------::END::-----------------------------------------------------------------------------






        // Load Specialer Main Methods ----||Advoakt-Specialer and Create Speciale||
        private void Load_Specialer(ComboBox combo)
        {
            speciale_comboBox.Items.Clear();
            Speciale_Load_Combobox Load_Specialer = new Speciale_Load_Combobox();
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
              Delete_Speciale.CreateCommand($"Delete FROM Uddannelser Where Advokat_Uddanelse = '{delete_speciale_comboBox.SelectedItem.ToString()}';");
              delete_speciale_comboBox.Items.Clear();
            }
            else
            {
                MessageBox.Show("Ugyldig Input","Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //----DELETE SPECIALE-------------::END::----------------------------------------------















        //----DELETE SPECIALE- From Advokate------------::START::----------------------------------------------

        // Delete_ Speciale_ From _ advokate
        private void delete_speciale_from_advokat_comboBox_Click(object sender, EventArgs e)
        {
            delete_speciale_from_advokat_comboBox.Items.Clear();
            Load_Specialer((ComboBox)sender);

        }



        // Delete Speciale From Advokat  Button
        private void delete_speciale_from_advokat_delete_button_Click(object sender, EventArgs e)
        {
            if (delete_speciale_from_advokat_comboBox.SelectedIndex != -1)
            {
  
                DB_Connection_Write Delete_Speciale_From_Advokat = new DB_Connection_Write();
                Delete_Speciale_From_Advokat.CreateCommand($"Delete FROM Advokat_Uddannelser Where Advokat_Uddannelser.Advokat_Uddanelse = '{delete_speciale_from_advokat_comboBox.SelectedItem.ToString()}' AND Advokat_Uddannelser.Me_ID = '{delete_speciale_from_advokat_textBox.Text}';");
                delete_speciale_from_advokat_comboBox.Items.Clear();
                delete_speciale_from_advokat_textBox.Clear();
            }
            else
            {
                MessageBox.Show("Ugyldig Input", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----DELETE SPECIALE- From Advokate------------::END::----------------------------------------------














    }
}
