using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///MessageBox 的摘要说明
/// </summary>
public class MessageBox
{
	public MessageBox()
	{
	}

    //参数TxtMesage 为发送的内容
    //参数Url 为对话框关闭后跳转的页面
    public string SendMessageBox(string TxtMessage, string Url)
    {
        string str;
        str = "<script language=javascript>alert('"
            + TxtMessage + "');location='" + Url + "'</script>";
        return str;
    }
}