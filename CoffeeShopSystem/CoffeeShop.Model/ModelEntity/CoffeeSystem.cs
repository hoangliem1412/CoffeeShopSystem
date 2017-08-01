namespace CoffeeShop.Model.ModelEntity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CoffeeSystemDbContext : DbContext
    {
        public CoffeeSystemDbContext()
            : base("name=CoffeeSystemConnection")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<GroupTable> GroupTables { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialCategory> MaterialCategories { get; set; }
        public virtual DbSet<MaterialLog> MaterialLogs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ShopUser> ShopUsers { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
        public virtual DbSet<MaterialView> MaterialViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Districts)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Wards)
                .WithRequired(e => e.District)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupTable>()
                .Property(e => e.Surcharge)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GroupTable>()
                .HasMany(e => e.Tables)
                .WithRequired(e => e.GroupTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaterialCategory>()
                .HasMany(e => e.Materials)
                .WithOptional(e => e.MaterialCategory)
                .HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<MaterialLog>()
                .Property(e => e.PreInventory)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalMoney)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderProducts)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderProduct>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderProduct>()
                .Property(e => e.Money)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderProducts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Promotion>()
                .Property(e => e.BasePurchase)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Promotion>()
                .Property(e => e.Discount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Promotion>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.ShopUsers)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Tables)
                .WithRequired(e => e.Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Table>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Table)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MaterialLogs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.EmployeeID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ShopUsers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
