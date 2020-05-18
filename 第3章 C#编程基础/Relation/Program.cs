using System;
using System.Collections.Generic;
using System.Text;

namespace Relation
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10, y = 15;
            Console.WriteLine(x >= y);  //输出false
            Console.WriteLine(x != y);  //输出true

            object z = x;
            object w = y;
            Console.WriteLine(w != z);  //输出true，因为w和z分别指向两个不同的对象

            Console.Read();
        }
    }
}
