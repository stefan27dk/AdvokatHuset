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
using System.Diagnostics;
using System.Data.SqlClient;

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
                Domain_Log_In_Check Check_Log_IN = new Domain_Log_In_Check();
                Log_In_Is_Valid =  Check_Log_IN.Log_In_Check(log_name_textBox.Text, log_pass_textBox.Text);


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


                 
                 // Show Message Labels - Error SQL Connection
                if (Check_Sql_server_Connection() == false)
                {
                    sql_connection_error_label.Visible = true;
                    conn_string_tip_label.Visible = true;

                }


            }

          

        }








        // Check SQL Connection
        private bool Check_Sql_server_Connection()
        {
            Check_SQL_Connection check_connection = new Check_SQL_Connection();
            return check_connection.Check_My_SQL_Connection();
         
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
            Show_Settings();
        }




        // SHow log  In Settings - Main Method
         private void Show_Settings()
        {
            //Show Hide
            if (settings_myPanel.Visible == false)
            {
                settings_myPanel.Visible = true;
            }
            else
            {
                settings_myPanel.Visible = false;
                sql_script_textBox.Visible = false;
            }
        }




        // Save Conn - String - BUTTON
        private void conn_string__Save_button_Click(object sender, EventArgs e)
        {
            Connection_String_To_File();
             
            Application.Restart();
            Environment.Exit(0);
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
                                Domain_Connection_String ConnString = new Domain_Connection_String();
                                ConnString.SET_DAL_Connectionstring(reader.GetAttribute("connecrion_string_data").ToString());
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







        // Load Log In - Button
        private void load_log_in_button_Click(object sender, EventArgs e)
        {
            Load_Log_In();
        }






        // Show Sql Script Textbox
        private void SQL_Script_button_Click(object sender, EventArgs e)
        {
            Load_SQL_script(); // Load Script

            if(sql_script_textBox.Visible == false)
            {
                sql_script_textBox.Visible = true;
            }
            else
            {
                sql_script_textBox.Visible = false;

            }
        }








        // Load - Sql Script to textbox
        private void Load_SQL_script()
        {
            sql_script_textBox.Text = "----This is Empty---Database - Advokathuset" + Environment.NewLine + 
"" + Environment.NewLine +
"USE [master]" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Database [Advokathuset]    Script Date: 26-05-2020 23:30:49 ******/" + Environment.NewLine +
"CREATE DATABASE [Advokathuset]" + Environment.NewLine +
" " + Environment.NewLine +
"GO" + Environment.NewLine +
"USE [Advokathuset]" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  User [abc]    Script Date: 26-05-2020 23:30:49 ******/" + Environment.NewLine +
"CREATE USER [abc] FOR LOGIN [abc] WITH DEFAULT_SCHEMA=[dbo]-----------------------LOG IN----------- Should be allowed in the SQL Managment Studio Settings in order to use!!!!!!!!!!!!!!" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Adv_Arbejds_Ydelser]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Adv_Arbejds_Ydelser](" + Environment.NewLine +
"\t[Ydelse_Nr] [int] NOT NULL," + Environment.NewLine +
"\t[Adv_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
" CONSTRAINT [PK_Adv_Arbejds_Ydelser] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Ydelse_Nr] ASC," + Environment.NewLine +
"\t[Adv_ID] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Advokat_Uddannelser]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Advokat_Uddannelser](" + Environment.NewLine +
"\t[Advokat_Uddanelse] [nvarchar](30) NOT NULL," + Environment.NewLine +
"\t[Me_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
" CONSTRAINT [PK_Advokat_Uddannelser_1] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Advokat_Uddanelse] ASC," + Environment.NewLine +
"\t[Me_ID] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Kørsel]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Kørsel](" + Environment.NewLine +
"\t[Kørsel_Tid] [decimal](18, 4) NOT NULL," + Environment.NewLine +
"\t[Kørsel_Dato] [nvarchar](50) NOT NULL," + Environment.NewLine +
"\t[Kørsel_Notering] [nvarchar](70) NULL," + Environment.NewLine +
"\t[Kørsel_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
"\t[Sag_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
"\t[Advokat_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
" CONSTRAINT [PK_Kørsel] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Kørsel_ID] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Kunde]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Kunde](" + Environment.NewLine +
"\t[Kunde_Fornavn] [nvarchar](50) NOT NULL," + Environment.NewLine +
"\t[Kunde_Efternavn] [nvarchar](50) NOT NULL," + Environment.NewLine +
"\t[Kunde_PostNr] [int] NOT NULL," + Environment.NewLine +
"\t[Kunde_Adresse] [nvarchar](50) NOT NULL," + Environment.NewLine +
"\t[Kunde_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
"\t[Kunde_Email] [nvarchar](50) NULL," + Environment.NewLine +
"\t[Kunde_Oprets_Dato] [nvarchar](25) NULL," + Environment.NewLine +
" CONSTRAINT [PK_Kunde_1] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Kunde_ID] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Kunde_Tlf]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Kunde_Tlf](" + Environment.NewLine +
"\t[Kunde_Tlf] [int] NOT NULL," + Environment.NewLine +
"\t[Kunde_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
" CONSTRAINT [PK_Kunde_Tlf] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Kunde_Tlf] ASC," + Environment.NewLine +
"\t[Kunde_ID] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Log_In]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Log_In](" + Environment.NewLine +
"\t[Me_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
"\t[Log_In_Navn] [nvarchar](20) NOT NULL," + Environment.NewLine +
"\t[Log_In_Pass] [nvarchar](20) NOT NULL," + Environment.NewLine +
" CONSTRAINT [IX_Log_In] UNIQUE NONCLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Log_In_Navn] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]," + Environment.NewLine +
" CONSTRAINT [IX_Log_In_1] UNIQUE NONCLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Me_ID] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Medarbejder]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Medarbejder](" + Environment.NewLine +
"\t[Me_Fornavn] [nvarchar](50) NOT NULL," + Environment.NewLine +
"\t[Me_Efternavn] [nvarchar](50) NOT NULL," + Environment.NewLine +
"\t[Me_PostNr] [int] NOT NULL," + Environment.NewLine +
"\t[Me_Adresse] [nvarchar](50) NOT NULL," + Environment.NewLine +
"\t[Me_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
"\t[Me_Type] [nvarchar](20) NOT NULL," + Environment.NewLine +
"\t[Me_Email] [nvarchar](50) NULL," + Environment.NewLine +
"\t[Me_Oprets_Dato] [nvarchar](25) NULL," + Environment.NewLine +
" CONSTRAINT [PK_Medarbejder_1] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Me_ID] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]," + Environment.NewLine +
" CONSTRAINT [IX_Medarbejder] UNIQUE NONCLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Me_Fornavn] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Medarbejder_Tlf]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Medarbejder_Tlf](" + Environment.NewLine +
"\t[Me_Tlf] [int] NOT NULL," + Environment.NewLine +
"\t[Me_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
" CONSTRAINT [PK_Medarbejder_Tlf] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Me_Tlf] ASC," + Environment.NewLine +
"\t[Me_ID] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Medarbejder_Type]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Medarbejder_Type](" + Environment.NewLine +
"\t[Me_Type] [nvarchar](20) NOT NULL," + Environment.NewLine +
" CONSTRAINT [PK_Medarbejder_Type] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Me_Type] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Post]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Post](" + Environment.NewLine +
"\t[PostNr] [int] NOT NULL," + Environment.NewLine +
"\t[Distrikt] [nvarchar](50) NULL," + Environment.NewLine +
" CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[PostNr] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Sag]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Sag](" + Environment.NewLine +
"\t[Sag_Oprets_Dato] [nvarchar](25) NOT NULL," + Environment.NewLine +
"\t[Sag_Slut_Dato] [nvarchar](15) NULL," + Environment.NewLine +
"\t[Sag_Type] [nvarchar](15) NOT NULL," + Environment.NewLine +
"\t[Sag_Afslutet] [bit] NOT NULL," + Environment.NewLine +
"\t[Sag_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
"\t[Sag_Kunde_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
"\t[Sag_Advokat_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
" CONSTRAINT [PK_Sag_1] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Sag_ID] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Sag_Ydelser]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Sag_Ydelser](" + Environment.NewLine +
"\t[Sag_Ydelse_Oprets_Dato] [nvarchar](25) NOT NULL," + Environment.NewLine +
"\t[Sag_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
"\t[Ydelse_Nr] [uniqueidentifier] NOT NULL," + Environment.NewLine +
" CONSTRAINT [PK_Sag_Ydelser] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Sag_ID] ASC," + Environment.NewLine +
"\t[Ydelse_Nr] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Tid]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Tid](" + Environment.NewLine +
"\t[Tid] [decimal](18, 4) NOT NULL," + Environment.NewLine +
"\t[Tid_Dato] [nvarchar](25) NOT NULL," + Environment.NewLine +
"\t[Tid_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
"\t[Sag_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
"\t[Ydelse_Nr] [uniqueidentifier] NOT NULL," + Environment.NewLine +
"\t[Advokat_ID] [uniqueidentifier] NOT NULL," + Environment.NewLine +
" CONSTRAINT [PK_Tid] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Tid_ID] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Type_Ydelse]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Type_Ydelse](" + Environment.NewLine +
"\t[Ydelse_Type] [nvarchar](10) NOT NULL," + Environment.NewLine +
" CONSTRAINT [PK_Type_Ydelse] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Ydelse_Type] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Uddannelser]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Uddannelser](" + Environment.NewLine +
"\t[Advokat_Uddanelse] [nvarchar](30) NOT NULL," + Environment.NewLine +
" CONSTRAINT [PK_Advokat_Udanelser] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Advokat_Uddanelse] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"/****** Object:  Table [dbo].[Ydelse]    Script Date: 26-05-2020 23:30:50 ******/" + Environment.NewLine +
"SET ANSI_NULLS ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"SET QUOTED_IDENTIFIER ON" + Environment.NewLine +
"GO" + Environment.NewLine +
"CREATE TABLE [dbo].[Ydelse](" + Environment.NewLine +
"\t[Ydelse_Navn] [nvarchar](25) NOT NULL," + Environment.NewLine +
"\t[Ydelse_Pris] [decimal](18, 4) NOT NULL," + Environment.NewLine +
"\t[Ydelse_Type] [nvarchar](10) NOT NULL," + Environment.NewLine +
"\t[Ydelse_Art] [nvarchar](20) NOT NULL," + Environment.NewLine +
"\t[Ydelse_Nr] [uniqueidentifier] NOT NULL," + Environment.NewLine +
"\t[Ydelse_Oprets_Dato] [nvarchar](25) NULL," + Environment.NewLine +
" CONSTRAINT [PK_Ydelse] PRIMARY KEY CLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Ydelse_Nr] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]," + Environment.NewLine +
" CONSTRAINT [IX_Ydelse] UNIQUE NONCLUSTERED " + Environment.NewLine +
"(" + Environment.NewLine +
"\t[Ydelse_Navn] ASC" + Environment.NewLine +
")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" + Environment.NewLine +
") ON [PRIMARY]" + Environment.NewLine +
"" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Adv_Arbejds_Ydelser]  WITH CHECK ADD  CONSTRAINT [FK_Adv_Arbejds_Ydelser_Medarbejder] FOREIGN KEY([Adv_ID])" + Environment.NewLine +
"REFERENCES [dbo].[Medarbejder] ([Me_ID])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Adv_Arbejds_Ydelser] CHECK CONSTRAINT [FK_Adv_Arbejds_Ydelser_Medarbejder]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Advokat_Uddannelser]  WITH CHECK ADD  CONSTRAINT [FK_Advokat_Advokat_Udanelser] FOREIGN KEY([Advokat_Uddanelse])" + Environment.NewLine +
"REFERENCES [dbo].[Uddannelser] ([Advokat_Uddanelse])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Advokat_Uddannelser] CHECK CONSTRAINT [FK_Advokat_Advokat_Udanelser]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Advokat_Uddannelser]  WITH CHECK ADD  CONSTRAINT [FK_Advokat_Uddannelser_Medarbejder] FOREIGN KEY([Me_ID])" + Environment.NewLine +
"REFERENCES [dbo].[Medarbejder] ([Me_ID])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Advokat_Uddannelser] CHECK CONSTRAINT [FK_Advokat_Uddannelser_Medarbejder]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Kørsel]  WITH CHECK ADD  CONSTRAINT [FK_Kørsel_Medarbejder] FOREIGN KEY([Advokat_ID])" + Environment.NewLine +
"REFERENCES [dbo].[Medarbejder] ([Me_ID])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Kørsel] CHECK CONSTRAINT [FK_Kørsel_Medarbejder]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Kørsel]  WITH CHECK ADD  CONSTRAINT [FK_Kørsel_Sag1] FOREIGN KEY([Sag_ID])" + Environment.NewLine +
"REFERENCES [dbo].[Sag] ([Sag_ID])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Kørsel] CHECK CONSTRAINT [FK_Kørsel_Sag1]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Kunde]  WITH CHECK ADD  CONSTRAINT [FK_Kunde_Post] FOREIGN KEY([Kunde_PostNr])" + Environment.NewLine +
"REFERENCES [dbo].[Post] ([PostNr])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Kunde] CHECK CONSTRAINT [FK_Kunde_Post]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Kunde_Tlf]  WITH CHECK ADD  CONSTRAINT [FK_Kunde_Tlf_Kunde1] FOREIGN KEY([Kunde_ID])" + Environment.NewLine +
"REFERENCES [dbo].[Kunde] ([Kunde_ID])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Kunde_Tlf] CHECK CONSTRAINT [FK_Kunde_Tlf_Kunde1]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Log_In]  WITH CHECK ADD  CONSTRAINT [FK_Log_In_Medarbejder] FOREIGN KEY([Me_ID])" + Environment.NewLine +
"REFERENCES [dbo].[Medarbejder] ([Me_ID])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Log_In] CHECK CONSTRAINT [FK_Log_In_Medarbejder]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Medarbejder]  WITH CHECK ADD  CONSTRAINT [FK_Medarbejder_Medarbejder_Type] FOREIGN KEY([Me_Type])" + Environment.NewLine +
"REFERENCES [dbo].[Medarbejder_Type] ([Me_Type])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Medarbejder] CHECK CONSTRAINT [FK_Medarbejder_Medarbejder_Type]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Medarbejder]  WITH CHECK ADD  CONSTRAINT [FK_Medarbejder_Post] FOREIGN KEY([Me_PostNr])" + Environment.NewLine +
"REFERENCES [dbo].[Post] ([PostNr])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Medarbejder] CHECK CONSTRAINT [FK_Medarbejder_Post]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Medarbejder_Tlf]  WITH CHECK ADD  CONSTRAINT [FK_Medarbejder_Tlf_Medarbejder1] FOREIGN KEY([Me_ID])" + Environment.NewLine +
"REFERENCES [dbo].[Medarbejder] ([Me_ID])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Medarbejder_Tlf] CHECK CONSTRAINT [FK_Medarbejder_Tlf_Medarbejder1]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Sag]  WITH CHECK ADD  CONSTRAINT [FK_Sag_Kunde] FOREIGN KEY([Sag_Kunde_ID])" + Environment.NewLine +
"REFERENCES [dbo].[Kunde] ([Kunde_ID])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Sag] CHECK CONSTRAINT [FK_Sag_Kunde]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Sag]  WITH CHECK ADD  CONSTRAINT [FK_Sag_Medarbejder] FOREIGN KEY([Sag_Advokat_ID])" + Environment.NewLine +
"REFERENCES [dbo].[Medarbejder] ([Me_ID])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Sag] CHECK CONSTRAINT [FK_Sag_Medarbejder]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Sag_Ydelser]  WITH CHECK ADD  CONSTRAINT [FK_Sag_Ydelser_Sag1] FOREIGN KEY([Sag_ID])" + Environment.NewLine +
"REFERENCES [dbo].[Sag] ([Sag_ID])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Sag_Ydelser] CHECK CONSTRAINT [FK_Sag_Ydelser_Sag1]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Sag_Ydelser]  WITH CHECK ADD  CONSTRAINT [FK_Sag_Ydelser_Ydelse] FOREIGN KEY([Ydelse_Nr])" + Environment.NewLine +
"REFERENCES [dbo].[Ydelse] ([Ydelse_Nr])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Sag_Ydelser] CHECK CONSTRAINT [FK_Sag_Ydelser_Ydelse]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Tid]  WITH CHECK ADD  CONSTRAINT [FK_Tid_Medarbejder] FOREIGN KEY([Advokat_ID])" + Environment.NewLine +
"REFERENCES [dbo].[Medarbejder] ([Me_ID])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Tid] CHECK CONSTRAINT [FK_Tid_Medarbejder]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Tid]  WITH CHECK ADD  CONSTRAINT [FK_Tid_Sag_Ydelser] FOREIGN KEY([Sag_ID], [Ydelse_Nr])" + Environment.NewLine +
"REFERENCES [dbo].[Sag_Ydelser] ([Sag_ID], [Ydelse_Nr])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Tid] CHECK CONSTRAINT [FK_Tid_Sag_Ydelser]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Tid]  WITH CHECK ADD  CONSTRAINT [FK_Tid_Sag1] FOREIGN KEY([Sag_ID])" + Environment.NewLine +
"REFERENCES [dbo].[Sag] ([Sag_ID])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Tid] CHECK CONSTRAINT [FK_Tid_Sag1]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Ydelse]  WITH CHECK ADD  CONSTRAINT [FK_Ydelse_Type_Ydelse] FOREIGN KEY([Ydelse_Type])" + Environment.NewLine +
"REFERENCES [dbo].[Type_Ydelse] ([Ydelse_Type])" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER TABLE [dbo].[Ydelse] CHECK CONSTRAINT [FK_Ydelse_Type_Ydelse]" + Environment.NewLine +
"GO" + Environment.NewLine +
"USE [master]" + Environment.NewLine +
"GO" + Environment.NewLine +
"ALTER DATABASE [Advokathuset] SET  READ_WRITE " + Environment.NewLine +
"GO" ;
        }








        // Sql Diagram Button
        private void sql_diagram_button_Click(object sender, EventArgs e)
        {
            Save_Db_Diagram();
        }








         // Save Database Diagram - To Desktop
        private void Save_Db_Diagram()
        {

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            desktopPath += "\\";

            // Bitmap
            Bitmap bitmapScreenshot = Properties.Resources.Advokathuset___Design__Diagram;

             
           
            // Save bitmap
            bitmapScreenshot.Save(desktopPath + "Advokat_Design_Diagram.png");
            Clipboard.SetDataObject(bitmapScreenshot);  // Copy Image to Clipboard Also

            // Open File
            Process.Start(desktopPath + "Advokat_Design_Diagram.png");
        }



        // Sql Connection Label -- Tip - Click 
        private void conn_string_tip_label_Click(object sender, EventArgs e)
        {
            Show_Settings();
        }
    }
}
