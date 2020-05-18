using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace chpt8_5a_FTPUpDpwnload
{
    public partial class Form1 : Form
    {
        //定义字段
        string ftpServerIP;
        string ftpUserID;
        string ftpPassword;

        public Form1()
        {
            InitializeComponent();
        }

        //初始化设置
        private void Form1_Load(object sender, EventArgs e)
        {
            ftpServerIP = "127.0.0.1";
            ftpUserID = "anonymous";//也可以使用系统账户，如Administrator，但需输入密码
            //ftpPassword="...";
            txtServerIP.Text = ftpServerIP;
            txtUsername.Text = ftpUserID;
            txtPasserword.Text = ftpPassword;
            //btnFTPSave.Enabled=false;
        }

        //用户名一旦修改，需要重新登录
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            btnFTPSave.Enabled = true;
        }
        //密码一旦修改，需要重新登录
        private void txtPasserword_TextChanged(object sender, EventArgs e)
        {
            btnFTPSave.Enabled = true;
        }

        //登录FTP服务器，并显示其文件名列表
        private void btnFTPSave_Click(object sender, EventArgs e)
        {
            ftpServerIP = txtServerIP.Text.Trim();//trim简单理解就是去掉输入中的空格
            ftpUserID = txtUsername.Text.Trim();
            ftpPassword = txtPasserword.Text.Trim();

            //调用文件列表
            string[] filenames = GetFilesList();//getfileslist这玩意儿是个函数？
            listFiles.Items.Clear();
            try
            {
                foreach (string filename in filenames)
                {
                    listFiles.Items.Add(filename);
                }
            }
            catch
            {
                return;
            }
        }

        //文件列表
        public string[] GetFilesList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();//定义一个可变字符串变量；

            FtpWebRequest reqFTP;//实现文件传输协议（FTP）客户端
            try
            {
                //为指定的URI创建FtpWebRequest实例；说实话，这里看着有些复杂
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/"));

                reqFTP.UseBinary = true;//采用二进制数据类型传输
               
                //获取与FTP服务器通信的凭据
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                
                //获取FTP服务器上的文件的简短列表
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;

                //提供来自URI的响应
                WebResponse response = reqFTP.GetResponse();

                //从字节流中读取字符
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string line = reader.ReadLine();//持续读取文件名以便列表显示
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }

                //去除最后一个多余的换行符('\n');那这里的1是什么意思，mb，书写的真烂
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                
                //关闭读取文件名列表以便显示
                reader.Close();
                response.Close();

                //返回文件名列表结果
                return result.ToString().Split('\n');
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
        }


        //开始上传文件
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFilDlg = new OpenFileDialog();
            if (opFilDlg.ShowDialog() == DialogResult.OK)
            {
                //调用“上传文件”
                Upload(opFilDlg.FileName);

                //刷新文件名列表
                string[] filenames = GetFilesList();
                listFiles.Items.Clear();
                foreach(string filename in filenames)
                {
                    listFiles.Items.Add(filename);
                }
                MessageBox.Show("文件上传结束。");
            }
        }

        //上传文件
        private void Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            FtpWebRequest reqFTP;//实现文件传输协议（FTP）客户端

            //为指定的URI创建FtpWebRequest对象
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileInf.Name));

            //设置用于与ftp服务器通信的凭据（用户名和密码）
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

            //默认为true，在一个命令之后被执行，连接不会被关闭
            reqFTP.KeepAlive = false;

            //执行上传命令
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            //指定数据传输类型（二进制）
            reqFTP.UseBinary = true;

            //上传时通知服务器文件的大小
            reqFTP.ContentLength = fileInf.Length;

            //缓冲大小设置为2KB
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contenLen;

            //打开一个文件流（System.IO.FileStream）来读上传文件
            FileStream fs = fileInf.OpenRead();
            try
            {
                //检索用于向FTP服务器上载数据的流
                Stream strm = reqFTP.GetRequestStream();

                //每次从文件流中读入2kb（缓冲大小）
                contenLen = fs.Read(buff, 0, buffLength);
                //持续进行文件流的读写，直至全部结束
                while (contenLen != 0)
                {
                    //将所读取的文件流写入到上传的字节序列
                    strm.Write(buff, 0, contenLen);
                    contenLen = fs.Read(buff, 0, buffLength);
                }
                //关闭文件流和上传流
                strm.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "文件上传出错。");
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fldDlg = new FolderBrowserDialog();
            if (listFiles.Text.Trim().Length > 0)
            {
                if (fldDlg.ShowDialog() == DialogResult.OK)
                {
                    //调用“下载文件”
                    Download(fldDlg.SelectedPath, listFiles.Text.Trim());
                }
                MessageBox.Show("文件下载结束。");
            }
            else
            {
                MessageBox.Show("请选择需要下载的文件。");
            }
        }

        //下载文件
        private void Download(string filePath,string fileName)
        {
            FtpWebRequest reqFTP;
            try
            {
                //设置文件下载后保存的路径（文件夹）：filePath
                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);
                //命名下载后的文件名（可与原文件名不同）：fileName
                reqFTP = (FtpWebRequest)FtpWebRequest.Create
                    (new Uri("ftp://" + ftpServerIP + "/" + fileName));

                //指定执行下载命令
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

                //返回FTP服务器响应
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                //检索从FTP服务器上发送的响应数据的流
                Stream ftpStream = response.GetResponseStream();

                //获取从FTP服务器上接收的数据的长度
                long cl = response.ContentLength;
                int bufferSize = 2048;               
                byte[] buffer = new byte[bufferSize];

                //从当前流读取字节序列，并从此流中的位置提升读取的字节数
                int readCount;
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    //使用缓冲区中读取的数据，将字节块写入该流
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                //关闭两个流
                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
