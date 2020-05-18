using System;
using System.Collections.Generic;
using System.Text;

namespace chpt3_4b_MyStringType
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s1;
            //s1 = "你好，中国";
            //string s2 = "中国江苏";
            //string s3 = new string('a', 4);
            ////等效于string s3 = “aaaa”；

            Console.Title = "chpt3_4b_MyStringType";
            string s1 = "this is a string";
            string s2 = s1;     //可以直接给字符串赋值
            string s3 = s1 + " " + ":hello world "; //直接符加其他字符串，返回一个新的实例
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);

            Console.WriteLine("s1与s2的比较结果为：{0}", string.Compare(s1, s2));
            Console.WriteLine("s1与s3的比较结果为：{0}", string.Compare(s1, s3));
            //比较两个字符串的大小，即长度！
            //大于返回结果为1，等于返回结果为0，小于返回结果为-1

            Console.WriteLine("s1与s3的比较结果为：{0}", s1==s3);
            //比较两个字符串是否相等，相等结果为true，不相等结构为false

            Console.WriteLine("s1中首次出现is的位置是：{0}", s1.IndexOf("is"));
            Console.WriteLine("s1中最后一次出现is的位置是：{0}", s1.LastIndexOf("is"));
            //查找指定字符串再字符串中出现的位置，序号从0开始

            Console.WriteLine("s1中插入字符串c#后变成：{0}", s1.Insert(10, "C#"));
            //在指定位置插入字符串

            Console.WriteLine("s1中替换字符串second后变成：{0}", s1.Replace("a", "second"));
            //替换指定的字符串

            Console.WriteLine("s1转换为大写后:{0}", s1.ToUpper());
            //转换字符串中字母的大小写

            StringBuilder s4 = new StringBuilder("Test this string");
            //使用StringBuilder类生成的字符串可以动态分类内存空间
            //对该类的字符串操作不会生成新的实例
            Console.WriteLine(s4);
            s4.Append("在原字符串所占内存空间后直接符加");
            Console.WriteLine(s4);

            //Console.WriteLine(s1);

            Console.Read();

        }
    }
}
