namespace WEB_ShoesStore.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShoesDBContext : DbContext
    {
        public ShoesDBContext()
            : base("name=ShoesDBContext")
        {
        }

        public virtual DbSet<Account_Admin> Account_Admin { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<Attribute_Type> Attribute_Type { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Attribute> Product_Attribute { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account_Admin>()
                .Property(e => e.Ac_Password)
                .IsFixedLength();

            modelBuilder.Entity<Attribute>()
                .Property(e => e.Attribute_ID)
                .IsFixedLength();

            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.Attribute_Type)
                .WithRequired(e => e.Attribute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.Product_Attribute)
                .WithRequired(e => e.Attribute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Attribute_Type>()
                .Property(e => e.Attribute_Type_ID)
                .IsFixedLength();

            modelBuilder.Entity<Attribute_Type>()
                .Property(e => e.Attribute_ID)
                .IsFixedLength();

            modelBuilder.Entity<Credential>()
                .Property(e => e.UserGroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_ID)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.E_mail)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.C_Password)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone_Number)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_UserName)
                .IsFixedLength();

            modelBuilder.Entity<Manufacturer>()
                .Property(e => e.Manufacturer_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipMobile)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ProductID)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.OrderID)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Product_ID)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Manufacturer_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_Attribute)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product_Attribute>()
                .Property(e => e.Product_ID)
                .IsFixedLength();

            modelBuilder.Entity<Product_Attribute>()
                .Property(e => e.Attribute_ID)
                .IsFixedLength();

            modelBuilder.Entity<Product_Attribute>()
                .Property(e => e.Attribute_Type_ID)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.ID)
                .IsUnicode(false);
        }
    }
}
