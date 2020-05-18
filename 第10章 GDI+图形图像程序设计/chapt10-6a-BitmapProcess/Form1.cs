using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chapt10_6a_BitmapProcess
{
    public partial class s : Form
    {
        public s()
        {
            InitializeComponent();
        }

        //图像的显示
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "所有合适文件(*.bmp/*.jpg/*.gif)|*.*|Bitmap文件(*.bmp)|*.bmp|Jpeg文件(*.jpg)|*.jpg";
            openFileDialog1.FilterIndex = 2;//这句话似乎没什么用
            openFileDialog1.RestoreDirectory = true;
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                pictureBox1.Image = Bitmap.FromFile(openFileDialog1.FileName, false);
            }
        }

        //图像的保存与格式转换
        private void btnSave_Click(object sender, EventArgs e)
        {
            Bitmap b2 = new Bitmap(pictureBox1.Image);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.ShowDialog();
            string str = saveFileDialog1.FileName;
            b2.Save(str);
        }

        //图像的旋转、扭曲与反射
        private void btnDeform_Click(object sender, EventArgs e)
        {
            //旋转并扭曲后的左上点、右下点、左下点的坐标点
            Point[] destinationPoints =
            {
                new Point(10,10),//左上点
                new Point(200,50),//右上点
                new Point(80,150)//左下点
            };

            //原始图像
            Image image = new Bitmap(pictureBox1.Image);
            //在pictureBox1中绘制原图
            Graphics g = pictureBox1.CreateGraphics();
            //按照旋转、扭曲后的坐标点，绘制变形的图像
            g.DrawImage(image, destinationPoints);
        }

        //图像的缩放
        private void btnZoom_Click(object sender, EventArgs e)
        {
            Image image = new Bitmap(pictureBox1.Image);
            Image pThumbnail = image.GetThumbnailImage(200, 200, null, new IntPtr());
            Graphics g = pictureBox1.CreateGraphics();
            //图像缩放为原图的1/2
            g.DrawImage(pThumbnail, 10, 10, pictureBox1.Image.Width / 2, pictureBox1.Image.Height / 2);

        }
    }
}
