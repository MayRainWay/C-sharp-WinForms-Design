using System;
using System.Collections.Generic;
using System.Text;

namespace chpt3_4aMyObjectType
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "chpt3_4aMyObjectType";

            object a;       //注意object的大小写
            a = 100;
            Console.WriteLine("a的值是{0}", a);
            Console.WriteLine("此时的值类型是{0}", a.GetType());
            //gettype是Object类的一个方法，用来获得当前实例的type

            a = "AA";
            Console.WriteLine("a的值是{0}", a);
            Console.WriteLine("此时的值类型是{0}", a.GetType());

            Console.Read();
        }
    }
}
