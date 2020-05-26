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





          // Main Method --WORKER---FACADE------::::
          // Get Statistics
          private void Get_Statistics()
          {


            // Input
            Statistics_Facade Statistic = new Statistics_Facade();


                               
             //Variable      // IF ...this = true      than do this                    else 0
            Statistic.Fees = (fees_textBox.Text != "") ? decimal.Parse(fees_textBox.Text) : 0;  // One Line If Statement
            Statistic.Hour_salary = (Hour_Salary_textBox.Text !="") ? decimal.Parse(Hour_Salary_textBox.Text) : 0;
            Statistic.Me_Salary_Query = $"Select(ISNULL((Select SUM(T.Tid) From Tid As T Where Convert(datetime, T.Tid_Dato, 105) >= Convert(datetime, '{statistics_From_dateTimePicker.Value.ToShortDateString()}', 105) AND Convert(datetime, T.Tid_Dato, 105) <= Convert(datetime, '{statistics_To_dateTimePicker.Value.ToShortDateString()}', 105)),0));";
            Statistic.Indkomst_Query = $"SELECT (IsNull((Select SUM(Y.Ydelse_Pris) From Tid As T Inner Join Ydelse As Y On T.Ydelse_Nr = Y.Ydelse_Nr  Where (Y.Ydelse_Type = 'Fast Pris') AND Convert(datetime, T.Tid_Dato ,105) >= Convert(datetime, '{statistics_From_dateTimePicker.Value.ToShortDateString()}', 105) AND Convert(datetime, T.Tid_Dato ,105) <= Convert(datetime, '{statistics_To_dateTimePicker.Value.ToShortDateString()}', 105) ),0) + IsNull((Select SUM(T.Tid * Y.Ydelse_Pris) From Tid As T Inner Join Ydelse As Y On T.Ydelse_Nr = Y.Ydelse_Nr  Where (Y.Ydelse_Type = 'Time') AND Convert(datetime, T.Tid_Dato ,105) >= Convert(datetime, '{statistics_From_dateTimePicker.Value.ToShortDateString()}', 105) AND Convert(datetime, T.Tid_Dato ,105) <= Convert(datetime, '{statistics_To_dateTimePicker.Value.ToShortDateString()}', 105)), 0)) AS Total;";
            Statistic.Get_Statistics(); // Calculate

            // Output
            indkomst_textBox.Text = Statistic.Indkomst;
            Me_salary_textBox.Text = Statistic.Me_Total_Salary;
            profit_textBox.Text = Statistic.Profit;



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









            // Clear Textboxes -- Reset
            private void Clear_All_Loaded_Textboxes()
            {
               Me_salary_textBox.Clear();
               indkomst_textBox.Clear();
               profit_textBox.Clear();

            }








        // On Value Changed - Get The Statistic
        private void statistics_From_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Clear_All_Loaded_Textboxes(); // Clear
            Get_Statistics(); // Get Statistics
        }






        // On Value Changed - Get The Statistic
        private void statistics_To_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Clear_All_Loaded_Textboxes(); // Clear
            Get_Statistics(); // Get Statistics

        }






        // Omkostninger - Prevent Letters
        private void fees_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool have_comma = false;
            if (e.KeyChar != (char)8 && e.KeyChar != (char)26)/// "Allow backspace"  and CTRL+Z
            {
                e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out decimal isNumber);///Prevent letters
            }


            // Comma To Dot Convert
            if (e.KeyChar == (char)44)//If Comma
            {
                e.KeyChar = (char)46;
            }




            // Check for comma
            for (int i = 0; i < fees_textBox.Text.Length; i++)
            {
                int commaIndex = 0;

                if (fees_textBox.Text[i] == '.')
                {
                    commaIndex = i;
                    have_comma = true;

                 
                    // Max 2 digits after Comma
                    if (fees_textBox.Text.Length > commaIndex + 2 && e.KeyChar != (char)8)
                    {
                        e.Handled = true;
                    }

                }


            }

            if (e.KeyChar == (char)46 && have_comma == false && fees_textBox.Text != "")//If Comma and ther is no comma in the textbox than Add it
            {
                e.Handled = false;
            }
        }







        // Profit Textbox Color if Profit is negative
        private void profit_textBox_TextChanged(object sender, EventArgs e)
        {

                if (profit_textBox.Text != "" && profit_textBox.Text[0] == '-')
                {
                
                  profit_textBox.BackColor = Color.Red;
                }
                else
                {
                profit_textBox.BackColor = Color.FromArgb(255, 224, 192);

                }
        }














         // Medarbejder Hour - Salary - Prevent Letters
        private void Hour_Salary_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool have_comma = false;
            if (e.KeyChar != (char)8 && e.KeyChar != (char)26)/// "Allow backspace"  and CTRL+Z
            {
                e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out decimal isNumber);///Prevent letters
            }


            // Comma To Dot Convert
            if (e.KeyChar == (char)44)//If Comma
            {
                e.KeyChar = (char)46;
            }




            // Check for comma
            for (int i = 0; i < Hour_Salary_textBox.Text.Length; i++)
            {
                int commaIndex = 0;

                if (Hour_Salary_textBox.Text[i] == '.')
                {
                    commaIndex = i;
                    have_comma = true;


                    // Max 2 digits after Comma
                    if (Hour_Salary_textBox.Text.Length > commaIndex + 2 && e.KeyChar != (char)8)
                    {
                        e.Handled = true;
                    }

                }


            }

            if (e.KeyChar == (char)46 && have_comma == false && Hour_Salary_textBox.Text != "")//If Comma and ther is no comma in the textbox than Add it
            {
                e.Handled = false;
            }
        }






        // Fees On Textchanged Load Calculation
        private void fees_textBox_TextChanged(object sender, EventArgs e)
        {
            Get_Statistics();
        }





        // Medarbejder Salary - Load Calculations on TextChanged
        private void Hour_Salary_textBox_TextChanged(object sender, EventArgs e)
        {
            Get_Statistics();
        }


        // Reset All Button
        private void reset_all_button_Click(object sender, EventArgs e)
        {
            Clear_All_Inputs();
        }





         // Clear The Inputs
        private void Clear_All_Inputs()
        {
            fees_textBox.Clear();
            Hour_Salary_textBox.Clear();
        }
    }
}
