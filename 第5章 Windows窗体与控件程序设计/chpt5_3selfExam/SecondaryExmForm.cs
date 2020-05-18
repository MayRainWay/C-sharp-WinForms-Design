using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace chpt5_3selfExam
{
    public partial class SecondaryExmForm : Form
    {
        public SecondaryExmForm()
        {
            InitializeComponent();
        }

        private void SecondaryExmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注：\n表示文本换行
            if(MessageBox.Show(this,"确定要关闭当前窗体吗？是请点击‘确定’\n按钮，否则，请点击‘取消’按钮。","提示",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SecondaryExmForm SFrm = new SecondaryExmForm();
                SFrm.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //从指定文件创建位图
                pictureBox1.Image = Bitmap.FromFile(openFileDialog1.FileName, false);
            }
        }
    }
}
