using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
{
    //定义全局的类
    Common com = new Common();
    DbClass db = new DbClass();
    int n,i;
    //定义一个全局的连接对象
    OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["conn"]);
    //定义一个全局的数据集
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否为已登录用户，若否，就提示用户先登录
       if (Session["userName"] == null)
       {
           Response.Write(com.msgBox("尊敬的用户，请您先登录！！！", "login.aspx"));
       }
       Response.Cookies["userName"].Value = Convert.ToString(Session["userName"]);
       Response.Write(Response.Cookies["userName"].Value);
        Response.Cookies["userName"].Expires = DateTime.Now.AddYears(2);
        Response.Write("Cookie的过期时间是2年");
        
    }
    protected void lnkTitle_Command(object sender, CommandEventArgs e)
    {

        //将标题的id传递到Article.aspx页面，并且文章标题和内容全部展开
        //Response.Redirect("Article.aspx? ID=" + Convert.ToInt32(e.CommandArgument));
        //int n = Convert.ToInt32(e.CommandArgument);
        Session["ID"] = Convert.ToInt32(e.CommandArgument).ToString();
        string str=string.Format("Article.aspx");
        Response.Redirect(str);
    }
    
    protected void submit_Click(object sender, EventArgs e)
    {

        //打开数据库
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        //根据按钮的文本选择执行命令语句
       
            OleDbConnection conn1 = new OleDbConnection(ConfigurationManager.AppSettings["conn"]);
            conn1.Open();
            string sqlstr1 = "select * from word";
            OleDbDataAdapter da1 = new OleDbDataAdapter(sqlstr1, conn1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            n = Convert.ToInt32(ds1.Tables[0].Rows.Count) + 1;
            conn1.Close();
            string str0 = n.ToString();
            string str1 = Convert.ToString(Session["userName"]);
            string str2 = txtTitle.Text.Trim().ToString();
            string str3 = txtContent.Text.Trim().ToString();
            string str4 = DateTime.Now.ToString();
            //定义一个命令对象，在文章表中插入作者，文章标题，内容及发表时间
            string sqlstr="insert into word values(" + str0 + ",'" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')";
            //定义一个整型，并将命令对象的执行结果影响的行数赋值给整型
           // int i = comm.ExecuteNonQuery();
            OleDbCommand comm = new OleDbCommand(sqlstr, conn);
            i = Convert.ToInt32(comm.ExecuteNonQuery());
            //如果执行结果影响的行数大于0，则表示作者发表成功
            if (i > 0)
            {
                //给予相关提示并刷新当前页面
                Response.Write(com.msgBox("文章发表成功，正在跳转", "SendArticle.aspx"));
            }
            else
            {
                //如果发表失败，给予相关提示并刷新当前页面
                Response.Write(com.msgBox("文章发表失败，请重新发表", "SendArticle.aspx"));
            }
       
        
        //判断数据库的状态，如果打开就关闭
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
    }
    protected void cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SendArticle.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}