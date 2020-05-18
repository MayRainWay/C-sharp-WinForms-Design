using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//添加命名空间引用
using System.Diagnostics;
using System.Threading;

//添加命名空间引用
using System.IO;

namespace chapt6_2_CProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Windows计算器控制按钮的单击事件代码
        private void btnCalculatorStart_Click(object sender, EventArgs e)
        {
            CalculatorProcess.Start();//启动一个Windows计算器，就是启动我们刚才那个Process组件
        }

        //关闭已启动的Windows计算器
        private void btnCalculatorStopAll_Click(object sender, EventArgs e)
        {
            //创建一个Process组件的数组
            Process[] CalculatorProcess;  //注意，这个CalculatorProcess并不是那个进程组件Process

            //将所创建的数组与指定进程名称（calc|这里我替换成了foobar2000）的所有进程资源想关联
            CalculatorProcess = Process.GetProcessesByName("foobar2000");

            //遍历当前启动程序，查找包含指定名称的进程
            foreach(Process instance in CalculatorProcess)
            {
                instance.CloseMainWindow();
                //终止当前进程，关闭应用程序窗体
            }
        }


        //上机自测系统控制按钮的单机事件代码
        //启动一个上机自测系统
        //下面的代码可以看作是Process组件使用的纯代码版本，个人感觉有些复杂
        private void btnSelfExamStart_Click(object sender, EventArgs e)
        {
            FileInfo fInfo = new FileInfo(@"C:\Users\RainWay\Documents\C#语言 Windows程序设计\第5章 Windows窗体与控件程序设计\chpt5_3selfExam\bin\Debug\chpt5_3selfExam.exe");
            //以上代码为寻找文件？不通过process组件的方法;注意不要换行，会报错！！！

            if (fInfo.Exists)//如果文件存在
            {
                //实例化一个Process类，启动一个独立进程
                Process prcsSelfExam = new Process();

                //Process有一个StartInfo属性，这是ProcessStartInfo类，包括一些方法和属性
                //待启动的程序文件
                prcsSelfExam.StartInfo.FileName = fInfo.FullName;

                //启动进程
                prcsSelfExam.Start();
            }
            else
            {
                MessageBox.Show("文件：" + fInfo.FullName + "不存在！");
            }
        }

        //关闭已启动的所有上机自测系统；这里代码倒是没有什么区别,直接复制过来改改就能用
        private void btnSelfExamStopAll_Click(object sender, EventArgs e)
        {
            //创建一个Process组件的数组
            Process[] SelfExamProcess;  

            //将所创建的数组与指定进程名称（chpt5_3selfExam）的所有进程资源想关联
            SelfExamProcess = Process.GetProcessesByName("chpt5_3selfExam");

            //遍历当前启动程序，查找包含指定名称的进程
            foreach (Process instance in SelfExamProcess)
            {
                instance.CloseMainWindow();
                //终止当前进程，关闭应用程序窗体
            }
        }
    }
}
