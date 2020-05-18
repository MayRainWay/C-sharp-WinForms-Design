using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace chpt6_4d_ThreadSynchronize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        //创建一个互斥体对象（“令牌”）
        static object product = new object();

        int iMaxProduct = 10;//最大生产数量
        int iNewProduct = 0;//待装数量
        int iConvey = 0;//装运数量统计
        bool blStopProduce = false;//停止生产和装运标记

        //创建生产和装运线程对象
        private Thread thrdProduce = null;
        private Thread thrdConvey = null;
        
        //生产线程的调用方法
        private void Produce()
        {
            while (!blStopProduce)
            {
                lock (product)
                {
                    for(int i = 1; i < iMaxProduct + 1; i++)
                    {
                        this.lstProduction.Items.Add(i.ToString());//where is items?
                        iNewProduct++;
                        this.lbConvey.Text = iNewProduct.ToString();
                        if (i == iMaxProduct)
                        {
                            this.lstProduction.Items.Add("生产结束");
                            blStopProduce = true;
                        }
                        Thread.Sleep(500);//延时0.5秒，以便观察程序执行过程
                        Monitor.Pulse(product);
                        Monitor.Wait(product);
                    }
                }
            }
        } 

        //装运线程调用的方法
        private void Convey()
        {
            while (true)
            {
                lock (product)
                {
                    iConvey = iConvey + iNewProduct;
                    this.lstConvey.Items.Add(iConvey.ToString());
                    iNewProduct--;
                    this.lbConvey.Text = iNewProduct.ToString();
                    if (blStopProduce)
                    {
                        this.lstConvey.Items.Add("装运完成");
                    }
                    Thread.Sleep(500);//延时0.5秒，以便观察程序执行过程
                    Monitor.Pulse(product);
                    Monitor.Wait(product);
                }
            }
        }

        //线程初始化并启动
        private void btnStart_Click(object sender, EventArgs e)
        {
            thrdProduce = new Thread(new ThreadStart(Produce));
            thrdConvey = new Thread(new ThreadStart(Convey));
            thrdProduce.Start();
            thrdConvey.Start();
            btnStart.Enabled = false;
            btnAbort.Enabled = true;
        }


        //终止线程，并重新初始化各参数
        private void btnAbort_Click(object sender, EventArgs e)
        {
            thrdProduce.Abort();
            thrdConvey.Abort();
            btnStart.Enabled = true;
            btnAbort.Enabled = false;
            this.lstProduction.Items.Clear();
            this.lstProduction.Items.Add("0");
            this.lstConvey.Items.Clear();
            this.lstConvey.Items.Add("0");
            this.lbConvey.Text = "0";
            blStopProduce = false;
            iNewProduct = 0;
            iConvey = 0;
        }
    }
}
