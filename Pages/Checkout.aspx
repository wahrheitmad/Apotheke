<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Apotheke.Pages.Checkout"
MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">

        <div id="checkoutForm" class="checkout" runat="server">
            <h2>Оформить заказ</h2>
            Пожалуйста, введите свои данные, и мы отправим Ваш товар прямо сейчас!

        <div id="errors" data-valmsg-summary="true">
            <ul>
                <li style="display:none"></li>
            </ul>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>

            <h3>Заказчик</h3>
            <div>
                <label for="name">Имя:</label>
                <SX:VInput Property="Name" runat="server" />
            </div>
            <h3>Адрес доставки</h3>
            <div>
                <label for="line1">Адрес:</label>
              <SX:VInput Property= "Line1"  runat="server" />
                <br />
            </div>
            
            <div>
                &nbsp;</div>
            <div>
                <label for="city">Город:</label>
            <SX:VInput Property= "City" runat="server" />
            </div>
             <h2>Самовывоз</h2>  
            <input type="checkbox" id="pickup" name="pickup" value="true" />
            Отметьте, если хотите забрать заказ сами
                    
                <asp:DropDownList ID="ApotekeID" style="display:none; margin-top:10px; margin-left:7px" name="ApotekeID"  runat="server"  value="" OnSelectedIndexChanged ="ApotekeID_SelectedIndexChanged"   Height="20px"  Width="350px">
                </asp:DropDownList>
            <script type="text/javascript">
                let h3 = document.getElementById('pickup');
                
 h3.onclick = function(){
   this.nextElementSibling.style.display =  this.nextElementSibling.style.display == 'none' ? 'block' : 'none' ;
 }
            </script>
            <div id="selectedApo" runat="server">

            </div>
             &nbsp;<h3>Детали заказа</h3>              
            <input type="checkbox" id="giftwrap" name="giftwrap" value="true" />
            Использовать бумажный пакет? Соглашаясь, Вы делаете шаг навстречу нашей планете!
        
        <p class="actionButtons">
            <button class="actionButtons" type="submit">Обработать заказ</button>
        </p>
        </div>
        <div id="checkoutMessage" runat="server">
        </div>
         
    </div>
</asp:Content>