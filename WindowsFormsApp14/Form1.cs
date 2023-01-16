using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the values entered in the textboxes
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            int side = Convert.ToInt32(textBox3.Text);

           
// Create a new Bitmap object and a Graphics object from the image
          Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);

            // Draw the square
            g.DrawRectangle(Pens.LightBlue, x, y, side, side);

            // Set the Image property of the PictureBox control to the Bitmap object
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the values entered in the textboxes
            int x = Convert.ToInt32(textBox4.Text);
            int y = Convert.ToInt32(textBox5.Text);
            int radius = Convert.ToInt32(textBox6.Text);

            // Create a new Bitmap object and a Graphics object from the image
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);

            // Draw the circle
            g.DrawEllipse(Pens.PaleVioletRed, x - radius, y - radius, 2 * radius, 2 * radius);

            // Set the Image property of the PictureBox control to the Bitmap object
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int side = Convert.ToInt32(textBox3.Text);
            int x = Convert.ToInt32(textBox4.Text);
            int y = Convert.ToInt32(textBox5.Text);
            int radius = Convert.ToInt32(textBox6.Text);

            // Create a new Bitmap object and a Graphics object from the image
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);

            // Draw the square and the circle
            g.DrawRectangle(Pens.LightBlue, x1, y1, side, side);
            g.DrawEllipse(Pens.PaleVioletRed, x - radius, y - radius, 2 * radius, 2 * radius);

            // Iterate through each pixel of the Bitmap
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    // Check if the pixel is within the intersection of the two shapes
                    if (IsIntersection(x1, y1, side, x, y, radius, i, j))
                    {
                        // Change the color of the pixel to purple
                        bmp.SetPixel(i, j, Color.Purple);
                    }
                }
            }

            // Set the Image property of the PictureBox control to the Bitmap object
            pictureBox1.Image = bmp;
        }
        private void MidPoint(int x, int y, int radius, Graphics g)
        {
            int x_centru = 0;
            int y_centru = radius;
            int p = 5 / 4 - radius;

            while (x_centru <= y_centru)
            {

                if (p < 0)
                {
                    p += 2 * x_centru + 3;
                    x++;
                }
                else
                {
                    p += 2 * (x_centru - y_centru) + 5;
                    y_centru--;
                    x_centru++;
                }
                drawPointCircle(x, y, x_centru, y_centru, g);
            }
        }

        private void drawPointCircle(int x, int y, int x_centru, int y_centru, Graphics g)
        {
            g.DrawEllipse(new Pen(Color.PaleVioletRed, 2), x - x_centru, y - y_centru, 2 * x_centru, 2 * y_centru);
            g.DrawEllipse(new Pen(Color.PaleVioletRed, 2), x - y_centru, y - x_centru, 2 * y_centru, 2 * x_centru);
            g.DrawEllipse(new Pen(Color.PaleVioletRed, 2), x - x_centru, y + y_centru, 2 * x_centru, 2 * y_centru);
            g.DrawEllipse(new Pen(Color.PaleVioletRed, 2), x - y_centru, y + x_centru, 2 * y_centru, 2 * x_centru);
            g.DrawEllipse(new Pen(Color.PaleVioletRed, 2), x + x_centru, y - y_centru, 2 * x_centru, 2 * y_centru);
            g.DrawEllipse(new Pen(Color.PaleVioletRed, 2), x + y_centru, y - x_centru, 2 * y_centru, 2 * x_centru);
            g.DrawEllipse(new Pen(Color.PaleVioletRed, 2), x + x_centru, y + y_centru, 2 * x_centru, 2 * y_centru);
            g.DrawEllipse(new Pen(Color.PaleVioletRed, 2), x + y_centru, y + x_centru, 2 * y_centru, 2 * x_centru);
        }
        bool IsInsideSquare(int x1, int y1, int side, int i, int j)
        {
            if (i >= x1 && i <= x1 + side && j >= y1 && j <= y1 + side)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool IsIntersection(int x1, int y1, int side, int x, int y, int radius, int i, int j)
        {
            bool insideCircle = IsInsideCircle(x, y, radius, i, j);
            bool insideSquare = IsInsideSquare(x1, y1, side, i, j);
            if (insideCircle && insideSquare)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsInsideCircle(int x, int y, int radius, int i, int j)
        {
            // Calculate the distance between the center of the circle and the pixel
            double distance = Math.Sqrt(Math.Pow(i - x, 2) + Math.Pow(j - y, 2));

            // Check if the distance is less than or equal to the radius of the circle
            if (distance <= radius)
            {
                return true;
            }
            return false;
        }
    }
}
