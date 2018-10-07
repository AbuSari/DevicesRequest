namespace DevicesRequest.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DevicesRequestDBContext : DbContext
    {
        public DevicesRequestDBContext()
            : base("name=DevicesRequestDBContext")
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<PoRceived> PoRceiveds { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<RequestItem> RequestItems { get; set; }
        public virtual DbSet<RequestStatu> RequestStatus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<TechnicianReport> TechnicianReports { get; set; }
        public virtual DbSet<TypeOfRequest> TypeOfRequests { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<TreatmentHistory> TreatmentHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Department1)
                .WithOptional(e => e.Department2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

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
                .HasMany(e => e.TechnicianReports)
                .WithOptional(e => e.RequestItem)
                .HasForeignKey(e => e.ReportItem);

            modelBuilder.Entity<RequestStatu>()
                .HasMany(e => e.RequestItems)
                .WithOptional(e => e.RequestStatu)
                .HasForeignKey(e => e.StutusId);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Departments)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ManagerId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RequestItems)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
