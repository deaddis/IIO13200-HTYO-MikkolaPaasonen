<%@ Page Title="" Language="C#" MasterPageFile="~/TopBar.master" AutoEventWireup="true" CodeFile="Omat.aspx.cs" Inherits="Omat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1">
    <asp:XmlDataSource ID="xmlMonsters" DataFile="~/App_Data/monsters.xml" runat="server"></asp:XmlDataSource>
    
    <asp:TreeView ID="TVMonsters" runat="server" DataSourceID="xmlMonsters">
        <DataBindings>
            <asp:TreeNodeBinding DataMember="Monsters" Text ="Monsters" />
            <asp:TreeNodeBinding DataMember="Monster" TextField="name" />
            <asp:TreeNodeBinding DataMember="Attack" TextField="name" />
        </DataBindings>
    </asp:TreeView>
</table>
</asp:Content>

