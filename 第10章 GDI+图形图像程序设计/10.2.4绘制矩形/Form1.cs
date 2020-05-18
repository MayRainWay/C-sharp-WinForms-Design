using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._2._4绘制矩形
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
            e.Graphics.DrawRectangle(pen, 20, 20, 100, 120);

            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, 170, 20, 100, 120);
        }
    }
}
