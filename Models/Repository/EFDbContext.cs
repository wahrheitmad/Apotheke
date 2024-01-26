using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Apotheke.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Apoteke> Apotekes { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        

    }
}