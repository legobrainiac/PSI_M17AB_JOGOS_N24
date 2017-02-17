<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="PSI_M17AB_JOGOS_N24.product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mdl-layout mdl-js-layout">
        <style>
            .demo-card-image.mdl-card {
                width: 640px;
                height: 360px;
                background: url('../pics/1.jpg') center / cover;
            }

            .demo-card-image__filename {
                color: #fff;
                font-size: 14px;
                font-weight: 500;
            }
        </style>

        <div class="demo-card-image mdl-card mdl-shadow--2dp mdl-card">
            <div class="mdl-card__title mdl-card--expand"></div>
            <div class="mdl-card__actions">
                <span class="demo-card-image__filename">CrawlFactory</span>
            </div>
        </div>
        <div class="demo-updates mdl-card mdl-cell--6-col mdl-color--blue-grey-900 mdl-color-text--white">
            <div class="mdl-card__title mdl-color-text--white">
                <h1 class="mdl-card__title-text">CrawlFactory</h1>
            </div>

            <div class="mdl-card__supporting-text mdl-color-text--white">
                I AM TEXTS HUE HUE HUE
            </div>
        </div>
    </div>
</asp:Content>
