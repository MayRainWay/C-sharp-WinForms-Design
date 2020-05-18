using System;
using System.Collections.Generic;
using System.Text;

namespace Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;       //正确，可以同时声明同一数据类型的变量
            double g4 = 1.324;  //正确
            double name_07;     //正确
           // double name-07;     //不正确，含有非法字符“-”
         //   double Main;        //不正确，变量名和库函数名相同,但是能跑起来
            double @const;      //正确

            Console.Read();
        }
    }
}
