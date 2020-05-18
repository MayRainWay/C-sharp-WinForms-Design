using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

//示例代码，仅供测试，并不可运行
namespace 利用DataReader类获取只读数据
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=XPS13-9350\\" 
                + "SQLEXPRESS;Initial Catalog=ScoreMIS;Integrated Security=true");
            sqlCon.Open();//打开连接
            SqlCommand cmd = new SqlCommand("select * form students",sqlCon);//创建Command对象
            SqlDataReader dr = cmd.ExecuteReader();//创建DataReader对象
            //遍历数据表中行的信息
            while (dr.Read())
            {
                listBox1.Items.Add.(dr["class"].ToString());
            }
            //关闭连接
            sqlCon.Close();
        }
    }
}
