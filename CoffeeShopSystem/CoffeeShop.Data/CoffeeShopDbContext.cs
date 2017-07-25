using CoffeeShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data
{
    public class CoffeeShopDbContext : DbContext
    {
        public CoffeeShopDbContext() : base() //truyen connection string
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        DbSet<Shop> Shops { get; set; } 
        //DbSet cac class trong db. vd public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            
        }
    }
}
