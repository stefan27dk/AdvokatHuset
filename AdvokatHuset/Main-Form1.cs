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
using System.Reflection;

namespace View_GUI
{
  


    public partial class Main_Form1 : Form
    {
        // Local Folder
        string LocalFolderPath = "C:\\";

        //Forms--::START::
        Sager_Form2 SagerForm2 = new Sager_Form2();  //Form2
        Advokater_Form3 AdvokaterForm3 = new Advokater_Form3();//Form3
        Medarbejder_Form6 MedarbejderForm6 = new Medarbejder_Form6();// Form 6  '
        Sekretaer_Form7 SekretaerForm7 = new Sekretaer_Form7();// Form 7
        Ydelser_Form8 YdelserForm8 = new Ydelser_Form8();// Form 8
        Kunder_Form9 KunderForm9 = new Kunder_Form9(); // Form 9
        Koersel_Form10 KoerselForm10 = new Koersel_Form10(); // Form 10
        Home_Form11 HomeForm11 = new Home_Form11();// Start
        DeveloperForm_Form12 DeveloperForm12 = new DeveloperForm_Form12();//DEV

        //Forms--::END::

        Screenshot screenshot; // Screenshot 
        List<Form> formList = new List<Form>();  // Form List: Used to go back to the previews Form that was opened
        int formMinus1 = 0;
        bool itemClicked = false;
      

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
            // Other Properties for the menustrip colors
            //https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.professionalcolortable?view=netcore-3.1
            

            // Drop Down Background - Right
            public override Color ToolStripDropDownBackground { get { return Color.FromArgb(64, 63, 61); }}// Drop Down Right background

            public override Color MenuItemSelected { get { return Color.FromArgb(92, 92, 92); } }// Selected item color
            public override Color MenuItemBorder { get { return Color.FromArgb(70, 70, 80); } }// ITEM BORDER
            public override Color MenuItemSelectedGradientBegin  { get { return Color.FromArgb(255, 182, 110); } }
            public override Color MenuItemSelectedGradientEnd { get { return Color.FromArgb(52, 52, 52); } }
            public override Color MenuItemPressedGradientBegin { get { return Color.FromArgb(52, 71, 66); } }
            public override Color MenuItemPressedGradientEnd { get { return Color.FromArgb(51, 55, 56); } }
            public override Color ImageMarginGradientBegin { get { return Color.FromArgb(52, 71, 66); } }
            public override Color ImageMarginGradientMiddle { get { return Color.FromArgb(58, 58, 64); } }
            public override Color ImageMarginGradientEnd { get { return Color.FromArgb(48, 48, 54); } }
            public override Color SeparatorLight { get { return Color.Red; } }

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

           

            Home();// Start Form in the Loader_Panel
            formList.Add(HomeForm11);

           


            MovingItempanels();// Moving Panels
            //screenshotButton_back_panel.BringToFront();
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
             
            Process.Start(LocalFolderPath); // Opens Default App - Directory with Screenshots, Pdf etc.
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
            KoerselForm10.Hide();
            HomeForm11.Hide();
            DeveloperForm12.Hide();

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

            KoerselForm10.TopLevel = false;
            Loader_panel.Controls.Add(KoerselForm10);
            KoerselForm10.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            KoerselForm10.Dock = DockStyle.Fill;

            KoerselForm10.Show();
        }

        // General Menu Button Events---::END::---------------------------------------------------------------------------------------------------------------------------------------------

        
            
            
        //Top Menu Bar Left------::START::--------------------------------------------------------------------------------------------------------------------------------------------------
        // Home
        private void Home_Button_Click(object sender, EventArgs e)
        {
            Home(); // Main Method forHome
        }


        private void Home()// Main Method Home
        {
            //Forms for Hide "Hide all other Forms"
            HideAllForms();

            HomeForm11.TopLevel = false;
            Loader_panel.Controls.Add(HomeForm11);
            HomeForm11.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            HomeForm11.Dock = DockStyle.Fill;
            HomeForm11.Show();
        }

        //Top Menu Bar Left------::END::---------HomeForm11-----------------------------------------------------------------------------------------------------------------------------------------















        //Shortcut keys -----KEY WATCHER- ----SHORTCUT KEYS----------------::START::------------------------------------------------------------------------------------
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

        //Shortcut keys -----KEY WATCHER- ----SHORTCUT KEYS----------------::END::------------------------------------------------------------------------------------














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



