using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class MasterPage: System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            this.LoginLinkButton.Visible = false;
            this.RegisterLinkButton.Visible = false;
            this.labUser.Visible = true;
            this.btnExitUser.Visible = true;
            this.labUser.Text = "欢迎您," + Session["userName"].ToString();
        }
        else
        {
            this.btnExitUser.Visible = false;
            this.labUser.Visible = false;
        }
    }
    protected void btnExitUser_Click(object sender, EventArgs e)
    {
        MessageBox message = new MessageBox();
        if (Session["userName"] != null)
        {
            Session["userName"] = null;
            Response.Write(message.SendMessageBox("退出成功", "/" +
                ConfigurationManager.AppSettings["FileFloderName"].ToString() +     //加上该网站的文件夹名
                "Article.aspx"));
        }
    }
}
