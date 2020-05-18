using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._2._3绘制曲线
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
            Pen pen1 = new Pen(Color.Blue, 2);
            Point[] points1 ={
                new Point(20,170),
                new Point(60,30),
                new Point(100,160),
                new Point(140,40),
                new Point(180,150),
                new Point(220,50),
                new Point(260,140),
            };
            e.Graphics.DrawCurve(pen1, points1, 0f);

            Pen pen2 = new Pen(Color.Red, 2);
            Point[] points2 =
            {
                new Point(20,170),
                new Point(60,30),
                new Point(100,160),
                new Point(140,40),
                new Point(180,150),
                new Point(220,50),
                new Point(260,140),
            };
            e.Graphics.DrawCurve(pen2, points2, 0.6f);
        }
    }
}
