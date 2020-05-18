using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleWriteOut
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 20;
            string name = "韩梅梅";
            Console.Write(name);
            Console.Write("年龄是:");
            Console.Write("{0}\r\n", age);

            Console.WriteLine("{0}年龄是：{1}", name, age);

            Console.Read();//read可以保证完成一系列操作之后窗口不被关闭！
        }
    }
}
