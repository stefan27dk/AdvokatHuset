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

        string Data_Query = "Select ((Select SUM(Y.Ydelse_Pris) From Tid As T Inner Join Ydelse As Y On T.Ydelse_Nr = Y.Ydelse_Nr Inner Join Sag AS S ON T.Sag_ID = S.Sag_ID Where Y.Ydelse_Type = 'Fast Pris' AND S.Sag_Afslutet = '1') + (Select SUM(T.Tid * Y.Ydelse_Pris) From Tid As T Inner Join Ydelse As Y On T.Ydelse_Nr = Y.Ydelse_Nr Inner Join Sag AS S ON T.Sag_ID = S.Sag_ID Where Y.Ydelse_Type = 'Time' AND S.Sag_Afslutet = '1'));
";

        // Classes
        private DB_Loader Load_Data;


        // Resources
        private TextBox Indkomst;
        private TextBox Me_salary;
        private TextBox Profit;

        public Statistics_Facade()
        {
            Load_Data = new DB_Loader();

        }
       



        // Get Data
        private void Get_Statistics_Data_From_DB(string  Query)
        {
            Load_Data.PopulateTextbox(Data_Query, );

        }


    }
}
