using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tet1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        if(comment.Text.Trim()!=null)
        {
            string str=@"<br \>"+comment.Text.Trim().ToString();
            label1.Text += str;
        }
    }
}