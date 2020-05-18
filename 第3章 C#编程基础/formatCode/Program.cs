using System;
using System.Collections.Generic;
using System.Text;

namespace formatCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            double x = 20.5;
            DateTime date = DateTime.Now;

            Console.WriteLine("{0:c}",x);   //输出带货币符号的数值
            Console.WriteLine("{0:D5}",i);  //数值输出整数
            Console.WriteLine("{0:d}",date);    //输出长短日期格式
            Console.WriteLine("{0:e}",x);   //输出科学计数法格式数值
            Console.WriteLine("{0:F4}",x);  //输出数值小数点后固定位数
            Console.WriteLine("{0:t}",date);    //输出长短时间格式
            Console.WriteLine("{0:p}", 0.432);  //输出带百分比的数值
            //格式化类型代码无需区分大小写
            Console.Read();
        }
    }
}
