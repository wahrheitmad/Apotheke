using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apotheke.Models
{
    public class Apoteke
    {
        public int ApotekeID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Contacts { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

    }
}