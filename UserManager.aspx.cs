using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

public partial class _Default: System.Web.UI.Page
{
    //定义一个全局的类
    Common com = new Common();
    //定义连接对象
    OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["conn"]);
    //
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否为已登录用户，若否，就提示用户先登录
       // if (Session["userName"] == null)
       // {
       //     Response.Write(com.msgBox("尊敬的用户，请您先登录！！！", "../login.aspx"));
       // }
    }
    protected void lnkDel_Command(object sender, CommandEventArgs e)
    {

        //打开数据库
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }

        //定义命令对象，从要删除的用户表中找出对应的信息
        OleDbCommand comm = new OleDbCommand("select * from userInfo where userID=" + e.CommandArgument, conn);

        OleDbDataAdapter da = new OleDbDataAdapter(comm);
        da.Fill(ds, "userInfo");
        Session["userName"] = ds.Tables["userInfo"].Rows[0]["userName"].ToString();
        //定义命令对象1、删除用户表的用户信息
        OleDbCommand comm1 = new OleDbCommand("delete from userInfo where userID=" + e.CommandArgument, conn);
       
        int i = Convert.ToInt32(comm1.ExecuteNonQuery());
        

        if (i > 0)
        {
            Response.Write(com.msgBox("删除用户成功！并且其相关的文章和留言也删除！正在跳转！！！", "userManager.aspx"));
        }
        else
        {
            Response.Write(com.msgBox("删除失败！正在跳转！！！", "userManager.aspx"));
        }
        //判断数据库的状态，如果打开就关闭
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
    }
    protected void lnkFenHao_Command(object sender, CommandEventArgs e)
    {
        //打开数据库
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        string update_sql = "update userInfo set blockade=@blockade where userName=@userName";
        //定义命令对象，从要封除的用户表中找出对应的信息
        OleDbCommand comm = new OleDbCommand("select * from userInfo where userID=" + e.CommandArgument, conn);

        OleDbDataAdapter da = new OleDbDataAdapter(comm);
        da.Fill(ds, "userInfo");
        Session["userName"] = ds.Tables["userInfo"].Rows[0]["userName"].ToString();
        //定义命令对象1、封用户表的用户信息
        OleDbCommand comm1 = new OleDbCommand();
        //OleDbCommand comm1 = new OleDbCommand("delete from users where userID=" + e.CommandArgument, conn);
        comm1.CommandText = update_sql;
        //这句必须指定，没有这句，


        comm1.Parameters.Add("@blockade", OleDbType.VarChar).Value = 1;
    
        
        //执行命令对象，并将执行结果转换为整型
        int i = Convert.ToInt32(comm1.ExecuteNonQuery());

        if (i > 0)//&& m > 0 && n > 0
        {
            Response.Write(com.msgBox("封除用户成功！但其相关的文章和留言并没有消失！正在跳转！！！", "UserManager.aspx"));
        }
        else
        {
            Response.Write(com.msgBox("删除失败！正在跳转！！！", "UserManager.aspx"));
        }
        //判断数据库的状态，如果打开就关闭
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}