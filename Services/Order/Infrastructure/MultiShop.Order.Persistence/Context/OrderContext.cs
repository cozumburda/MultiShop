using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441;initial Catalog=MultiShopOrderDb;user=sa;password=A123456789?a");
        }

        public DbSet<Address> Addresses {  get; set; } 
        public DbSet<OrderDetail> OrderDetails {  get; set; } 
        public DbSet<Ordering> Orderings {  get; set; } 
    }
}
