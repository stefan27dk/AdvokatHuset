using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain
{
    class Datagridview_Screenshot
    {

        My_APP_Settings Get_LocalPath = new My_APP_Settings();




        public void Take_DGV_Screenshot(DataGridView datagridview1)
        {

            int oldHeight = datagridview1.Height;
            int oldWidth = datagridview1.Width;


            datagridview1.Height = datagridview1.RowCount * datagridview1.RowTemplate.Height;



            int allColumnsLenght = 60;

            // Get All Columns Lenght
            for (int i = 0; i < datagridview1.ColumnCount; i++)
            {
                allColumnsLenght += datagridview1.Columns[i].Width;
            }

            // Total DGV width by column width
            datagridview1.Width = allColumnsLenght;


            // Bitmap
            Bitmap bitmapScreenshot = new Bitmap(datagridview1.Width, datagridview1.Height);

            // Draw to the bitmap
            datagridview1.DrawToBitmap(bitmapScreenshot, new System.Drawing.Rectangle(0, 0, datagridview1.Width, datagridview1.Height));

            // Reset the height
            datagridview1.Height = oldHeight;
            datagridview1.Width = oldWidth;

            // Save bitmap
            bitmapScreenshot.Save(Get_LocalPath.LocalPath + "Advokat_Snapshot  " + DateTime.Now.ToString("dd-MM-yyyy  HH-mm-ss") + ".png");
            Clipboard.SetDataObject(bitmapScreenshot);  // Copy Image to Clipboard Also   


        }






    }
}
