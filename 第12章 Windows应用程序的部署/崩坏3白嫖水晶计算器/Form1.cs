using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 崩坏3白嫖水晶计算器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 开始计算_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(每日任务.Text);
            int b = Convert.ToInt32(记忆战场.Text);
            int c = Convert.ToInt32(深渊结算.Text);
            int d = Convert.ToInt32(每月签到.Text);
            int x = Convert.ToInt32(每日月卡.Text);

            //每月按30天，4周计算
            int month = a * 30 + b * 4 + c * 4 + d + x * 52;
            月收入.Text = Convert.ToString(month);

            //每年按365天，12个月，52周计算
            int year = a * 365 + b * 52 + c * 52 + d * 12 + x * 52 * 12;
            年收入.Text = Convert.ToString(year);            
            //开始计算.Enabled = false;
        }

        private void 重置_Click(object sender, EventArgs e)
        {
            每日任务.Text = Convert.ToString(0);
            记忆战场.Text = Convert.ToString(0);
            深渊结算.Text = Convert.ToString(0);
            每月签到.Text = Convert.ToString(0);
            每日月卡.Text = Convert.ToString(0);
            月收入.Text = Convert.ToString(0);
            年收入.Text = Convert.ToString(0);
            开始计算.Enabled = true;
        }
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private void Form1_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
