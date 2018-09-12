using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DevicesRequest.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public System.Data.Entity.DbSet<DevicesRequest.Models.RequestStatu> RequestStatu { get; set; }
        public System.Data.Entity.DbSet<DevicesRequest.Models.RequestItem> RequestItem { get; set; }
        public System.Data.Entity.DbSet<DevicesRequest.Models.Level> Level { get; set; }
        public System.Data.Entity.DbSet<DevicesRequest.Models.Building> Building { get; set; }
        public System.Data.Entity.DbSet<DevicesRequest.Models.Department> Department { get; set; }
        public System.Data.Entity.DbSet<DevicesRequest.Models.TypeOfRequest> TypeOfRequest { get; set; }
        public System.Data.Entity.DbSet<DevicesRequest.Models.Position> Position { get; set; }
        public System.Data.Entity.DbSet<DevicesRequest.Models.Item> Item { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}