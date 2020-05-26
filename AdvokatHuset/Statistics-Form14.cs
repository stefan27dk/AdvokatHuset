using Domain;
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
            statistics_From_dateTimePicker.Value = DateTime.Today.AddMonths(-1);// Start Date Date Time Picker
            Date_Time_Picker_Settings(); // Date Time Picker Date

            Get_Statistics(); // Get Statistics
        }






          // Get Statistics
          private void Get_Statistics()
          {


            // Input
            Statistics_Facade Statistic = new Statistics_Facade();
            Statistic.Indkomst = indkomst_textBox; // Indkomst
            Statistic.Me_salary_Time = Me_salary_textBox; // Me_Salary



            if (Hour_Salary_textBox.Text.Length > 0)
            {
                Statistic.Hour_salary = decimal.Parse(Hour_Salary_textBox.Text); // Me_Salary
            }

            if (fees_textBox.Text.Length > 0)
            {
                Statistic.Fees = decimal.Parse(fees_textBox.Text); // Fees

            }

            

            Statistic.Profit = profit_textBox; // Profit
            Statistic.Me_Salary_Query = $"Select(ISNULL((Select SUM(T.Tid) From Tid As T Where Convert(datetime, T.Tid_Dato, 105) >= Convert(datetime, '{statistics_From_dateTimePicker.Value.ToShortDateString()}', 105) AND Convert(datetime, T.Tid_Dato, 105) <= Convert(datetime, '{statistics_To_dateTimePicker.Value.ToShortDateString()}', 105)),0));";
            Statistic.Indkomst_Query = $"SELECT (IsNull((Select SUM(Y.Ydelse_Pris) From Tid As T Inner Join Ydelse As Y On T.Ydelse_Nr = Y.Ydelse_Nr  Where (Y.Ydelse_Type = 'Fast Pris') AND Convert(datetime, T.Tid_Dato ,105) >= Convert(datetime, '{statistics_From_dateTimePicker.Value.ToShortDateString()}', 105) AND Convert(datetime, T.Tid_Dato ,105) <= Convert(datetime, '{statistics_To_dateTimePicker.Value.ToShortDateString()}', 105) ),0) + IsNull((Select SUM(T.Tid * Y.Ydelse_Pris) From Tid As T Inner Join Ydelse As Y On T.Ydelse_Nr = Y.Ydelse_Nr  Where (Y.Ydelse_Type = 'Time') AND Convert(datetime, T.Tid_Dato ,105) >= Convert(datetime, '{statistics_From_dateTimePicker.Value.ToShortDateString()}', 105) AND Convert(datetime, T.Tid_Dato ,105) <= Convert(datetime, '{statistics_To_dateTimePicker.Value.ToShortDateString()}', 105)), 0)) AS Total;";
            Statistic.Get_Statistics(); // Calculate

            // Output
            indkomst_textBox.Text = Statistic.Indkomst.Text;
            Me_salary_textBox.Text = Statistic.Me_Total_Salary.Text;
            profit_textBox.Text = Statistic.Profit.Text;



          }














        //----------Date Time Pickers---Limits--Settings----::START::----------------------------------------------------------

        //  Date Time Picker From - Settings
        private void statistics_From_dateTimePicker_Enter(object sender, EventArgs e)
        {
            Date_Time_Picker_Settings();

        }





        // Date Time Picker Limitiations  - Main Method
           private void Date_Time_Picker_Settings()
           {
             // From
            statistics_From_dateTimePicker.MaxDate = DateTime.Today;



            // To
            statistics_To_dateTimePicker.MinDate = statistics_From_dateTimePicker.Value;
            statistics_To_dateTimePicker.MaxDate = DateTime.Today;
           
           }






        // Date Time Picker To
        private void statistics_To_dateTimePicker_Enter(object sender, EventArgs e)
        {
            Date_Time_Picker_Settings();
        }





        //----------Date Time Pickers---Limits--Settings----::END::----------------------------------------------------------










            private void Clear_All_Textboxes()
            {
               Me_salary_textBox.Clear();
               indkomst_textBox.Clear();
               profit_textBox.Clear();

            }








        // On Value Changed - Get The Statistic
        private void statistics_From_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Clear_All_Textboxes(); // Clear
            Get_Statistics(); // Get Statistics
        }






        // On Value Changed - Get The Statistic
        private void statistics_To_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Clear_All_Textboxes(); // Clear
            Get_Statistics(); // Get Statistics

        }





    }
}
