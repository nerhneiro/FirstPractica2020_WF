using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Location = new Point(ClientSize.Width / 2, 0);
            
        }
        bool paint = false;
        bool exist = false;
        int x1, x2, x3, y1, y2, y3;

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Width = ClientSize.Width / 2;
            panel1.Height = ClientSize.Height;
        }

        float x23_diff, y1_diff;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int center_x = panel1.Width / 2;
            int center_y = panel1.Height / 2;
            int p1_x = 0, p1_y = 0, p2_x = 0, p2_y = 0, p3_x = 0, p3_y = 0;
            Console.WriteLine(exist);
            if (!exist)
            {
                Console.WriteLine("first");
                x23_diff = center_x / 2;
                y1_diff = center_y / 2;
                p1_x = center_x;
                p1_y = (int)(center_y - y1_diff);
                p2_x = (int)(center_x - x23_diff);
                p3_x = (int)(center_x + x23_diff);
                p2_y = center_y;
                p3_y = center_y;
                x1 = p1_x;  x2 = p2_x; x3 = p3_x; y1 = p1_y; y2 = p2_y; y3 = p3_y;
                Console.WriteLine("p1_x = " + x1 + " p1_y = " + y1 + " p2_x = " + x2 + " p2_y = " + y2 + " p3_x = " + x3 + " p3_y = " + y3);
            }
            else
            {
                Console.WriteLine("next");
                y1_diff = (float)(y1_diff * 1.1);
                x23_diff = (float)(x23_diff * 1.1);
                Console.WriteLine("y1_diff " + y1_diff, " x23_diff " + x23_diff);
                y1 = (int)((float)center_y - y1_diff);
                x2 = (int)((float)center_x - x23_diff);
                x3 = (int)((float)center_x + x23_diff);
                Console.WriteLine("p1_x = " + x1 + " p1_y = " + y1 + " p2_x = " + x2 + " p2_y = " + y2 + " p3_x = " + x3 + " p3_y = " + y3);
            }
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.YellowGreen);
            Point[] points = { new Point(x1, y1), new Point(x2,y2), new Point(x3, y3) };
            //if (x1 > 0 || y1 < 0 || x3 < 0) paint = false;
            panel1.Width = ClientSize.Width / 2;
            panel1.Height = ClientSize.Height;
            if (paint)
            {
                if (y1 >= 0 && x3 >= 0)
                {
                    g.FillPolygon(brush, points);
                    exist = true;
                    button1.Text = "увеличить";
                }
                else 
                { 
                    exist = false;
                    button1.Text = "начать";
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Width = Width / 2;
            panel1.Height = ClientSize.Height;
            paint = true;
        }
    }
}
