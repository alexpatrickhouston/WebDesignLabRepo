using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab8.Data.Entities;
namespace Lab8.Models
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

        public class AppDbContext : IdentityDbContext<ApplicationUser>
        {
            public AppDbContext(): base("DefaultConnection",throwIfV1Schema: false)
            {
                this.Configuration.LazyLoadingEnabled = false;
            }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
            base.OnModelCreating(modelBuilder);
        }
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
            public virtual DbSet<Pet> Pets { get; set; }

        public System.Data.Entity.DbSet<Lab8.Models.View.PetViewModel> PetViewModels { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
        {

        }
    }
