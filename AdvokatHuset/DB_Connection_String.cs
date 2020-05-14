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
        public string DBConnectionString = "Data source=BG-1-PC\\SQLEXPRESS; Database = Advokathuset; User Id = abc; Password = abc;"; // Connstring is just for testing, the coonectionstring will be assigned from a file
       
 

      
        // Constructor is protected
        public DB_Connection_String()
        {
            // lOADING LOCAL FILE HERE--->   // lOADING LOCAL FILE HERE:: With Connection String
            
        }

     

    }
}
