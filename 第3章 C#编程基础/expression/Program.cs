using System;
using System.Collections.Generic;
using System.Text;

namespace expression
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 7;
            int c = a + b;

            //           string s = TextBox1.Text + "你好";

            int x = 2 * 2 + 5;          //自左向右计算，x=9
            int x1 = 2 * (2 + 5);       //使用圆括号改变计算顺序，x1=14
            int x2 = 7 % 3;             //x3=1
            double x3 = 4.3 % 1.7;      //x3=0.9
            a++;                        //自增 a=a+1


            int y = 20;
            x += y;     //等价于x=x+y
            x &= y;     //等价于x=x&y

            

            Console.Read();
        }
    }
}
