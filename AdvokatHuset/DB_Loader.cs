using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain
{
    class DB_Loader
    {

        // DB Connection
        DB_Connection_String Connection = DB_Connection_String.Get_Connection_String_Instance(); // SQL Connection 

        public DB_Loader(){}


        // Combobox Populate
        public ComboBox Populate_Combobox(string Query, ComboBox Loader_Combobox)
        {
            

            try
            {


                if(Connection.DBConnectionString != null)
                {
              
                     using (SqlConnection conn = new SqlConnection(Connection.DBConnectionString))
                     {
                    
                         conn.Open();
                        SqlCommand cmd = new SqlCommand(Query, conn);
                        SqlDataReader DataReader = cmd.ExecuteReader();
                    
                        while (DataReader.Read())
                        {
                             Loader_Combobox.Items.Add(DataReader[0]);
                        }
                    
                     }
                    
                }

            }

            catch(Exception e) { MessageBox.Show($"Fejl: {e.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                return Loader_Combobox;
        }




        // TextBox populate
        public string PopulateTextbox(string Query)
        {

            string Output = "";
            try
            {


                if (Connection.DBConnectionString != null)
                {
                    using (SqlConnection conn = new SqlConnection(Connection.DBConnectionString))
                    {

                        conn.Open();
                        SqlCommand cmd = new SqlCommand(Query, conn);
                        SqlDataReader DataReader = cmd.ExecuteReader();


                        while (DataReader.Read())
                        {
                            Output = DataReader[0].ToString();
                        }

                    }

                }

            }

            catch (Exception e) { MessageBox.Show($"Fejl: {e.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return Output;

        }





       


    }
}
