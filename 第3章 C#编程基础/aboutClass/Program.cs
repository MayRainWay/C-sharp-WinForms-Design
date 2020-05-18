using System;
using System.Collections.Generic;
using System.Text;

namespace aboutClass
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class student               //声明一个基类
    {
        public string name;
        public int ID;
        public int score;
    }       
    class Grade : student   //声明一个派生类，派生类拥有基类的字段，又有自己专属的字段
    {
        public int ClassNumber;
    }
}
