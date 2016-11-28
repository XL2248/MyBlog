using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

public partial class Default4 : System.Web.UI.Page
{
    OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["conn"]);
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //判断数据库的状态，如果关闭就打开
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //定义命令对象，执行查询语句
            OleDbCommand comm = new OleDbCommand("select top 5 * from word order by time desc", conn);
            OleDbDataAdapter da = new OleDbDataAdapter(comm);
            da.Fill(ds, "word");
            GridView1.DataSource = ds.Tables["word"].DefaultView;
            GridView1.DataBind();

            GridView2.DataSourceID = "AccessDataSource1";
            GridView2.DataBind();
            GridView2.PageIndex = 0;

            //判断数据库的状态，如果打开就关闭
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        
    }
    protected void lnkTitle_Command(object sender, CommandEventArgs e)
    {

        //将标题的id传递到Article.aspx页面，并且文章标题和内容全部展开
        Response.Redirect("Article.aspx? ID=" + Convert.ToInt32(e.CommandArgument));
    }
    protected void lnkContent_Command(object sender, CommandEventArgs e)
    {

        //将标题的id传递到Article.aspx页面，并且文章标题和内容全部展开
        Response.Redirect("Article.aspx? ID=" + Convert.ToInt32(e.CommandArgument));
    }
    public void bind()
    {

        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }

        OleDbCommand comm = new OleDbCommand("select * from word order by time desc", conn);
        OleDbDataAdapter da = new OleDbDataAdapter(comm);
        da.Fill(ds, "word");
        GridView1.DataSource = ds.Tables["word"].DefaultView;
        GridView1.AllowPaging = true;
        GridView1.PageSize = 6;
        GridView1.DataBind();

        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }

    }
    protected void moreArticles_Click(object sender, EventArgs e)
    {
        bind();
        moreArticles.Text = "";
        moreArticles.Visible = false;
    }
    protected void Title_Command(object sender, CommandEventArgs e)
    {
        //将标题的id传递到showArticle.aspx页面，并且文章标题和内容全部展开
        Response.Redirect("Article.aspx? ID=" + Convert.ToInt32(e.CommandArgument));
    }
    protected void content_Command(object sender, CommandEventArgs e)
    {
        //将标题的id传递到showArticle.aspx页面，并且文章标题和内容全部展开
        Response.Redirect("Article.aspx? ID=" + Convert.ToInt32(e.CommandArgument));
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind();
    }
    protected void moreWords_Click(object sender, EventArgs e)
    {

        GridView2.DataSourceID = "AccessDataSource2";
        GridView2.DataBind();
        GridView2.PageIndex = 0;
        lnkBtnWords.Text = "";
        lnkBtnWords.Visible = false;
    }
    protected void searchTitle_Click(object sender, EventArgs e)
    {

        OleDbCommand comm = new OleDbCommand("select * from word where title like '%" + txtTitle.Text.Trim().ToString() + "%' order by time desc", conn);
        OleDbDataAdapter da = new OleDbDataAdapter(comm);
        da.Fill(ds, "word");
        if (ds.Tables["word"].Rows.Count > 0)
        {
            GridView1.AllowPaging = true;
            GridView1.PageSize = 5;
            GridView1.DataSource = ds.Tables["word"].DefaultView;
            GridView1.DataBind();
            Label1.Text = "找到以上文章";
            moreArticles.Text = "";
            moreArticles.Visible = false;
        }
        else
        {

            Label1.Text = "暂时没有相关数据";
            moreArticles.Text = "";
            moreArticles.Visible = false;
        }
    }
}