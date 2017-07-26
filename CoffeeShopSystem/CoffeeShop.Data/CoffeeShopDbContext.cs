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
            this.Configuration.LazyLoadingEnabled = false; //load bảng cha k tự động include bảng con
        }
        public DbSet<Shop> Shops { get; set; } 
        public DbSet<City>  Citys { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<GroupTable> GroupTables { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShopUser> ShopUsers { get; set; }

        //DbSet cac class trong db. vd public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            
        }
    }
}
