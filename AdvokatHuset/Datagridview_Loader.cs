using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
                
namespace DAL
{
    class Datagridview_Loader
    {
        // DB Connection
        DB_Connection_String Connection = DB_Connection_String.Get_Connection_String_Instance(); // SQL Connection

        public Datagridview_Loader()
        {
           
        }


        public void DB_Populate(string Query, DataSet Dataset1, string TableName)
        {
             
            try
            {
                 if(Connection.DBConnectionString != null)
                 {

                    using (SqlConnection connection = new SqlConnection(Connection.DBConnectionString))// SQL Connection
                    {
                        //Kunde_Dataset.Clear(); // Clear all rows so we begin on fresh datagridview "If We dont do that the old Data will remain and the new data will be inserted at the bottom of the datagridview"
                        connection.Open();
                        SqlDataAdapter Adapter = new SqlDataAdapter(Query, connection); 
                        Adapter.Fill(Dataset1, TableName);
                        connection.Close();
                        //Kunde_dataGridView.DataSource = Kunde_Dataset;
                        //Kunde_dataGridView.DataMember = "Kunde";
                    }

                 }
            }
            catch(Exception err)
            {
                if(TableName != "DEV")  // Show Message Box Error by Default
                {
                  MessageBox.Show(err.Message.ToString());
                }

                else  // If DEV Mode Than Show it in The Datagridview
                {
                    DataTable ErrorTable = Dataset1.Tables.Add("DEV");
                    ErrorTable.Columns.Add("Error");
                    ErrorTable.Rows.Add(err.Message.ToString());
                    ErrorTable.Dispose();


                }

            }

        }


    }
}
