<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="PSI_M17AB_JOGOS_N24.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label mdl-color-text--white">
        <label for="input_text" class="mdl-textfield__label mdl-color-text--white">Username</label>
        <input type="text" class="mdl-textfield__input mdl-color-text--white" id="input_text" />
    </div> <br />

    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label mdl-color-text--white">
        <label for="input_email" class="mdl-textfield__label mdl-color-text--white">Email</label>
        <input type="email" class="mdl-textfield__input mdl-color-text--white" id="input_email" />
    </div> <br />

    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label mdl-color-text--white">
        <label for="input_password" class="mdl-textfield__label mdl-color-text--white">Password</label>
        <input type="password" pattern="[0-9]*" class="mdl-textfield__input mdl-color-text--white" id="input_password" />
        <span class="mdl-textfield__error mdl-color-text--white">Digits only</span>
    </div> <br />
</asp:Content>
