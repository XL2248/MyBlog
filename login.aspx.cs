using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;



public partial class login : System.Web.UI.Page
{
    Common comm = new Common();
    DbClass dbc = new DbClass();
    protected void Page_Load(object sender, EventArgs e)
    {
         //如果用户还没有注销就提示要先注销才能登录
        if (Session["userName"] != null)
        {

        }
    }
    protected void resetButton_Click(object sender, EventArgs e)
    {
        userName.Text = "";
        passWord.Text = "";
        rbl.SelectedIndex = -1;
    }
    protected void loginButtonn_Click1(object sender, EventArgs e)
    {
        DataTable userDt;
        DataTable adminDt;
        dbc.Open();
        if (rbl.SelectedValue == "普通用户")
        {
            string sqlstr1 = "select * from userInfo where userName='" + userName.Text.Trim().ToString() + "'and passWord='" + passWord.Text.Trim().ToString() + "'";
            userDt = dbc.getTable(sqlstr1, "user");
            if (userDt.Rows.Count > 0)
            {
                if (Convert.ToInt32(userDt.Rows[0][5]) == 0)
                {
                    //如果登录的人是非管理员就保存用户的所有信息
                    Response.Write(comm.msgBox("登录成功！正在为您跳转！！！", "SendArticle.aspx"));
                    Session["userName"] = userDt.Rows[0]["userName"];
                    Session["passWord"] = userDt.Rows[0]["passWord"];
                    Session["sex"] = userDt.Rows[0]["sex"];
                    Session["birthDay"] = userDt.Rows[0]["birthDay"];
                }
                else
                {
                    Response.Write(comm.msgBox("账号已被封锁！请联系管理员！！", "login.aspx"));
                }
            }
        }
        else if (rbl.SelectedValue == "管理员")
        {

            string strSql02 = "select * from adminInfo where userName='" + userName.Text.Trim().ToString() + "' and passWord='" + passWord.Text.Trim().ToString() + "'";
            adminDt = dbc.getTable(strSql02, "tbAdmins");
            if (adminDt.Rows.Count > 0)
            {
                Response.Write(comm.msgBox("登录成功！正在为您跳转！！！", "UserManager.aspx"));
                Session["userName"] = adminDt.Rows[0]["userName"];
            }
        }
        else
        {
            Response.Write(comm.msgBox("输入有误！请重新输入！！！", "login.aspx"));
        }
        dbc.Close();
    }
}