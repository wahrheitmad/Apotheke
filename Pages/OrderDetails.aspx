<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="Apotheke.Pages.OrderDetails"
    MasterPageFile="Store.Master"  %>

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
                <asp:Repeater ID="Repeater1" ItemType="Apotheke.Models.OrderLine"
                    SelectMethod="GetOrderLines" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Quantity %></td>
                            <td><%# Item.Drug.Name %></td>
                            <td><%# Item.Drug.Price.ToString("c")%></td>
                            <td><%# ((Item.Quantity * 
                                Item.Drug.Price).ToString("c"))%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">Итого:</td>
                    <td > 
                        <asp:TextBox id="totalValue" style="text-align:right" runat="server" BorderStyle="None" Font-Italic="True" Font-Bold="True">        
                        </asp:TextBox>
                       

                    </td>
                </tr>
            </tfoot>
        </table>
        <p class="actionButtons">
            <a href="<%= ReturnUrl  %>">Вернуться назад</a>
        </p>
    </div>
</asp:Content>