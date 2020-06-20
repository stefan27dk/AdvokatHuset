﻿using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
    
namespace View_GUI
{


    public partial class Main_Body_Form : Form
    {
        // Transparent Form
        Transparent_Form TransparentForm1 = new Transparent_Form();



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


            // Transaparent Form 
            Transparent_Panel();


            this.StartPosition = FormStartPosition.CenterScreen;

            Main_Body_Settings(); // Settings
            Show_Log_In(); // Load Log In Form on Start

            //var prop = TitleBar_panel.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            //prop.SetValue(TitleBar_panel, true, null);



            //this.Opacity = 1;
            opacity_trackBar.Value = (int)(this.Opacity * 100);
        }












        // Log In Form
        private void Show_Log_In()
        {
            this.Opacity = 0.95; // Main Form Opacity
            Log_In_Form.TopLevel = false;
            Main_Body_Loader_panel.Controls.Add(Log_In_Form);
            Log_In_Form.FormBorderStyle = FormBorderStyle.None;
            Log_In_Form.Dock = DockStyle.Fill;
            Log_In_Form.Show();

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
            if (WindowState != FormWindowState.Maximized)
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

            if (this.TopMost == false)
            {
                this.TopMost = true;
                allays_on_top_button.BackgroundImage = Properties.Resources.flash_kard_icon__1___5___4_;

            }
            else
            {
                this.TopMost = false;
                allays_on_top_button.BackgroundImage = Properties.Resources.flash_kard_icon__1___5___3_1;

            }


        }

        //----Buttons-------------------------<<<--------------------------------------







        //-------------Buttons---Hover-------------->>>--------------------------------

        // Exit Button - MouseEnter
        private void close_form_button_MouseEnter(object sender, EventArgs e)
        {
            close_form_button.BackgroundImage = Properties.Resources.Exit_Hover_Form1432;
        }




        //Exit Button - Reset Image On Leave
        private void close_form_button_MouseLeave(object sender, EventArgs e)
        {
            close_form_button.BackgroundImage = Properties.Resources.Exit_Form14321;

        }




        //Maximize - Mouse Enter
        private void maximize_button_MouseEnter(object sender, EventArgs e)
        {
            maximize_button.BackgroundImage = Properties.Resources.Maximize_Hover_Ll234;
        }






        // Maximize - Mouse Leave
        private void maximize_button_MouseLeave(object sender, EventArgs e)
        {
            maximize_button.BackgroundImage = Properties.Resources.Hover_Maximize_Now;

        }






        // Minimizee - Enter
        private void minimize_button_MouseEnter(object sender, EventArgs e)
        {
            minimize_button.BackgroundImage = Properties.Resources.Minimize_OOP;
        }




        // Minimizee - Leave
        private void minimize_button_MouseLeave(object sender, EventArgs e)
        {
            minimize_button.BackgroundImage = Properties.Resources.Minimize12342;
        }





        // Move Form Top
        private void Move_Form_Top_button_Click(object sender, EventArgs e)
        {
            int ScreenW = Screen.PrimaryScreen.Bounds.Width;  // Get Screen Width
            int ScreenH = Screen.PrimaryScreen.Bounds.Height; // Get Screen Height

            this.WindowState = FormWindowState.Normal; // Make The Form Normal Size Note:"If it is maximized you cant resize it"
            this.Location = new Point(0, 0); // Location Top Left Corner
            this.Width = ScreenW;
            this.Height = (int)(ScreenH * 0.5);
        }





        // Move Form Botom
        private void Move_Form_Bottom_button_Click(object sender, EventArgs e)
        {
            int ScreenW = Screen.PrimaryScreen.Bounds.Width;
            int ScreenH = Screen.PrimaryScreen.Bounds.Height;
            int ScreenY = Screen.PrimaryScreen.Bounds.Y;

            this.WindowState = FormWindowState.Normal;
            this.Location = new Point(0, (int)(ScreenH / 2));
            this.Width = ScreenW;
            this.Height = (int)(ScreenH * 0.5) - 41;
        }





