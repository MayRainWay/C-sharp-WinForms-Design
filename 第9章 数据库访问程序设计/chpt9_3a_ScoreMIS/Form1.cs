using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//添加命名空间
using System.Data.SqlClient;

namespace chpt9_3a_ScoreMIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string strCon;//声明连接字符串
        SqlConnection sqlCon;//声明SqlConnection连接对象

        //设计数据库连接的公共方法
        private void DBConnect()
        {
            //编写数据库连接字符串：server为“服务器IP地址（或名称）”，
            //database为“数据库名称”，uid为“数据库用户名”，pwd为“数据库密码”
            strCon = "server='XPS-13-9350';" +
                "database='ScoreMIS';uid='sa';pwd='971128'";
            //新建SQL Server连接
            sqlCon = new SqlConnection(strCon);
        }

        //刷新及显示相关数据的方法
        private void CommonDataView()
        {
            try
            {
                DBConnect();//调用我们上面写的函数方法
                            //连接数据库成功后，创建DataAdapter对象
                SqlDataAdapter da = new SqlDataAdapter("select ID as 学号," +
                    "name as 姓名,class as 班级 form students", sqlCon);

                DataSet ds = new DataSet();//创建数据集（也可以直接利用.NET的DataSet数据适配器控件）
                da.Fill(ds, "tablename");//Fill方法填充
                dataGridView1.DataSource = ds.Tables[0];//将DataSet数据绑定到DataGridView

                //将DataSet数据集绑定到ComboBox
                //指定列表种要显示的数据表的具体字段            
                cbID.DisplayMember = "学号";//例如，列表时显示姓名name，但保存的数据是学号ID
                cbID.ValueMember = "学号";//指定最终实际储存数据表的具体字段
                cbID.DataSource = ds.Tables[0].DefaultView;//绑定数据源
            }
            catch(SystemException ex)
            {
                MessageBox.Show("错误：" + ex.Message, "错误提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            finally
            {
                //如果处于与数据库连接状态
                if (sqlCon.State == ConnectionState.Open)
                {
                    //关闭SQL连接
                    sqlCon.Close();
                    //释放所占用的资源
                    sqlCon.Dispose();
                }
            }
        }

        //在窗体加载时显示数据表原始数据，并初始化列表项的数据
        private void Form1_Load(object sender, EventArgs e)
        {
            CommonDataView();//调用上面的函数
        }

        //增加记录
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DBConnect();
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("insert into students values('" + cbID.Text
                + "','" + tbName.Text + "','" + tbClass.Text + "')", sqlCon);
            cmd.ExecuteNonQuery();//执行SQL语句，增加记录
            sqlCon.Close();
            CommonDataView();//刷新记录显示
        }

        //删除记录
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBConnect();
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("delete from students where ID='"+cbID.Text+"'",sqlCon);
            cmd.ExecuteNonQuery();//执行SQL语句，增加记录
            sqlCon.Close();
            CommonDataView();//刷新记录显示
        }

        //更改记录
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBConnect();
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("UPDATE students SET name='" +
                tbName.Text + "',class='" + tbClass.Text+"'WHERE ID='" + cbID.Text + "'", sqlCon);
            //妈了个巴子的，这玩意儿的双引号和单引号是怎么对应的？？cnmd
            cmd.ExecuteNonQuery();//执行SQL语句，增加记录
            sqlCon.Close();
            CommonDataView();//刷新记录显示
        }

        //查询记录
        private void btnQuery_Click(object sender, EventArgs e)
        {
            DBConnect();
            sqlCon.Open();
            //创建DataAdapter对象
            SqlDataAdapter da = new SqlDataAdapter("select ID as 学号," 
                + "name as 姓名,class as 班级 from students WHERE ID like '%" + cbID.Text + "%'", sqlCon);
            //这里sql语句的双引号对应存在很大的问题！！！书上没讲实属贱人！！！
            DataSet ds = new DataSet();//创建数据集（也可以直接利用.NET的DataSet数据适配器控件）
            da.Fill(ds, "tablename");//Fill方法填充
            dataGridView1.DataSource = ds.Tables[0];
            sqlCon.Close();
        }
    }    
}
