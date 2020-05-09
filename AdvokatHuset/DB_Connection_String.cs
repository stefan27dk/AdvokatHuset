using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class DB_Connection_String
    {
        public string DBConnectionString = "Data source=BG-1-PC\\SQLEXPRESS; Database = Advokathuset; User Id = abc; Password = abc;"; // Connstring is just for testing, the coonectiostring will be assigned from a file
        private static DB_Connection_String ConnectionStringInstance; // Singleton Instance
 



        // lOADING LOCAL FILE HERE--->   // lOADING LOCAL FILE HERE::

       



        // Constructor is protected
        protected DB_Connection_String()
        {

        }


        // Create Singleton instance if it is null or just return the existing one
        public static DB_Connection_String GetConnectionString()
        {
             if(ConnectionStringInstance == null)
             {
            
                  ConnectionStringInstance = new DB_Connection_String();
                 
             }

            return ConnectionStringInstance;

        }


    }
}
