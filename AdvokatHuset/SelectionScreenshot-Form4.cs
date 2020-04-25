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

namespace View_GUI
{
    public partial class SelectionScreenshot_Form4 : Form
    {

        MenuFormSelectionScreenshot___Form5 menuForm = new MenuFormSelectionScreenshot___Form5();
        private bool canDraw;
        private int startX, startY;
        private Rectangle rect = Screen.GetBounds(Point.Empty);



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
            canDraw = true; // On mouse Down - Now we can draw

            // Start Position of Drawing
            // e is the mouse 
            startX = e.X;
            startY = e.Y;
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




        private void selectionScreenshot_button_Click(object sender, EventArgs e)  // Make Screenshot form the Selection
        {
            selectionScreenshot_button.Visible = false;  // Make the button invisible so it does not come in the screenshot

            Screenshot screenshot = new Screenshot();
            screenshot.MakeSelectionScreenshot(rect);   // Screenshot Class Method

            selectionScreenshot_button.Visible = true;  // Make the button visible again
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
            help_label.Visible = true;
        }

        //---------ScreenshotForm--Close with Esc - Key-----::END::------------------------------------------------------------------------------------------------------------------------------------------------------



        private void openFolder_button_Click(object sender, EventArgs e)
        {
           
            Process.Start("C://"); // Opens Default App - Directory with Screenshots, Pdf etc.
            this.Close();
        }








    }
}
