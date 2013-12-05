<%@ Page Title="Encounterit" Language="C#" MasterPageFile="~/TopBar.master" AutoEventWireup="true" CodeFile="Encounterit.aspx.cs" Inherits="Encounterit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <h1>Haku:</h1>
                <h2>Kohtaamisen taso: <asp:TextBox ID="txtboxKohtaamisenTaso" runat="server"></asp:TextBox>
               <!-- <h2>Minimi Kokemuspisteet: <asp:TextBox ID="txtboxKohtaamisenExpMin" runat="server"></asp:TextBox>
                    Maksimi Kokemuspisteet: <asp:TextBox ID="txtboxKohtaamisenExpMaks" runat="server"></asp:TextBox></h2>-->
                <h2>Sana Haku: <asp:TextBox ID="txtboxSanaHaku" runat="server"></asp:TextBox></h2>
                <h1>Encountteri:</h1>
                <h2>Nimi: <asp:CheckBox ID="checkNimi" runat="server" />
                    Kuvaus: <asp:CheckBox ID="checkKuvaus" runat="server" /></h2>
                
                <asp:Button ID="btnHaku" runat="server" Text="Hae" OnClick="getEncountterit"/>
            </td>
        </tr>
    </table>
    
    <table border="1">
    
        <h1>Encountterit:</h1>
        <asp:Repeater ID="RepeaterEncounters" runat="server" OnItemCommand="RepeaterEncounters_ItemCommand">
            <ItemTemplate>
                <h2><%# DataBinder.Eval(Container.DataItem, "encounterName") %></h2>
                <h3>Tason <%# DataBinder.Eval(Container.DataItem, "encounterLevel") %> kohtaaminen</h3>
                <h3><%# DataBinder.Eval(Container.DataItem, "encounterDesc") %></h3>
                <asp:Button runat="server" Text="Lataa Monsterit" ToolTip=<%# DataBinder.Eval(Container.DataItem, "encounterMonsters") %> />
                
                
                

                
            </ItemTemplate>
        </asp:Repeater>

</table>


    <!-- Lisää haluttu taulukko tyyppi huehue -->
</asp:Content>

