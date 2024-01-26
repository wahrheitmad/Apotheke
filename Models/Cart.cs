using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apotheke.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Drug drug, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Drug.DrugID == drug.DrugID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Drug = drug,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Drug drug)
        {
            lineCollection.RemoveAll(l => l.Drug.DrugID == drug.DrugID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Drug.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Drug Drug { get; set; }
        public int Quantity { get; set; }
    }

}
