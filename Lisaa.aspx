<%@ Page Title="" Language="C#" MasterPageFile="~/TopBar.master" AutoEventWireup="true" CodeFile="Lisaa.aspx.cs" Inherits="Lisaa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HyperLink ID="btnLisaaMonster" NavigateUrl="~/LisaaMonster.aspx" runat="server" ><h4>Lisää Monsteri</h4></asp:HyperLink>
    <asp:HyperLink ID="btnLisaaEncounter" NavigateUrl="~/LisaaEncounter.aspx" runat="server"><h4>Lisää Encounteri</h4></asp:HyperLink>
</asp:Content>

