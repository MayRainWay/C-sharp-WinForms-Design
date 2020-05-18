using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace chpt8_4b_UDPReceive
{
    public partial class Form1 : Form
    {
        UdpClient udpClient;//定义一个UdpClient类型的字段
        Thread thread;//定义一个线程
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;//屏蔽异常以便跨线程访问控件
            InitializeComponent();
            udpClient = new UdpClient(13579);//创建一个与指定端口绑定的UdpClient实例，此端口需与发送方端口相同
        }

        //监听并接收数据
        private void listen()
        {
            IPEndPoint iep = null;
            //定义一个终结点，因为此前创建的UdpClient实例已于指定端口绑定

            while (true)
            {
                string sData = System.Text.Encoding.UTF8.GetString(udpClient.Receive(ref iep));
                //获得发送方的数据包并转换为指定字符类型；
                //ref关键字使参数按引用传递，当控制权传给调用方法时，
                //在方法中对参数所做的任何更改都将反映在该变量中

                this.listBox1.Items.Add(sData);
                //将接收到的数据添加到listBox1的条目中
            }
        }

        //启动数据接收
        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(listen));//创建一个线程以监听并接收数据
            thread.IsBackground = true;//设置为后台线程，以便关闭窗体时终止线程
            thread.Start();
        }

        //关闭窗体时终止线程
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
            }
        }
    }
}
