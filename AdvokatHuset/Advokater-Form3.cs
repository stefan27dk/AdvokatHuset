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
                                       //static readonly  DB_Connection_String ConnectionString = DB_Connection_String.GetConnectionString(); // Global Connectionstring
                                       //static SqlConnection connection = null; 




        // Show Advokatr - Database
        static string show_Advokat_Query = "Select Medarbejder.*, Medarbejder_Tlf.Me_Tlf From Medarbejder Full Join Medarbejder_Tlf ON Medarbejder.Me_ID = Medarbejder_Tlf.Me_ID Where Me_Type = 'Advokat';";
        DataSet Advokat_Dataset = new DataSet(); // Dataset for "Show Advokat" and "Show Advokat_Tlf"
                                         


        //TAdvokat_Tlf - Database
        static string Advokat_Tlf_Select_Query = "Select Medarbejder_Tlf.* From Medarbejder_Tlf inner join Medarbejder ON Medarbejder_Tlf.Me_ID = Medarbejder.Me_ID  Where Medarbejder.Me_Type = 'Advokat';";
        //static string Advokat_Tlf_Select_Query = "Select Advokat_Tlf.*, Advokat.Advokat_Fornavn, Advokat.Advokat_Efternavn From Advokat_Tlf Inner Join Advokat ON Advokat_Tlf.Advokat_ID = Advokat.Advokat_ID;";




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
        public Advokater_Form3()
        {
            InitializeComponent();
        }





        // Load
        private void Advokatr_Form9_Load(object sender, EventArgs e)
        {
            DatagridviewSettings_Style();
            LoadAdvokater();// Show all Advokatr "Populating the datagridview with Curtomers "Advokatr""
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
            advokatinstance.Fornavn = advokatr_name_textBox.Text;
            advokatinstance.Efternavn = advokatr_surname_textBox.Text;
            advokatinstance.PostNr = Convert.ToInt32(advokatr_zipcCode_textBox.Text);
            advokatinstance.Adresse = advokatr_adr_textBox.Text;
            advokatinstance.TlfNr = Convert.ToInt32(advokatr_tlf_textBox.Text);
            advokatinstance.Mail = advokat_email_textBox.Text;

        }





        // Insert to DB  "Insert Advokat to DB"
        private void InsertToDB()
        {
            ConnWrite = new DB_Connection_Write(); // "Write to DB Class instance"
            string AdvokatQuery = $"BEGIN DECLARE @UNIQUEX UNIQUEIDENTIFIER SET @UNIQUEX = NEWID(); Insert into Advokat Values('{advokatinstance.Fornavn}','{advokatinstance.Efternavn}',{advokatinstance.PostNr},'{advokatinstance.Adresse}', (@UNIQUEX),'{advokatinstance.Mail}', '{DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss")}'); Insert INTO Advokat_Tlf Values('{advokatr_tlf_textBox.Text}',(@UNIQUEX)); END;"; // Query
            successful = ConnWrite.CreateCommand(AdvokatQuery); // Write to DB Input and "Execution"
        }









        // Key Events--Validating--Textboxes----::START::---------------------------------------------- 
      
        // Validate Name
        private void advokatr_name_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = (int.TryParse(e.KeyChar.ToString(), out int isNumber) || (e.KeyChar == (char)Keys.Space));///Prevent Numbers and Spaces

        }



        // Validate Surname
        private void advokatr_surname_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (int.TryParse(e.KeyChar.ToString(), out int isNumber));///Prevent Numbers and Spaces
        }




        // Zip Code Validating
        private void advokatr_zipcCode_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && e.KeyChar != (char)26)/// "Allow backspace"  and CTRL+Z
            {
                    e.Handled = !int.TryParse(e.KeyChar.ToString(), out int isNumber);///Prevent letters
            }
        
        }




        // TLF Validating
        private void advokatr_tlf_textBox_KeyPress(object sender, KeyPressEventArgs e)
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
            if (advokatr_name_textBox.TextLength < 2)
            {
                isValid = false; // Now you cant proceed because its not valid
                advokatr_name_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }

            else
            {
                
                  for (int i = 0; i < advokatr_name_textBox.TextLength; i++)
                  {
                 
                      if(String.IsNullOrEmpty(advokatr_name_textBox.Text[i].ToString()) || int.TryParse(advokatr_name_textBox.Text[i].ToString(), out int isNumber) || advokatr_name_textBox.Text[i].ToString() == " ") // Check for numbers, null, 
                      {
                          isValid = false; // Now you cant proceed because its not valid
                          advokatr_name_textBox.BackColor = Color.FromArgb(255, 128, 128);
                        break;
                      }
                      
                  }

            }




            // Surname Validation------------------------------------------------------------------------> 
            if (advokatr_surname_textBox.TextLength < 2)
            {
                isValid = false; // Now you cant proceed because its not valid
                advokatr_surname_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
            
                 for (int i = 0; i < advokatr_surname_textBox.TextLength; i++)
                 {
                
                     if (String.IsNullOrEmpty(advokatr_surname_textBox.Text[i].ToString()) || int.TryParse(advokatr_surname_textBox.Text[i].ToString(), out int isNumber))  
                     {
                         isValid = false; // Now you cant proceed because its not valid
                         advokatr_surname_textBox.BackColor = Color.FromArgb(255, 128, 128);
                        break;
                     }
                
                 }

            }



             // TLF Validation--------------------------------------------------------------------------->

             if (advokatr_tlf_textBox.TextLength < 8)
             {
                isValid = false;
                advokatr_tlf_textBox.BackColor = Color.FromArgb(255, 128, 128);

            }

            else if(!int.TryParse(advokatr_tlf_textBox.Text, out int isNumber))
            {
                isValid = false;
                advokatr_tlf_textBox.BackColor = Color.FromArgb(255, 128, 128);
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
               if(advokatr_zipcCode_textBox.TextLength < 4)
               {
                isValid = false;
                advokatr_zipcCode_textBox.BackColor = Color.FromArgb(255, 128, 128);
               }
               else if(!int.TryParse(advokatr_zipcCode_textBox.Text, out int isNumber))
               {
                isValid = false;
                advokatr_zipcCode_textBox.BackColor = Color.FromArgb(255, 128, 128);
               }
            



            // Adress Validation------------------------------------------------------------------------>
            if(advokatr_adr_textBox.TextLength < 2)
            {
                isValid = false;
                advokatr_adr_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }
            
           
        }















        //-----------------CREATE---TEXTBOXES-SETTINGS---------::START::----------------------------------------------

        // Reset Textbox Color
        private void TextboxesResetColor()
        {
            advokatr_name_textBox.BackColor = Color.FromArgb(220, 243, 250);
            advokatr_surname_textBox.BackColor = Color.FromArgb(220, 243, 250);
            advokatr_tlf_textBox.BackColor = Color.FromArgb(220, 243, 250);
            advokat_email_textBox.BackColor = Color.FromArgb(220, 243, 250);
            advokatr_zipcCode_textBox.BackColor = Color.FromArgb(220, 243, 250);
            advokatr_adr_textBox.BackColor = Color.FromArgb(220, 243, 250);

        }




        // Clear All Textboxes
        private void ClearTextboxes()
        {
            advokatr_name_textBox.Clear();
            advokatr_surname_textBox.Clear();
            advokatr_tlf_textBox.Clear();
            advokat_email_textBox.Clear();
            advokatr_zipcCode_textBox.Clear();
            advokatr_adr_textBox.Clear();
        }




        // Save Button 
        private void advokatr_Save_button_Click(object sender, EventArgs e)
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
        private void vis_rediger_advokatr_button_Click(object sender, EventArgs e)
        {
            datagridviewBackground_panel.Visible = true;
            backPanel_Textboxes_panel.Visible = false;
            //this.advokatTableAdapter.Fill(this.advokathusetDataSet.Advokat);
        }



  

        // Opret Button
        private void opret_advokat_button_Click(object sender, EventArgs e)
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
            //DataTable dtImage = Advokat_Dataset.Tables[0];

            //    Advokat_Dataset.Tables.Add(dtImage);


            // Always the last item
            if (DeletedRowsList.Count > 0 && Advokat_dataGridView.DataMember == "Medarbejder")
            {
                int lastindex = DeletedRowsList.Count - 1;
               Advokat_Dataset.Tables[0].Rows.Add(DeletedRowsList[lastindex].Cells[0].Value, DeletedRowsList[lastindex].Cells[1].Value, DeletedRowsList[lastindex].Cells[2].Value, DeletedRowsList[lastindex].Cells[3].Value, DeletedRowsList[lastindex].Cells[4].Value, DeletedRowsList[lastindex].Cells[5].Value, DeletedRowsList[lastindex].Cells[6].Value);
               SaveDataGridView(); // Save to DB  

                //inserdetindex.Add(advokat);
                DeletedRowsList.RemoveAt(lastindex); // Remove Last index

            }


        }

        //----------DELETE------------------::END::-------------------------------------------------------------------------------------- 










        // Show Customers "Advokatr" - Main Method
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
            //Advokat_dataGridView.Columns[7].ReadOnly = true;  // Forbid Editing Advokat_Tlf
           
        }



        // Show_Advokat-Tlf - Load Advokat_Tlf - Main Method
        private void LoadAdvokat_Tlf()
        {
            string Advokat_Tlf_Advokat_navn_Select = "Select Medarbejder_Tlf.*, Medarbejder.Me_Fornavn, Medarbejder.Me_Efternavn From Medarbejder_Tlf inner join Medarbejder ON Medarbejder_Tlf.Me_ID = Medarbejder.Me_ID  Where Medarbejder.Me_Type = 'Advokat';";
            // Clear the Columns 
            if (Advokat_dataGridView.DataMember == "Medarbejder")
            {
                Advokat_dataGridView.Columns.Clear();
            }

            // Advokat_Tlf
            Advokat_Dataset.Clear();
            Datagridview_Loader Load_Advokat_Tlf = new Datagridview_Loader();
            Load_Advokat_Tlf.DB_Populate(Advokat_Tlf_Advokat_navn_Select, Advokat_Dataset, "Medarbejder_Tlf");
            Advokat_dataGridView.DataSource = Advokat_Dataset;
            Advokat_dataGridView.DataMember = "Medarbejder_Tlf";
            //Advokat_dataGridView.Columns[2].ReadOnly = true;  // Forbid Editing Advokat_ForNavn
            //Advokat_dataGridView.Columns[3].ReadOnly = true;  // Forbid Editing Advokat_EfterNavn

        }










         //----SAVE-UPDATE--DATAGRIDVIEW-------::START::---------------------------------------------------------------------------------- 

        // Save Cutomers "KUNDER"
        private void SaveDataGridView()
        {
            bool a = false;
            // Save changes to DB  "UPDATE Advokatr"
            if(Advokat_dataGridView.DataMember == "Advokat_Tlf") // Advokat_Tlf
            {
                Advokat_dataGridView.EndEdit();
                DatagridView_Save Update_Advokater = new DatagridView_Save();
                Update_Advokater.DatagridView_Update(Advokat_Tlf_Select_Query, Advokat_Dataset, "Advokat_Tlf", this.Advokat_dataGridView );

            }

            else if(Advokat_dataGridView.DataMember == "Advokat")   // KUNDE
            {
                    Advokat_dataGridView.EndEdit();
                    DatagridView_Save Update_Advokater = new DatagridView_Save();
                    Update_Advokater.DatagridView_Update("Select* From Advokat", Advokat_Dataset, "Advokat", this.Advokat_dataGridView);
            }
         

        }

           
     

        // UPDATE - Get row to Compare on Row enter "Used to determine if the row have been changed so we know when to edit "Save the changes""
        private void Advokat_dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Selected_Row_For_Compare();
        }




       // Row Enter - Main Method "It is used also for reseting the row Comparison when Column Header Is Clicked"
       private void Selected_Row_For_Compare()
        {
            if (Advokat_dataGridView.SelectedRows.Count > 0) // I there are
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







        // Reset Row Selection "For Save"
        private void Advokat_dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Selected_Row_For_Compare();
        }

      

        // RefreshDatagridview "After Update OR Cancelation"
        private void RefreshDatagridview()
        {
            if (Advokat_dataGridView.DataMember == "Advokat")
            {
                LoadAdvokater();
            }
            else if (Advokat_dataGridView.DataMember == "Advokat_Tlf")
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




        // Show All Customers "Advokatr" - Button
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
                    SearchColumn_SearchString = $"IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select* From Advokat Where  Advokat_Fornavn {SearchOptions} OR Advokat_Efternavn {SearchOptions} OR Advokat_Adresse {SearchOptions} OR Advokat_Email {SearchOptions} OR Advokat_Oprets_Dato {SearchOptions} OR Advokat_ID {SearchOptions} END ELSE  BEGIN SELECT Advokat.*, Advokat_Tlf.Advokat_Tlf From Advokat Full Join Advokat_Tlf ON Advokat.Advokat_ID = Advokat_Tlf.Advokat_ID Where Advokat_PostNr {SearchOptions} OR Advokat_Tlf.Advokat_Tlf {SearchOptions} OR Advokat_Fornavn {SearchOptions} OR Advokat_Efternavn {SearchOptions} OR Advokat_Adresse {SearchOptions} OR Advokat_Email {SearchOptions} OR Advokat_Oprets_Dato {SearchOptions} OR Advokat.Advokat_ID {SearchOptions} END;  ";
                    break;
                case 1: // Name
                    SearchColumn_SearchString = $"SELECT* From Advokat Where Advokat.Advokat_Fornavn {SearchOptions}";
                    break;
                case 2:   // Surname
                    SearchColumn_SearchString = $"SELECT* From Advokat Where Advokat.Advokat_Efternavn {SearchOptions}";
                    break;
                case 3:  //Adress
                    SearchColumn_SearchString = $"SELECT* From Advokat Where Advokat.Advokat_Adresse {SearchOptions}";
                    break;
                case 4:  // Zip-Code
                    SearchColumn_SearchString = $" IF(ISNUMERIC('{search_textBox.Text}') = 1) BEGIN SELECT* From Advokat Where Advokat_PostNr {SearchOptions} END";
                    break;
                case 5: //TLF
                    SearchColumn_SearchString = $" IF(ISNUMERIC('{search_textBox.Text}') = 1) BEGIN SELECT Advokat.*, Advokat_Tlf.Advokat_Tlf From Advokat Full Join Advokat_Tlf ON  Advokat.Advokat_ID = Advokat_Tlf.Advokat_ID Where Advokat_Tlf.Advokat_Tlf {SearchOptions} END";
                    break;
                case 6: // ID
                    SearchColumn_SearchString = $"SELECT* From Advokat Where Advokat.Advokat_ID {SearchOptions}";
                    break;
                case 7: // Email
                    SearchColumn_SearchString = $"SELECT* From Advokat Where Advokat.Advokat_Email {SearchOptions}";
                    break;
                case 8: // Date
                    SearchColumn_SearchString = $"SELECT* From Advokat Where Advokat.Advokat_Oprets_Dato {SearchOptions}";

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
            Load_Search_Result.DB_Populate(SearchColumn_SearchString, Advokat_Dataset, "Advokat");
            Advokat_dataGridView.DataSource = Advokat_Dataset;
            Advokat_dataGridView.DataMember = "Advokat";
 
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
            if(Advokat_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor != Color.FromArgb(191, 50, 95))
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
        //--------------Datagridview - Change - Color------------::END:----------------------------------------------------------------


















        //------------PDF--PRINT------------------::START::----------------------------------------------------------------------------
        // Print Datagridview
        private void print_button_Click(object sender, EventArgs e)
        {
            Datagridview_To_PDF(); // Method for Converting the Current Datagridview result to PDF
            OpenLastFile();

        }




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

            using(FileStream stream = new FileStream(LocalFolderPath + "Advokatr_PDF -  "+DateTime.Now.ToString("dd-MM-yyyy   HH-mm-ss")+".pdf", FileMode.Create))
            {
                Document PDF_DOC = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(PDF_DOC, stream);
                PDF_DOC.Open();
                PDF_DOC.Add(Pdf_DGV);
                PDF_DOC.Close();
                stream.Close();


            }



            ////USING -  iTextSharp - Class
            //PdfPTable pdfTable = new PdfPTable(Advokat_dataGridView.ColumnCount);
            //pdfTable.DefaultCell.Padding = 3;
            //pdfTable.WidthPercentage = 100;
            //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            //pdfTable.DefaultCell.BorderWidth = 1;

            ////Adding Columns to the Pdf
            //foreach (DataGridViewColumn column in Advokat_dataGridView.Columns)
            //{
            //    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
            //    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
            //    pdfTable.AddCell(cell);
            //}

            ////Add Rows and Cells to the Pdf

            //for (int i = 0; i < Advokat_dataGridView.Rows.Count; i++)
            //{
            //    for (int a = 0; a < Advokat_dataGridView.Rows[i].Cells.Count; a++)
            //    {
            //        if (Advokat_dataGridView.Rows[i].Cells[a].Value != null)
            //        {

            //            pdfTable.AddCell(Advokat_dataGridView.Rows[i].Cells[a].Value.ToString());

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
        private void advokatr_name_textBox_TextChanged(object sender, EventArgs e)
        {
            advokatr_name_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }





        // Surname - Reset Color
        private void advokatr_surname_textBox_TextChanged(object sender, EventArgs e)
        {
            advokatr_surname_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }





        // Zip Code - Reset Background
        private void advokatr_zipcCode_textBox_TextChanged(object sender, EventArgs e)
        {
            advokatr_zipcCode_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }




        // Adress - Reset Background
        private void advokatr_adr_textBox_TextChanged(object sender, EventArgs e)
        {
            advokatr_adr_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }




        // Tlf - Reset Background
        private void advokatr_tlf_textBox_TextChanged(object sender, EventArgs e)
        {
            advokatr_tlf_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }


        // Email - Reset Background 
        private void advokat_email_textBox_TextChanged(object sender, EventArgs e)
        {
            advokat_email_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }

     

        //-------------CREATE-TEXTBOXES -- Reset Color on Typing-------------------::END:--------------------------------------------------


















    }
}
