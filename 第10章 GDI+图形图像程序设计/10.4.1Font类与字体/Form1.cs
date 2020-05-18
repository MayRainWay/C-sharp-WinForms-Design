using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._4._1Font类与字体
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //该项目仅供代码测试，不具实际意义
            //其实学习c#到现在，总感觉还是有不少疑惑，就比如函数和方法，以及一些变量的使用
            //对于Winform而言，是不是每个控件都是全局变量呢？我觉得是
            //然后是变量的使用，在一个类里面，我们可以在任何位置随便丢一个变量
            //而有些类的使用，似乎则必须被包含在事件、方法、函数里面？？？
            FontFamily fontFamily = new FontFamily("黑体");
            Font font = new Font(fontFamily, 12, FontStyle.Italic, GraphicsUnit.Pixel);


            //我比较喜欢下面这种格式，简单好记！
            Font font1 = new Font("黑体", 12, FontStyle.Italic, GraphicsUnit.Pixel);
        }
        
    }
}
