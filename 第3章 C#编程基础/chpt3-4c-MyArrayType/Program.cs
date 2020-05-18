using System;
using System.Collections.Generic;
using System.Text;

namespace chpt3_4c_MyArrayType
{
    public class A         //定义一个类A；说实话，这玩意儿我没看太懂
    {
        private int i;
        public A(int a)     //类的构造函数
        { i = a * 2; }

        public int I        //类的一个成员
        {
            get { return i + 1; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "chpt3-4c";
            
            int[] a, b;     //声明两个int类型的数组a、b，它们的数组元素都是int型
            a = new int[4] { 4, 3, 2, 1 };  //数组a含有4个int型数值，并赋初值为4、3、2、1
            b = new int[5];     //数组b含有5个int型数值，初值全为默认值0

            Console.Write("int型数组a：\n");
            foreach (int i in a)  Console.Write("{0}\t", i);
            //采用foreach语句遍历数组a，输出数组a

            Console.Write("\n int型数组b：\n");
            foreach (int i in b) Console.Write("{0}\t", i);
            //采用foreach语句遍历数组b，输出数组b

            bool[] c = { true, false, true, false };
            Console.Write("\n bool型数组c:\n");
            foreach (bool i in c) Console.Write("{0}\t", i);
            //采用foreach语句遍历数组c，输出数组c

            object[] d = new object[4];
            //创建数组d，含有4个object型数组元素，初始值为默认值null
            Console.Write("\n object型数组d:\n");
            for (int i = 0; i < d.Length; i++) Console.Write("d[{0}]={1}\t", i, d[i]);
            //采用for循环语句遍历数组d，输出数组d

            A[] h = new A[3] { new A(3),new A(7), new A(11) };
            Console.Write("\n 通过类类型数组h使用类的属性:\n");
            foreach (A i in h) Console.Write("{0}\t", i.I);

            Console.Read();
        }
    }
}
