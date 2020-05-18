using System;
using System.Collections.Generic;
using System.Text;

namespace classDeclare
{
    public class Student
    {
        //定义类的数据成员
        public string Name;
        public int ID;
        public int Score;

        //定义类的函数成员
        public string StudentMessage()
        {
            return string.Format("姓名：{0}，学号：{1}，得分{2}", Name, ID, Score);
        }
    }
    class Program
    {
        public const double pi = System.Math.PI;
        static void Main(string[] args)
        {
            Student johnson;            //声明类student的对象是jhonson
            johnson = new Student();    //使用构造函数和关键字new实例化对象，完成初始化

            //OK,of course！上面的两条语句也可以合成一条语句使用,like this one ⬇
            Student John = new Student();

          
        }
    }
}
