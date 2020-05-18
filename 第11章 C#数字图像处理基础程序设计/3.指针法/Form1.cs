using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.指针法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Bitmap crtBitmap = new Bitmap("");

            //获取被处理的图像大小
            Rectangle rect = new Rectangle(0, 0, crtBitmap.Width, crtBitmap.Height);
            //将被处理的图像数据锁存
            System.Drawing.Imaging.BitmapData bmpData = crtBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, crtBitmap.PixelFormat);

            //启动非安全代码，以便使用指针
            unsafe
            {
                //得到第一个字节的首地址（指针起点）
                byte* ptr = (byte*)(bmpData.Scan0);

                //二维图像循环
                for(int i = 0; i < bmpData.Height; i++)
                {
                    for(int j = 0; j < bmpData.Width; j++)
                    {
                        //处理像素点
                        ptr[0] = 0;
                        ptr[1] = 0;
                        //ptr[2]=0;//保留其中的红色信息
                        //指向下一个像素
                        ptr += 3;//这是什么意思？ ptr[0]=ptr[0]+3 ??????
                    }
                    //指向下一行的首字节（“ *3 ”表示24位位图）
                    //bmpData.Stride - bmpData.Width * 3为扫描偏移量
                    ptr += bmpData.Stride - bmpData.Width * 3;
                }
            }
            //解除被处理的图像数据的锁存，图像处理结束
            crtBitmap.UnlockBits(bmpData);
        }
    }
}
