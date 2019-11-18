using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using mvcday1.Models.filters;

namespace mvcday1.Models
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
        [Required]
        [Column(TypeName = "varchar")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        public string LastName { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("RAMAMVC", throwIfV1Schema: false)
        {
              

    }
       

        public static ApplicationDbContext Create()// dbcontext represents database
        {
          
            return new ApplicationDbContext();
        }
        public DbSet<Customer> Customers { get; set; }//dbset represents table
        public DbSet<MOVIE> Movies { get; set; }
        public DbSet<MemberShipType> MemberShipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
         public DbSet<DbLogger> DbLoggers { get; set; }
     
   
    }
}