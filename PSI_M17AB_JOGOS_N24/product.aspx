<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="PSI_M17AB_JOGOS_N24.product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .demo-card-image.mdl-card {
            width: 640px;
            height: 360px;
        }

        .demo-card-image__filename {
            color: #fff;
            font-size: 14px;
            font-weight: 500;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mdl-layout mdl-js-layout">
        <div class="demo-card-image mdl-card mdl-shadow--2dp mdl-card">
            <div class="mdl-card__media mdl-card--expand">
                <asp:Image ID="img" runat="server" Width="640" Height="360"/>
            </div>
            <div class="mdl-card__actions">
                <span class="demo-card-image__filename">
                    <asp:Label ID="lblTituloImg" runat="server"></asp:Label>
                </span>
            </div>
        </div>
        <div class="demo-updates mdl-card mdl-cell--6-col mdl-color--blue-grey-900 mdl-color-text--white">
            <div class="mdl-card__title mdl-color-text--white">
                <h1 class="mdl-card__title-text">
                    <asp:Label ID="lblTitulo" runat="server"></asp:Label></h1>
            </div>

            <div class="mdl-card__supporting-text mdl-color-text--white">
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
