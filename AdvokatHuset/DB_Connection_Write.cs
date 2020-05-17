using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain
{
    class DB_Connection_Write
    {

        DB_Connection_String Connection = new DB_Connection_String(); // SQL Connection Singleton 

        bool successful = false;
        
        public bool CreateCommand(string Query)
        {
            try
            {
                if (Connection.DBConnectionString != null)
                {
                    using (SqlConnection connection = new SqlConnection(new DB_Connection_String().DBConnectionString))
                    {
                        SqlCommand command = new SqlCommand(Query, connection);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }

                    successful = true; // Succesfull Transaction


                }
            }

                // Get Information about the Exception        
               catch (Exception e) { MessageBox.Show($"{e.Message} \t {e.InnerException} \t {e.Data} \t {e.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

               return successful;
        }

  
    }
}
