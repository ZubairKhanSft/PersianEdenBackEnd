using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersianEden.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.DataLayer.EntityConfiguration
{
    public class FuneralVideoConfiguration : IEntityTypeConfiguration<FuneralVideo>
    {
        public void Configure(EntityTypeBuilder<FuneralVideo> builder)
        {
            builder.ToTable("FuneralVideo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.VideoPath).IsRequired();
            builder.Property(x => x.DeceasedId).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}
