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

                using (Connection.Get_SQL_Conn_Instance())
                {
                    SqlCommand command = new SqlCommand(Query, Connection.Get_SQL_Conn_Instance());
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                successful = true; // Succesfull Transaction

           
            }

                // Get Information about the Exception        
               catch (Exception e) { MessageBox.Show($"{e.Message} \t {e.InnerException} \t {e.Data}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return successful;
        }

  
    }
}
