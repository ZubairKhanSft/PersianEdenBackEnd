using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersianEden.DataLayer.EntityConfiguration;
using PersianEden.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.DataLayer
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Name> Names { get; set; }
        public DbSet<HebrewMonth> HebrewMonths { get; set; }
        public DbSet<PersianEdenUser> PersianEdenUsers { get; set; }
        public DbSet<DeceasedPerson> DeceasedPerson { get; set; }
        public DbSet<FuneralPictures> FuneralPictures { get; set; }
        public DbSet<FuneralVideo> FuneralVideo { get; set; }
        public DbSet<MemorialVideo> MemorialVideo { get; set; }
        public DbSet<MemorialPictures> MemorialPictures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NameConfiguration());
            modelBuilder.ApplyConfiguration(new HebrewMonthConfiguration());
            modelBuilder.ApplyConfiguration(new PersianEdenUserConfiguration());
            modelBuilder.ApplyConfiguration(new DeceasedPersonConfiguration());
            modelBuilder.ApplyConfiguration(new FuneralVideoConfiguration());
            modelBuilder.ApplyConfiguration(new FuneralPicturesConfiguration());
            modelBuilder.ApplyConfiguration(new MemorialVideoConfiguration());
            modelBuilder.ApplyConfiguration(new MemorialPicturesConfiguration());

        }

    }
}
