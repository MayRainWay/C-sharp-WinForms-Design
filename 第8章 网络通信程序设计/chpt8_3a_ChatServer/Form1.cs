using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//添加新的命名空间引用
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace chpt8_3a_ChatServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//禁用此异常
        }
        private bool bConnected = false;//客户机与服务器之间的连接状态
        private Thread tAcceptMsg = null;//侦听线程
        private IPEndPoint IPP = null;//用于socket通信的IP地址和端口

        //Socket通信
        private Socket socket = null;
        private Socket clientSocket = null;

        private NetworkStream nStream = null;//网络访问的基础数据流
        private TextReader tReader = null;//创建读取器
        private TextWriter tWriter = null;//创建编写器

        //显示信息
        public void AcceptMessage()
        {
            clientSocket = socket.Accept();//接受客户机的连接请求
            if (clientSocket != null)
            {
                bConnected = true;
                this.label1.Text = "与客户" + clientSocket.RemoteEndPoint.ToString() + "成功建立连接。";
            }
            nStream = new NetworkStream(clientSocket);//创建clientSocket字节流实例
            tReader = new StreamReader(nStream);//读字节流
            tWriter = new StreamWriter(nStream);//写字节流

            string sTemp;//临时存储读取的字符串
            while (bConnected)
            {
                try
                {
                    sTemp = tReader.ReadLine();//连续从当前流中读取字符串直至结束
                    if (sTemp.Length != 0)
                    {
                        lock (this)
                        {
                            richTextBox1.Text = "客户机：" + sTemp + "\n" + richTextBox1.Text;
                            //richTextBox2_KeyPress()和AcceptMessage()都向richTextBox1写字符，
                            //可能访问有冲突，所以需要多线程互斥
                        }
                    }
                }
                catch
                {
                    tAcceptMsg.Abort();
                    MessageBox.Show("无法与客户机通信");
                }
            }
            clientSocket.Shutdown(SocketShutdown.Both);//禁止当前Socket上的发送和接受
            clientSocket.Close();//关闭Socket，并释放所有关联的资源
            socket.Shutdown(SocketShutdown.Both);//同上
            socket.Close();
        }

        //启动侦听并显示聊天信息
        private void button1_Click(object sender, EventArgs e)
        {
            IPP = new IPEndPoint(IPAddress.Any, 65535);
            socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            //服务器侦听端口可预先指定（此处使用了端口最大值）
            //Any表示服务器应侦听所有网络接口上的客户活动
            socket.Bind(IPP);//关联（绑定）节点
            socket.Listen(0);//0表示连接数量不限

            //创建侦听线程
            tAcceptMsg = new Thread(new ThreadStart(this.AcceptMessage));
            tAcceptMsg.Start();
            button1.Enabled = false;
        }

        //发送信息
        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {//KeyPress是按键事件
            if (e.KeyChar == (char)13)//按下的是Enter键
            {
                if (bConnected)
                {
                    try
                    { //richTextBox2_KeyPress()和AcceptMessage()都向richTextBox1写字符，
                      //可能访问有冲突，所以需要多线程互斥
                        lock (this)
                        {
                            richTextBox1.Text = "服务器：" + richTextBox2.Text + richTextBox1.Text;

                            tWriter.WriteLine(richTextBox2.Text);
                            //客户机聊天信息写入网络流，以便服务器接受
                            //这里我个人理解是，writeline把richtextbox2.text写入了twriter里

                            tWriter.Flush();//清理当前缓冲区数据，使所有缓冲区数据写入基础设备

                            //发送成功后，清空输入框并聚焦
                            richTextBox2.Text = "";
                            richTextBox2.Focus();
                        }

                    }
                    catch
                    {
                        MessageBox.Show("无法与客户机通信！");
                    }
                }
                else
                {
                    MessageBox.Show("未与客户机建立连接，不能通信。");
                }
            }

        }

        //关闭窗体时断开socket连接，并终止线程（否则，VS调试程序将仍处于运行状态）
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                socket.Close();
                tAcceptMsg.Abort();
            }
            catch
            {
                //此处无需异常处理
            }
        }
    }
}
