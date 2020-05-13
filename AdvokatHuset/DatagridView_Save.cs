using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View_GUI
{
    class DatagridView_Save
    {
        DB_Connection_String Connection = new DB_Connection_String(); // SQL Connection Singleton 


        public DatagridView_Save()
        {

        }


         

            public void DatagridView_Update(string Query, DataSet Dataset1, string TableName)
            {

                 try
                 {
                       if(Connection.DBConnectionString != null)
                       {
                       
                              using (Connection.Get_SQL_Conn_Instance())// SQL Connection
                              {
                             
                                  //Kunde_dataGridView.EndEdit();
                                  SqlCommand Select_Command = new SqlCommand(Query, Connection.Get_SQL_Conn_Instance());
                                  SqlDataAdapter Adapter1 = new SqlDataAdapter(Query, Connection.Get_SQL_Conn_Instance());
                                  SqlCommandBuilder Builder1 = new SqlCommandBuilder(Adapter1);
                                  Adapter1.SelectCommand = Select_Command;
                                  Adapter1.Update(Dataset1, TableName);
                             
                              }
                       }
                 }

                 catch (Exception err)
                 {
                     MessageBox.Show(err.Message.ToString());
                 }


            }





    }
}
