using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Apotheke.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Drug> Drugs
        {
            get { return context.Drugs
                    .Include(p => p.Producer); }
        }
        public IEnumerable<User> Users
        {
            get
            {
                return context.Users;
                    
            }
        }

        public IEnumerable<Producer> Producers
        {
            get { return context.Producers; }
        }

        public IEnumerable<Apoteke> Apotekes
        {
            get { return context.Apotekes; }
        }

        // Чтение данных из таблицы Orders
        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders
                    .Include(o => o.OrderLines.Select(ol => ol.Drug))
                    ;
            }
        }

        // Сохранить данные заказа в базе данных
        public void SaveOrder(Order order)
        {
            if (order.OrderID == 0)
            {
                order = context.Orders.Add(order);

                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Drug).State
                        = EntityState.Modified;
                }

            }
            else
            {
                Order dbOrder = context.Orders.Find(order.OrderID);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Line1 = order.Line1;
                    dbOrder.City = order.City;
                    dbOrder.GiftWrap = order.GiftWrap;
                    dbOrder.Dispatched = order.Dispatched;
                    dbOrder.ApotekeID = order.ApotekeID;
                    dbOrder.Status = order.Status;
                    dbOrder.UserID = order.UserID;
                    dbOrder.OrderDate = order.OrderDate;
                }
            }
            context.SaveChanges();
        }


    }
}