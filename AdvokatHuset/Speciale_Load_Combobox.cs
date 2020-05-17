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
    class Speciale_Load_Combobox
    {

        DB_Connection_String Connection = new DB_Connection_String(); // SQL Connection Singleton 

        public Speciale_Load_Combobox(){}



        public ComboBox Populate_Combobox_Speciale(string Query, ComboBox speciale_Combobox)
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
                       speciale_Combobox.Items.Add(DataReader[0]);
                   }
               
                }
               
           }
                return speciale_Combobox;
        }
    }
}
