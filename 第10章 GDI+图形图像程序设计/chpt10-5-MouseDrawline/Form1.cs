using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chpt10_5_MouseDrawline
{
    public partial class Form1 : Form
    {
        //定义绘图对象
        Graphics g;//这个全局变量能保证在所有的函数中都能使用，算是个小技巧吧！
        //定义画线起点x、y坐标
        int LineStartX = 0;
        int LineStartY = 0;
        //标志，仅移动并“按下”鼠标时才可画线
        bool blDrawLine = false;
        public Form1()
        {
            InitializeComponent();
            //创建绘图对象
            g = this.pictureBox1.CreateGraphics();//如果不用这个，应该就需要用Paint事件了
        }
        
        //初置画线起点以便鼠标移动时画线
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //画线起点
                LineStartX = e.X;
                LineStartY = e.Y;
                blDrawLine = true;
            }
        }

        //画线
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (blDrawLine)
            {
                //创建一个2像素宽的蓝色画笔
                Pen p= new Pen(Color.Blue, 2);
                //开始画线
                g.DrawLine(p, LineStartX, LineStartY, e.X, e.Y);
                //重置画线起点
                LineStartX = e.X;
                LineStartY = e.Y;
            }
        }

        //取消画线
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            blDrawLine = false;
        }

        //清除画线
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
