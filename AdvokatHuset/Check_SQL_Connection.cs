using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Domain
{
    class Check_SQL_Connection
    {

        public Check_SQL_Connection() { }



        public bool Check_My_SQL_Connection()
        {

            DAL_Check_Connection conn = new DAL_Check_Connection();
           return conn.Check_Connection();

        }
    }
}
