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

namespace PathGradientBrush_径向渐变画刷
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            //创建矩形路径
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(g.VisibleClipBounds);

            //创建PathGradientBrush画刷对象
            PathGradientBrush brush = new PathGradientBrush(path);

            //路径格式刷的中心设定为白色
            brush.CenterColor = Color.White;
            //根据路径内的点指定颜色
            brush.SurroundColors = new Color[] { Color.Yellow, Color.Green, Color.Blue, Color.Red };
            //填充矩形路径
            g.FillRectangle(brush, g.VisibleClipBounds);
            //释放资源
            brush.Dispose();
            g.Dispose();
        }
    }
}
