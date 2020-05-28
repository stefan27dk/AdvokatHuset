using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace Domain
{
    abstract class Person
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Mail { get; set; }
        public int TlfNr { get; set; }
        public string Adresse { get; set; }
        public int PostNr { get; set; }

        public Person() //Constructor
        {

        }



        // Datagridview - Populate  // Data - Loader
        public void Person_Datagridview_Loader(string Query, DataSet Dataset1, string TableName)
        {
            Datagridview_Loader DAL_DGV_Loader = new Datagridview_Loader();
            DAL_DGV_Loader.DB_Populate(Query, Dataset1, TableName);
        }



        // Save Person_Data to DB // Datagridview Save
        public void Person_Save_DGV(string Query1, DataSet Dataset1, string TableName1, DataGridView Datagridview1)
        {
            DatagridView_Save Save_DGV = new DatagridView_Save();
            Save_DGV.DatagridView_Update(Query1, Dataset1, TableName1, Datagridview1);
        }



    }
}
