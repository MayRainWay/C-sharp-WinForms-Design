using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._4._2绘制文本
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

            //创建Font对象1：Times New Roman字体，12号大小
            Font font1 = new Font("Times New Roman", 12);
            //绘制文本1
            g.DrawString("Times New Roman,12,Green", font1, new SolidBrush(Color.Green), 20, 20);

            //创建Font对象2：宋体字，14号大小
            Font font2 = new Font("宋体", 14);
            //绘制文本2
            g.DrawString("宋体，14号，蓝色，正常", font2, new SolidBrush(Color.Blue), 20, 70);

            //创建Font对象3：宋体字，14号大小，加粗
            Font font3 = new Font("宋体", 14, FontStyle.Bold);
            //绘制文本3
            g.DrawString("宋体，14号，红色，加粗", font3, new SolidBrush(Color.Red), 20, 120);
        }
    }
}
