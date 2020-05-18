using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//以下为测试代码，无实际意义，仅供练习

namespace GDI_ExampleText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //2.调用当前窗体或控件的CreatGraphics方法
            Graphics g = this.CreateGraphics();
            //其他图形图像处理代码
        }

        //1.在窗体或空间的Paint事件中直接引用Graphics对象
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //其他图形图像处理代码
        }


        //3.调用Graphics类的FromImage静态方法
        //        Bitmap bitmap = new Bitmap(@"C:\Users\RainWay\Documents\C#语言 Windows程序设计
        //\第10章 GDI+图形图像程序设计\GDI+ExampleText\test.bmp");
        //        Graphics g = Graphics.FromImage(bitmap);

        //Image img = Image.FromFile(durandal.gif);
        //Graphics g = Graphics.FromImage(img);

            //1.利用FromArgb指定任意颜色
        //纯红色
        Color red = Color.FromArgb(255, 0, 0);
        //纯绿色
        Color green = Color.FromArgb(0, 255, 0);
        //纯蓝色（也可采用十六进制表示）
        Color blue = Color.FromArgb(0, 0, 0xff);

        //通过Alpha的值设定为128（256/2），创建半透明的纯红色
        Color test = Color.FromArgb(128, 255, 0, 0);

        ////2.直接使用系统定义的颜色
        //Color mycolor;        
        //MyColor=mycolor.Red;//红色
        //MyColor=mycolor.Brown;//棕色

        //坐标系统
        Point p = new Point(85, 100);
        Size s = new Size(50, 80);
        Rectangle rct = new Rectangle(10, 20, 150, 300);

        //Point p1 = new Point(10, 20);
        //Size s1 = new Size(150, 300);
        //Rectangle rct1 = new Rectangle(p1, s1);

        //画笔与画刷
        //1个像素宽的红色笔
        Pen pen1 = new Pen(Color.Red);
        //5个像素宽的黑色笔
        Pen pen2 = new Pen(Color.Black, 5);

        ////利用画刷实例化笔
        //SolidBrush brush1 = new SolidBrush(Color.Red);
        ////1个像素宽的红色笔
        //Pen pen3 = new Pen(brush1);
        ////5个像素的红色笔
        //Pen pen4 = new Pen(brush1,5);
        
    }
}
