using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theme_Seller.Domain.Entities.Themes;
using Theme_Seller.Domain.Entities.Users;

namespace Theme_Seller.Application.Interfaces.Context
{
    public interface IDataBaseContext
    {


        DbSet<User> Users { get; set; }
        public DbSet<ThemeCategories> Categories { get; set; }
        public DbSet<Theme> themes { get; set; }
        public DbSet<ThemeImages> ThemeImages { get; set; }
        public DbSet<ThemeFeatures> ThemeFeatures { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,CancellationToken cancellationToken=new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken());

    }
}
