using Gymbokning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
                        
            builder.Entity<ApplicationUserGymClass>().HasKey(au => new { au.ApplicationUserId, au.GymClassId });

            

        }

        
    }
}
