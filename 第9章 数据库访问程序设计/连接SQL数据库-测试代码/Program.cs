using System;
using System.Collections.Generic;
using System.Text;
//添加命名空间
using System.Data.SqlClient;

namespace 连接SQL数据库_测试代码
{
    class Program
    {
        static void Main(string[] args)
        {
            string strCon;//声明连接字符串

            //编写连接字符串：server为“服务器IP地址（或名称）”，database为“数据库名称”，
            //uid为“数据库用户名”，pwd“为数据库密码”
            strCon = "server='(local)';database='ScoreMIS';uid='sa';pwd='dbpwd';";

            //新建SQL Server连接
            SqlConnection sqlCon = new SqlConnection(strCon);

            //另一种集成登录方式
            //sqlconnection sqlcon = new sqlconnection("data sourse=(local);
            //initial catalog=scoremis;integrated security=true");

            try
            {
                //打开SQL连接
                sqlCon.Open();

                //连接数据库成功后的相应数据库操作
                //。。。。。。

                //关闭SQL连接
                sqlCon.Close();
            }
            catch
            {
                //连接数据库失败提示
                //。。。。。。
            }
        }
    }
}
