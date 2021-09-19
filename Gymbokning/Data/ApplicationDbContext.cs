using Gymbokning.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gymbokning.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole, string>
    {
        public DbSet<Gymbokning.Models.GymClass> GymClasses { get; set; }
        public DbSet<Gymbokning.Models.ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Gymbokning.Models.ApplicationUserGymClass> ApplicationUsersGymClasses { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().Property<DateTime>("TimeOfRegistration");

            builder.Entity<ApplicationUserGymClass>().HasKey(au => new { au.ApplicationUserId, au.GymClassId });

            

        }

        //public override int SaveChanges()
        //{

        //    ChangeTracker.DetectChanges();

        //    foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
        //    {
        //        entry.Property("TimeOfRegistration").CurrentValue = DateTime.Now;
        //    }

            


        //    return base.SaveChanges();
        //}




        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                if (entry.Entity is ApplicationUser)
                {
                    entry.Property("TimeOfRegistration").CurrentValue = DateTime.Now;
                }
                
            }

            return base.SaveChangesAsync(cancellationToken);
        }




    }
}
