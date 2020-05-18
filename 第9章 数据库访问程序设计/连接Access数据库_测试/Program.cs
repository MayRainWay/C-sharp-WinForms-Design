using System;
using System.Collections.Generic;
using System.Text;
//add namespace
using System.Data.OleDb;

namespace 连接Access数据库_测试
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用相对路径
            string strCon = "provider=Microsoft.Jet.OLEDB.4.0;Data Sourse=" + Server.MapPath("access.mdb") + "";
            //构造连接对象
            OleDbConnection oledbCon = new OleDbConnection(strCon);
            try
            {
                //打开SQL连接
                oledbCon.Open();
                //连接数据库成功后的相应数据库操作
                //。。。
                //关闭SQL连接
                oledbCon.Close();
            }
            catch
            {
                //连接数据库失败提示
                //。。。
            }
        }
    }
}
