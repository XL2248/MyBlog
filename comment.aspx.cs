using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Timers;

public partial class tet1 : System.Web.UI.Page
{
    OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["conn"]);
    DataSet ds = new DataSet();
    OleDbDataAdapter da;
    Common com = new Common();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //session对象须有跳转页面时给出；
       Session["Title"]="满江红";
        Session["Author"]="hero";
        Session["UserName"] = "hero";
       
        string sqlstr = "select * from comment where title='" + Session["Title"].ToString() + "' and author='" + Session["Author"] + "'";
        conn.Open();
        da = new OleDbDataAdapter(sqlstr, conn);
        da.Fill(ds, "comment");
        int n = ds.Tables[0].Rows.Count;
        if(n>0)
        {
            for (int i = 0; i < n; i++)
            {
                string commentstr = "<p class=name>" + ds.Tables[0].Rows[i]["audience"].ToString() + "(" + ds.Tables[0].Rows[i]["time"].ToString() + "):" + "</p>" + "&nbsp &nbsp" + ds.Tables[0].Rows[i]["comment"].ToString();
                label1.Text +="<br />"+ commentstr;
            }
        }
        sqlstr = "select * from comment";
        da = new OleDbDataAdapter(sqlstr, conn);
        da.Fill(ds, "comment");
        conn.Close();
        
       
    }

    protected void updata(DataRow row)
    {
       /* OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
        da.InsertCommand = builder.GetInsertCommand();
        da.UpdateCommand = builder.GetUpdateCommand();
        da.DeleteCommand = builder.GetDeleteCommand();
        da.Update(ds, "comment");
        ds.AcceptChanges();
        */
        conn.Open();
        string sqlstr2="insert into comment values('"+row[0].ToString()+"','"+row[1].ToString()+"','"+row[2].ToString()+"','"+row[3].ToString()+"','"+row[4]+"')";
        OleDbCommand comm = new OleDbCommand(sqlstr2, conn);
        conn.Close();
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        
        if (Session["userName"] == null)
            Response.Write("<script>alert('请先登录！')</script>");
        else
        {
            if (comment.Text.Trim() != null)
            {
                DateTime DT = System.DateTime.Now;
                string dt = System.DateTime.Now.ToString();
                string str = "<br />" + "<p class=name>" + Session["UserName"].ToString() + "(" + dt + "):" + "</p>" + "&nbsp &nbsp" + comment.Text.Trim().ToString();
                label1.Text += str;

                DataRow row = ds.Tables[0].NewRow();
                row[0] = Session["UserName"];
                row[1] = Session["Author"];
                row[2] = Session["Title"];
                row[3] = comment.Text.Trim().ToString();
                row[4] = dt;
                ds.Tables[0].Rows.Add(row);
                updata(row);
            }
        }
       
    }
}