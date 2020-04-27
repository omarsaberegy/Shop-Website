<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Shopping.Pages.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlShoppingCart" runat="server">

    </asp:Panel>
    <table>
        <tr>
            <td><b>Total: </b></td>
            <td><asp:Literal ID="litTotal" runat="server" Text="" /></td>
        </tr>
        <tr>
            <td><b>Vat: </b></td>
            <td><asp:Literal ID="LitVat" runat="server" Text="" /></td>
        </tr>
        <tr>
            <td><b>Shipping: </b></td>
            <td>$ 15</td>
        </tr>
        <tr>
            <td><b>Total Amount: </b></td>
            <td><asp:Literal ID="LitTotalAmount" runat="server" Text="" /></td>
        </tr>
        <tr>
            <td>
               <asp:Button  runat="server" Width="250px" CssClass="button" PostBackUrl="~/Index.aspx" Text="Continue Shopping"/>
                OR
                <asp:Button ID="btnCheckOut" runat="server" PostBackUrl="~/Pages/Success.aspx" CssClass="button" 
                    Width="250px" Text="Continue CheckOut" />
            </td>
        </tr>


    </table>
</asp:Content>
