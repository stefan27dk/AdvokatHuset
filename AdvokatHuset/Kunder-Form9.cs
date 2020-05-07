using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace View_GUI
{
    public partial class Kunder_Form9 : Form
    {
       
        Kunde kundeinstance; // Instance af Kunde 
        DB_Connection_Write ConnWrite; // Sql Write "
        DB_Connection_String ConnectionString; // Global Connectionstring

        public Kunder_Form9()
        {
            InitializeComponent();
        }




        // Create Kunde
        private void CreateKunde()
        {
            kundeinstance = new Kunde();
            kundeinstance.Fornavn = kunder_name_textBox.Text;
            kundeinstance.Efternavn = kunder_surname_textBox.Text;
            kundeinstance.PostNr = Convert.ToInt32(kunder_zipcCode_textBox.Text);
            kundeinstance.Adresse = kunder_adr_textBox.Text;
            kundeinstance.TlfNr = Convert.ToInt32(kunder_tlf_textBox.Text);
            kundeinstance.Mail = kunde_email_textBox.Text;

        }



        // Insert to DB
        private void InsertToDB()
        {
            ConnectionString = new DB_Connection_String(); // Global ConnectionString
            ConnWrite = new DB_Connection_Write(); // "Write to DB Class instance"
            string KundeQuery = $"DECLARE @UNIQUEX UNIQUEIDENTIFIER SET @UNIQUEX = NEWID(); Insert into Kunde Values('{kundeinstance.Fornavn}','{kundeinstance.Efternavn}',{kundeinstance.PostNr},'{kundeinstance.Adresse}', (@UNIQUEX),'{kundeinstance.Mail}');"; // Query
            ConnWrite.CreateCommand(KundeQuery, ConnectionString.DBConnectionString); // Write to DB Input and "Execution"
        }


        // Save Button 
        private void kunder_Save_button_Click(object sender, EventArgs e)
        {
            CreateKunde(); 
            InsertToDB();
        }


    }
}
