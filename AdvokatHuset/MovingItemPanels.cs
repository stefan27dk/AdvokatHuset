using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Reflection;

namespace View_GUI
{
    class MovingItemPanels
    {
        public Button AddButton { get; set; }
        public Panel LoaderPanel { get; set; }
        public Panel TaskbarPanel { get; set; }

        public Control Add_Object { get; private set; }


        /////CLEAN
        // Item Panel - Settings 
        //public int ItemPanelSize { get; set; }
        //public Color ItemPanelBackground { get; set; }// Background
        //public Panel ItemPanelAddControls { get; set; } // Adding content to the panel
        //public int ItemPanelLocationX {get; set;}
        //public int ItemPanelLocationY {get; set;}
        /////CLEAN

     

        // Item Panel - Relations
        private Control activeControl;
        private Point Start_TaskPanel;
        public  MyPanel ItemPanel = new MyPanel();//Added task panel
        



        // Mini Panel - Relations
        public MyPanel miniPanel {get; set;}// Mini task Panel
        private Control MiniActiveControl;
        public Label minipanelLabel;



        // Top menu
        Panel topmenu;


  

        public MovingItemPanels() // Constructor
        {
            Add_Object = this.ItemPanel;
            
        }

  


 



        //---------MiniPanel------------------::START::-----------------------------------------------------------------------------------------------------------------

        // The Mini Panel
        public void MiniPanelTask()
        {

            // MiniPanel Demensions
            miniPanel = new MyPanel();//Added task panel
            //miniPanel.MaximumSize = new Size(40, 10);
            miniPanel.Size = new Size(100, 30);
            miniPanel.BackColor = Color.FromArgb(79, 79, 79);
            miniPanel.BorderStyle = BorderStyle.FixedSingle;
            miniPanel.Tag = this.miniPanel;
            miniPanel.Tag1 = this.ItemPanel;
            //miniPanel.Margin = new Padding(5, 5, 5, 5);
            //miniPanel.Padding = new Padding(2);




            //MiniPanel Event Handlers
            miniPanel.MouseDown += new MouseEventHandler(miniPanel_MouseDown);///Added panel Declaring MouseDown
            miniPanel.MouseUp += new MouseEventHandler(miniPanel_MouseUp);///Added panel Declaring MouseUp
            //miniPanel.Location = new System.Drawing.Point(LastMini.Location.X + 110, LastMini.Location.Y);


            // Added Position
            if(TaskbarPanel.Controls.Count != 0)
            {
               miniPanel.Location  = new System.Drawing.Point(TaskbarPanel.Controls[TaskbarPanel.Controls.Count -1].Location.X + 110, TaskbarPanel.Controls[TaskbarPanel.Controls.Count -1].Location.Y);// Add 110px to this mini panel so its not over the previous
            }
            else
            {
                miniPanel.Location = new System.Drawing.Point(10, 10); // First Panel add it 10px X axis and 10px Y axis
            }

            MiniPanelINFO(); // Add the content of the MiniPanel



            // Add the Mini Panel to the Loader Panel
            TaskbarPanel.Controls.Add(miniPanel);// Add it to the Taskbarpanel
   
        }

    





          // MiniPanel INFO
          private void MiniPanelINFO()
          {
            minipanelLabel = new Label();
            minipanelLabel.Width = 80;
            minipanelLabel.Height = 20;
            minipanelLabel.Location = new Point(10,2);
            minipanelLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(miniPanel_MouseDown);
            miniPanel.Controls.Add(minipanelLabel);
         
          }






        // MiniPanels ---EVENTS-------------------::START::--------------------------------------------------------------------------------------------------------------------------------------------------------

        // Mini Panels MouseDown
        private void miniPanel_MouseDown(object sender, MouseEventArgs e)
        {

            MiniActiveControl = sender as Control; // Get the clicked panel
            Cursor.Current = Cursors.Hand; 
            ItemPanel.BringToFront();// Show on Top of all



            // Show -  Hide Item Panel
            if (ItemPanel.Visible == true)
            {
                ItemPanel.Visible = false;
                MiniPanelLastClickedPanelBorder();// ORANGE -  Make the mini Panel border Orange  - Minipanel related to the Hided ItemPanel

            }

            else
            {
                ItemPanel.Visible = true;
                ChangeBorderColorOfAllOtherItemPanels();// Item Panel Inactive panels border becomes blue and the active Green

                // Make the Active miniPanels border green
                MiniPanelBorderInActive();
                MiniPanelBorderActive();
            }

            OpenedPanelsMiniPanelBorder();

            // CLEAN
            //MiniPanelBorderOnActive();////////////////////////////////////TEST
            //miniPanel.Border = Pens.Lime;    ////////////////////////////TEST
            //miniPanel.Refresh(); /////////TEST
        }




