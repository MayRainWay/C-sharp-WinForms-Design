using System;
using System.Collections.Generic;
using System.Text;

namespace chpt3_3b_MyEnumType
{
    class Program
    {
        //enum Weekdays { Sun, Mon, Tue, Wed, Thu, Fri, Sat};
        //enum Weekdays :long { Sun=1,Mon,Tue,Wed,Thu=22,Fri,Sat};

        enum Weekdays { 星期日, 星期一, 星期二, 星期三, 星期四, 星期五, 星期六 };

        static void Main(string[] args)
        {
            Weekdays myday = Weekdays.星期日;  //声明weekdays枚举类型的变量myday
            Console.Title = "chpt3-3b";

            Console.WriteLine("今天是：{0}", DateTime.Now.Date.ToShortDateString());    //输出日期
            Console.WriteLine("今天是：{0}", DateTime.Now.DayOfWeek);       //输出英文星期

            myday = (Weekdays)DateTime.Now.DayOfWeek;   //将当前日期强制转换为weekdays枚举类型
            Console.WriteLine(myday);
            Console.Read();
        }
    }
}
