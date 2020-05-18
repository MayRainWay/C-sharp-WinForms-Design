using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//add namespace
using System.Data.SqlClient;
//这个程序就先别测试了，数据库这方面的知识我太少了，配置SQL Server有些繁琐，说白了是我懒

namespace chpt9_3b_ScoreMIS
{
    public partial class Form1 : Form
    {

        SqlConnection sqlCon;//declare sqlConnection object
        SqlDataAdapter sda;//delcare sqlDataAdapter object

        public Form1()
        {
            InitializeComponent();
        }

        //refresh DataGridView1's display
        void DataRefresh()
        {
            sqlCon = new SqlConnection("server='XPS13-9350\\" +
                "SQLEXPRESS';database = 'ScoreMIS';uid = 'sa';pwd = '971128';");
            //we just need to care the double quotation marks,
            //the single quotation marks is a format in SQL

            sda = new SqlDataAdapter("select ID as 学号," + 
                "name as 姓名,class as 班级 from students", sqlCon);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            cbID.DisplayMember = "学号";//assign the final saved datatable's specific filed
            cbID.DataSource = ds.Tables[0].DefaultView;//bind data source 
        }

        //when form load,initialize DataGridView
        private void Form1_Load(object sender, EventArgs e)
        {
            DataRefresh();
        }

        //take dataGridView1's operation to database
        private Boolean dbUpdate()
        {
            string strSql = "select ID as 学号," + "name as 姓名,class as 班级 from students";
            //淦，我受不了了，我要用中文注释！！！
            //新建一个用于将dataGridView1数据操作更新到数据库的内存表
            DataTable dtUpdate = new DataTable();
            //新建一个用于更新dataGridView1数据操作的内存表
            //利用sda初始化dtUpdate的表结构（和数据）
            sda = new SqlDataAdapter(strSql, sqlCon);
            sda.Fill(dtUpdate);
            //初始化数据需清除，以存放更新后的dataGridView1数据
            dtUpdate.Rows.Clear();
            
            //再建一个内存表，用于将更新后的dataGridView1数据逐条读取出来存入更新内存表中
            DataTable dtShow = new DataTable();
            dtShow = (DataTable)dataGridView1.DataSource;
            for(int i = 0; i < dtShow.Rows.Count; i++)
            {
                dtUpdate.ImportRow(dtShow.Rows[i]);
            }

            try
            {
                this.sqlCon.Open();
                //使对DataSet所做的更改与关联的SQL Server数据库协调
                SqlCommandBuilder CommandBuiler;
                CommandBuiler = new SqlCommandBuilder(sda);
                //通过该sda将更新后的dataGridView1数据（即已复制的dtUpdate）更新到数据库
                sda.Update(dtUpdate);
                sqlCon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("数据库操作失败：" + ex.Message.ToString(), "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            dtUpdate.AcceptChanges();
            return true;
        }

        //视图排序
        private void btnSort_Click(object sender, EventArgs e)
        {
            //创建数据集
            sqlCon = new SqlConnection("server='XPS13-9350\\" +
                "SQLEXPRESS';database='ScoreMIS';uid='sa';pwd='dbpwd';");
            sda = new SqlDataAdapter("select ID as 学号," +
                "name as 姓名,class as 班级 from students", sqlCon);
            DataSet ds = new DataSet();
            sda.Fill(ds, "tablename");
            
            //创建视图
            DataView dv;
            dv = ds.Tables["tablename"].DefaultView;

            //排序视图
            if (radioButton1.Checked)
            {
                dv.Sort = "学号";
            }
            else if (radioButton2.Checked)
            {
                dv.Sort = "姓名";
            }
            else
            {
                dv.Sort = "班级";
            }

            //开始排序
            dataGridView1.DataSource = dv;
            //转换为编辑数据状态
            btnSave.Text = "编辑数据";
        }

        //视图筛选
        private void btnFilter_Click(object sender, EventArgs e)
        {
            //创建数据集
            sqlCon = new SqlConnection("server='XPS13-9350\\" + 
                "SQLEXPRESS';database='ScoreMIS';uid='sa';pwd='dbpwd';");
            sda = new SqlDataAdapter("select ID as 学号," + 
                "name as 姓名,class as 班级 from students", sqlCon);
            DataSet ds = new DataSet();
            sda.Fill(ds, "tablename");

            //创建视图
            DataView dv;
            dv = ds.Tables["tablename"].DefaultView;

            //筛选选项
            if (radioButton1.Checked)
            {
                dv.RowFilter = "学号 like '%" + cbID.Text + "%'";
            }
            else if (radioButton2.Checked)
            {
                dv.RowFilter = "姓名 like '%" + tbName.Text + "%'";
            }
            else
            {
                dv.RowFilter = "班级 like '%" + tbClass.Text + "%'";
            }

            //开始筛选
            dv.RowStateFilter = DataViewRowState.CurrentRows;
            dataGridView1.DataSource = dv;
            //转为编辑数据状态
            btnSave.Text = "编辑数据";
        }

        //保存数据操作到数据库中
        private void button3_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "保存数据编辑")
            {
                if (dbUpdate())
                {
                    MessageBox.Show("数据库操作成功！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btnSave.Text = "编辑数据";
            }
            else
            {
                //刷新dataGridView1数据显示，以便对其进行数据编辑
                DataRefresh();
                btnSave.Text = "保存数据编辑";
            }
        }
    }
}
