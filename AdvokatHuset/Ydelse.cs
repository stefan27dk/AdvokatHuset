using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Ydelse
    {
        //private int YdelseNr { get; set; }
        public string Navn { get; set; }
        public double Pris { get; set; }
        public string Type { get; set; }
        public string Art { get; set; }
        public string Oprets_Dato { get; set; }

        public Ydelse() //Constructor
        {

        }



        // Data Loader
        public void Ydelse_Datagridview_Loader(string Query, DataSet Dataset1, string TableName)
        {
            Datagridview_Loader DAL_DGV_Loader = new Datagridview_Loader();
            DAL_DGV_Loader.DB_Populate(Query, Dataset1, TableName);
        }

    }
}
