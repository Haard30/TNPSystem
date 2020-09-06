<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TnpSystem.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="HeadText" runat="server">
    <h2>Login Now</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span><i class="fa fa-user-o" aria-hidden="true"></i></span>
     <asp:TextBox ID="LoginTextBox" runat="server" name="username" placeholder="enter your id" required="" OnTextChanged="LoginTextBox_TextChanged"></asp:TextBox>
   
                    <%--<input type="text" name="username" placeholder="enter your name" required="">--%>
                    <span><i class="fa fa-unlock-alt" aria-hidden="true"></i></span>
    <asp:TextBox ID="PasswordTextBox" runat="server" name="password" TextMode="Password" placeholder="enter your password" required="" OnTextChanged="PasswordTextBox_TextChanged"></asp:TextBox>
                    <%--<input type="password" name="password" placeholder="enter your password" required="">--%>
   
    
    <asp:Button ID="LoginButton" runat="server" Text="login" OnClick="LoginButton_Click" />
                    <%--<input type="submit" value="login">--%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ForgotPassword" runat="server">
    <div class="login-password">
                        <span><a href="ForgotPassword.aspx">forgot password</a></span>
                    </div>
    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
    </asp:Content>