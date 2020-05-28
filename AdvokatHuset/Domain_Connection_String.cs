using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Domain_Connection_String
    {

       
        // Set Connection String
        public void SET_DAL_Connectionstring(string ConnString)
        {
            DB_Connection_String connection = DB_Connection_String.Get_Connection_String_Instance();
            connection.DBConnectionString = ConnString;
        }




    }
}
