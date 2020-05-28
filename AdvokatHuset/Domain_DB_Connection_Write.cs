using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Domain_DB_Connection_Write
    {

       public Domain_DB_Connection_Write() { }



        // Write to DB
        public bool CreateCommand(string Query)
        {
            DB_Connection_Write ConnWrite = new DB_Connection_Write();
            return ConnWrite.DAL_CreateCommand(Query);

        }

    }
}
