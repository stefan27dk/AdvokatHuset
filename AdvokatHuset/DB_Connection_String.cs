using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DB_Connection_String
    {
        public string DBConnectionString { get; set; } = "";  /*"Data source=BG-1-PC\\SQLEXPRESS; Database = Advokathuset; User Id = abc; Password = abc;";*/ // Connstring is just for testing, the coonectionstring will be assigned from a file

        private static DB_Connection_String ConnString_Instance = null;



        // Constructor is protected
        protected DB_Connection_String()
        {  }

     
        
        // Get Singleton Instance
        public static DB_Connection_String Get_Connection_String_Instance()
        {
            if(ConnString_Instance == null)
            {
                ConnString_Instance = new DB_Connection_String();
            }

            return ConnString_Instance;
        }

        

    }
}
