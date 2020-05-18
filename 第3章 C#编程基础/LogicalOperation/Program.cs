using System;
using System.Collections.Generic;
using System.Text;

namespace LogicalOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10, y = 15, z = 12;
            bool a = x < y || y-- < z++;
            bool b = x > y || y - 3 < ++z;
        }
    }
}
