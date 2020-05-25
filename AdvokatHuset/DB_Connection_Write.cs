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

        // DB Connection
        DB_Connection_String Connection = DB_Connection_String.Get_Connection_String_Instance(); // SQL Connection
        


        
        bool successful = false;
        
        public bool CreateCommand(string Query)
        {
            try
            {
                if (Connection.DBConnectionString != null)
                {
                    using (SqlConnection connection = new SqlConnection(Connection.DBConnectionString))
                    {
                        SqlCommand command = new SqlCommand(Query, connection);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }

                    successful = true; // Succesfull Transaction


                }
            }

                // Get Information about the Exception        
            catch (SqlException e) 
            {


                switch(e.Number)
                 {
                    case 8134:
                        MessageBox.Show("Fokeret ID", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 8169:
                        MessageBox.Show("Forkert Input: Fejlen kan skyldes fx. forkeret \"ID\"", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 2627:
                        MessageBox.Show("Forkert Input: Fejlen kan skyldes fx. Tomt \"Input\"", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 547:
                        MessageBox.Show("Forkert Input", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                  MessageBox.Show($"{e.Number.ToString()} \t {e.Message} \t {e.InnerException} \t {e.Data} \t {e.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }


          

            }

               return successful;
        }       

          
    }
}
