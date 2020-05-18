using System;
using System.Collections.Generic;
using System.Text;

namespace PartVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 20; i++)
            {
                i++;
            }
            
        //    Console.WriteLine("{0}",i);  //错误，不存在变量i

            Console.Read();
        }
    }
}
