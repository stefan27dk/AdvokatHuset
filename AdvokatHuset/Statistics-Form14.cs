using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View_GUI
{
    public partial class Statistics_Form14 : Form
    {
        public Statistics_Form14()
        {
            InitializeComponent();
        }




        // Load
        private void Statistics_Form14_Load(object sender, EventArgs e)
        {
            statistics_From_dateTimePicker.Value = DateTime.Today.AddMonths(-1);
            Date_Time_Picker_Settings();
        }



           private void Date_Time_Picker_Settings()
           {
             // From
            statistics_From_dateTimePicker.MaxDate = DateTime.Today;



            // To
            statistics_To_dateTimePicker.MinDate = statistics_From_dateTimePicker.Value;
            statistics_To_dateTimePicker.MaxDate = DateTime.Today;



           }













        //----------Date Time Pickers---Limits--Settings----::START::----------------------------------------------------------

        //  Date Time Picker From - Settings
        private void statistics_From_dateTimePicker_Enter(object sender, EventArgs e)
        {
            Date_Time_Picker_Settings();
        }




        // Date Time Picker To
        private void statistics_To_dateTimePicker_Enter(object sender, EventArgs e)
        {
            Date_Time_Picker_Settings();
        }

        //----------Date Time Pickers---Limits--Settings----::END::----------------------------------------------------------









    }
}
