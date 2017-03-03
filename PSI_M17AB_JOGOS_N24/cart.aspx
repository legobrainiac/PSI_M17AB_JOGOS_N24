<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="PSI_M17AB_JOGOS_N24.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cart:</h1>
    <div id="divCart" runat="server">
    </div>
    <div class="mdl-cell--12-col" align="center">
        <asp:Button ID="btnCheckout" CssClass="mdl-button mdl-js-ripple-effect mdl-js-button mdl-button--raised mdl-button--colored" Text="Checkout" runat="server" OnClick="btnCheckout_Click" />
    </div>
</asp:Content>
