using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePutReadLine
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, AgeString;
            int Age;    
            name = Console.ReadLine();  //获取姓名,赋给字符串类型变量name
            AgeString = Console.ReadLine(); //获取年龄,赋给字符串变量AgeString
            Age = Convert.ToInt32(AgeString);   //使用年龄前,需将字符串类型转换为整数类型
        }
    }
}
