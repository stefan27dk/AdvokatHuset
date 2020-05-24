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
    public partial class Sager_Form2 : Form
    {
     
        

        // Local Folder
        string LocalFolderPath = "C://";  // Gets Assignet in initialize

        //DB
        Sag Saginstance; // Instance af Sag 
        DB_Connection_Write ConnWrite; // Sql Write "
        //static readonly  DB_Connection_String ConnectionString = DB_Connection_String.GetConnectionString(); // Global Connectionstring
        //static SqlConnection connection = null; 
      

       

        // Show Sag - Database
        //static string show_Sag_Query = "Select Sag.*, Sag_Tlf.Sag_Tlf  From Sag Full Join Sag_Tlf ON Sag.Sag_ID = Sag_Tlf.Sag_ID AND";
        static string show_Sag_Query = "Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID";



        DataSet Sag_Dataset = new DataSet(); // Dataset for "Show Sag" and "Show Sag_Tlf"
                                                

        



        // Row Edit
        DataGridViewRow enterRow = new DataGridViewRow(); // On Enter






        // Validate Textboxes bools
        bool isValid = true; // Inputboxes Validator
        bool successful = false; // Successful Transaction




        // Validate ADD-Ydelse
        bool Add_Ydelse_Validate = true;




        // Validate Add Time
        bool Add_time_validate = true;



        // Validate Kørsel - Tid
        bool Validate_Koersel_TId = true;


        // Undo Delete
        List<DataGridViewRow> DeletedRowsList = new List<DataGridViewRow>(); // List with deleted Rows




        // Search string
        string SearchOptions = "";
        string SearchColumn_SearchString = "";



 

        // Initialize
        public Sager_Form2()
        {
            InitializeComponent();
        }





        // Load
        private void Sag_Form9_Load(object sender, EventArgs e)
        {
            DatagridviewSettings_Style();
            LoadSag();// Show all Sag "Populating the datagridview with Curtomers "Sag""
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
            Sag_dataGridView, new object[] { true });
        }



        // Datagridview Color Style
        private void Black_DatagridviewStyle()
         {

            this.Sag_dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.Sag_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 34);
            this.Sag_dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(59, 203, 255);  // Datagridview Fore Color
            this.Sag_dataGridView.GridColor = Color.Gray;
            this.Sag_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point
            this.Sag_dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 94);
            this.Sag_dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 32, 29);
            
            //this.Sag_dataGridView.DefaultCellStyle..Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold);

         }





        //  Datagridview Color Style "White" 
        private void White_DatagridviewStyle()
        {

            this.Sag_dataGridView.RowsDefaultCellStyle.BackColor = DefaultBackColor;
            this.Sag_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = DefaultBackColor;
            this.Sag_dataGridView.DefaultCellStyle.ForeColor = DefaultForeColor;  // Datagridview Fore Color
            this.Sag_dataGridView.GridColor = Color.Gray;
            this.Sag_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point

        }


        //-----------SETTINGS------------::END::--------------------------------------------------------------------------------------------














        // Create Sag------------------------------------------------------------------
        private void CreateSag()
        {
            Saginstance = new Sag();
            Saginstance.SagType = opret_sag_Type_textBox.Text;
            Saginstance.AdvokatID = opret_sag_advokatID_textBox.Text;
            Saginstance.KundeID = opret_sag_Kunde_ID_textBox.Text;

        }











        // Insert to DB  "Insert Sag to DB"------------------------------------------
        private void InsertToDB()
        {
            ConnWrite = new DB_Connection_Write(); // "Write to DB Class instance"
            string SagQuery = $"DECLARE @UNIQUEX UNIQUEIDENTIFIER SET @UNIQUEX = NEWID(); Insert Into Sag Values('{DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss")}', Null, '{Saginstance.SagType}', 0, (@UNIQUEX), '{Saginstance.KundeID}', '{Saginstance.AdvokatID}');"; // Query
            successful = ConnWrite.CreateCommand(SagQuery); // Write to DB Input and "Execution"
        }















        // validate All -----------::START::-------------------------------------------------------------------------------------
         private void ValidateAll()
         {

            // Sag Type - Validating
           if(opret_sag_Type_textBox.Text.Length < 2)
           {
                isValid = false;
                opret_sag_Type_textBox.BackColor = Color.FromArgb(255, 192, 192);

           }


           // Advokat ID Validating
           if(opret_sag_advokatID_textBox.Text.Length < 15)
           {
                isValid = false;
                opret_sag_advokatID_textBox.BackColor = Color.FromArgb(255, 192, 192);
           }

           if(opret_sag_Kunde_ID_textBox.Text.Length <15)
            {
                isValid = false;
                opret_sag_Kunde_ID_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }


         }

        // validate All -----------::END::-------------------------------------------------------------------------------------

















        //-----------------CREATE---TEXTBOXES-SETTINGS---------::START::----------------------------------------------

        // Reset Textbox Color
        private void TextboxesResetColor()
        {
            opret_sag_Type_textBox.BackColor = Color.FromArgb(220, 243, 250);
            opret_sag_advokatID_textBox.BackColor = Color.FromArgb(220, 243, 250);
            opret_sag_Kunde_ID_textBox.BackColor = Color.FromArgb(220, 243, 250);

        }




        // Clear All Textboxes
        private void ClearTextboxes()
        {
            add_sag_Advokat_name_comboBox.Items.Clear();
            opret_sag_Type_textBox.Clear();
            opret_sag_advokatID_textBox.Clear();
            opret_sag_Kunde_ID_textBox.Clear();
        }




        // Save Button- 
        private void Sag_Save_button_Click(object sender, EventArgs e)
        {
            TextboxesResetColor(); // Reset Color
            ValidateAll(); // Validate

            if(isValid == true)
            {
                CreateSag(); // Create Sag From the textboxes "ID and Date is autogenerated" 
                InsertToDB(); // Add it to the DB


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



        // Opret Button
        private void opret_Sag_button_Click(object sender, EventArgs e)
        {
            HideAll_Menu_Windows();
            backPanel_Textboxes_Opret_sag_panel.Visible = true;

        }







        // Vis Rediger // Show Datagridview
        private void vis_rediger_Sag_button_Click(object sender, EventArgs e)
        {
            HideAll_Menu_Windows();
            datagridviewBackground_panel.Visible = true;
            
        }





  




        // Add - Ydelse - Button
        private void button1_Click(object sender, EventArgs e)
        {
            HideAll_Menu_Windows();
            sag_Add_Ydelse_panel.Visible = true;
        }







        // Hide All Menu_Windows
        private void HideAll_Menu_Windows()
        {
            Register_Koersel_Back_Panel_panel.Visible = false;
            add_time_back_panel.Visible = false;
            update_sag_Back_panel.Visible = false;
            backPanel_Textboxes_Opret_sag_panel.Visible = false;
            datagridviewBackground_panel.Visible = false;// Hide Datagridview
            sag_Add_Ydelse_panel.Visible = false;

        }















        // Form Menu-----------::END::----------------------------------------------












        //Shortcut keys-----KEY WATCHER-----------::START::--------------------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            // Open Item Menu Shortcut
            if (keyData == (Keys.Delete))
            {
                if(Sag_dataGridView.Focused && Sag_dataGridView.SelectedRows.Count > 0)
                {
                    DeleteFromDatagridview();
                }
            }

            // Copy Editing Cell
            if (keyData == (Keys.Control | Keys.C | Keys.Alt))
            {  
               Clipboard.SetText(Sag_dataGridView.SelectedRows[0].Cells[Sag_dataGridView.CurrentCell.ColumnIndex].Value.ToString());
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
                if(Sag_dataGridView.SelectedRows.Count > 0) // Check if any row is selected
                {
                   DialogResult deleteDialog = MessageBox.Show("Are you sure that you want to delete the selected row?", "Delete: Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                   if (deleteDialog == DialogResult.Yes)
                   {
                       AddRowToList(); // Add to list the row that will be deleted
                       Sag_dataGridView.Rows.RemoveAt(Sag_dataGridView.SelectedRows[0].Index); //  Delete selected row
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
           
            if (Sag_dataGridView.CurrentRow.Cells.Count == Sag_dataGridView.ColumnCount) // If all cels are selected on the current row
            {
                
                DataGridViewRow row = (DataGridViewRow)Sag_dataGridView.SelectedRows[0].Clone();
                for (int i = 0; i < Sag_dataGridView.SelectedCells.Count; i++)
                {
                    row.Cells[i].Value = Sag_dataGridView.SelectedCells[i].Value;
                }
                DeletedRowsList.Add(row);
            }
        }





        // Undo  DELETE - Button
        private void undo_button_Click(object sender, EventArgs e)
        { 

  
            if (DeletedRowsList.Count > 0 && Sag_dataGridView.DataMember == "Sag")
            {
                int lastindex = DeletedRowsList.Count - 1;

                Sag_Dataset.Tables[0].Rows.Add(DeletedRowsList[lastindex].Cells[0].Value, DeletedRowsList[lastindex].Cells[1].Value, DeletedRowsList[lastindex].Cells[2].Value, DeletedRowsList[lastindex].Cells[3].Value, DeletedRowsList[lastindex].Cells[4].Value, DeletedRowsList[lastindex].Cells[5].Value, DeletedRowsList[lastindex].Cells[6].Value, DeletedRowsList[lastindex].Cells[7].Value, DeletedRowsList[lastindex].Cells[8].Value, DeletedRowsList[lastindex].Cells[9].Value, DeletedRowsList[lastindex].Cells[10].Value, DeletedRowsList[lastindex].Cells[11].Value, DeletedRowsList[lastindex].Cells[12].Value);


                SaveDataGridView(); // Save to DB  

                //inserdetindex.Add(Sag);
                DeletedRowsList.RemoveAt(lastindex); // Remove Last index
                RefreshDatagridview(); // Refresh
            }


        }

        //----------DELETE------------------::END::-------------------------------------------------------------------------------------- 















         //---------------------------------LOAD-----------::START::---------------------------------------------------------------------------------------------------------

        // Show Customers "Sag" - Main Method
        private void LoadSag()
        {
            if(Sag_dataGridView.DataMember != "Sag")
            {
            Sag_dataGridView.Columns.Clear();
            }
        
            Sag_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"
            Datagridview_Loader Load_Customers = new Datagridview_Loader();
            Load_Customers.DB_Populate(show_Sag_Query, Sag_Dataset, "Sag");
            Sag_dataGridView.DataSource = Sag_Dataset;
            Sag_dataGridView.DataMember = "Sag";
            
            Sag_dataGridView.Columns[5].ReadOnly = true;  // Forbid Editing 
            Sag_dataGridView.Columns[6].ReadOnly = true;  // Forbid Editing
            Sag_dataGridView.Columns[7].ReadOnly = true;  // Forbid Editing
            Sag_dataGridView.Columns[8].ReadOnly = true;  // Forbid Editing
            Sag_dataGridView.Columns[9].ReadOnly = true;  // Forbid Editing
            Sag_dataGridView.Columns[10].ReadOnly = true;  // Forbid Editing
            Sag_dataGridView.Columns[11].ReadOnly = true;  // Forbid Editing
            Sag_dataGridView.Columns[12].ReadOnly = true;  // Forbid Editing

            

        }



        // Show_Ydelser - Main Method
        private void LoadSag_Ydelser()
        {
            string Sag_Tlf_Sag_navn_Select = "Select SY.Sag_ID, SY.Sag_Ydelse_Oprets_Dato, Y.Ydelse_Navn, SY.Ydelse_Nr, T.Tid From Sag_Ydelser AS SY Full Join Ydelse As Y ON SY.Ydelse_Nr = Y.Ydelse_Nr Inner Join Tid AS T ON SY.Sag_ID = T.Sag_ID ";

            if (Sag_dataGridView.DataMember != "Sag_Ydelser") 
            {
            Sag_dataGridView.Columns.Clear();

            }
       

            // Sag_Ydelser
            Sag_Dataset.Clear();
            Datagridview_Loader Load_Sag_Tlf = new Datagridview_Loader();
            Load_Sag_Tlf.DB_Populate(Sag_Tlf_Sag_navn_Select, Sag_Dataset, "Sag_Ydelser");
            Sag_dataGridView.DataSource = Sag_Dataset;
            Sag_dataGridView.DataMember = "Sag_Ydelser";
            Sag_dataGridView.Columns[2].ReadOnly = true;  // Forbid Editing 
            Sag_dataGridView.Columns[4].ReadOnly = true;  // Forbid Editing 

        }
















        // Show_Sag-Tid - Load Sag_Tid - Main Method
        private void LoadSag_Tid()
        {
            string Sag_Tlf_Sag_navn_Select = "Select T.Tid, T.Tid_Dato, T.Tid_ID, T.Ydelse_Nr, M.Me_Fornavn, T.Advokat_ID From Tid AS T Inner Join Medarbejder AS M ON T.Advokat_ID = M.Me_ID ";


            if (Sag_dataGridView.DataMember != "Tid")
            {
                Sag_dataGridView.Columns.Clear();

            }


            // Sag_Tid
            Sag_Dataset.Clear();
            Datagridview_Loader Load_Sag_Tlf = new Datagridview_Loader();
            Load_Sag_Tlf.DB_Populate(Sag_Tlf_Sag_navn_Select, Sag_Dataset, "Tid");
            Sag_dataGridView.DataSource = Sag_Dataset;
            Sag_dataGridView.DataMember = "Tid";
            Sag_dataGridView.Columns[4].ReadOnly = true;  // Forbid Editing 
            //Sag_dataGridView.Columns[3].ReadOnly = true;  // Forbid Editing  

        }















        // Show_Sag- Køre-Tid - Load Sag_køre_Tid - Main Method
        private void LoadKoersel_Tid()
        {
            string Sag_Tlf_Sag_navn_Select = "Select K.Kørsel_Tid, K.Kørsel_Dato, K.Kørsel_Notering, K.Kørsel_ID, K.Sag_Id, M.Me_Fornavn AS Advokat_Fornavn, K.Advokat_ID  From Kørsel AS K Inner join Medarbejder As M ON K.Advokat_ID = M.Me_ID";


            if (Sag_dataGridView.DataMember != "Kørsel")
            {
                Sag_dataGridView.Columns.Clear();

            }


            // Sag_Kørsel_Tid
            Sag_Dataset.Clear();
            Datagridview_Loader Load_Sag_Tlf = new Datagridview_Loader();
            Load_Sag_Tlf.DB_Populate(Sag_Tlf_Sag_navn_Select, Sag_Dataset, "Kørsel");
            Sag_dataGridView.DataSource = Sag_Dataset;
            Sag_dataGridView.DataMember = "Kørsel";
            Sag_dataGridView.Columns[5].ReadOnly = true;  // Forbid Editing  
            //Sag_dataGridView.Columns[3].ReadOnly = true;  // Forbid Editing Sag_EfterNavn

        }
        //---------------------------------LOAD-----------::END::---------------------------------------------------------------------------------------------------------


















        //----SAVE-UPDATE--DATAGRIDVIEW-------::START::---------------------------------------------------------------------------------- 

        // Save Cutomers "Sag"
        private void SaveDataGridView()
        {          
            
            // Save changes to DB  "UPDATE Sag"
            if(Sag_dataGridView.DataMember == "Sag_Tlf") // Sag_Tlf
            {
                Sag_dataGridView.EndEdit();
                DatagridView_Save Update_Sag = new DatagridView_Save();
                Update_Sag.DatagridView_Update("", Sag_Dataset, "Sag_Tlf", this.Sag_dataGridView);

            }

            else if(Sag_dataGridView.DataMember == "Sag")   // Sag
            {
                Sag_dataGridView.EndEdit();
                DatagridView_Save Update_Sag = new DatagridView_Save();
                Update_Sag.DatagridView_Update("Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, S.Sag_Kunde_ID, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID From Sag As S ", Sag_Dataset, "Sag", this.Sag_dataGridView);
            }
         

        }

           
     

        // UPDATE - Get row to Compare on Row enter "Used to determine if the row have been changed so we know when to "Save the changes""
        private void Sag_dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Selected_Row_For_Compare();
        }




       // Row Enter - Main Method "It is used also for reseting the row Comparison when Column Header Is Clicked"
       private void Selected_Row_For_Compare()
        {
            if (Sag_dataGridView.SelectedRows.Count > 0) // I there is selected row
            {

                // Clone Row
                enterRow = (DataGridViewRow)Sag_dataGridView.SelectedRows[0].Clone();

                // Add Data to the Cloned Row
                for (int i = 0; i < Sag_dataGridView.SelectedRows[0].Cells.Count; i++)
                {
                    enterRow.Cells[i].Value = Sag_dataGridView.SelectedRows[0].Cells[i].Value;
                }


            }

        }





        // Row Leave - "ON - Validattion" - UPDATE "SAVE" - On ROW LEAVE AFTER VALIDATION  "Save"
        private void Sag_dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
             bool edited = false; // Check if the Row was edited

            if (Sag_dataGridView.SelectedRows.Count > 0) // Selected minimum 1 row
            {


                for (int j = 0; j < Sag_dataGridView.SelectedRows[0].Cells.Count; j++)
                {
                

                    if (Sag_dataGridView.SelectedRows[0].Cells[j].Value != null && !Sag_dataGridView.SelectedRows[0].Cells[j].Value.Equals(enterRow.Cells[j].Value))
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
        private void Sag_dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Selected_Row_For_Compare();
        }

      

        // RefreshDatagridview "After Update OR Cancelation"
        private void RefreshDatagridview()
        {
            if (Sag_dataGridView.DataMember == "Sag")
            {
                LoadSag();
            }
            else if (Sag_dataGridView.DataMember == "Sag_Tlf")
            {
                LoadSag_Ydelser();
            }
        }


        //----SAVE-UPDATE--DATAGRIDVIEW-------::END::--------------------------------------------------------------------------------------- 











      



















        //-------------BUTTONS-Datagridview--Menu-------::START::----------------------------------------------------------------------------

        // Local Folder
        private void local_folder_button_Click(object sender, EventArgs e)
        {
            Open_Local_Folder();
        }




        // Show All Customers "Sag" - Button
        private void show_all_button_Click(object sender, EventArgs e)
        {
            LoadSag();


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



         //-----------------DG----MENU-----:START::--------------------------------------
        // Sag_Ydelse- DG- Button - Show Ydelser
        private void Sag_ydelse_DG__button_Click(object sender, EventArgs e)
        {
            LoadSag_Ydelser();
            if (search_textBox.TextLength > 0)
            {
                search_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }

        }





        // Sag_Tid - DG- Button - Show Tid
        private void sag_Tid_DG_button_Click(object sender, EventArgs e)
        {

             LoadSag_Tid();
            if (search_textBox.TextLength > 0)
            {
                search_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }
        }






        // Sag_Kørsel - DG- Button - Show Kørsel

        private void sag_koersel_DG_button_Click(object sender, EventArgs e)
        {
            LoadKoersel_Tid();
            if (search_textBox.TextLength > 0)
            {
                search_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }
        }


        //-----------------DG----MENU-----------::END::---------------------------





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
            Search_Column_comboBox.Items.Add("Type");
            Search_Column_comboBox.Items.Add("Sag ID");
            Search_Column_comboBox.Items.Add("Oprets_Dato");
            Search_Column_comboBox.Items.Add("Slut_dato");
            Search_Column_comboBox.Items.Add("Kunde_Navn");
            Search_Column_comboBox.Items.Add("Kunde Efternavn");
            Search_Column_comboBox.Items.Add("Kunde ID");
            Search_Column_comboBox.Items.Add("Advokat_Fornavn");
            Search_Column_comboBox.Items.Add("Advokat_Efternavn");
            Search_Column_comboBox.Items.Add("Advokat ID");
            Search_Column_comboBox.Items.Add("Tid");
            Search_Column_comboBox.Items.Add("Tid_Dato");
            Search_Column_comboBox.Items.Add("Sag_Ydelse Fra Sag ID");
            Search_Column_comboBox.Items.Add("Sag_Tid Fra Sag ID");
            Search_Column_comboBox.Items.Add("Sag_Kørsel Fra Sag ID");
            Search_Column_comboBox.Items.Add("Sag_Afslutet");
            Search_Column_comboBox.Items.Add("Sag_Total Tid");
            Search_Column_comboBox.Items.Add("Sag_Total_Kørsel");
            Search_Column_comboBox.SelectedIndex = 0;

        }


        // Search Queries - / Columns / Search - Text
        private void Search_Column()
        {
            //SearchColumn_SearchString
          

            switch (Search_Column_comboBox.SelectedIndex)
            {

                case 0: // ALL
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where S.Sag_Type {SearchOptions} OR S.Sag_ID {SearchOptions} OR S.Sag_Oprets_Dato {SearchOptions} OR S.Sag_Slut_Dato {SearchOptions} OR K.Kunde_Fornavn {SearchOptions} OR K.Kunde_Efternavn {SearchOptions} OR S.Sag_Kunde_ID {SearchOptions} OR M.Me_Fornavn {SearchOptions} OR M.Me_Efternavn {SearchOptions} OR S.Sag_Advokat_ID {SearchOptions} OR T.Tid {SearchOptions} OR T.Tid_Dato {SearchOptions};";
                    //IF(ISNUMERIC('{search_textBox.Text}') = 0) BEGIN Select* From Sag Where  Sag_Fornavn {SearchOptions} OR Sag_Efternavn {SearchOptions} OR Sag_Adresse {SearchOptions} OR Sag_Email {SearchOptions} OR Sag_Oprets_Dato {SearchOptions} OR Sag_ID {SearchOptions} END ELSE  BEGIN SELECT Sag.*, Sag_Tlf.Sag_Tlf From Sag Full Join Sag_Tlf ON Sag.Sag_ID = Sag_Tlf.Sag_ID Where Sag_PostNr {SearchOptions} OR Sag_Tlf.Sag_Tlf {SearchOptions} OR Sag_Fornavn {SearchOptions} OR Sag_Efternavn {SearchOptions} OR Sag_Adresse {SearchOptions} OR Sag_Email {SearchOptions} OR Sag_Oprets_Dato {SearchOptions} OR Sag.Sag_ID {SearchOptions} END;
                    break;
                case 1: // Sag Type
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where S.Sag_Type {SearchOptions}";
                    break;
                case 2:   // Sag ID
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where S.Sag_ID {SearchOptions}";
                    break;
                case 3:  //Oprets Dato
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where S.Sag_Oprets_Dato {SearchOptions}";
                    break;
                case 4:  //Slut Dato
                    SearchColumn_SearchString = $" Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where S.Sag_Slut_Dato {SearchOptions}";
                    break;
                case 5: // Kunde Navn
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where K.Kunde_Fornavn {SearchOptions}";
                    break;
                case 6: //Kunde Efternavn
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where K.Kunde_Efternavn {SearchOptions}";
                    break; 
                case 7: //Kunde ID
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where K.Kunde_ID {SearchOptions}";
                    break;
                case 8: // Advokat Fornavn
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where M.Me_Fornavn {SearchOptions}";
                    break;
                case 9: // Advokat Efternavn
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where M.Me_Efternavn {SearchOptions}";
                    break;  
                case 10: // Advokat ID
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where M.Me_ID {SearchOptions}";
                    break;
                case 11: // Tid
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where T.Tid {SearchOptions}";
                    break;
                case 12: // Tid Dato
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where T.Tid_Dato {SearchOptions}";
                    break;
               case 13: // Sag_Ydelse
                    SearchColumn_SearchString = $"Select SY.Sag_ID, Sy.Sag_Ydelse_Oprets_Dato, SY.Ydelse_Nr, Y.Ydelse_Navn, S.Sag_Kunde_ID, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn As Advokat_Efternavn, S.Sag_Afslutet, S.Sag_Oprets_Dato, S.Sag_Type, S.Sag_Slut_Dato, T.Tid, T.Tid_Dato, Y.Ydelse_Type From Sag_Ydelser AS Sy Inner Join Ydelse AS Y ON  Sy.Ydelse_Nr = Y.Ydelse_Nr Inner Join Sag AS S ON Sy.Sag_ID = S.Sag_ID Inner Join Kunde AS K ON S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder M On S.Sag_Advokat_ID = M.Me_ID Inner JOIN Tid AS T ON Sy.Ydelse_Nr = T.Ydelse_Nr Where Sy.Sag_ID {SearchOptions}";
                    break;
               case 14: // Sag_Tid
                    SearchColumn_SearchString = $"SELECT T.Tid_ID, T.Tid, T.Tid_Dato, T.Sag_ID, S.Sag_Type, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, T.Ydelse_Nr, Y.Ydelse_Navn, T.Advokat_ID AS Ansvarlig_Advokat_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Kunde_ID, K.Kunde_Fornavn, K.Kunde_Efternavn FROM TID AS T Inner Join Ydelse AS Y ON T.Ydelse_Nr = Y.Ydelse_Nr  INNER JOIN Medarbejder AS M ON T.Advokat_ID = M.Me_ID Inner Join Sag AS S ON T.Sag_ID = S.Sag_ID Inner Join Kunde AS K ON Sag_Kunde_ID = K.Kunde_ID  Where T.Sag_ID {SearchOptions}";
                    break;
               case 15: // Sag_Køretid
                    SearchColumn_SearchString = $"Select Ko.Kørsel_Tid, Ko.Kørsel_Dato, Ko.Kørsel_Notering, Ko.Advokat_ID AS Kørsel_Advokat_ID, M.Me_Fornavn AS Kørsel_Advokat_Fornavn, Ko.Kørsel_ID, S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID From Sag As S Full Join Kørsel AS Ko On S.Sag_ID = Ko.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON Ko.Advokat_ID = M.Me_ID Where Ko.Sag_ID {SearchOptions}";
                    break; 
                case 16: // Sag_Afsluted
                    SearchColumn_SearchString = $"Select S.Sag_Type, S.Sag_ID, S.Sag_Oprets_Dato, S.Sag_Slut_Dato, S.Sag_Afslutet, K.Kunde_Fornavn, K.Kunde_Efternavn, S.Sag_Kunde_ID, M.Me_Fornavn AS Advokat_Fornavn, M.Me_Efternavn AS Advokat_Efternavn, S.Sag_Advokat_ID AS Ansvarlig_Advokat_ID, T.Tid, T.Tid_Dato From Sag As S Full Join Tid AS T On S.Sag_ID = T.Sag_ID Inner Join Kunde As K On S.Sag_Kunde_ID = K.Kunde_ID Inner Join Medarbejder AS M ON S.Sag_Advokat_ID = M.Me_ID Where (S.Sag_Type {SearchOptions} OR S.Sag_ID {SearchOptions} OR S.Sag_Oprets_Dato {SearchOptions} OR S.Sag_Slut_Dato {SearchOptions} OR K.Kunde_Fornavn {SearchOptions} OR K.Kunde_Efternavn {SearchOptions} OR S.Sag_Kunde_ID {SearchOptions} OR M.Me_Fornavn {SearchOptions} OR M.Me_Efternavn {SearchOptions} OR S.Sag_Advokat_ID {SearchOptions} OR T.Tid {SearchOptions} OR T.Tid_Dato {SearchOptions}) AND S.Sag_Afslutet = 1";
                    break;
              case 17: // Sag_Total_TID
                    SearchColumn_SearchString = $"Select SUM(T.Tid) AS Total_Tid From Tid AS T Where T.Sag_ID { SearchOptions}";
                    break;  
                case 18: // Sag_Køre_Total_TID
                    SearchColumn_SearchString = $"Select SUM(K.Kørsel_Tid) AS Total_Kørsel_Tid From Kørsel AS K  Where K.Sag_ID { SearchOptions}";
                    break;
                    
            }
        }



        // Search - DB - Connection
        private void Search()
        {
            Sag_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"
            Datagridview_Loader Load_Search_Result = new Datagridview_Loader();
            Load_Search_Result.DB_Populate(SearchColumn_SearchString, Sag_Dataset, "Sag");
            Sag_dataGridView.DataSource = Sag_Dataset;
            Sag_dataGridView.DataMember = "Sag";
 
        }




        // MAIN - Search Method
        private void Search_Resources()
        {
            LoadSag(); // Used for refreshing the datagridview Because of the Sag_Tlf Table appears first again
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
                LoadSag();
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
            LoadSag(); // Show All
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
            if (this.Sag_dataGridView.RowsDefaultCellStyle.BackColor == Color.FromArgb(64, 64, 64))
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
             if(Sag_dataGridView.CurrentRow != null)
             {

          
                if(Sag_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor != Color.FromArgb(191, 50, 95))
                {
                Sag_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.FromArgb(191, 50, 95);
                Sag_dataGridView.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    Sag_dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = Color.FromArgb(2, 222, 160);
                    Sag_dataGridView.SelectedRows[0].DefaultCellStyle.ForeColor = DefaultForeColor;
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
               PdfPTable Pdf_DGV = new PdfPTable(Sag_dataGridView.Columns.Count);
               Pdf_DGV.DefaultCell.Padding = 3;
               Pdf_DGV.WidthPercentage = 100;
               Pdf_DGV.HorizontalAlignment = Element.ALIGN_LEFT;
               Pdf_DGV.DefaultCell.BorderWidth = 1;
             
             
               // Adding the Columns with their txt to the PDF 
               foreach(DataGridViewColumn column in Sag_dataGridView.Columns)
               {
                   PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                   cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255); // White Color
                   Pdf_DGV.AddCell(cell);
               }
             
             
               //Add Rows and Cells to the Pdf

              for (int i = 0; i < Sag_dataGridView.Rows.Count; i++)
              {
                  for (int a = 0; a < Sag_dataGridView.Rows[i].Cells.Count; a++)
                  {
                      if (Sag_dataGridView.Rows[i].Cells[a].Value != null)
                      {
             
                          Pdf_DGV.AddCell(Sag_dataGridView.Rows[i].Cells[a].Value.ToString());
             
                      }
             
             
                  }
              }



              // Export to PDF

            if(!Directory.Exists(LocalFolderPath))
            {
                Directory.CreateDirectory(LocalFolderPath);
            }

            using(FileStream stream = new FileStream(LocalFolderPath + "Sag_PDF -  "+DateTime.Now.ToString("dd-MM-yyyy   HH-mm-ss")+".pdf", FileMode.Create))
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


            int oldHeight = Sag_dataGridView.Height;
            Sag_dataGridView.Height = Sag_dataGridView.RowCount * Sag_dataGridView.RowTemplate.Height;




            // Bitmap
            Bitmap bitmapScreenshot = new Bitmap(this.Sag_dataGridView.Width, this.Sag_dataGridView.Height);

            // Draw to the bitmap
            Sag_dataGridView.DrawToBitmap(bitmapScreenshot, new System.Drawing.Rectangle(0, 0, this.Sag_dataGridView.Width, this.Sag_dataGridView.Height));

            // Reset the height
            Sag_dataGridView.Height = oldHeight;

            // Save bitmap
            bitmapScreenshot.Save(LocalFolderPath + "Sag_Snapshot  " + DateTime.Now.ToString("dd-MM-yyyy  HH-mm-ss") + ".png");
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
        private void Sag_name_textBox_TextChanged(object sender, EventArgs e)
        {
            opret_sag_Type_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }





        // Surname - Reset Color
        private void Sag_surname_textBox_TextChanged(object sender, EventArgs e)
        {
            opret_sag_advokatID_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }




  

        // Adress - Reset Background
        private void Sag_adr_textBox_TextChanged(object sender, EventArgs e)
        {
            opret_sag_Kunde_ID_textBox.BackColor = Color.FromArgb(220, 243, 250);
        }



 
 

        // ERROR - Handling - Default Datagridview Error handling
        private void Sag_dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Sag_dataGridView.RefreshEdit(); // Reset
            MessageBox.Show("Der Opståd Fejl, Input er ikke i korekt format","Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }





        //-------------CREATE-TEXTBOXES -- Reset Color on Typing-------------------::END:--------------------------------------------------





        // Copy Selected Column
        private void copy_selected_column_button_Click(object sender, EventArgs e)
        {
           Clipboard.SetText(Sag_dataGridView.SelectedRows[0].Cells[Sag_dataGridView.CurrentCell.ColumnIndex].Value.ToString());
        }



































        //--------------------ADD Ydelse - "Tilføj Ydelse"-----::START::---------------------------------------------------------------



        // Load Ydelser  - ComboBox
        private void ydelse_navn_comboBox_Click(object sender, EventArgs e)
        {
            ydelse_navn_comboBox.Items.Clear();
            Load_Combobox Load_Ydelser = new Load_Combobox();
            ydelse_navn_comboBox = Load_Ydelser.Populate_Combobox("Select Ydelse_Navn From Ydelse", ydelse_navn_comboBox);
        }




        // On Selected Ydelse Name Get Ydelse ID
        private void ydelse_navn_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            add_Ydelse_Ydelse_Nr_textBox.Clear(); // Clear
            Load_Combobox Load_Ydelse_Nr = new Load_Combobox();
            add_Ydelse_Ydelse_Nr_textBox = Load_Ydelse_Nr.PopulateTextbox($"Select Ydelse_Nr From Ydelse Where Ydelse_Navn Like '{ydelse_navn_comboBox.SelectedItem.ToString()}' ", add_Ydelse_Ydelse_Nr_textBox); // Load NR Ydelse NR "ID"
        }





        // Clear Input
        private void CLEAR_sag_Ydelse_button_Click(object sender, EventArgs e)
        {
            Clear_All_TextBoxes();
        }







         // Clear All Textboxes
         private void Clear_All_TextBoxes()
        {
            add_Ydelse_Sag_SagID_textBox.Clear();
            ydelse_navn_comboBox.Items.Clear();
            add_Ydelse_Ydelse_Nr_textBox.Clear();
        }







        //----:::SAVE::---------------------------------------------------------------------
        // Save Add Ydelse - Button
        private void add_sag_Ydelse_button_Click(object sender, EventArgs e)
        {
            bool successful;

            ResetColor_TextBoxes();
            Validate_Add_Ydelse();
              

            if(Add_Ydelse_Validate == true)
            {
                DB_Connection_Write Add_SAg_Ydelse = new DB_Connection_Write();
                successful =  Add_SAg_Ydelse.CreateCommand($"Insert Into Sag_Ydelser Values('{DateTime.Now.ToString("dd-MM-yyyy   HH-mm-ss")}','{add_Ydelse_Sag_SagID_textBox.Text}','{add_Ydelse_Ydelse_Nr_textBox.Text}');");
                
                if(successful == true)
                {
                
                    Clear_All_TextBoxes(); // Clear
                
                }
            }

        }









        // Validate TextBoxes
        private void Validate_Add_Ydelse()
        {
            Add_Ydelse_Validate = true;

            if (add_Ydelse_Sag_SagID_textBox.Text.Length < 15)
            {
                Add_Ydelse_Validate = false;
                add_Ydelse_Sag_SagID_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }   
            
            if (ydelse_navn_comboBox.SelectedIndex == -1)
            {
                Add_Ydelse_Validate = false;
               
            }

            if (add_Ydelse_Ydelse_Nr_textBox.Text.Length < 1)
            {
                Add_Ydelse_Validate = false;
                add_Ydelse_Ydelse_Nr_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }
           

         }









        // Reset Color -Textboxes
        private void ResetColor_TextBoxes()
        {
            add_Ydelse_Sag_SagID_textBox.BackColor = DefaultBackColor;
            add_Ydelse_Ydelse_Nr_textBox.BackColor = DefaultBackColor;

        }






        // Sag ID - Reset Color
        private void add_Ydelse_Sag_SagID_textBox_TextChanged(object sender, EventArgs e)
        {
            add_Ydelse_Sag_SagID_textBox.BackColor = DefaultBackColor;

        }



        // Ydelse NR - Reset Color
        private void add_Ydelse_Ydelse_Nr_textBox_TextChanged(object sender, EventArgs e)
        {
            add_Ydelse_Ydelse_Nr_textBox.BackColor = DefaultBackColor;

        }


        // Ydelse NR - Reset Color
        private void ydelse_navn_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            add_Ydelse_Ydelse_Nr_textBox.BackColor = DefaultBackColor;

        }


        // Load Advokat Names 
        private void add_sag_Advokat_name_comboBox_Click(object sender, EventArgs e)
        {
            add_sag_Advokat_name_comboBox.Items.Clear();
            Load_Combobox Load_Advokat_names = new Load_Combobox();
            add_sag_Advokat_name_comboBox = Load_Advokat_names.Populate_Combobox("Select M.Me_Fornavn From Medarbejder AS M Where M.Me_Type = 'Advokat'; ", add_sag_Advokat_name_comboBox);
        }



        // Get Advokate ID
        private void add_sag_Advokat_name_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            opret_sag_advokatID_textBox.Clear();

            Load_Combobox Get_Advokat_ID = new Load_Combobox();
            opret_sag_advokatID_textBox = Get_Advokat_ID.PopulateTextbox($"Select M.Me_ID From Medarbejder As M Where M.Me_Fornavn = '{add_sag_Advokat_name_comboBox.SelectedItem.ToString()}'", opret_sag_advokatID_textBox);
        }



        //--------------------ADD Ydelse - "Tilføj Ydelse"-----::END::---------------------------------------------------------------
































        // Update SAG ----"Afslut SAG"-------------::START::-------------------------------------------------------------------------------------------------



        // Save Button
        private void SAVE_Update_sag_button_Click(object sender, EventArgs e)
        {
            Update_Sag();
        }




        private void Update_Sag()
        {
            bool successful;

            if(Sag_ID_textBox.Text.Length > 15)
            {


            DB_Connection_Write Update_Sag = new DB_Connection_Write();
            successful = Update_Sag.CreateCommand($"Update Sag Set Sag.Sag_Afslutet = 1, Sag.Sag_Slut_Dato ='{Update_SAG_Slut_Dato_dateTimePicker.Value.Date.ToShortDateString()}' Where Sag.Sag_ID = '{Sag_ID_textBox.Text}'; IF @@RowCount = 0 BEGIN Select 1/0; END");


                if(successful == true)
                {
                    Clear_Input_Update_sag();
                }
            }
            else
            {
                Sag_ID_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }

        }


         // Clear Input - Textboxes
        private void Clear_sag_update_button_Click(object sender, EventArgs e)
        {
            Clear_Input_Update_sag();

        }


        private void Clear_Input_Update_sag()
        {
            Sag_ID_textBox.Clear();
            Update_SAG_Slut_Dato_dateTimePicker.Value = DateTime.Now;
        }







        // Reset Color SAg ID Textbox
        private void Sag_ID_textBox_TextChanged(object sender, EventArgs e)
        {
            Sag_ID_textBox.BackColor = DefaultBackColor;
        }









        // Update Sag - Aflsut Sag
        private void afslut_sag_button_Click(object sender, EventArgs e)
        {
            HideAll_Menu_Windows();
            update_sag_Back_panel.Visible = true;
        }


        // Update SAG ----"Afslut SAG"-------------::START::-------------------------------------------------------------------------------------------------




























        //------------ADD Time--"Tilføj Tid"-----::START::------------------------------------------------------------

    

        //Add Time - "Tilføj Tid" - Button
        private void add_time_button_Click(object sender, EventArgs e)
        {

            HideAll_Menu_Windows();
            add_time_back_panel.Visible = true;
        }








        // Save Time Button
        private void add_time_save_button_Click(object sender, EventArgs e)
        {
            Save_Time();
        }






        private void Valudate_Time()
        {
            Add_time_validate = true;

            // Time - Validate
            if(add_time_sag_textBox.Text.Length < 1)
            {
                Add_time_validate = false;
                add_time_sag_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }

            // Advokat ID - Validate
            if(add_time_Advokat_name_textBox.Text.Length <15)
            {
                Add_time_validate = false;
                add_time_Advokat_name_textBox.BackColor = Color.FromArgb(255, 192, 192);

            }



            // Sag ID
            if(add_time_sag_id_textBox.Text.Length < 15)
            {
                Add_time_validate = false;
                add_time_sag_id_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }


            // Ydelse NR
            if(add_time_ydelse_nr_textBox.Text.Length < 15)
            {
                Add_time_validate = false;
                add_time_ydelse_nr_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }

        }




       


        // Save TIME - Main Method
        private void Save_Time()
        {
            Valudate_Time();

            if(Add_time_validate == true)
            {
                DB_Connection_Write Add_time_toSag = new DB_Connection_Write();
                bool succesfull_Added = Add_time_toSag.CreateCommand($"DECLARE @UniqueID Uniqueidentifier SET @UniqueID = NewID();  Insert Into TID Values('{add_time_sag_textBox.Text}','{Add_Time_sag_dateTimePicker.Value.ToShortDateString()}', (@UniqueID), '{add_time_sag_id_textBox.Text}', '{add_time_ydelse_nr_textBox.Text}', '{add_time_Advokat_name_textBox.Text}'); ");

                if(succesfull_Added == true)
                {
                    Clear_All_Inputs_Add_Time();
                }

            }

        }




        // TIME - Textbox - Validation
        private void add_time_sag_textBox_KeyPress(object sender, KeyPressEventArgs e)
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
            for (int i = 0; i < add_time_sag_textBox.Text.Length; i++)
            {
                int commaIndex = 0;

                if(add_time_sag_textBox.Text[i] == '.')
                {
                    commaIndex = i;
                    have_comma = true;


                    // Prevent Numbers from 5 and up 
                    if( e.KeyChar > (char)53)
                    {
                        e.Handled = true;

                    }

                    // Max 2 digits after Comma
                    if(add_time_sag_textBox.Text.Length > commaIndex +2 && e.KeyChar != (char)8)
                    {
                        e.Handled = true;
                    }

                }

         
            }

            if (e.KeyChar == (char)46 && have_comma == false && add_time_sag_textBox.Text != "")//If Comma and ther is no comma in the textbox than Add it
            {
                e.Handled = false;
            }


        }








        //Reset Color - Time
        private void add_time_sag_textBox_TextChanged(object sender, EventArgs e)
        {
            add_time_sag_textBox.BackColor = DefaultBackColor;
        }







        // Advokat Reset Color
        private void add_time_Advokat_name_textBox_TextChanged(object sender, EventArgs e)
        {
            add_time_Advokat_name_textBox.BackColor = DefaultBackColor;
        }







        // Sag Reset Color
        private void add_time_sag_id_textBox_TextChanged(object sender, EventArgs e)
        {
            add_time_sag_id_textBox.BackColor = DefaultBackColor;
        }



        // Ydelse NR - Reset Color
        private void add_time_ydelse_nr_textBox_TextChanged(object sender, EventArgs e)
        {
            add_time_ydelse_nr_textBox.BackColor = DefaultBackColor;

        }



        // Clear All Inputs - Add - Time
        private void add_time_Clear_All_textboxes_button_Click(object sender, EventArgs e)
        {
            Clear_All_Inputs_Add_Time();
        }


        // CLear All Inputs
        private void Clear_All_Inputs_Add_Time()
        {
            Add_Time_sag_dateTimePicker.Value = DateTime.Now.Date;
            add_time_sag_textBox.Clear();
            add_time_Advokat_name_textBox.Clear();
            add_time_sag_id_textBox.Clear();
            add_time_Advokat_name_comboBox.SelectedIndex = -1;
            add_time_ydelse_name_comboBox.SelectedIndex = -1;
            add_time_ydelse_nr_textBox.Clear();
            Reset_Input_Color();
        }


         // Reset Color of the whole Input
        private void Reset_Input_Color()
        {
            add_time_ydelse_nr_textBox.BackColor = DefaultBackColor;
            add_time_sag_id_textBox.BackColor = DefaultBackColor;
            add_time_Advokat_name_textBox.BackColor = DefaultBackColor;
            add_time_sag_textBox.BackColor = DefaultBackColor;
        }



        // Advokat Name Loader - Combobox
        private void add_time_Advokat_name_comboBox_Click(object sender, EventArgs e)
        {
            add_time_Advokat_name_comboBox.Items.Clear();
            Load_Combobox Load_Advokat_names = new Load_Combobox();
            add_time_Advokat_name_comboBox = Load_Advokat_names.Populate_Combobox("Select M.Me_Fornavn From Medarbejder AS M Where M.Me_Type = 'Advokat'; ", add_time_Advokat_name_comboBox);
        }



 



         // Get ID Form Advokate name Combobox
        private void add_time_Advokat_name_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

            add_time_Advokat_name_textBox.Clear();

            Load_Combobox Get_Advokat_ID = new Load_Combobox();
            add_time_Advokat_name_textBox = Get_Advokat_ID.PopulateTextbox($"Select M.Me_ID From Medarbejder As M Where M.Me_Fornavn = '{add_time_Advokat_name_comboBox.SelectedItem.ToString()}'", add_time_Advokat_name_textBox);
        }





        // Add - Time - Ydelse Load Names
        private void add_time_ydelse_name_comboBox_Click(object sender, EventArgs e)
        {
            add_time_ydelse_name_comboBox.Items.Clear();
            Load_Combobox Load_Ydelser = new Load_Combobox();
            add_time_ydelse_name_comboBox = Load_Ydelser.Populate_Combobox("Select Ydelse_Navn From Ydelse", add_time_ydelse_name_comboBox);
        }




        // Add - Time - Load  - Ydelser  - Names
        private void add_time_ydelse_name_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            add_Ydelse_Ydelse_Nr_textBox.Clear(); // Clear
            Load_Combobox Load_Ydelse_Nr = new Load_Combobox();
            add_time_ydelse_nr_textBox = Load_Ydelse_Nr.PopulateTextbox($"Select Ydelse_Nr From Ydelse Where Ydelse_Navn Like '{add_time_ydelse_name_comboBox.SelectedItem.ToString()}' ", add_time_ydelse_nr_textBox); // Load NR Ydelse NR "ID"
        }


        //------------ADD Time--"Tilføj Tid"-----::START::------------------------------------------------------------












        //--------------------ADD--Kørsel-----::START::---------------------------------------------------------------

        // ADD Kørsel - BUTTON
        private void Add_Koersel_Sag_button_Click(object sender, EventArgs e)
        {
            HideAll_Menu_Windows();
            Register_Koersel_Back_Panel_panel.Visible = true;
        }


        // Kørsel - Advokat name Loader - Combobox
        private void koersel_Advokat_name_comboBox_Click(object sender, EventArgs e)
        {
            koersel_Advokat_name_comboBox.Items.Clear();
            Load_Combobox Load_Advokat_names = new Load_Combobox();
            koersel_Advokat_name_comboBox = Load_Advokat_names.Populate_Combobox("Select M.Me_Fornavn From Medarbejder AS M Where M.Me_Type = 'Advokat'; ", koersel_Advokat_name_comboBox);
        }



        // Load Advokat ID in the Textbox
        private void koersel_Advokat_name_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

            koersel_Advokat_Id_textBox.Clear();
            Load_Combobox Get_Advokat_ID = new Load_Combobox();
            koersel_Advokat_Id_textBox = Get_Advokat_ID.PopulateTextbox($"Select M.Me_ID From Medarbejder As M Where M.Me_Fornavn = '{koersel_Advokat_name_comboBox.SelectedItem.ToString()}'", koersel_Advokat_Id_textBox);
        }




        // Kørsel tid - Reset Color
        private void koersel_koersel_Tid_textBox_TextChanged(object sender, EventArgs e)
        {
            koersel_koersel_Tid_textBox.BackColor = DefaultBackColor;
        }





        // Validate Kørsel Tid 
        private void koersel_koersel_Tid_textBox_KeyPress(object sender, KeyPressEventArgs e)
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
            for (int i = 0; i < koersel_koersel_Tid_textBox.Text.Length; i++)
            {
                int commaIndex = 0;

                if (koersel_koersel_Tid_textBox.Text[i] == '.')
                {
                    commaIndex = i;
                    have_comma = true;


                    // Prevent numbers fron 5 and up 
                    if (e.KeyChar > (char)53)
                    {
                        e.Handled = true;

                    }



                    // Max 2 digits after Comma
                    if (koersel_koersel_Tid_textBox.Text.Length > commaIndex + 2 && e.KeyChar != (char)8)
                    {
                        e.Handled = true;
                    }

                }


            }

            if (e.KeyChar == (char)46 && have_comma == false && koersel_koersel_Tid_textBox.Text != "")//If Comma and ther is no comma in the textbox than Add it
            {
                e.Handled = false;
            }


        }







        // Save Method - Kørsel - Tid
        private void Save_Koersel_Tid()
        {
            Validate_Koersel_Tid_Input();

            if (Validate_Koersel_TId == true)
            {
                DB_Connection_Write Add_Driving_Time = new DB_Connection_Write();
                 bool successful = Add_Driving_Time.CreateCommand($" Declare @UniqueID uniqueidentifier SET @UniqueID = NewID(); Insert Into Kørsel Values('{koersel_koersel_Tid_textBox.Text}', '{koersel_date_dateTimePicker.Value.ToShortDateString()}', '{koersel_noter_textBox.Text}', (@UniqueID), '{koersel_Sag_ID_textBox.Text}', '{koersel_Advokat_Id_textBox.Text}');");

                if(successful == true)
                {
                    Clear_All_Input_Koersel();
                }

            }

             
        }





        // Save Button Kørsel- TID
        private void koersel_Save_button_Click(object sender, EventArgs e)
        {
            Save_Koersel_Tid();
        }






        private void Validate_Koersel_Tid_Input()
        {
            Validate_Koersel_TId = true;



            // Validate Advokat ID
            if(koersel_Advokat_Id_textBox.Text.Length < 15)
            {
                Validate_Koersel_TId = false;
                koersel_Advokat_Id_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }




            // Validate SAG
            if(koersel_Sag_ID_textBox.Text.Length < 15)
            {
                Validate_Koersel_TId = false;
                koersel_Sag_ID_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }



            // Kørsel TID - Validate
            if(koersel_koersel_Tid_textBox.Text.Length < 1)
            {
                Validate_Koersel_TId = false;
                koersel_koersel_Tid_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }

        

       

        }


        private void Koersel_Reset_Input_Color()
        {
            koersel_Advokat_Id_textBox.BackColor = DefaultBackColor;
            koersel_Sag_ID_textBox.BackColor = DefaultBackColor;
            koersel_koersel_Tid_textBox.BackColor = DefaultBackColor;

        }


         // Clear All Inputs for Kørsel
        private void Clear_All_Input_Koersel()
        {
            Koersel_Reset_Input_Color();
            koersel_Advokat_name_comboBox.SelectedIndex = -1;
            koersel_Advokat_Id_textBox.Clear();
            koersel_Sag_ID_textBox.Clear();
            koersel_koersel_Tid_textBox.Clear();
            koersel_date_dateTimePicker.Value = DateTime.Now;
            koersel_noter_textBox.Clear();
        }


        private void koersel_Clear_all_button_Click(object sender, EventArgs e)
        {
            Clear_All_Input_Koersel();  
        }

      

        //-------------------ADD---Kørsel ---------::END::---------------------------------------------------------------








    }
}
