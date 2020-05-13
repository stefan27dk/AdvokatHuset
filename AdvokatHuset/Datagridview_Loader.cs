﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
namespace View_GUI
{
    class Datagridview_Loader
    {
        DB_Connection_String Connection = new DB_Connection_String(); // SQL Connection Singleton 
       
        public Datagridview_Loader()
        {
           
        }


        public void DB_Populate(string Query, DataSet Dataset1, string TableName)
        {

            try
            {
                 if(Connection.DBConnectionString != null)
                 {

                    using (Connection.Get_SQL_Conn_Instance())// SQL Connection
                    {
                        //Kunde_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"
                        Connection.Get_SQL_Conn_Instance().Open();
                        SqlDataAdapter Adapter = new SqlDataAdapter(Query, Connection.Get_SQL_Conn_Instance()); 
                        Adapter.Fill(Dataset1, TableName);
                        Connection.Get_SQL_Conn_Instance().Close();
                        //Kunde_dataGridView.DataSource = Kunde_Dataset;
                        //Kunde_dataGridView.DataMember = "Kunde";
                    }

                 }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }

        }


    }
}
