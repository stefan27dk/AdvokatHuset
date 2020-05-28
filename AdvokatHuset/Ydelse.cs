using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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





        // Save Ydelse_Data to DB // Datagridview Save
        public void Ydelse_Save_DGV(string Query1, DataSet Dataset1, string TableName1, DataGridView Datagridview1)
        {
            DatagridView_Save Save_DGV = new DatagridView_Save();
            Save_DGV.DatagridView_Update(Query1, Dataset1, TableName1, Datagridview1);
        }

    }
}
