<%@ Page Title="" Language="C#" MasterPageFile="~/TopBar.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="Account_MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Account details for <%  Response.Write(User.Identity.Name);%></h1>
     <div id="info">
         <h4>Account: <asp:Label ID="myName" runat="server"></asp:Label></h4>
         <h4>Email: <asp:Label ID="myEmail" runat="server"></asp:Label></h4>
         <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Account/ChangePassword.aspx">Vaihda salasana</asp:HyperLink>
     </div>
</asp:Content>

