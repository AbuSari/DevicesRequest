namespace DevicesRequest.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    public partial class DevicesRequestContext : DbContext
    {
        public DevicesRequestContext()
            : base("name=DevicesRequestContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminRole> AdminRoles { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<PoRceived> PoRceiveds { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<RequestItem> RequestItems { get; set; }
        public virtual DbSet<RequestStatu> RequestStatus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<TypeOfRequest> TypeOfRequests { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasMany(e => e.AdminRoles)
                .WithRequired(e => e.Admin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.RequestItems)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Shipments)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PoRceived>()
                .HasMany(e => e.Shipments)
                .WithRequired(e => e.PoRceived)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestItem>()
                .HasMany(e => e.Reports)
                .WithOptional(e => e.RequestItem)
                .HasForeignKey(e => new { e.ItemId, e.UserId });

            modelBuilder.Entity<RequestStatu>()
                .HasMany(e => e.RequestItems)
                .WithOptional(e => e.RequestStatu)
                .HasForeignKey(e => e.StutusId);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.AdminRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RequestItems)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
