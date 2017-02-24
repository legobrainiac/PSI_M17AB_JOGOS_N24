<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="add_product.aspx.cs" Inherits="PSI_M17AB_JOGOS_N24.add_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label mdl-cell mdl-cell--12-col">
        <label for="productName" class="mdl-textfield__label mdl-color-text--white">Product Name</label>
        <asp:TextBox ID="productName" CssClass="mdl-textfield__input" runat="server"></asp:TextBox>
    </div>
    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label mdl-cell mdl-cell--12-col">
        <label for="productDescription" class="mdl-textfield__label mdl-color-text--white">Product Description</label>
        <asp:TextBox ID="productDescription" CssClass="mdl-textfield__input" runat="server"></asp:TextBox>
    </div>
    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label mdl-cell mdl-cell--12-col">
        <label for="productPrice" class="mdl-textfield__label mdl-color-text--white">Price ( ͡° ͜ʖ ͡°)</label>
        <asp:TextBox ID="productPrice" CssClass="mdl-textfield__input" TextMode="Number" runat="server"></asp:TextBox>
    </div>

    <asp:FileUpload ID="fuImage" runat="server" CssClass="mdl-textfield__input mdl-button" />

    <div class="mdl-cell mdl-cell--12-col" align="center">
        <asp:Button ID="btnAdd" CssClass="mdl-button mdl-js-ripple-effect mdl-js-button mdl-button--raised mdl-button--colored" Text="Add" runat="server" OnClick="btnAdd_Click" />
    </div>
    <asp:Label id="lblError" runat="server"></asp:Label>

</asp:Content>
