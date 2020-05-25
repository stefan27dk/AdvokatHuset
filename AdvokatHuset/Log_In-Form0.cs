using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View_GUI
{
    public partial class Log_In_Form0 : Form
    {

        // Forms
        Main_Form1 Main_Form = new Main_Form1();




        // Log In Validate
        bool Log_In_Is_Valid = false;

        // Input Vlidate
        bool Input_Is_Valid = true;

        public Log_In_Form0()
        {
            InitializeComponent();
        }


       


        // Log In Main Method
        private void Log_In()
        {
            Validate_Input(); // VALIDATE INPUT

            if(Input_Is_Valid == true)
            {
                Validate_Log_In Check_Log_IN = new Validate_Log_In();
                Log_In_Is_Valid =  Check_Log_IN.Log_In_Check(log_name_textBox, log_pass_textBox);


                // Play Log In Sound
                System.Media.SoundPlayer log_in_sound = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Battery Critical.wav");
                log_in_sound.Play();
            }
        }








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




            




        // Log In Button
        private void log_in_button_Click(object sender, EventArgs e)
        {
            Log_In();
            Show_Main_Form();
        }


       //------LOAD - MAIN FORM---IF LOG--IN--IS---Valid-------------::Start::----------------------------------------
        private void Show_Main_Form()
        {

            if (Log_In_Is_Valid == true)   // If Log IN is Valid
            {
                Main_Form.TopLevel = false;
                this.Parent.Controls.Add(Main_Form);  // Get the Loader Panel of the Main Form Body
                Main_Form.FormBorderStyle = FormBorderStyle.None;
                Main_Form.Dock = DockStyle.Fill;
                Main_Form.Show();
                this.Dispose(); // Dispose Log In Form
            }

            else
            {
                log_name_textBox.BackColor = Color.FromArgb(255, 192, 192);
                log_pass_textBox.BackColor = Color.FromArgb(255, 192, 192);
            }

        }


        //------LOAD - MAIN FORM---IF LOG--IN--IS---Valid-------------::END::----------------------------------------




        // Reset Color Name
        private void log_name_textBox_TextChanged(object sender, EventArgs e)
        {
            log_name_textBox.BackColor = DefaultBackColor;
        }




        // Reset Color Pass
        private void log_pass_textBox_TextChanged(object sender, EventArgs e)
        {
            log_pass_textBox.BackColor = DefaultBackColor;

        }
    }
}
