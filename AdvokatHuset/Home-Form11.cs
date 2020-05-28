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
    public partial class Home_Form11 : Form
    {
        public Home_Form11()
        {
            InitializeComponent();
        }



        // Load
        private void Home_Form11_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            Browser_Settings();


        }







        private void Browser_Settings()
        {
           typeof(WebBrowser).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
           BindingFlags.Instance | BindingFlags.SetProperty, null,
           home_webBrowser, new object[] { true });
           home_webBrowser.ScriptErrorsSuppressed = true;
           this.home_webBrowser.Navigate("https://advokathuset.dk/medarbejdere/");
           //home_webBrowser.Focus();

        }




        // Search - Main Method
        private void Search()
        {
            this.home_webBrowser.Navigate(wbbeowser_Search_textBox.Text);
        }

           

        // Search Button
        private void web_browser_Search_button_Click(object sender, EventArgs e)
        {
            Search();
        }



        // Search ON Pressing Enter
        private void wbbeowser_Search_textBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter) // On Enter Search
            {
                Search();
            }
           
        }

     

   



        // Focus When the page is loaded
        private void home_webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            home_webBrowser.Focus();

        }



        // Focus Wbbrowser
        private void Home_Form11_MouseEnter(object sender, EventArgs e)
        {
            home_webBrowser.Focus();

        }
    }
}
