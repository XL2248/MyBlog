<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="All.aspx.cs" Inherits="Default4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br />
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="td" colspan="2">
                最新信息
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <div class="search">
                    <div class="kw">
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                        <label class="kw_info">
                            请输入标题</label>
                    </div>
                    <form action="" name="form">
                    <%--<input name="txtname" id="txtname" type="text" onblur="check()" />--%>
                    </form>
                    &nbsp;
                    <asp:Button ID="searchTitle" runat="server" Text="标题搜索" OnClick="searchTitle_Click" />
                </div>
                <script type="text/javascript">
                   
                  
                </script>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="标题">
                            <ItemTemplate>
                                <asp:LinkButton ID="title" runat="server" Font-Underline="False" Text='<%# Eval("title").ToString().Length>6?Eval("title").ToString().Substring(0,6)+"...":Eval("title").ToString() %>'
                                    CommandArgument='<%# Eval("ID") %>' OnCommand="Title_Command" Width="80px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="正文">
                            <ItemTemplate>
                                <asp:LinkButton ID="content" runat="server" Font-Underline="False" Text='<%# Eval("content").ToString().Length>90?Eval("content").ToString().Substring(0,90)+"...":Eval("content").ToString() %>'
                                    CommandArgument='<%# Eval("ID") %>' OnCommand="content_Command"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="作者">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("userName") %>' Width="70px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发表时间">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <br />
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
                <div class="search">
                    <asp:LinkButton ID="moreArticles" runat="server" Font-Underline="False" OnClick="moreArticles_Click">更多文章》</asp:LinkButton>
                </div>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333"
                    GridLines="None" PageSize="4">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="title" HeaderText="主题" SortExpression="title">
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="content" HeaderText="内容" SortExpression="content" />
                        <asp:BoundField DataField="userName" HeaderText="发言人" SortExpression="userName">
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="time" HeaderText="留言时间" SortExpression="time" />
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Blog.mdb"
                    SelectCommand="SELECT TOP 5 * FROM [word] ORDER BY [time] DESC, [title]">
                </asp:AccessDataSource>
                <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/Blog.mdb"
                    SelectCommand="SELECT * FROM [word] ORDER BY [time] DESC, [title]"></asp:AccessDataSource>
                <br />
                <div class="search">
                    <asp:LinkButton ID="lnkBtnWords" runat="server" Font-Underline="False" OnClick="moreWords_Click">更多留言》</asp:LinkButton>
                </div>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    </asp:Content>