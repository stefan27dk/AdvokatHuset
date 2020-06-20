using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace View_GUI
{
    public partial class Transparent_Form : Form
    {
   
        public Transparent_Form()
        {
            InitializeComponent();
            this.TopMost = false; // make the form always on top
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // hidden border
            //this.WindowState = FormWindowState.Maximized; // maximized
            //this.MinimizeBox = this.MaximizeBox = false; // not allowed to be minimized
            //this.MinimumSize = this.MaximumSize = this.Size; // not allowed to be resized
            this.TransparencyKey = this.BackColor = Color.Red; // the color key to transparent, choose a color that you don't use
        }

       

        private void Transparent_Form_Load(object sender, EventArgs e)
        {

            

        }


       

       

        private void Transparent_Form_MouseMove(object sender, MouseEventArgs e)
        {
            Point newLocation = PointToClient(Cursor.Position);
            panel1.Location = newLocation;
            this.Refresh();
        }

       


    }
}
