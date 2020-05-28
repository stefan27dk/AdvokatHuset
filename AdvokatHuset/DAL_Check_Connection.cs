using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DAL_Check_Connection
    {


         // Check SQL Connection DAL
        public bool Check_Connection()
        {
            // Sql Connection String Check
            DB_Connection_String connection = DB_Connection_String.Get_Connection_String_Instance();

            if (connection.DBConnectionString != "")
            {

                using (SqlConnection DBconnection = new SqlConnection(connection.DBConnectionString))
                {
                    try
                    {
                        DBconnection.Open();
                        return true;
                    }

                    catch (SqlException)
                    {
                        return false;
                    }

                }

            }

            else
            {
                return false;
            }
        }



    }
}
