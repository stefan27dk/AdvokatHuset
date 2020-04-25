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
using Domain;

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

          



        //General_menustrip-Custumized-Theme  ::Start::----------------------------------------------------------------------------------------------
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
        //General_menustrip-Custumized-Theme  ::END::----------------------------------------------------------------------------------------------



 


        private void Main_Form1_Load(object sender, EventArgs e)
        {
            General_menuStrip.ForeColor = Color.FromArgb(0, 204, 255);
            //General_menuStrip.Font = new Font(FontFamily.GenericSansSerif, 11.0F, FontStyle.Bold);

        }

    
  


       

       

        private void Loader_panel_Paint(object sender, PaintEventArgs e)
        {
        }





        // Screenshot----------::START::------------------------------------------------------------------------------------------------------------------------------
        private void Screenshot_button_Click(object sender, EventArgs e) //Screenshot
        {
            
            screenshot.MakeScrenshot();
        }


        private void screenshotForm_button_Click(object sender, EventArgs e)
        {
             
            screenshot.MakeFormScreenshot();
        }



        private void selectAreaScreenshot_button_Click(object sender, EventArgs e)
        {
            SelectionScreenshot_Form4 SelectionScreenshotForm4 = new SelectionScreenshot_Form4();//SelectionScreenshotForm
            SelectionScreenshotForm4.Show();
        }
        // Screenshot----------::END::------------------------------------------------------------------------------------------------------------------------------





        private void Loacal_Folder_button_Click(object sender, EventArgs e) // Open Default Folder
        {
            Process.Start("C://"); // Opens Default App - Directory with Screenshots, Pdf etc.
        }



        // General Menu Button Events---::START::

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

        private void item_menu_button_Click(object sender, EventArgs e)
        {
            item_menu_panel.Visible = true;

            //activeControl = item_menu_panel;
        }

 

        

        // General Menu Button Events---::END::
    }
}
