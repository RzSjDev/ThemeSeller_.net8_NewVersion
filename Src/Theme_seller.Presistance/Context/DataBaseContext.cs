using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theme_Seller.Application.Interfaces.Context;
using Theme_Seller.Domain.Entities.Themes;
using Theme_Seller.Domain.Entities.Users;

namespace Theme_seller.Presistance.Context
{
    public class DataBaseContext:DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ThemeCategories> Categories { get; set; }
        public DbSet<Theme> themes { get; set; }
        public DbSet<ThemeImages> ThemeImages { get; set; }
        public DbSet<ThemeFeatures> ThemeFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            ApplyQueryFilter(modelBuilder);
        }
        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ThemeCategories>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Theme>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ThemeImages>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ThemeFeatures>().HasQueryFilter(p => !p.IsRemoved);
        }

    }
}
