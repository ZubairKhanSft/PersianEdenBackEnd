using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersianEden.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.DataLayer.EntityConfiguration
{
    public class PersianEdenUserConfiguration : IEntityTypeConfiguration<PersianEdenUser>

    {
        public void Configure(EntityTypeBuilder<PersianEdenUser> builder)
        {
            builder.ToTable("PersianEdenUser");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
        }
    }
}
