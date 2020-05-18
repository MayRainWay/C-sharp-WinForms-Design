using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._2._2绘制多边形
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Blue, 2);
            Point[] points1 =
            {
                new Point(90,40),
                new Point(40,150),
                new Point(140,150)
            };
            e.Graphics.DrawPolygon(pen, points1);

            SolidBrush brush = new SolidBrush(Color.Red);
            Point[] points2 =
            {
                new Point(230,40),
                new Point(180,150),
                new Point(280,150)
            };
            e.Graphics.FillPolygon(brush, points2);
        }
    }
}
