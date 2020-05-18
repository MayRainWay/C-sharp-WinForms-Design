using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//添加命名空间引用
using System.Net;
using System.IO;
using System.Threading;

namespace chpt8_5b_INETUpDownload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//禁用此异常以便跨线程访问空间
        }

        //下载文件
        private void StartDownload()
        {
            btnDownload.Enabled = false;
            string URI = uriAddress.Text;//设置URI的相关数值
            int n = URI.LastIndexOf('/');
            string URIAddress = URI.Substring(0,n);
            string fileName = URI.Substring(n + 1, URI.Length - n - 1);

            string Dir = SaveFileAddress.Text;
            string Path = Dir + '\\' + fileName;
            try
            {
                WebRequest myre = WebRequest.Create(URIAddress);
                //调用WebClient类的实例对象前，需用WebRequest类的对象
                //发出对统一资源标识符（URI）的请求，即，
                //WebClient类使用WebRequest类提供对资源的访问
            }
            catch(WebException exp)
            {
                MessageBox.Show(exp.Message, "创建URI错误");
            }

            WebClient DownLoadClient = new WebClient();//创建WebClient实例

            try
            {
                statusBar.Text = "开始下载文件";
                DownLoadClient.DownloadFile(URI, Path);//将具有指定URI的资源下载到本地文件
                statusBar.Text = "下载完成";
            }
            catch(WebException exp)
            {
                MessageBox.Show(exp.Message, "下载错误");
                statusBar.Text = "";
            }
            btnDownload.Enabled = true;
        }

        //开始下载文件
        private void btnDownload_Click(object sender, EventArgs e)
        {
            Thread thDownLoad = new Thread(new ThreadStart(StartDownload));
            thDownLoad.Start();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            if (dlgSaveFile.ShowDialog() == DialogResult.OK)
            {
                string sFileInfor = dlgSaveFile.FileName;
                SaveFileAddress.Text = sFileInfor.Substring(0, sFileInfor.LastIndexOf("\\"));
                statusBar.Text = "就绪";
            }
        }

        //上传文件
        private void StartUpLoad()
        {
            //注：uriAddress文件夹有匿名可写的权限
            if (UploadFileInfor.Text.Trim() == "" || uriAddress.Text.Trim() == "")
            {
                MessageBox.Show("请输入要上载的文件名。", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //设置上传文件名及服务器路径
                string filenamepath = UploadFileInfor.Text.Trim();
                string uristring = uriAddress.Text.Trim();
                string filename = filenamepath.Substring(filenamepath.LastIndexOf("\\") + 1);
                if (uristring.EndsWith("/") == false)
                {
                    uristring = uristring + "/";
                }
                uristring = uristring + filename;

                WebClient UpLoadClient = new WebClient();//创建WebClient实例
                UpLoadClient.Credentials = CredentialCache.DefaultCredentials;//获取与FTP服务器通信的凭据
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);//以文件流形式上传文件
                BinaryReader r = new BinaryReader(fs);//采用二进制数据流
                try
                {
                    //从当前流中读入指定长度的字节到字节数组
                    byte[] postarray = r.ReadBytes((int)fs.Length);
                    //打开一个文件进行写操作
                    Stream poststream = UpLoadClient.OpenWrite(uristring, "put");
                    if (poststream.CanWrite)
                    {
                        //向当前流中写入字节序列（上传文件）
                        poststream.Write(postarray, 0, postarray.Length);
                        statusBar.Text = filename + "上传成功！";
                    }
                    else
                    {
                        statusBar.Text = "文件目前不可写";
                    }
                    poststream.Close();//关闭流
                }
                catch(WebException errmsg)
                {
                    statusBar.Text = "上传失败：" + errmsg.Message;
                }
            }
        }

        //选择上传文件所在的位置
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpenfile = new OpenFileDialog();
            dlgOpenfile.InitialDirectory = @"c:\";//初始目录
            dlgOpenfile.ShowReadOnly = false;
            dlgOpenfile.ReadOnlyChecked = true;
            if (dlgOpenfile.ShowDialog() == DialogResult.OK)
            {
                if (dlgOpenfile.ReadOnlyChecked == true)
                {
                    UploadFileInfor.Text = dlgOpenfile.FileName.ToString();
                    statusBar.Text = "就绪";
                }
            }
        }

        //开始上传
        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            //调用“上传文件”
            StartUpLoad();
        }
    }
}