        // Developer Button " tem Menu"
        private void developer_button_Click(object sender, EventArgs e)
        {
            //Forms for Hide "Hide all other Forms"
            HideAllForms();

            DeveloperForm12.TopLevel = false;
            Loader_panel.Controls.Add(DeveloperForm12);
            DeveloperForm12.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            DeveloperForm12.Dock = DockStyle.Fill;
            DeveloperForm12.Show();

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
















 

        // Form History of Opening-------ADDING TO LIST------------------::START::---------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        // Back - Button - History
        private void Back_Button_Click(object sender, EventArgs e)
        
        {

            // Add the last Form if the Item menu was last Clicked "not the back and forward button"
            if (itemClicked == true)
            {
                itemClicked = false;
                AddFormToList(); // Add the current Form to List   "Doing it like that because the Item Click is triggered before Loader_panel shows the Form and the last form is not added"
                formMinus1 = formMinus1 + 1;// Because we added Form to the list
            }





            if (formMinus1 < formList.Count - 1)///////////////////// formMinus1 is the the value of going back " It should be less than the list Size"
            {
                formMinus1 = formMinus1 + 1; // If it is less than the list siz than + 1
            }





            if (formMinus1 > 0 && formMinus1 < formList.Count)// minimum = 0 and maximum = the last item in the list "formList.Count -1"
            {
                HideAllForms(); // Hide ALL    
                Form lastForm = formList[(formList.Count) - formMinus1]; // Value Back "The value is stored at the top and Reseted when Item in the Menu is Clicked
               lastForm.Show();
 
            }




        }








        // Forward Button --- History
        private void Forward_Button_Click(object sender, EventArgs e)
        {
 
            if (formMinus1 < formList.Count && formMinus1 > 1)
            {
                formMinus1 = formMinus1 - 1;// Going up "the formMinus1 is positive and we a are minusing it so when it goes to the list it will show the later form than before
                HideAllForms(); // Hide ALL

                Form lastForm = formList[formList.Count - formMinus1]; // Value Back "The value is stored at the top and Reseted when Item in the Menu is Clicked
                lastForm.Show();
            }
   
        }








        // Item Clicked --- Add to list
        private void General_menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            itemClicked = true;// Now When we Press the back button the Current form in the Loader_panel will be added to the list "The Item Clicked is triggered before the Loader_panel show a form that is why we are nottaking the last form when we press the back button
            AddFormToList();// Add the Form to List
        }







         // MAIN - METHOD - Add Form From the Loader_panel to the formList
        private void AddFormToList()
        {
            formMinus1 = 0;// Reset Focus View in the listForm so you start again from the last form looking down

            Form lastOpenedForm; // Get the Form before the current one



            for (int i = 0; i < Loader_panel.Controls.Count; i++)
            {


                if (Loader_panel.Controls[i] is Form) // Loop Controls of the Loaderpanel - "Contols are the tings that are in the Loader panel" Ex: Forms, buttons, textboxes. etc. if they are placed in the panel, the panel have their controls like LoaderPanel.Controls.Add(Form1);
                {
                    lastOpenedForm = (Form)Loader_panel.Controls[i];

              

                    if (lastOpenedForm.Visible && lastOpenedForm != formList[formList.Count-1])// If the Form is visible than it is the one we are looking at " the others are hidden" 
                    {
                        //MessageBox.Show(lastOpenedForm.Name, "1", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Used for testing
                        formList.Add(lastOpenedForm); // Add to List
                    }

                }


            }

 

        }

        // Form History of Opening--------------ADDING TO LIST------------::END::---------------------------------------------------------------------------------------------------------------------------------------------------------------------------











        // MovingItemPanels----------------------------::START::---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



         private void MovingItempanels()
        {
            //Panel a = new Panel();
            //a.BackColor = Color.Red;
            //a.Height = 30;
            //a.Width = 40;
        
        }


     
        // Add Timer
        private void timer_button_Click(object sender, EventArgs e)
        {

          
            MovingItemPanels MyMovingTimer = new MovingItemPanels();// using Moving Panels Class

            // Holder Panels
            MyMovingTimer.LoaderPanel = Loader_panel;
            MyMovingTimer.TaskbarPanel = task_bar_panel;


            // ITEM PANEL
            MyMovingTimer.ItemPanel.Location = new System.Drawing.Point(30, 100);//Added panel Location
            //MovingPanels.ItemPanel.MaximumSize = new Size(300, 100);
            MyMovingTimer.ItemPanel.Size = new Size(300, 150);
            MyMovingTimer.ItemPanel.MyPanelBackgroundColor = Color.FromArgb(94, 54, 74);
            MyMovingTimer.ItemPanel.BorderStyle = BorderStyle.FixedSingle;
            //TaskPanel.Padding = new Padding(200);
            //ItemPanel.Tag = TaskbarPanel.Controls.Count + 1;


            // MiniPanel
            MyMovingTimer.MiniPanelTask();

            //LABEL
            //IMAGE
            MyMovingTimer.minipanelLabel.Image = new Bitmap(Properties.Resources._42608_stopwatch_icon, new Size(20, 20));
            MyMovingTimer.minipanelLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            //TEXT
            MyMovingTimer.minipanelLabel.Text = "Timer";
            MyMovingTimer.minipanelLabel.TextAlign = ContentAlignment.BottomRight;
            MyMovingTimer.minipanelLabel.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point
            MyMovingTimer.minipanelLabel.ForeColor = Color.FromArgb(245, 200, 66);

            // Add ITEM PANEL
            MyMovingTimer.AddItemPanel();
            MyMovingTimer.ItemPanel.BringToFront();// Show on top of everything in the Loader Panel


        }



    



        // MovingItemPanels----------------------------::END::---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



    }
}
