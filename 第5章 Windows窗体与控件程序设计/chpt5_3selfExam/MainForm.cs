using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace chpt5_3selfExam
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 文件FToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //退出系统
            Application.Exit();
        }

        private void 初级自测题PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;  //将mainform窗体设置为父窗体
            this.label1.Visible = false;  //隐藏父窗体上的标题文字；
            this.pictureBox1.Visible = false;  //隐藏父窗体上的标题文字
            this.label2.Visible = false;  //隐藏父窗体上的版权文本

            PrimaryExmForm PFrm = new PrimaryExmForm();
            //实例化PrimaryExmForm，其实这里说白了就是创建对象，因为是在其他类调用PrimaryExmForm

            PFrm.MdiParent = this; //将MainForm窗体作为其父窗体

            PFrm.Show();//调用show方法，显示窗体PFrm
            //然后那两个窗体的创建也就同理咯
        }

        private void 中级自测题SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;  //将mainform窗体设置为父窗体
            this.label1.Visible = false;  //隐藏父窗体上的标题文字；
            this.pictureBox1.Visible = false;  //隐藏父窗体上的标题文字
            this.label2.Visible = false;  //隐藏父窗体上的版权文本
            SecondaryExmForm SFrm = new SecondaryExmForm();
            SFrm.MdiParent = this;
            SFrm.Show();
        }

        private void 高级自测题AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;  //将mainform窗体设置为父窗体
            this.label1.Visible = false;  //隐藏父窗体上的标题文字；
            this.pictureBox1.Visible = false;  //隐藏父窗体上的标题文字
            this.label2.Visible = false;  //隐藏父窗体上的版权文本
            AvacedExmForm AFrm = new AvacedExmForm();
            AFrm.MdiParent = this;
            AFrm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //利用MdiChildren遍历所有子窗体，并依次关闭
            Form[] CFrmList = this.MdiChildren;
            //在这里我们定义了一个Form类型的数组CFrmList

            foreach(Form CFrm in CFrmList)
            {
                CFrm.Close();
            }

            //此时窗体不太美观，我们对父窗体进行还原操作
            this.label1.Visible = true;  //还原父窗体上的标题文字；
            this.pictureBox1.Visible = true;  //还原父窗体上的标题文字
            this.label2.Visible = true;  //还原父窗体上的版权文本
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            string sltItem = this.toolStripComboBox1.Text;  //组合框选项

            switch (sltItem)
            {
                case ("层叠排列"):
                    LayoutMdi(MdiLayout.Cascade);
                    break;
                case ("水平平铺"):
                    LayoutMdi(MdiLayout.TileHorizontal);
                    break;
                case ("垂直平铺"):
                    LayoutMdi(MdiLayout.TileVertical);
                    break;
                case ("图标排列"):
                    LayoutMdi(MdiLayout.ArrangeIcons);
                    break;
                default:
                    throw new ApplicationException();
            }
        }

        private void 关于系统AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm AbtFrm = new AboutForm();
            AbtFrm.ShowDialog();  //模糊方式打开窗体
        }
    }
}
