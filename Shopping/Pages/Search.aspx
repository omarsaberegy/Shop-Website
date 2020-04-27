<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Shopping.Pages.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Type a name of a product to search :</h2>
    <asp:TextBox ID="Search_name" runat="server" CssClass="inputs" Width="249px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="button" OnClick="Button1_Click" Width="153px" />
     <asp:Panel ID="pnlProducts" runat="server" BackImageUrl="~/Product.aspx">
        
</asp:Panel>
    <div style="clear:both" ></div>
</asp:Content>
