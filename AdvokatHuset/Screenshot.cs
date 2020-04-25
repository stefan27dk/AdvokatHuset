using System;
using System.Collections.Generic;
using System.Drawing;// Used for the Screenshot function
using System.Drawing.Imaging; // Used for the Screenshot function
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain
{
    class Screenshot
    {

       string ScreenshotNameDateTime { get; set; } 
       string ScreenshotSavePath { get; set; }

        public Screenshot()  // Constructor
        {
            ScreenshotSavePath = "C://ScreenShot - ";
            ScreenshotNameDateTime = DateTime.Now.ToString("dd-MM-yyyy  HH-mm-ss");
        }






        //----------------Screenshot-Entire--Screen-----::START::--------------------------------------------------------------------------------------------
        public void MakeScrenshot()
        {
            Rectangle screenBounds = Screen.GetBounds(Point.Empty); // The Screen Area
            using (Bitmap bmp = new Bitmap(screenBounds.Width, screenBounds.Height)) // New Bitmap
            {
                using (Graphics g = Graphics.FromImage(bmp)) 
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, screenBounds.Size);
                    bmp.Save($"{ScreenshotSavePath}{ScreenshotNameDateTime}.png", ImageFormat.Png);// Screenshot -  Unique Name so it dont get overwrited everytime new screenshot is made
                }
            }
            
        }

        //----------------Screenshot-Entire--Screen-----::END::--------------------------------------------------------------------------------------------









        //--------------------Form--Screenshot----::START::------------------------------------------------------------------------------------------

        public void MakeFormScreenshot()
        {
            Form currentForm = Form.ActiveForm; // Get the Active Form  
            using (Bitmap bmp = new Bitmap(currentForm.Width, currentForm.Height)) // New Bitmap
            {
                currentForm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height)); // Current Form to Bitmap "Rectangle Location and Size"
                bmp.Save($"{ScreenshotSavePath}{ScreenshotNameDateTime}.png", ImageFormat.Png);// Screenshot -  Unique Name so it dont get overwrited everytime new screenshot is made
            }
        }

        //--------------------Form--Screenshot----::END::------------------------------------------------------------------------------------------









        //---------------------Selection-Screenshot--::START::-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void MakeSelectionScreenshot(Rectangle selection)
        {
            Form currentForm = Form.ActiveForm; // Get current Form

            int locationX = currentForm.Location.X + selection.Location.X + 8; // + 8; "If form has Normal Border + 8" // Get Form Location x and plus it with the rectangle X: So we know where on the screen is the rectangle. The rectangles scope is only in the Forms scope "The 8px Tolerance is because of the Forms window itself "The window border"
            int locationY = currentForm.Location.Y + selection.Location.Y +26 ; // + 30; "If form has Border + 30"

            using (Bitmap bmp = new Bitmap(selection.Width, selection.Height, PixelFormat.Format32bppArgb))
            {

                using (Graphics g = Graphics.FromImage(bmp))
                {

                    g.CopyFromScreen(locationX, locationY, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                    bmp.Save($"{ScreenshotSavePath}{ScreenshotNameDateTime}.png", ImageFormat.Png);// Screenshot -  Unique Name so it dont get overwrited everytime new screenshot is made
                }

            }

        }
        //---------------------Selection-Screenshot--::END::-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





    }
}
