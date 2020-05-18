using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Threading;

namespace chpt6_3a_MthreadTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // CheckForIllegalCrossThreadCalls = false;//禁用此异常
        }

        //private Thread thread1 = null;
        //private Thread thread2 = null;  //创建用来计数的线程对象

        //线程1（thread1）的计数方法
        public void counter1()
        {
            //while (true)
            {
                int i;
                for (i = 0; i < 1000; i++)
                {
                    textBox1.Text = i.ToString();
                }
               // Thread.Sleep(3000);//线程休眠3秒
            }
        }

        //线程2（thread2）的计数方法
        public void counter2()
        {
            //while (true)
            {
                int j;
                for (j = 0; j < 1000; j++)
                {
                    textBox2.Text = j.ToString();
                }
                //Thread.Sleep(3000);//线程休眠3秒
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //thread1 = new Thread(new ThreadStart(counter1));//线程初始化;也可以简写，把new ThreadStart去掉
            //thread2 = new Thread(new ThreadStart(counter2));
            //thread1.Start();
            //thread2.Start();    //启动线程
            counter1();
            counter2();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //thread1.Abort();
            //thread2.Abort();  //销毁线程
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //thread1 = new Thread(new ThreadStart(counter1));//线程初始化;也可以简写，把new ThreadStart去掉
            //thread2 = new Thread(new ThreadStart(counter2));
            //thread1.Start();
            //thread2.Start();    //启动线程
            //button1.Enabled = false;
            //counter1();
            //counter2();
        }
    }
}
