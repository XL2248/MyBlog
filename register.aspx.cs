using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

public partial class register : System.Web.UI.Page
{
    Common com = new Common();

    //定义连接对象
    OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["conn"]);
    //定义数据集
    DataSet ds = new DataSet();
    //定义数据适配器
    OleDbDataAdapter da;
    //定义整型变量i
    int i;
    int j;//判断用户名是否已经存在
    int n;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            Response.Write(com.msgBoxPage("尊敬的用户，请您先注销再注册"));
        }
    }

    protected void reset_Click(object sender, EventArgs e)
    {
        //清空所有内容
        name.Text = "";
        pwd.Text = "";
        confirmPwd.Text = "";
        birthDay.Text = "";
        radioSex.SelectedIndex = -1;

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //判断连接的状态，如果关闭就打开
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        OleDbCommand comm1 = new OleDbCommand("select * from adminInfo where userName='" + name.Text + "'", conn);
        da = new OleDbDataAdapter(comm1);
        da.Fill(ds, "admin");
        i = Convert.ToInt32(ds.Tables["admin"].Rows.Count);
        OleDbCommand comm2 = new OleDbCommand("select * from userInfo where userName='" + name.Text + "'", conn);
        da = new OleDbDataAdapter(comm2);
        da.Fill(ds, "user");
        j = Convert.ToInt32(ds.Tables["user"].Rows.Count);
        //判断用户名是否跟管理员表的用户名重复，如果是，提示不能注册并刷新页面
        if (i > 0||j>0)
        {
                Response.Write(com.msgBoxPage("不好意思！用户名已经被使用，请重新注册"));
        }
        else
        {
            OleDbConnection conn1 = new OleDbConnection(ConfigurationManager.AppSettings["conn"]);
            conn1.Open();
            string sqlstr1 = "select * from userInfo";
            OleDbDataAdapter da1 = new OleDbDataAdapter(sqlstr1, conn1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            n = Convert.ToInt32(ds1.Tables[0].Rows.Count)+1;
            conn1.Close();

            string str1=name.Text.Trim().ToString();
            string str2=pwd.Text.Trim().ToString();
            string str3= radioSex.SelectedValue;
            string str4=birthDay.Text.Trim().ToString();
            string str5="0";
            string str6 = n.ToString();
            string sqlstr="insert into userInfo values("+str6+",'"+str1+"','"+str2+"','"+str3+"','"+str4+"',"+str5+")";
            //定义命令对象
            OleDbCommand comm = new OleDbCommand(sqlstr,conn);
            i = Convert.ToInt32(comm.ExecuteNonQuery());

            if (i > 0)
            {
                //插入操作成功就给相应提示
                Response.Write(com.msgBox("注册成功（请记住您的注册信息）！正在为您跳转", "register.aspx"));
            }

            else
            {
                //操作失败也给相应提示
                Response.Write(com.msgBox("注册失败！请您重新注册", "register.aspx"));
            }
        }
        if(conn.State==ConnectionState.Open )
            conn.Close();
    }
              
}