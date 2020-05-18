using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//仅供练习测试；无实际意义
//代码不规范且存在错误！

    //1.直接操作法
namespace 数字图像处理_11._2_像素操作
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ////获取当前像素点的RGB颜色值
            //crtColor = crtBitmap.GetPixel(5, 3);
            ////设置当前像素点的新的RGB颜色值
            //crtBitmap.SetPixel(5, 3, Color.FromArgb(crtColor.R, 0, 0));
        }
    }
}
