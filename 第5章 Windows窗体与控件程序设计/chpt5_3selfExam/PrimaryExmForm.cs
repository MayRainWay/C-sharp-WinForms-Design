using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace chpt5_3selfExam
{
    public partial class PrimaryExmForm : Form
    {
        public PrimaryExmForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Answer21A_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Answer22C_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Answer3C_CheckedChanged(object sender, EventArgs e)
        {

        }

        int ExamSecond = 0; //考试用时
        private void timer1_Tick(object sender, EventArgs e)
        {
            ExamSecond++;   //以秒为单位进行自测用时计量
            this.ExamTime.Text = ExamSecond.ToString();
        }

        private void btnGrade_Click(object sender, EventArgs e)
        {
            int Score = 0;   //总得分

            //开始分别评判每题
            if (this.Answer1.Text == "2000") { Score = Score + 10; } //第一大题
            if(this.Answer21A.Checked) { Score = Score + 10; }   //第二大题第1小题
            if(this.Answer21C.Checked) { Score = Score + 10; }   //第二大题第2小题
            if(this.Answer23.Text == "PasswordChar") { Score = Score + 10; }//第二大题第3小题
            if (this.Answer24.Text == "Text") { Score = Score + 10; }//第二大题第4小题
            if (this.Answer3A.Checked && this.Answer3B.Checked && this.Answer3C.Checked && !this.Answer3D.Checked) {
                Score = Score + 10;
            }//第三大题，答案是123，还要保证第4个选项没被选上

            this.timer1.Enabled = false;       //计时停止
            this.btnGrade.Enabled = false;     //评分锁定
            this.TotalScore.Text = Score.ToString();//显示总得分

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();//调用Close方法关闭窗体PrimaryExmForm
        }
    }
}