        // MiniPanels Mouse Up    
        private void miniPanel_MouseUp(object sender, MouseEventArgs e)
        {
            MiniActiveControl = sender as Control;
            MiniActiveControl = null;
            Cursor.Current = Cursors.Default;
        }





        // Mini Item Panel Border Inactive
        private void MiniPanelBorderInActive()  
        {
            // Inactive mini panels make them Red
            for (int i = 0; i < TaskbarPanel.Controls.Count; i++)
            {
                if (TaskbarPanel.Controls[i] != miniPanel)
                {
                    MyPanel a = (MyPanel)TaskbarPanel.Controls[i];

                    a.Border = Pens.Red;

                    a.Refresh();
                    LoaderPanel.Controls[i].Tag = a;

                }


            }
            //CLEAN
            // Active mini panel make it green

            //miniPanel.Border = Pens.Lime;    ////////////////////////////TEST
            //miniPanel.Refresh();
            //CLEAN

        }







        // MiniPanel Active Border Color
        private void MiniPanelBorderActive()
        {
            miniPanel.Border = Pens.Lime;   
            miniPanel.Refresh();
        }    
        
 
        

        
        // MiniPanel Last Clicked Panel Border Color
        private void MiniPanelLastClickedPanelBorder()
        {
            // Check all object for Orange border if there are than make it red except for the current mini panel
            for (int i = 0; i < TaskbarPanel.Controls.Count; i++)
            {
                if (TaskbarPanel.Controls[i] != miniPanel)
                {
                    MyPanel a = (MyPanel)TaskbarPanel.Controls[i]; // Convert the object from Control to Type MyPanel and use the "tag" to assign it "The tag is a reference to a object that the current object holds" in this case it refers to itself, the tag is made when the object was made

                     // Reset all other orange colors
                    if (a.Border.Color == Color.Orange)
                    {
                
                    a.Border = Pens.Red;
                    a.Refresh();// Refresh it so the border apears
                    LoaderPanel.Controls[i].Tag = a;


                    }


                }


            }



            miniPanel.Border = Pens.Orange;   
            miniPanel.Refresh();
        }






     
        // FOR All opened windowses Minipanels turns blue border
        private void OpenedPanelsMiniPanelBorder()
        {


            for(int i = 0; i < LoaderPanel.Controls.Count; i++)
            {

                if(LoaderPanel.Controls[i] is MyPanel && LoaderPanel.Controls[i].Visible == true && LoaderPanel.Controls[i] != ItemPanel)
                {
                    MyPanel currentPanel = (MyPanel)LoaderPanel.Controls[i]; // Get The ItemPanel as MyPanel type

                    MyPanel CurrentMiniPanel = (MyPanel)currentPanel.Tag1; // Get the miniPanel that is related to this ItemPanel

                    CurrentMiniPanel.Border = new Pen(Color.FromArgb(66, 188, 245));
                    CurrentMiniPanel.Refresh();

                }


            }
             
        }


        // MiniPanels ---EVENTS-------------------::END::--------------------------------------------------------------------------------------------------------------------------------------------------------























        //------------ItemPanel--Workplace::------::START::------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        // Background - Exit, Minimize - Top of the Moving panel "Item panel" <------THIS IS ONLY BACKGROUND of the top menu------->
        private void ItemPanelTopMenu()
        {
            topmenu = new Panel();
            topmenu.BackColor = Color.FromArgb(76, 85, 99);
            topmenu.BorderStyle = BorderStyle.FixedSingle;
            topmenu.Dock = DockStyle.Top;
            topmenu.Height = 20;

             // Eventhandlers on this panel transfers the events to the Item Panel so we can move it around when we hold on this topmenu "Panel"
            topmenu.MouseDown += new MouseEventHandler(ItemPanel_MouseDown);///Added panel Declaring MouseDown
            topmenu.MouseMove += new MouseEventHandler(ItemPanel_MouseMove);///Added panel Declaring MouseMove
            topmenu.MouseUp += new MouseEventHandler(ItemPanel_MouseUp);///Added panel Declaring MouseUp

            ItemPanel.Controls.Add(topmenu); // Add the top menu to the Item panel

        }












       //---EXIT-Button------::START::-----------------------------------------------------------------------------------------------------
        // ItemPanel Exit Button
        private void ExitButton()
        {
            Button exitButton = new Button();
            exitButton.Location = new Point(ItemPanel.Width - 25, 0);
            exitButton.Width = 20;
            exitButton.Height = 20;
            exitButton.BackgroundImage = Properties.Resources.Exit_Red;
            exitButton.BackgroundImageLayout = ImageLayout.Zoom;
            //exitButton.Anchor = (AnchorStyles.Right);
            exitButton.MouseClick += new MouseEventHandler(ExitButton_Click);
      
            ItemPanel.Controls.Add(exitButton);
            exitButton.BringToFront();
        }





