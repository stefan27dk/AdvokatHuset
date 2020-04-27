using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Domain;
using System.Diagnostics;
using System.Media;
using System.IO;

namespace View_GUI
{
    public partial class SelectionScreenshot_Form4 : Form
    {

        MenuFormSelectionScreenshot___Form5 menuForm = new MenuFormSelectionScreenshot___Form5();
        private bool canDraw;
        private int startX, startY;
        private Rectangle rect = Screen.GetBounds(Point.Empty);
        Screenshot screenshot;


        public SelectionScreenshot_Form4()
        {

            menuForm.Show();
            this.TransparencyKey = Color.Turquoise;   // Transparent BackColor
            this.BackColor = Color.Turquoise;   // Transparent BackColor
            this.DoubleBuffered = true; // Removes Flickering on drawing
           

            InitializeComponent();
        }






        private void SelectionScreenshot_Form4_Load(object sender, EventArgs e)
        {
            


        }


     



        private void SelectionScreenshot_Form4_MouseDown(object sender, MouseEventArgs e)
        {
      

            if (e.Button == MouseButtons.Left)// If mouse button Left Down than Draw
            {
                canDraw = true; // On mouse Down - Now we can draw

                // Start Position of Drawing
                // e is the mouse 
                startX = e.X;
                startY = e.Y;
            }

     
            if(e.Button == MouseButtons.Right)// If Mouse Right Button pressed Make Screenshot
            {
                MakeScreenshotNow();
            }

        }


      




        private void SelectionScreenshot_Form4_MouseUp(object sender, MouseEventArgs e)
        {
            canDraw = false;  // When you leave the mouse button you stop drawing the rectangle 
        }






        private void SelectionScreenshot_Form4_MouseMove(object sender, MouseEventArgs e)
        {
             
                if (!canDraw) return; // Return if you are not allowed to Draw
                {

                    int x = Math.Min(startX, e.X); // The starting location and the Location of the mouse now
                    int y = Math.Min(startY, e.Y);
                    int width = Math.Max(startX, e.X) - Math.Min(startX, e.X);
                    int height = Math.Max(startY, e.Y) - Math.Min(startY, e.Y);
                    rect = new Rectangle(x, y, width, height);

                    Refresh();

                }
            
        }






        //--Paint---Rectangle-------
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, rect);
                //e.Graphics.DrawLine(Pens.Yellow, 0, 0, 100, 100);
           
            }
          
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  Make all buttons invisible on screenshot


        private void selectionScreenshot_button_Click(object sender, EventArgs e)  // Make Screenshot form the Selection
        {
            MakeScreenshotNow();

        
        }


        private void MakeScreenshotNow()
        {
            //Hide All Buttons
       ;
             
            Cursor.Current = Cursors.WaitCursor;
            //Sound
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();

            //Scrennshot
            screenshot = new Screenshot();
            screenshot.MakeSelectionScreenshot(rect);   // Screenshot Class Method

            Cursor.Current = Cursors.Default;

            //SHOW ALL Buttons Again --------
        ;
        }

         



        //---------ScreenshotForm--Close with Esc - Key-----::START::---------------------------------------------------------------------------------------------------------------------------------------------------
        private void SelectionScreenshot_Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape) //Close Form
            {
                 Close();
            }

            
        }



        private void SelectionScreenshot_Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (menuForm == null)
            {
               menuForm = new MenuFormSelectionScreenshot___Form5();
               menuForm.Show();
            }


                if (menuForm != null)
                {
                menuForm.Close();
                }

        }









        private void closeForm_button_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

         private void CloseForm()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Default.wav");
            simpleSound.Play();
            this.Close();
        }

        protected override bool ProcessDialogKey(Keys keydata) // ESC Key only on this form "Dont send key event to other "Parrent" forms
          {
            if(Form.ModifierKeys == Keys.None && keydata == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessDialogKey(keydata);
          }








        private void help_button_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Balloon.wav");
            simpleSound.Play();

            help_label.Visible = true;
        }







        private void open_iimage_in_paint_button_Click(object sender, EventArgs e)
        {

            //-----------------GET--LAST--Updated--File
            string Path = @"C:\";

            var files = new DirectoryInfo(Path).GetFiles("*.png*");
            string lastfile = "";

            DateTime lastupdated = DateTime.MinValue;

            foreach(FileInfo file in files)
            {
                if(file.LastWriteTime > lastupdated)
                {
                    lastfile = file.FullName;
                }
            }

           

            // Opens Last image in paint

            Process.Start("mspaint", $@"""{lastfile}""");

            CloseForm();


        }

        //---------ScreenshotForm--Close with Esc - Key-----::END::------------------------------------------------------------------------------------------------------------------------------------------------------















        private void openFolder_button_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\recycle.wav");
            simpleSound.Play();
             

            Process.Start("C://"); // Opens Default App - Directory with Screenshots, Pdf etc.
            this.Close();
        }








    }
}
