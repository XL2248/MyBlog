<%@ Page Language="C#"MasterPageFile="BlogMasterPage.master"  AutoEventWireup="true" CodeFile="SendArticle.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <br />
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2" class="td">
                    文章页面</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center">
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID,userName" 
                        DataSourceID="AccessDataSource1" ForeColor="#333333" GridLines="None" 
                        PageSize="5" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                            <asp:CommandField ShowSelectButton="True" />
                             <asp:BoundField DataField="ID" HeaderText="编号" 
                                SortExpression="ID" />
                            <asp:TemplateField HeaderText="标题" SortExpression="title">
                                <ItemTemplate>
                                    <asp:LinkButton ID="title" runat="server" 
                                        
                                        Text='<%# Eval("title").ToString().Length>6?Eval("title").ToString().Substring(0,6)+"...":Eval("title").ToString() %>' 
                                        oncommand="lnkTitle_Command" CommandArgument='<%# Eval("ID") %>' 
                                        Font-Size="12pt"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("title") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:BoundField DataField="userName" HeaderText="作者" ReadOnly="True" 
                                SortExpression="userName" >
                            <ControlStyle Width="60px" />
                            <HeaderStyle Width="60px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="content" HeaderText="内容" 
                                SortExpression="content" />
                            <asp:BoundField DataField="time" HeaderText="发表时间" 
                                SortExpression="time" />
                            
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

                     <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                        DataFile="~/App_Data/Blog.mdb" 
                        SelectCommand="SELECT * FROM [word] ORDER BY [userName] DESC">
                    </asp:AccessDataSource>

                    <br />
                    <br />
                    <br />
                    <asp:Panel ID="Panel1" runat="server" BackColor="ActiveCaption" Height="500px" 
                        Width="570px">
                        <asp:Panel ID="Panel2" runat="server" BackColor="Brown" Height="31px" 
                            Width="570px">
                            <center style="height: 26px">
                                <asp:Label ID="lbEdit" runat="server" Text=""></asp:Label>
                            </center>
                        </asp:Panel>
                        <asp:Panel ID="Panel3" runat="server" Height="500px" Width="570px">
                <br />
                            标题：<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtTitle" ErrorMessage="标题不能为空" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                <br />
                <br />
                <br />
                            内容：<asp:TextBox ID="txtContent" runat="server" Height="300px" 
                                TextMode="MultiLine" Width="400px"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtContent" ErrorMessage="内容不能为空" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            <br />
                            &nbsp;<br /> &nbsp;<asp:Button ID="submit" runat="server"  onclick="submit_Click" 
                                Text="提交" />
                            &nbsp;
                            <asp:Button ID="cancel" runat="server"  onclick="cancel_Click" Text="取消" />
                            &nbsp;&nbsp;&nbsp;</asp:Panel>
                    </asp:Panel>
                    <br />
                    
                    
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
                <td>
                   
                </td>
            </tr>
        </table>

</asp:Content>
