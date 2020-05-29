using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace View_GUI
{
    public partial class World_Clock_Form13 : Form
    {

        // My World Clock
        System.Windows.Forms.Timer timer1;





        // Thread
        Thread Clock_Thread;

        // Lock OBJ
        readonly object Lock_Obj = new object(); // The Thread Lock Object


        // Delaegate
        public delegate void CLock_Delegate(String SF_Clock, string KB_Clock);








        // Initialize
        public World_Clock_Form13()
        {
            InitializeComponent();
        }







        // Load
        private void World_Clock_Form13_Load(object sender, EventArgs e)
        {

            Populate_Combobx();
            World_Time();
            My_Timer();
            Thread_Clock(); // Verdens Ur Opggave
        }






        //------VerdensUR - Opgave------::START::--------------------------------------

        // Thread Method
        private void Thread_Clock()
        {

            Clock_Thread = new Thread(Update_Time);
            Clock_Thread.IsBackground = true; // Background Thread gets closed when the Application "Form" is closed - // Foreground thread continues and tries to do its job done even if we close the Application "Form" 
            Clock_Thread.Start();

        }

       
            
    
        // Update Clock - Time
        public void Update_Time()
            {
                   
     
                       lock (Lock_Obj)
                       {

                                 while(true) // The Thread is Background Thread and will be disposed on Form Close
                                 {
                                   
                                   string SF_Time = DateTime.Now.AddHours(-9).ToShortTimeString(); // San Francisco
                                   string KB_Time = DateTime.Now.ToShortTimeString(); // København - Time
                                   Update_View(SF_Time, KB_Time);
                                   Thread.Sleep(60000);

                                 }

                             
                          
                             void Update_View(string SF, string KB)
                             {
                                 CLock_Delegate c_delegate = new CLock_Delegate(Update_Clocks);
                                 Invoke(c_delegate, SF, KB);
                            
                             }
                          



                             void Update_Clocks(string SF_Clock, string KB_Clock)
                             {
                               San_Francisco_Time_textBox.Text = SF_Clock; // San Francisco
                               KB_clock_textBox.Text = KB_Clock; // København - Time
                             }

                           
                       }
                  
     
                 


         


            }


        //------VerdensUR - Opgave------::END::--------------------------------------


          


       // Populate Rest_world_Combobox
       private void Populate_Combobx()
             {

              rest_world_clocks_comboBox.Items.Add("England");
              rest_world_clocks_comboBox.Items.Add("Kina");
              rest_world_clocks_comboBox.Items.Add("Bulgarien");
              rest_world_clocks_comboBox.Items.Add("Vietnam");
              rest_world_clocks_comboBox.Items.Add("Spanien");
              rest_world_clocks_comboBox.SelectedIndex = 0;
        
             }


          
      
        // Timer 
        private void My_Timer()
              {
              
                timer1 = new System.Windows.Forms.Timer();
                timer1.Interval = 1000;
                timer1.Tick += new EventHandler(timer_Tick);
                timer1.Enabled = true;
                timer1.Start();

            // Tick
            void timer_Tick(object sender, EventArgs e)
            {
                World_Time();
            }


        }



        // Get World Time
        private void World_Time()
        {
            string time_For_selected_country = "";

            switch(rest_world_clocks_comboBox.SelectedIndex)
            {

                case 0:// England
                    time_For_selected_country = DateTime.Now.AddHours(-1).ToLongTimeString();
                    break; 
                case 1: // China
                    time_For_selected_country = DateTime.Now.AddHours(+6).ToLongTimeString();
                    break;
                case 2: //Bulgaria
                    time_For_selected_country = DateTime.Now.AddHours(+1).ToLongTimeString();
                    break;
                case 3: // Vietnam
                    time_For_selected_country = DateTime.Now.AddHours(+5).ToLongTimeString();
                    break;     
                case 4: // Spain
                    time_For_selected_country = DateTime.Now.ToLongTimeString();
                    break;


            }

            rest_world_clock_textBox.Text = time_For_selected_country;


        }


        
       

    }
}
