<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TnpSystem.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadText" runat="server">
    <h2>Password Reset</h2>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span><i class="fa fa-user-o" aria-hidden="true"></i></span>
     <asp:TextBox ID="LoginTextBox" runat="server" name="username" placeholder="enter your id" required="" OnTextChanged="LoginTextBox_TextChanged"></asp:TextBox>
    <asp:Button ID="LoginButton" runat="server" Text="Reset" OnClick="LoginButton_Click"  />
  </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ForgotPassword" runat="server">
    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="SuccessLabel" runat="server" ForeColor="Green"></asp:Label>
</asp:Content>
