using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//该项目仅供练习测试
namespace _10._6._1_Bitmap类测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //常用的几种创建方法
            Bitmap b1 = new Bitmap(pictureBox1.Image);
            Bitmap b2 = new Bitmap("C:\\Users\\RainWay\\Documents\\C#语言 Windows程序设计\\第10章 GDI+图形图像程序设计\\10.6.1_Bitmap类测试\\setsuna.jpg");
            Bitmap b3 = new Bitmap(@"C:\Users\RainWay\Documents\C#语言 Windows程序设计\第10章 GDI+图形图像程序设计\10.6.1_Bitmap类测试\setsuna.jpg");
            Bitmap b4 = new Bitmap(b3);
        }
    }
}
