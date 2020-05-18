using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpContinue
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0, sum = 0;
            do
            {
                i++;
                if (i % 4 != 0)
                {
                    continue;                    
                }
                sum += i;

            } while (i <= 20);

            Console.WriteLine(sum);
            Console.WriteLine(i);

            Console.Read();
        }
    }
}
