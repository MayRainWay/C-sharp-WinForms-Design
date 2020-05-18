using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
//本项目仅供分散代码练习使用，并非完整项目，所以会有大量“语法错误”

namespace DataSet数据集与DataAdapter数据适配器
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建DataAdapter对象
            SqlDataAdapter da = new SqlDataAdapter("selec*from students", con);

            //创建数据集
            DataSet ds = new DataSet();//这玩意儿需要什么命名空间，书上没写？
            //Fill方法填充
            ds.Fill(ds,"tablename")；

            //显示DataSet的数据
            //获取数据集
            ds.Tables["tablename"].Rows[0]["name"].ToString();
            //遍历DataSet数据集
            for(int i = 0; i < ds.Tables["tablename"].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables["tablename"].Rows[i]["name"].ToString());
            }

            //将DataSet数据集绑定到DataGridView
            dataGridView1.DataSourse = ds.Tables[0];

            //将DataSet数据集绑定到ComboBox
            //指定列表中要显示的数据表的具体字段
            //例如，列表时显示姓名name，但保存的数据是学号ID
            cbID.DisplayMember = "ID";
            //指定最终实际存储的数据表的具体字段
            cbID.ValueMember = "ID";
            //绑定数据源
            cbID.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
