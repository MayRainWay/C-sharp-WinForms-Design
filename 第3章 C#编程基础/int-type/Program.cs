using System;
using System.Collections.Generic;
using System.Text;

namespace int_type
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            a = 321;    //分两个语句，先定义，再赋值给变量a
            long b = 321;   //将int型的数值321隐式地转换为long类型，再赋值给变量b
            long c = 0x12aL;    //将十六进制表示的long型数值12a赋值给变量c
            int x1 = 10, x2, x3 = 30;   //可以在一个语句中声明多个变量，但注意是否被赋值

            float x = 3.5F;
            double y = 4.5;

            decimal MyMoney = 2010.4M;

            bool i = true;
           // bool ai = (i > 0 && i < 8);   //error!!!
            Console.Write(i);
            // Console.Write(ai);

            char c1 = 'B';
            char c2 = '\x0042';
            char c3 = '\u0042';

            Console.Read();//保证控制台窗口不关闭

        }
    }
}
