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

            // Transparent Form - Settings
            this.TopMost = false; // make the form always on top
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // hidden border
            this.TransparencyKey = this.BackColor = Color.Red; // the color key to transparent, choose a color that you don't use

        }

       

        private void Transparent_Form_Load(object sender, EventArgs e)
        {
          
        }


       

       
        // Move The Hole with the mouse so you can click trhu the Form
        private void Transparent_Form_MouseMove(object sender, MouseEventArgs e)
        {
            Point newLocation = PointToClient(Cursor.Position);
            pointer_hole_panel.Location = newLocation;
            this.Refresh();
        }

       


    }
}
