﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comment.aspx.cs" Inherits="tet1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
.name{
		font-size:15px;
		font-weight:bold;
		font-style:italic;
		font-family:"Microsoft Yahei"
	}
.comment
{
	font-size:25px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="comment"  runat="server" ></asp:TextBox>
    <asp:Button ID="submit" runat="server" Text="提交" OnClick="submit_Click" />
        <table>
            <tr>
                <asp:Label ID="label1" runat="server" ></asp:Label>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
