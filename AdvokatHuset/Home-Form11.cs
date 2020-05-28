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
            wbbeowser_Search_textBox.Text = home_webBrowser.Url.AbsoluteUri;
             

        }






        // Focus Wbbrowser
        private void Home_Form11_MouseEnter(object sender, EventArgs e)
        {
            home_webBrowser.Focus();

        }







        // Webbrowser Go Back
        private void browser_back_button_Click(object sender, EventArgs e)
        {
            home_webBrowser.GoBack();

        }




      
    
        // Webbrowser Go Forward
        private void Webbrowser_Go_Forward_button_Click(object sender, EventArgs e)
        {
            home_webBrowser.GoForward();

        }





        // Web - Browser - Home
        private void Web_Browser_Home_button_Click(object sender, EventArgs e)
        {
           this.home_webBrowser.Navigate("https://advokathuset.dk/medarbejdere/");

        }







        // Browser_Show_ Google
        private void web_browser_google_button_Click(object sender, EventArgs e)
        {
            home_webBrowser.Navigate("google.com");
        }







        // Clear Textbox on CTRL + Left mouse button
        private void wbbeowser_Search_textBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                wbbeowser_Search_textBox.Clear();
            }
           
        }




        // Tool Tip For Search
        private void Search_Tool_Tip()
        {
            ToolTip Search_ToolTip = new ToolTip();
            Search_ToolTip.AutoPopDelay = 3000;
            Search_ToolTip.InitialDelay = 500;
            Search_ToolTip.ReshowDelay = 1000;
            Search_ToolTip.ShowAlways = true;

            Search_ToolTip.SetToolTip(wbbeowser_Search_textBox, "CTRL + Mouse Left Button for Clear");
        }





        // Search Tool Tip
        private void wbbeowser_Search_textBox_MouseHover(object sender, EventArgs e)
        {
            Search_Tool_Tip();
        }
    }

}
