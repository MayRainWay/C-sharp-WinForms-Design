using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;//添加命名空间引用

namespace chapt6_4a_ThreadMutex1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//禁用此异常
        }

        //创建显示字符的线程对象
        private Thread thread1 = null;
        private Thread thread2 = null;

        //显示字符
        private void ShowChar(char ch)
        {
            lock (this)
            {
                richTextBox1.Text += ch;
            }
        }

        //线程thread1调用的方法（显示字符a）
        private void thread1Show()
        {
            while (true)
            {
                ShowChar('a');
                Thread.Sleep(60);
            }
        }

        //线程thread2调用的方法（显示字符A）
        private void thread2Show()
        {
            while (true)
            {
                ShowChar('A');
                Thread.Sleep(30);
            }
        }

        //线程初始化，并启动线程
        private void button1_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(new ThreadStart(thread1Show));
            thread2 = new Thread(new ThreadStart(thread2Show));
            thread1.Start();
            thread2.Start();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        //终止线程
        private void button2_Click(object sender, EventArgs e)
        {
            thread1.Abort();
            thread2.Abort();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
        }

        //关闭窗体时终止线程（否则，VS调试程序仍将处于运行状态）
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread1 != null)
            {
                thread1.Abort();
            }
            if (thread2 != null)
            {
                thread2.Abort();
            }
        }
    }
}
