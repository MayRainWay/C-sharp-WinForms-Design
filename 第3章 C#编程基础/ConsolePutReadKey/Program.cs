using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePutReadKey
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo flag;
            do
            {
                flag = Console.ReadKey();
            }
            while (flag.Key != ConsoleKey.Escape);//等待用户按esc键
        }
    }
}
