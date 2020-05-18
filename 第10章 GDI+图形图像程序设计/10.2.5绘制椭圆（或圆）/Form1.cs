using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._2._5绘制椭圆_或圆_
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
            e.Graphics.DrawEllipse(pen, 20, 50, 150, 100);

            SolidBrush sb = new SolidBrush(Color.Red);
            g.FillEllipse(sb, 200, 50, 100, 100);
        }
    }
}
