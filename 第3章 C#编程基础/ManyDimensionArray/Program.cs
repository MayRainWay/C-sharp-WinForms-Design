using System;
using System.Collections.Generic;
using System.Text;

namespace ManyDimensionArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array11 = new int[3, 2, 4];
            //这是一个三维数组，共有3x2x4=24个数组

            int[,] array1 = new int[3, 2]
            {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            };//创建一个二维数组，有两层大括号；就好比c语言中3行2列

            int[,] array3 =
            {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            };//创建一个二维数组，维数长度分别是3、2；就好比c语言中3行2列，和上面的数组相同

            int[,,] array2 = new int[,,] { 
                { { 1, 2, 3 } },
                { { 4, 5, 6 } }
            };
            //创建一个三维数组，维数长度分别是2，1，3
            //2行1列3高，表面是3维，实际上是个二维，这里举得例子不太好
            //三维的有点不太好理解
        }
    }
}
