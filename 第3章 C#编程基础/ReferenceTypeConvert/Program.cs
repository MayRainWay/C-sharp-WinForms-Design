using System;
using System.Collections.Generic;
using System.Text;

namespace ReferenceTypeConvert
{
    class A { public int i; }
    class B : A { public int j; }     //类B继承自类A

    class Test
    {
        static void Main(string[] args)
        {
            B myclass1 = new B();

            A myclass2 = myclass1;  //派生类B的对象可以隐式地转换成基础类A的对象
            B myclass3 = (B)myclass2;  //基础类A的对象显示地转换成派生类B的对象

            Console.WriteLine("{0}", myclass2.i);   //正确
           // Console.WriteLine("{0}", myclass2.j); //错误，因为class2里没有j
            Console.WriteLine("{0}", myclass3.i);   //正确

            int a = 10;
            string s1;
            s1 = Convert.ToString(a);

            Console.Read();
        }
    }
}