        // Exit Button - Function
        private void ExitButton_Click(object sender, EventArgs e)
          {

           
                int indexOfminiPanel = 0; // The index after the miniPanel we want to exit
                for (int i = 0; i < TaskbarPanel.Controls.Count; i++)
                {
                    if (TaskbarPanel.Controls[i] == miniPanel)
                    {

                         indexOfminiPanel = i;
                         TaskbarPanel.Controls[i].Dispose();
                         break;// Break out no reason to continue
                    }
                
                }

                    // Change the Location of the mini panels after the exited minipanel
                    for(int c = indexOfminiPanel; c < TaskbarPanel.Controls.Count; c++)
                    {
                     //MessageBox.Show(c.ToString(), "After: Index", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     TaskbarPanel.Controls[c].Location = new Point(TaskbarPanel.Controls[c].Location.X - 110, TaskbarPanel.Controls[c].Location.Y);
                    }
        
                    ItemPanel.Dispose();// Item Panel Dispose

          }

        //---EXIT-Button------::END::-----------------------------------------------------------------------------------------------------















        //---Minimize-Button------::START::-----------------------------------------------------------------------------------------------------

        // Minimize Button      "Topmenu of ItemPanel" 
        private void Minimize()
         {
            Button minimizeButton = new Button();
            minimizeButton.Location = new Point(ItemPanel.Width - 55, 0);
            minimizeButton.Width = 20;
            minimizeButton.Height = 20;
            minimizeButton.BackgroundImage = Properties.Resources.minimize;
            minimizeButton.BackgroundImageLayout = ImageLayout.Zoom;

            minimizeButton.MouseClick += new MouseEventHandler(MinimizeButton_Click);


            ItemPanel.Controls.Add(minimizeButton);
            minimizeButton.BringToFront();

         }


         private void MinimizeButton_Click(object sender, EventArgs eventArgs)
         {
            ItemPanel.Visible = false;
            MiniPanelLastClickedPanelBorder(); ////-----------------------------TEST
            OpenedPanelsMiniPanelBorder();
         }

        //---Minimize-Button------::END::-----------------------------------------------------------------------------------------------------









         // Change Border Color of all "Inactive" ItemPanels  
         private void ChangeBorderColorOfAllOtherItemPanels()
         {
              
            for(int i = 0; i < LoaderPanel.Controls.Count; i++) // Loop all Loader Panel Controls
            {
                if (LoaderPanel.Controls[i] is MyPanel && LoaderPanel.Controls[i] != ItemPanel) // If it is of type myPanel and if it is not the Current Panel
                {
                    MyPanel a = (MyPanel)LoaderPanel.Controls[i];// Convert it "Cast"

                    a.Border = new Pen(Color.FromArgb(66, 188, 245)); // Give it new Border color
                    a.Refresh(); // Refresh the border Color so it apears in the form

                    LoaderPanel.Controls[i].Tag = a; // Assign it to the Current items Tag " The tag is the Item Itselsf, the tag got assignet with the current object at the time the object was created.This is used "the Tag"  because " LoaderPanel.Controls[i]" is Read only

                }

               
            }

         
            //ItemPanel Active make it green
            ItemPanel.Border = Pens.Lime;
            ItemPanel.Refresh();


            // CLEAN
            ////Make Inactive mini panels red
            //MiniPanelBorderInActive();

            //// Make the Active mini panel Green
            //MiniPanelBorderActive();
            // CLEAN


        }



   







        // Item Panel
        public void AddItemPanel()
        {
            ////ItemPanel = new Panel();//Added task panel
            //ItemPanel.Location = new System.Drawing.Point(ItemPanelLocationX, ItemPanelLocationY);//Added panel Location
            //ItemPanel.MaximumSize = new Size(300, 100);
            //ItemPanel.Size = new Size(150, 100);
            //ItemPanel.BackColor = ItemPanelBackground;
            ////TaskPanel.Margin = new Padding(200, 200, 200, 200);
            ////TaskPanel.Padding = new Padding(200);
            ////ItemPanel.Tag = TaskbarPanel.Controls.Count + 1;
            ItemPanel.Tag = this.ItemPanel;
            ItemPanel.Tag1 = this.miniPanel;
            ItemPanel.AutoSize = true;

            // Event Handlers
            ItemPanel.MouseDown += new MouseEventHandler(ItemPanel_MouseDown);///Added panel Declaring MouseDown
            ItemPanel.MouseMove += new MouseEventHandler(ItemPanel_MouseMove);///Added panel Declaring MouseMove
            ItemPanel.MouseUp += new MouseEventHandler(ItemPanel_MouseUp);///Added panel Declaring MouseUp
            //ItemPanel.Paint += new PaintEventHandler(ItemPanel_Paint);// On loading the ItemPanel "On Apearing in the Form"
            ItemPanel.MouseClick += new MouseEventHandler(ItemPanel_MouseClick);



            //ItemPanel.LocationChanged += new System.EventHandler(ItemPanel_LocationChanged);
            //ItemPanel.KeyDown += MovingPanel_KeyDown;

            //ItemPanel.Controls.Add(ItemPanelAddControls);// Populate the panel with Controls

            LoaderPanel.Controls.Add(ItemPanel);// Add the panel to the loader_panel "Workplace"
            activeControl = ItemPanel;//Focused



            ItemPanelTopMenu();
            ExitButton(); // Exit Button "Added at the top right corner of the item panel"
            Minimize(); // Minimize Button
        }












