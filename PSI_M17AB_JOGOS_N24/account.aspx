<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="PSI_M17AB_JOGOS_N24.account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divUser" runat="server">
        
    </div>

    <h1>My Games:</h1>
        <div id="divGames" class="mdl-grid demo-content mdl-color--blue-grey-900" runat="server"></div>
    <div id="divAdmin" runat="server">
        admin
    </div>
</asp:Content>
