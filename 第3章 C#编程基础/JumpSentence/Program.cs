using System;
using System.Collections.Generic;
using System.Text;

namespace JumpSentence
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag;
            for(int i = 2; i < 30; i++)
            {
                flag = true;
                for(int j = 2; j <= i/2; j++)
                {
                    if (i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("{0}\t", i);
                }
            }
            Console.Read();
        }
    }
}
