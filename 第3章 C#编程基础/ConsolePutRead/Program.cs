using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePutRead
{
    class Program
    {
        static void Main(string[] args)
        {
            int code;
            char character;
            code = Console.Read();      //输入字母r,code=114;
            character = (char)code;     //将整数转换成字符
        }
    }
}
