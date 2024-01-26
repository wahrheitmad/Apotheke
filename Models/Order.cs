using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Apotheke.Models
{  
        public class Order
        {
            public int OrderID { get; set; }

            [Required(ErrorMessage = "Пожалуйста введите свое имя")]
            public string Name { get; set; }

            //[Required(ErrorMessage = "Вы должны указать хотя бы один адрес доставки")]
            public string Line1 { get; set; }

            //public string Line2 { get; set; }
            //public string Line3 { get; set; }

            [Required(ErrorMessage = "Пожалуйста укажите город, куда нужно доставить заказ")]
            public string City { get; set; }
            public bool GiftWrap { get; set; }
            public bool Dispatched { get; set; }
            public int ApotekeID { get; set; }  
            public bool PickUp { get; set; }
            public int UserID { get; set; }
            public DateTime OrderDate { get; set; }
            public string Status { get; set; }
            [NotMapped]
            public User User { get; set; }
            public virtual List<OrderLine> OrderLines { get; set; }
            


        }

        public class OrderLine
        {
            public int OrderLineID { get; set; }
            public Order Order { get; set; }
            public Drug Drug { get; set; }
            public int Quantity { get; set; }
        }
}