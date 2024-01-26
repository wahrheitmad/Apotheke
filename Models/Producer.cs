using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apotheke.Models
{
    public class Producer
    {
        public int ProducerID { get; set; }
        public string Name { get; set; }
        public DateTime LicenseDate { get; set; }
        public int LicenseNumber { get; set; }
        public string Mail { get; set; }

        public List<Drug> Drugs { get; set; }
    }
}