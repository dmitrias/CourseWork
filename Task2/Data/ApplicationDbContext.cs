using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task2.Models;

namespace Task2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Recepie> RecepieCollection { get; set; }

          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
          {
          }
          
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Recepie>()
                .HasMany(a => a.RecepieComments)
                .WithOne(b => b.Recepie);

            builder.Entity<ApplicationUser>()
                .HasMany(a => a.UserComments)
                .WithOne(b => b.Author);

            builder.Entity<ApplicationUser>()
                .HasMany(a => a.UserRecepies)
                .WithOne(b => b.RecepieAuthor);

            base.OnModelCreating(builder);
            
        }
    }
}