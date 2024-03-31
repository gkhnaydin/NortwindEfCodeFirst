using NortwindEfCodeFirst.Entities;
using System.Data.Entity;

namespace NortwindEfCodeFirst.Contexts
{
    public class NorthwindContext :DbContext
    {  
        public DbSet<Customer>  Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
