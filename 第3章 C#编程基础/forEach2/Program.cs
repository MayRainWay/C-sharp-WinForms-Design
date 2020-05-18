using System;
using System.Collections.Generic;
using System.Text;

namespace forEach2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "This is Visual Studio 2015";
            int i = 0;
            foreach(char ch in s)
            {
                if (ch == 's')
                {
                    i++;
                }
            }
            Console.WriteLine(i);
            Console.Read();
        }
    }
}
