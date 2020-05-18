using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//示例代码，并非项目，存在大量错误，仅供参考！
namespace _2.内存法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Bitmap crtBitmap = new Bitmap(@"C:\Users\RainWay\Documents\C#语言 Windows程序设计\第11章 C#数字图像处理基础程序设计\2.内存法\test.jpg");

            //获取被处理的图像大小
            Rectangle rect = new Rectangle(0, 0, crtBitmap.Width, crtBitmap.Height);
            //将被处理得图像数据锁存
            System.Drawing.Imaging.BitmapData bmpData = crtBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, crtBitmap.PixelFormat);
            //获取第一个像素的地址
            IntPtr ptr = bmpData.Scan0;
            //计算该被处理的24位图的字节总数
            int bytes = crtBitmap.Width * crtBitmap.Height * 3;
            //根据以上字节总数创建用于保存图像数据的字节数组
            byte[] rgbValues = new byte[bytes];
            //将被锁存的图像数据复制到数组中
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
            for(int i = 0; i < rgbValues.Length; i += 3)
            {
                //处理像素点
                rgbValues[i] = 0;
                rgbValues[i + 1] = 0;
                //rgbValues[i+2]=0;//保留其中的红色信息（不处理）
            }
            //将数组复制回位图中
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            //解除被处理图像数据的锁存，图像处理结束
            crtBitmap.UnlockBits(bmpData);
        }
    }
}
