using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View_GUI
{
    class Load_Combobox
    {

        DB_Connection_String Connection = new DB_Connection_String(); // SQL Connection Singleton 

        public Load_Combobox(){}



        public ComboBox Populate_Combobox(string Query, ComboBox Loader_Combobox)
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
                return Loader_Combobox;
        }





        public TextBox PopulateTextbox(string Query, TextBox Loader_TextBox)
        {


            if (Connection.DBConnectionString != null)
            {
                using (SqlConnection conn = new SqlConnection(Connection.DBConnectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    SqlDataReader DataReader = cmd.ExecuteReader();


                    while(DataReader.Read())
                    {
                        Loader_TextBox.Text = DataReader[0].ToString();
                    }

                }

            }

            return Loader_TextBox;

        }





    }
}
