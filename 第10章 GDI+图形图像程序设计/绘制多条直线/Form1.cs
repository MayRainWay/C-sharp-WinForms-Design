using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 绘制多条直线
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
            Pen pen = new Pen(Color.Red, 2);
            Point[] points =
            {
                new Point(30,10),
                new Point(180,10),
                new Point(30,120),
                new Point(30,50)
            };
            e.Graphics.DrawLines(pen, points);
            //这种绘制多条直线，会按照点的顺序依次连接起来
        }
    }
}
