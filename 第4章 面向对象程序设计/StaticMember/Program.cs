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

        public static string School = "信电学院";   //定义静态字段
        public static void SchoolHello()
        {
            Console.WriteLine("信电学院欢迎您！");
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
            John.Name = "Jonh";
            Console.WriteLine(John.Name);       //通过对象名访问非静态成员
            Console.WriteLine(Student.School);  //通过类名来访问静态成员
            // Console.WriteLine(John.School); //错误，静态成员属于类，只能通过类名来访问

            Student.SchoolHello();//调用静态方法
            Console.Read();
        }
    }
}
