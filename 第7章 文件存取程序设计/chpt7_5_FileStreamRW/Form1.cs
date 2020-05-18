using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace chpt7_5_FileStreamRW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sf = new SaveFileDialog();    //实例化一个保存文件对话框            
            sf.Filter = "txt文件|*.txt|所有文件|*.*";     //设置文件保存类型            
            sf.AddExtension = true;                      //如果用户没有输入扩展名，自动追加后缀
            sf.Title = "写文件";       //设置标题

            //选择写入方法后，单击“写入文件”按钮
            //利用FileStream类写入
            if (radioButton1.Checked)
            {
                //写入文件
                if (sf.ShowDialog() == DialogResult.OK)//这段话的作用，我感觉是负责调出窗口？
                {
                    //实例化一个文件流，与写入文件相关联
                    FileStream fs = new FileStream(sf.FileName, FileMode.Create);

                    //从当前窗体的文本框中获得字节数组
                    byte[] data = new UTF8Encoding().GetBytes(this.textBox1.Text);

                    //开始写入
                    fs.Write(data, 0, data.Length);

                    fs.Flush();//清空缓冲区
                    fs.Close();//关闭流
                }
            }
            //利用streamwriter类写入文件
            if (radioButton2.Checked)
            {
                //写入文件
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    //实例化一个文件流，与写入的文件相关联
                    FileStream fs = new FileStream(sf.FileName, FileMode.Create);

                    //实例化一个streamwriter，与fs相关联
                    StreamWriter sw = new StreamWriter(fs);
                    //开始写入
                    sw.Write(this.textBox1.Text);
                    //清空缓冲区
                    sw.Flush();

                    //关闭流
                    sw.Close();
                    fs.Close();
                }
            }
            else
            {
                //写入文件
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    //实例化一个文件流，与写入的文件相关联
                    FileStream fs = new FileStream(sf.FileName, FileMode.Create);
                    
                    BinaryWriter bw = new BinaryWriter(fs); //实例化binarywriter,与fs文件流相关联
                    bw.Write(this.textBox1.Text);       //开始写入

                    bw.Flush();//清空缓冲区

                    //关闭流
                    bw.Close();
                    fs.Close();
                }
            }
        }
    }
}
