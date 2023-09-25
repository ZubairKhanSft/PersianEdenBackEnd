using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersianEden.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.DataLayer.EntityConfiguration
{
    public class HebrewMonthConfiguration : IEntityTypeConfiguration<HebrewMonth>
    {
        public void Configure(EntityTypeBuilder<HebrewMonth> builder)
        {
            builder.ToTable("Hebrewmonth");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.MonthName).IsRequired();
           /* builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();*/
        }
    }
}
