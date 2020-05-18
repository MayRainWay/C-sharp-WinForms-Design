using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._3._1_HatchBrush画刷
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //交叉水平线和垂直图案填充
            HatchBrush brush1 = new HatchBrush(HatchStyle.Cross, Color.Chocolate);
            e.Graphics.FillEllipse(brush1, 20, 50, 150, 100);

            //格子花呢（ni，多音字）材料外观的阴影填充
            HatchBrush brush2 = new HatchBrush(HatchStyle.Plaid, Color.BlueViolet, Color.White);
            g.FillEllipse(brush2, 200, 50, 100, 100);
        }
    }
}
