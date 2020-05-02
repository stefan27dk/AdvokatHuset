using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View_GUI
{
    [System.ComponentModel.DesignerCategory("Code")]
   
    public class MyPanel: Panel
    {
        public Pen Border;
        public Color MyPanelBackgroundColor;



        public MyPanel()
        {
           
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            Border = Pens.Gray;
            
        }



        protected override void OnPaint(PaintEventArgs e)
        {
                using (SolidBrush brush = new SolidBrush(MyPanelBackgroundColor))// Inside Color of the Panel
                e.Graphics.FillRectangle(brush, ClientRectangle);
                e.Graphics.DrawRectangle(Border, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1); // Border Area
            //base.OnPaint(e);
        }
    }
}

  // Change the border Like this in the Main Form
//ItemPanel.Border = Pens.Aqua;
//ItemPanel.Refresh();