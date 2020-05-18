using System;
using System.Collections.Generic;
using System.Text;

namespace TypeConvert
{
    class Program
    {
        enum Weekdays { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
        static void Main(string[] args)
        {
            long a = 10;    //定义long整型
            float b = a;    //隐式地转换为单精度浮点型

            //int c = a;      //错误，int类型的精度低于long类型的精度
            //因为C#是强类型语言,大范围转小范围只能强制转换，即int c = (int)a;

            char s = 'A';   //定义字符型
            a = s;          //隐式地转换为int整型，a=65
            //以上为隐式转换，也就是自动转换，mb，这本书写的真臭，不是一般的烂

            double f = 1234.56;
            int i = (int)f;         //将f的值显式地转换为ing类型，i=1234；
            sbyte s1 = (sbyte)f;    //将f的值显示地转换为sbyte类型，s=-46

            Weekdays w = (Weekdays)4;       //显式转换后，w的值为Thu
            Weekdays w1 = (Weekdays)10;

            Console.Read();
        }
        
        
    }
}
