using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranslatieDreptunghi
{
    public partial class Form1 : Form
    {

        Point p1 = new Point(0, 0);
        Point p3 = new Point(300, 100);

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Initialize(display);
            Engine.Refresh();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Engine.Clear();
            GeneratePoints();
            Engine.Refresh();
        }

        private void GeneratePoints()
        {
            Point p2 = new Point(p3.X, p1.Y); // coltul dreapta sus
            Point p4 = new Point(p1.X, p3.Y); // coltul stanga jos

            midPoint1(p1.X, p1.Y, p2.X, p2.Y, Engine.grp);
            midPoint1(p2.X, p2.Y, p3.X, p3.Y, Engine.grp);
            midPoint1(p3.X, p3.Y, p4.X, p4.Y, Engine.grp);
            midPoint1(p4.X, p4.Y, p1.X, p1.Y, Engine.grp);
        }

        private void midPoint1(int X1, int Y1, int X2, int Y2, Graphics g)
        {
            midPoint1(X1, Y1, X2, Y2, g, Color.Black);
        }

        private void midPoint1(int X1, int Y1, int X2, int Y2, Graphics g, Color color)
        {
            int dx = Math.Abs(X2 - X1);
            int dy = Math.Abs(Y2 - Y1);

            int sx = (X1 < X2) ? 1 : -1;
            int sy = (Y1 < Y2) ? 1 : -1;

            int err = dx - dy;
            int x = X1, y = Y1;

            while (true)
            {
                Engine.bmp.SetPixel(x, y, color);

                if (x == X2 && y == Y2)
                    break;

                int err2 = 2 * err;
                if (err2 > -dy)
                {
                    err -= dy;
                    x += sx;
                }
                if (err2 < dx)
                {
                    err += dx;
                    y += sy;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Define the translation values
            int tx = 300;
            int ty = 100;

            Point p2 = new Point(p3.X, p1.Y);
            Point p4 = new Point(p1.X, p3.Y);

            TranslatePointDirect(ref p1, tx, ty);
            TranslatePointDirect(ref p2, tx, ty);
            TranslatePointDirect(ref p3, tx, ty);
            TranslatePointDirect(ref p4, tx, ty);


            // Draw the translated rectangle in red
            midPoint1(p1.X, p1.Y, p2.X, p2.Y, Engine.grp, Color.Red);
            midPoint1(p2.X, p2.Y, p3.X, p3.Y, Engine.grp, Color.Red);
            midPoint1(p3.X, p3.Y, p4.X, p4.Y, Engine.grp, Color.Red);
            midPoint1(p4.X, p4.Y, p1.X, p1.Y, Engine.grp, Color.Red);
            Engine.Refresh();
        }

        private void TranslatePointDirect(ref Point point, int tx, int ty)
        {
            point.X += tx;
            point.Y += ty;
            Engine.Refresh();

        }

       
    }
}
