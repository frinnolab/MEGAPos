using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MEGAPos.Models
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

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
           : base("FrinnoConnect", throwIfV1Schema: false)
        {
            Database.SetInitializer(new NullDatabaseInitializer<ApplicationDbContext>());

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Sales_Header> Sales_Headers { get; set; }
        public DbSet<Sales_Detail> Sales_Details { get; set; }

        public DbSet<U_O_M> Units { get; set; }

        public DbSet<Purchase_Head> Purchase_Heads { get; set; }

        public DbSet<Purchase_Detail> Purchase_Details { get; set; }

        public DbSet<Stock_Take_Head> Stock_Takes { get; set; }

        public DbSet<Stock_Take_Detail> Stock_Take_Details { get; set; }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<SalesType> SalesTypes { get; set; }

        public DbSet<PriceList> PriceLists { get; set; }

        public DbSet<VAT> VATs { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorItems> VendorsItems { get; set; }
        public DbSet<VendorType> VendorTypes { get; set; }




        public System.Data.Entity.DbSet<MEGAPos.Models.ApplicationRole> IdentityRoles { get; set; }
    }
}