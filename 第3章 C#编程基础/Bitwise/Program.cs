using System;
using System.Collections.Generic;
using System.Text;

namespace Bitwise
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0x21, b = 0x43;
            int c = a ^ b;

            int x = 10, z = -127;
            int y = x << 3;
            int w = z >> 2;

            Console.WriteLine("{0}类型为{1}", (7 > 5) ? 4 : 5.5, ((7 > 5) ? 4 : 5.5).GetType());
            //我个人非常不推荐使用条件运算符！

            Console.Read();
        }
    }
}
