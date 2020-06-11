using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View_GUI
{
    public partial class DeveloperForm_Form12 : Form
    {
        DataSet DEV_DataSet;
        Datagridview_Loader Load_Script;

        public DeveloperForm_Form12()
        {
            InitializeComponent();
        }

        private void DeveloperForm_Form12_Load(object sender, EventArgs e)
        {
            DatagridviewSettings_Style(); // DGV - Settings
        }




        // Run - Button
        private void Run_button_Click(object sender, EventArgs e)
        {
            Run_Scrupt();
        }













         // Run Script
        private void Run_Scrupt()
        {
            //Script_richTextBox
            DEV_DataSet = new DataSet(); // 1# New Dataset - This will be the Source
            Load_Script = new Datagridview_Loader(); // Loader DGV Class


            Load_Script.DB_Populate(Script_richTextBox.SelectedText, DEV_DataSet, "DEV"); // Loader Method to Populate the Dataset
            Dev_dataGridView.DataSource = DEV_DataSet; // Datagridview Source is the Dataset that was populated in the Loader Class
            Dev_dataGridView.DataMember = "DEV"; // Data Member is the Part of the DataSet we want to read from "You can have different Datamembers in the same Dataset ans just switch trought them"
          
        }









        // Datagridview Settings - Style - Setting on Load
        private void DatagridviewSettings_Style()
        {

            Black_DatagridviewStyle();
            // Datagridview DOUBLE BUFFERING // Double Buffer is Used so the Datagridview dont lagg on resize
            //Set Double buffering on the Grid using reflection and the bindingflags enum.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            Dev_dataGridView, new object[] { true });
        }



        // Datagridview Color Style
        private void Black_DatagridviewStyle()
        {

            this.Dev_dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.Dev_dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 34);
            this.Dev_dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(59, 203, 255);  // Datagridview Fore Color
            this.Dev_dataGridView.GridColor = Color.Gray;
            this.Dev_dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold); // FONT    //, System.Drawing.GraphicsUnit.Point
            this.Dev_dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 94);
            this.Dev_dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 32, 29);

            //this.Advokat_dataGridView.DefaultCellStyle..Font = new System.Drawing.Font(FontFamily.GenericSerif, 9, System.Drawing.FontStyle.Bold);

        }













        }
    }
