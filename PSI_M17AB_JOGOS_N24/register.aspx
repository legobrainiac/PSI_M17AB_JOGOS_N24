<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="PSI_M17AB_JOGOS_N24.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .util-center {
            margin: auto;
        }

        .util-max-512px {
            max-width: 512px;
        }

        .util-spacing-h--40px {
            margin-top: 40px;
            margin-bottom: 40px
        }

        .util-no-decoration {
            text-decoration: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- LOGIN FORM -->
    <div class="mdl-grid">
        <div class="mdl-card mdl-shadow--16dp util-center util-spacing-h--40px">
            <div class="mdl-card__title mdl-color--orange-800">
                <h2 class="mdl-card__title-text mdl-color-text--white">User Login</h2>
            </div>
            <div class="mdl-card__supporting-text mdl-grid">
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label mdl-cell mdl-cell--12-col">
                    <label for="tbUsernameLogin" class="mdl-textfield__label">Username</label>
                    <asp:TextBox ID="tbUsernameLogin" CssClass="mdl-textfield__input" runat="server"></asp:TextBox>
                </div>

                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label mdl-cell mdl-cell--12-col">
                    <label for="tBpasswordLogin" class="mdl-textfield__label">Password</label>
                    <asp:TextBox ID="tBpasswordLogin" runat="server" CssClass="mdl-textfield__input" TextMode="Password"></asp:TextBox>
                </div>

                <div class="mdl-cell mdl-cell--12-col send-button" align="center">
                    <asp:Button ID="btnLogin" CssClass="mdl-button mdl-js-ripple-effect mdl-js-button mdl-button--raised mdl-button--colored" Text="Login" runat="server" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>
    </div>


    <div class="mdl-grid">
        <div class="mdl-card mdl-shadow--16dp util-center util-spacing-h--40px">
            <div class="mdl-card__title mdl-color--teal-500">
                <h2 class="mdl-card__title-text mdl-color-text--white">Create a New Account</h2>
            </div>
            <div class="mdl-card__supporting-text mdl-grid">

                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label mdl-cell mdl-cell--12-col">
                    <label for="tbUsername" class="mdl-textfield__label">Username</label>
                    <asp:TextBox ID="tbUsername" CssClass="mdl-textfield__input" runat="server"></asp:TextBox>
                </div>

                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label mdl-cell mdl-cell--12-col">
                    <label for="tbEmail" class="mdl-textfield__label">Email</label>
                    <asp:TextBox ID="tbEmail" CssClass="mdl-textfield__input" runat="server"></asp:TextBox>
                </div>

                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label mdl-cell mdl-cell--12-col">
                    <label for="tBpassword" class="mdl-textfield__label">Password</label>
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="mdl-textfield__input" TextMode="Password"></asp:TextBox>
                </div>

                <div class="mdl-cell mdl-cell--12-col send-button" align="center">
                    <asp:Button ID="btnRegister" CssClass="mdl-button mdl-js-ripple-effect mdl-js-button mdl-button--raised mdl-button--colored" Text="Register" runat="server" OnClick="btnRegister_Click" />
                </div>
            </div>
        </div>
    </div>
    <span class="mdl-chip">
        <span class="mdl-chip__text">
            <asp:Label ID="lblErro" runat="server"></asp:Label>
        </span>
    </span>
</asp:Content>
