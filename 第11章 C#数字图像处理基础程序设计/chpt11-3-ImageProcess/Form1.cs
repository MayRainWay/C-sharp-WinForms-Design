using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace chpt11_3_ImageProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string currentImageFile;  //记录源图文件路径
        Bitmap sourceBitmap;      //源图像
        int[] countPixel = new int[256];//灰度级计数

        //打开源图，加载图像
        private void btnLoad_Click(object sender, EventArgs e)
        {
            //打开一个选择文件对话框以便加载要处理的图像
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "所有图片文件（*.bmp/*.jpg/*.gif）|*.*|"+
                "Jpeg文件（*.jpg）|*.jpg|Bitmap文件（*.bmp）|*.bmp|gif文件（*.gif）|*.gif";

            openFileDialog1.FilterIndex = 2;//这玩意儿有什么用？
            openFileDialog1.RestoreDirectory = true;
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                currentImageFile = openFileDialog1.FileName;
                //显示所加载的源图像以便与处理后的图像对比
                pictureBox1.Image = Bitmap.FromFile(currentImageFile, false);
                //备份所加载的图像以便款苏重新加载
                sourceBitmap = (Bitmap)Image.FromFile(currentImageFile);
                //对窗体进行重新绘制，这将强制执行Paint事件处理程序
                Invalidate();
                //当重新加载图像时，应重置标示
                this.label1.Text = "源图像";
                this.label2.Text = "源图像（待处理）";
            }
        }
        //在指定位置以指定尺寸绘图
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (sourceBitmap != null)
            {
                g.DrawImage(sourceBitmap, 378, 12, sourceBitmap.Width, sourceBitmap.Height);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sourceBitmap != null)//这个processingBitmap是个什么东西？？？代码里没出现过
            {
                Bitmap bitmap = sourceBitmap;
                //选择图像保存位置和保存类型
                saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Bitmap文件（*.bmp）|*.*|Jpeg文件（*.jpg）|*.jpg|gif文件（*.gif）|*.gif";

                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (DialogResult.OK == saveFileDialog1.ShowDialog())
                {
                    //保存图像文件
                    bitmap.Save(saveFileDialog1.FileName);
                }
            }
            else
            {
                MessageBox.Show("无处理的图像可保存。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //灰度化方法（函数）
        public static bool GrayScale(Bitmap b)
        {
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), 
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int noOffset = stride - b.Width * 3;
                byte red, green, blue;
                for(int y = 0; y < b.Height; ++y)
                {
                    for(int x = 0; x < b.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];
                        p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);
                        p += 3;
                    }
                    p += noOffset;
                }
            }
            b.UnlockBits(bmData);
            //返回图像处理结果
            return true;
        }

        //灰度化启动
        private void btnGray_Click(object sender, EventArgs e)
        {
            //调用灰度化方法
            GrayScale(sourceBitmap);   //这个b从tm哪里来的？？？？
            this.label2.Text = "灰度图";
        }

        //灰度直方图
        private void btnHistogram_Click(object sender, EventArgs e)
        {
            if (sourceBitmap != null)
            {
                //一、统计各级灰度数量以便绘制直方图
                //1.锁存图像数据，以便读取像素信息
                Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
                BitmapData bmpData = sourceBitmap.LockBits(rect,ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
                int stride = bmpData.Stride;
                IntPtr Scan0 = bmpData.Scan0;
                //灰度级记录
                byte grayScale = 0;
                //灰度级数组清零
                Array.Clear(countPixel, 0, 256);
                //记录灰度级的最大数量
                int maxPixel = 0;
                //2.计算各灰度级像素个数
                unsafe
                {
                    byte* p = (byte*)(void*)Scan0;
                    // “ *1 ”以强调图像为8位灰度图
                    //nOffset:扫描偏移量
                    int nOffset = stride - sourceBitmap.Width * 1;
                    for(int y = 0; y < sourceBitmap.Height; ++y)
                    {
                        for(int x = 0; x < sourceBitmap.Width; ++x)
                        {
                            //灰度级
                            grayScale = p[0];
                            //灰度级像素个数计数
                            countPixel[grayScale]++;
                            if (countPixel[grayScale] > maxPixel)
                            {
                                //重置灰度级最大数量
                                maxPixel = countPixel[grayScale];
                            }
                            p += 1;
                        }
                        p += nOffset;
                    }
                }
                sourceBitmap.UnlockBits(bmpData);

                //二、绘制直方图的坐标系
                this.label1.Text = "灰度直方图";
                //1.创建绘制坐标的画笔
                Pen curPen = new Pen(Brushes.Black, 1);
                //2.利用picturBox创建Graphics画图对象
                Graphics g = pictureBox1.CreateGraphics();
                //3.清除pictureBox1的背景上可能存在的图案
                g.Clear(this.BackColor);
                //4.绘制横坐标
                g.DrawLine(curPen, 50, 240, 320, 240);
                //5.绘制纵坐标
                g.DrawLine(curPen, 50, 240, 50, 30);
                //6.绘制横坐标刻度
                g.DrawLine(curPen, 100, 240, 100, 243);
                g.DrawLine(curPen, 150, 240, 150, 243);
                g.DrawLine(curPen, 200, 240, 200, 243);
                g.DrawLine(curPen, 250, 240, 250, 243);
                g.DrawLine(curPen, 300, 240, 300, 243);
                //7.间隔50个像素绘制横坐标的刻度值
                g.DrawString("0", new Font("New Timer", 8), Brushes.Black, new PointF(46, 245));
                g.DrawString("50", new Font("New Timer", 8), Brushes.Black, new PointF(92, 245));
                g.DrawString("100", new Font("New Timer", 8), Brushes.Black, new PointF(139, 245));
                g.DrawString("150", new Font("New Timer", 8), Brushes.Black, new PointF(189, 245));
                g.DrawString("200", new Font("New Timer", 8), Brushes.Black, new PointF(239, 245));
                g.DrawString("250", new Font("New Timer", 8), Brushes.Black, new PointF(289, 245));
                //8.绘制横坐标的刻度
                g.DrawLine(curPen, 47, 40, 50, 40);
                //9.在纵坐标上绘制灰度统计最大刻度值
                g.DrawString(maxPixel.ToString(), new Font("New Timer", 8), Brushes.Black, new PointF(8, 34));
                //10.绘制各级灰度统计图
                double temp2 = 0;
                Pen curPen2 = new Pen(Brushes.Blue, 1);
                for(int i = 0; i < 256; i++)
                {
                    //计算纵坐标相对最大高度
                    temp2 = 200 * countPixel[i] / maxPixel;
                    //绘制直方图
                    g.DrawLine(curPen2, 50 + i, 239, 50 + i, 239 - (int)temp2);
                }
                //释放画笔资源
                curPen.Dispose();
                //释放绘图资源
                g.Dispose();
            }
            else
            {
                MessageBox.Show("无图像可处理。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //String s = Interaction.InputBox(string Prompt, string Title, string DefaultResponse, int XPos, int YPos);
        //二值化方法
        private void Binarize()
        {
            if (sourceBitmap != null)
            {
                String RbrThreshold = Interaction.InputBox("请输入一个 -255~255之间的阈值。\n\n注：正负值可使图像二值化为不同的“黑白效果”。", "二值化阈值设置", "70", 100, 100);
                if (RbrThreshold == "" || Convert.ToInt16(RbrThreshold) < -255 || Convert.ToInt16(RbrThreshold) > 255)
                {
                    MessageBox.Show("阈值必须在-255~255之间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
                    BitmapData bmpData = sourceBitmap.LockBits(rect, ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
                    unsafe
                    {
                        int blue;
                        int RgbTh = Convert.ToInt16(RbrThreshold);
                        byte* ptr = (byte*)(bmpData.Scan0);
                        for(int i = 0; i < bmpData.Height; i++)
                        {
                            for(int j = 0; j < bmpData.Width; j++)
                            {
                                if (RgbTh > 0)
                                {
                                    blue = (int)(ptr[0] < System.Math.Abs(RgbTh) ? 0 : 255);
                                }
                                else
                                {
                                    blue = (int)(ptr[0] > System.Math.Abs(RgbTh) ? 0 : 255);
                                }
                                //green=ptr[1]
                                //red=ptr[2]
                                ptr[0] = ptr[1] = ptr[2] = (byte)(blue);
                                ptr += 3;
                            }
                            ptr += bmpData.Stride - bmpData.Width * 3;
                        }
                    }
                    sourceBitmap.UnlockBits(bmpData);
                    Invalidate();
                }
            }
            else
            {
                MessageBox.Show("无图像可处理。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //二值化启动
        private void btnBinarize_Click(object sender, EventArgs e)
        {
            //调用二值化方法
            Binarize();
            this.label2.Text = "二值化图";
        }

        //滤波方法
        public void Filter()
        {
            if (sourceBitmap != null)
            {
                Color c = new Color();
                int rr, gg, bb, r1, g1, b1, i, j, rx, gx, bx, k1, k2;
                for (i = 1; i < sourceBitmap.Width - 1; i++)
                {
                    for (j = 1; j < sourceBitmap.Height - 1; j++)
                    {
                        rx = 0;gx = 0;bx = 0;
                        for (k1 = -1; k1 <= 1; k1++)
                        {
                            for (k2 = -1; k2 <= 1; k2++)
                            {
                                if (i + k1 != 0 || i + k2 != 0)
                                {
                                    c = sourceBitmap.GetPixel(i + k1, j + k2);
                                    r1 = c.R;
                                    g1 = c.G;
                                    b1 = c.B;
                                    rx = rx + r1;
                                    gx = gx + g1;
                                    bx = bx + b1;
                                }
                            }
                        }
                        rr = (int)(rx / 8);
                        gg = (int)(gx / 8);
                        bb = (int)(bx / 8);
                        if (rr > 255) rr = 255;
                        if (gg > 255) gg = 255;
                        if (bb > 255) bb = 255;
                        Color c1 = Color.FromArgb(rr, gg, bb);
                        sourceBitmap.SetPixel(i, j, c1);
                    }
                }
                Invalidate();
            }
            else
            {
                MessageBox.Show("无图像可处理。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //滤波启动
        private void btnFilter_Click(object sender, EventArgs e)
        {
            //调用滤波方法
            Filter();
            this.label2.Text = "滤波图";
        }

        //锐化方法
        public static Bitmap Sharpen(Bitmap b)
        {
            if (b == null)
            {
                MessageBox.Show("无图像可处理。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            //设置锐化参数
            String sp = Interaction.InputBox("请输入一个0~1之间的锐化参数。", "锐化参数设置", "0.5", 100, 100);
            if (sp == "" || Convert.ToSingle(sp) < 0 || Convert.ToSingle(sp) > 1)
            {
                MessageBox.Show("锐化参数必须在0~1之间。", "提示", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            float val = Convert.ToSingle(sp);
            int w = b.Width;
            int h = b.Height;

            try
            {
                //创建一个与源图同尺寸的“空”图，以便保存锐化后的新图信息
                //因为在锐化过程中会修改当前点像素信息，但该像素点以后还将
                //作为其他像素点的邻域点进行锐化信息的计算，所以，源图状态
                //需要始终保存，也因此，以下处理中将“双指针同步移动”
                Bitmap bmpRtn = new Bitmap(w, h, PixelFormat.Format24bppRgb);
                BitmapData srcData = b.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                //锐化后的新图信息
                BitmapData dstData=bmpRtn.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* pIn = (byte*)srcData.Scan0.ToPointer();
                    byte* pOut = (byte*)dstData.Scan0.ToPointer();
                    int stride = srcData.Stride;
                    byte* p;
                    for(int y = 0; y < h; y++)
                    {
                        for(int x = 0; x < w; x++)
                        {
                            //取周围9点的值。位于边缘上的点不做处理
                            if (x == 0 || x == w - 1 || y == 0 || y == h - 1)
                            {
                                //处理（复制原信息）
                                pOut[0] = pIn[0];
                                pOut[1] = pIn[1];
                                pOut[2] = pIn[2];
                            }
                            else
                            {
                                //邻域像素点的颜色信息记录
                                int r1, r2, r3, r4, r5, r6, r7, r8, r0;
                                int g1, g2, g3, g4, g5, g6, g7, g8, g0;
                                int b1, b2, b3, b4, b5, b6, b7, b8, b0;
                                //锐化处理临时信息记录
                                float vR, vG, vB;
                                //左上像素点
                                p = pIn - stride - 3;
                                r1 = p[2];
                                g1 = p[1];
                                b1 = p[0];
                                //正上像素点
                                p = pIn - stride;
                                r2 = p[2];
                                g2 = p[2];
                                b2 = p[0];
                                p = pIn - stride - 3;
                                r3 = p[2];
                                g3 = p[1];
                                b3 = p[0];
                                //右上像素点
                                p = pIn - 3;
                                r4 = p[2];
                                g4 = p[1];
                                b4 = p[0];
                                //右侧像素点
                                p = pIn + 3;
                                r5 = p[2];
                                g5 = p[1];
                                b5 = p[0];
                                //左下像素点
                                p = pIn + stride - 3;
                                r6 = p[2];
                                g6 = p[1];
                                b6 = p[0];
                                //正下像素点
                                p = pIn + stride;
                                r7 = p[2];
                                g7 = p[1];
                                b7 = p[0];
                                //右下像素点
                                p = pIn + stride + 3;
                                r8 = p[2];
                                g8 = p[1];
                                b8 = p[0];
                                //当前像素点
                                p = pIn;
                                r0 = p[2];
                                g0 = p[1];
                                b0 = p[0];
                                vR = (float)r0 - (float)(r1 + r2 + r3 + r4 + r5 + r6 + r7 + r8) / 8;
                                vG= (float)g0 - (float)(g1 + g2 + g3 + g4 + g5 + g6 + g7 + g8) / 8;
                                vB= (float)b0 - (float)(b1 + b2 + b3 + b4 + b5 + b6 + b7 + b8) / 8;
                                //像素点锐化计算
                                vR = r0 + vR * val;
                                vG = g0 + vG * val;
                                vB = b0 + vB * val;
                                //像素点锐化处理
                                if (vR > 0)
                                {
                                    vR = Math.Min(255, vR);
                                }
                                else
                                {
                                    vR = Math.Max(0, vR);
                                }
                                if (vG > 0)
                                {
                                    vG = Math.Min(255, vG);
                                }
                                else
                                {
                                    vG = Math.Max(0, vG);
                                }
                                if (vB > 0)
                                {
                                    vB = Math.Min(255, vB);
                                }
                                else
                                {
                                    vB = Math.Max(0, vB);
                                }
                                //锐化信息存入“空”图
                                pOut[0] = (byte)vB;
                                pOut[1] = (byte)vG;
                                pOut[2] = (byte)vR;
                            }
                            pIn += 3;
                            pOut += 3;
                        }
                        pIn += srcData.Stride - w * 3;
                        pOut += srcData.Stride - w * 3;
                    }
                }
                b.UnlockBits(srcData);
                bmpRtn.UnlockBits(dstData);
                //返回锐化结果
                return bmpRtn;
            }
            catch
            {
                return null;
            }
        }

        //锐化启动
        private void btnSharpen_Click(object sender, EventArgs e)
        {
            //调用锐化方法
            sourceBitmap = Sharpen(sourceBitmap);
            this.label2.Text = "锐化图";
            Invalidate();
        }

        //边缘检测方法
        public static Bitmap EdgeDetect(Bitmap b)
        {
            if (b == null)
            {
                MessageBox.Show("无图像可处理。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            //设置锐化参数
            String sp = Interaction.InputBox("请输入一个0~1之间的锐化参数。", "锐化参数设置", "0.5", 100, 100);
            if (sp == "" || Convert.ToSingle(sp) < 0 || Convert.ToSingle(sp) > 1)
            {
                MessageBox.Show("锐化参数必须在0~1之间。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            float val = Convert.ToSingle(sp);
            int w = b.Width;
            int h = b.Height;
            try
            {
                //创建一个与源图同尺寸的“空”图，以便保存边缘检测后的新图信息
                //因为在边缘检测过程中会修改当前像素点信息，但该像素点以后还将
                //作为其他像素点的邻域点进行边缘检测信息的计算，所以，源图状态
                //需要始终保存，也因此，以下处理中将“双指针同步移动”
                Bitmap bmpRtn = new Bitmap(w, h, PixelFormat.Format24bppRgb);
                BitmapData srcData = b.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                //边缘检测后的新图信息
                BitmapData dstData=bmpRtn.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* pIn = (byte*)srcData.Scan0.ToPointer();
                    byte* pOut = (byte*)dstData.Scan0.ToPointer();
                    int stride = srcData.Stride;
                    byte* p;
                    for(int y = 0; y < h; y++)
                    {
                        for(int x = 0; x < w; x++)
                        {
                            //取周围9点的值。位于边缘上的点不做处理
                            if (x == 0 || x == w - 1 || y == 0 || y == h - 1)
                            {
                                //不处理（复制原信息）
                                pOut[0] = pIn[0];
                                pOut[1] = pIn[1];
                                pOut[2] = pIn[2];
                            }
                            else
                            {
                                //临近像素点的颜色信息记录
                                int r1, r2, r3, r4;
                                int g1, g2, g3, g4;
                                int b1, b2, b3, b4;
                                //边缘检测处理临时信息记录
                                float vR, vG, vB;
                                //当前像素点
                                p = pIn;
                                r1 = p[2];
                                g1 = p[1];
                                b1 = p[0];
                                //右侧像素点
                                p = pIn + 3;
                                r2 = p[2];
                                g2 = p[1];
                                b2 = p[0];
                                //正下像素点
                                p = pIn + stride;
                                r3 = p[2];
                                g3 = p[1];
                                b3 = p[0];
                                //右下像素点
                                p = pIn + stride + 3;
                                r4 = p[2];
                                g4 = p[1];
                                b4 = p[0];

                                vR = Math.Abs((float)(r1 - r4)) + Math.Abs((float)(r2 - r4));
                                vG = Math.Abs((float)(g1 - g4)) + Math.Abs((float)(g2 - g4));
                                vB = Math.Abs((float)(b1 - b4)) + Math.Abs((float)(b2 - b4));

                                //像素点边缘检测处理
                                if (vR > 0)
                                {
                                    vR = Math.Min(255, vR);
                                }
                                else
                                {
                                    vR = Math.Max(0, vR);
                                }
                                if (vG > 0)
                                {
                                    vG = Math.Min(255, vG);
                                }
                                else
                                {
                                    vG = Math.Max(0, vG);
                                }
                                if (vB > 0)
                                {
                                    vB = Math.Min(255, vB);
                                }
                                else
                                {
                                    vB = Math.Max(0, vB);
                                }

                                //边缘检测信息存入“空”图
                                pOut[0] = (byte)vB;
                                pOut[1] = (byte)vG;
                                pOut[2] = (byte)vR;
                            }
                            pIn += 3;
                            pOut += 3;
                        }
                        pIn += srcData.Stride - w * 3;
                        pOut += srcData.Stride - w * 3;
                    }
                }
                b.UnlockBits(srcData);
                bmpRtn.UnlockBits(dstData);
                //返回边缘检测结果
                return bmpRtn;
            }
            catch
            {
                return null;
            }
        }

        //边缘检测启动
        private void btnEdgeDetect_Click(object sender, EventArgs e)
        {
            //调用边缘检测方法
            sourceBitmap = EdgeDetect(sourceBitmap);
            this.label2.Text = "边缘检测图";
            Invalidate();
        }

        private void btnChainCode_Click(object sender, EventArgs e)
        {
            if (sourceBitmap == null)
            {
                MessageBox.Show("无图像可处理。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.label1.Text = "图像轮廓";
            //链码数量
            int CodeNum = 0;
            //链码编码
            String ChainCode;
            //颜色对象
            Color c = new Color();
            //链码进行路径动画
            Bitmap box1 = new Bitmap(pictureBox1.Image);
            //临时存储源图像以便扫描
            Bitmap box2 = sourceBitmap;
            int r;
            int i = 0, j = 0;
            int start_x = -2;
            int start_y = -2;
            int previous_x = -2;
            int previous_y = -2;
            int current_x = -1;
            int current_y = -1;

            int[,] ss = new int[600, 600];
            //pictureBox1背景置白色，以便显示链码编码过程
            for (i = 0; i < sourceBitmap.Width-1; i++)
            {
                for (j = 0; j < sourceBitmap.Height-1; j++)
                {
                    Color cc1 = Color.FromArgb(255, 255, 255);
                    box1.SetPixel(i, j, cc1);
                }
            }
            ChainCode = "";
            for (i = 0; i < sourceBitmap.Width-1; i++)
            {
                for (j = 0; j < sourceBitmap.Height-1; j++)
                {
                    c = sourceBitmap.GetPixel(i, j);
                    r = c.R;
                    //找到第一个目标像素点，以此为轮廓抽取的起点
                    if (r < 120)
                    {
                        current_x = i;
                        current_y = j;
                        start_x = i;
                        start_y = j;
                        //跳出起点搜索，转去编码
                        goto ChainCode;
                    }
                }
            }
            ChainCode:
            ChainCode = "起点坐标:("+start_x+","+start_y+")\r\n\r\n8方向链码:\r\n";
            while (previous_x == -2 || (start_x != i || start_y != j))
            {
                //先判断走势方向最右边的点
                if (previous_x == -2 || (current_x == previous_x + 1 && current_y == previous_y - 1) || (current_x == previous_x + 1 && current_y == previous_y))
                {
                    goto Code7;
                }
                if (previous_x == -2 || (current_x == previous_x && current_y == previous_y - 1) || (current_x == previous_x - 1 && current_y == previous_y-1))
                {
                    goto Code1;
                }
                if (previous_x == -2 || (current_x == previous_x - 1 && current_y == previous_y) || (current_x == previous_x - 1 && current_y == previous_y+1))
                {
                    goto Code3;
                }
                if (previous_x == -2 || (current_x == previous_x && current_y == previous_y + 1) || (current_x == previous_x + 1 && current_y == previous_y+1))
                {
                    goto Code5;
                }

                //链码0
                Code0:
                {
                    i++;
                    c = sourceBitmap.GetPixel(i, j);
                    r = c.R;
                    if (r < 120)
                    {
                        Color cc1 = Color.FromArgb(0, 0, 255);
                        box1.SetPixel(i, j, cc1);
                        pictureBox1.Refresh();
                        pictureBox1.Image = box1;
                        ChainCode = ChainCode + "0";
                        previous_x = i - 1;
                        current_x = i;
                        CodeNum++;
                        continue;
                    }
                    i--;
                }
                //链码1
                Code1:
                {
                    i++;
                    j--;
                    c = sourceBitmap.GetPixel(i, j);
                    r = c.R;
                    if (r < 120)
                    {
                        Color cc1 = Color.FromArgb(0, 0, 255);
                        box1.SetPixel(i, j, cc1);
                        pictureBox1.Refresh();
                        pictureBox1.Image = box1;
                        ChainCode = ChainCode + "1";
                        previous_x = i - 1;
                        previous_y = j + 1;
                        current_x = i;
                        current_y = j;
                        CodeNum++;
                        continue;
                    }
                    i--;
                    j++;
                }
                //链码2
                Code2:
                {
                    j--;
                    c = sourceBitmap.GetPixel(i, j);
                    r = c.R;
                    if (r < 120)
                    {
                        Color cc1 = Color.FromArgb(0, 0, 255);
                        box1.SetPixel(i, j, cc1);
                        pictureBox1.Refresh();
                        pictureBox1.Image = box1;
                        ChainCode = ChainCode + "2";
                        previous_y = j + 1;
                        current_x = i;
                        current_y = j;
                        CodeNum++;
                        continue;
                    }
                    j++;
                }
                //链码3
                Code3:
                {
                    i--;
                    j--;
                    c = sourceBitmap.GetPixel(i, j);
                    r = c.R;
                    if (r < 120)
                    {
                        Color cc1 = Color.FromArgb(0, 0, 255);
                        box1.SetPixel(i, j, cc1);
                        pictureBox1.Refresh();
                        pictureBox1.Image = box1;
                        ChainCode = ChainCode + "3";
                        previous_x = i + 1;
                        previous_y = j + 1;
                        current_x = i;
                        current_y = j;
                        CodeNum++;
                        continue;
                    }
                    i++;
                    j++;
                }
                //链码4
                Code4:
                {
                    i--;
                    c = sourceBitmap.GetPixel(i, j);
                    r = c.R;
                    if (r < 120)
                    {
                        Color cc1 = Color.FromArgb(0, 0, 255);
                        box1.SetPixel(i, j, cc1);
                        pictureBox1.Refresh();
                        pictureBox1.Image = box1;
                        ChainCode = ChainCode + "4";
                        previous_x = i + 1;
                        current_x = i;
                        current_y = j;
                        CodeNum++;
                        continue;
                    }
                    i++;
                }
                //链码5
                Code5:
                {
                    i--;
                    j++;
                    c = sourceBitmap.GetPixel(i, j);
                    r = c.R;
                    if (r < 120)
                    {
                        Color cc1 = Color.FromArgb(0, 0, 255);
                        box1.SetPixel(i, j, cc1);
                        pictureBox1.Refresh();
                        pictureBox1.Image = box1;
                        ChainCode = ChainCode + "5";
                        previous_x = i + 1;
                        previous_y = j - 1;
                        current_x = i;
                        current_y = j;
                        CodeNum++;
                        continue;
                    }
                    i++;
                    j--;
                }
                //链码6
                Code6:
                {
                    j++;
                    c = sourceBitmap.GetPixel(i, j);
                    r = c.R;
                    if (r < 120)
                    {
                        Color cc1 = Color.FromArgb(0, 0, 255);
                        box1.SetPixel(i, j, cc1);
                        pictureBox1.Refresh();
                        pictureBox1.Image = box1;
                        ChainCode = ChainCode + "6";
                        previous_y = j + 1;
                        current_x = i;
                        current_y = j;
                        CodeNum++;
                        continue;
                    }
                    j--;
                }
                //链码7
                Code7:
                {
                    i++;
                    j++;
                    c = sourceBitmap.GetPixel(i, j);
                    r = c.R;
                    if (r < 120)
                    {
                        Color cc1 = Color.FromArgb(0, 0, 255);
                        box1.SetPixel(i, j, cc1);
                        pictureBox1.Refresh();
                        pictureBox1.Image = box1;
                        ChainCode = ChainCode + "7";
                        previous_x = i - 1;
                        previous_y = j - 1;
                        current_x = i;
                        current_y = j;
                        CodeNum++;
                        continue;
                    }
                    i--;
                    j--;
                }
                goto Code0;
            }
            //红色标记起点
            Color cc2 = Color.FromArgb(255, 0, 0);
            box1.SetPixel(start_x, start_y, cc2);
            pictureBox1.Refresh();
            pictureBox1.Image = box1;
            //显示链码总数量
            ChainCode = ChainCode + "\r\n\r\n链码总数量：" + Convert.ToString(CodeNum);
            MessageBox.Show(ChainCode, "链码提取结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //细化方法
        public static Bitmap Refine(Bitmap b)
        {
            if (b == null)
            {
                MessageBox.Show("无图像可处理。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            int w = b.Width;
            int h = b.Height;
            try
            {
                //迭代标识
                int flag = 2;
                int[,] DotFlag = new int[w, h];
                Bitmap bmpRtn = new Bitmap(w, h, PixelFormat.Format24bppRgb);
                BitmapData srcData = b.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData dstData = bmpRtn.LockBits(new Rectangle(0, 0, 2, h), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* pIn = (byte*)srcData.Scan0.ToPointer();
                    byte* pOut = (byte*)dstData.Scan0.ToPointer();
                    byte* p = (byte*)srcData.Scan0.ToPointer();
                    int stride = srcData.Stride;
                    int vR = 255, vG = 255, vB = 255;
                    //第一次并行细化
                    while (flag > 1)//flag=0时迭代结束
                    {
                        flag++;//=0;
                        pIn=(byte*)srcData.Scan0.ToPointer();
                        pOut = (byte*)dstData.Scan0.ToPointer();
                        p = (byte*)srcData.Scan0.ToPointer();
                        for(int y = 0; y < h; y++)
                        {
                            for(int x = 0; x < w; x++)
                            {
                                pOut[0] = pIn[0];
                                pOut[1] = pIn[1];
                                pOut[2] = pIn[2];
                                //p[0]=pIn[0];
                                //取周围4点的值，位于边缘上的2点不做改变
                                if (x == 0 || x == 1 || x == w - 1 || x == w - 2 
                                    || y == 0 || y == 1 || y == h - 1 || y == h - 2)
                                {
                                    //不做处理
                                }
                                else
                                {
                                    //模板a
                                    if((pIn-stride+3)[2]==0
                                        &&(pIn-3)[2]==255
                                        &&(pIn)[2]==0
                                        &&(pIn+3)[2]==0
                                        &&(pIn+6)[2]==0
                                        && (pIn + stride + 3)[2] == 0)
                                    {
                                        p[0] = 255;
                                        flag = 1;
                                    }

                                    //模板b
                                    if ((pIn - stride - 3)[2] == 0
                                       && (pIn)[2] == 255
                                       && (pIn-stride)[2] == 0 
                                       && (pIn + 3)[2] == 0
                                       && (pIn + 6)[2] == 0
                                       && (pIn + stride + 3)[2] == 0)
                                    {
                                        p[0] = 255;
                                        flag = 1;
                                    }
                                    //模板c
                                    if ((pIn - 3)[2] == 0
                                       && (pIn - stride)[2] == 255
                                       && (pIn + stride - 3)[2] == 0 
                                       && (pIn - stride + 3)[2] == 0
                                       && (pIn)[2] == 0
                                       && (pIn + 3)[2] == 0
                                       && (pIn + stride)[2] == 0
                                       && (pIn + 6)[2] == 0)
                                    {
                                        p[0] = 255;
                                        flag = 1;
                                    }
                                    //模板d
                                    if ((pIn - stride - 3)[2] == 0
                                       && (pIn + stride)[2] == 255
                                       && (pIn- stride)[2] == 0 
                                       && (pIn - stride + 3)[2] == 0
                                       && (pIn)[2] == 0)
                                    {
                                        p[0] = 255;
                                        flag = 1;
                                    }
                                    //模板e
                                    if ((pIn - stride - 3)[2] == 0
                                       && (pIn + 3)[2] == 255
                                       && (pIn - 3)[2] == 0 
                                       && (pIn)[2] == 0
                                       && (pIn + stride - 3)[2] == 0)
                                    {
                                        p[0] = 255;
                                        flag = 1;
                                    }
                                    //模板f
                                    if ((pIn - stride)[2] == 0
                                       && (pIn - 3)[2] == 255
                                       && (pIn - stride + 3)[2] == 0 
                                       && (pIn)[2] == 0
                                       && (pIn + stride)[2] == 0
                                       && (pIn + 3)[2] == 0)
                                    {
                                        p[0] = 255;
                                        flag = 1;
                                    }
                                    //模板g
                                    if ((pIn + 3)[2] == 0
                                       && (pIn - stride)[2] == 255
                                       && (pIn + stride)[2] == 0 
                                       && (pIn - 3)[2] == 0
                                       && (pIn)[2] == 0
                                       && (pIn + stride + 3)[2] == 0)
                                    {
                                        p[0] = 255;
                                        flag = 1;
                                    }
                                    //模板h
                                    if ((pIn)[2] == 0
                                       && (pIn - stride)[2] == 255
                                       && (pIn + stride - 3)[2] == 0 
                                       && (pIn + stride)[2] == 0
                                       && (pIn + stride + 3)[2] == 0
                                       && (pIn + stride + stride)[2] == 0)
                                    {
                                        p[0] = 255;
                                        flag = 1;
                                    }
                                }
                                pIn += 3;
                                pOut += 3;
                                p += 3;
                            }
                            pIn += srcData.Stride - w * 3;
                            pOut += srcData.Stride - w * 3;
                            p += srcData.Stride - w * 3;
                        }
                        //统一消除点
                        pIn = (byte*)srcData.Scan0.ToPointer();
                        p = (byte*)srcData.Scan0.ToPointer();
                        for(int y = 0; y < h; y++)
                        {
                            for(int x = 0; x < w; x++)
                            {
                                if (p[0] == 255)
                                {
                                    pIn[0] = (byte)vR;
                                    pIn[1] = (byte)vB;
                                    pIn[2] = (byte)vG;
                                }
                                pIn += 3;
                                p += 3;
                            }
                            pIn += srcData.Stride - w * 3;
                            p += srcData.Stride - w * 3;
                        }
                    }
                    //第二次串行细化
                    pIn = (byte*)srcData.Scan0.ToPointer();//指针回到起点
                    for(int y = 0; y < 0; y++)
                    {
                        for(int x = 0; x < 0; x++)
                        {
                            //取周围4点的值，位于边缘上的2点不做改变
                            if (x == 0 || x == w - 1 || x == w - 2 || 
                                y == 0 || y == h - 1 || y == h - 2)
                            {
                                //不做处理
                            }
                            else
                            {
                                //缩小后的模板a
                                if ((pIn - stride - 3)[2] == 255
                                        && (pIn)[2] == 0
                                        && (pIn - 3)[2] == 255
                                        && (pIn - stride + 3)[2] == 0
                                        && (pIn + 3)[2] == 0
                                        &&(pIn+stride+3)[2]==0
                                        &&(pIn+stride-3)[2]==255)
                                {
                                    pIn[0] = (byte)vR;
                                    pIn[1] = (byte)vB;
                                    pIn[2] = (byte)vG;
                                }
                                //缩小后的模块h
                                if ((pIn - stride - 3)[2] == 255
                                        && (pIn)[2] == 0
                                        && (pIn - stride)[2] == 255
                                        && (pIn + stride - 3)[2] == 0
                                        && (pIn + stride)[2] == 0
                                        && (pIn + stride + 3)[2] == 0
                                        && (pIn - stride + 3)[2] == 255)
                                {
                                    pIn[0] = (byte)vR;
                                    pIn[1] = (byte)vB;
                                    pIn[2] = (byte)vG;
                                }
                                //直角的转折点消除模块*（自增加模板）
                                if((pIn)[2]==0 &&((pIn - stride)[2] == 0
                                    &&(pIn - 3)[2]==0)||((pIn - 3)[2] == 0
                                    &&(pIn + stride)[2] == 0)
                                    ||((pIn + stride)[2]==0 &&(pIn + 3)[2] == 0)
                                    || ((pIn + 3)[2] == 0 && (pIn - stride)[2] == 0))
                                {
                                    pIn[0] = (byte)vR;
                                    pIn[1] = (byte)vB;
                                    pIn[2] = (byte)vG;
                                }
                            }
                            pIn += 3;
                        }
                        pIn += srcData.Stride - w * 3;
                    }
                    //显示图像
                    pOut = (byte*)dstData.Scan0.ToPointer();
                    pIn = (byte*)srcData.Scan0.ToPointer();
                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                                pOut[0] = pIn[0];
                                pOut[1] = pIn[1];
                                pOut[2] = pIn[2];
                                pIn += 3;
                                pOut += 3;
                        }
                        pIn += srcData.Stride - w * 3;
                        pOut += srcData.Stride - w * 3;
                    }
                }
                b.UnlockBits(srcData);
                bmpRtn.UnlockBits(dstData);
                return bmpRtn;
            }
            catch
            {
                return null;
            }
        }
        //细化启动
        private void btnRefine_Click(object sender, EventArgs e)
        {
            //调用细化方法
            sourceBitmap = Refine(sourceBitmap);
            this.label2.Text = "细化图";
            Invalidate();
        }


        //腐蚀方法
        /// <param name="dgGrayValue">前后景临界值</param>
        public static Bitmap Corrode(Bitmap bmpobj)
        {
            if (bmpobj == null)
            {
                MessageBox.Show("无图像可处理。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            //设置前后景临界值
            int dgGrayValue = 0;
            String BkFwdThreshold = Interaction.InputBox("请输入一个0~255之间的前后景临界值。", "前后景临界值设置", "120", 100, 100);
            if (BkFwdThreshold == "" || 
                Convert.ToInt16(BkFwdThreshold) < 0 || 
                Convert.ToInt16(BkFwdThreshold) > 255)
            {
                MessageBox.Show("前后景必须在0~255之间。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            dgGrayValue = Convert.ToInt16(BkFwdThreshold);
            int lWidth = bmpobj.Width;
            int lHeight = bmpobj.Height;
            try
            {
                //循环变量
                int dot;
                Bitmap bmpRtn = new Bitmap(lWidth, lHeight, PixelFormat.Format24bppRgb);
                BitmapData srcData = bmpobj.LockBits(new Rectangle(0, 0, lWidth, lHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData dstData = bmpobj.LockBits(new Rectangle(0, 0, lWidth, lHeight), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* pIn = (byte*)srcData.Scan0.ToPointer();
                    byte* pOut = (byte*)dstData.Scan0.ToPointer();
                    byte* p;
                    int stride = srcData.Stride;
                    for(int y = 0; y < lHeight; y ++)
                    {
                        for(int x = 0; x < lWidth; x++)
                        {
                            //为防止越界。所以不处理最左边与最右边的
                            //两列像素和最上边与最下边的两行像素
                            if (x == 0 || x == lWidth - 1 || y == 0 || y == lHeight - 1)
                            {
                                //不做颜色处理
                                pOut[0] = pIn[0];
                                pOut[1] = pIn[1];
                                pOut[2] = pIn[2];
                            }
                            else
                            {
                                //目标图像中的当前点先赋成黑色
                                pOut[0] = (byte)0;
                                pOut[1] = (byte)0;
                                pOut[2] = (byte)0;
                                //如果源图像中当前点自身或者上、下、左、右中有一个点不是黑色，
                                //则将目标图像中的当前点赋成白色
                                dot = 0;
                                
                                //当前像素点
                                p = pIn;
                                if (p[2] > dgGrayValue)
                                {
                                    dot += 1;
                                }

                                //左侧像素点
                                p = pIn - 3;
                                if (p[2] > dgGrayValue)
                                {
                                    dot += 1;
                                }

                                //右侧像素点
                                p = pIn + 3;
                                if (p[2] > dgGrayValue)
                                {
                                    dot += 1;
                                }

                                //正上像素点
                                p = pIn - stride;
                                if (p[2] > dgGrayValue)
                                {
                                    dot += 1;
                                }

                                //正下像素点
                                p = pIn + stride;
                                if (p[2] > dgGrayValue)
                                {
                                    dot += 1;
                                }

                                if (dot > 0)
                                {
                                    pOut[0] = (byte)255;
                                    pOut[1] = (byte)255;
                                    pOut[2] = (byte)255;
                                }
                            }
                            pIn += 3;
                            pOut += 3;
                        }
                        pIn += srcData.Stride - lWidth * 3;
                        pOut += srcData.Stride - lWidth * 3;
                    }
                }
                bmpobj.UnlockBits(srcData);
                bmpRtn.UnlockBits(dstData);
                return bmpRtn;
            }
            catch
            {
                return null;
            }
        }
        //腐蚀启动
        private void btnCorrode_Click(object sender, EventArgs e)
        {
            //调用腐蚀方法
            bool[,] s = { 
                { true, true, true }, 
                { true, false, true }, 
                { true, true, true }
            };
            sourceBitmap = Corrode(sourceBitmap);
            this.label2.Text = "腐蚀图";
        }


        //膨胀方法
        /// <param name="dgGrayValue">前后景临界值</param>
        public static Bitmap Expand(Bitmap bmpobj)
        {
            if (bmpobj == null)
            {
                MessageBox.Show("无图像可处理。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            //设置前后景临界值
            int dgGrayValue = 0;
            String BkFwdThreshold = Interaction.InputBox("请输入一个0~255之间的前后景临界值。", "前后景临界值设置", "120", 100, 100);
            if (BkFwdThreshold == "" ||
                Convert.ToInt16(BkFwdThreshold) < 0 ||
                Convert.ToInt16(BkFwdThreshold) > 255)
            {
                MessageBox.Show("前后景必须在0~255之间。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            dgGrayValue = Convert.ToInt16(BkFwdThreshold);
            int lWidth = bmpobj.Width;
            int lHeight = bmpobj.Height;
            try
            {
                //循环变量
                int dot;
                Bitmap bmpRtn = new Bitmap(lWidth, lHeight, PixelFormat.Format24bppRgb);
                BitmapData srcData = bmpobj.LockBits(new Rectangle(0, 0, lWidth, lHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData dstData = bmpobj.LockBits(new Rectangle(0, 0, lWidth, lHeight), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* pIn = (byte*)srcData.Scan0.ToPointer();
                    byte* pOut = (byte*)dstData.Scan0.ToPointer();
                    byte* p;
                    int stride = srcData.Stride;
                    for (int y = 0; y < lHeight; y++)
                    {
                        for (int x = 0; x < lWidth; x++)
                        {
                            //为防止越界。所以不处理最左边与最右边的
                            //两列像素和最上边与最下边的两行像素
                            if (x == 0 || x == lWidth - 1 || y == 0 || y == lHeight - 1)
                            {
                                //不做颜色处理
                                pOut[0] = pIn[0];
                                pOut[1] = pIn[1];
                                pOut[2] = pIn[2];
                            }
                            else
                            {
                                //目标图像中的当前点先赋成白色
                                pOut[0] = (byte)255;
                                pOut[1] = (byte)255;
                                pOut[2] = (byte)255;
                                //如果源图像中当前点自身或者上、下、左、右中有一个点不是白色，
                                //则将目标图像中的当前点赋成黑色
                                dot = 0;

                                //当前像素点
                                p = pIn;
                                if (p[2] < dgGrayValue)
                                {
                                    dot += 1;
                                }

                                //左侧像素点
                                p = pIn - 3;
                                if (p[2] < dgGrayValue)
                                {
                                    dot += 1;
                                }

                                //右侧像素点
                                p = pIn + 3;
                                if (p[2] < dgGrayValue)
                                {
                                    dot += 1;
                                }

                                //正上像素点
                                p = pIn - stride;
                                if (p[2] < dgGrayValue)
                                {
                                    dot += 1;
                                }

                                //正下像素点
                                p = pIn + stride;
                                if (p[2] < dgGrayValue)
                                {
                                    dot += 1;
                                }

                                if (dot > 0)
                                {
                                    pOut[0] = (byte)0;
                                    pOut[1] = (byte)0;
                                    pOut[2] = (byte)0;
                                }
                            }
                            pIn += 3;
                            pOut += 3;
                        }
                        pIn += srcData.Stride - lWidth * 3;
                        pOut += srcData.Stride - lWidth * 3;
                    }
                }
                bmpobj.UnlockBits(srcData);
                bmpRtn.UnlockBits(dstData);
                //返回膨胀结果
                return bmpRtn;
            }
            catch
            {
                return null;
            }
        }
        //膨胀启动
        private void btnExpand_Click(object sender, EventArgs e)
        {
            //调用膨胀方法
            sourceBitmap = Expand(sourceBitmap);
            this.label2.Text = "膨胀图";
        }
    }
}
