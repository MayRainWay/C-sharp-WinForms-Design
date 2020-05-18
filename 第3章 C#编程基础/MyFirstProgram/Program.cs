using System;
using System.Collections.Generic;
using System.Text;
//上面的using涉及了命名空间的概念！
namespace MyFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "我的第一个C#程序";    //设置控制台窗口标题，可以不写！
            Console.WriteLine("C#语言程序设计\n一个简单的控制台程序");
            Console.Read();
            //console.writeline和console read是一体的，不可分离！
        }
    }
}
