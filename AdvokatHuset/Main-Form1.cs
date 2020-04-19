using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void Main_Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void sagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms for Hide "Hide all other Forms"
            AdvokaterForm3.Hide();

            // Show SagerForm2
            SagerForm2.TopLevel = false;
            SagerForm2.AutoScroll = true;
            Panel_Loader.Controls.Add(SagerForm2);
            SagerForm2.Show();
        }



         
        private void advokatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms for Hide "Hide all other Forms"
            SagerForm2.Hide();

            //Show AdvokaterForm3
            AdvokaterForm3.TopLevel = false;
            AdvokaterForm3.AutoScroll = true;
            Panel_Loader.Controls.Add(AdvokaterForm3);
            AdvokaterForm3.Show();
        }
    }
}
