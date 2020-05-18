using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayType
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[4] a;   //错误，声明时不能指定元素个数
            //string b[]; //错误，声明时不能把[]放在数组名之后！

            int[] a, b;                             //声明数组a和数组b
            a = new int[4];                         //使用new运算符创建含有4个int型整数的实例a
            b = new int[5] { 5, 4, 3, 2, 1 };       //使用new运算符创建数组实例b，并初始化为指定值

            int[] c = new int[4] { 2, 4, 5, 7 };

            bool[] d = { true, false, true, false };

            //int[] e;
            //e ={ 3,7,2,5,5};    //错误
        }
    }
}
