using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

public partial class Default3 : System.Web.UI.Page
{
    //定义连接对象，类，数据集
    OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["conn"]);
    Common com = new Common();
    DataSet ds = new DataSet();
   
    protected void back_Click(object sender, EventArgs e)
    {
          Response.Redirect("SendArticle.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["ID"] = 1;
        //判断本页面是否首次加载
        if (!IsPostBack)
        {
            //判断数据库的连接状态
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //从前一页面传回来的id获取留言的信息，并填充到各个字段
           
           string sqlstr="select * from word where ID=" +Session["ID"].ToString();//Convert.ToString(Session["userName"]) 
            //string sqlstr = "select * from word where ID=1"; //labeltxt.Text = Request.QueryString["ID"].ToString();
            OleDbCommand comm = new OleDbCommand(sqlstr, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(comm);

            da.Fill(ds, "word");
            //string ID = ds.Tables[0].Rows[0]["ID"].ToString();
            Label1.Text = ds.Tables[0].Rows[0]["title"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["content"].ToString();
            lblTime.Text = ds.Tables[0].Rows[0]["time"].ToString();

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        else
        {

        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        DateTime DT = System.DateTime.Now;
        string dt = System.DateTime.Now.ToString();
        string str = "<br />" + "<p class=name>" + Session["UserName"].ToString() + "(" + dt + "):" + "</p>" + "&nbsp &nbsp" + comment.Text.Trim().ToString();
        label3.Text += str;
    }
}