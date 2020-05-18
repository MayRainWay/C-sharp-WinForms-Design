using System;
using System.Collections.Generic;
using System.Text;

namespace StructType
{
    class Program
    {
        static void Main(string[] args)
        {
            student s;      //使用结构类型
            s.name = "赵鹏";  //给结构中的字段变量赋值
            s.ID = 10814;
            s.score = 90;
            Console.Title = "chpt3-3a";
            Console.WriteLine("学生{0}的学号是{1},他的成绩是{2}分", s.name, s.ID, s.score);
            Console.WriteLine(DateTime.Now);    //输出编译时间
            Console.Read();
        }
    }

    struct student      //声明结构类型
    {
        public string name;
        public int ID;
        public int score;
    }
}