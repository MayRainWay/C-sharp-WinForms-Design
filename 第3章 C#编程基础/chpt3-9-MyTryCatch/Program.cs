using System;
using System.Collections.Generic;
using System.Text;

namespace chpt3_9_MyTryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "chpt3-9";
            Console.WriteLine("请输入x的值：");
            while (true)
            {
                try
                {
                    string s = Console.ReadLine();
                    double x = Convert.ToDouble(s); //将string类型转换为double类型
                    int y;
                    if (x < 0) { y = -1; }
                    else if (x == 0) { y = 0; }
                    else { y = 1; }
                        Console.WriteLine("y的值为：{0}", y);
                }
                catch
                {
                    Console.WriteLine("输入的数据类型不正确");
                }
            }
        }
    }
}
