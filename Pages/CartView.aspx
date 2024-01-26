﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="Apotheke.Pages.CartView" 
    MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <h2>Ваша корзина</h2>
        <table id="cartTable">
            <thead>
                <tr>
                    <th>Количество</th>
                    <th>Название</th>
                    <th>Цена</th>           
                    <th>Общая стоимость</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" ItemType="Apotheke.Models.CartLine"
                    SelectMethod="GetCartLines" runat="server"  EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Quantity %></td>
                            <td><%# Item.Drug.Name %></td>
                            <td><%# Item.Drug.Price.ToString("c")%></td>
                            <td><%# ((Item.Quantity * 
                                Item.Drug.Price).ToString("c"))%></td>
                            <td>
                                
                                <button type="submit" class="actionButtons" name="remove"
                                    value="<%#Item.Drug.DrugID %>">
                                    Удалить</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">Итого:</td>
                    <td><%= CartTotal.ToString("c") %></td>
                </tr>
            </tfoot>
        </table>
        <p class="actionButtons">
            <a href="<%= ReturnUrl %>">Продолжить покупки</a>
             <a href="<%= CheckoutUrl %>">Оформить заказ</a>
        </p>
    </div>
</asp:Content>