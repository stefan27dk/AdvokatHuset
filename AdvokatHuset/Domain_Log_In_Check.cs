using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View_GUI
{
    class Domain_Log_In_Check
    {

        public Domain_Log_In_Check() { }


        // Check Log In
        public bool Log_In_Check(string Log_Name, string log_Pass)
        {
            Validate_Log_In Log_in = new Validate_Log_In();
            return Log_in.Log_In_Check(Log_Name, log_Pass);
        }

    }
}
