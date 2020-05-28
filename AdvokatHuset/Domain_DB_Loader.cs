using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace Domain
{
    class Domain_DB_Loader
    {

        public Domain_DB_Loader() { }


        // Combobox Loader
        public ComboBox Populate_Combobox(string Query, ComboBox Loader_Combobox)
        {
            DB_Loader Combobox_Loader = new DB_Loader();
            return Combobox_Loader.Populate_Combobox(Query, Loader_Combobox);
        }






        // Textbox Loader 
        public string PopulateTextbox(string Query)
        {
            DB_Loader TextBox_Loader = new DB_Loader();
            return TextBox_Loader.PopulateTextbox(Query);
        }



    }
}
