<%@ Page Title="" Language="C#" MasterPageFile="BlogMasterPage.master" AutoEventWireup="true" CodeFile="UserManager.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <br />
        <table class="tb">
            <tr>
                <td>
                    &nbsp;</td>
                <td class="td" colspan="2">
                    用户管理</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" DataSourceID="AccessDataSource1" 
                        ForeColor="#333333" GridLines="None" PageSize="6" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="userName" HeaderText="用户名" 
                                SortExpression="userName" />
                            
                            <asp:BoundField DataField="sex" HeaderText="性别" SortExpression="sex" />
                     
                            <asp:BoundField DataField="birthDay" HeaderText="生日" SortExpression="birthDay" />
                            <asp:BoundField DataField="blockade" HeaderText="是否封号" SortExpression="blockade" />
                    
                            <asp:TemplateField HeaderText="操作1">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDel" runat="server" OnClientClick="return confirm('删除用户会把相关的文章和留言都删除掉。确认删除吗？');" oncommand="lnkDel_Command" CommandArgument='<%# Eval("userId") %>'>删除</asp:LinkButton>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="操作2">
                                <ItemTemplate>
                                    
                                    <asp:LinkButton ID="LnkFenHao" runat="server" OnClientClick="return confirm('封除用户不会把相关的文章和留言都删除掉。确认封号吗？');" oncommand="lnkFenHao_Command" CommandArgument='<%# Eval("userId") %>'>封号</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerSettings FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
                            PreviousPageText="上一页" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                        DataFile="~/App_Data/Blog.mdb" 
                        SelectCommand="SELECT * FROM [userInfo] ORDER BY [userName] DESC">
                    </asp:AccessDataSource>

                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
   

</asp:Content>

