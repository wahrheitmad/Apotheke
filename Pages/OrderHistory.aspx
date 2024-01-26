<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="Apotheke.Pages.OrderHistory" 
 MasterPageFile="~/Pages/Store.Master" %>


<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <h2>Ваша заказы</h2>
        <table id="orderTable">
            <thead>
                <tr>
                    <th>Номер</th>
                    <th>Дата заказа</th>           
                    <th>Статус</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" ItemType="Apotheke.Models.Order"
                    SelectMethod="GetOrders" runat="server"  EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.OrderID %></td>
                            <td><%# Item.OrderDate.ToShortDateString() %></td>
                            <td><%# Item.Status%></td>              
                                <td><button type="submit" class="actionButtons" name="info"
                                    value="<%#Item.OrderID %>">
                                    Детальная информация</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>      
        </table>
    </div>
    </asp:Content>
