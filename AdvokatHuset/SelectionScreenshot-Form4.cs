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
        



        // Initialize
        public SelectionScreenshot_Form4()
        {
            menuForm.Show();
            this.TransparencyKey = Color.Turquoise;   // Transparent BackColor
            this.BackColor = Color.Turquoise;   // Transparent BackColor
            this.DoubleBuffered = true; // Removes Flickering on drawing
 
            InitializeComponent();
        }





        // LOAD
        private void SelectionScreenshot_Form4_Load(object sender, EventArgs e)
        {
          

        }


     


       // Start Point of Draw "Rectangle"
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


      



        // Stop Drawing Rectangle on Mouse Up
        private void SelectionScreenshot_Form4_MouseUp(object sender, MouseEventArgs e)
        {
            canDraw = false;  // When you leave the mouse button you stop drawing the rectangle 
        }





          // Draw the Rectangle SIZE   ------ DRAWS the SIZE OF THE RECTANGLE NOT THE VISIBLE RED LINES
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






        //--Paint---Rectangle-------THIS TAKES the size of the rectangle and paints it red
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, rect);
                //e.Graphics.DrawLine(Pens.Yellow, 0, 0, 100, 100);
           
            }
          
        }


        







        // Make Screenshot button " Discet"
        private void selectionScreenshot_button_Click(object sender, EventArgs e)  // Make Screenshot form the Selection
        {
            MakeScreenshotNow();
        
        }






         // The Main Method - Make Screenshot
        private void MakeScreenshotNow()
        {
            //Hide All Buttons
       
             
            Cursor.Current = Cursors.WaitCursor;


            //Sound-------------
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();

            //Scrennshot
            screenshot = new Screenshot();
            screenshot.MakeSelectionScreenshot(rect);   // Screenshot Class Method

            Cursor.Current = Cursors.Default;

            //SHOW ALL Buttons Again --------
      
        }

         



        //---------ScreenshotForm--Close with Esc - Key-----::START::---------------------------------------------------------------------------------------------------------------------------------------------------
        private void SelectionScreenshot_Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape) //Close Form
            {
                 Close();
            }

            
        }





         // On Selection Screen "FORM Closing" close the menu with the "Save, Edit in Paint, Open folder, etc.  "The menu is made of another Form because of the transparency" On Selection Screenshot Form CLose the menu is also closed
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



          


        // Close Selection Cut button  "THIS FORM"
        private void closeForm_button_Click(object sender, EventArgs e)
        {
            CloseForm();// Method
        }






        // Close SelectionScreenshot Form - Main Method
         private void CloseForm()
         {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Default.wav");
            simpleSound.Play();
            this.Close(); // Close this Form
         }





        // ESC Buttoen Down - Close Selection Cut
        protected override bool ProcessDialogKey(Keys keydata) // ESC Key only on this form "Dont send key event to other "Parrent" forms
          {
            if(Form.ModifierKeys == Keys.None && keydata == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessDialogKey(keydata);
          }

        //---------ScreenshotForm--Close with Esc - Key-----::END::------------------------------------------------------------------------------------------------------------------------------------------------------







        // Help button
        private void help_button_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Balloon.wav");
            simpleSound.Play();

            help_label.Visible = true;
        }






           // Opens Last Image in Paint -Main - Method
        private void OpenLastImageInPaint()
        {

            //----------------GET--LAST--Updated--File
            string Path = @"C:\";

            var files = new DirectoryInfo(Path).GetFiles("*.png*");
            string lastfile = "";

            DateTime lastupdated = DateTime.MinValue;

            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > lastupdated)
                {
                    lastfile = file.FullName;
                }
            }



            //---------------- Opens Last image in paint

            Process.Start("mspaint", $@"""{lastfile}""");

            CloseForm();
        }






         // Opens the last Image in Paint
        private void open_iimage_in_paint_button_Click(object sender, EventArgs e)
        {
            OpenLastImageInPaint();
        }






        //Shortcut keys  -- Paint, Foldet, ETC--- Place here all shortcuts
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.E))
            {
                OpenLastImageInPaint();// Paint
            }


            if (keyData == (Keys.Control | Keys.F))
            {
                OpenFolder();// FOLDER
            }


            if (keyData == (Keys.Control | Keys.S))
            {
                MakeScreenshotNow();
            }
                  
            return base.ProcessCmdKey(ref msg, keyData);
        }

    
 



            // Open Folder - Main Method
           private void OpenFolder()
           {

            //Sound
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\recycle.wav");
            simpleSound.Play();

            // Opens Folder
            screenshot = new Screenshot();
            Process.Start($@"{screenshot.ScreenshotSavePath}"); // Opens Default App - Directory with Screenshots, Pdf etc.
            this.Close();

           }


  







         //---------ToolTips---::START::------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Save Screenshot "Make Screenshot" - ToolTip
        private void selectionScreenshot_button_MouseHover_1(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
        
            tip.AutoPopDelay = 3000;
            tip.InitialDelay = 500;
            tip.ReshowDelay = 1000;
            tip.ShowAlways = true;

            tip.SetToolTip(selectionScreenshot_button, "Save: Press: \"CTRL + S\"");
        }





        // Tool Tip Folder
        private void openFolder_button_MouseHover(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
             
            tip.AutoPopDelay = 3000;
            tip.InitialDelay = 500;
            tip.ReshowDelay = 1000;
            tip.ShowAlways = true;

            tip.SetToolTip(openFolder_button, "Open Local Folder: Press: \"CTRL + F\"");
        }





        // Tool Tip Paint
        private void open_iimage_in_paint_button_MouseHover_1(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
        
            tip.AutoPopDelay = 3000;
            tip.InitialDelay = 500;
            tip.ReshowDelay = 1000;
            tip.ShowAlways = true;

            tip.SetToolTip(open_iimage_in_paint_button, "Open Last Image in Paint: Press:  \"CTRL + E\"");
        }




        // Close Selection Screenshot- Tooltip
        private void closeForm_button_MouseHover(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();

            tip.AutoPopDelay = 3000;
            tip.InitialDelay = 500;
            tip.ReshowDelay = 1000;
            tip.ShowAlways = true;

            tip.SetToolTip(closeForm_button, "EXIT Press: \"ESC\"");
        }

        //---------ToolTips---::END::------------------------------------------------------------------------------------------------------------------------------------------------------------






        // Open Folder with the screenshots
        private void openFolder_button_Click(object sender, EventArgs e)
        {
            OpenFolder();// Main - Method - "Open Folder"
        }

         
       


    }
}
