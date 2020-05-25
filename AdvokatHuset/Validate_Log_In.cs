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

        // Log In Info
        Log_In_Info log_In_Info = Log_In_Info.Get_Log_In_Info();


        // DB Connection
        DB_Connection_String Connection = DB_Connection_String.Get_Connection_String_Instance(); // SQL Connection   

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


                        while (reader.Read())
                        {
                            if (reader["Log_In_Navn"].ToString() == Log_Name.Text && reader["Log_In_Pass"].ToString() == log_Pass.Text)
                            {
                                Log_In_valid = true; // Log In Validated

                                log_In_Info.Log_User_Name = Log_Name.Text;
                                log_In_Info.Log_Password = log_Pass.Text;

                                Medarbejder_Get_Info(Log_Name.Text, log_Pass.Text); // Get Me_ID and Me_Type

                                break;
                            }
                        }


                    }


                }
                catch (Exception e)
                {
                    MessageBox.Show($"Fejl: {e.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }


            return Log_In_valid;

        }
















        // Get Medarbejder Info
        private void Medarbejder_Get_Info(string Log_Name, string Log_Pass)
        {


            if (Connection.DBConnectionString != null)
            {

                try
                {

                    using (SqlConnection conn = new SqlConnection(Connection.DBConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand($"Select L.Me_ID, M.Me_Type From Log_In As L Inner Join Medarbejder As M On L.Me_ID = M.Me_ID Where L.Log_In_Navn ='{Log_Name}' And L.Log_In_Pass = '{Log_Pass}';", conn);
                        SqlDataReader reader = cmd.ExecuteReader();


                        while (reader.Read())
                        {
                            log_In_Info.Me_ID = reader[0].ToString();// Medarbejder Id
                            log_In_Info.Log_IN_Type = reader[1].ToString(); // Medarbejder Type
                        }


                    }


                }
                catch (Exception e)
                {
                    MessageBox.Show($"Fejl: {e.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }













        }
    }
}
