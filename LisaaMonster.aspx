<%@ Page Title="" Language="C#" MasterPageFile="~/TopBar.master" AutoEventWireup="true" CodeFile="LisaaMonster.aspx.cs" Inherits="Lisaa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table cellspacing="0px">
                <tr><td><h1>Lisää Monsteri:</h1></td></tr>
                <tr><td><h5>Nimi: <asp:TextBox ID="monNimi" runat="server"></asp:TextBox></h5></td>
                <td><h5>Taso: <asp:TextBox ID="monLevel" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Rooli: <asp:TextBox ID="monRole" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Tyyppi: <asp:TextBox ID="monType" runat="server"></asp:TextBox></h5></td>
                <td><h5>Kokemuspisteet: <asp:TextBox ID="monExp" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>HP: <asp:TextBox ID="monHP" runat="server"></asp:TextBox></h5></td>
                <td><h5>Bloodied: <asp:TextBox ID="monBloodied" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Aloitekyky: <asp:TextBox ID="monInit" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>AC: <asp:TextBox ID="monAC" runat="server"></asp:TextBox></h5></td>
                <td><h5>Fort: <asp:TextBox ID="monFort" runat="server"></asp:TextBox></h5></td>
                <td><h5>Ref: <asp:TextBox ID="monRef" runat="server"></asp:TextBox></h5></td>
                <td><h5>Will: <asp:TextBox ID="monWill" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Aistit: <asp:TextBox ID="monSenses" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Nopeus: <asp:TextBox ID="monSpeed" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Vastustukset: <asp:TextBox ID="monResist" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Pelastavat heitot: <asp:TextBox ID="monSaves" runat="server"></asp:TextBox></h5></td>
                <td><h5>Toiminta pisteet: <asp:TextBox ID="monAP" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Taidot: <asp:TextBox ID="monSkills" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Str: <asp:TextBox ID="monStr" runat="server"></asp:TextBox></h5></td>
                <td><h5>Dex: <asp:TextBox ID="monDex" runat="server"></asp:TextBox></h5></td>
                <td><h5>Wis: <asp:TextBox ID="monWis" runat="server"></asp:TextBox></h5></td>
                <td><h5>Con: <asp:TextBox ID="monCon" runat="server"></asp:TextBox></h5></td>
                <td><h5>Int: <asp:TextBox ID="monInt" runat="server"></asp:TextBox></h5></td>
                <td><h5>Cha: <asp:TextBox ID="monCha" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Ryhmitys: <asp:TextBox ID="monAlign" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Kielet: <asp:TextBox ID="monLang" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Varusteet: <asp:TextBox ID="monEquip" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h2>Kyvyt:</h2></td></tr>
                <tr><td><h2>1:</h2></td></tr>
                <tr><td><h5>Pääkkyky: <asp:CheckBox ID="powMain1" runat="server" /></h5></td>
                <td><h5>Nimi: <asp:TextBox ID="powName1" runat="server"></asp:TextBox></h5></td>
                <td><h5>Saatavuus: <asp:TextBox ID="powAvail1" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Tyyppi: <asp:TextBox ID="powType1" runat="server"></asp:TextBox></h5></td>
                <td><h5>Kuvaus: <asp:TextBox ID="powDesc1" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h2>2:</h2></td></tr>
                <tr><td><h5>Pääkkyky: <asp:CheckBox ID="powMain2" runat="server" /></h5></td>
                <td><h5>Nimi: <asp:TextBox ID="powName2" runat="server"></asp:TextBox></h5></td>
                <td><h5>Saatavuus: <asp:TextBox ID="powAvail2" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Tyyppi: <asp:TextBox ID="powType2" runat="server"></asp:TextBox></h5></td>
                <td><h5>Kuvaus: <asp:TextBox ID="powDesc2" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h2>3:</h2></td></tr>
                <tr><td><h5>Pääkkyky: <asp:CheckBox ID="powMain3" runat="server" /></h5></td>
                <td><h5>Nimi: <asp:TextBox ID="powName3" runat="server"></asp:TextBox></h5></td>
                <td><h5>Saatavuus: <asp:TextBox ID="powAvail3" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><h5>Tyyppi: <asp:TextBox ID="powType3" runat="server"></asp:TextBox></h5></td>
                <td><h5>Kuvaus: <asp:TextBox ID="powDesc3" runat="server"></asp:TextBox></h5></td></tr>
                <tr><td><asp:Button ID="btnLisaa" runat="server" Text="Lisää Monsteri" OnClick="btnLisaa_Click"/></td></tr>
        </table>
</asp:Content>

