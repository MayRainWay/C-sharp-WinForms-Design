using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chpt10_6b_PicsAnmate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //预加载图像保存
        Bitmap[] bitmap;
        //图像编号
        int PicNum = 0;

        //预加载图像
        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Value = timer1.Interval;//让滑动条初始状态与默认值一致
            bitmap = new Bitmap[5];
            for(int i = 0; i < 5; i++)
            {
                bitmap[i] = new Bitmap(Application.StartupPath+"\\pics\\p"+i.ToString()+".jpg");
            }
        }

        //开始动画
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PicNum > 4)
            {
                PicNum = 0;
            }
            pictureBox1.Image = bitmap[PicNum];
            PicNum++;
        }

        //速度控制
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
        }
    }
}
