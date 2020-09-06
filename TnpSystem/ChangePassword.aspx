<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TnpSystem.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="HeadText" runat="server">
    <h2>Password Reset</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <asp:TextBox ID="UserId" runat="server" name="username" placeholder="enter your id" required=""></asp:TextBox>

<asp:TextBox ID="PasswordTextBox1" runat="server" name="password" TextMode="Password" placeholder="enter your new password" required="" OnTextChanged="PasswordTextBox1_TextChanged"></asp:TextBox>
<asp:TextBox ID="PasswordTextBox2" runat="server" name="password" TextMode="Password" placeholder="confirm password" required=""></asp:TextBox>
<asp:Button ID="SavePassword" runat="server" Text="Save" OnClick="SavePassword_Click"/>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ForgotPassword" runat="server">
    <div class="login-password">
                        <span><a href="Login.aspx">Go To Login</a></span>
                    </div>
    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="SuccessLabel" runat="server" ForeColor="Green"></asp:Label>
    </asp:Content>
