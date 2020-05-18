using System;
using System.Collections.Generic;
using System.Text;

namespace foreachTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = { 2, 4, 6, 8, 10 };
            foreach(int i in x)
            {
                Console.WriteLine(i);               
            }

            Console.Read();
        }
    }
}
