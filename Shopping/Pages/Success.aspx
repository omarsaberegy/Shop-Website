<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="Shopping.Pages.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Choose your payement Type</h2>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
    

    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Location"></asp:Label>
    <br />

    <asp:TextBox ID="TextBox1" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Phone "></asp:Label>
    <br />
    <asp:TextBox ID="TextBox3" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Credit number"></asp:Label>
    <br />
     <asp:TextBox ID="TextBox2" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit Payment " CssClass="button" OnClick="Button1_Click" Width="186px" />
    <br />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <br />



 
</asp:Content>
