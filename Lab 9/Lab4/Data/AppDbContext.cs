using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lab4.Data.Entities;

namespace Lab4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }

        public System.Data.Entity.DbSet<Lab4.Models.View.PetViewModel> PetViewModels { get; set; }

        public System.Data.Entity.DbSet<Lab4.Models.View.UserViewModel> UserViewModels { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {

    }
}