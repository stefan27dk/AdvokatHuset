using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace View_GUI
{
    public partial class Log_In_Form0 : Form
    {
        // Log_In_info - Directory
        Local_Settings log_info_dir = new Local_Settings();



        // Log In Info
        Log_In_Info log_In_info = Log_In_Info.Get_Log_In_Info();


       // Forms
       Main_Form1 Main_Form = new Main_Form1();




        // Log In Validate
        bool Log_In_Is_Valid = false;

        // Input Vlidate
        bool Input_Is_Valid = true;







        //Initialize

        public Log_In_Form0()
        {
            InitializeComponent();
        }


       






        // Load
        private void Log_In_Form0_Load(object sender, EventArgs e)
        {
            Load_Sql_Connection(); // Load Connectionstring from file
            Load_Log_In(); // Load Log In // Remember Me
 
        }







        // Log In Main Method
        private void Log_In()
        {
            Validate_Input(); // VALIDATE INPUT

            if(Input_Is_Valid == true)
            {
                Validate_Log_In Check_Log_IN = new Validate_Log_In();
                Log_In_Is_Valid =  Check_Log_IN.Log_In_Check(log_name_textBox, log_pass_textBox);


                 // If Remember Me Check Box is Checked
                 if(remember_log_in_checkBox.Checked == true && Log_In_Is_Valid == true)
                 {
                    Remember_Log_In();
                 }




                 if(Log_In_Is_Valid == true)
                 {
                    Log_In_Sound();
                 }
               
            }

           
            if (Log_In_Is_Valid == false || Input_Is_Valid == false)
            {
                Error_Sound();
            }



        }





         //----XML------Login---File--------------::START---------------------------------------------------------------------------------------------

        // Save Log in To XML
        private void Remember_Log_In()
        {


            //MessageBox.Show($"{log_In_info.Log_User_Name}: {log_In_info.Log_Password}","", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using (XmlTextWriter save_log_in = new XmlTextWriter($"{log_info_dir.LocalFolder}Log_In.xml", null))
            {

                   save_log_in.WriteStartDocument();
              
                     // Log In
                    save_log_in.WriteStartElement("Log_In");

                     

                    // Name
                    save_log_in.WriteStartElement("log_in_name");
                    save_log_in.WriteAttributeString("name", $"{log_In_info.Log_User_Name}");
                    save_log_in.WriteEndElement();
                   
                   
                    // Password
                    save_log_in.WriteStartElement("log_in_password");
                    save_log_in.WriteAttributeString("password", $"{log_In_info.Log_Password}");
                    save_log_in.WriteEndElement();
                   
                   
                   
                    //Checkbox - Remember Password
                    save_log_in.WriteStartElement("remember");
                    save_log_in.WriteAttributeString("remember_value", remember_log_in_checkBox.Checked.ToString());
                    save_log_in.WriteEndElement();

                    
                    save_log_in.WriteEndDocument();
                    save_log_in.Close();
            }


        }






        // Load Log in From XML
        private void Load_Log_In()
        {
            if(File.Exists($@"{log_info_dir.LocalFolder}Log_In.xml"))// If Log_Info_xml file exists
            {



                using (XmlReader reader = XmlReader.Create($@"{log_info_dir.LocalFolder}Log_In.xml"))
                {

                     
                    while (reader.Read())
                    {
                       

                        //Remember
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "remember"))
                        {

                            if (reader.HasAttributes)
                            {

                                if (reader.GetAttribute("remember_value").ToString() == "True")
                                {
                                    remember_log_in_checkBox.Checked = true;
                                }
                                else
                                {
                                    break; // If the checkbos was not set tot remember dont load the username and pass 
                                }


                            }

                        }


                     




                        // Get UserName
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "log_in_name"))
                        {
                            if (reader.HasAttributes)
                            {
                                log_name_textBox.Text = reader.GetAttribute("name");
                            }
                        }








                        // Get Password
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "log_in_password"))
                        {

                            if (reader.HasAttributes)
                            {
                                log_pass_textBox.Text = reader.GetAttribute("password");
                            }

                        }










                    }
             
                }
            }

        }







        // Delete login File - Button
        private void delete_login_file_button_Click(object sender, EventArgs e)
        {
            Delete_Log_In_File();
        }


        // Delete Login File Main - Method
        private void Delete_Log_In_File()
        {



            DialogResult delete_login = MessageBox.Show("Er du sikker på at du vil SLETTE den Husket Login?!?!","Slet Husket Log In", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (File.Exists($@"{log_info_dir.LocalFolder}Log_In.xml") && delete_login == DialogResult.Yes)// If Log_Info_xml file exists
            {
                File.Delete($@"{log_info_dir.LocalFolder}Log_In.xml");
                Clear_All_Input();
            }


        }

        //----XML-----------Login---File------------::END------------------------------------------------------------------------------------------------







        // Validate Input
        private void Validate_Input()
         {
            Input_Is_Valid = true;

            if (log_name_textBox.Text.Length < 1)
            {
                Input_Is_Valid = false;
                log_name_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }


            if(log_pass_textBox.Text.Length < 1)
            {
                Input_Is_Valid = false;
                log_pass_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }


         }


        
        


         // Error Sound
        private void Error_Sound()
        {
            wrong_log_in_label.Visible = true;
            System.Media.SoundPlayer log_in_sound = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Balloon.wav");
            log_in_sound.Play();
        }



        // Log In Sound
        private void Log_In_Sound()
        {
            // Play Log In Sound
            System.Media.SoundPlayer log_in_sound = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Battery Critical.wav");
            log_in_sound.Play();
        }


        // Log In Button
        private void log_in_button_Click(object sender, EventArgs e)
        {
            Log_In();
            Show_Main_Form();
        }



          

        // Reset Color Name
        private void log_name_textBox_TextChanged(object sender, EventArgs e)
        {
            log_name_textBox.BackColor = DefaultBackColor;
            remember_log_in_checkBox.Checked = false;

        }




        // Reset Color Password
        private void log_pass_textBox_TextChanged(object sender, EventArgs e)
        {
            log_pass_textBox.BackColor = DefaultBackColor;
            remember_log_in_checkBox.Checked = false;


        }









        //------LOAD - MAIN FORM---IF LOG--IN--IS---Valid-------------::Start::----------------------------------------
        private void Show_Main_Form()
        {

            if (Log_In_Is_Valid == true)   // If Log IN is Valid
            {
                Load_Main_Form();
            }

            else
            {
                log_name_textBox.BackColor = Color.FromArgb(255, 192, 192);
                log_pass_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }

        }


       // Load Main Form Code
       private void Load_Main_Form()
        {
            Main_Form.TopLevel = false;
            this.Parent.Controls.Add(Main_Form);  // Get the Loader Panel of the Main Form Body
            Main_Form.FormBorderStyle = FormBorderStyle.None;
            Main_Form.Dock = DockStyle.Fill;
            Main_Form.Show();
            this.Dispose(); // Dispose Log In Form
        }

        //------LOAD - MAIN FORM---IF LOG--IN--IS---Valid-------------::END::----------------------------------------
















        //Shortcut keys -----KEY WATCHER- ----SHORTCUT KEYS----------------::START::------------------------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            // Open Item Menu Shortcut
            if (keyData == (Keys.Control | Keys.Shift | Keys.X))
            {
                Load_Main_Form(); // Log In As Developer
                Log_In_Sound();
            }

            
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //Shortcut keys -----KEY WATCHER- ----SHORTCUT KEYS----------------::END::------------------------------------------------------------------------------------











        // Clear All - Input - Main
        private void Clear_All_Input()
         {
            // Clear
            log_name_textBox.Clear();
            log_pass_textBox.Clear();


            // Reset Color
            log_name_textBox.BackColor = DefaultBackColor;
            log_pass_textBox.BackColor = DefaultBackColor;


            remember_log_in_checkBox.Checked = false;


            

         }



        // Clear All Input Log In - Button
        private void log_in_Clear_all_button_Click(object sender, EventArgs e)
        {
            Clear_All_Input();
        }



















        //-----------------Connection String--------::START::--------------------------------------------------------------------




        //Setting button
        private void settings_button_Click(object sender, EventArgs e)
        {
             //Show Hide
            if(settings_myPanel.Visible == false)
            {
                settings_myPanel.Visible = true;
            }
            else
            {
                settings_myPanel.Visible = false;

            }

        }







        // Save Conn - String - BUTTON
        private void conn_string__Save_button_Click(object sender, EventArgs e)
        {
            Connection_String_To_File();
        }








        // Save Connectionstring to the log_in_info XML File 
        private void Connection_String_To_File()
        {
            using (XmlTextWriter save_Connection_string = new XmlTextWriter($"{log_info_dir.LocalFolder}Connection_string.xml", null))
            {

                save_Connection_string.WriteStartDocument();
                // Conn String
                save_Connection_string.WriteStartElement("Connection_String");
                save_Connection_string.WriteAttributeString("connecrion_string_data", conn_string_textBox.Text);
                save_Connection_string.WriteEndElement();
                save_Connection_string.WriteEndDocument();
                save_Connection_string.Close();
            }

        }












        // Load Sql Connection From File
        private void Load_Sql_Connection()
        {
            if (File.Exists($@"{log_info_dir.LocalFolder}Connection_string.xml"))// If Log_Info_xml file exists
            {

                using (XmlReader reader = XmlReader.Create($@"{log_info_dir.LocalFolder}Connection_string.xml"))
                {
                    while (reader.Read())
                    {
                        // Connection String
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Connection_String"))
                        {

                            if (reader.HasAttributes)
                            {
                                DB_Connection_String ConnectionString_instance = DB_Connection_String.Get_Connection_String_Instance();

                                ConnectionString_instance.DBConnectionString = reader.GetAttribute("connecrion_string_data").ToString();
                                conn_string_textBox.Text = reader.GetAttribute("connecrion_string_data").ToString();

                            }

                        }


                    }

                }
            }

        }





        //-----------------Connection String--------::END::--------------------------------------------------------------------

























        // Secret Button----------------::Start::-----------------------------------------------------------


        // Secret Developer Mode - Hover - Button
        private void secret_developer_mode_button_MouseEnter(object sender, EventArgs e)
        {

            secret_developer_mode_button.BackgroundImage = Properties.Resources.Apps_utilities_terminal_icon;
            secret_developer_mode_button.BackgroundImageLayout = ImageLayout.Stretch;
        }






        // Developer Mode Secret Button - Leave - Hide Image
        private void secret_developer_mode_button_MouseLeave(object sender, EventArgs e)
        {
            secret_developer_mode_button.BackgroundImage = null;

        }



        // Open Developer Mode
        private void secret_developer_mode_button_Click(object sender, EventArgs e)
        {
            DeveloperForm_Form12 DeveloperForm = new DeveloperForm_Form12();
            DeveloperForm.TopLevel = false;
            DeveloperForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.Controls.Add(DeveloperForm);
            DeveloperForm.Show();
            DeveloperForm.BringToFront();

        }

      
        //-Secret Button-------------------::END::-----------------------------------------------------

    }
}
