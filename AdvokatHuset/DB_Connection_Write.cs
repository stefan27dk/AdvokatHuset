﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain
{
    class DB_Connection_Write
    {
        bool successful = false;
        
        public bool CreateCommand(string queryString, string connectionString)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                successful = true; // Succesfull Transaction

           
            }

                // Get Information about the Exception        
               catch (Exception e) { MessageBox.Show($"{e.Message} \t {e.InnerException} \t {e.Data}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return successful;
        }

  
    }
}
