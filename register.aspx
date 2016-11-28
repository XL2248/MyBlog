<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <body>
    
    <div>
      <table class="tb" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            </td>
            <td class="td" colspan="2">
                注册页面</td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="center">
                <br />
             
                <table class="tb_rg" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="用户名：" AssociatedControlID="name"></asp:Label></td>
                        <td align="left">
                            <asp:TextBox ID="name" runat="server" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="name" ErrorMessage="必须输入用户名" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="密 码：" AssociatedControlID="pwd"></asp:Label></td>
                        <td align="left">
                            <asp:TextBox ID="pwd" runat="server" MaxLength="12" TextMode="Password" 
                                Width="150px"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="pwd" ErrorMessage="密码为空或不正确" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="确认密码：" AssociatedControlID="confirmPwd"></asp:Label></td>
                        <td align="left">
                            <asp:TextBox ID="confirmPwd" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="confirmPwd" ControlToValidate="pwd" ErrorMessage="与原密码不一致" 
                                ForeColor="Red"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align"right">
                            <asp:Label ID="Label4" runat="server" Text="生日：" AssociatedControlID="birthDay"></asp:Label></td>
                        </td>
                        <td>
                            <asp:TextBox ID="birthDay" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv2" runat="server" controlToValidate="birthDay" ErrorMessage="必须填写生日" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="性别：" AssociatedControlID="radioSex"></asp:Label></td>
                        <td align="left">
                            <asp:RadioButtonList ID="radioSex" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="男">男</asp:ListItem>
                                <asp:ListItem Value="女">女</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="radioSex" ErrorMessage="性别必须选择" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="center">
                            <asp:Button ID="btnRegister" runat="server"  
                                Text="注册" OnClick="btnRegister_Click" />
                            &nbsp;
                            <asp:Button ID="reset" runat="server"  Text="重置" OnClick="reset_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>

               </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    </div>
</body>
</html>
    </asp:Content>