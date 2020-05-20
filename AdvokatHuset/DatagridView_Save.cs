using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View_GUI
{
    class DatagridView_Save
    {

       

        DB_Connection_String Connection = new DB_Connection_String(); // SQL Connection Singleton 


        public DatagridView_Save()
        {

        }


         

            public void DatagridView_Update(string Query1, DataSet Dataset1, string TableName1, DataGridView Datagridview1)
            {

                 try
                 {
                       if(Connection.DBConnectionString != null)
                       {
                     
                              using (SqlConnection connection = new SqlConnection(new DB_Connection_String().DBConnectionString))// SQL Connection
                              {
                             
                                  //Kunde_dataGridView.EndEdit();
                                  SqlCommand Select_Command = new SqlCommand(Query1, connection);
                                  SqlDataAdapter Adapter1 = new SqlDataAdapter(Query1, connection);
                                  SqlCommandBuilder Builder1 = new SqlCommandBuilder(Adapter1);
                                  Adapter1.SelectCommand = Select_Command;
                                  Adapter1.Update(Dataset1, TableName1);
                             
                              }
                       }
                 }

                 catch (SqlException err)
                 {


                //MessageBox.Show(err.Number.ToString());
                //MessageBox.Show(err.ToString());


                       switch (err.Number)
                       {
                           case 547:
                           MessageBox.Show("Fejl: Fejlen kan skyldes fodi du prøver at slette en Række som er bindet til en anden tabel. " +
                               "Ex. Hvis du prøver på at slette en person den person har TLF-Nr som skal slettes først før du kan slette Personen. " +
                               "Fejlen kan også skyldes fordi den input du har givet er ikke korekt da det er en tabel som er forbundet til databasen skal der" +
                               " være værdier der eksister i Database FX: Post Nr skal eksister i Databasen før du kan oprette FX. Kunde med den bestemte Post Nr", "Fejl" , MessageBoxButtons.OK, MessageBoxIcon.Error );
                           break; 
                          case 515:
                           MessageBox.Show("Inputed var ikke korekt: Der er et tekstfelt: som ikke eksepter Tomt Input:  Null Exception", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error );
                           break;  
                          case 8152:
                           MessageBox.Show("Inputet var for lang", "Fejl" , MessageBoxButtons.OK, MessageBoxIcon.Error );
                           break;
                         default:
                        MessageBox.Show(err.ToString());

                        break;
                     
                       }

                      Datagridview1.RefreshEdit(); // Reset the current Cell to the previeous Value on Error
                      
                 }

          
           

                 
            }





    }
}
