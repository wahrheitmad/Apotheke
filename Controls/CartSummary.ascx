<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartSummary.ascx.cs" Inherits="Apotheke.Controls.CartSummary" %>

<div id="cartSummary">
    <span class="caption">
        <b>В корзине:</b>
        <span id="csQuantity" runat="server"></span> товаров на сумму
        <span id="csTotal" runat="server"></span>
    </span>
    <a id="csLink" runat="server">Корзина</a>
</div>