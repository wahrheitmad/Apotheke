using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apotheke.Models
{
    public class Drug
    {
        public int DrugID { get; set; }
        public int ProducerID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int Expiration { get; set; }
        public decimal Price { get; set; }
        public bool Rezept { get; set; }
        public string Category { get; set; }
        public byte[] ImageData { get; set; }
       
        public Producer Producer { get; set; }
    }
}