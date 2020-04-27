<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Shopping.Pages.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </p>
    <p>
        User Name</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        First Name</p>
    <p>
        <asp:TextBox ID="TextBox4" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        Last Name</p>
    <p>
        <asp:TextBox ID="TextBox5" runat="server" CssClass="inputs" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
    </p>
    <p>
        Address</p>
    <p>
        <asp:TextBox ID="TextBox6" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        Postal Card</p>
    <p>
        <asp:TextBox ID="TextBox7" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        Password</p>
    <p>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="inputs"  TextMode="Password"></asp:TextBox>
    </p>
    <p>
        Confirm Password</p>
    <p>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="Submit Account" Width="125px" />
    </p>
    </asp:Content>
