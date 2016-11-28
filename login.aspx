<%@ Page Language="C#" MasterPageFile="MasterPage.master"  AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <body>
    
    <div>
   <table class="td" celpadding="0" cellspacing="0">
	<tr>
		<td>
		&nbsp;
		</td>
		<td class="td" colspan="2" align="center">
			登录界面</td>=
	</tr>
	<tr>
		<td>
		</td>
		<td align="center" colspan="2" valign="middle">
		<br />
		<table class="tb_lg" cellpadding="0" cellspacing="0">
		<tr>
			<td align="right">
			用户名：
			</td>
			<td align="left">
			<asp:Textbox ID="userName" runat="server"></asp:Textbox>
			</td>
			<td align="right">
			<asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="必须输入用户姓名" ControlToValidate="userName" ></asp:RequiredFieldValidator>
		</tr>
		<tr>
			<td align="center">
			密码：
			</td>
			<td align="left">
			<asp:Textbox ID="passWord" runat="server"></asp:TextBox>
			</td>
			<td align="left">
			<asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="必须输入密码" ControlToValidate="passWord"> </asp:RequiredFieldValidator>            
			</td>
		</tr>
		<tr>
			<td align="center">
			权限：
			</td>
			<td align="left">
			<asp:RadioButtonList ID="rbl" runat="server" RepeatDirection="Horizontal" >
				 <asp:ListItem Value="管理员">管理员</asp:ListItem>
				 <asp:ListItem Value="普通用户">普通用户</asp:ListItem>
			</asp:RadioButtonList>
			</td>
			<td align="left">
			<asp:RequiredFieldValidator ID="rfv3" runat="server" ErrorMessage="必须选择权限" ControlTovalidate="rbl"></asp:RequiredFieldValidator>
			</td>
		</tr>
		<tr>
			<td>
			</td>
			<td>
			<asp:Button ID="loginButtonn" runat="server" Text="登录" OnClick="loginButtonn_Click1" ></asp:Button>
			<asp:Button ID="resetButton" runat="server" Text="重置" OnClick="resetButton_Click"></asp:Button>
			<br />
			<br />
			还没有账号，现在<a href="register.aspx">注册</a>
			</td>
			<td>
			</td>
		</tr>
		</table>
		</td>
	</tr>
</table>
		
    </div>
   
</body>
</html>
    </asp:Content>