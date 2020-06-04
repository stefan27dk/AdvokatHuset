using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
    
namespace View_GUI
{

 

    public partial class Main_Body_Form : Form
    {

       


        //-----------FORM--Border----TitleBar-----Settings-----::SATRT::-------------------------------------------

        // For the Title Bar make it Dragable with The Form so you can drag the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);



        

        // Form Resize Resources
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 1;
        const int HTCAPTION = 2;


        // Tasbar Minimize Maximize
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;

        //-----------FORM--Border----TitleBar-----Settings-----::END::-------------------------------------------









        // Froms -  For Loading
        Log_In_Form0 Log_In_Form = new Log_In_Form0();






        public Main_Body_Form()
        {
            InitializeComponent();
        }





        // Load
        private void Main_Body_Form_Load(object sender, EventArgs e)
        {
            Main_Body_Settings(); // Settings
            Show_Log_In(); // Load Log In Form on Start
          
            //var prop = TitleBar_panel.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            //prop.SetValue(TitleBar_panel, true, null);

        }





        // Main_Body_Form Settings
        private void Main_Body_Settings()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            typeof(Form).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, this, new object[] { true });

            // The Title Bar - Border - Dragger - No - Anti FLickering Code
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, TitleBar_panel, new object[] { true });

        }









        //-------------------Custom--Form--Border----::START::-----------------------------------------------






        //-------------------------SPECIAL-->>>-----------------------------------------------------------------


        // Method for Form Move - // Can be also done with panel that follows the mouse on grab and move
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {

                case WM_NCHITTEST:
                    if (m.Result == (IntPtr)HTCLIENT)
                    {
                        m.Result = (IntPtr)HTCAPTION;
                    }
                    break;

            }


        }




        // Method for Resize
        protected override CreateParams CreateParams
        {

            get
            {
              
                // For Moving the Form and resize it
                CreateParams cp = base.CreateParams;
                cp.Style = (cp.Style | 262144);


                // For Minimize and maximize when you click on the taskbar
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;


                return cp;   
             }

            

        }






        // Move Form - Panel Drag
        private void TitleBar_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }


         //-------------------------SPECIAL-----<<<--------------------------------------------------------------












        //----Buttons-------------------->>>-------------------------------------------

        // Close the Form - Button
        private void close_form_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        // Minimize - Button
        private void minimize_button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }




        // Maximize - Button
        private void maximize_button_Click(object sender, EventArgs e)
        {
            if(WindowState != FormWindowState.Maximized)
            {
               WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }


        }





        // Allways on top
        private void allays_on_top_button_Click(object sender, EventArgs e)
        {

            if(this.TopMost == false)
            {
            this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }


        }
        //----Buttons-------------------------<<<--------------------------------------







        //-----------Remove FLickering-TITLE BAR------------------------------------------------




        //protected override void OnPaintBackground(PaintEventArgs e)
        //{

        //}



        //protected override void OnPaint(PaintEventArgs e)
        //{


        //}

        //-----------Remove FLickering-TITLE BAR------------------------------------------------














        //-------------------Custom--Form--Border----::END::-----------------------------------------------












        // Log In Form
        private void Show_Log_In()
        {
            Log_In_Form.TopLevel = false;
            Main_Body_Loader_panel.Controls.Add(Log_In_Form);
            Log_In_Form.FormBorderStyle = FormBorderStyle.None;
            Log_In_Form.Dock = DockStyle.Fill;
            Log_In_Form.Show();
          
        }

      
    }
}