        // Form Normal Size - Center
        private void Normal_Size_Form_button_Click(object sender, EventArgs e)
        {

            int ScreenW = Screen.PrimaryScreen.Bounds.Width;
            int ScreenH = Screen.PrimaryScreen.Bounds.Height;
            WindowState = FormWindowState.Normal;

            this.Size = new Size(1600, 800);
            this.Location = new Point((ScreenW / 2) - (this.Width / 2), (ScreenH / 2) - (this.Height / 2)); // Position is determined by the top left corner of the Object in this Case the Form
            // Get The screens Width / 2 monus the half of the form size and you get the form at tte center
        }







        // Show Only TitleBar
        private void Show_Only_TitleBar_button_Click(object sender, EventArgs e)
        {

            int ScreenW = Screen.PrimaryScreen.Bounds.Width;
            int ScreenH = Screen.PrimaryScreen.Bounds.Height;

            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(ScreenW - 150, 50);
            this.Location = new Point(0, 0);
        }



        // Form Screenshot Button
        private void Form_Screenshot_button_button_Click(object sender, EventArgs e)
        {
            SoundPlayer sscreenshotSound = new SoundPlayer(@"C:\\Windows\Media\Windows Information Bar.wav");
            sscreenshotSound.Play();

            Screenshot screenshot = new Screenshot();
            screenshot.MakeFormScreenshot();
        }


        //-------------Buttons---Hover--------------<<<<--------------------------------


        //-------------------Custom--Form--Border----::END::-----------------------------------------------











        //------Form - Opacity----::START::-------------------------------------------------------------

        //Track bar "Opacity"
        private void opacity_trackBar_ValueChanged(object sender, EventArgs e)
        {
            this.Opacity = opacity_trackBar.Value * 0.01;  // Adjust Form Opacity
        }



        // Opacity MAX
        private void opacity_max_button_Click(object sender, EventArgs e)
        {

            opacity_trackBar.Value = opacity_trackBar.Minimum;
        }




        // Opacity MINIMUM
        private void opacity_min_button_Click(object sender, EventArgs e)
        {

            opacity_trackBar.Value = opacity_trackBar.Maximum;
        }





        // Middle
        private void semi_middle_opacity_button_Click(object sender, EventArgs e)
        {

            opacity_trackBar.Value = ((opacity_trackBar.Maximum) / 2) + 7;
        }





        // 25 % Opacity Button
        private void opacity_25_percent_button_Click(object sender, EventArgs e)
        {
            opacity_trackBar.Value = 85;

        }


        //------Form - Opacity----::START::-------------------------------------------------------------




      





        // ADD / Show - Transparent Form -------::START::------------------------------------------------------


        // Toggle Transparrent Form
        private void Add_Ttransparent_form_button_MouseDown(object sender, MouseEventArgs e)
        {
            if (TransparentForm1.Visible == false)
            {
                TransparencyKey = Color.Red;
                TransparentForm1.Visible = true;
            }
            else
            {
                this.TransparencyKey = this.BackColor = Color.Red; // Makes it so we don see red Color on Removing the Transaprent Form
                TransparentForm1.Visible = false;
                this.BackColor = Color.FromArgb(24, 24, 34); // Remove Red Background and Transparency on the main form at the Bottom
                 
            }

        }



       
     
 

        // Mouse UP - Remove Red Flickering on Transparent Form Toggle
        private void Add_Ttransparent_form_button_MouseUp(object sender, MouseEventArgs e)
        {
            if(TransparentForm1.Visible == false)
            {
              this.TransparencyKey = this.BackColor = Color.Empty;
              this.BackColor = Color.FromArgb(24, 24, 34); // Remove Red Background and Transparency on the main form at the Bottom
            }

        }

        // ADD - Transparency Form -------::START::------------------------------------------------------








        // Transparent panel / Form
        private void Transparent_Panel()
        {
            
            TransparentForm1.TopLevel = false;
            TransparentForm1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            TransparentForm1.Dock = DockStyle.Fill;

            Main_Body_Loader_panel.Controls.Add(TransparentForm1);

            //TransparentForm1.Show();
            //TransparentForm1.BringToFront();
        }

      
    }


      




}
 
