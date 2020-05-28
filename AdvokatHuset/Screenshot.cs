using System;
using System.Collections.Generic;
using System.Drawing;// Used for the Screenshot function
using System.Drawing.Imaging; // Used for the Screenshot function
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain
{
    class Screenshot
    {

     public  string ScreenshotNameDateTime { get; set; } 
     public  string ScreenshotSavePath { get; set; }

        public Screenshot()  // Constructor
        {
            ScreenshotSavePath = "C://";
            ScreenshotNameDateTime = "ScreenShot -"+DateTime.Now.ToString("dd -MM-yyyy  HH-mm-ss");
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

                    // Add to Clipboard
                    Clipboard.SetDataObject(bmp);
                    Image image = (Image)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    Clipboard.SetDataObject(image);
                }
            }

           
        }

        //----------------Screenshot-Entire--Screen-----::END::--------------------------------------------------------------------------------------------









        //--------------------Form--Screenshot----::START::------------------------------------------------------------------------------------------

        public void MakeFormScreenshot()
        {
            //Form currentForm = Form.ActiveForm; // Get the Active Form  

            Rectangle formBounds = new Rectangle(Form.ActiveForm.Location, Form.ActiveForm.Size);
            using (Bitmap bmp = new Bitmap(formBounds.Width, formBounds.Height)) // New Bitmap
            {
                 
                using (Graphics gr = Graphics.FromImage(bmp))
                {

                    gr.CopyFromScreen(formBounds.Location.X, formBounds.Location.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                    bmp.Save($"{ScreenshotSavePath}{ScreenshotNameDateTime}.png", ImageFormat.Png);// Screenshot -  Unique Name so it dont get overwrited everytime new screenshot is made

                    // Add to Clipboard
                    Clipboard.SetDataObject(bmp);
                    Image image = (Image)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    Clipboard.SetDataObject(image);
                }

                //currentForm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height)); // Current Form to Bitmap "Rectangle Location and Size"
                //bmp.Save($"{ScreenshotSavePath}{ScreenshotNameDateTime}.png", ImageFormat.Png);// Screenshot -  Unique Name so it dont get overwrited everytime new screenshot is made
            }
        }

        //--------------------Form--Screenshot----::END::------------------------------------------------------------------------------------------






              // Error - Sound
             private void PlaySound()
             {
               SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chord.wav");
               simpleSound.Play();
             }





        //---------------------Selection-Screenshot--::START::-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void MakeSelectionScreenshot(Rectangle selection)
        {
            bool exception = false;

            try
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
                
                        // To Clipboard
                        Clipboard.SetDataObject(bmp);
                        Image image = (Image)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                        Clipboard.SetDataObject(image);
                     

                    }

                }
                 

 
            }
            catch(Exception)
            {
                exception = true;
            }

            if(exception == true) // If there is exceptio play Failed sound - // Exception can happen because the rectangle can be null
            {
                PlaySound();
            }


        }
        //---------------------Selection-Screenshot--::END::-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





    }
}
