<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="Apotheke.Pages.Listing"
 MasterPageFile="~/Pages/Store.Master" %>
<%@ Import Namespace="System.Web.Routing" %>




<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
       
    </div>
        <div class="cards">
       <asp:Repeater ID="Repeater1" ItemType="Apotheke.Models.Drug" runat="server" SelectMethod="GetSearchedDrugs" ClientIDMode="Inherit">
            <ItemTemplate>
                <article class="card">
                    <h2><%# Item.Name %></h2>
                    <img src="<%#GetPath(Item)%>" style="width:40%" runat="server" />
                   
                    <h3 style ="color:dimgrey"><%# Item.Producer.Name %></h3>
                    <h4>В наличии: <%# Item.Amount.ToString() %> шт</h4>
                    <h4><%# Item.Price.ToString("c") %></h4>
                    <button name="add" title="Добавить в корзину" type="submit" value="<%# Item.DrugID %>">     
                    </button>
                </article>
            </ItemTemplate>
        </asp:Repeater>
            </div>
        </div>
   <div class="pager">
        <%
            for (int i = 1; i <= MaxPage; i++)
            {string path = RouteTable.Routes.GetVirtualPath(null, null,
                    new RouteValueDictionary() { { "page", i } }).VirtualPath;
                Response.Write(
                    String.Format("<a href='{0}' {1}>{2}</a>",
                        path, i == CurrentPage ? "class='selected'" : "", i));
            }
        %>
    </div>
    </asp:Content>
