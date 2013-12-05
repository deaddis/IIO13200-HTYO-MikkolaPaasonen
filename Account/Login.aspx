<%@ Page Title="Login" Language="C#" MasterPageFile="~/TopBar.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        Log In
    </h2>
        <h5>Please enter your username and password.</h5>
        <h5><asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Register </asp:HyperLink> if you don't have an account.</h5>

    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
        <LayoutTemplate>
            <h4>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                 ValidationGroup="LoginUserValidationGroup"/></h4>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Account Information</legend> 
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName"><h4>Username:</h4></asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                             CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password"><h4>Password:</h4></asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <h5><asp:CheckBox ID="RememberMe" runat="server"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label></h5>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" Text="Log In" ValidationGroup="LoginUserValidationGroup" OnClick="LoginButton_Click"/>
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
    <asp:Label ID="lblNotes" runat="server" />
</asp:Content>

