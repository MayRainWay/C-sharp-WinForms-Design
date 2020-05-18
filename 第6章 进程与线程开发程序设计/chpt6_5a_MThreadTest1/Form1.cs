using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace chpt6_5a_MThreadTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //此delegate通过异步操作方式设置控件TextBox1的Text属性
        delegate void SetTextDelegate(string text);
        //这个东西在C#里面叫委托，类似于C语言中的函数指针，书里没教！！！
        //超前了！！！md，垃圾！！！

        //创建用来计数的线程对象
        private Thread thread = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(counter));  //线程初始化
            thread.Start();     //启动计数线程
        }

        //线程（thread）的计数方法
        private void counter()
        {
            while (true)
            {
                int i;
                for (i = 0; i < 1000; i++)
                {
                    this.SetText(i.ToString()); // 调用工作线程
                }
                Thread.Sleep(3000);     //线程休眠3秒
            }
        }

        //名为SetTextDelegate的委托类型封装SetText方法
        private void SetText(string text)
        {
            //InvokeRequire 比较线程ID以及创建控件的线程ID
            //如果不同，则返回ture
            if (this.textBox1.InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread.Abort();     //销毁计数线程

            //调用RunWorkerAsync方法启动BackgroundWoker，
            this.backgroundWorker1.RunWorkerAsync();
           //控件TextBox2的Text属性设置将在BackgroundWoker发生RunWokerCompleted事件之后完成

            button1.Enabled = false;
        }

        //通过调用创建控件的线程来更改控件属性，所以线程是安全的
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.textBox2.Text = "计数线程终止";
        }


    }
}
