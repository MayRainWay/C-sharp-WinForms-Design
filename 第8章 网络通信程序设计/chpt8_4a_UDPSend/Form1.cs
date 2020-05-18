using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace chpt8_4a_UDPSend
{
    public partial class Form1 : Form
    {
        UdpClient udpClient;//定义一个UdpClient类型的字段；
        public Form1()
        {
            udpClient = new UdpClient();//创建一个
            InitializeComponent();
        }

        //发送数据
        private void button1_Click(object sender, EventArgs e)
        {
            string temp = this.textBox1.Text;//临时存储textBox1中的数据
            byte[] bData = System.Text.Encoding.UTF8.GetBytes(temp);
            //将textbox1中的数据（文本）转化为字节编码以便发送

            //向本机的13579端口发送数据（方法1）
            //udpClient.Send(bData,bData.Length,Dns.GetHostName(),13579);
            //向本机的13579端口发送数据(方法2)
            //利用方法2，可向其他计算机端口发送数据
            udpClient.Connect(IPAddress.Parse("127.0.0.1"), 13579);
            udpClient.Send(bData, bData.Length);
        }
    }
}
