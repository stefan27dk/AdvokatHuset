using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;  //Used for Screenshot
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Domain;
using System.Threading;
using System.Timers;

namespace View_GUI
{
  


    public partial class Main_Form1 : Form
    {    
        //Forms--::START::
        Sager_Form2 SagerForm2 = new Sager_Form2();  //Form2
        Advokater_Form3 AdvokaterForm3 = new Advokater_Form3();//Form3
        //Forms--::END::

        Screenshot screenshot; // Screenshot 
 



                                      

        public Main_Form1()
        {

            InitializeComponent();
            General_menuStrip.Renderer = new MyRenderer(); // Used for General_menuStrip to change the "Selection Background Color" "Renderer"
         
        }

          




        //General_menustrip-Custumized-Theme-------::Start::----------------------------------------------------------------------------------------------
        private class MyRenderer: ToolStripProfessionalRenderer
        {
              public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable  //Overriding Colors
        {
            public override Color MenuItemSelected { get { return Color.FromArgb(250, 182, 72); } }
            public override Color MenuItemSelectedGradientBegin  { get { return Color.FromArgb(250, 182, 72); } }
            public override Color MenuItemSelectedGradientEnd { get { return Color.FromArgb(250, 182, 72); } }
        }
        //General_menustrip-Custumized-Theme-------::END::----------------------------------------------------------------------------------------------








        //------------------MENU DROP DOWN FOR SCREENSHOTS------RENDER---Custumized-Theme-----::START::-----------------------------------------------------------------------
        public class BrowserMenuRenderer : ToolStripProfessionalRenderer
        {
            public BrowserMenuRenderer() : base(new BrowserColors()) { }
        }



        public class BrowserColors : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground  // Drop Down Background - Right
            {
                get
                {
                    return Color.FromArgb(48, 48, 54);   //---------------->
                }
            }

            public override Color ImageMarginGradientBegin
            {
                get
                {
                    return Color.FromArgb(52, 71, 66);     //---------------->
                }
            }

            public override Color ImageMarginGradientMiddle
            {
                get
                {
                    return Color.FromArgb(58, 58, 64); //---------------->
                }
            }

            public override Color ImageMarginGradientEnd
            {
                get
                {
                    return Color.FromArgb(48, 48, 54);
                }
            }

            public override Color MenuBorder //Drop Down Border
            {
                get
                {
                    return Color.Red; //---------------->
                }
            }
           

            public override Color MenuItemBorder
            {
                get
                {
                    return Color.Red;   //---------------->
                }
            }

            public override Color MenuItemSelected
            {
                get
                {
                    return Color.FromArgb(255);   //---------------->
                }
            }

            public override Color MenuStripGradientBegin
            {
                get
                {
                    return Color.FromArgb(52, 71, 66);
                }
            }

            public override Color MenuStripGradientEnd
            {
                get
                {
                    return Color.FromArgb(52, 71, 66);
                }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get
                {
                    return Color.FromArgb(52, 71, 66);
                }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get
                {
                    return Color.FromArgb(52, 71, 66);
                }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get
                {
                    return Color.FromArgb(52, 71, 66);   //---------------->
                }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get
                {
                    return Color.FromArgb(51, 55, 56);
                }
            }




        }

        //------------------MENU DROP DOWN FOR SCREENSHOTS------RENDER---Custumized-Theme-----::END::-----------------------------------------------------------------------







        private void Main_Form1_Load(object sender, EventArgs e)
        {
            General_menuStrip.ForeColor = Color.FromArgb(0, 204, 255);//Color of the Menu Strip "General menu"
            screenshot_DropDown_menustrip.Renderer = new BrowserMenuRenderer(); // Custumized THEME For the DROP DOWN MENU FOR THE SCREENSHOTS
        }

    
  


         



   




        // Screenshot----------::START::------------------------------------------------------------------------------------------------------------------------------
  

         //Sound
         private void ScreenshotSound()
         {
            SoundPlayer sscreenshotSound = new SoundPlayer(@"C:\\Windows\Media\Windows Information Bar.wav");
            sscreenshotSound.Play();
         }



        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //  Screenhsot - Entire - Screen - AND - Type- Menu
            ScreenshotSound();
            screenshot = new Screenshot();
            screenshot.MakeScrenshot();
        }


        // Click-Button - Entire Screen
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            ScreenshotSound();
            screenshot = new Screenshot();
            screenshot.MakeScrenshot();
        }



        //Click-Button - Form
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ScreenshotSound();
            screenshot = new Screenshot();
            screenshot.MakeFormScreenshot();
        }


        //Selectin - Area - Button - Click
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            SoundPlayer screenSelectionButtonSound = new SoundPlayer(@"C:\Windows\Media\Windows Feed Discovered.wav");
            screenSelectionButtonSound.Play();


            SelectionScreenshot_Form4 SelectionScreenshotForm4 = new SelectionScreenshot_Form4();//SelectionScreenshotForm
            SelectionScreenshotForm4.Show();
        }


        // Screenshot----------::END::-----------------------------------------------------------------------------------------------------------------------------------------------------------------










        private void item_menu_button_Click(object sender, EventArgs e)
        {
               
            //activeControl = item_menu_panel;
        }

       






        //-------Top--BAR----<--,---->, Home, Etc.-------::START::-------------------------------------------------------------------------------------------------------------------------------------
          

        private void Loacal_Folder_button_Click(object sender, EventArgs e) // Open Default Folder
        {
            Process.Start("C://"); // Opens Default App - Directory with Screenshots, Pdf etc.
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\recycle.wav");
            simpleSound.Play();
        }
   
        //-------Top--BAR----<--,---->, Home, Etc.-------::END::-------------------------------------------------------------------------------------------------------------------------------------











        // General Menu Button Events---------"Advokater","Sager",Etc.--------::START::------------------------------------------------------------------------------------------------------------------

        private void HideAllForms()
        {
            AdvokaterForm3.Hide();
            SagerForm2.Hide();
        }



        private void sagerToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            //Forms for Hide "Hide all other Forms"
            HideAllForms();

            // Show SagerForm2
            SagerForm2.TopLevel = false;
            SagerForm2.AutoScroll = true;
            Loader_panel.Controls.Add(SagerForm2);
            SagerForm2.Show();
        }



        private void advokaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms for Hide "Hide all other Forms"
            HideAllForms();

            //Show AdvokaterForm3
            AdvokaterForm3.TopLevel = false;
            AdvokaterForm3.AutoScroll = true;
            Loader_panel.Controls.Add(AdvokaterForm3);
            AdvokaterForm3.Show();
        }

        private void toolStripMenuItem2_MouseEnter(object sender, EventArgs e)
        {
            toolStripMenuItem2.ShowDropDown();
        }


        // General Menu Button Events---::END::---------------------------------------------------------------------------------------------------------------------------------------------





    }
}
