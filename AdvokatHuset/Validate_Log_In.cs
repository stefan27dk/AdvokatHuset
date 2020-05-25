using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
namespace View_GUI
{
    class Validate_Log_In
    {

        DB_Connection_String Connection = new DB_Connection_String(); // SQL Connection   

        public Validate_Log_In() { }




            public bool Log_In_Check(TextBox Log_Name, TextBox log_Pass)
            {
                bool Log_In_valid = false;

                
                if (Connection.DBConnectionString != null)
                {

                        try
                        {

                            using (SqlConnection conn = new SqlConnection(Connection.DBConnectionString))
                            {
                             conn.Open();
                             SqlCommand cmd = new SqlCommand("Select Log_In_Navn, Log_In_Pass From Log_IN", conn);
                             SqlDataReader reader = cmd.ExecuteReader();


                                   while(reader.Read())
                                   {
                                       if(reader["Log_In_Navn"].ToString() == Log_Name.Text && reader["Log_In_Pass"].ToString() == log_Pass.Text)
                                       {
                                          Log_In_valid = true;
                                          break;
                                       }
                                   }
                                 
                              
                            }


                        }
                        catch(Exception e)
                        {
                           MessageBox.Show($"Fejl: {e.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                                
              
                
                }


               return Log_In_valid;

            }
          

        

    }
}
