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

    public partial class Main_Body_Form : Form
    {

       // Froms -  For Loading
       Log_In_Form0 Log_In_Form = new Log_In_Form0();
        //Main_Form1 Main_Form = new Main_Form1();





        public Main_Body_Form()
        {
            InitializeComponent();
        }

        private void Main_Body_Form_Load(object sender, EventArgs e)
        {
            Show_Log_In(); // Load Log In Form
            //Show_Main_Form();
        }


        // Log In Form
        private void Show_Log_In()
        {
            Log_In_Form.TopLevel = false;
            Main_Body_Loader_panel.Controls.Add(Log_In_Form);
            Log_In_Form.FormBorderStyle = FormBorderStyle.None;
            Log_In_Form.Dock = DockStyle.Fill;
            Log_In_Form.Show();
          
        }



        //// Main Form After Log In
        //private void Show_Main_Form()
        //{
        //    Main_Form.TopLevel = false;
        //    Main_Body_Loader_panel.Controls.Add(Main_Form);
        //    Main_Form.FormBorderStyle = FormBorderStyle.None;
        //    Main_Form.Dock = DockStyle.Fill;
        //    Main_Form.Show();
        //}


    }
}