        // ItemPanel - Mouse Down - "On pressing down the the mouse button"
        private void ItemPanel_MouseDown(object sender, MouseEventArgs e)
        {

            
            //activeControl = sender as Control;
            activeControl = ItemPanel;
            Start_TaskPanel = e.Location;// Start position on panel move
            Cursor.Current = Cursors.Hand;

            // Change ItemPanel Border
            ChangeBorderColorOfAllOtherItemPanels();

            //Make Inactive mini panels red
            MiniPanelBorderInActive();   

            // Make the Active mini panel Green
            MiniPanelBorderActive();   

            // For all Opened Panels Except the current one the miniPanels related to them will get blue
            OpenedPanelsMiniPanelBorder();

            //CLEAN
            //SelectedItemPanelBorder();


        }











        // ItemPanel Mouse Move
        private void ItemPanel_MouseMove(object sender, MouseEventArgs e)
        {

            // If it is not sender does not move any panel  "The sender is the panel that owns the current MouseEvent"  
            if (activeControl == null/* || activeControl != sender*/)
            {
                return;//Terminates execution of the method and returns control to the calling method
            }



            // Mouse Button Left Down
            if (e.Button == System.Windows.Forms.MouseButtons.Left) // The panel is attached to the mouse and you can move it 
            {
                activeControl.BringToFront();// Show on top

                //Selected Panel Limited location of Bottom and Right 
                if (this.activeControl.Location.X == Math.Min(Math.Max(activeControl.Right + (e.X - Start_TaskPanel.X), 0), activeControl.Parent.Width - activeControl.Width) && this.activeControl.Location.Y == Math.Min(Math.Max(activeControl.Bottom + (e.Y - Start_TaskPanel.Y), 0), activeControl.Parent.Height - activeControl.Height))
                {
                    int RightX = Math.Min(Math.Max(activeControl.Right + (e.X - Start_TaskPanel.X), 0), activeControl.Parent.Width - activeControl.Width);
                    int BottomY = Math.Min(Math.Max(activeControl.Bottom + (e.Y - Start_TaskPanel.Y), 0), activeControl.Parent.Height - activeControl.Height);

                    activeControl.Location = new Point(RightX, BottomY);

                }


                //Selected Panel Limited location of LEFT and TOP 
                else
                {
                    int LeftX = Math.Min(Math.Max(activeControl.Left + (e.X - Start_TaskPanel.X), 0), activeControl.Parent.Width - activeControl.Width);
                    int TopY = Math.Min(Math.Max(activeControl.Top + (e.Y - Start_TaskPanel.Y), 0), activeControl.Parent.Height - activeControl.Height);
                    activeControl.Location = new Point(LeftX, TopY);
                }

            }


             

        }









        // ItemPanel Mouse UP
        private void ItemPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if(activeControl  != null)
            {
                activeControl.BringToFront();// Show on top

            }

            activeControl = null;
            Cursor.Current = Cursors.Default;

        }



        //// ItemPanel BORDER
        //private void ItemPanel_Paint(object sender, PaintEventArgs e)
        //{
        //    ControlPaint.DrawBorder(e.Graphics, this.ItemPanel.ClientRectangle, Color.DarkBlue, ButtonBorderStyle.Solid);
        //}





        // ItemPanel Location Changed
        private void ItemPanel_LocationChanged(object sender, EventArgs e)
        {

        }

        // ItemPanel Key Down
        private void ItemPanel_KeyDown(object sender, KeyEventArgs e)
        {

        }

        // ItemPanel Mouse Click
        private void ItemPanel_MouseClick(object sender, MouseEventArgs e)
        {

        }

        //------------Moving Task Panels--Workplace::------::END::------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------




    }
}
