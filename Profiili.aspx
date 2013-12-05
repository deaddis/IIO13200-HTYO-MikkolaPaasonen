<%@ Page Title="" Language="C#" MasterPageFile="~/TopBar.master" AutoEventWireup="true" CodeFile="Profiili.aspx.cs" Inherits="Profiili" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <td>
        <table cellpadding="5" border="1" width="640px">
            <tr>
                <td>
                    <h4>Email: <asp:TextBox ID="txtboxEmail" runat="server"></asp:TextBox></h4>
                    <h4>Salasana: <asp:TextBox ID="txtboxPassword" runat="server"  TextMode="Password"></asp:TextBox></h4>
                    <h4>Vahvista Salasana: <asp:TextBox ID="TextBox1" runat="server"  TextMode="Password"></asp:TextBox></h4><br />
                    <h4>Nykyinen Salasana: <asp:TextBox ID="TextBox2" runat="server"  TextMode="Password"></asp:TextBox></h4>
                    <asp:Button ID="btnSaveChanges" Text="Tallenna muutokset" runat="server" OnClick="SaveChanges"/>
                    <asp:Button ID="btnPoistaTunnus" Text="Poista Tunnus" runat="server" OnClick="PoistaTunnus"/>
                </td>
            </tr>
        </table>
    </td>
</asp:Content>

