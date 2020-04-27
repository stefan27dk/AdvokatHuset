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
            public override Color MenuItemSelectedGradientBegin  { get { return Color.FromArgb(255, 182, 110); } }
            public override Color MenuItemSelectedGradientEnd { get { return Color.FromArgb(69, 69, 69); } }
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
            
            General_Menu_Panel.BringToFront();// Advokate,Sager ETC. menu to top
            itemMenuPanelDropDown.BringToFront();//ItemMenuPanel
            General_menuStrip.ForeColor = Color.FromArgb(0, 204, 255);//Color of the Menu Strip "General menu"
            screenshot_DropDown_menustrip.Renderer = new BrowserMenuRenderer(); // Custumized THEME For the DROP DOWN MENU FOR THE SCREENSHOTS
        }














        // Screenshot----------::START::------------------------------------------------------------------------------------------------------------------------------


        // Screenshot Sound
        private void ScreenshotSound()
         {
            SoundPlayer sscreenshotSound = new SoundPlayer(@"C:\\Windows\Media\Windows Information Bar.wav");
            sscreenshotSound.Play();
         }


        // Screenshot Entire Screen Main - Method----"For Main button and Entire Screen button"
          private void ScreenshotEntireScreen()
          {
            //  Screenhsot - Entire - Screen - AND - Type- Menu
            ScreenshotSound();
            screenshot = new Screenshot();
            screenshot.MakeScrenshot();
          }



        // Main Screenshot Button --> Drop Down
        private void main_screenshot_button_Click(object sender, EventArgs e)
        {
            ScreenshotEntireScreen();
        }




        // Screenshot Click-Button - Entire Screen
        private void screenshotEntireScreen_button_Click(object sender, EventArgs e)
        {
            ScreenshotEntireScreen();

        }



        //Screenshot Click-Button - Form
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ScreenshotSound();
            screenshot = new Screenshot();
            screenshot.MakeFormScreenshot();
        }

 


        //Screenshot Selectin - Area - Button - Click
        private void selection_screenshot_button_Click(object sender, EventArgs e)
        {
            SoundPlayer screenSelectionButtonSound = new SoundPlayer(@"C:\Windows\Media\Windows Feed Discovered.wav");
            screenSelectionButtonSound.Play();

            SelectionScreenshot_Form4 SelectionScreenshotForm4 = new SelectionScreenshot_Form4();//SelectionScreenshotForm
            SelectionScreenshotForm4.Show();
        }






        // Main Screenshot button on Hover Show Drop Down
        private void main_screenshot_button_MouseEnter(object sender, EventArgs e)
        {
            main_screenshot_button.ShowDropDown();
        }

        // Screenshot----------::END::-----------------------------------------------------------------------------------------------------------------------------------------------------------------

           








  





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
        

        // General Menu Button Events---::END::---------------------------------------------------------------------------------------------------------------------------------------------







        //-----------------------------ITEM-Menu-------::START::------------------------------------------------------------------------------------------------------------------------------------------------------------------


        // Menu Open Button
        private void item_menu_button_Click_1(object sender, EventArgs e)  // SHow hide Item Menu
        {
            if(itemMenuPanelDropDown.Visible == false)
            {
            itemMenuPanelDropDown.Visible = true;
            item_menu_top_panel.Visible = true;
            }

            else
            {
                itemMenuPanelDropDown.Visible = false;
                item_menu_top_panel.Visible = false;
            }

        }




        // Open Calculator
        private void calculator_button_Click(object sender, EventArgs e) //Start Calculator
        {
             
            System.Diagnostics.Process calculatorProcess = System.Diagnostics.Process.Start("calc.exe");
            
        }



         // Open Paint
        private void open_paint_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process paintProcess = System.Diagnostics.Process.Start("mspaint.exe");
        }




        //Sound Recorder
        private void sound_recorder_button_Click(object sender, EventArgs e)
        {
          
          
        }




        //Open Browser
        private void open_browser_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http:\\google.com");
        }



        
        // Bell button 
        private void bell_button_Click(object sender, EventArgs e)
        {

            SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\Media\ding.wav");
            simpleSound.Play();
        }

         
        //-----------------------------ITEM-Menu-------::START::------------------------------------------------------------------------------------------------------------------------------------------------------------------






    }
}
