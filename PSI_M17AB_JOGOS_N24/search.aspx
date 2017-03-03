<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="PSI_M17AB_JOGOS_N24.search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mdl-textfield mdl-js-textfield mdl-textfield--expandable mdl-color-text--white">
        <asp:TextBox ID="tbSearch" runat="server" CssClass="mdl-textfield__input mdl-color-text--white" OnTextChanged="tbSearch_TextChanged"></asp:TextBox>
        <label for="tbSearch" class="mdl-textfield__label mdl-color-text--white">Search</label>
    </div>

    <div id="divResult" class="mdl-grid demo-content mdl-color--blue-grey-900" runat="server"></div>
</asp:Content>
