namespace WebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WorkerDBContext : DbContext
    {
        public WorkerDBContext()
            : base("name=WorkerDBContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RawMaterial> RawMaterials { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Tlf)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RawMaterial>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<RawMaterial>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.Tlf)
                .IsUnicode(false);
        }
    }
}
