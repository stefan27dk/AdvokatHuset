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
                     
                              using (SqlConnection connection = new SqlConnection(new DB_Connection_String().DBConnectionString))// SQL Connection
                              {
                             
                                  //Kunde_dataGridView.EndEdit();
                                  SqlCommand Select_Command = new SqlCommand(Query, connection);
                                  SqlDataAdapter Adapter1 = new SqlDataAdapter(Query, connection);
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
