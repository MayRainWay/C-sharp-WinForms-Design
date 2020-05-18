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

namespace _10._3._2TextureBrush纹理画刷
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
            //工具文件名创建BMP对象
            Bitmap bitmap = new Bitmap("C:\\Users\\RainWay\\Documents\\C#语言 Windows程序设计"
                +"\\第10章 GDI+图形图像程序设计\\10.3.2TextureBrush纹理画刷\\测试用.jpg");
            //其实这里是存在一些问题的，相对路径和绝对路径的问题！！！
            //书里没讲这个东西！！！

            bitmap = new Bitmap(bitmap, 280, 170);
            //利用纹理画刷填充图形
            TextureBrush brush = new TextureBrush(bitmap);
            e.Graphics.FillEllipse(brush,20, 20, 280, 170);
        }
    }
}
