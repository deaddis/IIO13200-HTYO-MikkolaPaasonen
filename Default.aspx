<%@ Page Title="Home" Language="C#" MasterPageFile="~/TopBar.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:ListView ID="ListView1" runat="server" >
        <LayoutTemplate>
          <table cellpadding="2" border="1" width="640px" runat="server" style="margin:10px 10px 10px 10px; " id="tblCars">
            <tr runat="server" id="itemPlaceholder" />
          </table>
        </LayoutTemplate>
         <ItemTemplate>
          <tr id="Tr2" runat="server">
            <td>
              <div id="Div1" runat="Server">
                  <h1><span class="bold"><%#Eval("DATE") %> - <%#Eval("Otsikko") %></span></h1>
                  <h3><%#Eval("Kirjoitus") %></h3>
                  <h4><%#Eval("Kirjoittaja") %></h4>
              </div>
            </td>
          </tr>
        </ItemTemplate>
    </asp:ListView>

    <asp:ListView ID="ListView2" runat="server" >
        <LayoutTemplate>
          <table cellpadding="2" border="0" width="640px" runat="server" style="margin:10px 10px 10px 10px; " id="itemPlaceholder" >
          </table>
        </LayoutTemplate>
         <ItemTemplate>
            <tr>
                <td>
                    <div id="Div1" runat="Server">
                        <h1><span class="bold"><%#Eval("DATE") %> - <%#Eval("Otsikko") %></span></h1>
                        <h3><%#Eval("Kirjoitus") %> </h3>
                        <h4><%#Eval("Kirjoittaja") %></h4>
                    </div>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <div runat="server" id="er"></div>
</asp:Content>

