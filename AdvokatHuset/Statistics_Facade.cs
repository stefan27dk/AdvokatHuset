using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View_GUI;

namespace Domain
{
    class Statistics_Facade
    {

        //string Time_From { get; set; }
        //string Time_To { get; set; }

        //string Data_Query = $"Select ((Select SUM(Y.Ydelse_Pris) From Tid As T Inner Join Ydelse As Y On T.Ydelse_Nr = Y.Ydelse_Nr Inner Join Sag AS S ON T.Sag_ID = S.Sag_ID Where (Y.Ydelse_Type = 'Fast Pris' AND S.Sag_Afslutet = '1') AND S.Sag_Slut_Dato BETWEEN '{Time_From}' AND '{Time_To}' ) + (Select SUM(T.Tid * Y.Ydelse_Pris) From Tid As T Inner Join Ydelse As Y On T.Ydelse_Nr = Y.Ydelse_Nr Inner Join Sag AS S ON T.Sag_ID = S.Sag_ID Where (Y.Ydelse_Type = 'Time' AND S.Sag_Afslutet = '1') AND S.Sag_Slut_Dato BETWEEN '{Time_From}' AND '{Time_To}' ));";
        //string Me_Time = Select SUM(T.Tid) From Tid As T Where T.Tid_Dato BETWEEN '22-05-2020' AND '22-05-2020';


        // Classes
        private DB_Loader Load_Data;


        // Resources
        public string Indkomst { get; set; }
        public string Me_salary_Time { get; set; }
        public string Me_Total_Salary { get; set; } = "0";
        public decimal Hour_salary { get; set; } = 200;
        public decimal Fees { get; set; } = 0;
        public string Profit { get; set; }



        // Querys
        public string Me_Salary_Query { get; set; }
        public string Indkomst_Query { get; set; }




        public Statistics_Facade()
        {
            Load_Data = new DB_Loader();

        }
       




        // Get Statistics - MAIN
        public void Get_Statistics()
        {
            Get_Inkomst_Data_From_DB(); // Get Inkomst
            Get_Me_Salary(); // Get Me_Salary
            Calculate_Profit(); // Calculating
        }







        // Get Data - Inkomst
        private void Get_Inkomst_Data_From_DB()
        {
            Indkomst =  Load_Data.PopulateTextbox(Indkomst_Query);
        }





        // Me_Salary - "Løn"
        private void Get_Me_Salary()
        {
            Me_salary_Time = Load_Data.PopulateTextbox(Me_Salary_Query);

        }





        // Calculate Profit
        private void Calculate_Profit()
        {
            if(Me_salary_Time !="" && Indkomst !="")
            {
              Me_Total_Salary = (decimal.Parse(Me_salary_Time) * Hour_salary).ToString();
              Profit = (decimal.Parse(Indkomst) - (decimal.Parse(Me_Total_Salary) + Fees)).ToString();
            }

        }






    }
}
