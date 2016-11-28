<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
   <br />
    <div id="title">
        <asp:Label ID="Label1" runat="server"></asp:Label></div>
        <br />
    <div id="content">
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        </div>
        <div id="time"> 
            <br />
            发表时间：<asp:Label ID="lblTime" runat="server"></asp:Label>
        </div>
         <div id="control">
            <br />
            <asp:LinkButton
                ID="back" runat="server" onclick="back_Click">返回</asp:LinkButton>&nbsp;
             <br />
            <asp:TextBox ID="comment"  runat="server" ></asp:TextBox>
    <asp:Button ID="submit" runat="server" Text="评论" OnClick="submit_Click" />
                <asp:Label ID="label3" runat="server" ></asp:Label>
    </div>

</asp:Content>
