using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace View_GUI
{
    public partial class Kunder_Form9 : Form
    {
       
        Kunde kundeinstance; // Instance af Kunde 
        DB_Connection_Write ConnWrite; // Sql Write "
        DB_Connection_String ConnectionString; // Global Connectionstring
        bool isValid = true;
        bool successful = false; // Successful Transaction


        public Kunder_Form9()
        {
            InitializeComponent();
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



        // Insert to DB
        private void InsertToDB()
        {
            ConnectionString = new DB_Connection_String(); // Global ConnectionString
            ConnWrite = new DB_Connection_Write(); // "Write to DB Class instance"
            string KundeQuery = $"DECLARE @UNIQUEX UNIQUEIDENTIFIER SET @UNIQUEX = NEWID(); Insert into Kunde Values('{kundeinstance.Fornavn}','{kundeinstance.Efternavn}',{kundeinstance.PostNr},'{kundeinstance.Adresse}', (@UNIQUEX),'{kundeinstance.Mail}', '{DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss")}');"; // Query
            successful = ConnWrite.CreateCommand(KundeQuery, ConnectionString.DBConnectionString); // Write to DB Input and "Execution"
        }




        // Key Events------::START::----------------------------------------------------------------------

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

            //Name Validation----------------------------------------------------------------------------
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




            // Surname Validation------------------------------------------------------------------------ 
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



             // TLF Validation---------------------------------------------------------------------------

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



             // Email Validation-------------------------------------------------------------------------
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



              //Zip Code Valiadtion----------------------------------------------------------------------
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
            



            // Adress Validation------------------------------------------------------------------------
            if(kunder_adr_textBox.TextLength < 2)
            {
                isValid = false;
                kunder_adr_textBox.BackColor = Color.FromArgb(255, 128, 128);
            }
            
           
        }





        // Reset Textboc Color
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

        private void Kunder_Form9_Load(object sender, EventArgs e)
        {
            // Datagridview Fore Color
            this.Kunde_dataGridView.DefaultCellStyle.ForeColor = Color.Blue;
            // TODO: This line of code loads data into the 'advokathusetDataSet.Kunde' table. You can move, or remove it, as needed.
            this.kundeTableAdapter.Fill(this.advokathusetDataSet.Kunde);


        }
    }
}
