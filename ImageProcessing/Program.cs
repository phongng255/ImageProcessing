using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string imagePath = "C:\\Users\\PhongDP\\Downloads\\aaa.jpg";
            // Create a bitmap from the source image file
            Bitmap sourceBitmap = new Bitmap(imagePath);

            // Create a new bitmap with the same dimensions
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            // Create a Graphics object to draw on the result bitmap
            using (Graphics graphics = Graphics.FromImage(resultBitmap))
            {
                // Copy the source image onto the result bitmap
                graphics.DrawImage(sourceBitmap, 0, 0, sourceBitmap.Width, sourceBitmap.Height);

                // Define the position and dimensions of the red rectangle
                int rectX = 555; // X coordinate
                int rectY = 555; // Y coordinate
                int rectWidth = 200; // Width
                int rectHeight = 100; // Height

                // Create a Brush with the background color outside the rectangle (here, it's black)
                using (Brush backgroundBrush = new SolidBrush(Color.Black))
                {
                    // Fill the area outside the rectangle with the background color
                    graphics.FillRectangle(backgroundBrush, 0, 0, resultBitmap.Width, rectY); // Above
                    graphics.FillRectangle(backgroundBrush, 0, rectY, rectX, rectHeight); // Left
                    graphics.FillRectangle(backgroundBrush, rectX + rectWidth, rectY, resultBitmap.Width - (rectX + rectWidth), rectHeight); // Right
                    graphics.FillRectangle(backgroundBrush, 0, rectY + rectHeight, resultBitmap.Width, resultBitmap.Height - (rectY + rectHeight)); // Below
                }

                // Draw the rectangle with the desired color (here, it's red)
                using (Pen pen = new Pen(Color.Red, 1)) // Red color, 1-pixel thickness
                {
                    graphics.DrawRectangle(pen, rectX, rectY, rectWidth, rectHeight);
                }
            }

            // Save the resulting bitmap to a new file
            resultBitmap.Save("C:\\Users\\PhongDP\\Downloads\\result_image.jpg", ImageFormat.Jpeg);

            // Release resources
            sourceBitmap.Dispose();
            resultBitmap.Dispose();

            Console.WriteLine("Completed!");
        }
    }
}
