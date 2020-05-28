using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Log_In_Info
    {

        private static Log_In_Info Log_In_Info_OBJ;  // Empty - Singleton - Instance

        public string Log_User_Name { get; set; }
        public string Log_Password { get; set; }
        public string Me_ID{ get; set; }
        public string Log_IN_Type { get; set; }



        // Protected Constructor
        protected Log_In_Info() { }




        // Get Singleton Instance
        public static Log_In_Info Get_Log_In_Info() // Method to get the existing instance or create new if it is null
        {
            if (Log_In_Info_OBJ == null)
            {
                Log_In_Info_OBJ = new Log_In_Info(); // If Instance is null we create it here and than return it --> next line down
            }


            return Log_In_Info_OBJ; // Get the instance
        }


        // Not Thread Safe
        // For Thread safe Singleton we just use object and lock

        //object thelock = new object();
        // lock(thelock)
        //{

        //    //Get Singleton Method Code Here- <-->

        //}






        // Write Log In  - To file
        private void Remember_Log_In()
        {
              

        }


   

        }
}
