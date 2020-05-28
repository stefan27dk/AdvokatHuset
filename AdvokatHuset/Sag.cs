using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Domain
{
    class Sag:Omkostninger
    {
        
        public string AdvokatID { get; set; }
        public string KundeID { get; set; }
        public string Oprets_Dato { get; set; }
        public string SagType { get; set; }
        public bool Afslutet { get; set; }

        public Sag() //Constructor
        {

        }


         // Data Loader 
        public void Sag_Datagridview_Loader(string Query, DataSet Dataset1, string TableName)
        {
            Datagridview_Loader DAL_DGV_Loader = new Datagridview_Loader();
            DAL_DGV_Loader.DB_Populate(Query, Dataset1, TableName);
        }




    }
}
