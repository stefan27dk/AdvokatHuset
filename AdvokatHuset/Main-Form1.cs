﻿using System;
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
        Medarbejder_Form6 MedarbejderForm6 = new Medarbejder_Form6();// Form 6  '
        Sekretaer_Form7 SekretaerForm7 = new Sekretaer_Form7();// Form 7
        Ydelser_Form8 YdelserForm8 = new Ydelser_Form8();// Form 8
        Kunder_Form9 KunderForm9 = new Kunder_Form9(); // Form 9
        Koersel_Form10 KoerselForm19 = new Koersel_Form10(); // Form 10

        //Forms--::END::

        Screenshot screenshot; // Screenshot 
 



                                      

        public Main_Form1()
        {

            InitializeComponent();
            
         
        }

          




        //General_menustrip-Custumized-Theme-------::Start::----------------------------------------------------------------------------------------------
        private class MyRenderer: ToolStripProfessionalRenderer
        {
              public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable  //Overriding Colors
        {   
            
            // Drop Down Background - Right
            public override Color ToolStripDropDownBackground { get { return Color.FromArgb(64, 63, 61); }}// Drop Down Right background

            public override Color MenuItemSelected { get { return Color.FromArgb(128, 122, 111); } }// Selected item color
            public override Color MenuItemSelectedGradientBegin  { get { return Color.FromArgb(255, 182, 110); } }
            public override Color MenuItemSelectedGradientEnd { get { return Color.FromArgb(69, 69, 69); } }
            public override Color MenuItemPressedGradientBegin { get { return Color.FromArgb(52, 71, 66); } }
            public override Color MenuItemPressedGradientEnd { get { return Color.FromArgb(51, 55, 56); } }
            public override Color ImageMarginGradientBegin { get { return Color.FromArgb(52, 71, 66); } }
            public override Color ImageMarginGradientMiddle { get { return Color.FromArgb(58, 58, 64); } }
            public override Color ImageMarginGradientEnd { get { return Color.FromArgb(48, 48, 54); } }

            //Drop Down Border
            public override Color MenuBorder { get { return Color.FromArgb(255, 183, 89); } }
        }
        //General_menustrip-Custumized-Theme-------::END::----------------------------------------------------------------------------------------------



                               



        //------------------MENU DROP DOWN FOR SCREENSHOTS------RENDER---Custumized-Theme-----::START::-----------------------------------------------------------------------
        public class BrowserMenuRenderer : ToolStripProfessionalRenderer
        {
            public BrowserMenuRenderer() : base(new BrowserColors()) { }
        }


        public class BrowserColors : ProfessionalColorTable
        {

            
            public override Color ToolStripDropDownBackground { get { return Color.FromArgb(48, 48, 54); }  } // Drop Down Background - Right

            public override Color ImageMarginGradientBegin { get { return Color.FromArgb(52, 71, 66); } }

            public override Color ImageMarginGradientMiddle { get { return Color.FromArgb(58, 58, 64); } }

            public override Color ImageMarginGradientEnd { get { return Color.FromArgb(48, 48, 54); } }

            public override Color MenuBorder { get { return Color.Red; } } //Drop Down Border

            public override Color MenuItemBorder { get { return Color.Red; } }

            public override Color MenuItemSelected { get { return Color.FromArgb(255); } }

            public override Color MenuStripGradientBegin { get { return Color.FromArgb(52, 71, 66); } }

            public override Color MenuStripGradientEnd { get { return Color.FromArgb(52, 71, 66); } }

            public override Color MenuItemSelectedGradientBegin { get { return Color.FromArgb(52, 71, 66); } }

            public override Color MenuItemSelectedGradientEnd { get { return Color.FromArgb(52, 71, 66); } }

            public override Color MenuItemPressedGradientBegin {  get { return Color.FromArgb(52, 71, 66);   } }    

            public override Color MenuItemPressedGradientEnd { get { return Color.FromArgb(51, 55, 56); } }
 
        }


        //------------------MENU DROP DOWN FOR SCREENSHOTS------RENDER---Custumized-Theme-----::END::-----------------------------------------------------------------------







        //Form Load
        private void Main_Form1_Load(object sender, EventArgs e)
        {
            screenshotButton_back_panel.BringToFront();
            itemMenuPanelDropDown.BringToFront();//ItemMenuPanel
            screenshot_DropDown_menustrip.Renderer = new BrowserMenuRenderer(); // Custumized THEME For the DROP DOWN MENU FOR THE SCREENSHOTS
            General_menuStrip.Renderer = new MyRenderer(); // Used for General_menuStrip to change the "Selection Background Color" "Renderer"
            General_menuStrip.ForeColor = Color.FromArgb(0, 204, 255);//Color of the Menu Strip "General menu"
            General_Menu_Panel.BringToFront();// Advokate,Sager ETC. menu to top
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
            Size size = new Size();   // New Size
            size.Width = 55;
             
            main_screenshot_button.ShowDropDown();
            main_screenshot_button.DropDown.MaximumSize = size;
        }

        // Screenshot----------::END::-----------------------------------------------------------------------------------------------------------------------------------------------------------------

           




    





        //-------Top--BAR----<--,---->, Home, Etc.-------::START::-------------------------------------------------------------------------------------------------------------------------------------
          

            // Open Local Folder --- Main Method
          private void OpenLocalFolder()
          {
            screenshot = new Screenshot();
            Process.Start($@"{screenshot.ScreenshotSavePath}"); // Opens Default App - Directory with Screenshots, Pdf etc.
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\recycle.wav");
            simpleSound.Play();
          }




        // Open Local Folder Button
        private void Loacal_Folder_button_Click(object sender, EventArgs e) // Open Default Folder
        {
            OpenLocalFolder();// Main Method
        
        }





        // Bell button 
        private void bell_button_Click(object sender, EventArgs e)
        {

            SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\Media\ding.wav");
            simpleSound.Play();
        }

        //-------Top--BAR----<--,---->, Home, Etc.-------::END::-------------------------------------------------------------------------------------------------------------------------------------








        // General Menu Button Events---------"Advokater","Sager",Etc.--------::START::------------------------------------------------------------------------------------------------------------------

        // Hide All Forms
        private void HideAllForms()
        {
            SagerForm2.Hide();
            AdvokaterForm3.Hide();
            MedarbejderForm6.Hide();
            SekretaerForm7.Hide();
            YdelserForm8.Hide();
            KunderForm9.Hide();
            KoerselForm19.Hide();

        }








         //Sager
        private void sagerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Forms for Hide "Hide all other Forms"
            HideAllForms();

             // Show SagerForm2
            SagerForm2.TopLevel = false;
            Loader_panel.Controls.Add(SagerForm2);
            SagerForm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SagerForm2.Dock = DockStyle.Fill;
            SagerForm2.Show();
      
        }








        //Advokater
        private void advokaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms for Hide "Hide all other Forms"
            HideAllForms();
 
            // SHow AdvokaterForm3
            AdvokaterForm3.TopLevel = false;
            Loader_panel.Controls.Add(AdvokaterForm3);
            AdvokaterForm3.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            AdvokaterForm3.Dock = DockStyle.Fill;
            AdvokaterForm3.Show();
      

        }


 



        // Medarbejder
        private void medarbejder_item_Click(object sender, EventArgs e)
        {
            //Forms for Hide "Hide all other Forms"
            HideAllForms();

            MedarbejderForm6.TopLevel = false;
            Loader_panel.Controls.Add(MedarbejderForm6);
            MedarbejderForm6.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MedarbejderForm6.Dock = DockStyle.Fill;
            MedarbejderForm6.Show();
        }



 


        //Sekretær
        private void sekretærToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms for Hide "Hide all other Forms"
            HideAllForms();

            SekretaerForm7.TopLevel = false;
            Loader_panel.Controls.Add(SekretaerForm7);
            SekretaerForm7.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SekretaerForm7.Dock = DockStyle.Fill;
            SekretaerForm7.Show();
        }






        // Ydelser  
        private void ydelserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms for Hide "Hide all other Forms"
            HideAllForms();

            YdelserForm8.TopLevel = false;
            Loader_panel.Controls.Add(YdelserForm8);
            YdelserForm8.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            YdelserForm8.Dock = DockStyle.Fill;
            YdelserForm8.Show();
        }





        // Kunder
        private void kunderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms for Hide "Hide all other Forms"
            HideAllForms();// Dont Forget to add the Form in the Hide Method: So on Form change this will hide and other Form will apear

            KunderForm9.TopLevel = false;
            Loader_panel.Controls.Add(KunderForm9);
            KunderForm9.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            KunderForm9.Dock = DockStyle.Fill;
            KunderForm9.Show();
        }





        // Kørsel
        private void kørselToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms for Hide "Hide all other Forms"
            HideAllForms();

            KoerselForm19.TopLevel = false;
            Loader_panel.Controls.Add(KoerselForm19);
            KoerselForm19.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            KoerselForm19.Dock = DockStyle.Fill;

            KoerselForm19.Show();
        }

        // General Menu Button Events---::END::---------------------------------------------------------------------------------------------------------------------------------------------












        //-----------------------------ITEM-Menu-------::START::------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private void OpenItemMenu() // The menu with tools, Claculator, timer, setting, etc.
          {

            if (itemMenuPanelDropDown.Visible == false)
            {
                itemMenuPanelDropDown.Visible = true;
                item_menu_top_panel.Visible = true;
            }

            else
            {
                itemMenuPanelDropDown.Visible = false;
                item_menu_top_panel.Visible = false;
            }

            // Open Close Sound
            SoundPlayer clicksound = new SoundPlayer(@"C:\Windows\Media\Windows Navigation Start.wav");
            clicksound.Play();

        
          }







        //Shortcut keys for Opening Item Menu
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            // Open Item Menu Shortcut
            if (keyData == (Keys.Control | Keys.G))
            {
                OpenItemMenu();
            }

            // Open Folder Shortcut
            if (keyData == (Keys.Control | Keys.F))
            {
                OpenLocalFolder();// FOLDER
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }








        // Item Menu Open Button
        private void item_menu_button_Click_1(object sender, EventArgs e)  // SHow hide Item Menu
        {
            OpenItemMenu();

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



        // ToolTip - Item Menu 
        private void item_menu_button_MouseHover(object sender, EventArgs e)
        {
       
            ToolTip ItemMenuToolTip = new ToolTip();
            ItemMenuToolTip.AutoPopDelay = 3000;
            ItemMenuToolTip.InitialDelay = 500;
            ItemMenuToolTip.ReshowDelay = 1000;
            ItemMenuToolTip.ShowAlways = true;

            ItemMenuToolTip.SetToolTip(item_menu_button, "CTRL + G");
       
 
        }

 
        //-----------------------------ITEM-Menu-------::START::------------------------------------------------------------------------------------------------------------------------------------------------------------------




        // ToolTIP - Local Folder 
        private void Loacal_Folder_button_MouseHover(object sender, EventArgs e)
        {
            ToolTip localFolderToolTip = new ToolTip();

            localFolderToolTip.AutoPopDelay = 3000;
            localFolderToolTip.InitialDelay = 500;
            localFolderToolTip.ReshowDelay = 1000;
            localFolderToolTip.ShowAlways = true;

            localFolderToolTip.SetToolTip(Loacal_Folder_button, "CTRL + F");

        }



    }
}
