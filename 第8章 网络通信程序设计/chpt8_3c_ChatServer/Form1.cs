using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace chpt8_3c_ChatServer
{
    public partial class Form1 : Form
    {
        private Socket socket;
        private Socket clientSocket;
        private Thread tAcceptMSG;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//禁用此异常
        }

        //接收信息
        private void AcceptMessage()
        {
            while (true)
            {
                try
                {
                    NetworkStream nStream = new NetworkStream(clientSocket);
                    byte[] datasize = new byte[4];
                    nStream.Read(datasize, 0, 4);
                    int size = System.BitConverter.ToInt32(datasize, 0);
                    Byte[] message = new byte[size];
                    int dataleft = size;
                    int start = 0;

                    while (dataleft > 0)
                    {
                        int recv = nStream.Read(message, start, dataleft);
                        start += recv;
                        dataleft -= recv;
                    }
                    this.rtbAccept.Rtf = System.Text.Encoding.Unicode.GetString(message);
                }
                catch
                {
                    this.lbServerSate.Text = "与客户机断开连接";
                    break;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.buttonStart.Enabled = false;
            IPAddress ip = IPAddress.Parse(this.tbIP.Text);
            IPEndPoint IPP = new IPEndPoint(ip, Int32.Parse(this.tbPort.Text));
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(IPP);
            socket.Listen(10);//侦听客户端连接
            clientSocket = socket.Accept();
            this.lbServerSate.Text = "与客户机" + clientSocket.RemoteEndPoint.ToString() + "成功建立连接。";

            tAcceptMSG = new Thread(new ThreadStart(AcceptMessage));
            tAcceptMSG.Start();
        }

        //发送信息
        private void rtbSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)//按下的是enter键
            {
                string str = this.rtbSend.Rtf;
                int i = str.Length;
                if (i == 0)
                {
                    return;
                    //这里我猜测是什么都不做，不进入else
                }
                else
                {
                    i *= 2;
                    //因为str为Unicode编码，每个字符占2B，所以实际字节数应*2；
                }
                byte[] datasize = new byte[4];//将32位整数值转换为字节数组
                datasize = System.BitConverter.GetBytes(i);
                byte[] sendbytes = System.Text.Encoding.Unicode.GetBytes(str);
                try
                {
                    NetworkStream netStream = new NetworkStream(clientSocket);
                    netStream.Write(datasize, 0, 4);
                    netStream.Write(sendbytes, 0, sendbytes.Length);
                    netStream.Flush();
                    this.rtbSend.Rtf = "";
                }
                catch
                {
                    MessageBox.Show("信息无法发送！");
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                socket.Close();
                tAcceptMSG.Abort();
            }
            catch
            {
                //这里不需要异常处理，其实说实话，这里干脆砍掉try和catch也行
            }
        }
    }
}
