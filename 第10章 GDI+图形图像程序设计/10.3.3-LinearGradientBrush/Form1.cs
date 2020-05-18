using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._3._3_LinearGradientBrush
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
            Pen pen = new Pen(Color.Black);
            Rectangle rect = new Rectangle(25, 20, 270, 160);
            g.DrawRectangle(pen, rect);//利用画笔创建绘图填充区

            LinearGradientBrush brush = new LinearGradientBrush(
                rect, Color.Red, Color.Blue, LinearGradientMode.Horizontal);
            //使用渐变画刷填充矩形
            g.FillRectangle(brush, rect);
        }
    }
}
