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

namespace AdvokatHuset
{

    public partial class Main_Form1 : Form
    {    
        Sager_Form2 SagerForm2 = new Sager_Form2();
        Advokater_Form3 AdvokaterForm3 = new Advokater_Form3();

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



        private void sagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms for Hide "Hide all other Forms"
            AdvokaterForm3.Hide();

            // Show SagerForm2
            SagerForm2.TopLevel = false;
            SagerForm2.AutoScroll = true;
            Loader_panel.Controls.Add(SagerForm2);
            SagerForm2.Show();
        }



         
        private void advokatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms for Hide "Hide all other Forms"
            SagerForm2.Hide();

            //Show AdvokaterForm3
            AdvokaterForm3.TopLevel = false;
            AdvokaterForm3.AutoScroll = true;
            Loader_panel.Controls.Add(AdvokaterForm3);
            AdvokaterForm3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Loader_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Screenshot_button_Click(object sender, EventArgs e)
        {
            

            Rectangle bounds = Screen.GetBounds(Point.Empty);

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {

                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }


                

                bitmap.Save($"C://ScreenShot - {DateTime.Now.ToString("dd-MM-yyyy  HH-mm-ss")}.jpg", ImageFormat.Png);// Screenshot -  Unique Name so it dont get overwrited everytime new screenshot is made



            }




        }

        private void Loacal_Folder_button_Click(object sender, EventArgs e)
        {
            Process.Start("C://");
        }
    }
}
