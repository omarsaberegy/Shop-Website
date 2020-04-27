<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Shopping.Pages.Account.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
<br />
User Name<br />
<asp:TextBox ID="TextBox1" runat="server" CssClass="inputs"></asp:TextBox>
<br />
Password<br />
<asp:TextBox ID="TextBox2" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
<br />
<br />
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Log In" CssClass="button" Width="101px" />
<br />
</asp:Content>
