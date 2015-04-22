namespace WebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WorkerContext : DbContext
    {
        public WorkerContext()
            : base("name=WorkerContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
