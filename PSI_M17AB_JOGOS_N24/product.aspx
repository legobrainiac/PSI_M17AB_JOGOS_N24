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
                <asp:Image ID="img" runat="server" Width="640" Height="360" />
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
                <h4>
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </h4>
            </div>
        </div>

        <div class="mdl-card mdl-card mdl-cell--6-col mdl-color--blue-grey-600 mdl-color-text--white">
            <h4>Title</h4>
            <asp:TextBox ID="tbTitle" CssClass="mdl-textfield__input mdl-color-text--white" runat="server"></asp:TextBox>
            <h6>Body</h6>
            <asp:TextBox ID="tbBody" CssClass="mdl-textfield__input mdl-color-text--white" runat="server"></asp:TextBox>

            <div class="mdl-cell--12-col" align="center">
                <asp:Button ID="btnReview" CssClass="mdl-button mdl-js-ripple-effect mdl-js-button mdl-button--raised mdl-button--colored" Text="Review" runat="server" OnClick="btnReview_Click" />
            </div>


        </div>

        <div id="divReviews" runat="server">
        </div>

        <div id="divAdmin" runat="server">
            <div class="mdl-cell mdl-cell--12-col send-button">
                <asp:Button ID="btnDel" CssClass="mdl-button mdl-js-ripple-effect mdl-js-button mdl-button--raised mdl-button--colored" Text="Delete" runat="server" OnClick="btnDel_Click" />
            </div>


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
            <div class="mdl-cell mdl-cell--12-col" align="center">
                <asp:Button ID="btnEdit" CssClass="mdl-button mdl-js-ripple-effect mdl-js-button mdl-button--raised mdl-button--colored" Text="Edit" runat="server" OnClick="btnEdit_Click" />
            </div>
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
