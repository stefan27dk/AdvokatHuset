using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View_GUI
{
    public class My_RichTextBox : RichTextBox
    {

        public My_RichTextBox() { }



        protected override CreateParams CreateParams
        {
            get
            {
                //This makes the control's background transparent
                CreateParams CP = base.CreateParams;
                CP.ExStyle |= 0x20;
                return CP;
            }
        }


    }
}
