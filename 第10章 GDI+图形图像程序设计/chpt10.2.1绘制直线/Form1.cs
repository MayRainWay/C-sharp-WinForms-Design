using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chpt10._2._1绘制直线
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
            Pen pen = new Pen(Color.Black, 5);
            Point startPoint = new Point(10, 30);
            Point endPoint = new Point(200, 90);
            e.Graphics.DrawLine(pen, startPoint, endPoint);
            //感觉和浙大的ACLlib库很像
        }
    }
}
