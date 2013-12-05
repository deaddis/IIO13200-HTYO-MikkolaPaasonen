<%@ Page Title="" Language="C#" MasterPageFile="~/TopBar.master" AutoEventWireup="true" CodeFile="MonsteritEiHaku.aspx.cs" Inherits="MonsteritEiHaku" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Repeater ID="RepeaterMonsters" runat="server">
                    <ItemTemplate>
                        <div
                    style="font-family: arial; font-size: 8pt; width: 350px; line-height: 10.5pt;">
                    <div
                        style="padding: 2px 5px 0px; background-color: rgb(80, 96, 80); color: rgb(255, 255, 255); height: 28px;">
                        <div style="font-weight: bold; float: left"><%# DataBinder.Eval(Container.DataItem, "name") %></div>
                        <div style="font-weight: bold; float: right;"> Level <%# DataBinder.Eval(Container.DataItem, "Level") %> <%# DataBinder.Eval(Container.DataItem, "Role") %></div>
                        <br>
                        <div style="float: left; font-size: 7pt;"><%# DataBinder.Eval(Container.DataItem, "Type") %></div>
                        <div style="float: right; font-size: 7pt;">XP <%# DataBinder.Eval(Container.DataItem, "XP") %></div>
                    </div>
                    <div
                        style="padding: 0px 0px 3px 5px; background-color: rgb(221, 221, 204);">
                        <div style="padding: 0px 5px; float: right; text-align: right;">
                            <b>Initiative</b> <%# DataBinder.Eval(Container.DataItem, "Init") %><br>
                            <%# DataBinder.Eval(Container.DataItem, "Senses") %><br>
                        </div>
                        <b>HP</b> <%# DataBinder.Eval(Container.DataItem, "HP") %>; <b>Bloodied</b> <%# DataBinder.Eval(Container.DataItem, "Bloodied") %><br>
                        <b>AC</b> <%# DataBinder.Eval(Container.DataItem, "AC") %>, <b>Fortitude</b> <%# DataBinder.Eval(Container.DataItem, "Fort") %>, <b>Reflex</b> <%# DataBinder.Eval(Container.DataItem, "Ref") %>, <b>Will</b> <%# DataBinder.Eval(Container.DataItem, "Will") %><br>
                        <b>Speed</b> <%# DataBinder.Eval(Container.DataItem, "Speed") %><br>
                        <%# DataBinder.Eval(Container.DataItem, "Resist") %>;<br>
                        <b>Saving Throws</b> <%# DataBinder.Eval(Container.DataItem, "Saves") %>; <b>Action Points</b> <%# DataBinder.Eval(Container.DataItem, "AP") %><br>
                    </div>
                   <!-- REPEATER VÄLI -->
                    <div
                        style="padding: 1px 0px 2px 5px; background-color: rgb(80, 96, 80); color: rgb(255, 255, 255); font-variant: small-caps; font-weight: bold; position: relative;">
                        Standard / Move / Minor / Free Actions
                    </div>
                    <asp:Repeater ID="RepeaterAttacks" runat="server" EnableViewState="false" DataSource='<%# DataBinder.Eval(Container.DataItem, "Attackit") %>'>
                        <ItemTemplate>

                            
                    <div
                        style="padding: 1px 0px 2px 5px; background-color: rgb(204, 204, 187); position: relative;">
                        <%# DataBinder.Eval(Container.DataItem, "type") %>
                        <b><%# DataBinder.Eval(Container.DataItem, "name") %></b> <%# DataBinder.Eval(Container.DataItem, "avail") %> ♦ <b><%# DataBinder.Eval(Container.DataItem, "School") %></b>
                    </div>
                    <div
                        style="padding: 1px 0px 2px 20px; background-color: rgb(221, 221, 204);">
                        <%# DataBinder.Eval(Container.DataItem, "Desc") %>
                    </div>

                        </ItemTemplate>


                    </asp:Repeater>
                    



                   <!-- REPEATER VÄLI --> 
                    <div
                        style="padding: 1px 0px 3px 5px; background-color: rgb(204, 204, 187);">
                        <b>Skills</b> <%# DataBinder.Eval(Container.DataItem, "Skills") %><br>
                        <table
                            style="border-style: none; margin: 0px; border-collapse: collapse; width: 344px;">
                            <tbody>
                                <tr>
                                    <td
                                        style="border-style: none; padding: 0px; font-size: 8pt; width: 115px;"><b>Str</b>
                                        <%# DataBinder.Eval(Container.DataItem, "Str") %></td>
                                    <td
                                        style="border-style: none; padding: 0px; font-size: 8pt; width: 115px;"><b>Dex</b>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Dex") %></td>
                                    <td
                                        style="border-style: none; padding: 0px; font-size: 8pt; width: 115px;"><b>Wis</b>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Wis") %></td>
                                </tr>
                                <tr>
                                    <td
                                        style="border-style: none; padding: 0px; font-size: 8pt; width: 115px;"><b>Con</b>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Con") %></td>
                                    <td
                                        style="border-style: none; padding: 0px; font-size: 8pt; width: 115px;"><b>Int</b><%# DataBinder.Eval(Container.DataItem, "Int") %></td>
                                    <td
                                        style="border-style: none; padding: 0px; font-size: 8pt; width: 115px;"><b>Cha</b>&nbsp;<%# DataBinder.Eval(Container.DataItem, "Cha") %></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div
                        style="padding: 2px 0px 3px 5px; background-color: rgb(221, 221, 204);">
                        <div
                            style="float: right; width: 210px;">
                            <b>Languages</b> <%# DataBinder.Eval(Container.DataItem, "Lang") %>
                        </div>
                        <b>Alignment</b> <%# DataBinder.Eval(Container.DataItem, "Align") %><br>
                        <b>Equipment</b>
                    </div>
                    <br>
                </div>
                    </ItemTemplate>
                </asp:Repeater>

</asp:Content>