using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersianEden.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.DataLayer.EntityConfiguration
{
    class NameConfiguration: IEntityTypeConfiguration<Name>
    {
        public void Configure(EntityTypeBuilder<Name> builder)
        {
            builder.ToTable("FullName");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FullName).IsRequired();
        }
    }
}
