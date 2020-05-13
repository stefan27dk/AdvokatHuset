using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class DB_Connection_String
    {
        // This should = null; IT will be assigned int the Constructor from a local file
        public string DBConnectionString = "Data source=BG-1-PC\\SQLEXPRESS; Database = Advokathuset; User Id = abc; Password = abc;"; // Connstring is just for testing, the coonectiostring will be assigned from a file
        public static SqlConnection My_SQLconnection; // Singleton
 




       



        // Constructor is protected
        public DB_Connection_String()
        {
            // lOADING LOCAL FILE HERE--->   // lOADING LOCAL FILE HERE:: With Connection String
            
        }


        // Create Singleton instance if it is null or just return the existing one
        public SqlConnection Get_SQL_Conn_Instance()
        {
          
            My_SQLconnection = new SqlConnection(DBConnectionString);
            return My_SQLconnection;
        }


    }
}
