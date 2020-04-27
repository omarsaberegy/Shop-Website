<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Filters.aspx.cs" Inherits="Shopping.Pages.Filters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Choose a Category to display : </h2>
    <asp:DropDownList ID="ddl_list" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name" Width="234px" Height="16px">
        </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=HP-PC;Initial Catalog=Shop;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Name] FROM [Category] ORDER BY [Name]"></asp:SqlDataSource>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Get Products" CssClass="button" OnClick="Button1_Click" Width="225px"  />
 
    <asp:Panel ID="pnlProducts" runat="server" BackImageUrl="~/Product.aspx">
        
</asp:Panel>
    <div style="clear:both" ></div>
</asp:Content>
