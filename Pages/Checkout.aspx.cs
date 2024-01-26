using Apotheke.Models;
using Apotheke.Models.Repository;
using Apotheke.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;

namespace Apotheke.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected internal Order myOrder;
        Cart myCart;
        EFDbContext db = new EFDbContext();

        

        protected void Page_Load(object sender, EventArgs e)
        {
            
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;         
            EFDbContext db = new EFDbContext();
            var apos = db.Apotekes.ToList();
            ApotekeID.DataSource = apos;
            ApotekeID.DataTextField = "Name";
            ApotekeID.DataValueField = "ApotekeID";
            ApotekeID.DataBind();

            
            if (IsPostBack)
            {
                myOrder = new Order();
                myOrder.ApotekeID = Int32.Parse(ApotekeID.SelectedValue);
                myOrder.OrderDate = DateTime.Today;
                if (Login.IsLoggedIn == true) { myOrder.UserID = Login.user.UserID; }
                myOrder.Status = "Заказ обрабатывается";
                if (TryUpdateModel(myOrder,
                   new FormValueProvider(ModelBindingExecutionContext)))
                {

                    myOrder.OrderLines = new List<OrderLine>();

                    myCart = SessionHelper.GetCart(Session);

                    foreach (CartLine line in myCart.Lines)
                    {
                        myOrder.OrderLines.Add(new OrderLine
                        {
                            Order = myOrder,
                            Drug = line.Drug,
                            Quantity = line.Quantity
                        });
                    }

                    new Repository().SaveOrder(myOrder);
                    myCart.Clear();

                    checkoutForm.Visible = false;
                 
                    checkoutMessage.InnerHtml = GetOrderInfo();
                  
                    checkoutMessage.Visible = true;
                }
            }
            


        }



        public string GetOrderInfo()
        {
            decimal totalValue = 0;
            Apoteke apoteke = db.Apotekes.Find(myOrder.ApotekeID);
            string info = "<h2>Спасибо!</h2>\r\n" +
                "<a> Спасибо что выбрали нас! Мы постараемся максимально быстро отправить ваш заказ</a>  <div>&nbsp;</div>";
            if (myOrder.PickUp == true)
            {
                info += "Заказ номер "+ myOrder.OrderID + " на имя " + myOrder.Name + " можно забрать в аптеке " + apoteke.Name + " по адресу " + apoteke.Adress + ". Часы работы аптеки:" + apoteke.StartTime +  " - " + apoteke.EndTime +"<div>&nbsp;</div>";
            }
            else
            {
                info += "Заказ номер " + myOrder.OrderID + " на имя " + myOrder.Name + " будет доставлен по адресу " + myOrder.Line1 + "<div>&nbsp;</div>";
            }
            info += "Наш менеджер в скором времени свяжется с вами по вопросам оплаты.<div>&nbsp;</div> ";
            info += "Содержимое заказа:<div>&nbsp;</div>";
            info += "<table class=\"center\">\r\n  <tr>\r\n    <th>Наименование</th>\r\n    <th>Количество</th>\r\n    <th>Цена за экземпляр</th>\r\n  </tr>";
            foreach (OrderLine orderLine in myOrder.OrderLines)
            {
                Drug drug = db.Drugs.Find(orderLine.Drug.DrugID);
                info += "<tr>\r\n    <td>" + drug.Name + "</td>\r\n    <td>" + orderLine.Quantity + "</td>\r\n    <td>" + drug.Price + "</td>\r\n  </tr> \r\n";
                totalValue += orderLine.Quantity * drug.Price;
            }
            info += "</table><div>&nbsp;</div>";
            info += "Итоговая цена: " + totalValue.ToString("c");

            return info;
        }

        protected void ApotekeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApotekeID.SelectedValue = ApotekeID.SelectedItem.Value;
            Apoteke apoteke = db.Apotekes.Find(Int32.Parse(ApotekeID.SelectedValue));
            selectedApo.InnerText = "Адрес аптеки: " + apoteke.Adress;
        }

       


    }
}